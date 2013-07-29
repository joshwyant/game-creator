using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Linq.Expressions;

namespace JavaScriptBuilder.Expressions
{
    public partial class Js
    {
        public static JsBinary Binary(Js left, Js right, string op) { return new JsBinary(left, right, op); }
        public static JsBinary Binary(Expression<Func<JsObject, JsObject, JsObject>> lambda) { return new JsExpressionVisitor(lambda).ToBinary(); }
        public static JsBinary Plus(Js left, Js right) { return new JsBinary(left, right, "+"); }
        public static JsBinary Minus(Js left, Js right) { return new JsBinary(left, right, "-"); }
        public static JsBinary Multiply(Js left, Js right) { return new JsBinary(left, right, "*"); }
        public static JsBinary Divide(Js left, Js right) { return new JsBinary(left, right, "/"); }
        public static JsBinary Assign(Js left, Js right) { return new JsBinary(left, right, "="); }
        public static JsBinary AddAssign(Js left, Js right) { return new JsAssignment(left, right, "+="); }
        public static JsBinary SubtractAssign(Js left, Js right) { return new JsAssignment(left, right, "-="); }
        public static JsBinary MultiplyAssign(Js left, Js right) { return new JsAssignment(left, right, "*="); }
        public static JsBinary DivideAssign(Js left, Js right) { return new JsAssignment(left, right, "/="); }
        public static JsBinary Equality(Js left, Js right) { return new JsBinary(left, right, "=="); }
        public static JsBinary Inequality(Js left, Js right) { return new JsBinary(left, right, "!="); }
        public static JsBinary Identity(Js left, Js right) { return new JsBinary(left, right, "==="); }
        public static JsBinary NotIdentity(Js left, Js right) { return new JsBinary(left, right, "!=="); }
        public static JsKeywordBinary InstanceOf(Js left, Js right) { return new JsKeywordBinary(left, right, "instanceof"); }
        public static JsBlock Block(params Js[] body) { return new JsBlock(body); }
        public static JsFunction Function(string name, IEnumerable<Js> body, params string[] parameters) { return new JsFunction(name, body, parameters); }
        public static JsFunction Function(IEnumerable<Js> body, params string[] parameters) { return new JsFunction(null, body, parameters); }
        public static JsFunction Function<T>(Expression<T> lambda) { return new JsExpressionVisitor(lambda).ToJavaScript() as JsFunction; }
        public static JsFunction Function<T1, T2>(Expression<Func<T1, T2>> lambda) { return new JsExpressionVisitor(lambda).ToJavaScript() as JsFunction; }
        public static JsFunction Function<T1, T2, T3>(Expression<Func<T1, T2, T3>> lambda) { return new JsExpressionVisitor(lambda).ToJavaScript() as JsFunction; }
        public static JsFunction Function<T1, T2, T3, T4>(Expression<Func<T1, T2, T3, T4>> lambda) { return new JsExpressionVisitor(lambda).ToJavaScript() as JsFunction; }
        public static JsIf If(Js condition, Js action) { return new JsIf(condition, action, null); }
        public static JsIf If(Js condition, Js action, Js actionElse) { return new JsIf(condition, action, actionElse); }
        public static JsWhile While(Js condition, Js action) { return new JsWhile(condition, action); }
        public static JsVariable Variable(string name) { return new JsVariable(name); }
        public static JsReturn Return(Js js) { return new JsReturn(js); }
    }
}
