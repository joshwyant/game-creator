using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;

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

        Interpreter()
        {
            Context = new LibraryContext();
        }

        public static Value Eval(string s)
        {
            return Eval(ExecutionContext.CreatePrivateInstance(), s);
        }

        public static Value Eval(Instance inst, string s)
        {
            using (new InstanceScope(inst))
            {
                return CodeUnit.Get(s).Eval();
            }
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
                if (f is ScriptFunction)
                {
                    (f as ScriptFunction).Compile();
                }
            }
        }
    }
}
