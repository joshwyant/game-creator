using System;
using System.Collections.Generic;
using System.Text;

namespace GameCreator.Framework.Gml
{
    public class Parser
    {
        Lexer l;
        Token next;
        Terminal t;
        static System.Collections.Hashtable globalvars = new System.Collections.Hashtable();
        System.Collections.Hashtable localvars = new System.Collections.Hashtable();
        /*
        public static Value Execute(string s)
        {
            return Execute(Env.CreatePrivateInstance(), s);
        }
        public static Value Execute(Env inst, string s)
        {
            Env t = Env.Current;
            Env.Current = inst; // The current instance executing the code
            Parser p = new Parser(s);
            try
            {
                Stmt st = p.Parse();
                Env.Enter();
                try
                {
                    st.Exec();
                }
                catch
                {
                    throw;
                }
                finally
                {
                    Env.Leave();
                }
            }
            catch (ProgramError err)
            {
                throw;
            }
			finally
			{
				Env.Current = t;
			}
            return Env.Returned;
        }
        */
        public static Value Evaluate(string s)
        {
            return Evaluate(Env.CreatePrivateInstance(), s);
        }
        public static Value Evaluate(Instance inst, string s)
        {
            if (string.IsNullOrEmpty(s.Trim()))
                return 0;
            Value v = 0;
            Instance t = Env.Current;
            Env.Current = inst; // The current instance executing the code
            Parser p = new Parser(s);
            Expr e = p.ParseExpression();
            Env.Enter();
            try
            {
                v = e.Eval();
            }
            catch
            {
                throw;
            }
            finally
            {
                Env.Leave();
                Env.Current = t;
            }
            return v;
        }
        public Parser(Lexer lex)
        {
            l = lex;
        }
        public Parser(string s)
        {
            System.IO.MemoryStream ms = new System.IO.MemoryStream();
            System.IO.BinaryWriter bw = new System.IO.BinaryWriter(ms, Encoding.ASCII);
            bw.Write(s.ToCharArray());
            ms.Seek(0, System.IO.SeekOrigin.Begin);
            l = new Lexer(ms, Encoding.ASCII);
        }
        void move()
        {
            next = l.Scan();
            t = next.t;
        }
        void error(string s)
        {
            throw new ProgramError(s, ErrorSeverity.CompilationError, next.line, next.col);
        }
        void match(Token tok)
        {
            match(tok.t, string.Format("Symbol {0} expected.", tok.ToString()));
        }
        void match(Terminal ter, string err)
        {
            if (next.t == ter)
                move();
            else
                error(err);
        }
        void match(Terminal ter)
        {
            match(ter, "Unexpected symbol in expression.");
        }
        Token peek()
        {
            Token tok = l.Scan();
            l.PutBack(tok);
            return tok;
        }
        public Stmt Parse()
        {
            // the Game Maker lexer runs before parsing, but we will scan as we are parsing, using l.Scan(),
            // implemented in move() and peek(). We will, as in Game Maker, parse completely before executing,
            // to catch all compile errors. I've heard Game Maker compiles to byte code, but we will build
            // a parse tree of Stmts and Exprs. We return a Stmt node that can be executed by Stmt.Exec().
            // Game Maker does all of its parsing during loading, and if there are no errors, caches the
            // intermediate representation, which is referenced by the events and scripts.
            Stmt s;
            move();
            if (t == Terminal.OpeningCurlyBrace)
            {
                s = block(); if (t != Terminal.Eof) error("Program ends before end of the code.");
                return s;
            }
            s = Stmt.Null;
            while (t != Terminal.Eof)
            {
                s = new Seq(s, stmt(), next.line, next.col); // stmt() throws ProgramError
            }
            return s;
        }
        public Expr ParseExpression()
        {
            move();
            Expr e = expr();
            if (t != Terminal.Eof) error("Unexpected symbol in expression.");
            return e;
        }
        Expr expr()
        {
            Token temp = next;
            Expr x = rel();
            while (true)
            {
                switch (t)
                {
                    case Terminal.LogicalAnd:
                        move(); x = new LogicalAnd(x, rel(), temp.line, temp.col); continue;
                    case Terminal.LogicalOr:
                        move(); x = new LogicalOr(x, rel(), temp.line, temp.col); continue;
                    case Terminal.LogicalXor:
                        move(); x = new LogicalXor(x, rel(), temp.line, temp.col); continue;
                    default:
                        return x;
                }
            }
        }
        Expr rel()
        {
            Token temp = next;
            Expr x = bitwise();
            while (true)
            {
                switch (t)
                {
                    case Terminal.LessThan:
                        move(); x = new LessThan(x, bitwise(), temp.line, temp.col); continue;
                    case Terminal.LessThanOrEqual:
                        move(); x = new LessThanOrEqual(x, bitwise(), temp.line, temp.col); continue;
                    case Terminal.GreaterThan:
                        move(); x = new GreaterThan(x, bitwise(), temp.line, temp.col); continue;
                    case Terminal.GreaterThanOrEqual:
                        move(); x = new GreaterThanOrEqual(x, bitwise(), temp.line, temp.col); continue;
                    case Terminal.Inequality:
                        move(); x = new NotEqual(x, bitwise(), temp.line, temp.col); continue;
                    case Terminal.Equality:
                    case Terminal.Assignment:
                        move(); x = new Equality(x, bitwise(), temp.line, temp.col); continue;
                    default:
                        return x;
                }
            }
        }
        Expr bitwise()
        {
            Token temp = next;
            Expr x = shift();
            while (true)
            {
                switch (t)
                {
                    case Terminal.BitwiseAnd:
                        move(); x = new BitwiseAnd(x, shift(), temp.line, temp.col); continue;
                    case Terminal.BitwiseOr:
                        move(); x = new BitwiseOr(x, shift(), temp.line, temp.col); continue;
                    case Terminal.BitwiseXor:
                        move(); x = new BitwiseXor(x, shift(), temp.line, temp.col); continue;
                    default:
                        return x;
                }
            }
        }
        Expr shift()
        {
            Token temp = next;
            Expr x = add();
            while (true)
            {
                switch (t)
                {
                    case Terminal.ShiftLeft:
                        move(); x = new ShiftLeft(x, add(), temp.line, temp.col); continue;
                    case Terminal.ShiftRight:
                        move(); x = new ShiftRight(x, add(), temp.line, temp.col); continue;
                    default:
                        return x;
                }
            }
        }
        Expr add()
        {
            Token temp = next;
            Expr x = term();
            while (true)
            {
                switch (t)
                {
                    case Terminal.Plus:
                        move(); x = new Addition(x, term(), temp.line, temp.col); continue;
                    case Terminal.Minus:
                        move(); x = new Subtraction(x, term(), temp.line, temp.col); continue;
                    default:
                        return x;
                }
            }
        }
        Expr term()
        {
            Token temp = next;
            Expr x = unary();
            while (true)
            {
                switch (t)
                {
                    case Terminal.Multiply:
                        move(); x = new Multiply(x, unary(), temp.line, temp.col); continue;
                    case Terminal.Divide:
                        move(); x = new Divide(x, unary(), temp.line, temp.col); continue;
                    case Terminal.Mod:
                        move(); x = new Mod(x, unary(), temp.line, temp.col); continue;
                    case Terminal.Div:
                        move(); x = new Div(x, unary(), temp.line, temp.col); continue;
                    default:
                        return x;
                }
            }
        }
        Expr unary()
        {
            Token temp = next;
            while (true)
            {
                switch (t)
                {
                    case Terminal.Plus:
                        move(); return new Plus(unary(), temp.line, temp.col);
                    case Terminal.Minus:
                        move(); return new Minus(unary(), temp.line, temp.col);
                    case Terminal.Not:
                        move(); return new Not(unary(), temp.line, temp.col);
                    case Terminal.BitwiseComplement:
                        move(); return new Complement(unary(), temp.line, temp.col);
                    default:
                        return access();
                }
            }
        }
        Expr access()
        {
            Token temp = next;
            Expr x = factor();
            if (x.GetType() == typeof(Id))
                if (Env.constants.ContainsKey(x.ToString()))
                    x = new Constant(Env.constants[x.ToString()].Real, temp.line, temp.col);
                else
                    x = new Access(null, x.ToString(), subscript(), temp.line, temp.col);
            while (t == Terminal.Dot)
            {
                move();
                if (t != Terminal.Identifier || Env.constants.ContainsKey(next.lexeme))
                    error("Variable name expected.");
                string n = next.lexeme;
                move();
                x = new Access(x, n, subscript(), temp.line, temp.col);
            }
            return x;
        }
        Expr[] subscript()
        {
            if (t != Terminal.OpeningSquareBracket) return new Expr[0];
            move();
            List<Expr> indices = new List<Expr>();
            while (t != Terminal.ClosingSquareBracket)
            {
                indices.Add(expr());
                if (t == Terminal.Comma) move();
                else if (t != Terminal.ClosingSquareBracket)
                    error("Symbol , or ] expected.");
            }
            move();
            if (indices.Count > 2) error("Only 1- and 2-dimensional arrays are supported.");
            return indices.ToArray();
        }
        Expr factor()
        {
            Expr e;
            Token temp = next;
            switch (t)
            {
                case Terminal.Real:
                    e = new Constant(((Real)next).value, next.line, next.col);
                    move();
                    return e;
                case Terminal.StringLiteral:
                    e = new Constant(((StringLiteral)next).value, next.line, next.col);
                    move();
                    return e;
                case Terminal.Identifier:
                    if (peek().t == Terminal.OpeningParenthesis)
                    {
                        string str = next.lexeme;
                        if (!Env.FunctionExists(str))
                        {
                            error("Unknown function or script: " + str);
                        }
                        move(); move();
                        List<Expr> exprs = new List<Expr>();
                        if (t != Terminal.ClosingParenthesis && t != Terminal.Eof)
                        {
                            exprs.Add(expr());
                        }
                        while (t == Terminal.Comma)
                        {
                            move();
                            exprs.Add(expr());
                        }
                        match(Token.ClosingParenthesis);
                        BaseFunction f = Env.GetFunction(str);
                        if ((f.Argc != -1 && exprs.Count != f.Argc) || exprs.Count > 16)
                            error("Wrong number of arguments to function or script.");
                        return new Call(f, exprs.ToArray(), temp.line, temp.col);
                    }
                    else
                    {
                        Expr x = new Id(next.lexeme, next.line, next.col);
                        move();
                        return x;
                    }
                case Terminal.OpeningParenthesis:
                    move();
                    e = new Grouping(expr(), next.line, next.col);
                    match(Terminal.ClosingParenthesis);
                    return e;
                default:
                    throw new ProgramError("Unexpected symbol in expression.", ErrorSeverity.CompilationError, next.line, next.col);

            }
        }
        Stmt block()
        {
            Stmt s = Stmt.Null;
            int l = next.line;
            int c = next.col;
            match(Token.OpeningCurlyBrace);
            while (t != Terminal.ClosingCurlyBrace && t != Terminal.Eof)
            {
                s = new Seq(s, stmt(), l, c);
            }
            match(Token.ClosingCurlyBrace);
            while (t == Terminal.Semicolon) move();
            return s;
        }
        Stmt assign()
        {
            int l = next.line;
            int c = next.col;
            Expr e = access();
            if (e.GetType() != typeof(Access))
                error("Variable name expected.");
            Access a = (Access)e;
            switch (t)
            {
                case Terminal.Assignment:
                    move(); return new Assignment(a, expr(), l, c);
                case Terminal.AdditionAssignment:
                    move(); return new AdditionAssignment(a, expr(), l, c);
                case Terminal.SubtractionAssignment:
                    move(); return new SubtractionAssignment(a, expr(), l, c);
                case Terminal.MultiplyAssignment:
                    move(); return new MultiplyAssignment(a, expr(), l, c);
                case Terminal.DivideAssignment:
                    move(); return new DivideAssignment(a, expr(), l, c);
                case Terminal.OrAssignment:
                    move(); return new OrAssignment(a, expr(), l, c);
                case Terminal.AndAssignment:
                    move(); return new AndAssignment(a, expr(), l, c);
                case Terminal.XorAssignment:
                    move(); return new XorAssignment(a, expr(), l, c);
                default:
                    throw new ProgramError("Assignment operator expected.", ErrorSeverity.CompilationError, l, c);
            }
        }
        Stmt tstmt()
        {
            int l = next.line;
            int c = next.col;
            Stmt s, s1, s2;
            Expr e;
            if (t == Terminal.OpeningCurlyBrace)
                return block();
            else if (t == Terminal.If)
            {
                move(); e = expr(); if (t == Terminal.Then) move(); s = stmt();
                if (t == Terminal.Else)
                {
                    move();
                    return new If(e, s, stmt(), l, c);
                }
                return new If(e, s, l, c);
            }
            else if (t == Terminal.While)
            {
                move(); e = expr(); if (t == Terminal.Do) move(); return new While(e, stmt(), l, c);
            }
            else if (t == Terminal.Do)
            {
                move();
                s = stmt();
                match(Terminal.Until, "Keyword until expected.");
                return new Do(s, expr(), l, c);
            }
            else if (t == Terminal.For)
            {
                move();
                match(Token.OpeningParenthesis);
                s1 = stmt();
                match(Token.Semicolon);
                e = expr();
                match(Token.Semicolon);
                s2 = stmt();
                match(Token.ClosingParenthesis);
                return new For(s1, e, s2, stmt(), l, c);
            }
            else if (t == Terminal.Break)
            {
                move();
                return new Break(l, c);
            }
            else if (t == Terminal.Continue)
            {
                move();
                return new Continue(l, c);
            }
            else if (t == Terminal.Exit)
            {
                move();
                return new Exit(l, c);
            }
            else if (t == Terminal.Return)
            {
                move();
                return new Return(expr(), l, c);
            }
            else if (t == Terminal.Repeat)
            {
                move();
                return new Repeat(expr(), stmt(), l, c);
            }
            else if (t == Terminal.Var)
            {
                move();
                List<string> strs = new List<string>();
                while (t == Terminal.Identifier)
                {
                    if (peek().t == Terminal.OpeningParenthesis) break;
                    if (Env.Builtin.Contains(next.lexeme)) error("Cannot redeclare a builtin variable.");
                    strs.Add(next.lexeme);
                    move();
                    if (t == Terminal.Comma) move();
                }
                return new Var(strs.ToArray(), l, c);
            }
            else if (t == Terminal.Globalvar)
            {
                move();
                List<string> strs = new List<string>();
                while (t == Terminal.Identifier)
                {
                    if (peek().t == Terminal.OpeningParenthesis) break;
                    if (Env.Builtin.Contains(next.lexeme)) error("Cannot redeclare a builtin variable.");
                    strs.Add(next.lexeme);
                    move();
                    if (t == Terminal.Comma) move();
                }
                return new Globalvar(strs.ToArray(), l, c);
            }
            else if (t == Terminal.With)
            {
                move();
                e = expr();
                if (t == Terminal.Do) move();
                return new With(e, stmt(), l, c);
            }
            else if (t == Terminal.Default)
            {
                move();
                match(Token.Colon);
                return new Default(l, c);
            }
            else if (t == Terminal.Case)
            {
                move();
                Case @case = new Case(expr(), l, c); // @ since case is a keyword
                match(Token.Colon);
                return @case;
            }
            else if (t == Terminal.Switch)
            {
                move();
                e = expr();
                match(Token.OpeningCurlyBrace);
                List<Stmt> lst = new List<Stmt>();
                while (t != Terminal.ClosingCurlyBrace && t != Terminal.Eof)
                {
                    lst.Add(stmt());
                    while (t == Terminal.Semicolon) move();
                }
                match(Token.ClosingCurlyBrace);
                return new Switch(e, lst.ToArray(), l, c);
            }
            else if (t == Terminal.Identifier)
            {
                if (peek().t == Terminal.OpeningParenthesis)
                {
                    string str = next.lexeme;
                    if (!Env.FunctionExists(str))
                    {
                        error("Unknown function or script: " + str);
                    }
                    move(); move();
                    List<Expr> exprs = new List<Expr>();
                    if (t != Terminal.ClosingParenthesis && t != Terminal.Eof)
                    {
                        exprs.Add(expr());
                    }
                    while (t == Terminal.Comma)
                    {
                        move();
                        exprs.Add(expr());
                    }
                    match(Token.ClosingParenthesis);
                    BaseFunction f = Env.GetFunction(str);
                    if ((f.Argc != -1 && exprs.Count != f.Argc) || exprs.Count > 16)
                        error("Wrong number of arguments to function or script.");
                    return new CallStmt(f, exprs.ToArray(), l, c);
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
        Stmt stmt()
        {
            Stmt s = tstmt();
            while (t == Terminal.Semicolon) move();
            return s;
        }
        public Lexer Lexer
        {
            get
            {
                return l;
            }
        }
    }
}
