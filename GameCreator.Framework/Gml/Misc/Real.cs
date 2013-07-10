namespace GameCreator.Framework.Gml
{
    public class Real : Token
    {
        public double value;
        public Real(double d, int l, int c) : base(TokenKind.Real, l, c) { value = d; }
        public Real(double d, string l, int line, int col) : base(TokenKind.Real, l, line, col) { value = d; }
        public override string ToString() { if (!string.IsNullOrEmpty(lexeme)) return lexeme; return value.ToString(); }
    }
}
