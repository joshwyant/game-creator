var enums = require('./ParseEnums.js');
var parse = require('./Parser.js');

exports.NodeVisitor = function () {
    var self = this;

    var ExpressionKind = enums.ExpressionKind,
        StatementKind = enums.StatementKind,
        Access = parse.Access,
        Addition = parse.Addition,
        BitwiseAnd = parse.BitwiseAnd,
        BitwiseOr = parse.BitwiseOr,
        BitwiseXor = parse.BitwiseXor,
        Call = parse.Call,
        Complement = parse.Complement,
        Constant = parse.Constant,
        Div = parse.Div,
        Divide = parse.Divide,
        Equality = parse.Equality,
        GreaterThan = parse.GreaterThan,
        GreaterThanOrEqual = parse.GreaterThanOrEqual,
        Grouping = parse.Grouping,
        Id = parse.Id,
        LessThan = parse.LessThan,
        LessThanOrEqual = parse.LessThanOrEqual,
        LogicalAnd = parse.LogicalAnd,
        LogicOr = parse.LogicOr,
        LogicalXor = parse.LogicalXor,
        Minus = parse.Minus,
        Mod = parse.Mod,
        Multiply = parse.Multiply,
        Not = parse.Not,
        NotEqual = parse.NotEqual,
        Plus = parse.Plus,
        ShiftLeft = parse.ShiftLeft,
        ShiftRight = parse.ShiftRight,
        Subtraction = parse.Subtraction,
        AdditionAssignment = parse.AdditionAssignment,
        AndAssignment = parse.AndAssignment,
        Assignment = parse.Assignment,
        Break = parse.Break,
        CallStatement = parse.CallStatement,
        Case = parse.Case,
        Continue = parse.Continue,
        Default = parse.Default,
        DivideAssignment = parse.DivideAssignment,
        Do = parse.Do,
        Exit = parse.Exit,
        For = parse.For,
        Globalvar = parse.Globalvar,
        If = parse.If,
        MultiplyAssignment = parse.MultiplyAssignment,
        Nop = parse.Nop,
        OrAssignment = parse.OrAssignment,
        Repeat = parse.Repeat,
        Return = parse.Return,
        Sequence = parse.Sequence,
        SubtractionAssignment = parse.SubtractionAssignment,
        Switch = parse.Switch,
        Var = parse.Var,
        While = parse.While,
        With = parse.With,
        Statement = parse.Statement;

    // Main Traversal
    this.VisitNode = function(node) {
        if (node instanceof Statement)
            self.VisitStatement(node);
        else
            self.VisitExpression(node);
    }

    this.VisitExpression = function(e) {
        switch (e.Kind)
        {
            case ExpressionKind.Addition:
            case ExpressionKind.BitwiseAnd:
            case ExpressionKind.BitwiseOr:
            case ExpressionKind.BitwiseXor:
            case ExpressionKind.Div:
            case ExpressionKind.Divide:
            case ExpressionKind.Equality:
            case ExpressionKind.GreaterThan:
            case ExpressionKind.GreaterThanOrEqual:
            case ExpressionKind.LessThan:
            case ExpressionKind.LessThanOrEqual:
            case ExpressionKind.LogicalAnd:
            case ExpressionKind.LogicalOr:
            case ExpressionKind.LogicalXor:
            case ExpressionKind.Mod:
            case ExpressionKind.Multiply:
            case ExpressionKind.NotEqual:
            case ExpressionKind.ShiftLeft:
            case ExpressionKind.ShiftRight:
            case ExpressionKind.Subtraction:
                self.VisitBinaryExpression(e);
                break;
            case ExpressionKind.Complement:
            case ExpressionKind.Minus:
            case ExpressionKind.Not:
            case ExpressionKind.Plus:
                self.VisitUnary(e);
                break;
            case ExpressionKind.Access:
                self.VisitAccess(e);
                break;
            case ExpressionKind.Call:
                self.VisitCall(e);
                break;
            case ExpressionKind.Constant:
                self.VisitConstant(e);
                break;
            case ExpressionKind.Grouping:
                self.VisitGrouping(e);
                break;
            case ExpressionKind.None:
            case ExpressionKind.Id:
                throw new Error();
        }
    }

    this.VisitStatement = function(s) {
        switch (s.Kind)
        {
            case StatementKind.AdditionAssignment:
            case StatementKind.AndAssignment:
            case StatementKind.Assignment:
            case StatementKind.DivideAssignment:
            case StatementKind.MultiplyAssignment:
            case StatementKind.OrAssignment:
            case StatementKind.SubtractionAssignment:
            case StatementKind.XorAssignment:
                self.VisitAssignment(s);
                break;
            case StatementKind.Break:
                self.VisitBreak(s);
                break;
            case StatementKind.Call:
                self.VisitCallStatement(s);
                break;
            case StatementKind.Case:
                self.VisitCaseLabel(s);
                break;
            case StatementKind.Continue:
                self.VisitContinue(s);
                break;
            case StatementKind.Default:
                self.VisitDefaultCaseLabel(s);
                break;
            case StatementKind.Do:
                self.VisitDo(s);
                break;
            case StatementKind.Exit:
                self.VisitExit(s);
                break;
            case StatementKind.For:
                self.VisitFor(s);
                break;
            case StatementKind.Globalvar:
                self.VisitGlobalvar(s);
                break;
            case StatementKind.If:
                self.VisitIf(s);
                break;
            case StatementKind.Nop:
                self.VisitNop(s);
                break;
            case StatementKind.Repeat:
                self.VisitRepeat(s);
                break;
            case StatementKind.Return:
                self.VisitReturn(s);
                break;
            case StatementKind.Sequence:
                self.VisitSequence(s);
                break;
            case StatementKind.Switch:
                self.VisitSwitch(s);
                break;
            case StatementKind.Var:
                self.VisitVar(s);
                break;
            case StatementKind.While:
                self.VisitWhile(s);
                break;
            case StatementKind.With:
                self.VisitWith(s);
                break;
        }
    }

    /*
     * The following are abstract functions. Copy-paste them to use them in your implementation.
     */

    // Abstract expression visitors

    this.VisitBinaryExpression = function(binaryExpression) {

    };

    this.VisitConstant = function(constant) {

    };

    this.VisitUnary = function(unaryExpression) {

    };

    this.VisitCall = function(call) {

    };

    this.VisitAccess = function(access) {

    };

    this.VisitGrouping = function(expression) {

    };

    // Abstract Statement Visitors
    this.VisitWith = function(_with) {

    };

    this.VisitWhile = function(p) {

    };

    this.VisitVar = function(_var) {

    };

    this.VisitSwitch = function(p) {

    };

    this.VisitSequence = function(sequence) {
        self.VisitNode(sequence.First);
        self.VisitNode(sequence.Second);
    };

    this.VisitReturn = function(p) {

    };

    this.VisitRepeat = function(repeat) {

    };

    this.VisitNop = function(nop) {

    };

    this.VisitIf = function(p) {

    };

    this.VisitGlobalvar = function(globalvar) {

    };

    this.VisitFor = function(p) {

    };

    this.VisitExit = function(exit) {

    };

    this.VisitDo = function(p) {

    };

    this.VisitDefaultCaseLabel = function(p) {

    };

    this.VisitContinue = function(p) {

    };

    this.VisitCaseLabel = function(p) {

    };

    this.VisitCallStatement = function(callStatement) {

    };

    this.VisitBreak = function(p) {

    };

    this.VisitAssignment = function(assignment) {

    };
};
