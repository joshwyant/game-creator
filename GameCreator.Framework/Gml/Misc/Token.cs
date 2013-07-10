namespace GameCreator.Framework.Gml
{
    public class Token
    {
        public TokenKind t;
        public string lexeme = string.Empty;
        public object attribute;
        public int line, col;
        public Token(TokenKind x, int l, int c) { t = x; line = l; col = c; }
        public Token(TokenKind x, string lexeme, int l, int c) { t = x; this.lexeme = lexeme; line = l; col = c; }
        public override string ToString() { return lexeme; }
        public static Token Unknown = new Token(TokenKind.Unknown, 0, 0);
        public static Token Eof = new Token(TokenKind.Eof, 0, 0);
        public static Token None = new Token(TokenKind.None, 0, 0);
        public static Token
            Break                   = new Token ( TokenKind.Break,                 "break"     , 0, 0),
            Continue                = new Token ( TokenKind.Continue,              "continue"  , 0, 0),
            Return                  = new Token ( TokenKind.Return,                "return"    , 0, 0),
            If                      = new Token ( TokenKind.If,                    "if"        , 0, 0),
            Then                    = new Token ( TokenKind.Then,                  "then"      , 0, 0),
            Else                    = new Token ( TokenKind.Else,                  "else"      , 0, 0),
            While                   = new Token ( TokenKind.While,                 "while"     , 0, 0),
            Until                   = new Token ( TokenKind.Until,                 "until"     , 0, 0),
            Do                      = new Token ( TokenKind.Do,                    "do"        , 0, 0),
            For                     = new Token ( TokenKind.For,                   "for"       , 0, 0),
            NotWord                 = new Token ( TokenKind.Not,                   "not"       , 0, 0),
            And                     = new Token ( TokenKind.LogicalAnd,            "and"       , 0, 0),
            Or                      = new Token ( TokenKind.LogicalOr,             "or"        , 0, 0),
            Xor                     = new Token ( TokenKind.LogicalXor,            "xor"       , 0, 0),
            Repeat                  = new Token ( TokenKind.Repeat,                "repeat"    , 0, 0),
            With                    = new Token ( TokenKind.With,                  "with"      , 0, 0),
            Div                     = new Token ( TokenKind.Div,                   "div"       , 0, 0),
            Mod                     = new Token ( TokenKind.Mod,                   "mod"       , 0, 0),
            Var                     = new Token ( TokenKind.Var,                   "var"       , 0, 0),
            Globalvar               = new Token ( TokenKind.Globalvar,             "globalvar" , 0, 0),
            Switch                  = new Token ( TokenKind.Switch,                "switch"    , 0, 0),
            Case                    = new Token ( TokenKind.Case,                  "case"      , 0, 0),
            Default                 = new Token ( TokenKind.Default,               "default"   , 0, 0),
            Exit                    = new Token ( TokenKind.Exit,                  "exit"      , 0, 0),
            Begin                   = new Token ( TokenKind.OpeningCurlyBrace,     "begin"     , 0, 0),
            End                     = new Token ( TokenKind.ClosingCurlyBrace,     "end"       , 0, 0),
            Self                    = new Real  ( -1,                             "self"      , 0, 0),
            Other                   = new Real  ( -2,                             "other"     , 0, 0),
            All                     = new Real  ( -3,                             "all"       , 0, 0),
            Noone                   = new Real  ( -4,                             "noone"     , 0, 0),
            Global                  = new Real  ( -5,                             "global"    , 0, 0),
            BitwiseComplement       = new Token ( TokenKind.BitwiseComplement,     "~"         , 0, 0),
            Not                     = new Token ( TokenKind.Not,                   "!"         , 0, 0),
            Inequality              = new Token ( TokenKind.Inequality,            "!="        , 0, 0),
            BitwiseXor              = new Token ( TokenKind.BitwiseXor,            "^"         , 0, 0),
            LogicalXor              = new Token ( TokenKind.LogicalXor,            "^^"        , 0, 0),
            XorAssignment           = new Token ( TokenKind.XorAssignment,         "^="        , 0, 0),
            BitwiseAnd              = new Token ( TokenKind.BitwiseAnd,            "&"         , 0, 0),
            LogicalAnd              = new Token ( TokenKind.LogicalAnd,            "&&"        , 0, 0),
            AndAssignment           = new Token ( TokenKind.AndAssignment,         "&="        , 0, 0),
            Multiply                = new Token ( TokenKind.Multiply,              "*"         , 0, 0),
            MultiplyAssignment      = new Token ( TokenKind.MultiplyAssignment,    "*="        , 0, 0),
            OpeningParenthesis      = new Token ( TokenKind.OpeningParenthesis,    "("         , 0, 0),
            ClosingParenthesis      = new Token ( TokenKind.ClosingParenthesis,    ")"         , 0, 0),
            Minus                   = new Token ( TokenKind.Minus,                 "-"         , 0, 0),
            SubtractionAssignment   = new Token ( TokenKind.SubtractionAssignment, "-="        , 0, 0),
            Plus                    = new Token ( TokenKind.Plus,                  "+"         , 0, 0),
            AdditionAssignment      = new Token ( TokenKind.AdditionAssignment,    "+="        , 0, 0),
            Assignment              = new Token ( TokenKind.Assignment,            "="         , 0, 0),
            Equality                = new Token ( TokenKind.Equality,              "=="        , 0, 0),
            OpeningCurlyBrace       = new Token ( TokenKind.OpeningCurlyBrace,     "{"         , 0, 0),
            ClosingCurlyBrace       = new Token ( TokenKind.ClosingCurlyBrace,     "}"         , 0, 0),
            OpeningSquareBracket    = new Token ( TokenKind.OpeningSquareBracket,  "["         , 0, 0),
            ClosingSquareBracket    = new Token ( TokenKind.ClosingSquareBracket,  "]"         , 0, 0),
            BitwiseOr               = new Token ( TokenKind.BitwiseOr,             "|"         , 0, 0),
            LogicalOr               = new Token ( TokenKind.LogicalOr,             "||"        , 0, 0),
            OrAssignment            = new Token ( TokenKind.OrAssignment,          "|="        , 0, 0),
            Colon                   = new Token ( TokenKind.Colon,                 ":"         , 0, 0),
            Semicolon               = new Token ( TokenKind.Semicolon,             ";"         , 0, 0),
            LessThan                = new Token ( TokenKind.LessThan,              "<"         , 0, 0),
            LessThanOrEqual         = new Token ( TokenKind.LessThanOrEqual,       "<="        , 0, 0),
            ShiftLeft               = new Token ( TokenKind.ShiftLeft,             "<<"        , 0, 0),
            GreaterThan             = new Token ( TokenKind.GreaterThan,           ">"         , 0, 0),
            GreaterThanOrEqual      = new Token ( TokenKind.GreaterThanOrEqual,    ">="        , 0, 0),
            ShiftRight              = new Token ( TokenKind.ShiftRight,            ">>"        , 0, 0),
            Comma                   = new Token ( TokenKind.Comma,                 ","         , 0, 0),
            Dot                     = new Token ( TokenKind.Dot,                   "."         , 0, 0),
            Divide                  = new Token ( TokenKind.Divide,                "/"         , 0, 0),
            DivideAssignment        = new Token ( TokenKind.DivideAssignment,      "/="        , 0, 0);
    }
}
