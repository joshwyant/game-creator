var enums = require("./ParseEnums.js");


exports.Token = (function() {
    var TokenKind = enums.TokenKind;

    function Token(x, l, c) { 
        this.t = x; 
        this.line = l; 
        this.col = c; 
        this.lexeme = ""; 
    }
    
    Token.prototype.toString = function() {
        return this.lexeme;
    }
    
    function TokenLexeme(x, lexeme, l, c) { 
    	var tok = new Token(x, l, c); 
        tok.lexeme = lexeme; 
        return tok;
    }

    exports.TokenLexeme = TokenLexeme;
    
    function Real(d, l, line, col) {
        Token.call(this, TokenKind.Real, line, col);
        this.lexeme = l;
        this.value = d;
    }
    
    Real.prototype = Object.create(Token.prototype);
    Real.prototype.valueOf = function() {
        return this.value;
    };
    Real.prototype.toString = function() {
    		if ((this.lexeme !== null) && (this.lexeme !== ""))
            return this.lexeme;
        return this.valueOf().toString();
    };

    exports.Real = Real;
    
    function StringLiteral(l, val, line, col) {
        Token.call(this, TokenKind.StringLiteral, line, col);
        this.lexeme = l;
        this.value = val;
    }
    
    StringLiteral.prototype = Object.create(Token.prototype);
    StringLiteral.prototype.valueOf = function() {
        return this.value;
    };
    StringLiteral.prototype.toString = function() {
        return this.valueOf().toString();
    };

    exports.StringLiteral = StringLiteral;
    
    function static() {
        Token.Unknown = new Token(TokenKind.Unknown, 0, 0);
        Token.Eof = new Token(TokenKind.Eof, 0, 0);
        Token.None = new Token(TokenKind.None, 0, 0);
        Token.Break                   = TokenLexeme ( TokenKind.Break,                 "break"     , 0, 0);
        Token.Continue                = TokenLexeme ( TokenKind.Continue,              "continue"  , 0, 0);
        Token.Return                  = TokenLexeme ( TokenKind.Return,                "return"    , 0, 0);
        Token.If                      = TokenLexeme ( TokenKind.If,                    "if"        , 0, 0);
        Token.Then                    = TokenLexeme ( TokenKind.Then,                  "then"      , 0, 0);
        Token.Else                    = TokenLexeme ( TokenKind.Else,                  "else"      , 0, 0);
        Token.While                   = TokenLexeme ( TokenKind.While,                 "while"     , 0, 0);
        Token.Until                   = TokenLexeme ( TokenKind.Until,                 "until"     , 0, 0);
        Token.Do                      = TokenLexeme ( TokenKind.Do,                    "do"        , 0, 0);
        Token.For                     = TokenLexeme ( TokenKind.For,                   "for"       , 0, 0);
        Token.NotWord                 = TokenLexeme ( TokenKind.Not,                   "not"       , 0, 0);
        Token.And                     = TokenLexeme ( TokenKind.LogicalAnd,            "and"       , 0, 0);
        Token.Or                      = TokenLexeme ( TokenKind.LogicalOr,             "or"        , 0, 0);
        Token.Xor                     = TokenLexeme ( TokenKind.LogicalXor,            "xor"       , 0, 0);
        Token.Repeat                  = TokenLexeme ( TokenKind.Repeat,                "repeat"    , 0, 0);
        Token.With                    = TokenLexeme ( TokenKind.With,                  "with"      , 0, 0);
        Token.Div                     = TokenLexeme ( TokenKind.Div,                   "div"       , 0, 0);
        Token.Mod                     = TokenLexeme ( TokenKind.Mod,                   "mod"       , 0, 0);
        Token.Var                     = TokenLexeme ( TokenKind.Var,                   "var"       , 0, 0);
        Token.Globalvar               = TokenLexeme ( TokenKind.Globalvar,             "globalvar" , 0, 0);
        Token.Switch                  = TokenLexeme ( TokenKind.Switch,                "switch"    , 0, 0);
        Token.Case                    = TokenLexeme ( TokenKind.Case,                  "case"      , 0, 0);
        Token.Default                 = TokenLexeme ( TokenKind.Default,               "default"   , 0, 0);
        Token.Exit                    = TokenLexeme ( TokenKind.Exit,                  "exit"      , 0, 0);
        Token.Begin                   = TokenLexeme ( TokenKind.OpeningCurlyBrace,     "begin"     , 0, 0);
        Token.End                     = TokenLexeme ( TokenKind.ClosingCurlyBrace,     "end"       , 0, 0);
        Token.Self                    = new Real  ( -1,                             "self"      , 0, 0);
        Token.Other                   = new Real  ( -2,                             "other"     , 0, 0);
        Token.All                     = new Real  ( -3,                             "all"       , 0, 0);
        Token.Noone                   = new Real  ( -4,                             "noone"     , 0, 0);
        Token.Global                  = new Real  ( -5,                             "global"    , 0, 0);
        Token.BitwiseComplement       = TokenLexeme ( TokenKind.BitwiseComplement,     "~"         , 0, 0);
        Token.Not                     = TokenLexeme ( TokenKind.Not,                   "!"         , 0, 0);
        Token.Inequality              = TokenLexeme ( TokenKind.Inequality,            "!="        , 0, 0);
        Token.BitwiseXor              = TokenLexeme ( TokenKind.BitwiseXor,            "^"         , 0, 0);
        Token.LogicalXor              = TokenLexeme ( TokenKind.LogicalXor,            "^^"        , 0, 0);
        Token.XorAssignment           = TokenLexeme ( TokenKind.XorAssignment,         "^="        , 0, 0);
        Token.BitwiseAnd              = TokenLexeme ( TokenKind.BitwiseAnd,            "&"         , 0, 0);
        Token.LogicalAnd              = TokenLexeme ( TokenKind.LogicalAnd,            "&&"        , 0, 0);
        Token.AndAssignment           = TokenLexeme ( TokenKind.AndAssignment,         "&="        , 0, 0);
        Token.Multiply                = TokenLexeme ( TokenKind.Multiply,              "*"         , 0, 0);
        Token.MultiplyAssignment      = TokenLexeme ( TokenKind.MultiplyAssignment,    "*="        , 0, 0);
        Token.OpeningParenthesis      = TokenLexeme ( TokenKind.OpeningParenthesis,    "("         , 0, 0);
        Token.ClosingParenthesis      = TokenLexeme ( TokenKind.ClosingParenthesis,    ")"         , 0, 0);
        Token.Minus                   = TokenLexeme ( TokenKind.Minus,                 "-"         , 0, 0);
        Token.SubtractionAssignment   = TokenLexeme ( TokenKind.SubtractionAssignment, "-="        , 0, 0);
        Token.Plus                    = TokenLexeme ( TokenKind.Plus,                  "+"         , 0, 0);
        Token.AdditionAssignment      = TokenLexeme ( TokenKind.AdditionAssignment,    "+="        , 0, 0);
        Token.Assignment              = TokenLexeme ( TokenKind.Assignment,            "="         , 0, 0);
        Token.Equality                = TokenLexeme ( TokenKind.Equality,              "=="        , 0, 0);
        Token.OpeningCurlyBrace       = TokenLexeme ( TokenKind.OpeningCurlyBrace,     "{"         , 0, 0);
        Token.ClosingCurlyBrace       = TokenLexeme ( TokenKind.ClosingCurlyBrace,     "}"         , 0, 0);
        Token.OpeningSquareBracket    = TokenLexeme ( TokenKind.OpeningSquareBracket,  "["         , 0, 0);
        Token.ClosingSquareBracket    = TokenLexeme ( TokenKind.ClosingSquareBracket,  "]"         , 0, 0);
        Token.BitwiseOr               = TokenLexeme ( TokenKind.BitwiseOr,             "|"         , 0, 0);
        Token.LogicalOr               = TokenLexeme ( TokenKind.LogicalOr,             "||"        , 0, 0);
        Token.OrAssignment            = TokenLexeme ( TokenKind.OrAssignment,          "|="        , 0, 0);
        Token.Colon                   = TokenLexeme ( TokenKind.Colon,                 ":"         , 0, 0);
        Token.Semicolon               = TokenLexeme ( TokenKind.Semicolon,             ";"         , 0, 0);
        Token.LessThan                = TokenLexeme ( TokenKind.LessThan,              "<"         , 0, 0);
        Token.LessThanOrEqual         = TokenLexeme ( TokenKind.LessThanOrEqual,       "<="        , 0, 0);
        Token.ShiftLeft               = TokenLexeme ( TokenKind.ShiftLeft,             "<<"        , 0, 0);
        Token.GreaterThan             = TokenLexeme ( TokenKind.GreaterThan,           ">"         , 0, 0);
        Token.GreaterThanOrEqual      = TokenLexeme ( TokenKind.GreaterThanOrEqual,    ">="        , 0, 0);
        Token.ShiftRight              = TokenLexeme ( TokenKind.ShiftRight,            ">>"        , 0, 0);
        Token.Comma                   = TokenLexeme ( TokenKind.Comma,                 ","         , 0, 0);
        Token.Dot                     = TokenLexeme ( TokenKind.Dot,                   "."         , 0, 0);
        Token.Divide                  = TokenLexeme ( TokenKind.Divide,                "/"         , 0, 0);
        Token.DivideAssignment        = TokenLexeme ( TokenKind.DivideAssignment,      "/="        , 0, 0);
    }
    
    static();
    
    return Token;
})();

exports.TextReader = function(text) {
    this.text = text;

    var idx = 0;
    
    this.Read = function() {
        return text.charCodeAt(idx++);
    }
    
    this.Peek = function () {
        return idx >= text.length ? -1 : text.charCodeAt(idx);
    }
}

exports.Lexer = (function() {
    var Token = exports.Token,
        TokenLexeme = exports.TokenLexeme,
        TokenKind = enums.TokenKind,
        Real = exports.Real,
        StringLiteral = exports.StringLiteral,
        Words = {};

    function Lexer(reader) {
        var self = this;

        var peek = ' ',
            eof = '\uFFFF', 
            pushed = [],
            chars = [];
        
        self.line = 1;
        self.col = 1;
        self.tokencol = 0;
        
        this.PutBack = function(tok) {
            pushed.push(tok);
        };
        
        var white = new RegExp(/^\s$/);
        var letter = new RegExp(/^[A-Z]$/i);
        var letterOrDigit = new RegExp(/^[A-Z0-9]$/i);
        var digit = new RegExp(/^\d$/);
        
        this.Scan = function() {
            if (pushed.length) return pushed.pop();
            var skipwhite = false;
            do {
                while (white.test(peek)) {
                    peek = readch();
                }
                
                if (peek == eof) return Token.Eof;
                
                self.tokencol = self.col;
                // [A-Za-z_][A-Za-z0-9_]*
                if (letter.test(peek) || peek == '_')
                {
                    var sb = [];
                    do
                    {
                        sb.push(peek);
                        peek = readch();
                    } while (letterOrDigit.test(peek) || peek == '_');
                    var s = sb.join('');
                    // reserve keywords and constants. Return their values literally as tokens
                    if (Words.hasOwnProperty(s)) return Words[s];
                    var t = new Token(TokenKind.Identifier, self.line, self.tokencol);
                    t.lexeme = s;
                    Words[s] = t;
                    return t;
                }
                else if (peek == '\"')
                {
                    var sb = [];
                    do
                    {
                        peek = readch();
                        switch (peek)
                        {
                            case eof:
                            case '\"':
                                break;
                            default:
                                sb.push(peek);
                                break;
                        }
                    } while (peek != '\"' && peek != eof);
                    peek = ' ';
                    var val = sb.join('');
                    return new StringLiteral('\"'+val+'\"', val, self.line, self.tokencol);
                }
                else if (peek == '\'')
                {
                    var sb = [];
                    do
                    {
                        peek = readch();
                        switch (peek)
                        {
                            case eof:
                            case '\'':
                                break;
                            default:
                                sb.push(peek);
                                break;
                        }
                    } while (peek != '\'' && peek != eof);
                    peek = ' ';
                    var val = sb.join('');
                    return new StringLiteral('\''+val+'\'', val, self.line, self.tokencol);
                }
                else if (peek == '.' || digit.test(peek))
                {
                    // returns: a dot or a real. real = .d[.d]*|d[.d]*
                    var d = 0.0;
                    if (peek == '.')
                    {
                        peek = readch();
                        if (!digit.test(peek))
                        {
                            return new Token(TokenKind.Dot, self.line, self.tokencol);
                        }
                        // Fall through to the fractional part: peek holds the first digit
                    }
                    else
                    {
                        // integral part (lexeme begins with a digit)
                        do
                        {
                            d = d * 10 + parseFloat(peek);
                            peek = readch();
                        } while (digit.test(peek));
                    }

                    var p = 10.0;
                    // fractional part
                    while (digit.test(peek) || peek == '.')
                    {
                        if (peek != '.')
                        {
                            d += parseFloat(peek) / p;
                            p *= 10;
                        }
                        peek = readch();
                    }
                    return new Real(d, self.line, self.tokencol);
                }
                else if (peek == '$')
                {
                    peek = readch();
                    var d = 0;
                    while (digit.test(peek) || (peek >= 'a' && peek <= 'f') || (peek >= 'A' && peek <= 'F'))
                    {
                        var hex = "0123456789ABCDEF"
                        d = d * 16 + hex.indexOf(peek.toUpperCase);
                        peek = readch();
                    }
                    return new Real(d, self.line, self.tokencol);
                }
                else if (peek == '/')
                {
                    peek = readch();
                    switch (peek)
                    {
                        case '=':
                            peek = readch(); return new Token(TokenKind.DivideAssignment, self.line, self.tokencol);
                        case '/':
                            do peek = readch(); while (peek != '\n' && peek != '\r' && peek != eof);
                            skipwhite = true;
                            break;
                        case '*':
                            do
                            {
                                peek = readch();
                                if (peek == '*')
                                {
                                    peek = readch();
                                    if (peek == '/')
                                    {
                                        peek = readch();
                                        break;
                                    }
                                }
                            } while (peek != eof);
                            //error(Token.None, "End-of-file found, '*/' expected");
                            skipwhite = true;
                            break;
                        default:
                            return new Token(TokenKind.Divide, self.line, self.tokencol);
                    }
                }
                else
                {
                    switch (peek)
                    {
                        case '~': peek = readch(); return new Token(TokenKind.BitwiseComplement, self.line, self.tokencol);
                        case '(': peek = readch(); return new Token(TokenKind.OpeningParenthesis, self.line, self.tokencol);
                        case ')': peek = readch(); return new Token(TokenKind.ClosingParenthesis, self.line, self.tokencol);
                        case '{': peek = readch(); return new Token(TokenKind.OpeningCurlyBrace, self.line, self.tokencol);
                        case '}': peek = readch(); return new Token(TokenKind.ClosingCurlyBrace, self.line, self.tokencol);
                        case '[': peek = readch(); return new Token(TokenKind.OpeningSquareBracket, self.line, self.tokencol);
                        case ']': peek = readch(); return new Token(TokenKind.ClosingSquareBracket, self.line, self.tokencol);
                        case ';': peek = readch(); return new Token(TokenKind.Semicolon, self.line, self.tokencol);
                        case ',': peek = readch(); return new Token(TokenKind.Comma, self.line, self.tokencol);
                        case ':': peek = readch(); if (peek == '=') { peek = readch(); return TokenLexeme(TokenKind.Assignment, ":=", self.line, self.tokencol); } return new Token(TokenKind.Colon, self.line, self.tokencol);
                        case '=': peek = readch(); if (peek == '=') { peek = readch(); return new Token(TokenKind.Equality, self.line, self.tokencol); } return TokenLexeme(TokenKind.Assignment, "=", self.line, self.tokencol);
                        case '!': peek = readch(); if (peek == '=') { peek = readch(); return new Token(TokenKind.Inequality, self.line, self.tokencol); } return new Token(TokenKind.Not, self.line, self.tokencol);
                        case '*': peek = readch(); if (peek == '=') { peek = readch(); return new Token(TokenKind.MultiplyAssignment, self.line, self.tokencol); } return new Token(TokenKind.Multiply, self.line, self.tokencol);
                        case '+': peek = readch(); if (peek == '=') { peek = readch(); return new Token(TokenKind.AdditionAssignment, self.line, self.tokencol); } return new Token(TokenKind.Plus, self.line, self.tokencol);
                        case '-': peek = readch(); if (peek == '=') { peek = readch(); return new Token(TokenKind.SubtractionAssignment, self.line, self.tokencol); } return new Token(TokenKind.Minus, self.line, self.tokencol);
                        case '&': peek = readch(); if (peek == '=') { peek = readch(); return new Token(TokenKind.AndAssignment, self.line, self.tokencol); }
                            else
                                if (peek == '&') { peek = readch(); return new Token(TokenKind.LogicalAnd, self.line, self.tokencol); } return new Token(TokenKind.BitwiseAnd, self.line, self.tokencol);
                        case '|': peek = readch(); if (peek == '=') { peek = readch(); return new Token(TokenKind.OrAssignment, self.line, self.tokencol); }
                            else
                                if (peek == '|') { peek = readch(); return new Token(TokenKind.LogicalOr, self.line, self.tokencol); } return new Token(TokenKind.BitwiseOr, self.line, self.tokencol);
                        case '^': peek = readch(); if (peek == '=') { peek = readch(); return new Token(TokenKind.XorAssignment, self.line, self.tokencol); }
                            else
                                if (peek == '^') { peek = readch(); return new Token(TokenKind.LogicalXor, self.line, self.tokencol); } return new Token(TokenKind.BitwiseXor, self.line, self.tokencol);
                        case '<':
                            peek = readch();
                            if (peek == '=')
                            {
                                peek = readch();
                                return new Token(TokenKind.LessThanOrEqual, self.line, self.tokencol);
                            }
                            else if (peek == '<')
                            {
                                peek = readch();
                                return new Token(TokenKind.ShiftLeft, self.line, self.tokencol);
                            }
                            else if (peek == '>')
                            {
                                peek = readch();
                                return TokenLexeme(TokenKind.Inequality, "<>", self.line, self.tokencol);
                            }
                            else return new Token(TokenKind.LessThan, self.line, self.tokencol);
                        case '>':
                            peek = readch();
                            if (peek == '=')
                            {
                                peek = readch();
                                return new Token(TokenKind.GreaterThanOrEqual, self.line, self.tokencol);
                            }
                            else if (peek == '>')
                            {
                                peek = readch();
                                return new Token(TokenKind.ShiftRight, self.line, self.tokencol);
                            }
                            else return new Token(TokenKind.GreaterThan, self.line, self.tokencol);
                        default:
                            throw new ProgramError(Error.UnexpectedSymbol, self.line, self.tokencol);
                    }
                }
            } while (skipwhite);
        };
        
        function readch() {
            if (chars.length) return chars.pop();
            if (reader.Peek() == -1) return eof;
            var c = String.fromCharCode(reader.Read());
            self.col++;
            if (c == '\n') {
            		line++;
                self.col = 1;
            }
            return c;
        }
        function peekch() {
            var c = readch();
            putbackc(c);
            return c;
        }
        function putbackc(c) {
            chars.push(c);
        }
    }
    
    function static (Words) {
        Lexer.Words = Words;
        
        reserve(Token.Break);
        reserve(Token.Continue);
        reserve(Token.Return);
        reserve(Token.If);
        reserve(Token.Then);
        reserve(Token.Else);
        reserve(Token.While);
        reserve(Token.Do);
        reserve(Token.Until);
        reserve(Token.For);
        reserve(Token.NotWord);
        reserve(Token.And);
        reserve(Token.Or);
        reserve(Token.Xor);
        reserve(Token.Repeat);
        reserve(Token.With);
        reserve(Token.Div);
        reserve(Token.Mod);
        reserve(Token.Var);
        reserve(Token.Globalvar);
        reserve(Token.Switch);
        reserve(Token.Case);
        reserve(Token.Default);
        reserve(Token.Exit);
        reserve(Token.Begin);
        reserve(Token.End);
        reserve(Token.Self);
        reserve(Token.Other);
        reserve(Token.All);
        reserve(Token.Noone);
        reserve(Token.Global);
    }
    
    function reserve(t) {
        Lexer.Words[t.lexeme] = t;
    }
    
    static(Words);
    
    return Lexer;
})();