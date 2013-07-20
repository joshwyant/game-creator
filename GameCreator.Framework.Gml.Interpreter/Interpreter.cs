using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using GameCreator.Runtime;

namespace GameCreator.Framework.Gml.Interpreter
{
    public static class Interpreter
    {
        public static bool RunOptimized { get; set; }

        public static LibraryContext Context { get; set; }

        static Dictionary<string, ExecutableFunction> functions = new Dictionary<string, ExecutableFunction>();
        public static Dictionary<string, ExecutableFunction> Functions { get { return functions; } }

        public static AstNode ExecutingNode { get; set; }
        public static FlowType ProgramFlow = FlowType.None;

        // Stacks for scopes
        static Stack<ArgumentList> argstack = new Stack<ArgumentList>();
        static Stack<List<string>> varstack = new Stack<List<string>>();
        static Stack<Dictionary<string, Variable>> localstack = new Stack<Dictionary<string, Variable>>();

        public static Value Returned;

        static Interpreter()
        {
            Context = LibraryContext.Current;
        }

        public static Value Eval(string s)
        {
            return Eval(Context.InstanceFactory.CreatePrivateInstance() as RuntimeInstance, s);
        }

        public static Value Eval(RuntimeInstance inst, string s)
        {
            using (new InstanceScope(inst))
            {
                return CodeUnit.Get(s).Eval();
            }
        }

        public static void ImportFunctions(IEnumerable<Type> types)
        {
            // Creates and compiles wrapper methods of FunctionDelegate (Value func(params Value[])) around functions defined in 'types' with GmlFunctionAttribute

            Context.ImportFunctions(types,
                (m, n) =>
                {
                    var parms = m.GetParameters();
                    var argc = parms.Length;
                    if (argc == 1 && parms.Any(p => p.GetCustomAttributes(typeof(ParamArrayAttribute), false).Any() && p.ParameterType == typeof(Value[])))
                        argc = -1;

                    var input = System.Linq.Expressions.Expression.Parameter(typeof(Value[]));

                    var e_params = parms.Select(
                        (p, i) => {
                            System.Linq.Expressions.Expression param = System.Linq.Expressions.Expression.ArrayAccess(input, System.Linq.Expressions.Expression.Constant(i));
                            if (argc == -1) 
                                return input;
                            if (p.ParameterType.IsAssignableFrom(typeof(Value)))
                                return param;
                            return System.Linq.Expressions.Expression.Convert(param, p.ParameterType);
                        }
                        );

                    var call = System.Linq.Expressions.Expression.Call(m, e_params);

                    System.Linq.Expressions.Expression body;

                    if (m.ReturnType == typeof(void))
                    {
                        body = System.Linq.Expressions.Expression.Block(
                            call,
                            System.Linq.Expressions.Expression.Property(null, typeof(Value).GetProperty("Null", System.Reflection.BindingFlags.Static))
                        );
                    }
                    else
                    {
                        if (typeof(Value).IsAssignableFrom(m.ReturnType))
                            body = call;
                        else
                            body = System.Linq.Expressions.Expression.Convert(call, typeof(Value));
                    }

                    FunctionDelegate del = System.Linq.Expressions.Expression.Lambda<FunctionDelegate>(body, input).Compile();

                    return new Function(n, argc, del);
            });
        }

        public static Value ExecuteFunction(string n, params Value[] args)
        {
            Returned = functions[n].Execute(args);
            return Returned;
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

        public static void CompileScripts()
        {
            foreach (ExecutableFunction f in functions.Values)
            {
                if (f is ScriptFunction)
                {
                    (f as ScriptFunction).Compile();
                }
            }
        }

        public static void Enter()
        {
            varstack.Push(ExecutionContext.DeclaredVariables);
            localstack.Push(ExecutionContext.ScopedVariables);
            argstack.Push(ExecutionContext.Globals.argument);
            ExecutionContext.DeclaredVariables = new List<string>();
            ExecutionContext.ScopedVariables = new Dictionary<string, Variable>();
            ExecutionContext.Globals.argument = new ArgumentList();
            Returned = Value.Zero;
        }
        public static void Leave()
        {
            ExecutionContext.DeclaredVariables = varstack.Pop();
            ExecutionContext.ScopedVariables = localstack.Pop();
            ExecutionContext.Globals.argument = argstack.Pop();
        }
        public static void SetArguments(Value[] args)
        {
            for (int i = 0; i < 16 && i < args.Length; i++)
                ExecutionContext.Globals.argument[i] = args[i];
        }
    }
}
