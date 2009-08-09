namespace GameCreator.Interpreter
{
    class OrAssignment : Stmt
    {
        Access a; Expr x;
        public OrAssignment(Access acc, Expr e) { a = acc; x = e; }
        protected override void run()
        {
            Value v1 = a.Eval(), v2 = x.Eval();
            if (v1.IsReal && v2.IsReal)
                a.Set(new Value((double)((long)v1.Real | (long)v2.Real)));
            // else throw new ProgramError("Wrong type of arguments to assignment operator.");
        }
    }
}
