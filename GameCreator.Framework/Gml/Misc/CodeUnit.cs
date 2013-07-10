namespace GameCreator.Framework.Gml
{
    // A code unit. It is initialized with a code string.
    // A code unit is always compiled once. Either manually, i.e. while loading, or immediately before the code is run.
    // 'Compiled' means transformed into a parse tree to be efficiently executed.
	public class CodeUnit
	{
        string code;
        internal Statement ParseTree;
        public CodeUnit(string code) { this.code = code; }
        public string Code { get { return code; } }
        public void Compile()
        {
            if (ParseTree != null)
                return;
            Parser p = new Parser(code);
            ParseTree = p.Parse();
        }
        public bool Compiled { get { return ParseTree != null; } }
        public void Run()
        {
            if (ParseTree == null)
                Compile();
            ParseTree.Exec();
        }
	}
}
