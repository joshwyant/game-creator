using System;
using System.Text;
using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using JavaScriptBuilder.Expressions;
using System.Linq.Expressions;
using JavaScriptBuilder;
using System.IO;

namespace GameCreator.Test
{
    [TestClass]
    public class JavaScriptTest
    {
        [TestMethod]
        public void TestMethod1()
        {
            var x = Js.Variable("x");
            var y = Js.Variable("y");

            var t = Js.Assign(
                    Js.Variable("fn"),
                    Js.Function(new [] {
                        Js.If(
                            Js.Equality(x, y),
                            Js.MultiplyAssign(x, y))
                    }, "x", "y")
                );
        }

        [TestMethod]
        public void TestMethod2()
        {
            string s;

            var t = Js.Binary((x, y) => x + y);
            var u = Js.AddAssign(
                Js.Variable("t"),
                Js.Function<Func<JsObject, JsObject, JsObject, JsObject>>((a, b, c) => a + b * c)
                );

            s = u.ToString();
        }
    }
}
