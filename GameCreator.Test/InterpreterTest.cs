using System;
using System.Text;
using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using GameCreator.Framework;
using GameCreator.Runtime.Game;
using GameCreator.Framework.Gml;
using System.IO;
using GameCreator.Framework.Gml.Interpreter;
using GameCreator.Runtime.Game.Interpreted;
using GameCreator.Runtime.Library;

namespace GameCreator.Test
{
    [TestClass]
    public class InterpreterTest
    {
        LibraryContext Current { get { return LibraryContext.Current = LibraryContext.Current ?? new LibraryContext(new InterpretedGameLibraryInitializer()); } }

        Value ParseExpression(string e)
        {
            var p = new Parser(Current, new StringReader(e));

            return p.ParseExpression().Eval();
        }

        [TestMethod]
        public void TestVariousFunctions()
        {
            Assert.AreEqual(Value.One, ParseExpression("real('1')"));

            Assert.AreEqual((Value)GmlFunctions.mean(1,2,3), ParseExpression("mean(1,2,3)"));
        }
    }
}
