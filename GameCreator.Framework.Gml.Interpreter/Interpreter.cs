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
        public static LibraryContext Context { get; set; }

        static Dictionary<string, ExecutableFunction> functions = new Dictionary<string, ExecutableFunction>();
        public static Dictionary<string, ExecutableFunction> Functions { get { return functions; } }

        public static AstNode ExecutingNode { get; set; }
        public static FlowType ProgramFlow = FlowType.None;

        static Interpreter()
        {
            Context = LibraryContext.Current;
        }

        public static Value Eval(string s)
        {
            return Eval(Context.InstanceFactory.CreatePrivateInstance(), s);
        }

        public static Value Eval(Instance inst, string s)
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
                if (f is ScriptFunction)
                {
                    (f as ScriptFunction).Compile();
                }
            }
        }
    }
}
