using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Reflection;
using System.IO;
using System.Reflection.Emit;

namespace GameCreator.Framework.Gml.Compiler.Clr
{
    public class DotNetCompiler
    {
        public LibraryContext Context { get; set; }
        internal readonly Dictionary<string, MethodInfo> Scripts = new Dictionary<string, MethodInfo>();
        public readonly Dictionary<int, System.Action> Rooms = new Dictionary<int, System.Action>();

        public DotNetCompiler(LibraryContext context)
        {
            Context = context;
        }

        public void CompileScripts(bool jit)
        {
            if (jit)
            {
                foreach (var kvp in Context.Resources.Scripts)
                {
                    var script = kvp.Value;
                    var method = new DynamicMethod(script.Name, typeof(Value), new[] { typeof(Value[]) });

                    CompileScript(script.GetCodeReader(), method.GetILGenerator());

                    Context.Resources.Scripts[kvp.Key].ExecutionDelegate = method.CreateDelegate(typeof(FunctionDelegate)) as FunctionDelegate;

                    Scripts.Add(script.Name, method);
                }
            }
            else
            {
                throw new NotImplementedException();
            }
        }

        public void CompileRooms(bool jit)
        {
            if (jit)
            {
                foreach (var kvp in Context.Resources.Rooms)
                {
                    var room = kvp.Value;
                    var method = new DynamicMethod(room.Name + "_CreationCode", typeof(void), Type.EmptyTypes);

                    Compile(room.GetCodeReader(), method.GetILGenerator());

                    Rooms.Add(room.Id, method.CreateDelegate(typeof(System.Action)) as System.Action);
                }
            }
            else
            {
                throw new NotImplementedException();
            }
        }

        void CompileScript(TextReader reader, ILGenerator generator)
        {
            // Instantiate a parser.
            var p = new Parser(Context, reader);

            // Parse the code.
            p.Parse();

            // Optimize it.
            p.Optimize();

            // Do the naiive .net compiler pass.
            // This compiler phase is "naiive" because it doesn't do any type checking,
            //   it just uses dynamic values and instance variables.
            var t = new NaiveDotNetTraverser(this, generator);

            t.BeginMethod();
            t.LoadArguments();
            p.Pass(t);
            t.EndMethod(true);
        }

        void Compile(TextReader reader, ILGenerator generator)
        {
            // Instantiate a parser.
            var p = new Parser(Context, reader);

            // Parse the code.
            p.Parse();

            // Optimize it.
            p.Optimize();

            // Do the naiive .net compiler pass.
            // This compiler phase is "naiive" because it doesn't do any type checking,
            //   it just uses dynamic values and instance variables.
            var t = new NaiveDotNetTraverser(this, generator);

            t.BeginMethod();
            p.Pass(t);
            t.EndMethod(false);
        }
    }
}
