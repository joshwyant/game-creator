namespace GameCreator.Interpreter
{
    class MultiplyAssignment : Stmt
    {
        Access a; Expr x;
        public MultiplyAssignment(Access acc, Expr e) { a = acc; x = e; }
        protected override void run()
        {
            Value v1 = a.Eval(), v2 = x.Eval();
            if (v1.IsReal && v2.IsReal)
                a.Set(new Value(v1.Real * v2.Real));
            else if (v1.IsReal && v2.IsString)
            {
                System.Text.StringBuilder sb = new System.Text.StringBuilder();
                for (int i = 0; i < (int)System.Math.Round(v1.Real); i++)
                    sb.Append(v2.String);
                a.Set(new Value(sb.ToString()));
            }
            // else throw new ProgramError("Wrong type of arguments to assignment operator.");
        }
    }
}
