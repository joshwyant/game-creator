namespace GameCreator.Interpreter
{
    class Assignment : Stmt
    {
        Access a; Expr x;
        public Assignment(Access acc, Expr e) { a = acc; x = e; }
        protected override void run()
        {
            a.Set(x.Eval());
        }
    }
}
