using System;
using System.Text;
using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using GameCreator.Framework;

namespace GameCreator.Test
{
    [TestClass]
    public class FrameworkTest
    {
        [TestMethod]
        public void TestValues()
        {
            Value value = default(Value);
            Assert.IsFalse(value.IsReal, "Default value should not be real.");
            Assert.IsFalse(value.IsString, "Default value should not be string.");
            Assert.AreEqual(Value.Null, value);

            Value num = 0;
            Assert.AreEqual(Value.Zero, num);
            num = 1;
            Assert.AreEqual(Value.One, num);

            Value empty = "";
            Assert.AreEqual(Value.EmptyString, empty);
        }

        [TestMethod]
        public void TestCreateLibraryContext()
        {
            var context = new LibraryContext();

            Assert.IsNotNull(context.Resources);
            Assert.AreSame(context, context.Resources.Context);

            context.Resources.Sprites.Define("sprite0", 1);

            Assert.IsNotNull(context.Resources.Sprites[0]);

            Assert.IsTrue(context.Resources.Sprites[0].Name == "sprite0");

            var sprite1 = context.Resources.Sprites.Define(null, 0);
            Assert.AreEqual("sprite1", sprite1.Name);
        }
    }
}
