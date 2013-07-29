using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Linq.Expressions;
using System.IO;
using JavaScriptBuilder.Expressions;

namespace JavaScriptBuilder
{
    public class JsExpressionVisitor : ExpressionVisitor
    {
        public Expression Root { get; set; }
        public JsFormatter Formatter { get; set; }
        Js constructed;

        public JsExpressionVisitor(Expression root)
            : base()
        {
            Root = root;
        }

        public override string ToString()
        {
            Visit(Root);

            return constructed.ToString();
        }

        public string ToString(JsFormatter formatter)
        {
            Visit(Root);
            return constructed.ToString(formatter);
        }

        public Js ToJavaScript()
        {
            Visit(Root);

            return constructed;
        }

        public JsBinary ToBinary()
        {
            Visit(Root);

            return ((constructed as JsFunction).Body.Single() as JsReturn).Expression as JsBinary;
        }

        public void Write(TextWriter writer, JsFormatter formatter = null)
        {
            Visit(Root);

            constructed.Write(writer, formatter);
        }

        protected override Expression VisitParameter(ParameterExpression node)
        {
            constructed = Js.Variable(node.Name);

            return node;
        }

        protected override Expression VisitBinary(BinaryExpression node)
        {
            Js left, right;
            Visit(node.Left);
            left = constructed;
            Visit(node.Right);
            right = constructed;

            var ops = new Dictionary<ExpressionType, string>() {
                { ExpressionType.Add, "+" },
                { ExpressionType.Subtract, "-" },
                { ExpressionType.Multiply, "*" },
                { ExpressionType.Divide, "/" },
            };

            constructed = Js.Binary(left, right, ops[node.NodeType]);

            return node;
        }

        protected override Expression VisitLambda<T>(Expression<T> node)
        {
            Visit(node.Body);

            constructed = Js.Function(node.Name, new[] { Js.Return(constructed) }, node.Parameters.Select(p => p.Name).ToArray());

            return node;
        }

        protected override Expression VisitBlock(BlockExpression node)
        {
            var list = new List<Js>();

            foreach (var e in node.Expressions)
            {
                Visit(e);
                list.Add(constructed);
            }

            constructed = Js.Block(list.ToArray());

            return node;
        }
    }
}
