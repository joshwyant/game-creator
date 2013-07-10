namespace GameCreator.Framework.Gml
{
    class DivideAssignment : Statement
    {
        Access a; Expression x;
        public DivideAssignment(Access acc, Expression e, int line, int col) : base(line, col) { a = acc; x = e; }
        protected override void run()
        {
            Value v1 = a.Eval(), v2 = x.Eval();
            if (v1.IsReal && v2.IsReal && v2.Real != 0.0)
                a.Set(v1 / v2);
            // else throw new ProgramError("Wrong type of arguments to assignment operator.");
        }
    }
}
