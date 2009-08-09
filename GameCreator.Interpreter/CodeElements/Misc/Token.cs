namespace GameCreator.Interpreter
{
    public class Token
    {
        public Terminal t;
        public string lexeme = string.Empty;
        public object attribute;
        public Token(Terminal x) { t = x; }
        public Token(Terminal x, string lexeme) { t = x; this.lexeme = lexeme; }
        public override string ToString() { return lexeme; }
        public static Token Unknown = new Token(Terminal.Unknown);
        public static Token Eof = new Token(Terminal.Eof);
        public static Token None = new Token(Terminal.None);
        public static Token
            Break                   = new Token ( Terminal.Break,                 "break"     ),
            Continue                = new Token ( Terminal.Continue,              "continue"  ),
            Return                  = new Token ( Terminal.Return,                "return"    ),
            If                      = new Token ( Terminal.If,                    "if"        ),
            Then                    = new Token ( Terminal.Then,                  "then"      ),
            Else                    = new Token ( Terminal.Else,                  "else"      ),
            While                   = new Token ( Terminal.While,                 "while"     ),
            Do                      = new Token ( Terminal.Until,                 "until"     ),
            Until                   = new Token ( Terminal.Do,                    "do"        ),
            For                     = new Token ( Terminal.For,                   "for"       ),
            NotWord                 = new Token ( Terminal.Not,                   "not"       ),
            And                     = new Token ( Terminal.LogicalAnd,            "and"       ),
            Or                      = new Token ( Terminal.LogicalOr,             "or"        ),
            Xor                     = new Token ( Terminal.LogicalXor,            "xor"       ),
            Repeat                  = new Token ( Terminal.Repeat,                "repeat"    ),
            With                    = new Token ( Terminal.With,                  "with"      ),
            Div                     = new Token ( Terminal.Div,                   "div"       ),
            Mod                     = new Token ( Terminal.Mod,                   "mod"       ),
            Var                     = new Token ( Terminal.Var,                   "var"       ),
            Globalvar               = new Token ( Terminal.Globalvar,             "globalvar" ),
            Switch                  = new Token ( Terminal.Switch,                "switch"    ),
            Case                    = new Token ( Terminal.Case,                  "case"      ),
            Default                 = new Token ( Terminal.Default,               "default"   ),
            Exit                    = new Token ( Terminal.Exit,                  "exit"      ),
            Begin                   = new Token ( Terminal.OpeningCurlyBrace,     "begin"     ),
            End                     = new Token ( Terminal.ClosingCurlyBrace,     "end"       ),
            Self                    = new Real  ( -1,                             "self"      ),
            Other                   = new Real  ( -2,                             "other"     ),
            All                     = new Real  ( -3,                             "all"       ),
            Noone                   = new Real  ( -4,                             "noone"     ),
            Global                  = new Real  ( -5,                             "global"    ),
            BitwiseComplement       = new Token ( Terminal.BitwiseComplement,     "~"         ),
            Not                     = new Token ( Terminal.Not,                   "!"         ),
            Inequality              = new Token ( Terminal.Inequality,            "!="        ),
            BitwiseXor              = new Token ( Terminal.BitwiseXor,            "^"         ),
            LogicalXor              = new Token ( Terminal.LogicalXor,            "^^"        ),
            XorAssignment           = new Token ( Terminal.XorAssignment,         "^="        ),
            BitwiseAnd              = new Token ( Terminal.BitwiseAnd,            "&"         ),
            LogicalAnd              = new Token ( Terminal.LogicalAnd,            "&&"        ),
            AndAssignment           = new Token ( Terminal.AndAssignment,         "&="        ),
            Multiply                = new Token ( Terminal.Multiply,              "*"         ),
            MultiplyAssignment      = new Token ( Terminal.MultiplyAssignment,    "*="        ),
            OpeningParenthesis      = new Token ( Terminal.OpeningParenthesis,    "("         ),
            ClosingParenthesis      = new Token ( Terminal.ClosingParenthesis,    ")"         ),
            Minus                   = new Token ( Terminal.Minus,                 "-"         ),
            SubtractionAssignment   = new Token ( Terminal.SubtractionAssignment, "-="        ),
            Plus                    = new Token ( Terminal.Plus,                  "+"         ),
            AdditionAssignment      = new Token ( Terminal.AdditionAssignment,    "+="        ),
            Assignment              = new Token ( Terminal.Assignment,            "="         ),
            Equality                = new Token ( Terminal.Equality,              "=="        ),
            OpeningCurlyBrace       = new Token ( Terminal.OpeningCurlyBrace,     "{"         ),
            ClosingCurlyBrace       = new Token ( Terminal.ClosingCurlyBrace,     "}"         ),
            OpeningSquareBracket    = new Token ( Terminal.OpeningSquareBracket,  "["         ),
            ClosingSquareBracket    = new Token ( Terminal.ClosingSquareBracket,  "]"         ),
            BitwiseOr               = new Token ( Terminal.BitwiseOr,             "|"         ),
            LogicalOr               = new Token ( Terminal.LogicalOr,             "||"        ),
            OrAssignment            = new Token ( Terminal.OrAssignment,          "|="        ),
            Colon                   = new Token ( Terminal.Colon,                 ":"         ),
            Semicolon               = new Token ( Terminal.Semicolon,             ";"         ),
            LessThan                = new Token ( Terminal.LessThan,              "<"         ),
            LessThanOrEqual         = new Token ( Terminal.LessThanOrEqual,       "<="        ),
            ShiftLeft               = new Token ( Terminal.ShiftLeft,             "<<"        ),
            GreaterThan             = new Token ( Terminal.GreaterThan,           ">"         ),
            GreaterThanOrEqual      = new Token ( Terminal.GreaterThanOrEqual,    ">="        ),
            ShiftRight              = new Token ( Terminal.ShiftRight,            ">>"        ),
            Comma                   = new Token ( Terminal.Comma,                 ","         ),
            Dot                     = new Token ( Terminal.Dot,                   "."         ),
            Divide                  = new Token ( Terminal.Divide,                "/"         ),
            DivideAssignment        = new Token ( Terminal.DivideAssignment,      "/="        );
    }
}
