using System;
using System.Collections.Generic;
using System.Text;


namespace GameCreator.Framework.Gml
{
    public abstract class Statement : AstNode
    {
        public Statement(int line, int col) : base(line, col) { }
        protected FlowType ProgramFlow;
        // Nothing should call run(), which is called internally be Stmt.
        // This is the function you override. The statement changes program flow with the variable ProgramFlow.
        protected virtual void run()
        {
        }
        // This is the user function to execute a statement. It should not be called by statements themselves.
        public FlowType Exec()
        {
            ProgramFlow = FlowType.None;
            Statement prev = ExecutionContext.ExecutingStatement;
            ExecutionContext.ExecutingStatement = this;
            run();
            ExecutionContext.ExecutingStatement = prev;
            return ProgramFlow;
        }
        // This function is called by non-loop statements with embedded statements. The calling statement must
        // return if Exec(s) != FlowType.None.
        protected FlowType Exec(Statement s)
        {
            FlowType t = s.Exec();
            ProgramFlow |= t;
            return t;
        }
        // This function is called by loop statements to execute embedded statements. You can catch
        // program flow statements, to keep them from falling through, like this:
        /* switch (Exec(s, FlowType.Break|FlowType.Continue))
         * {
         * case FlowType.Break:
         *     goto End;
         * case FlowType.Continue:
         *     goto Test;
         * default:
         *     return;
         * }
         */
        protected FlowType Exec(Statement s, FlowType Catch)
        {
            FlowType t = s.Exec();
            ProgramFlow |= t & ~Catch;
            return t;
        }
        public void Error(string str)
        {
            throw new ProgramError(str, ErrorSeverity.Error, ExecutionContext.ExecutingStatement);
        }

        public abstract StatementKind Kind { get; }


        public static Statement Nop { get { return new Nop(0, 0); } }
    }
}
