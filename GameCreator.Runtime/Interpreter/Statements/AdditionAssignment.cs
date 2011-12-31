namespace GameCreator.Runtime.Interpreter
{
    class AdditionAssignment : Stmt
    {
        Access a; Expr x;
        public AdditionAssignment(Access acc, Expr e, int l, int c) : base(l, c) { a = acc; x = e; }
        protected override void run()
        {
            Value v1 = a.Eval(), v2 = x.Eval();
            if (v1.IsReal && v2.IsReal)
                a.Set(v1 + v2);
            else if (v1.IsString && v2.IsString)
                a.Set(v1 + v2);
            // else throw new ProgramError("Wrong type of arguments to assignment operator.");
        }
    }
}
