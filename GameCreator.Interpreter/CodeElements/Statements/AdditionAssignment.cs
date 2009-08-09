namespace GameCreator.Interpreter
{
    class AdditionAssignment : Stmt
    {
        Access a; Expr x;
        public AdditionAssignment(Access acc, Expr e) { a = acc; x = e; }
        protected override void run()
        {
            Value v1 = a.Eval(), v2 = x.Eval();
            if (v1.IsReal && v2.IsReal)
                a.Set(new Value(v1.Real + v2.Real));
            else if (v1.IsString && v2.IsString)
                a.Set(new Value(v1.String + v2.String));
            // else throw new ProgramError("Wrong type of arguments to assignment operator.");
        }
    }
}
