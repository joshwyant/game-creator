using System;
using System.Text;
using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using GameCreator.Framework.Gml;
using GameCreator.Framework;
using System.IO;
using GameCreator.Runtime.Game;

namespace GameCreator.Test
{
    [TestClass]
    public class GmlTest
    {
        LibraryContext Current { get { return LibraryContext.Current = LibraryContext.Current ?? new LibraryContext(new GameLibraryInitializer()); } }

        Expression ParseExpression(string str)
        {
            var p = new Parser(Current, new StringReader(str));

            return p.ParseExpression();
        }
        Statement ParseStatement(string str)
        {
            var p = new Parser(Current, new StringReader(str));

            var stmt = p.Parse() as Sequence;

            if (stmt.First.Kind == StatementKind.Nop)
                return stmt.Second;

            return stmt;
        }
        void VerifyExpressionString(string str, string expected)
        {
            Assert.AreEqual(expected, ParseExpression(str).ToString());
        }
        void VerifyStatementString(string str, string expected)
        {
            Assert.AreEqual(expected, ParseStatement(str).ToString(GmlFormatter.Minifier));
        }
        void VerifyExpressionString(string str)
        {
            VerifyExpressionString(str, str);
        }
        void VerifyStatementString(string str)
        {
            VerifyStatementString(str, str);
        }

        [TestMethod]
        public void ParseEmptyExpression()
        {
            var e = ParseExpression("  /* Empty expression */  ");

            Assert.IsInstanceOfType(e, typeof(Constant));

            var c = e as Constant;

            Assert.AreEqual(Value.Zero, c.Value);
        }

        [TestMethod]
        public void ParseIdentifier()
        {
            var e = ParseExpression("abc");

            Assert.IsInstanceOfType(e, typeof(Access));
            Assert.AreEqual(ExpressionKind.Access, e.Kind);

            var a = e as Access;
            Assert.AreEqual("abc", a.Name);
        }

        [TestMethod]
        public void TestBlockToString()
        {
            var str = " { a=3; } ";

            var generated = "{\r\n    a = 3;\r\n}\r\n";

            var p = new Parser(LibraryContext.Current, new StringReader(str));

            var e = p.Parse();

            Assert.AreEqual(generated, e.ToString());

            var minified = "{a=3;}";

            Assert.AreEqual(minified, e.ToString(GmlFormatter.Minifier));
        }

        [TestMethod]
        public void TestExpressionToString()
        {
            VerifyExpressionString("a");
            VerifyExpressionString("a + 1");
            VerifyExpressionString("a + (3 * 2)");
            VerifyExpressionString("(a - 1) / t");
            VerifyExpressionString("a == 1");

            VerifyExpressionString("a <> 1", "a != 1");
            VerifyExpressionString("a mod 3");
            VerifyExpressionString("a and 1", "a && 1");
            VerifyExpressionString("a xor b", "a ^^ b");
        }

        [TestMethod]
        public void TestStatementToString()
        {
            VerifyStatementString("a := 0",                                                 "a=0;");
            VerifyStatementString("if t then x = 3",                                        "if(t)x=3;");
            VerifyStatementString("if t then begin x := 3 y = 4 end",                       "if(t){x=3;y=4;}");
            VerifyStatementString("for ({case 2:};0;exit)t=3",                              "for({case 2:};0;exit)t=3;");
            VerifyStatementString("for (repeat 5 i = 0;;;;; i < 3; globalvar;;;;;)a=3",     "for(repeat(5)i=0;;i<3;globalvar)a=3;");
            VerifyStatementString("for (i := 0 i<3; {case 3:exit};;;)string(4);",           "for(i=0;i<3;{case 3:exit;})string(4);");
        }
    }
}
