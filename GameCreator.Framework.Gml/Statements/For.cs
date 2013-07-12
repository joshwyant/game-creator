using System;
using System.Collections.Generic;
using System.Text;

namespace GameCreator.Framework.Gml
{
    public class For : Statement
    {
        public Statement Initializer { get; set; }
        public Statement Iterator { get; set; }
        public Statement Body { get; set; }
        public Expression Test { get; set; }

        public For(Statement init, Expression test, Statement iterator, Statement body, int l, int c)
            : base(l, c)
        {
            Initializer = init;
            Iterator = iterator;
            Body = body;
            Test = test;
        }

        public override StatementKind Kind
        {
            get { return StatementKind.For; }
        }

        public override void Optimize()
        {
            Test = Test.Reduce();
            Initializer.Optimize();
            Iterator.Optimize();
            Body.Optimize();
        }

        internal override void Write(System.CodeDom.Compiler.IndentedTextWriter writer, GmlFormatter formatter)
        {
            throw new NotImplementedException();
        }
    }
}
