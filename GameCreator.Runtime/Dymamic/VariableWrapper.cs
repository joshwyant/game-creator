using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using GameCreator.Framework;

namespace GameCreator.Runtime
{
    public class VariableWrapper : GetSetValue
    {
        object m_obj;
        string m_name;

        public VariableWrapper(object obj, string name)
        {
            m_obj = obj;
            m_name = name;
        }

        public override Value Get(int i1, int i2)
        {
            return FieldAccessor<Value>.GetNamedValue(m_obj, m_name, i1, i2);
        }

        public override void Set(int i1, int i2, Value value)
        {
            FieldAccessor<Value>.SetNamedValue(m_obj, m_name, i1, i2, value);
        }

        public override bool CheckIndex(int i1, int i2)
        {
            return FieldAccessor<Value>.CheckIndex(m_obj, m_name, i1, i2);
        }

        public override bool IsReadOnly
        {
            get { return FieldAccessor<Value>.IsReadOnly(m_obj, m_name); }
        }
    }
}
