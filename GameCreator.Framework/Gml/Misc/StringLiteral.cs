namespace GameCreator.Framework.Gml
{
    public class StringLiteral : Token
    {
        public string value;
        public StringLiteral(string s, string l, int line, int col) : base(Terminal.StringLiteral, l, line, col) { value = s; }
        public StringLiteral(string s, int line, int col) : base(Terminal.StringLiteral, line, col) { value = s; }
        public override string ToString() { return value; }
    }
}
