using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Reflection;
using System.Linq.Expressions;

namespace GameCreator.Runtime.Dynamic
{
    class MemberAccessor<T> : MemberAccessorBuilder<T>
    {
        bool m_readOnly;
        bool initialized = false;

        internal MemberAccessor(Type t, string name)
            : base(t, name)
        {
            EnsureInitialized();
        }

        private void EnsureInitialized()
        {
            if (!initialized)
                m_readOnly = IsProperty && !((MemberInfo as PropertyInfo).CanWrite);
        }

        protected override Func<object, int, int, bool> BuildCheckIndex()
        {
            return (o, i1, i2) => true;
        }

        protected override Func<object, int, int, T> BuildGetter()
        {
            EnsureInitialized();
            var p_obj = Expression.Parameter(typeof(object));
            var p_i1 = Expression.Parameter(typeof(int));
            var p_i2 = Expression.Parameter(typeof(int));

            Expression access = Expression.MakeMemberAccess(Expression.Convert(p_obj, ObjectType), MemberInfo);
            
            return Expression.Lambda<Func<object, int, int, T>>(
                ValueType.IsAssignableFrom(MemberType) ?
                access : Expression.Convert(access, ValueType),
                p_obj, p_i1, p_i2
            ).Compile();
        }

        protected override Action<object, int, int, T> BuildSetter()
        {
            EnsureInitialized();
            if (m_readOnly)
                return null;

            var p_obj = Expression.Parameter(typeof(object));
            var p_i1 = Expression.Parameter(typeof(int));
            var p_i2 = Expression.Parameter(typeof(int));
            var p_val = Expression.Parameter(ValueType);
            Expression param = p_val;

            Expression access = Expression.MakeMemberAccess(Expression.Convert(p_obj, ObjectType), MemberInfo);

            return Expression.Lambda<Action<object, int, int, T>>(
                    Expression.Assign(
                        access,
                        MemberType.IsAssignableFrom(ValueType) ?
                        param : Expression.Convert(p_val, MemberType)
                    ),
                    p_obj, p_i1, p_i2, p_val
                ).Compile();
        }

        protected override Func<object, bool> BuildReadOnly()
        {
            return (o) => m_readOnly;
        }
    }
}
