using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using GameCreator.Framework;
using System.Linq.Expressions;


namespace GameCreator.Runtime
{
    public class RuntimeInstance : Instance
    {
        #region Private
        [NoGmlExport]
        Dictionary<string, Variable> instancevars = new Dictionary<string, Variable>();
        #endregion

        #region Instance variables and access methods
        public int object_index { get { return ObjectIndex; } }
        public int id { get { return Id; } }
        #endregion

        #region Other properties
        [NoGmlExport]
        public bool Destroyed = false;
        #endregion

        #region Constructor
        // use Env.CreateInstance() or Env.CreatePrivateInstance().
        public RuntimeInstance(ResourceContext context, int object_index, int id)
            : base(context, object_index, id) { }
        #endregion

        #region Variable Access Methods
        public void SetLocalVar(string name, Value val)
        {
            SetLocalVar(name, 0, 0, val);
        }
        public void SetLocalVar(string name, int index, Value val)
        {
            SetLocalVar(name, 0, index, val);
        }
        public GetSetValue Variable(string name)
        {
            if (Context.Context.InstanceVariables.Contains(name, StringComparer.Ordinal))
                return FieldAccessor<Value>.Variable(this, name);
            else if (instancevars.ContainsKey(name))
                return instancevars[name];
            else return null;
        }
        public void SetLocalVar(string name, int i1, int i2, Value val)
        {
            if (Context.Context.InstanceVariables.Contains(name, StringComparer.Ordinal))
                FieldAccessor<Value>.SetNamedValue(this, name, val);
            else if (instancevars.ContainsKey(name))
                instancevars[name][i1, i2] = val;
            else
                instancevars.Add(name, new Variable(i1, i2, val));
        }
        public Value GetLocalVar(string name)
        {
            return GetLocalVar(name, 0, 0);
        }
        public Value GetLocalVar(string name, int index)
        {
            return GetLocalVar(name, 0, index);
        }

        public bool VariableExists(string name)
        {
            return Context.Context.InstanceVariables.Contains(name, StringComparer.Ordinal)
                || instancevars.ContainsKey(name);
        }

        public Value GetLocalVar(string name, int i1, int i2)
        {
            if (Context.Context.InstanceVariables.Contains(name, StringComparer.Ordinal))
                return FieldAccessor<Value>.GetNamedValue(this, name, i1, i2);
            return instancevars[name][i1, i2];
        }
        public bool CheckIndex(string name, int i1, int i2)
        {
            if (Context.Context.InstanceVariables.Contains(name, StringComparer.Ordinal))
                return FieldAccessor<Value>.CheckIndex(this, name, i1, i2);
            return instancevars[name].CheckIndex(i1, i2);
        }
        public bool IsReadOnly(string name)
        {
            if (Context.Context.InstanceVariables.Contains(name, StringComparer.Ordinal))
                return FieldAccessor<Value>.IsReadOnly(this, name);
            return instancevars[name].IsReadOnly;
        }
        #endregion
    }
}
