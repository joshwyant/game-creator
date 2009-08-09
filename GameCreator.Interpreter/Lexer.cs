namespace GameCreator.Interpreter
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
        System.Collections.Hashtable words = new System.Collections.Hashtable();
        public Lexer(System.IO.Stream s) : this(s, System.Text.Encoding.Default) { }
        public Lexer(System.IO.Stream s, System.Text.Encoding e)
        {
            this.s = s;
            br = new System.IO.BinaryReader(s, e);
            reserve(Token.Break     );
            reserve(Token.Continue  );
            reserve(Token.Return    );
            reserve(Token.If        );
            reserve(Token.Then      );
            reserve(Token.Else      );
            reserve(Token.While     );
            reserve(Token.Do        );
            reserve(Token.Until     );
            reserve(Token.For       );
            reserve(Token.NotWord   );
            reserve(Token.And       );
            reserve(Token.Or        );
            reserve(Token.Xor       );
            reserve(Token.Repeat    );
            reserve(Token.With      );
            reserve(Token.Div       );
            reserve(Token.Mod       );
            reserve(Token.Var       );
            reserve(Token.Globalvar );
            reserve(Token.Switch    );
            reserve(Token.Case      );
            reserve(Token.Default   );
            reserve(Token.Exit      );
            reserve(Token.Begin     );
            reserve(Token.End       );
            reserve(Token.Self      );
            reserve(Token.Other     );
            reserve(Token.All       );
            reserve(Token.Noone     );
            reserve(Token.Global    );
        }
        void reserve(Token t) { words.Add(t.lexeme, t); }
        public void ReserveConstant(string name, string val)
        {
            reserve(new StringLiteral(val, name));
        }
        public void ReserveConstant(string name, double val)
        {
            reserve(new Real(val, name));
        }
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
                if (words.Contains(s)) return (Token)words[s];
                Token t = new Token(Terminal.Identifier, s);
                words.Add(s, t);
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
                return new StringLiteral(sb.ToString());
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
                return new StringLiteral(sb.ToString());
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
                        return Token.Dot;
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
                return new Real(d);
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
                return new Real(d);
            }
            else if (peek == '/')
            {
                peek = readch();
                switch (peek)
                {
                    case '=':
                        peek = readch(); return Token.DivideAssignment;
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
                        return Token.Divide;
                }
            }
            else
            {
                switch (peek)
                {
                    case '~': peek = readch(); return Token.BitwiseComplement;
                    case '(': peek = readch(); return Token.OpeningParenthesis;
                    case ')': peek = readch(); return Token.ClosingParenthesis;
                    case '{': peek = readch(); return Token.OpeningCurlyBrace;
                    case '}': peek = readch(); return Token.ClosingCurlyBrace;
                    case '[': peek = readch(); return Token.OpeningSquareBracket;
                    case ']': peek = readch(); return Token.ClosingSquareBracket;
                    case ';': peek = readch(); return Token.Semicolon;
                    case ',': peek = readch(); return Token.Comma;
                    case ':': peek = readch(); if (peek == '=') { peek = readch(); return new Token(Terminal.Assignment, ":="); } return Token.Colon;
                    case '=': peek = readch(); if (peek == '=') { peek = readch(); return Token.Equality; } return Token.Assignment;
                    case '!': peek = readch(); if (peek == '=') { peek = readch(); return Token.Inequality; } return Token.Not;
                    case '*': peek = readch(); if (peek == '=') { peek = readch(); return Token.MultiplyAssignment; } return Token.Multiply;
                    case '+': peek = readch(); if (peek == '=') { peek = readch(); return Token.AdditionAssignment; } return Token.Plus;
                    case '-': peek = readch(); if (peek == '=') { peek = readch(); return Token.SubtractionAssignment; } return Token.Minus;
                    case '&': peek = readch(); if (peek == '=') { peek = readch(); return Token.AndAssignment; }
                        else
                            if (peek == '&') { peek = readch(); return Token.LogicalAnd; } return Token.BitwiseAnd;
                    case '|': peek = readch(); if (peek == '=') { peek = readch(); return Token.OrAssignment; }
                        else
                            if (peek == '|') { peek = readch(); return Token.LogicalOr; } return Token.BitwiseOr;
                    case '^': peek = readch(); if (peek == '=') { peek = readch(); return Token.XorAssignment; }
                        else
                            if (peek == '^') { peek = readch(); return Token.LogicalXor; } return Token.BitwiseXor;
                    case '<':
                        peek = readch();
                        if (peek == '=')
                        {
                            peek = readch();
                            return Token.LessThanOrEqual;
                        }
                        else if (peek == '<')
                        {
                            peek = readch();
                            return Token.ShiftLeft;
                        }
                        else if (peek == '>')
                        {
                            peek = readch();
                            return new Token(Terminal.Inequality, "<>");
                        }
                        else return Token.LessThan;
                    case '>':
                        peek = readch();
                        if (peek == '=')
                        {
                            peek = readch();
                            return Token.GreaterThanOrEqual;
                        }
                        else if (peek == '>')
                        {
                            peek = readch();
                            return Token.ShiftRight;
                        }
                        else return Token.GreaterThan;
                    default:
                        throw new ProgramError("Unexpected symbol.");
                }
            }

        }
    }
}
