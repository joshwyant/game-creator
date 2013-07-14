using System.Collections.Generic;
using System.Collections;
using System.Text;
using System;
using GameCreator.Runtime;

namespace GameCreator.Framework.Gml.Interpreter
{
    public static class ExecutionContext
    {
        public static bool RunOptimized { get; set; }
        static internal int ids = 100000;
        // The last id assigned to an instance by the IDE
        public static int LastInstanceID { get { return ids; } set { ids = value; } }
        public static List<int> InstanceIds = new List<int>();
        public static Dictionary<int, Instance> Instances = new Dictionary<int, Instance>();
        public static Instance Current = null;
        public static Instance Other = null;
        static Dictionary<string, Variable> globals = new Dictionary<string, Variable>();
        static List<string> globalvars = new List<string>();
        static List<string> localvars;
        public static List<string> Builtin = new List<string>();
        static Stack<List<string>> varstack = new Stack<List<string>>();
        internal static Dictionary<string, Value> constants = new Dictionary<string, Value>();
        static Stack<Dictionary<string, Variable>> localstack = new Stack<Dictionary<string, Variable>>();
        static Dictionary<string, Variable> locals;// = new Dictionary<string, Variable>();
        static Stack<Value[]> argstack = new Stack<Value[]>();
        static Value[] args = new Value[0];
        // Holds the value of the last returned value. This mimics GM's behavior. If a script does not
        // return a value, it automatically returns the value returned from the last call
        // (Env.Returned is not changed). Upon entry of a script, Env.Return is set to Value(0.d).
        // In other words, a script containing "func0()" is the same as "return func0()", but an empty
        // script returns 0. Also, when a string is executed, i.e. with execute_string(),
        // it has the same behavior as a script (Env.Return -> 0, if return statement is encountered,
        // returns control from string, not script).
        public static Value Returned;
        // Define a resource name along with its index, so it can be referenced in code.
        public static void DefineResourceIndex(string name, int index)
        {
            ExecutionContext.DefineConstant(name, index);
        }
        public static void DefineConstant(string name, Value val)
        {
            if (constants.ContainsKey(name))
                constants.Remove(name);
            constants.Add(name, val);
        }
        static ExecutionContext()
        {
            // builtins
            current_time = DefineVar("current_time", get_current_time);
            argument = DefineVar("argument", get_argument, set_argument);
            argument0 = DefineVar("argument0", get_argument0, set_argument0);
            argument1 = DefineVar("argument1", get_argument1, set_argument1);
            argument2 = DefineVar("argument2", get_argument2, set_argument2);
            argument3 = DefineVar("argument3", get_argument3, set_argument3);
            argument4 = DefineVar("argument4", get_argument4, set_argument4);
            argument5 = DefineVar("argument5", get_argument5, set_argument5);
            argument6 = DefineVar("argument6", get_argument6, set_argument6);
            argument7 = DefineVar("argument7", get_argument7, set_argument7);
            argument8 = DefineVar("argument8", get_argument8, set_argument8);
            argument9 = DefineVar("argument9", get_argument9, set_argument9);
            argument10 = DefineVar("argument10", get_argument10, set_argument10);
            argument11 = DefineVar("argument11", get_argument11, set_argument11);
            argument12 = DefineVar("argument12", get_argument12, set_argument12);
            argument13 = DefineVar("argument13", get_argument13, set_argument13);
            argument14 = DefineVar("argument14", get_argument14, set_argument14);
            argument15 = DefineVar("argument15", get_argument15, set_argument15);
            argument_relative = DefineVar("argument_relative", new BoolVariable(false, true)) as BoolVariable;
            Builtin.Add("object_index");
            Builtin.Add("id");
            Builtin.Add("x");
            Builtin.Add("y");
            Builtin.Add("hspeed");
            Builtin.Add("vspeed");
            Builtin.Add("direction");
            Builtin.Add("speed");
            DefineConstant("true", true);
            DefineConstant("false", false);
            DefineConstant("pi", System.Math.PI);
            DefineConstant("c_red", 0x000000FF);
            DefineConstant("c_yellow", 0x0000FFFF);
            DefineConstant("c_green", 0x00008000);
            DefineConstant("c_blue", 0x00FF0000);
        }
        #region Argument access methods
        static Value get_argument(int i1, int i2)
        {
            return i2 >= 16 ? (Value)0 : args[i2];
        }
        static void set_argument(int i1, int i2, Value v)
        {
            args[i2 >= 16 ? 0 : i2] = v;
        }
        // argument[5,0] is an unexpected error in gm
        static Value get_argument0(int i1, int i2)
        {
            return args[0];
        }
        static void set_argument0(int i1, int i2, Value v)
        {
            args[0] = v;
        }
        static Value get_argument1(int i1, int i2)
        {
            return args[1];
        }
        static void set_argument1(int i1, int i2, Value v)
        {
            args[1] = v;
        }
        static Value get_argument2(int i1, int i2)
        {
            return args[2];
        }
        static void set_argument2(int i1, int i2, Value v)
        {
            args[2] = v;
        }
        static Value get_argument3(int i1, int i2)
        {
            return args[3];
        }
        static void set_argument3(int i1, int i2, Value v)
        {
            args[3] = v;
        }
        static Value get_argument4(int i1, int i2)
        {
            return args[4];
        }
        static void set_argument4(int i1, int i2, Value v)
        {
            args[4] = v;
        }
        static Value get_argument5(int i1, int i2)
        {
            return args[5];
        }
        static void set_argument5(int i1, int i2, Value v)
        {
            args[5] = v;
        }
        static Value get_argument6(int i1, int i2)
        {
            return args[6];
        }
        static void set_argument6(int i1, int i2, Value v)
        {
            args[6] = v;
        }
        static Value get_argument7(int i1, int i2)
        {
            return args[7];
        }
        static void set_argument7(int i1, int i2, Value v)
        {
            args[7] = v;
        }
        static Value get_argument8(int i1, int i2)
        {
            return args[8];
        }
        static void set_argument8(int i1, int i2, Value v)
        {
            args[8] = v;
        }
        static Value get_argument9(int i1, int i2)
        {
            return args[9];
        }
        static void set_argument9(int i1, int i2, Value v)
        {
            args[9] = v;
        }
        static Value get_argument10(int i1, int i2)
        {
            return args[10];
        }
        static void set_argument10(int i1, int i2, Value v)
        {
            args[10] = v;
        }
        static Value get_argument11(int i1, int i2)
        {
            return args[11];
        }
        static void set_argument11(int i1, int i2, Value v)
        {
            args[11] = v;
        }
        static Value get_argument12(int i1, int i2)
        {
            return args[12];
        }
        static void set_argument12(int i1, int i2, Value v)
        {
            args[12] = v;
        }
        static Value get_argument13(int i1, int i2)
        {
            return args[13];
        }
        static void set_argument13(int i1, int i2, Value v)
        {
            args[13] = v;
        }
        static Value get_argument14(int i1, int i2)
        {
            return args[14];
        }
        static void set_argument14(int i1, int i2, Value v)
        {
            args[14] = v;
        }
        static Value get_argument15(int i1, int i2)
        {
            return args[15];
        }
        static void set_argument15(int i1, int i2, Value v)
        {
            args[15] = v;
        }
        #endregion
		#region Builtin Variables
        public static Variable current_time, argument, argument0, argument1, argument2, argument3, argument4,
            argument5, argument6, argument7, argument8, argument9, argument10, argument11, argument12, argument13,
            argument14, argument15;
        public static BoolVariable argument_relative;
		/*
         * Built-in variables
         */
        public static Value get_current_time(int i1, int i2)
        {
            return new Value((double)Environment.TickCount);
        }
		#endregion
        static Variable DefineVar(string n, GetAccessor f)
        {
            Variable t;
            Builtin.Add(n);
            globals.Add(n, t = new Variable(f));
            globalvars.Add(n);
            return t;
        }
        static Variable DefineVar(string n, Variable v)
        {
            Builtin.Add(n);
            globals.Add(n, v);
            globalvars.Add(n);
            return v;
        }
        static Variable DefineVar(string n, GetAccessor g, SetAccessor s)
        {
            Variable t;
            Builtin.Add(n);
            globals.Add(n, t = new Variable(g, s));
            globalvars.Add(n);
            return t;
        }
        public static void Enter()
        {
            varstack.Push(localvars);
            localstack.Push(locals);
            argstack.Push(args);
            localvars = new List<string>();
            locals = new Dictionary<string, Variable>();
            args = new Value[] {Value.Zero, Value.Zero, Value.Zero, Value.Zero,
                                Value.Zero, Value.Zero, Value.Zero, Value.Zero,
                                Value.Zero, Value.Zero, Value.Zero, Value.Zero,
                                Value.Zero, Value.Zero, Value.Zero, Value.Zero};
            Returned = Value.Zero;
        }
        public static void Leave()
        {
            localvars = varstack.Pop();
            locals = localstack.Pop();
            args = argstack.Pop();
        }
        public static void SetArguments(Value[] args)
        {
            for (int i = 0; i < 16 && i < args.Length; i++)
                ExecutionContext.args[i] = args[i];
        }
		/*
        public static void RunProgram(System.IO.Stream s)
        {
            try
            {
                try
                {
                    Env t = Env.Current;
                    Env.Current = Env.CreatePrivateInstance(); // The current instance executing the code
                    ImportScripts(s);
                    if (!FunctionExists("main")) throw new ProgramError("Entry point not found.");
                    CompileScripts();
                    Enter();
                    try
                    {
                        functions["main"].Execute();
                    }
                    catch (System.OutOfMemoryException)
                    {
                        throw;
                    }
                    finally
                    {
                        Leave();
                        Env.Current = t;
                    }
                }
                catch (ProgramError p)
                {
                    System.Windows.Forms.MessageBox.Show(p.Message, Env.Title, System.Windows.Forms.MessageBoxButtons.OK, System.Windows.Forms.MessageBoxIcon.Error);
                }
            }
            catch (System.OutOfMemoryException)
            {
                System.Windows.Forms.MessageBox.Show("Unexpected error occurred when running the game.");
                System.Environment.Exit(1);
            }

        }
        */

        // create an instance on the fly
        public static Instance CreateInstance()
        {
            Instance e = new Instance();
            e.assign_id();
            return e;
        }
        // create an instance with an id assigned by the IDE
        public static Instance CreateInstance(int id)
        {
            Instance e = new Instance();
            e.assign_id(id);
            return e;
        }
        // Used for: Room scripts, etc.
        public static Instance CreatePrivateInstance()
        {
            return new Instance();
        }
        // returns whether the name exists as a variable, in the scope of the current instance.
        // The interpreter checks array bounds with Variable.CheckIndex().
        public static bool VariableExists(string name)
        {
            return (locals.ContainsKey(name) || globalvars.Contains(name) || Current.instancevars.ContainsKey(name));
        }
        // returns whether the name exists as a variable, in the scope of the given instance.
        // example: x = VariableExists(Env.self, "t");
        public static bool VariableExists(int id, string name)
        {
            switch (id)
            {
                case self:
                    return (Current != null && Current.instancevars.ContainsKey(name));
                case other:
                    return (Other != null && Other.instancevars.ContainsKey(name));
                case all:
                    foreach (Instance e in Instances.Values)
                    {
                        if (e.instancevars.ContainsKey(name)) return true;
                    }
                    return false;
                case noone:
                    return false;
                case global:
                    return globals.ContainsKey(name);
                default:
                    Instance inst;
                    return (Instances.TryGetValue(id, out inst) && !inst.Destroyed && inst.instancevars.ContainsKey(name));
            }
        }
        public static void SetVar(string name, int i1, int i2, Value val)
        {
            if (localvars.Contains(name))
            {
                if (locals.ContainsKey(name))
                {
                    if (locals[name].IsReadOnly) throw new ProgramError("Cannot assign to the variable", ErrorSeverity.Error, ExecutingStatement);
                    locals[name][i1, i2] = val;
                }
                else
                    locals.Add(name, new Variable(i1, i2, val));
            }
            else if (globalvars.Contains(name))
            {
                if (globals[name].IsReadOnly) throw new ProgramError("Cannot assign to the variable", ErrorSeverity.Error, ExecutingStatement);
                globals[name][i1, i2] = val;
            }
            else if (Current != null)
            {
                if (Current.instancevars.ContainsKey(name))
                {
                    if (Current.instancevars[name].IsReadOnly) throw new ProgramError("Cannot assign to the variable", ErrorSeverity.Error, ExecutingStatement);
                    Current.instancevars[name][i1, i2] = val;
                }
                else
                    Current.instancevars.Add(name, new Variable(i1, i2, val));
            }
            
        }
        public static void SetVar(string name, int index, Value val)
        {
            SetVar(name, 0, index, val);
        }
        public static void SetVar(string name, Value val)
        {
            SetVar(name, 0, 0, val);
        }
        public static void SetVar(int instance, string name, int i1, int i2, Value val)
        {
            Dictionary<string, Variable> vars;
            switch (instance)
            {
                case self:
                    vars = Current.instancevars;
                    break;
                case other:
                    if (Other == null) throw new ProgramError("Cannot assign to the variable", ErrorSeverity.Error, ExecutingStatement);
                    vars = Other.instancevars;
                    break;
                case all:
                    foreach (int l in Instances.Keys)
                    {
                        SetVar(l, name, i1, i2, val);
                    }
                    return;
                case noone:
                    throw new ProgramError("Cannot assign to the variable", ErrorSeverity.Error, ExecutingStatement);
                case global:
                    vars = globals;
                    break;
                default:
                    if (Instances.ContainsKey(instance))
                        vars = Instances[instance].instancevars;
                    else if (instance < global)
                        throw new ProgramError("Cannot assign to the variable", ErrorSeverity.Error, ExecutingStatement);
                    else
                    {
                        foreach (Instance e in Instances.Values)
                        {
                            if (e.object_index.value == instance)
                            {
                                //SetVar(e.instancevars["id"].Value, name, i1, i2, val);
                                vars = e.instancevars;
                                if (vars.ContainsKey(name))
                                    vars[name][i1, i2] = val;
                                else
                                    vars.Add(name, new Variable(i1, i2, val));
                            }
                        }
                        return;
                    }
                    break;
            }
            if (vars.ContainsKey(name))
                vars[name][i1, i2] = val;
            else
                vars.Add(name, new Variable(i1, i2, val));
        }
        public static void SetVar(int instance, string name, int index, Value val)
        {
            SetVar(instance, name, 0, index, val);
        }
        public static void SetVar(int instance, string name, Value val)
        {
            SetVar(instance, name, 0, 0, val);
        }
        public static Value GetVar(string name, int i1, int i2)
        {
            if (localvars.Contains(name))
                return locals[name][i1, i2];
            if (globalvars.Contains(name))
                return globals[name][i1, i2];
            return Current.instancevars[name][i1, i2];
        }
        public static Value GetVar(string name, int index)
        {
            return GetVar(name, 0, index);
        }
        public static Value GetVar(string name)
        {
            return GetVar(name, 0, 0);
        }
        public static Value GetVar(int instance, string name, int i1, int i2)
        {
            switch (instance)
            {
                case self:
                    return Current.instancevars[name][i1, i2];
                case other:
                    return Other.instancevars[name][i1, i2];
                case all:
                    foreach (Instance e in Instances.Values)
                    {
                        if (e.instancevars.ContainsKey(name))
                            return e.instancevars[name][i1, i2];
                    }
                    return Value.Zero;
                case noone:
                    return Value.Zero;
                case global:
                    return globals[name][i1, i2];
                default:
                    return Instances[instance].instancevars[name][i1, i2];
            }
        }
        public static Value GetVar(int instance, string name, int index)
        {
            return GetVar(instance, name, 0, index);
        }
        public static Value GetVar(int instance, string name)
        {
            return GetVar(instance, name, 0, 0);
        }
        public static Variable Variable(string name)
        {
            if (localvars.Contains(name))
                return locals[name];
            if (globalvars.Contains(name))
                return globals[name];
            return Current.instancevars[name];
        }
        public static Variable Variable(int instance, string name)
        {
            switch (instance)
            {
                case self:
                    return Current.instancevars[name];
                case other:
                    return Other.instancevars[name];
                case all:
                    foreach (Instance e in Instances.Values)
                    {
                        if (e.instancevars.ContainsKey(name))
                            return e.instancevars[name];
                    }
                    return null;
                case noone:
                    return null;
                case global:
                    return globals[name];
                default:
                    return Instances[instance].instancevars[name];
            }
        }
        public static void GlobalVars(string[] v)
        {
            foreach (string s in v)
            {
                if (!globalvars.Contains(s))
                {
                    globalvars.Add(s);
                    globals.Add(s, new Variable());
                }
            }
        }
        public static void LocalVars(string[] v)
        {
            foreach (string s in v)
            {
                if (!localvars.Contains(s))
                    localvars.Add(s);
            }
        }
    }
}
