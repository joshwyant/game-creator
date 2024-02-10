var visitor = require('./NodeVisitor.js');
var lex = require('./Lexer.js');
var parse = require('./Parser.js');

exports.Compiler = (function() {
    function Compiler(runtime) {
        var self = this,
            emitter = new CompileUnitBuilder();

        this.Compile = function(text) {
            var reader = new lex.TextReader(text),
                lexer = new lex.Lexer(reader),
                parser = new parse.Parser(runtime.Context, lexer),
                visitor = new Visitor(emitter);

            var tree = parser.Parse();
            emitter.begin();
            visitor.VisitNode(tree);
            emitter.end();
            return emitter.getCompileUnit();
        };
    }

    function static() {
        
    }

    function CompileUnitBuilder() {
        var self = this;

        var output = [];
        this.getCompileUnit = function() {
            var initDelegate = eval(self.output.join(""));
            var delegate = initDelegate(runtime);

            return {
                delegate: delegate
            };
        };
        this.begin = function() {
            self.emit("function(runtime) {return function() { runtime.pushEnv(); "
                );
        }
        this.emit = function (code) {
            output.push(code);
        };
        this.end = function() {
            self.emit("runtime.popEnv();};}");
        }
    }

    function Visitor(emitter) {
        var self = this;

        visitor.NodeVisitor.call(this);

        var nextvar = 0;
        var newvar = function() {
            return "$"+(nextvar++).toString();
        };

        // Expression visitors

        this.VisitBinaryExpression = function(binaryExpression) {

            if (binaryExpression instanceof parse.Div) {
                emitter.emit("Math.floor(runtime.requireNumber(");
                self.VisitExpression(binaryExpression.Left);
                emitter.emit(")/runtime.requireNumber(");
                self.VisitExpression(binaryExpression.Right);
                emitter.emit("))");
            } else if (binaryExpression instanceof parse.LogicalXor) {
                emitter.emit("(runtime.requireNumber(");
                self.VisitExpression(binaryExpression.Left);
                emitter.emit(")?1:0)^(runtime.requireNumber(");
                self.VisitExpression(binaryExpression.Right);
                emitter.emit(")?1:0)");
            } else {
                var op;
                var requireNumber = true;
                if (binaryExpression instanceof parse.Addition) { op = "+"; requireNumber = false; }
                else if (binaryExpression instanceof parse.BitwiseAnd) op = "&";
                else if (binaryExpression instanceof parse.BitwiseOr) op = "|";
                else if (binaryExpression instanceof parse.BitwiseXor) op = "^";
                else if (binaryExpression instanceof parse.Divide) op = "/";
                else if (binaryExpression instanceof parse.Equality) { op = "=="; requireNumber = false; }
                else if (binaryExpression instanceof parse.GreaterThan) { op = ">"; requireNumber = false; }
                else if (binaryExpression instanceof parse.GreaterThanOrEqual) { op = ">="; requireNumber = false; }
                else if (binaryExpression instanceof parse.LessThan) { op = "<"; requireNumber = false; }
                else if (binaryExpression instanceof parse.LessThanOrEqual) { op = "<="; requireNumber = false; }
                else if (binaryExpression instanceof parse.LogicalAnd) op = "&&";
                else if (binaryExpression instanceof parse.LogicalOr) op = "||";
                else if (binaryExpression instanceof parse.Mod) op = "%";
                else if (binaryExpression instanceof parse.Multiply) op = "*";
                else if (binaryExpression instanceof parse.NotEqual) { op = "!="; requireNumber = false; }
                else if (binaryExpression instanceof parse.ShiftLeft) op = "<<";
                else if (binaryExpression instanceof parse.ShiftRight) op = ">>";
                else if (binaryExpression instanceof parse.Subtraction) op = "-";
                emitter.emit(requireNumber ? "(runtime.requireNumber(" : "((");
                self.VisitExpression(binaryExpression.Left);
                emitter.emit(")");
                emitter.emit(op);
                emitter.emit(requireNumber ? "runtime.requireNumber(" : "(");
                self.VisitExpression(binaryExpression.Right);
                emitter.emit("))");
            }
        };

        this.VisitConstant = function(constant) {
            if (typeof constant.Value === 'string') {
                emitter.emit("\"");
                emitter.emit(constant.Value.replace(/"/g, '\\"'));
                emitter.emit("\"");
            } else {
                emitter.emit(constant.Value.toString());
            }
        };

        this.VisitUnary = function(unaryExpression) {
            var op;
            if (binaryExpression instanceof parse.Plus) op = "+";
            else if (binaryExpression instanceof parse.Minus) op = "-";
            else if (binaryExpression instanceof parse.Not) op = "!";
            else if (binaryExpression instanceof parse.Complement) op = "~";
            emitter.emit(op);
            emitter.emit("runtime.requireNumber(");
            self.VisitExpression(binaryExpression.Operand);
            emitter.emit(")");
        };

        this.VisitCall = function(call) {
            emitter.emit("runtime.AllDelegates.");
            emitter.emit(call.Function.Name);
            emitter.emit("(");
            for (var i = 0; i < call.Expressions.length; i++) {
                if (i != 0)
                    emitter.emit(",");
                self.VisitExpression(call.Expressions[i]);
            }
            emitter.emit(")");
        };

        this.VisitAccess = function(access) {
            emitter.emit("runtime.getInstance(");
            if (access.Instance === null)
                emitter.emit("null");
            else
                self.VisitExpression(access.Instance);
            emitter.emit(").");
            emitter.emit(access.Name);
            for (var i = 0; i < access.Expressions.length; i++) {
                emitter.emit("[");
                self.VisitExpression();
                emitter.emit("]");
            }
        };

        this.VisitGrouping = function(expression) {
            emitter.emit("(");
            emitter.VisitExpression(expression.InnerExpression);
            emitter.emit(")");
        };

        // Statement Visitors
        this.VisitWith = function(_with) {
            emitter.emit("runtime.pushEnv(runtime.getInstance(");
            self.VisitExpression(_with.Instance);
            emitter.emit("));");
            emitter.VisitStatement(_with.Body);
            emitter.emit("runtime.popEnv();");
        };

        this.VisitWhile = function(p) {
            emitter.emit("while (");
            self.VisitExpression(p.Expression);
            emitter.emit(") {");
            self.VisitStatement(p.Body);
            emitter.emit("}");
        };

        this.VisitVar = function(_var) {
            //
        };

        this.VisitSwitch = function(p) {
            emitter.emit("switch (");
            self.VisitExpression(p.Expression);
            emitter.emit(") {");
            for (var i = 0; i < p.Statements.length; i++) {
                self.VisitStatement(p.Statements[i]);
            }
            emitter.emit("}");
        };

        this.VisitReturn = function(p) {
            emitter.emit("return ");
            self.VisitExpression(p.Expression);
            emitter.emit(";");
        };

        this.VisitRepeat = function(repeat) {
            var v = newvar();
            emitter.emit("for (var "+v+" = 0; "+v+" < ");
            self.VisitExpression(repeat.Expression);
            emitter.emit("; v++) {");
            self.VisitStatement(repeat.Body);
            emitter.emit("}");
        };

        this.VisitNop = function(nop) {
            emitter.emit(";");
        };

        this.VisitIf = function(p) {
            emitter.emit("if (");
            self.VisitExpression(p.Expression);
            emitter.emit(") {");
            self.VisitStatement(p.Body);
            emitter.emit("} else {");
            self.VisitStatement(p.Else);
            emitter.emit("}");
        };

        this.VisitGlobalvar = function(globalvar) {
            //
        };

        this.VisitFor = function(p) {
            // Initializer, Test, Iterator, Body
            self.VisitStatement(p.Initializer);
            emitter.emit("while (");
            self.VisitExpression(p.Test);
            emitter.emit(") {");
            self.VisitStatement(p.Body);
            self.VisitStatement(p.Iterator);
            emitter.emit("}");
        };

        this.VisitExit = function(exit) {
            emitter.emit("return;");
        };

        this.VisitDo = function(p) {
            emitter.emit("do {");
            self.VisitExpression(p.Expression);
            emitter.emit("} while (");
            self.VisitStatement(p.Body);
            emitter.emit("};");
        };

        this.VisitDefaultCaseLabel = function(p) {
            emitter.emit("default:");
        };

        this.VisitContinue = function(p) {
            emitter.emit("continue;");
        };

        this.VisitCaseLabel = function(p) {
            emitter.emit("case ");
            self.VisitExpression(p.Expression);
            emitter.emit(":");
        };

        this.VisitCallStatement = function(callStatement) {
            emitter.emit("runtime.AllDelegates.");
            emitter.emit(callStatement.Call.Function.Name);
            emitter.emit("(");
            for (var i = 0; i < callStatement.Call.Expressions.length; i++) {
                if (i != 0)
                    emitter.emit(",");
                self.VisitExpression(callStatement.Call.Expressions[i]);
            }
            emitter.emit(");");
        };

        this.VisitBreak = function(p) {
            emitter.emit("break;");
        };

        this.VisitAssignment = function(assignment) {
            var op, xor = false;
            if (assignment instanceof parse.AdditionAssignment) op = "+";
            else if (assignment instanceof parse.AndAssignment) op = "&&";
            else if (assignment instanceof parse.DivideAssignment) op = "/";
            else if (assignment instanceof parse.OrAssignment) op = "||";
            else if (assignment instanceof parse.MultiplyAssignment) op = "*";
            else if (assignment instanceof parse.SubtractionAssignment) op = "*";
            else if (assignment instanceof parse.XorAssignment) xor = true;

            var access = assignment.Lefthand;

            var v = newvar();

            emitter.emit("var "+v+" = runtime.getInstance(");
            if (access.Instance === null || access.Instance === undefined)
                emitter.emit("null");
            else
                self.VisitExpression(access.Instance);
            emitter.emit("); "+v+".");
            emitter.emit(access.Name);
            if (access.Expressions) {
                for (var i = 0; i < access.Expressions.length; i++) {
                    emitter.emit("[");
                    self.VisitExpression();
                    emitter.emit("]");
                }
            }
            if (typeof assignment === "Assignment") {
                emitter.emit(" = ");
            } else {
                if (xor)
                    emitter.emit(" = (("+v+"."+access.Name+"?1:0) ^ (");
                else
                    emitter.emit(" = "+v+"."+access.Name+" "+op+" ");
            }
            self.VisitExpression(assignment.Expression);
            if (xor)
                emitter.emit("?1:0));");
            else
                emitter.emit(";");
        };
    }
    Visitor.prototype = Object.create(visitor.NodeVisitor.prototype);

    static();

    return Compiler;
})();