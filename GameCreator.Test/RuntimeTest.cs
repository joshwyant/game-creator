using System;
using System.Text;
using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using GameCreator.Runtime;
using GameCreator.Framework;

namespace GameCreator.Test
{
    [TestClass]
    public class RuntimeTest
    {
        class RuntimeTestObject
        {
            public double doubleVal;
            public int intVal;
            public bool propertyVal { get { return true; } }
            public string propertyVal2 { get; set; }
            public Variable a;
            public Variable b { get; set; }

            public RuntimeTestObject()
            {
                a = new Variable();
                b = new Variable();
            }
        }

        [TestMethod]
        public void VariableWrapperTest()
        {
            var test = new RuntimeTestObject();

            var var1 = new VariableWrapper(test, "doubleVal");
            var var2 = new VariableWrapper(test, "intVal");
            var var3 = new VariableWrapper(test, "propertyVal");
            var var4 = new VariableWrapper(test, "propertyVal2");
            var var5 = new VariableWrapper(test, "a");
            var var6 = new VariableWrapper(test, "b");

            Assert.IsFalse(var1.IsReadOnly);
            Assert.IsTrue(var3.IsReadOnly);

            var1.Value = 3.5;
            Assert.IsTrue(var1.Value == 3.5);

            var2.Value = "Hello";
            Assert.IsTrue(var2.Value.Real == 0);

            var2.Value = "Hello";
            Assert.AreEqual(Value.Zero, var2.Value);

            var4.Value = 0;
            Assert.AreEqual(Value.EmptyString, var4.Value);

            test.a.Value = 3;
            Assert.AreEqual(new Value(3), test.a.Value);

            test.b.Value = "Something";
            Assert.AreEqual(new Value("Something"), test.b.Value);


        }
    }
}
