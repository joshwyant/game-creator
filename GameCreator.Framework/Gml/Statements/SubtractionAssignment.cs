namespace GameCreator.Framework.Gml
{
    class SubtractionAssignment : Stmt
    {
        Access a; Expr x;
        public SubtractionAssignment(Access acc, Expr e, int line, int col) : base(line, col) { a = acc; x = e; }
        protected override void run()
        {
            Value v1 = a.Eval(), v2 = x.Eval();
            if (v1.IsReal && v2.IsReal)
                a.Set(v1 - v2);
            // else throw new ProgramError("Wrong type of arguments to assignment operator.");
        }
    }
}
