using System;
using System.Collections.Generic;
using System.Text;
using System.IO;
using System.Linq;

namespace GameCreator.Framework.Gml
{
    public class Parser
    {
        public LibraryContext Context { get; set; }
        Lexer l;
        Token next;
        TokenKind t;
        
        internal Parser(LibraryContext context, Lexer lex)
        {
            l = lex;
            Context = context ?? new LibraryContext();
        }

        public Parser(LibraryContext context, TextReader r)
            : this(context, new Lexer(r)) { }

        void move()
        {
            next = l.Scan();
            t = next.t;
        }

        void error(Error err)
        {
            throw new ProgramError(err, next.line, next.col);
        }

        void error(Error err, object obj)
        {
            throw new ProgramError(err, obj, next.line, next.col);
        }

        void match(Token tok)
        {
            match(tok, Error.SymbolExpected);
        }

        void match(Token ter, Error err)
        {
            if (next.t == ter.t)
                move();
            else
                throw new ProgramError(err, ter.ToString(), next.line, next.col);
        }

        Token peek()
        {
            Token tok = l.Scan();
            l.PutBack(tok);
            return tok;
        }

        public Statement Parse()
        {
            // the Game Maker lexer runs before parsing, but we will scan as we are parsing, using l.Scan(),
            // implemented in move() and peek(). We will, as in Game Maker, parse completely before executing,
            // to catch all compile errors. I've heard Game Maker compiles to byte code, but we will build
            // a parse tree of Stmts and Exprs. We return a Stmt node that can be executed by Stmt.Exec().
            // Game Maker does all of its parsing during loading, and if there are no errors, caches the
            // intermediate representation, which is referenced by the events and scripts.
            Statement s;
            move();
            if (t == TokenKind.OpeningCurlyBrace)
            {
                s = block(); if (t != TokenKind.Eof) error(Error.ProgramEnds);
                return s;
            }
            s = Statement.Nop;
            while (t != TokenKind.Eof)
            {
                s = new Sequence(s, stmt(), next.line, next.col); // stmt() throws ProgramError
            }
            return s;
        }

        /// <summary>
        /// This will return a constant 0 if the parser parses an empty string.
        /// </summary>
        public Expression ParseExpression()
        {
            move();
            if (t == TokenKind.Eof)
                return new Constant(0, 0, 0);

            Expression e = expr();
            if (t != TokenKind.Eof) error(Error.UnexpectedSymbol);
            return e;
        }

        Expression expr()
        {
            Token temp = next;
            Expression x = rel();
            while (true)
            {
                switch (t)
                {
                    case TokenKind.LogicalAnd:
                        move(); x = new LogicalAnd(x, rel(), temp.line, temp.col); continue;
                    case TokenKind.LogicalOr:
                        move(); x = new LogicalOr(x, rel(), temp.line, temp.col); continue;
                    case TokenKind.LogicalXor:
                        move(); x = new LogicalXor(x, rel(), temp.line, temp.col); continue;
                    default:
                        return x;
                }
            }
        }

        Expression rel()
        {
            Token temp = next;
            Expression x = bitwise();
            while (true)
            {
                switch (t)
                {
                    case TokenKind.LessThan:
                        move(); x = new LessThan(x, bitwise(), temp.line, temp.col); continue;
                    case TokenKind.LessThanOrEqual:
                        move(); x = new LessThanOrEqual(x, bitwise(), temp.line, temp.col); continue;
                    case TokenKind.GreaterThan:
                        move(); x = new GreaterThan(x, bitwise(), temp.line, temp.col); continue;
                    case TokenKind.GreaterThanOrEqual:
                        move(); x = new GreaterThanOrEqual(x, bitwise(), temp.line, temp.col); continue;
                    case TokenKind.Inequality:
                        move(); x = new NotEqual(x, bitwise(), temp.line, temp.col); continue;
                    case TokenKind.Equality:
                    case TokenKind.Assignment:
                        move(); x = new Equality(x, bitwise(), temp.line, temp.col); continue;
                    default:
                        return x;
                }
            }
        }

        Expression bitwise()
        {
            Token temp = next;
            Expression x = shift();
            while (true)
            {
                switch (t)
                {
                    case TokenKind.BitwiseAnd:
                        move(); x = new BitwiseAnd(x, shift(), temp.line, temp.col); continue;
                    case TokenKind.BitwiseOr:
                        move(); x = new BitwiseOr(x, shift(), temp.line, temp.col); continue;
                    case TokenKind.BitwiseXor:
                        move(); x = new BitwiseXor(x, shift(), temp.line, temp.col); continue;
                    default:
                        return x;
                }
            }
        }

        Expression shift()
        {
            Token temp = next;
            Expression x = add();
            while (true)
            {
                switch (t)
                {
                    case TokenKind.ShiftLeft:
                        move(); x = new ShiftLeft(x, add(), temp.line, temp.col); continue;
                    case TokenKind.ShiftRight:
                        move(); x = new ShiftRight(x, add(), temp.line, temp.col); continue;
                    default:
                        return x;
                }
            }
        }

        Expression add()
        {
            Token temp = next;
            Expression x = term();
            while (true)
            {
                switch (t)
                {
                    case TokenKind.Plus:
                        move(); x = new Addition(x, term(), temp.line, temp.col); continue;
                    case TokenKind.Minus:
                        move(); x = new Subtraction(x, term(), temp.line, temp.col); continue;
                    default:
                        return x;
                }
            }
        }

        Expression term()
        {
            Token temp = next;
            Expression x = unary();
            while (true)
            {
                switch (t)
                {
                    case TokenKind.Multiply:
                        move(); x = new Multiply(x, unary(), temp.line, temp.col); continue;
                    case TokenKind.Divide:
                        move(); x = new Divide(x, unary(), temp.line, temp.col); continue;
                    case TokenKind.Mod:
                        move(); x = new Mod(x, unary(), temp.line, temp.col); continue;
                    case TokenKind.Div:
                        move(); x = new Div(x, unary(), temp.line, temp.col); continue;
                    default:
                        return x;
                }
            }
        }

        Expression unary()
        {
            Token temp = next;
            while (true)
            {
                switch (t)
                {
                    case TokenKind.Plus:
                        move(); return new Plus(unary(), temp.line, temp.col);
                    case TokenKind.Minus:
                        move(); return new Minus(unary(), temp.line, temp.col);
                    case TokenKind.Not:
                        move(); return new Not(unary(), temp.line, temp.col);
                    case TokenKind.BitwiseComplement:
                        move(); return new Complement(unary(), temp.line, temp.col);
                    default:
                        return access();
                }
            }
        }

        Expression access()
        {
            Token temp = next;
            Expression x = factor();
            if (x.GetType() == typeof(Id))
            {
                var val = Context.Resources.GetNamedValue(x.ToString());
                if (!val.IsNull)
                    x = val.IsReal ? new Constant(val.Real, temp.line, temp.col) : new Constant(val.String, temp.line, temp.col);
                else
                    x = new Access(null, x.ToString(), subscript(), temp.line, temp.col);
            }
            while (t == TokenKind.Dot)
            {
                move();
                if (t != TokenKind.Identifier || !Context.Resources.GetNamedValue(x.ToString()).IsNull)
                    error(Error.ExpectedVariableName);
                string n = next.lexeme;
                move();
                x = new Access(x, n, subscript(), temp.line, temp.col);
            }
            return x;
        }

        Expression[] subscript()
        {
            if (t != TokenKind.OpeningSquareBracket) return new Expression[0];
            move();
            List<Expression> indices = new List<Expression>();
            while (t != TokenKind.ClosingSquareBracket)
            {
                indices.Add(expr());
                if (t == TokenKind.Comma) move();
                else if (t != TokenKind.ClosingSquareBracket)
                    error(Error.ArraySymbol);
            }
            move();
            if (indices.Count > 2) error(Error.ArrayDegree);
            return indices.ToArray();
        }

        Expression factor()
        {
            Expression e;
            Token temp = next;
            switch (t)
            {
                case TokenKind.Real:
                    e = new Constant(((Real)next).value, next.line, next.col);
                    move();
                    return e;
                case TokenKind.StringLiteral:
                    e = new Constant(((StringLiteral)next).value, next.line, next.col);
                    move();
                    return e;
                case TokenKind.Identifier:
                    if (peek().t == TokenKind.OpeningParenthesis)
                    {
                        string str = next.lexeme;
                        if (!Context.Resources.FunctionExists(str))
                        {
                            error(Error.UnknownFunction, str);
                        }
                        move(); move();
                        List<Expression> exprs = new List<Expression>();
                        if (t != TokenKind.ClosingParenthesis && t != TokenKind.Eof)
                        {
                            exprs.Add(expr());
                        }
                        while (t == TokenKind.Comma)
                        {
                            move();
                            exprs.Add(expr());
                        }
                        match(Token.ClosingParenthesis);
                        IFunction f = Context.Resources.GetFunction(str);
                        if ((f.Argc != -1 && exprs.Count != f.Argc) || exprs.Count > 16)
                            error(Error.WrongArgumentNumber);
                        return new Call(f, exprs.ToArray(), temp.line, temp.col);
                    }
                    else
                    {
                        Expression x = new Id(next.lexeme, next.line, next.col);
                        move();
                        return x;
                    }
                case TokenKind.OpeningParenthesis:
                    move();
                    e = new Grouping(expr(), next.line, next.col);
                    match(Token.ClosingParenthesis, Error.UnexpectedSymbolInExpression);
                    return e;
                default:
                    throw new ProgramError(Error.UnexpectedSymbolInExpression, ErrorSeverity.CompilationError, next.line, next.col);

            }
        }

        Statement block()
        {
            Statement s = Statement.Nop;
            int l = next.line;
            int c = next.col;
            match(Token.OpeningCurlyBrace);
            while (t != TokenKind.ClosingCurlyBrace && t != TokenKind.Eof)
            {
                s = new Sequence(s, stmt(), l, c);
            }
            match(Token.ClosingCurlyBrace);
            while (t == TokenKind.Semicolon) move();
            return s;
        }

        Statement assign()
        {
            int l = next.line;
            int c = next.col;
            Expression e = access();
            if (e.GetType() != typeof(Access))
                error(Error.ExpectedVariableName);
            Access a = (Access)e;
            switch (t)
            {
                case TokenKind.Assignment:
                    move(); return new Assignment(a, expr(), l, c);
                case TokenKind.AdditionAssignment:
                    move(); return new AdditionAssignment(a, expr(), l, c);
                case TokenKind.SubtractionAssignment:
                    move(); return new SubtractionAssignment(a, expr(), l, c);
                case TokenKind.MultiplyAssignment:
                    move(); return new MultiplyAssignment(a, expr(), l, c);
                case TokenKind.DivideAssignment:
                    move(); return new DivideAssignment(a, expr(), l, c);
                case TokenKind.OrAssignment:
                    move(); return new OrAssignment(a, expr(), l, c);
                case TokenKind.AndAssignment:
                    move(); return new AndAssignment(a, expr(), l, c);
                case TokenKind.XorAssignment:
                    move(); return new XorAssignment(a, expr(), l, c);
                default:
                    throw new ProgramError(Error.ExpectedAssignmentOperator, ErrorSeverity.CompilationError, l, c);
            }
        }

        Statement tstmt()
        {
            int l = next.line;
            int c = next.col;
            Statement s, s1, s2;
            Expression e;
            if (t == TokenKind.OpeningCurlyBrace)
                return block();
            else if (t == TokenKind.If)
            {
                move(); e = expr(); if (t == TokenKind.Then) move(); s = stmt();
                if (t == TokenKind.Else)
                {
                    move();
                    return new If(e, s, stmt(), l, c);
                }
                return new If(e, s, l, c);
            }
            else if (t == TokenKind.While)
            {
                move(); e = expr(); if (t == TokenKind.Do) move(); return new While(e, stmt(), l, c);
            }
            else if (t == TokenKind.Do)
            {
                move();
                s = stmt();
                match(Token.Until, Error.ExpectedUntil);
                return new Do(s, expr(), l, c);
            }
            else if (t == TokenKind.For)
            {
                // "For" is very weird in GM. Any legal statement including control flow and blocks can be used in for.
                // example of legal "for" statements:
                // for (i = 0 i<3; {case 3:exit};;;)func();
                move();
                match(Token.OpeningParenthesis);
                s1 = stmt();
                //match(Token.Semicolon); // Taken care of by stmt();
                e = expr();
                match(Token.Semicolon);
                s2 = stmt();
                match(Token.ClosingParenthesis);
                return new For(s1, e, s2, stmt(), l, c);
            }
            else if (t == TokenKind.Break)
            {
                move();
                return new Break(l, c);
            }
            else if (t == TokenKind.Continue)
            {
                move();
                return new Continue(l, c);
            }
            else if (t == TokenKind.Exit)
            {
                move();
                return new Exit(l, c);
            }
            else if (t == TokenKind.Return)
            {
                move();
                return new Return(expr(), l, c);
            }
            else if (t == TokenKind.Repeat)
            {
                move();
                return new Repeat(expr(), stmt(), l, c);
            }
            else if (t == TokenKind.Var)
            {
                move();
                List<string> strs = new List<string>();
                while (t == TokenKind.Identifier)
                {
                    if (peek().t == TokenKind.OpeningParenthesis) break;
                    if (Context.IsBuiltIn(next.lexeme)) error(Error.BuiltinVariable);
                    strs.Add(next.lexeme);
                    move();
                    if (t == TokenKind.Comma) move();
                }
                return new Var(strs.ToArray(), l, c);
            }
            else if (t == TokenKind.Globalvar)
            {
                move();
                List<string> strs = new List<string>();
                while (t == TokenKind.Identifier)
                {
                    if (peek().t == TokenKind.OpeningParenthesis) break;
                    if (Context.IsBuiltIn(next.lexeme)) error(Error.BuiltinVariable);
                    strs.Add(next.lexeme);
                    move();
                    if (t == TokenKind.Comma) move();
                }
                return new Globalvar(strs.ToArray(), l, c);
            }
            else if (t == TokenKind.With)
            {
                move();
                e = expr();
                if (t == TokenKind.Do) move();
                return new With(e, stmt(), l, c);
            }
            else if (t == TokenKind.Default)
            {
                move();
                match(Token.Colon);
                return new Default(l, c);
            }
            else if (t == TokenKind.Case)
            {
                move();
                Case @case = new Case(expr(), l, c); // @ since case is a keyword
                match(Token.Colon);
                return @case;
            }
            else if (t == TokenKind.Switch)
            {
                move();
                e = expr();
                match(Token.OpeningCurlyBrace);
                List<Statement> lst = new List<Statement>();
                while (t != TokenKind.ClosingCurlyBrace && t != TokenKind.Eof)
                {
                    lst.Add(stmt());
                    while (t == TokenKind.Semicolon) move();
                }
                match(Token.ClosingCurlyBrace);
                return new Switch(e, lst.ToArray(), l, c);
            }
            else if (t == TokenKind.Identifier)
            {
                if (peek().t == TokenKind.OpeningParenthesis)
                {
                    string str = next.lexeme;
                    if (!Context.Resources.FunctionExists(str))
                    {
                        error(Error.UnknownFunction, str);
                    }
                    move(); move();
                    List<Expression> exprs = new List<Expression>();
                    if (t != TokenKind.ClosingParenthesis && t != TokenKind.Eof)
                    {
                        exprs.Add(expr());
                    }
                    while (t == TokenKind.Comma)
                    {
                        move();
                        exprs.Add(expr());
                    }
                    match(Token.ClosingParenthesis);
                    IFunction f = Context.Resources.GetFunction(str);
                    if ((f.Argc != -1 && exprs.Count != f.Argc) || exprs.Count > 16)
                        error(Error.WrongArgumentNumber);
                    return new CallStatement(f, exprs.ToArray(), l, c);
                }
                else
                {
                    return assign();
                }
            }
            else
            {
                return assign();
            }
        }
        Statement stmt()
        {
            Statement s = tstmt();
            while (t == TokenKind.Semicolon) move();
            return s;
        }
        internal Lexer Lexer
        {
            get
            {
                return l;
            }
        }
    }
}
