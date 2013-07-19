using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Reflection.Emit;
using System.Linq.Expressions;
using System.Reflection;
using GameCreator.Framework.Dynamic;

namespace GameCreator.Framework
{
    public class FieldAccessor<T>
    {
        readonly Dictionary<string, IMemberAccessor<T>> Accessors = new Dictionary<string, IMemberAccessor<T>>();

        readonly static Dictionary<Type, FieldAccessor<T>> FieldAccessors = new Dictionary<Type,FieldAccessor<T>>();

        readonly Type m_t;

        FieldAccessor(Type t) { m_t = t; }

        public override int GetHashCode()
        {
            return m_t.GetHashCode() ^ typeof(T).GetHashCode();
        }

        private static FieldAccessor<T> GetFieldAccessor(Type t)
        {
            FieldAccessor<T> accessor;

            if (!FieldAccessors.TryGetValue(t, out accessor))
            {
                FieldAccessors.Add(t, accessor = new FieldAccessor<T>(t));
            }

            return accessor;
        }

        private static MemberInfo GetMember(object obj, string name)
        {
            return obj.GetType().GetMember(name).Single();
        }
        private static Type MemberType(MemberInfo member)
        {
            return member is PropertyInfo ?
                (member as PropertyInfo).PropertyType :
                (member as FieldInfo).FieldType;
        }

        private static IMemberAccessor<T> GetAccessor(object obj, string name)
        {
            var t = obj.GetType();

            var fa = GetFieldAccessor(t);

            IMemberAccessor<T> accessor;

            if (!fa.Accessors.TryGetValue(name, out accessor))
            {
                var memberType = MemberType(GetMember(obj, name));
                accessor = typeof(Array).IsAssignableFrom(memberType) ?
                    new ArrayAccessor<T>(t, name)
                    : IsGetSet(memberType) ?
                    new GetSetAccessor<T>(t, name):
                    (MemberAccessorBuilder<T>)new MemberAccessor<T>(t, name);

                fa.Accessors.Add(name, accessor);
            }
            return accessor;
        }

        private static bool IsGetSet(Type memberType)
        {
            return memberType.GetInterfaces().Any(i => i.IsGenericType && i.GetGenericTypeDefinition() == typeof(IGetSet<>));
        }

        public static T GetNamedValue(object obj, string name, int i1, int i2)
        {
            return GetAccessor(obj, name).Get(obj, i1, i2);
        }

        public static void SetNamedValue(object obj, string name, int i1, int i2, T value)
        {
            GetAccessor(obj, name).Set(obj, i1, i2, value);
        }

        public static T GetNamedValue(object obj, string name, int i)
        {
            return GetNamedValue(obj, name, 0, i);
        }

        public static void SetNamedValue(object obj, string name, int i, T value)
        {
            SetNamedValue(obj, name, 0, i, value);
        }

        public static T GetNamedValue(object obj, string name)
        {
            return GetNamedValue(obj, name, 0, 0);
        }

        public static void SetNamedValue(object obj, string name, T value)
        {
            SetNamedValue(obj, name, 0, 0, value);
        }

        public static bool CheckIndex(object obj, string name, int i)
        {
            return GetAccessor(obj, name).CheckIndex(obj, 0, i);
        }

        public static bool CheckIndex(object obj, string name, int i1, int i2)
        {
            return GetAccessor(obj, name).CheckIndex(obj, i1, i2);
        }

        public static bool IsReadOnly(object obj, string name)
        {
            return GetAccessor(obj, name).IsReadOnly(obj);
        }
    }
}
