using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Linq.Expressions;

namespace GameCreator.Framework.Dynamic
{
    internal class GetSetAccessor<T> : MemberAccessorBuilder<T>
    {
        public GetSetAccessor(Type t, string name)
            : base(t, name) { }

        protected override Func<object, int, int, bool> BuildCheckIndex()
        {
            var p_obj = Expression.Parameter(typeof(object));
            var p_i1 = Expression.Parameter(typeof(int));
            var p_i2 = Expression.Parameter(typeof(int));

            Expression access = Expression.MakeMemberAccess(Expression.Convert(p_obj, ObjectType), MemberInfo);
            Expression checkindex = Expression.Call(access, MemberType.GetMethod("CheckIndex"), p_i1, p_i2);

            return Expression.Lambda<Func<object, int, int, bool>>(checkindex, p_obj, p_i1, p_i2).Compile();
        }

        public Type GetValueType()
        {
            return MemberType.GetInterfaces().Single(i => i.IsGenericType && i.GetGenericTypeDefinition() == typeof(IGetSet<>)).GetGenericArguments()[0];
        }

        protected override Func<object, int, int, T> BuildGetter()
        {
            var p_obj = Expression.Parameter(typeof(object));
            var p_i1 = Expression.Parameter(typeof(int));
            var p_i2 = Expression.Parameter(typeof(int));
            var valType = GetValueType();

            Expression access = Expression.MakeMemberAccess(Expression.Convert(p_obj, ObjectType), MemberInfo);
            Expression getter = Expression.Call(access, MemberType.GetMethod("Get"), p_i1, p_i2);

            return Expression.Lambda<Func<object, int, int, T>>(
                ValueType.IsAssignableFrom(valType) ?
                getter : Expression.Convert(getter, ValueType),
                p_obj, p_i1, p_i2
            ).Compile();
        }

        protected override Action<object, int, int, T> BuildSetter()
        {
            var p_obj = Expression.Parameter(typeof(object));
            var p_i1 = Expression.Parameter(typeof(int));
            var p_i2 = Expression.Parameter(typeof(int));
            var p_val = Expression.Parameter(ValueType);
            var valType = GetValueType();
            Expression param = p_val;

            Expression access = Expression.MakeMemberAccess(Expression.Convert(p_obj, ObjectType), MemberInfo);
            Expression val = valType.IsAssignableFrom(ValueType) ?
                        param : Expression.Convert(p_val, valType);
            Expression setter = Expression.Call(access, MemberType.GetMethod("Set"), p_i1, p_i2, val);

            return Expression.Lambda<Action<object, int, int, T>>(setter,
                    p_obj, p_i1, p_i2, p_val
                ).Compile();
        }

        protected override Func<object, bool> BuildReadOnly()
        {
            var p_obj = Expression.Parameter(typeof(object));

            Expression access = Expression.MakeMemberAccess(Expression.Convert(p_obj, ObjectType), MemberInfo);
            Expression readOnly = Expression.MakeMemberAccess(access, MemberType.GetProperty("IsReadOnly"));

            return Expression.Lambda<Func<object, bool>>(readOnly, p_obj).Compile();
        }
    }
}
