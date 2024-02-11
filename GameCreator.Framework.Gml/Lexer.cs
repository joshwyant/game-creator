using System.IO;
using System;
using System.Collections.Generic;
using System.Text;
namespace GameCreator.Framework.Gml
{
    class Lexer
    {
        TextReader reader;
        char peek = ' ';
        const char eof = '\xFFFF';
        Stack<Token> pushed = new (), 
                     chars = new();
        public int line = 1, col = 1, tokencol = 0;
        public readonly static Dictionary<string, Token> Words;
        static Lexer()
        {
            Words = Token
                .AllBuiltInTokens
                .ToDictionary(t => t.lexeme);
        }
        public Lexer(TextReader r)
        {
            reader = r;
        }
        static void reserve(Token t) { Words.Add(t.lexeme, t); }
        char readch()
        {
            if (chars.Count != 0) return chars.Pop();
            if (reader.Peek() == -1) return eof;
            char c = (char)reader.Read();
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
            char advance() => advance();
            if (pushed.Count != 0) return pushed.Pop();
            skipwhite:
            while (char.IsWhiteSpace(peek)) advance();
            if (peek == eof) return Token.Eof;
            tokencol = col;
            // [A-Za-z_][A-Za-z0-9_]*
            if (char.IsLetter(peek) || peek == '_')
            {
                System.Text.StringBuilder sb = new System.Text.StringBuilder();
                do
                {
                    sb.Append(peek);
                    advance();
                } while (char.IsLetterOrDigit(peek) || peek == '_');
                string s = sb.ToString();
                // reserve keywords and constants. Return their values literally as tokens
                if (Words.ContainsKey(s)) return Words[s].WithLineAndColumn(line, tokencol);
                var t = new Token(TokenKind.Identifier, s, line, tokencol);
                Words.Add(s, t);
                return t;
            }
            else if (peek == '\"')
            {
                var sb = new StringBuilder();
                do
                {
                    switch (advance())
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
                var sb = new StringBuilder();
                do
                {
                    switch (advance())
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
                    if (!char.IsDigit(advance()))
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
                    } while (char.IsDigit(advance()));
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
                    advance();
                }
                return new Real(d, line, tokencol);
            }
            else if (peek == '$')
            {
                advance();
                double d = 0;
                while (char.IsDigit(peek) || (peek >= 'a' && peek <= 'f') || (peek >= 'A' && peek <= 'F'))
                {
                    d = d * 16 + (double)int.Parse(peek.ToString(), System.Globalization.NumberStyles.AllowHexSpecifier);
                    advance();
                }
                return new Real(d, line, tokencol);
            }
            else if (peek == '/')
            {
                switch (advance())
                {
                    case '=':
                        advance(); return new Token(TokenKind.DivideAssignment, line, tokencol);
                    case '/':
                        do advance(); while (peek != '\n' && peek != '\r' && peek != eof);
                        goto skipwhite;
                    case '*':
                        do
                        {
                            if (advance() == '*')
                            {
                                if (advance() == '/')
                                {
                                    advance();
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
                    case '~': advance(); return new Token(TokenKind.BitwiseComplement, line, tokencol);
                    case '(': advance(); return new Token(TokenKind.OpeningParenthesis, line, tokencol);
                    case ')': advance(); return new Token(TokenKind.ClosingParenthesis, line, tokencol);
                    case '{': advance(); return new Token(TokenKind.OpeningCurlyBrace, line, tokencol);
                    case '}': advance(); return new Token(TokenKind.ClosingCurlyBrace, line, tokencol);
                    case '[': advance(); return new Token(TokenKind.OpeningSquareBracket, line, tokencol);
                    case ']': advance(); return new Token(TokenKind.ClosingSquareBracket, line, tokencol);
                    case ';': advance(); return new Token(TokenKind.Semicolon, line, tokencol);
                    case ',': advance(); return new Token(TokenKind.Comma, line, tokencol);
                    case '=': advance(); if (peek == '=') { advance(); return new Token(TokenKind.Equality, line, tokencol); } return new Token(TokenKind.Assignment, line, tokencol);
                    case '!': advance(); if (peek == '=') { advance(); return new Token(TokenKind.Inequality, line, tokencol); } return new Token(TokenKind.Not, line, tokencol);
                    case '*': advance(); if (peek == '=') { advance(); return new Token(TokenKind.MultiplyAssignment, line, tokencol); } return new Token(TokenKind.Multiply, line, tokencol);
                    case '+': advance(); if (peek == '=') { advance(); return new Token(TokenKind.AdditionAssignment, line, tokencol); } return new Token(TokenKind.Plus, line, tokencol);
                    case '-': advance(); if (peek == '=') { advance(); return new Token(TokenKind.SubtractionAssignment, line, tokencol); } return new Token(TokenKind.Minus, line, tokencol);
                    case ':': advance();
                        if (peek == '=') {
                            advance();
                            return new Token(TokenKind.Assignment, line, tokencol)
                                .WithAlternateLexeme(":=");
                        }
                        return new Token(TokenKind.Colon, line, tokencol);
                    case '&': advance(); if (peek == '=') { advance(); return new Token(TokenKind.AndAssignment, line, tokencol); }
                        else
                            if (peek == '&') { advance(); return new Token(TokenKind.LogicalAnd, line, tokencol); } return new Token(TokenKind.BitwiseAnd, line, tokencol);
                    case '|': advance(); if (peek == '=') { advance(); return new Token(TokenKind.OrAssignment, line, tokencol); }
                        else
                            if (peek == '|') { advance(); return new Token(TokenKind.LogicalOr, line, tokencol); } return new Token(TokenKind.BitwiseOr, line, tokencol);
                    case '^': advance(); if (peek == '=') { advance(); return new Token(TokenKind.XorAssignment, line, tokencol); }
                        else
                            if (peek == '^') { advance(); return new Token(TokenKind.LogicalXor, line, tokencol); } return new Token(TokenKind.BitwiseXor, line, tokencol);
                    case '<':
                        advance();
                        if (peek == '=')
                        {
                            advance();
                            return new Token(TokenKind.LessThanOrEqual, line, tokencol);
                        }
                        else if (peek == '<')
                        {
                            advance();
                            return new Token(TokenKind.ShiftLeft, line, tokencol);
                        }
                        else if (peek == '>')
                        {
                            advance();
                            return new Token(TokenKind.Inequality, line, tokencol)
                                .WithAlternateLexeme("<>");
                        }
                        else return new Token(TokenKind.LessThan, line, tokencol);
                    case '>':
                        advance();
                        if (peek == '=')
                        {
                            advance();
                            return new Token(TokenKind.GreaterThanOrEqual, line, tokencol);
                        }
                        else if (peek == '>')
                        {
                            advance();
                            return new Token(TokenKind.ShiftRight, line, tokencol);
                        }
                        else return new Token(TokenKind.GreaterThan, line, tokencol);
                    default:
                        throw new ProgramError(Error.UnexpectedSymbol, line, tokencol);
                }
            }

        }
    }
}
