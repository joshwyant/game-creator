using System;
namespace GameCreator.Framework.Gml
{
    class XorAssignment : Assignment
    {
        public XorAssignment(Access a, Expression e, int l, int c)
            : base(a, e, l, c) { }

        public override StatementKind Kind
        {
            get { return StatementKind.XorAssignment; }
        }

        internal override void Write(System.CodeDom.Compiler.IndentedTextWriter writer, GmlFormatter formatter)
        {
            throw new NotImplementedException();
        }
    }
}