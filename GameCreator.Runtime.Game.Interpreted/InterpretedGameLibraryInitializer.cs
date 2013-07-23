using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using GameCreator.Framework;
using GameCreator.Framework.Gml.Interpreter;
using System.Reflection;

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

        public override BaseFunction TransformFunction(System.Reflection.MethodInfo m, string n)
        {
            var parms = m.GetParameters();
            var argc = parms.Length;
            if (argc == 1 && parms.Any(p => p.GetCustomAttributes(typeof(ParamArrayAttribute), false).Any()))
                argc = -1;

            var input = System.Linq.Expressions.Expression.Parameter(typeof(Value[]));

            var e_params = parms.Select(
                (p, i) =>
                {
                    System.Linq.Expressions.Expression param = System.Linq.Expressions.Expression.ArrayAccess(input, System.Linq.Expressions.Expression.Constant(i));
                    if (argc == -1)
                    {
                        if (p.ParameterType.IsAssignableFrom(typeof(Value[])))
                            return input;
                        else
                        {
                            // Varargs
                            var label = System.Linq.Expressions.Expression.Label(p.ParameterType);

                            var index = System.Linq.Expressions.Expression.Variable(typeof(int));
                            var array = System.Linq.Expressions.Expression.Variable(p.ParameterType);
                            var newarray = System.Linq.Expressions.Expression.NewArrayBounds(
                                p.ParameterType.GetElementType(),
                                System.Linq.Expressions.Expression.ArrayLength(input));

                            return System.Linq.Expressions.Expression.Block(
                                new [] { index, array },
                                newarray,
                                System.Linq.Expressions.Expression.Assign(index, System.Linq.Expressions.Expression.Constant(0)),
                                System.Linq.Expressions.Expression.Assign(array, newarray),
                                System.Linq.Expressions.Expression.Loop(
                                    System.Linq.Expressions.Expression.IfThenElse(
                                        System.Linq.Expressions.Expression.GreaterThanOrEqual(index, System.Linq.Expressions.Expression.ArrayLength(input)),
                                        System.Linq.Expressions.Expression.Break(label, array),
                                        System.Linq.Expressions.Expression.Block(
                                            System.Linq.Expressions.Expression.Assign(
                                                System.Linq.Expressions.Expression.ArrayAccess(array, index),
                                                System.Linq.Expressions.Expression.Convert(
                                                    System.Linq.Expressions.Expression.ArrayAccess(input, index),
                                                    p.ParameterType.GetElementType())
                                            ),
                                            System.Linq.Expressions.Expression.PostIncrementAssign(index)
                                        )),
                                label)
                            );
                        }
                    }
                    if (p.ParameterType.IsAssignableFrom(typeof(Value)))
                        return param;
                    return System.Linq.Expressions.Expression.Convert(param, p.ParameterType);
                }
                );

            var call = System.Linq.Expressions.Expression.Call(m, e_params);

            System.Linq.Expressions.Expression body;

            if (m.ReturnType == typeof(void))
            {
                body = System.Linq.Expressions.Expression.Block(
                    call,
                    System.Linq.Expressions.Expression.MakeMemberAccess(null, typeof(Value).GetMember("Null", System.Reflection.BindingFlags.Static | BindingFlags.Public).Single())
                );
            }
            else
            {
                if (typeof(Value).IsAssignableFrom(m.ReturnType))
                    body = call;
                else
                    body = System.Linq.Expressions.Expression.Convert(call, typeof(Value));
            }

            FunctionDelegate del = System.Linq.Expressions.Expression.Lambda<FunctionDelegate>(body, input).Compile();

            return new Function(n, argc, del);
        }
    }
}
