namespace GameCreator.Framework.Gml
{
    public class Lexer
    {
        System.IO.Stream s;
        System.IO.BinaryReader br;
        char peek = ' ';
        const char eof = '\xFFFF';
        System.Collections.Generic.Stack<Token> pushed = new System.Collections.Generic.Stack<Token>();
        System.Collections.Generic.Stack<char> chars = new System.Collections.Generic.Stack<char>();
        public int line = 1;
        public int col = 1;
        public int tokencol = 0;
        public static System.Collections.Hashtable Words = new System.Collections.Hashtable();
        static Lexer()
        {
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
        public Lexer(System.IO.Stream s) : this(s, System.Text.Encoding.Default) { }
        public Lexer(System.IO.Stream s, System.Text.Encoding e)
        {
            this.s = s;
            br = new System.IO.BinaryReader(s, e);
        }
        static void reserve(Token t) { Words.Add(t.lexeme, t); }
        char readch()
        {
            if (chars.Count != 0) return chars.Pop();
            if (s.Position == s.Length) return eof;
            char c = br.ReadChar();
            col++;
            if (c == '\n')
            {
                line++;
                col = 1;
            }
            return c;
        }
        char peekch()
        {
            char c = readch();
            putbackc(c);
            return c;
        }
        void putbackc(char c)
        {
            // FIXME: Problem with line numbers here!
            chars.Push(c);
        }
        // useful for lookahead or: >>, interpreted as > >, as in Array<Array<int> > so PutBack(Token.GreaterThan);
        public void PutBack(Token t)
        {
            pushed.Push(t);
        }
        public Token Scan()
        {
            if (pushed.Count != 0) return pushed.Pop();
            skipwhite:
            while (char.IsWhiteSpace(peek))
            {
                peek = readch();
            }
            if (peek == eof) return Token.Eof;
            tokencol = col;
            // [A-Za-z_][A-Za-z0-9_]*
            if (char.IsLetter(peek) || peek == '_')
            {
                System.Text.StringBuilder sb = new System.Text.StringBuilder();
                do
                {
                    sb.Append(peek);
                    peek = readch();
                } while (char.IsLetterOrDigit(peek) || peek == '_');
                string s = sb.ToString();
                // reserve keywords and constants. Return their values literally as tokens
                if (Words.Contains(s)) return (Token)Words[s];
                Token t = new Token(TokenKind.Identifier, s, line, tokencol);
                Words.Add(s, t);
                return t;
            }
            else if (peek == '\"')
            {
                System.Text.StringBuilder sb = new System.Text.StringBuilder();
                do
                {
                    peek = readch();
                    switch (peek)
                    {
                        case eof:
                        case '\"':
                            break;
                        default:
                            sb.Append(peek);
                            break;
                    }
                } while (peek != '\"' && peek != eof);
                peek = ' ';
                return new StringLiteral(sb.ToString(), line, tokencol);
            }
            else if (peek == '\'')
            {
                System.Text.StringBuilder sb = new System.Text.StringBuilder();
                do
                {
                    peek = readch();
                    switch (peek)
                    {
                        case eof:
                        case '\'':
                            break;
                        default:
                            sb.Append(peek);
                            break;
                    }
                } while (peek != '\'' && peek != eof);
                peek = ' ';
                return new StringLiteral(sb.ToString(), line, tokencol);
            }
            else if (peek == '.' || char.IsDigit(peek))
            {
                // returns: a dot or a real. real = .d[.d]*|d[.d]*
                double d = 0;
                if (peek == '.')
                {
                    peek = readch();
                    if (!char.IsDigit(peek))
                    {
                        return new Token(TokenKind.Dot, line, tokencol);
                    }
                    // Fall through to the fractional part: peek holds the first digit
                }
                else
                {
                    // integral part (lexeme begins with a digit)
                    do
                    {
                        d = d * 10 + double.Parse(peek.ToString());
                        peek = readch();
                    } while (char.IsDigit(peek));
                }

                double p = 10;
                // fractional part
                while (char.IsDigit(peek) || peek == '.')
                {
                    if (peek != '.')
                    {
                        d += double.Parse(peek.ToString()) / p;
                        p *= 10;
                    }
                    peek = readch();
                }
                return new Real(d, line, tokencol);
            }
            else if (peek == '$')
            {
                peek = readch();
                double d = 0;
                while (char.IsDigit(peek) || (peek >= 'a' && peek <= 'f') || (peek >= 'A' && peek <= 'F'))
                {
                    d = d * 16 + (double)int.Parse(peek.ToString(), System.Globalization.NumberStyles.AllowHexSpecifier);
                    peek = readch();
                }
                return new Real(d, line, tokencol);
            }
            else if (peek == '/')
            {
                peek = readch();
                switch (peek)
                {
                    case '=':
                        peek = readch(); return new Token(TokenKind.DivideAssignment, line, tokencol);
                    case '/':
                        do peek = readch(); while (peek != '\n' && peek != '\r' && peek != eof);
                        goto skipwhite;
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
                                    goto skipwhite;
                                }
                            }
                        } while (peek != eof);
                        //error(Token.None, "End-of-file found, '*/' expected");
                        goto skipwhite;
                    default:
                        return new Token(TokenKind.Divide, line, tokencol);
                }
            }
            else
            {
                switch (peek)
                {
                    case '~': peek = readch(); return new Token(TokenKind.BitwiseComplement, line, tokencol);
                    case '(': peek = readch(); return new Token(TokenKind.OpeningParenthesis, line, tokencol);
                    case ')': peek = readch(); return new Token(TokenKind.ClosingParenthesis, line, tokencol);
                    case '{': peek = readch(); return new Token(TokenKind.OpeningCurlyBrace, line, tokencol);
                    case '}': peek = readch(); return new Token(TokenKind.ClosingCurlyBrace, line, tokencol);
                    case '[': peek = readch(); return new Token(TokenKind.OpeningSquareBracket, line, tokencol);
                    case ']': peek = readch(); return new Token(TokenKind.ClosingSquareBracket, line, tokencol);
                    case ';': peek = readch(); return new Token(TokenKind.Semicolon, line, tokencol);
                    case ',': peek = readch(); return new Token(TokenKind.Comma, line, tokencol);
                    case ':': peek = readch(); if (peek == '=') { peek = readch(); return new Token(TokenKind.Assignment, ":=", line, tokencol); } return new Token(TokenKind.Colon, line, tokencol);
                    case '=': peek = readch(); if (peek == '=') { peek = readch(); return new Token(TokenKind.Equality, line, tokencol); } return new Token(TokenKind.Assignment, line, tokencol);
                    case '!': peek = readch(); if (peek == '=') { peek = readch(); return new Token(TokenKind.Inequality, line, tokencol); } return new Token(TokenKind.Not, line, tokencol);
                    case '*': peek = readch(); if (peek == '=') { peek = readch(); return new Token(TokenKind.MultiplyAssignment, line, tokencol); } return new Token(TokenKind.Multiply, line, tokencol);
                    case '+': peek = readch(); if (peek == '=') { peek = readch(); return new Token(TokenKind.AdditionAssignment, line, tokencol); } return new Token(TokenKind.Plus, line, tokencol);
                    case '-': peek = readch(); if (peek == '=') { peek = readch(); return new Token(TokenKind.SubtractionAssignment, line, tokencol); } return new Token(TokenKind.Minus, line, tokencol);
                    case '&': peek = readch(); if (peek == '=') { peek = readch(); return new Token(TokenKind.AndAssignment, line, tokencol); }
                        else
                            if (peek == '&') { peek = readch(); return new Token(TokenKind.LogicalAnd, line, tokencol); } return new Token(TokenKind.BitwiseAnd, line, tokencol);
                    case '|': peek = readch(); if (peek == '=') { peek = readch(); return new Token(TokenKind.OrAssignment, line, tokencol); }
                        else
                            if (peek == '|') { peek = readch(); return new Token(TokenKind.LogicalOr, line, tokencol); } return new Token(TokenKind.BitwiseOr, line, tokencol);
                    case '^': peek = readch(); if (peek == '=') { peek = readch(); return new Token(TokenKind.XorAssignment, line, tokencol); }
                        else
                            if (peek == '^') { peek = readch(); return new Token(TokenKind.LogicalXor, line, tokencol); } return new Token(TokenKind.BitwiseXor, line, tokencol);
                    case '<':
                        peek = readch();
                        if (peek == '=')
                        {
                            peek = readch();
                            return new Token(TokenKind.LessThanOrEqual, line, tokencol);
                        }
                        else if (peek == '<')
                        {
                            peek = readch();
                            return new Token(TokenKind.ShiftLeft, line, tokencol);
                        }
                        else if (peek == '>')
                        {
                            peek = readch();
                            return new Token(TokenKind.Inequality, "<>", line, tokencol);
                        }
                        else return new Token(TokenKind.LessThan, line, tokencol);
                    case '>':
                        peek = readch();
                        if (peek == '=')
                        {
                            peek = readch();
                            return new Token(TokenKind.GreaterThanOrEqual, line, tokencol);
                        }
                        else if (peek == '>')
                        {
                            peek = readch();
                            return new Token(TokenKind.ShiftRight, line, tokencol);
                        }
                        else return new Token(TokenKind.GreaterThan, line, tokencol);
                    default:
                        throw new ProgramError("Unexpected symbol.", ErrorSeverity.CompilationError, line, tokencol);
                }
            }

        }
    }
}
