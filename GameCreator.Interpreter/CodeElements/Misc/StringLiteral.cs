namespace GameCreator.Interpreter
{
    public class StringLiteral : Token
    {
        public string value;
        public StringLiteral(string s, string l) : base(Terminal.StringLiteral, l) { value = s; }
        public StringLiteral(string s) : base(Terminal.StringLiteral) { value = s; }
        public override string ToString() { return value; }
    }
}
