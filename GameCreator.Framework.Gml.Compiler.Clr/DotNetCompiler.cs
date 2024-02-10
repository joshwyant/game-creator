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
        internal readonly Dictionary<string, MethodInfo> RoomMethods = new Dictionary<string, MethodInfo>();
        public readonly Dictionary<int, System.Action> Rooms = new Dictionary<int, System.Action>();
        AppDomain BuilderAppDomain;
        AssemblyBuilder AssemblyBuilder;
        ModuleBuilder MainModule;
        TypeBuilder ScriptsType;
        TypeBuilder RoomsType;
        FileInfo Path;

        public DotNetCompiler(LibraryContext context)
        {
            Context = context;
        }

        public void InitCompiler()
        {
            foreach (var kvp in Context.Resources.Scripts)
            {
                var script = kvp.Value;

                MethodInfo method;

                if (AssemblyBuilder == null)
                    method = new DynamicMethod(script.Name, typeof(Value), new[] { typeof(Value[]) });
                else
                    method = ScriptsType.DefineMethod(script.Name, MethodAttributes.Public | MethodAttributes.Static, typeof(Value), new[] { typeof(Value[]) });

                Scripts.Add(script.Name, method);
            }

            foreach (var kvp in Context.Resources.Rooms)
            {
                var room = kvp.Value;

                MethodInfo method;

                if (AssemblyBuilder == null)
                    method = new DynamicMethod(room.Name + "_CreationCode", typeof(void), Type.EmptyTypes);
                else
                    method = RoomsType.DefineMethod(room.Name + "_CreationCode", MethodAttributes.Public | MethodAttributes.Static, typeof(void), Type.EmptyTypes);

                RoomMethods.Add(room.Name, method);
            }
        }

        public DotNetCompiler(LibraryContext context, string filename)
        {
            Context = context;
            var fi = new FileInfo(filename);
            Path = fi;

            BuilderAppDomain = AppDomain.CurrentDomain;
            AssemblyBuilder = BuilderAppDomain.DefineDynamicAssembly(new AssemblyName(fi.Name), AssemblyBuilderAccess.RunAndSave, fi.DirectoryName);
            MainModule = AssemblyBuilder.DefineDynamicModule(fi.Name, fi.Name);
            ScriptsType = MainModule.DefineType("Scripts", TypeAttributes.Class);
            RoomsType = MainModule.DefineType("Rooms", TypeAttributes.Class);
        }

        public void Save()
        {
            ScriptsType.CreateType();
            RoomsType.CreateType();
            AssemblyBuilder.Save(Path.Name);
        }

        public void CompileScripts()
        {
            foreach (var kvp in Context.Resources.Scripts)
            {
                var script = kvp.Value;
                var method = Scripts[script.Name];

                ILGenerator il;

                if (method is DynamicMethod)
                    il = (method as DynamicMethod).GetILGenerator();
                else
                    il = (method as MethodBuilder).GetILGenerator();

                CompileScript(script.GetCodeReader(), il);

                if (method is DynamicMethod)
                    Context.Resources.Scripts[kvp.Key].ExecutionDelegate =
                        (method as DynamicMethod).CreateDelegate(typeof(FunctionDelegate)) as FunctionDelegate;
            }
        }

        public void CompileRooms()
        {
            foreach (var kvp in Context.Resources.Rooms)
            {
                var room = kvp.Value;
                var method = RoomMethods[room.Name];

                ILGenerator il;

                if (method is DynamicMethod)
                    il = (method as DynamicMethod).GetILGenerator();
                else
                    il = (method as MethodBuilder).GetILGenerator();

                Compile(room.GetCodeReader(), il);

                if (method is DynamicMethod)
                    Rooms.Add(room.Id, (method as DynamicMethod).CreateDelegate(typeof(System.Action)) as System.Action);
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
