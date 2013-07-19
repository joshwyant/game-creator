using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Reflection;
using System.Linq.Expressions;

namespace GameCreator.Runtime.Dynamic
{
    internal class ArrayAccessor<T> : MemberAccessorBuilder<T>
    {
        public ArrayAccessor(Type t, string name)
            : base(t, name) { }

        protected override Func<object, int, int, bool> BuildCheckIndex()
        {
            return (o, i1, i2) => true;
        }

        protected override Func<object, int, int, T> BuildGetter()
        {
            var p_obj = Expression.Parameter(typeof(object));
            var p_i1 = Expression.Parameter(typeof(int));
            var p_i2 = Expression.Parameter(typeof(int));
            var elementType = MemberType.GetElementType();

            Expression arrayAccess = BuildArrayAccess(p_obj, p_i2);

            return Expression.Lambda<Func<object, int, int, T>>(
                ValueType.IsAssignableFrom(elementType) ?
                arrayAccess : Expression.Convert(arrayAccess, ValueType),
                p_obj, p_i1, p_i2
            ).Compile();
        }

        private Expression BuildArrayAccess(ParameterExpression p_obj, ParameterExpression p_index)
        {
            var obj = Expression.Convert(p_obj, ObjectType);

            Expression access = Expression.MakeMemberAccess(obj, MemberInfo);

            var length = MemberType.GetProperty("Length");

            var indexer = Expression.Condition(
                              Expression.Or(
                                  Expression.LessThan(
                                      p_index, Expression.Constant(0)),
                                  Expression.GreaterThanOrEqual(
                                      p_index,
                                      Expression.MakeMemberAccess(access, length)
                                  )
                              ), Expression.Constant(0), p_index);

            return Expression.ArrayAccess(access, indexer);
        }

        protected override Action<object, int, int, T> BuildSetter()
        {
            var p_obj = Expression.Parameter(typeof(object));
            var p_i1 = Expression.Parameter(typeof(int));
            var p_i2 = Expression.Parameter(typeof(int));
            var p_val = Expression.Parameter(ValueType);
            var elementType = MemberType.GetElementType();
            Expression param = p_val;

            var arrayAccess = BuildArrayAccess(p_obj, p_i2);

            return Expression.Lambda<Action<object, int, int, T>>(
                    Expression.Assign(
                        arrayAccess,
                        elementType.IsAssignableFrom(ValueType) ?
                        param : Expression.Convert(p_val, elementType)
                    ),
                    p_obj, p_i1, p_i2, p_val
                ).Compile();
        }

        protected override Func<object, bool> BuildReadOnly()
        {
            return o => false;
        }
    }
}
