using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using GameCreator.Framework;
using GameCreator.Framework.Gml.Interpreter;
using System.Reflection;
using System.Linq.Expressions;

namespace GameCreator.Runtime.Game.Interpreted
{
    public class InterpretedGameLibraryInitializer : GameLibraryInitializer
    {
        public override IEnumerable<Type> FunctionLibraries
        {
            get
            {
                var asm = Assembly.Load("GameCreator.Runtime.Library.Interpreted");
                return base.FunctionLibraries.Union(new [] {
                    asm.GetType("GameCreator.Runtime.Library.Interpreted.InterpreterFunctions"),
                });
            }
        }

        public override IFunction TransformFunction(System.Reflection.MethodInfo m, string n)
        {
            // Mayyyybe I should have used Reflection.Emit and DynamicMethod here, this is just too much... ha

            var parms = m.GetParameters();
            var argc = parms.Length;
            if (argc == 1 && parms.Any(p => p.GetCustomAttributes(typeof(ParamArrayAttribute), false).Any()))
                argc = -1;

            // For the method passed into TransformFunction():
            // 1. Compile a wrapper function of the form
            //      Value fn(Value[] args) {...}
            //    which has the form...
            //    {
            //        return (Value)nativeFunction((T1)arg1, (T2)arg2);
            //    }
            //    for example:
            //    Value show_message_wrapper(Value[] args) {
            //        show_message((string)args[0]);
            //        return Value.Null;
            //    }
            // 2. Create a delegate from the wrapper and return a new executable function.

            var input = Expression.Parameter(typeof(Value[]));

            var e_params = parms.Select(
                (p, i) =>
                {
                    Expression param = Expression.ArrayAccess(input, Expression.Constant(i));
                    if (argc == -1)
                    {
                        if (p.ParameterType.IsAssignableFrom(typeof(Value[])))
                            return input;
                        else
                        {
                            // Varargs, convert and copy the array

                            var label = Expression.Label(p.ParameterType);

                            var index = Expression.Variable(typeof(int));
                            var array = Expression.Variable(p.ParameterType);
                            var newarray = Expression.NewArrayBounds(
                                p.ParameterType.GetElementType(),
                                Expression.ArrayLength(input));

                            return Expression.Block(
                                new [] { index, array },
                                newarray,
                                Expression.Assign(index, Expression.Constant(0)),
                                Expression.Assign(array, newarray),
                                Expression.Loop(
                                    Expression.IfThenElse(
                                        Expression.GreaterThanOrEqual(index, Expression.ArrayLength(input)),
                                        Expression.Break(label, array),
                                        Expression.Block(
                                            Expression.Assign(
                                                Expression.ArrayAccess(array, index),
                                                Expression.Convert(Expression.ArrayAccess(input, index), p.ParameterType.GetElementType())
                                            ),
                                            Expression.PostIncrementAssign(index)
                                        )),
                                label)
                            );
                        }
                    }
                    if (p.ParameterType.IsAssignableFrom(typeof(Value)))
                        return param;
                    return Expression.Convert(param, p.ParameterType);
                }
                );

            var call = Expression.Call(m, e_params);

            Expression body;

            if (m.ReturnType == typeof(void))
            {
                body = Expression.Block(call, Expression.Constant(Value.Null));
            }
            else
            {
                if (typeof(Value).IsAssignableFrom(m.ReturnType))
                    body = call;
                else
                    body = Expression.Convert(call, typeof(Value));
            }

            FunctionDelegate del = Expression.Lambda<FunctionDelegate>(body, input).Compile();

            return new Function(n, argc, del);
        }

        public override void PerformEvent(Instance e, EventType et, int num)
        {
            var events = e.Context.Objects[e.ObjectIndex].Events;

            if (events.ContainsKey(et))
            {
                var ee = events[et];
                if (ee.ContainsKey(num))
                    ee[num].Execute();
            }
        }
    }
}
