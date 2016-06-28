(function() {
    var enums = require('./ParseEnums.js');
    var flib = require('./FunctionLibrary.js');
    var errors = require('./Errors.js');

    exports.AstNode = function(line, col) {
        this.Line = line;
        this.Column = col;
    }

    exports.Expression = (function() {
        var ExpressionKind = enums.ExpressionKind;
        
        function Expression(line, col) {
            exports.AstNode.call(this, line, col);
        }
        Expression.prototype = Object.create(exports.AstNode.prototype);

        function BinaryExpression(left, right, line, col) {
            exports.Expression.call(this, line, col);
            this.Left = left;
            this.Right = right;
            this.Kind = ExpressionKind.None;
        }
        BinaryExpression.prototype = Object.create(Expression.prototype);
        exports.BinaryExpression = BinaryExpression;

        function UnaryExpression(operand, line, col) {
            exports.Expression.call(this, line, col);
            this.Operand = operand;
            this.Kind = ExpressionKind.None;
        }
        UnaryExpression.prototype = Object.create(Expression.prototype);
        exports.UnaryExpression = UnaryExpression;

        function Access(left, name, indices, line, col) {
            exports.Expression.call(this, line, col);
            this.Instance = left;
            this.Name = name;
            this.Indices = indices;
            this.Kind = ExpressionKind.Access;
        }
        Access.prototype = Object.create(Expression.prototype);
        exports.Access = Access;

        function Call(func, expressions, line, col) {
            exports.Expression.call(this, line, col);
            this.Function = func;
            this.Expressions = expressions;
            this.Kind = ExpressionKind.Call;
        }
        Call.prototype = Object.create(Expression.prototype);
        exports.Call = Call;

        function Constant(val, line, col) {
            exports.Expression.call(this, line, col);
            this.Value = val;
            this.Kind = ExpressionKind.Constant;
        }
        Constant.prototype = Object.create(Expression.prototype);
        exports.Constant = Constant;

        function Grouping(e, line, col) {
            exports.Expression.call(this, line, col);
            this.InnerExpression = e;
            this.Kind = ExpressionKind.Grouping;
        }
        Grouping.prototype = Object.create(Expression.prototype);
        exports.Grouping = Grouping;

        function Id(name, line, col) {
            exports.Expression.call(this, line, col);
            this.Name = name;
            this.Kind = ExpressionKind.Id;
        }
        Id.prototype = Object.create(Expression.prototype);
        exports.Id = Id;

        function Complement(operand, line, col) {
            exports.UnaryExpression.call(this, operand, line, col);
            this.Kind = ExpressionKind.Complement;
        }
        Complement.prototype = Object.create(UnaryExpression.prototype);
        exports.Complement = Complement;

        function Not(operand, line, col) {
            exports.UnaryExpression.call(this, operand, line, col);
            this.Kind = ExpressionKind.Not;
        }
        Not.prototype = Object.create(UnaryExpression.prototype);
        exports.Not = Not;

        function Minus(operand, line, col) {
            exports.UnaryExpression.call(this, operand, line, col);
            this.Kind = ExpressionKind.Minus;
        }
        Minus.prototype = Object.create(UnaryExpression.prototype);
        exports.Minus = Minus;

        function Plus(operand, line, col) {
            exports.UnaryExpression.call(this, operand, line, col);
            this.Kind = ExpressionKind.Plus;
        }
        Plus.prototype = Object.create(UnaryExpression.prototype);
        exports.Plus = Plus;

        function Addition(left, right, line, col) {
            exports.BinaryExpression.call(this, left, right, line, col);
            this.Kind = ExpressionKind.Addition;
        }
        Addition.prototype = Object.create(BinaryExpression.prototype);
        exports.Addition = Addition;

        function BitwiseAnd(left, right, line, col) {
            exports.BinaryExpression.call(this, left, right, line, col);
            this.Kind = ExpressionKind.BitwiseAnd;
        }
        BitwiseAnd.prototype = Object.create(BinaryExpression.prototype);
        exports.BitwiseAnd = BitwiseAnd;

        function BitwiseOr(left, right, line, col) {
            exports.BinaryExpression.call(this, left, right, line, col);
            this.Kind = ExpressionKind.BitwiseOr;
        }
        BitwiseOr.prototype = Object.create(BinaryExpression.prototype);
        exports.BitwiseOr = BitwiseOr;

        function BitwiseXor(left, right, line, col) {
            exports.BinaryExpression.call(this, left, right, line, col);
            this.Kind = ExpressionKind.BitwiseXor;
        }
        BitwiseXor.prototype = Object.create(BinaryExpression.prototype);
        exports.BitwiseXor = BitwiseXor;

        function Div(left, right, line, col) {
            exports.BinaryExpression.call(this, left, right, line, col);
            this.Kind = ExpressionKind.Div;
        }
        Div.prototype = Object.create(BinaryExpression.prototype);
        exports.Div = Div;

        function Divide(left, right, line, col) {
            exports.BinaryExpression.call(this, left, right, line, col);
            this.Kind = ExpressionKind.Divide;
        }
        Divide.prototype = Object.create(BinaryExpression.prototype);
        exports.Divide = Divide;

        function Equality(left, right, line, col) {
            exports.BinaryExpression.call(this, left, right, line, col);
            this.Kind = ExpressionKind.Equality;
        }
        Equality.prototype = Object.create(BinaryExpression.prototype);
        exports.Equality = Equality;

        function GreaterThan(left, right, line, col) {
            exports.BinaryExpression.call(this, left, right, line, col);
            this.Kind = ExpressionKind.GreaterThan;
        }
        GreaterThan.prototype = Object.create(BinaryExpression.prototype);
        exports.GreaterThan = GreaterThan;

        function GreaterThanOrEqual(left, right, line, col) {
            exports.BinaryExpression.call(this, left, right, line, col);
            this.Kind = ExpressionKind.GreaterThanOrEqual;
        }
        GreaterThanOrEqual.prototype = Object.create(BinaryExpression.prototype);
        exports.GreaterThanOrEqual = GreaterThanOrEqual;

        function LessThan(left, right, line, col) {
            exports.BinaryExpression.call(this, left, right, line, col);
            this.Kind = ExpressionKind.LessThan;
        }
        LessThan.prototype = Object.create(BinaryExpression.prototype);
        exports.LessThan = LessThan;

        function LessThanOrEqual(left, right, line, col) {
            exports.BinaryExpression.call(this, left, right, line, col);
            this.Kind = ExpressionKind.LessThanOrEqual;
        }
        LessThanOrEqual.prototype = Object.create(BinaryExpression.prototype);
        exports.LessThanOrEqual = LessThanOrEqual;

        function LogicalAnd(left, right, line, col) {
            exports.BinaryExpression.call(this, left, right, line, col);
            this.Kind = ExpressionKind.LogicalAnd;
        }
        LogicalAnd.prototype = Object.create(BinaryExpression.prototype);
        exports.LogicalAnd = LogicalAnd;

        function LogicOr(left, right, line, col) {
            exports.BinaryExpression.call(this, left, right, line, col);
            this.Kind = ExpressionKind.LogicOr;
        }
        LogicOr.prototype = Object.create(BinaryExpression.prototype);
        exports.LogicOr = LogicOr;

        function LogicalXor(left, right, line, col) {
            exports.BinaryExpression.call(this, left, right, line, col);
            this.Kind = ExpressionKind.LogicalXor;
        }
        LogicalXor.prototype = Object.create(BinaryExpression.prototype);
        exports.LogicalXor = LogicalXor;

        function Mod(left, right, line, col) {
            exports.BinaryExpression.call(this, left, right, line, col);
            this.Kind = ExpressionKind.Mod;
        }
        Mod.prototype = Object.create(BinaryExpression.prototype);
        exports.Mod = Mod;

        function Multiply(left, right, line, col) {
            exports.BinaryExpression.call(this, left, right, line, col);
            this.Kind = ExpressionKind.Multiply;
        }
        Multiply.prototype = Object.create(BinaryExpression.prototype);
        exports.Multiply = Multiply;

        function NotEqual(left, right, line, col) {
            exports.BinaryExpression.call(this, left, right, line, col);
            this.Kind = ExpressionKind.NotEqual;
        }
        NotEqual.prototype = Object.create(BinaryExpression.prototype);
        exports.NotEqual = NotEqual;

        function ShiftLeft(left, right, line, col) {
            exports.BinaryExpression.call(this, left, right, line, col);
            this.Kind = ExpressionKind.ShiftLeft;
        }
        ShiftLeft.prototype = Object.create(BinaryExpression.prototype);
        exports.ShiftLeft = ShiftLeft;

        function ShiftRight(left, right, line, col) {
            exports.BinaryExpression.call(this, left, right, line, col);
            this.Kind = ExpressionKind.ShiftRight;
        }
        ShiftRight.prototype = Object.create(BinaryExpression.prototype);
        exports.ShiftRight = ShiftRight;

        function Subtraction(left, right, line, col) {
            exports.BinaryExpression.call(this, left, right, line, col);
            this.Kind = ExpressionKind.Subtraction;
        }
        Subtraction.prototype = Object.create(BinaryExpression.prototype);
        exports.Subtraction = Subtraction;

        return Expression;
    })();

    exports.Statement = (function() {
        var StatementKind = enums.StatementKind;

        function Statement(line, col) {
            exports.AstNode.call(this, line, col);
        }
        Statement.prototype = Object.create(exports.AstNode.prototype);
        //Statement.prototype.Optimize = function() {};

        function Nop(line, col) {
            Statement.call(this, line, col);
            this.Kind = StatementKind.Nop;
        }
        Nop.prototype = Object.create(Statement.prototype);
        exports.Nop = Nop;

        // Static field Statement.Nop
        Statement.Nop = new Nop(0, 0);

        function Break(line, col) {
            Statement.call(this, line, col);
            this.Kind = StatementKind.Break;
        }
        Break.prototype = Object.create(Statement.prototype);
        exports.Break = Break;

        function CallStatement(func, exprs, line, col) {
            Statement.call(this, line, col);
            this.Call = new exports.Call(func, exprs, line, col);
            this.Kind = StatementKind.CallStatement;
        }
        CallStatement.prototype = Object.create(Statement.prototype);
        exports.CallStatement = CallStatement;

        function Case(expr, line, col) {
            Statement.call(this, line, col);
            this.Expression = expr;
            this.Kind = StatementKind.Case;
        }
        Case.prototype = Object.create(Statement.prototype);
        exports.Case = Case;

        function Continue(line, col) {
            Statement.call(this, line, col);
            this.Kind = StatementKind.Continue;
        }
        Continue.prototype = Object.create(Statement.prototype);
        exports.Continue = Continue;

        function Default(line, col) {
            Statement.call(this, line, col);
            this.Kind = StatementKind.Default;
        }
        Default.prototype = Object.create(Statement.prototype);
        exports.Default = Default;

        function Do(s, e, line, col) {
            Statement.call(this, line, col);
            this.Body = s;
            this.Expression = e;
            this.Kind = StatementKind.Do;
        }
        Do.prototype = Object.create(Statement.prototype);
        exports.Do = Do;

        function Exit(line, col) {
            Statement.call(this, line, col);
            this.Kind = StatementKind.Exit;
        }
        Exit.prototype = Object.create(Statement.prototype);
        exports.Exit = Exit;

        function For(init, test, iterator, body, line, col) {
            Statement.call(this, line, col);
            this.Initializer = init;
            this.Test = test;
            this.Iterator = iterator;
            this.Body = body;
            this.Kind = StatementKind.For;
        }
        For.prototype = Object.create(Statement.prototype);
        exports.For = For;

        function Globalvar(v, line, col) {
            Statement.call(this, line, col);
            this.Variables = v;
            this.Kind = StatementKind.Globalvar;
        }
        Globalvar.prototype = Object.create(Statement.prototype);
        exports.Globalvar = Globalvar;

        function If(e, s, f, line, col) {
            Statement.call(this, line, col);
            this.Expression = e;
            this.Body = s;
            this.Else = f;
            this.Kind = StatementKind.If;
        }
        If.prototype = Object.create(Statement.prototype);
        exports.If = If;

        // Shortcut to create if with no else statement
        exports.IfNoElse = function(e, s, line, col) {
            return new If(e, s, Statement.Nop, line, col);
        };

        function Repeat(e, b, line, col) {
            Statement.call(this, line, col);
            this.Expression = e;
            this.Body = b;
            this.Kind = StatementKind.Repeat;
        }
        Repeat.prototype = Object.create(Statement.prototype);
        exports.Repeat = Repeat;

        function Return(e, line, col) {
            Statement.call(this, line, col);
            this.Expression = e;
            this.Kind = StatementKind.Return;
        }
        Return.prototype = Object.create(Statement.prototype);
        exports.Return = Return;

        function Sequence(s1, s2, line, col) {
            Statement.call(this, line, col);
            this.First = s1;
            this.Second = s2;
            this.Kind = StatementKind.Sequence;
        }
        Sequence.prototype = Object.create(Statement.prototype);
        exports.Sequence = Sequence;

        function Switch(x, y, line, col) {
            Statement.call(this, line, col);
            this.Expression = x;
            this.Statements = y;
            this.Kind = StatementKind.Switch;
        }
        Switch.prototype = Object.create(Statement.prototype);
        exports.Switch = Switch;

        function Var(v, line, col) {
            Statement.call(this, line, col);
            this.Variables = v;
            this.Kind = StatementKind.Var;
        }
        Var.prototype = Object.create(Statement.prototype);
        exports.Var = Var;

        function While(e, s, line, col) {
            Statement.call(this, line, col);
            this.Expression = e;
            this.Body = s;
            this.Kind = StatementKind.While;
        }
        While.prototype = Object.create(Statement.prototype);
        exports.While = While;

        function With(e, s, line, col) {
            Statement.call(this, line, col);
            this.Instance = e;
            this.Body = s;
            this.Kind = StatementKind.With;
        }
        With.prototype = Object.create(Statement.prototype);
        exports.With = With;

        function Assignment(access, expression, line, col) {
            Statement.call(this, line, col);
            this.Lefthand = access;
            this.Expression = expression;
            this.Kind = StatementKind.Assignment;
        }
        Assignment.prototype = Object.create(Statement.prototype);
        exports.Assignment = Assignment;

        function AdditionAssignment(a, e, l, c) {
            Assignment.call(this, a, e, l, c);
            this.Kind = StatementKind.AdditionAssignment;
        }
        AdditionAssignment.prototype = Object.create(Assignment.prototype);
        exports.AdditionAssignment = AdditionAssignment;

        function AndAssignment(a, e, l, c) {
            Assignment.call(this, a, e, l, c);
            this.Kind = StatementKind.AndAssignment;
        }
        AndAssignment.prototype = Object.create(Assignment.prototype);
        exports.AndAssignment = AndAssignment;

        function DivideAssignment(a, e, l, c) {
            Assignment.call(this, a, e, l, c);
            this.Kind = StatementKind.DivideAssignment;
        }
        DivideAssignment.prototype = Object.create(Assignment.prototype);
        exports.DivideAssignment = DivideAssignment;

        function MultiplyAssignment(a, e, l, c) {
            Assignment.call(this, a, e, l, c);
            this.Kind = StatementKind.MultiplyAssignment;
        }
        MultiplyAssignment.prototype = Object.create(Assignment.prototype);
        exports.MultiplyAssignment = MultiplyAssignment;

        function OrAssignment(a, e, l, c) {
            Assignment.call(this, a, e, l, c);
            this.Kind = StatementKind.OrAssignment;
        }
        OrAssignment.prototype = Object.create(Assignment.prototype);
        exports.OrAssignment = OrAssignment;

        function SubtractionAssignment(a, e, l, c) {
            Assignment.call(this, a, e, l, c);
            this.Kind = StatementKind.SubtractionAssignment;
        }
        SubtractionAssignment.prototype = Object.create(Assignment.prototype);
        exports.SubtractionAssignment = SubtractionAssignment;

        function XorAssignment(a, e, l, c) {
            Assignment.call(this, a, e, l, c);
            this.Kind = StatementKind.XorAssignment;
        }
        XorAssignment.prototype = Object.create(Assignment.prototype);
        exports.XorAssignment = XorAssignment;

        return Statement;
    })();

    exports.Parser = (function() {
        var Access = exports.Access,
            Addition = exports.Addition,
            BitwiseAnd = exports.BitwiseAnd,
            BitwiseOr = exports.BitwiseOr,
            BitwiseXor = exports.BitwiseXor,
            Call = exports.Call,
            Complement = exports.Complement,
            Constant = exports.Constant,
            Div = exports.Div,
            Divide = exports.Divide,
            Equality = exports.Equality,
            GreaterThan = exports.GreaterThan,
            GreaterThanOrEqual = exports.GreaterThanOrEqual,
            Grouping = exports.Grouping,
            Id = exports.Id,
            LessThan = exports.LessThan,
            LessThanOrEqual = exports.LessThanOrEqual,
            LogicalAnd = exports.LogicalAnd,
            LogicOr = exports.LogicOr,
            LogicalXor = exports.LogicalXor,
            Minus = exports.Minus,
            Mod = exports.Mod,
            Multiply = exports.Multiply,
            Not = exports.Not,
            NotEqual = exports.NotEqual,
            Plus = exports.Plus,
            ShiftLeft = exports.ShiftLeft,
            ShiftRight = exports.ShiftRight,
            Subtraction = exports.Subtraction,
            AdditionAssignment = exports.AdditionAssignment,
            AndAssignment = exports.AndAssignment,
            Assignment = exports.Assignment,
            Break = exports.Break,
            CallStatement = exports.CallStatement,
            Case = exports.Case,
            Continue = exports.Continue,
            Default = exports.Default,
            DivideAssignment = exports.DivideAssignment,
            Do = exports.Do,
            Exit = exports.Exit,
            For = exports.For,
            Globalvar = exports.Globalvar,
            If = exports.If,
            MultiplyAssignment = exports.MultiplyAssignment,
            Nop = exports.Nop,
            OrAssignment = exports.OrAssignment,
            Repeat = exports.Repeat,
            Return = exports.Return,
            Sequence = exports.Sequence,
            SubtractionAssignment = exports.SubtractionAssignment,
            Switch = exports.Switch,
            Var = exports.Var,
            While = exports.While,
            With = exports.With,
            XorAssignment = exports.XorAssignment,
            Error = errors.Error,
            TokenKind = enums.TokenKind,
            Statement = exports.Statement;


        function Parser(context, l) {
            var self = this;

            this.Context = context;
            this.Lexer = l;
            var next, t, Current;

            this.Parse = function()
            {
                var s;
                move();
                if (t.t == TokenKind.OpeningCurlyBrace)
                {
                    s = block(); if (t != TokenKind.Eof) error(Error.ProgramEnds);
                    return s;
                }
                s = Statement.Nop;
                while (t.t != TokenKind.Eof)
                {
                    s = new Sequence(s, stmt(), next.line, next.col); // stmt() throws ProgramError
                }

                Current = s;
                return s;
            }
            function move()
            {
                next = l.Scan();
                t = next;
            }

            function error(err)
            {
                //throw new ProgramError(err, next.line, next.col);
            }

            function error(err, obj)
            {
                //throw new ProgramError(err, obj, next.line, next.col);
            }

            function match(tok)
            {
                match(tok, Error.SymbolExpected);
            }

            function match(ter, err)
            {
                if (next == ter.t)
                    move();
                else
                    ;//throw new ProgramError(err, ter.ToString(), next.line, next.col);
            }

            function peek()
            {
                var tok = l.Scan();
                l.PutBack(tok);
                return tok;
            }
            
            this.ParseExpression = function()
            {
                move();
                if (t.t == TokenKind.Eof)
                    return new Constant(0, 0, 0);

                var e = expr();
                if (t != TokenKind.Eof) error(Error.UnexpectedSymbol);
                Current = e;
                return e;
            }

            function expr()
            {
                var temp = next;
                var x = rel();
                while (true)
                {
                    switch (t.t)
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

            function rel()
            {
                var temp = next;
                var x = bitwise();
                while (true)
                {
                    switch (t.t)
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

            function bitwise()
            {
                var temp = next;
                var x = shift();
                while (true)
                {
                    switch (t.t)
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

            function shift()
            {
                var temp = next;
                var x = add();
                while (true)
                {
                    switch (t.t)
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

            function add()
            {
                var temp = next;
                var x = term();
                while (true)
                {
                    switch (t.t)
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

            function term()
            {
                var temp = next;
                var x = unary();
                while (true)
                {
                    switch (t.t)
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

            function unary()
            {
                var temp = next;
                while (true)
                {
                    switch (t.t)
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

            function access()
            {
                var temp = next;
                var x = factor();
                if (x.Kind == TokenKind.Id)
                {
                    //var val = Context.Resources.GetNamedValue(x.ToString());
                    //if (!val.IsNull)
                    //    x = val.IsReal ? new Constant(val.Real, temp.line, temp.col) : new Constant(val.String, temp.line, temp.col);
                    //else
                        x = new Access(null, x.ToString(), subscript(), temp.line, temp.col);
                }
                while (t.t == TokenKind.Dot)
                {
                    move();
                    if (t != TokenKind.Identifier) // || !Context.Resources.GetNamedValue(x.ToString()).IsNull) // Save this for later
                        error(Error.ExpectedVariableName);
                    var n = next.lexeme;
                    move();
                    x = new Access(x, n, subscript(), temp.line, temp.col);
                }
                return x;
            }

            function subscript()
            {
                if (t != TokenKind.OpeningSquareBracket) return new Expression[0];
                move();
                var indices = [];
                while (t != TokenKind.ClosingSquareBracket)
                {
                    indices.push(expr());
                    if (t.t == TokenKind.Comma) move();
                    else if (t != TokenKind.ClosingSquareBracket)
                        error(Error.ArraySymbol);
                }
                move();
                if (indices.length > 2) error(Error.ArrayDegree);
                return indices;
            }

            function factor()
            {
                var e;
                var temp = next;
                switch (t.t)
                {
                    case TokenKind.Real:
                        e = new Constant(next.value, next.line, next.col);
                        move();
                        return e;
                    case TokenKind.StringLiteral:
                        e = new Constant(next.value, next.line, next.col);
                        move();
                        return e;
                    case TokenKind.Identifier:
                        if (peek().t == TokenKind.OpeningParenthesis)
                        {
                            var str = next.lexeme;
                            //if (!Context.Resources.FunctionExists(str))
                            //{
                            //    error(Error.UnknownFunction, str);
                            //}
                            move(); move();
                            var exprs = [];
                            if (t != TokenKind.ClosingParenthesis && t != TokenKind.Eof)
                            {
                                exprs.push(expr());
                            }
                            while (t.t == TokenKind.Comma)
                            {
                                move();
                                exprs.push(expr());
                            }
                            match(Token.ClosingParenthesis);
                            var f = null; //Context.Resources.GetFunction(str);
                            //if ((f.Argc != -1 && exprs.length != f.Argc) || exprs.Count > 16)
                            //    error(Error.WrongArgumentNumber);
                            return new Call(f, exprs, temp.line, temp.col);
                        }
                        else
                        {
                            var x = new Id(next.lexeme, next.line, next.col);
                            move();
                            return x;
                        }
                    case TokenKind.OpeningParenthesis:
                        move();
                        e = new Grouping(expr(), next.line, next.col);
                        match(Token.ClosingParenthesis, Error.UnexpectedSymbolInExpression);
                        return e;
                    default:
                        //throw new ProgramError(Error.UnexpectedSymbolInExpression, ErrorSeverity.CompilationError, next.line, next.col);
                        break;
                }
            }

            function block()
            {
                var s = Statement.Nop;
                var l = next.line;
                var c = next.col;
                match(Token.OpeningCurlyBrace);
                while (t != TokenKind.ClosingCurlyBrace && t != TokenKind.Eof)
                {
                    s = new Sequence(s, stmt(), l, c);
                }
                match(Token.ClosingCurlyBrace);
                while (t.t == TokenKind.Semicolon) move();
                return s;
            }

            function assign()
            {
                var l = next.line;
                var c = next.col;
                var e = access();
                //if (e.Kind != TokenKind.Access)
                //    error(Error.ExpectedVariableName);
                var a = e;
                switch (t.t)
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
                        //throw new ProgramError(Error.ExpectedAssignmentOperator, ErrorSeverity.CompilationError, l, c);
                        break;
                }
            }

            function tstmt()
            {
                var l = next.line;
                var c = next.col;
                var s, s1, s2;
                var e;
                if (t.t == TokenKind.OpeningCurlyBrace)
                    return block();
                else if (t.t == TokenKind.If)
                {
                    move(); e = expr(); if (t.t == TokenKind.Then) move(); s = stmt();
                    if (t.t == TokenKind.Else)
                    {
                        move();
                        return new If(e, s, stmt(), l, c);
                    }
                    return IfNoElse(e, s, l, c);
                }
                else if (t.t == TokenKind.While)
                {
                    move(); e = expr(); if (t.t == TokenKind.Do) move(); return new While(e, stmt(), l, c);
                }
                else if (t.t == TokenKind.Do)
                {
                    move();
                    s = stmt();
                    match(Token.Until, Error.ExpectedUntil);
                    return new Do(s, expr(), l, c);
                }
                else if (t.t == TokenKind.For)
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
                else if (t.t == TokenKind.Break)
                {
                    move();
                    return new Break(l, c);
                }
                else if (t.t == TokenKind.Continue)
                {
                    move();
                    return new Continue(l, c);
                }
                else if (t.t == TokenKind.Exit)
                {
                    move();
                    return new Exit(l, c);
                }
                else if (t.t == TokenKind.Return)
                {
                    move();
                    return new Return(expr(), l, c);
                }
                else if (t.t == TokenKind.Repeat)
                {
                    move();
                    return new Repeat(expr(), stmt(), l, c);
                }
                else if (t.t == TokenKind.Var)
                {
                    move();
                    var strs = [];
                    while (t.t == TokenKind.Identifier)
                    {
                        if (peek().t == TokenKind.OpeningParenthesis) break;
                        //if (Context.IsBuiltIn(next.lexeme)) error(Error.BuiltinVariable);
                        strs.push(next.lexeme);
                        move();
                        if (t.t == TokenKind.Comma) move();
                    }
                    return new Var(strs, l, c);
                }
                else if (t.t == TokenKind.Globalvar)
                {
                    move();
                    var strs = [];
                    while (t.t == TokenKind.Identifier)
                    {
                        if (peek().t == TokenKind.OpeningParenthesis) break;
                        //if (Context.IsBuiltIn(next.lexeme)) error(Error.BuiltinVariable);
                        strs.push(next.lexeme);
                        move();
                        if (t.t == TokenKind.Comma) move();
                    }
                    return new Globalvar(strs, l, c);
                }
                else if (t.t == TokenKind.With)
                {
                    move();
                    e = expr();
                    if (t.t == TokenKind.Do) move();
                    return new With(e, stmt(), l, c);
                }
                else if (t.t == TokenKind.Default)
                {
                    move();
                    match(Token.Colon);
                    return new Default(l, c);
                }
                else if (t.t == TokenKind.Case)
                {
                    move();
                    var _case = new Case(expr(), l, c);
                    match(Token.Colon);
                    return _case;
                }
                else if (t.t == TokenKind.Switch)
                {
                    move();
                    e = expr();
                    match(Token.OpeningCurlyBrace);
                    var lst = [];
                    while (t.t != TokenKind.ClosingCurlyBrace && t.t != TokenKind.Eof)
                    {
                        lst.push(stmt());
                        while (t.t == TokenKind.Semicolon) move();
                    }
                    match(Token.ClosingCurlyBrace);
                    return new Switch(e, lst, l, c);
                }
                else if (t.t == TokenKind.Identifier)
                {
                    if (peek().t == TokenKind.OpeningParenthesis)
                    {
                        var str = next.lexeme;
                        //if (!Context.Resources.FunctionExists(str))
                        //{
                        //    error(Error.UnknownFunction, str);
                        //}
                        move(); move();
                        var exprs = [];
                        if (t.t != TokenKind.ClosingParenthesis && t.t != TokenKind.Eof)
                        {
                            exprs.push(expr());
                        }
                        while (t.t == TokenKind.Comma)
                        {
                            move();
                            exprs.push(expr());
                        }
                        match(Token.ClosingParenthesis);
                        var f = null; //Context.Resources.GetFunction(str);
                        //if ((f.Argc != -1 && exprs.Count != f.Argc) || exprs.Count > 16)
                        //    error(Error.WrongArgumentNumber);
                        return new CallStatement(f, exprs, l, c);
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
            function stmt()
            {
                var s = tstmt();
                while (t.t == TokenKind.Semicolon) move();
                return s;
            }
        }

        return Parser;
    })();
})();