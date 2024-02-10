using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;


namespace GameCreator.Framework.Gml
{
    public class Access : Expression
    {
        public Expression Instance { get; set; }
        public string Name { get; set; }
        public Expression[] Indices { get; set; }

        public Access(Expression left, string n, Expression[] ind, int l, int c)
            : base(l, c)
        {
            Instance = left; Name = n; Indices = ind;
        }

        public override ExpressionKind Kind
        {
            get { return ExpressionKind.Access; }
        }

        internal override void Write(System.CodeDom.Compiler.IndentedTextWriter writer, GmlFormatter formatter)
        {
            if (Instance != null)
            {
                Instance.Write(writer, formatter);
                writer.Write(".");
            }
            writer.Write(Name);
            if (Indices.Length != 0)
            {
                writer.Write("[");
                for (int i = 0; i < Indices.Length; i++)
                {
                    if (i != 0)
                        writer.Write("," + formatter.Padding);
                    Indices[i].Write(writer, formatter);
                }
                writer.Write("]");
            }
        }
    }
}
