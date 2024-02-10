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
                return CodeUnit.GetExpression(s).Eval();
            }
        }

        public static Value ExecuteFunction(string n, params Value[] args)
        {
            var fn = Context.Functions[n];

            if (fn is ExecutableFunction)
                Returned = (fn as ExecutableFunction).Execute(args);
            else
                Returned = (fn as Script).ExecutionDelegate(args);

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
    }
}
