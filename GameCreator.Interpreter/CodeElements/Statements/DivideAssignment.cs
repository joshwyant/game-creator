namespace GameCreator.Interpreter
{
    class DivideAssignment : Stmt
    {
        Access a; Expr x;
        public DivideAssignment(Access acc, Expr e) { a = acc; x = e; }
        protected override void run()
        {
            Value v1 = a.Eval(), v2 = x.Eval();
            if (v1.IsReal && v2.IsReal && v2.Real != 0.0)
                a.Set(new Value(v1.Real / v2.Real));
            // else throw new ProgramError("Wrong type of arguments to assignment operator.");
        }
    }
}
