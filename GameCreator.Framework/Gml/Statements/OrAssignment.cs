using System;
namespace GameCreator.Framework.Gml
{
    class OrAssignment : Statement
    {
        Access a; Expression x;
        public OrAssignment(Access acc, Expression e, int line, int col) : base(line, col) { a = acc; x = e; }
        protected override void run()
        {
            Value v1 = a.Eval(), v2 = x.Eval();
            if (v1.IsReal && v2.IsReal)
                a.Set((double)(Convert.ToInt64(v1.Real) | Convert.ToInt64(v2.Real)));
            // else throw new ProgramError("Wrong type of arguments to assignment operator.");
        }

        public override StatementKind Kind
        {
            get { return StatementKind.OrAssignment; }
        }
    }
}
