using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Reflection;
using System.Linq.Expressions;

namespace GameCreator.Framework.Dynamic
{
    internal abstract class MemberAccessorBuilder<T> : IMemberAccessor<T>
    {
        public readonly Type MemberType;
        public readonly MemberInfo MemberInfo;
        public readonly bool IsProperty;
        public readonly Type ObjectType;
        public readonly Type ValueType = typeof(T);

        Func<object, int, int, T> m_getter;
        Action<object, int, int, T> m_setter;
        Func<object, int, int, bool> m_checkBounds;
        Func<object, bool> m_readOnly;

        public MemberAccessorBuilder(Type t, string name)
        {
            ObjectType = t;
            Type memberType;
            MemberInfo memberInfo;
            bool isProperty;

            GetMemberInfo(t, name, out memberType, out memberInfo, out isProperty);
            MemberInfo = memberInfo;
            MemberType = memberType;
            IsProperty = isProperty;

            m_getter = BuildGetter();
            m_setter = BuildSetter();
            m_checkBounds = BuildCheckIndex();
            m_readOnly = BuildReadOnly();
        }

        internal static void GetMemberInfo(Type t, string name, out Type memberType, out MemberInfo memberInfo, out bool isProperty)
        {
            memberInfo = t.GetMember(name, MemberTypes.Property | MemberTypes.Field, BindingFlags.Public | BindingFlags.Instance).Single();
            isProperty = memberInfo is PropertyInfo;
            memberType = isProperty ? (memberInfo as PropertyInfo).PropertyType : (memberInfo as FieldInfo).FieldType;
        }

        public T Get(object obj, int i1, int i2)
        {
            return m_getter(obj, i1, i2);
        }

        public void Set(object obj, int i1, int i2, T value)
        {
            m_setter(obj, i1, i2, value);
        }

        public bool CheckIndex(object obj, int i1, int i2)
        {
            return m_checkBounds(obj, i1, i2);
        }

        protected abstract Func<object, int, int, bool> BuildCheckIndex();

        protected abstract Func<object, int, int, T> BuildGetter();

        protected abstract Action<object, int, int, T> BuildSetter();

        protected abstract Func<object, bool> BuildReadOnly();

        public bool IsReadOnly(object obj)
        {
            return m_readOnly(obj);
        }
    }
}
