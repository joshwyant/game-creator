namespace GameCreator.Runtime.Interpreter
{
    public class Real : Token
    {
        public double value;
        public Real(double d, int l, int c) : base(Terminal.Real, l, c) { value = d; }
        public Real(double d, string l, int line, int col) : base(Terminal.Real, l, line, col) { value = d; }
        public override string ToString() { if (!string.IsNullOrEmpty(lexeme)) return lexeme; return value.ToString(); }
    }
}
