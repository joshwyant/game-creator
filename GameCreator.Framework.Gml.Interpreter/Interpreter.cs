using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using GameCreator.Runtime;

namespace GameCreator.Framework.Gml.Interpreter
{
    // Delegate for calling GML functions
    public delegate Value FunctionDelegate(params Value[] args);
    public static class Interpreter
    {
        internal static FlowType ProgramFlow { get; set; }
        public static Statement ExecutingStatement = null;
        internal static Dictionary<string, CodeUnit> CodeStrings = new Dictionary<string, CodeUnit>();
        static Dictionary<string, ExecutableFunction> functions = new Dictionary<string, ExecutableFunction>();
        public static Dictionary<string, ExecutableFunction> Functions { get { return functions; } }

        public static Value EvalOptimized(this Expression e)
        {
            return Delegator.ExpressionEvaluators[e.Kind](e.Reduce());
        }

        public static Value Eval(this Expression e)
        {
            return Delegator.ExpressionEvaluators[e.Kind](e);
        }

        public static FlowType Execute(this Statement s)
        {
            ProgramFlow = FlowType.None;
            Statement prev = ExecutingStatement;
            ExecutingStatement = s;
            Delegator.StatementExecutors[s.Kind](s);
            ExecutingStatement = prev;
            return ProgramFlow;
        }

        // This function is called by non-loop statements with embedded statements. The calling statement must
        // return if Exec(s) != FlowType.None.
        internal static FlowType Exec(Statement inner)
        {
            FlowType t = inner.Execute();
            ProgramFlow |= t;
            return t;
        }

        /* This function is called by loop statements to execute embedded statements. You can catch
         * program flow statements, to keep them from falling through, like this:
         * switch (Exec(s, FlowType.Break|FlowType.Continue))
         * {
         * case FlowType.Break:
         *     goto End;
         * case FlowType.Continue:
         *     goto Test;
         * default:
         *     return;
         * }
         */
        internal static FlowType Exec(Statement inner, FlowType Catch)
        {
            FlowType t = inner.Execute();
            ProgramFlow |= t & ~Catch;
            return t;
        }

        public static Value Evaluate(string s)
        {
            return Evaluate(ExecutionContext.CreatePrivateInstance(), s);
        }

        public static Value Evaluate(Instance inst, string s)
        {
            if (string.IsNullOrEmpty(s.Trim()))
                return 0;
            Value v = 0;
            Instance t = ExecutionContext.Current;
            ExecutionContext.Current = inst; // The current instance executing the code
            Parser p = new Parser(new StringReader(s));
            Expression e = p.ParseExpression();
            ExecutionContext.Enter();
            try
            {
                v = e.Eval();
            }
            catch
            {
                throw;
            }
            finally
            {
                ExecutionContext.Leave();
                ExecutionContext.Current = t;
            }
            return v;
        }
        public static void DefineFunctionsFromType(Type t)
        {
            // Build the list of functions
            foreach (System.Reflection.MethodInfo mi in t.GetMethods())
            {
                if (!mi.IsStatic) continue;
                GMLFunctionAttribute[] attrs = (GMLFunctionAttribute[])mi.GetCustomAttributes(typeof(GMLFunctionAttribute), false);
                if (attrs.Length != 1) continue;
                GMLFunctionAttribute fn = attrs[0];
                string name = string.IsNullOrEmpty(fn.Name) ? mi.Name : fn.Name;
                DefineFunction(name, fn.Argc, (FunctionDelegate)System.Delegate.CreateDelegate(typeof(FunctionDelegate), mi));
            }
        }
        public static void DefineFunction(string n, int argc, FunctionDelegate f)
        {
            if (functions.ContainsKey(n)) return;
            functions.Add(n, new Function(n, argc, f));
        }
        public static Value ExecuteFunction(string n, params Value[] args)
        {
            ExecutionContext.Returned = functions[n].Execute(args);
            return ExecutionContext.Returned;
        }
        public static ExecutableFunction GetFunction(string n)
        {
            return functions[n];
        }
        public static ScriptFunction DefineScript(string n, int i, string c)
        {
            ScriptFunction s = new ScriptFunction(n, c);
            if (!functions.ContainsKey(n))
                functions.Add(n, s);
            return s;
        }
        // To be implemented by the IDE, not the runtime interpreter
        /*public static void ImportScripts(string fname)
        {
            ImportScripts(System.IO.File.Open(fname, System.IO.FileMode.Open));
        }
        public static void ImportScripts(System.IO.Stream s)
        {
            System.IO.StreamReader sr = new System.IO.StreamReader(s);
            string scr = null;
            StringBuilder sb = new StringBuilder();
            while (!sr.EndOfStream)
            {
                string line = sr.ReadLine();
                if (line.Trim().StartsWith("#define "))
                {
                    if (!string.IsNullOrEmpty(scr))
                    {
                        DefineScript(scr, sb.ToString());
                    }
                    scr = line.Substring(line.IndexOf("#define ") + 8).Trim();
                    sb.Remove(0, sb.Length);
                }
                else if (!string.IsNullOrEmpty(scr))
                {
                    sb.AppendLine(line);
                }
            }
            if (!string.IsNullOrEmpty(scr))
            {
                DefineScript(scr, sb.ToString());
            }
        }*/
        public static void CompileScripts()
        {
            foreach (ExecutableFunction f in functions.Values)
            {
                if (f.GetType() == typeof(ScriptFunction))
                {
                    ((ScriptFunction)f).Compile();
                }
            }
        }
        // return value indicates whether to execute the next action (or group of actions).
        // only returns false if the action is a question and the action tests false.
        // Execute() is only called when the action type is Normal, Code, or Variable.
        public bool Execute(this Action action)
        {
            System.Collections.Generic.List<Instance> instances = new System.Collections.Generic.List<Instance>(1);
            switch (action.AppliesTo)
            {
                case (int)ActionScope.Self:
                    instances.Add(ExecutionContext.Current);
                    break;
                case (int)ActionScope.Other:
                    instances.Add(ExecutionContext.Other);
                    break;
                default:
                    foreach (Instance e in ExecutionContext.Instances.Values)
                    {
                        if (e.object_index.value == action.AppliesTo)
                            instances.Add(e);
                    }
                    break;
            }
            bool returned = !action.Not;
            ExecutionContext.argument_relative.value = action.Relative;
            Instance c = ExecutionContext.Current;
            Instance o = ExecutionContext.Other;
            foreach (Instance e in instances)
            {
                if (e != c)
                {
                    ExecutionContext.Current = e;
                    ExecutionContext.Other = c;
                }
                switch (action.Definition.Kind)
                {
                    case ActionKind.Code:
                    case ActionKind.Variable:
                        ExecutionContext.Returned = new Value();
                        ExecutionContext.Enter();
                        Code.Run();
                        ExecutionContext.Leave();
                        if (ExecutionContext.Returned == Not) returned = Not;
                        break;
                    case ActionKind.Normal:
                        Value[] args = new Value[Arguments.Length];
                        // Evaluate the arguments
                        for (int i = 0; i < args.Length; i++)
                        {
                            switch (Definition.Arguments[i])
                            {
                                case ActionArgumentType.Expression:
                                    args[i] = Parser.Evaluate(ExecutionContext.Current, Arguments[i]);
                                    break;
                                case ActionArgumentType.String:
                                case ActionArgumentType.FontString:
                                    args[i] = new Value(Arguments[i]);
                                    break;
                                case ActionArgumentType.Both:
                                    args[i] = Arguments[i].StartsWith("\"") || Arguments[i].StartsWith("\'") ? Parser.Evaluate(ExecutionContext.Current, Arguments[i]) : new Value(Arguments[i]);
                                    break;
                                default:
                                    args[i] = new Value(double.Parse(Arguments[i]));
                                    break;
                            }
                        }
                        switch (Definition.ExecutionType)
                        {
                            case ActionExecutionType.Code:
                                ExecutionContext.Returned = new Value();
                                ExecutionContext.Enter();
                                ExecutionContext.SetArguments(args);
                                Definition.Code.Run();
                                ExecutionContext.Leave();
                                if (ExecutionContext.Returned == Not) returned = Not;
                                break;
                            case ActionExecutionType.Function:
                                if (ExecutionContext.ExecuteFunction(Definition.FunctionName, args) == Not) returned = Not;
                                break;
                        }
                        break;
                }
                if (returned == Not) break;
            }
            ExecutionContext.Current = c;
            ExecutionContext.Other = o;
            ExecutionContext.argument_relative.value = false;
            return Definition.IsQuestion ? Not ? !returned : returned : true;
        }
    }
}
