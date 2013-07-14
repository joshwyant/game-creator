using System.IO;
using System;
using System.Collections.Generic;
namespace GameCreator.Framework.Gml.Interpreter
{
    // A code unit. It is initialized with a code string.
    // A code unit is always compiled once. Either manually, i.e. while loading, or immediately before the code is run.
    // 'Compiled' means transformed into a parse tree to be efficiently executed.
    public class CodeUnit
    {
        static Dictionary<object, CodeUnit> CodeUnits = new Dictionary<object, CodeUnit>();

        public object CodeObject { get; set; }

        AstNode parseTree;
        public AstNode ParseTree
        {
            get
            {
                Compile();

                return parseTree;
            }
        }

        public bool IsExpression { get; set; }

        CodeUnit(object gmlObject, bool isExpression)
        {
            CodeObject = gmlObject;
            IsExpression = isExpression;
        }

        TextReader GetTextReader()
        {
            if (CodeObject is IGml)
                return (CodeObject as IGml).GetCodeReader();

            return new StringReader(CodeObject as string);
        }

        public string Code
        {
            get
            {
                if (CodeObject is string)
                    return CodeObject as string;

                using (var reader = GetTextReader())
                {
                    return reader.ReadToEnd();
                }
            }
        }

        public void Compile()
        {
            if (parseTree != null)
                return;

            using (var reader = GetTextReader())
            {
                var p = new Parser(reader);

                if (IsExpression)
                {
                    parseTree = p.ParseExpression();
                    if (ExecutionContext.RunOptimized)
                        parseTree = (parseTree as Expression).Reduce();
                }
                else
                {
                    parseTree = p.Parse();
                    if (ExecutionContext.RunOptimized)
                        (parseTree as Statement).Optimize();
                }

            }
        }

        public bool Compiled { get { return parseTree != null; } }

        static CodeUnit Get(object obj, bool isExpression)
        {
            if (!(obj is string || obj is IGml))
                throw new InvalidOperationException();

            CodeUnit unit;

            if (!CodeUnits.TryGetValue(obj, out unit))
            {
                unit = new CodeUnit(obj, isExpression);
                CodeUnits.Add(obj, unit);
            }

            return unit;
        }

        /// <summary>
        /// Gets a CodeUnit based on an IGml instance or string, to execute, not to evaluate.
        /// </summary>
        public static CodeUnit Get(object obj)
        {
            return Get(obj, false);
        }

        /// <summary>
        /// Gets a CodeUnit based on an IGml instance or string, to evaluate as an expression.
        /// </summary>
        public static CodeUnit GetExpression(object obj)
        {
            return Get(obj, true);
        }
    }
}
