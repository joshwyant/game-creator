namespace GameCreator.Interpreter
{
    public class Real : Token
    {
        public double value;
        public Real(double d) : base(Terminal.Real) { value = d; }
        public Real(double d, string l) : base(Terminal.Real, l) { value = d; }
        public override string ToString() { if (!string.IsNullOrEmpty(lexeme)) return lexeme; return value.ToString(); }
    }
}
