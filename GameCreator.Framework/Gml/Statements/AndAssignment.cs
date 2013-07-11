using System;
namespace GameCreator.Framework.Gml
{
    class AndAssignment : Statement
    {
        Access a; Expression x;
        public AndAssignment(Access acc, Expression e, int l, int c) : base(l, c) { a = acc; x = e; }
        protected override void run()
        {
            Value v1 = a.Eval(), v2 = x.Eval();
            if (v1.IsReal && v2.IsReal)
                a.Set((double)(Convert.ToInt64(v1.Real) & Convert.ToInt64(v2.Real)));
            // else throw new ProgramError("Wrong type of arguments to assignment operator.");
        }

        public override StatementKind Kind
        {
            get { return StatementKind.AndAssignment; }
        }
    }
}
