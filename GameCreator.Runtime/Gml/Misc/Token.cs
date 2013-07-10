namespace GameCreator.Framework.Gml
{
    public class Token
    {
        public Terminal t;
        public string lexeme = string.Empty;
        public object attribute;
        public int line, col;
        public Token(Terminal x, int l, int c) { t = x; line = l; col = c; }
        public Token(Terminal x, string lexeme, int l, int c) { t = x; this.lexeme = lexeme; line = l; col = c; }
        public override string ToString() { return lexeme; }
        public static Token Unknown = new Token(Terminal.Unknown, 0, 0);
        public static Token Eof = new Token(Terminal.Eof, 0, 0);
        public static Token None = new Token(Terminal.None, 0, 0);
        public static Token
            Break                   = new Token ( Terminal.Break,                 "break"     , 0, 0),
            Continue                = new Token ( Terminal.Continue,              "continue"  , 0, 0),
            Return                  = new Token ( Terminal.Return,                "return"    , 0, 0),
            If                      = new Token ( Terminal.If,                    "if"        , 0, 0),
            Then                    = new Token ( Terminal.Then,                  "then"      , 0, 0),
            Else                    = new Token ( Terminal.Else,                  "else"      , 0, 0),
            While                   = new Token ( Terminal.While,                 "while"     , 0, 0),
            Until                   = new Token ( Terminal.Until,                 "until"     , 0, 0),
            Do                      = new Token ( Terminal.Do,                    "do"        , 0, 0),
            For                     = new Token ( Terminal.For,                   "for"       , 0, 0),
            NotWord                 = new Token ( Terminal.Not,                   "not"       , 0, 0),
            And                     = new Token ( Terminal.LogicalAnd,            "and"       , 0, 0),
            Or                      = new Token ( Terminal.LogicalOr,             "or"        , 0, 0),
            Xor                     = new Token ( Terminal.LogicalXor,            "xor"       , 0, 0),
            Repeat                  = new Token ( Terminal.Repeat,                "repeat"    , 0, 0),
            With                    = new Token ( Terminal.With,                  "with"      , 0, 0),
            Div                     = new Token ( Terminal.Div,                   "div"       , 0, 0),
            Mod                     = new Token ( Terminal.Mod,                   "mod"       , 0, 0),
            Var                     = new Token ( Terminal.Var,                   "var"       , 0, 0),
            Globalvar               = new Token ( Terminal.Globalvar,             "globalvar" , 0, 0),
            Switch                  = new Token ( Terminal.Switch,                "switch"    , 0, 0),
            Case                    = new Token ( Terminal.Case,                  "case"      , 0, 0),
            Default                 = new Token ( Terminal.Default,               "default"   , 0, 0),
            Exit                    = new Token ( Terminal.Exit,                  "exit"      , 0, 0),
            Begin                   = new Token ( Terminal.OpeningCurlyBrace,     "begin"     , 0, 0),
            End                     = new Token ( Terminal.ClosingCurlyBrace,     "end"       , 0, 0),
            Self                    = new Real  ( -1,                             "self"      , 0, 0),
            Other                   = new Real  ( -2,                             "other"     , 0, 0),
            All                     = new Real  ( -3,                             "all"       , 0, 0),
            Noone                   = new Real  ( -4,                             "noone"     , 0, 0),
            Global                  = new Real  ( -5,                             "global"    , 0, 0),
            BitwiseComplement       = new Token ( Terminal.BitwiseComplement,     "~"         , 0, 0),
            Not                     = new Token ( Terminal.Not,                   "!"         , 0, 0),
            Inequality              = new Token ( Terminal.Inequality,            "!="        , 0, 0),
            BitwiseXor              = new Token ( Terminal.BitwiseXor,            "^"         , 0, 0),
            LogicalXor              = new Token ( Terminal.LogicalXor,            "^^"        , 0, 0),
            XorAssignment           = new Token ( Terminal.XorAssignment,         "^="        , 0, 0),
            BitwiseAnd              = new Token ( Terminal.BitwiseAnd,            "&"         , 0, 0),
            LogicalAnd              = new Token ( Terminal.LogicalAnd,            "&&"        , 0, 0),
            AndAssignment           = new Token ( Terminal.AndAssignment,         "&="        , 0, 0),
            Multiply                = new Token ( Terminal.Multiply,              "*"         , 0, 0),
            MultiplyAssignment      = new Token ( Terminal.MultiplyAssignment,    "*="        , 0, 0),
            OpeningParenthesis      = new Token ( Terminal.OpeningParenthesis,    "("         , 0, 0),
            ClosingParenthesis      = new Token ( Terminal.ClosingParenthesis,    ")"         , 0, 0),
            Minus                   = new Token ( Terminal.Minus,                 "-"         , 0, 0),
            SubtractionAssignment   = new Token ( Terminal.SubtractionAssignment, "-="        , 0, 0),
            Plus                    = new Token ( Terminal.Plus,                  "+"         , 0, 0),
            AdditionAssignment      = new Token ( Terminal.AdditionAssignment,    "+="        , 0, 0),
            Assignment              = new Token ( Terminal.Assignment,            "="         , 0, 0),
            Equality                = new Token ( Terminal.Equality,              "=="        , 0, 0),
            OpeningCurlyBrace       = new Token ( Terminal.OpeningCurlyBrace,     "{"         , 0, 0),
            ClosingCurlyBrace       = new Token ( Terminal.ClosingCurlyBrace,     "}"         , 0, 0),
            OpeningSquareBracket    = new Token ( Terminal.OpeningSquareBracket,  "["         , 0, 0),
            ClosingSquareBracket    = new Token ( Terminal.ClosingSquareBracket,  "]"         , 0, 0),
            BitwiseOr               = new Token ( Terminal.BitwiseOr,             "|"         , 0, 0),
            LogicalOr               = new Token ( Terminal.LogicalOr,             "||"        , 0, 0),
            OrAssignment            = new Token ( Terminal.OrAssignment,          "|="        , 0, 0),
            Colon                   = new Token ( Terminal.Colon,                 ":"         , 0, 0),
            Semicolon               = new Token ( Terminal.Semicolon,             ";"         , 0, 0),
            LessThan                = new Token ( Terminal.LessThan,              "<"         , 0, 0),
            LessThanOrEqual         = new Token ( Terminal.LessThanOrEqual,       "<="        , 0, 0),
            ShiftLeft               = new Token ( Terminal.ShiftLeft,             "<<"        , 0, 0),
            GreaterThan             = new Token ( Terminal.GreaterThan,           ">"         , 0, 0),
            GreaterThanOrEqual      = new Token ( Terminal.GreaterThanOrEqual,    ">="        , 0, 0),
            ShiftRight              = new Token ( Terminal.ShiftRight,            ">>"        , 0, 0),
            Comma                   = new Token ( Terminal.Comma,                 ","         , 0, 0),
            Dot                     = new Token ( Terminal.Dot,                   "."         , 0, 0),
            Divide                  = new Token ( Terminal.Divide,                "/"         , 0, 0),
            DivideAssignment        = new Token ( Terminal.DivideAssignment,      "/="        , 0, 0);
    }
}
