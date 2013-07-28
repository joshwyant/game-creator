using System.Collections.Generic;
using System.Collections;
using System.Text;
using System;
using System.Linq;
using GameCreator.Framework;

namespace GameCreator.Runtime
{
    public static class ExecutionContext
    {
        public static IEnumerable<RuntimeInstance> Instances { get { return LibraryContext.Current.InstanceFactory.Instances.Values.Cast<RuntimeInstance>(); } }

        public static Globals Globals = new Globals();
        public static readonly IEnumerable<object> GlobalObjects = new List<object> { Globals };
        public static readonly Dictionary<string, Variable> GlobalVariables = new Dictionary<string, Variable>();

        public static RuntimeInstance Current = null;
        public static RuntimeInstance Other = null;
        // Names of variables declared with 'global' keyword
        static List<string> globalvars = new List<string>();
        // Names of variables declared with 'var' keyword
        public static List<string> DeclaredVariables;

        public static Dictionary<string, Variable> ScopedVariables;// = new Dictionary<string, Variable>();
        // Holds the value of the last returned value. This mimics GM's behavior. If a script does not
        // return a value, it automatically returns the value returned from the last call
        // (Env.Returned is not changed). Upon entry of a script, Env.Return is set to Value(0.d).
        // In other words, a script containing "func0()" is the same as "return func0()", but an empty
        // script returns 0. Also, when a string is executed, i.e. with execute_string(),
        // it has the same behavior as a script (Env.Return -> 0, if return statement is encountered,
        // returns control from string, not script).

        static ExecutionContext()
        {
        }
		

        public static void DefineGlobalObject(object obj)
        {
            (GlobalObjects as List<object>).Add(obj);
        }

        public static bool GlobalVariableExists(string name)
        {
            return GlobalVariables.ContainsKey(name)
                    || FieldAccessor<Value>.ChooseObject(GlobalObjects, name) != null;
        }

        public static GetSetValue GetGlobalVariable(string name)
        {
            if (GlobalVariables.ContainsKey(name))
                return GlobalVariables[name];

            var obj = FieldAccessor<Value>.ChooseObject(GlobalObjects, name);

            return obj == null ? null : new VariableWrapper(obj, name);
        }
		
        // returns whether the name exists as a variable, in the scope of the current instance.
        // The interpreter checks array bounds with Variable.CheckIndex().
        public static bool VariableExists(string name)
        {
            if (DeclaredVariables.Contains(name))
                return ScopedVariables.ContainsKey(name);

            return (globalvars.Contains(name) || Current.VariableExists(name));
        }
        // returns whether the name exists as a variable, in the scope of the given instance.
        // example: x = VariableExists(Env.self, "t");
        public static bool VariableExists(int id, string name)
        {
            switch ((InstanceTarget)id)
            {
                case InstanceTarget.Self:
                    return (Current != null && Current.VariableExists(name));
                case InstanceTarget.Other:
                    return (Other != null && Other.VariableExists(name));
                case InstanceTarget.All:
                    return Instances.Any(e => e.VariableExists(name));
                case InstanceTarget.Noone:
                    return false;
                case InstanceTarget.Global:
                    return GlobalVariableExists(name);
                default:
                    return Instances.Any(inst => inst.id == id && !inst.Destroyed && inst.VariableExists(name));
            }
        }
        public static RuntimeInstance GetInstance(int id)
        {
            return LibraryContext.Current.InstanceFactory.Instances[id] as RuntimeInstance;
        }

        public static void SetVar(string name, int i1, int i2, Value val)
        {
            if (DeclaredVariables.Contains(name))
            {
                if (ScopedVariables.ContainsKey(name))
                {
                    if (ScopedVariables[name].IsReadOnly) throw new ProgramError(Error.CannotAssign);
                    ScopedVariables[name][i1, i2] = val;
                }
                else
                    ScopedVariables.Add(name, new Variable(i1, i2, val));
            }
            else if (GlobalVariableExists(name))
            {
                var globalvar = GetGlobalVariable(name);
                if (globalvar.IsReadOnly) throw new ProgramError(Error.CannotAssign);
                globalvar[i1, i2] = val;
            }
            else if (Current != null)
            {
                if (Current.VariableExists(name))
                {
                    var instancevar = Current.Variable(name);
                    if (instancevar.IsReadOnly) throw new ProgramError(Error.CannotAssign);
                    instancevar[i1, i2] = val;
                }
                else
                   Current.SetLocalVar(name, val);
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
            switch ((InstanceTarget)instance)
            {
                case InstanceTarget.Self:
                    Current.SetLocalVar(name, i1, i2, val);
                    break;
                case InstanceTarget.Other:
                    if (Other == null) throw new ProgramError(Error.CannotAssign);
                    Other.SetLocalVar(name, i1, i2, val);
                    break;
                case InstanceTarget.All:
                    foreach (var inst in Instances)
                    {
                        inst.SetLocalVar(name, i1, i2, val);
                    }
                    break;
                case InstanceTarget.Noone:
                    throw new ProgramError(Error.CannotAssign);
                case InstanceTarget.Global:
                    if (GlobalVariableExists(name))
                        GetGlobalVariable(name).Set(i1, i2, val);
                    else
                        GlobalVariables.Add(name, new Variable(val, i1: i1, i2: i2));
                    break;
                default:
                    var e = GetInstance(instance);

                    if (e != null)
                        e.SetLocalVar(name, i1, i2, val);
                    else if (instance < (int)InstanceTarget.Global)
                        throw new ProgramError(Error.CannotAssign);
                    else
                    {
                        foreach (var i in Instances.Where(ii => ii.object_index == instance))
                        {
                            e.SetLocalVar(name, i1, i2, val);
                        }
                    }
                    break;
            }
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
            if (DeclaredVariables.Contains(name))
                return ScopedVariables[name][i1, i2];
            if (globalvars.Contains(name))
                return GetGlobalVariable(name)[i1, i2];
            return Current.Variable(name)[i1, i2];
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
            var variable = Variable(instance, name);
            if (variable == null)
                return Value.Zero;
            return variable[i1, i2];
        }
        public static Value GetVar(int instance, string name, int index)
        {
            return GetVar(instance, name, 0, index);
        }
        public static Value GetVar(int instance, string name)
        {
            return GetVar(instance, name, 0, 0);
        }
        public static GetSetValue Variable(string name)
        {
            if (DeclaredVariables.Contains(name))
                return ScopedVariables[name];
            if (globalvars.Contains(name))
                return GlobalVariables[name];
            return Current.Variable(name);
        }
        public static GetSetValue Variable(int instance, string name)
        {
            switch ((InstanceTarget)instance)
            {
                case InstanceTarget.Self:
                    return Current.Variable(name);
                case InstanceTarget.Other:
                    return Other.Variable(name);
                case InstanceTarget.All:
                    return Instances.Where(e => e.VariableExists(name)).Select(e => e.Variable(name)).FirstOrDefault();
                case InstanceTarget.Noone:
                    return null;
                case InstanceTarget.Global:
                    return GetGlobalVariable(name);
                default:
                    return GetInstance(instance).Variable(name);
            }
        }

        /// <summary>
        /// Use this at runtime to dereference a variable using dynamically typed values.
        /// </summary>
        public static Value Dereference(Value instance, string name, Value v1, Value v2)
        {
            ValidateArray(v1, v2);

            if (instance != Value.Null)
            {
                if (!instance.IsReal)
                    throw new ProgramError(Error.WrongVariableIndexType);

                if (v1 != 0 || v2 != 0)
                {
                    if (!VariableExists(instance, name) || !Variable(instance, name).CheckIndex(v1, v2))
                        throw new ProgramError(Error.UnknownArray, name);
                }
                else
                {
                    if (!VariableExists(instance, name))
                        throw new ProgramError(Error.UnknownVariable, name);
                }

                return GetVar(instance, name, v1, v2);
            }
            else
            {
                if (v1 != 0 || v2 != 0)
                {
                    if (!VariableExists(name) || !Variable(name).CheckIndex(v1, v2))
                        throw new ProgramError(Error.UnknownArray, name);
                }
                else
                {
                    if (!VariableExists(name))
                        throw new ProgramError(Error.UnknownVariable, name);
                }

                return GetVar(name, v1, v2);
            }
        }

        public static void ValidateArray(Value v1, Value v2)
        {
            if (!(v1.IsReal && v2.IsReal))
                throw new ProgramError(Error.WrongArrayIndexType);

            if (v1 < 0 || v2 < 0)
                throw new ProgramError(Error.NegativeArrayIndex);

            if (v1 >= 32000 || v2 >= 32000)
                throw new ProgramError(Error.ArrayBounds);
        }

        public static void GlobalVars(string[] v)
        {
            foreach (string s in v)
            {
                if (!globalvars.Contains(s))
                {
                    globalvars.Add(s);
                    GlobalVariables.Add(s, new Variable());
                }
            }
        }
        public static void LocalVars(string[] v)
        {
            foreach (string s in v)
            {
                if (!DeclaredVariables.Contains(s))
                    DeclaredVariables.Add(s);
            }
        }

        public static IEnumerable<RuntimeInstance> WithInstance(Value v)
        {
            if (!v.IsReal)
                throw new ProgramError(Error.ExpectedObjectId);

            // Save the last instances being used
            var c = Current;
            var o = Other;
            Other = c;

            try
            {
                switch ((InstanceTarget)(int)v)
                {
                    case InstanceTarget.Self:
                        yield return c;
                        break;
                    case InstanceTarget.Other:
                        if (o != null)
                            yield return o;
                        break;
                    case InstanceTarget.All:
                        foreach (var i in ExecutionContext.Instances)
                            yield return i;
                        break;
                    case InstanceTarget.Global:
                        throw new ProgramError(Error.GlobalWith);
                    default:
                        if (ExecutionContext.Instances.Any(e => e.id == v))
                            yield return LibraryContext.Current.InstanceFactory.Instances[v] as RuntimeInstance;
                        else
                            foreach (var i in ExecutionContext.Instances.Where(ii => ii.object_index == v))
                                yield return i;
                        break;
                }
            }
            finally
            {
                // Restore current and other instances
                Current = c;
                Other = o;
            }
        }

        public static IEnumerable<int> Repeat(Value v)
        {
            if (!v.IsReal)
                throw new ProgramError(Error.RepeatExpression);

            var times = (int)Math.Round(v.Real);

            while (times > 0)
                yield return --times;
        }
        public static void SetArguments(Value[] args)
        {
            for (int i = 0; i < 16 && i < args.Length; i++)
                Globals.argument[i] = args[i];
        }
    }
}
