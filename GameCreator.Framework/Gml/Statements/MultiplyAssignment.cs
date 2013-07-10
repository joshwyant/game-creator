namespace GameCreator.Framework.Gml
{
    class MultiplyAssignment : Stmt
    {
        Access a; Expr x;
        public MultiplyAssignment(Access acc, Expr e, int l, int c) : base(l, c) { a = acc; x = e; }
        protected override void run()
        {
            Value v1 = a.Eval(), v2 = x.Eval();
            if (v1.IsReal && v2.IsReal)
                a.Set(v1 * v2);
            else if (v1.IsReal && v2.IsString)
            {
                System.Text.StringBuilder sb = new System.Text.StringBuilder();
                for (int i = 0; i < (int)System.Math.Round(v1.Real); i++)
                    sb.Append(v2.String);
                a.Set(sb.ToString());
            }
            // else throw new ProgramError("Wrong type of arguments to assignment operator.");
        }
    }
}
