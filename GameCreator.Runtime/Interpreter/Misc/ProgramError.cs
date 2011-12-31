using System;
using System.Collections.Generic;
using System.Text;

namespace GameCreator.Runtime.Interpreter
{
    public enum CodeLocation
    {
        Script,
        RoomScript,
        ObjectAction,
        TimelineAction,
        CodeToBeExecuted
    }
    public enum ErrorSeverity
    {
        CompilationError,
        FatalError,
        Error
    }
    public class ProgramError : Exception
    {
        public string Code { get; set; }
        public int Line { get; set; }
        public int Column { get; set; }
        public CodeLocation Location { get; set; }
        public ErrorSeverity Severity { get; set; }
        public Stmt OffendingStatement { get; set; }
        public ProgramError(String message, ErrorSeverity sev, int line, int col) 
            : base(message) 
        {
            Severity = sev;
            Line = line;
            Column = col; 
        }
        public ProgramError(String message, ErrorSeverity sev, Stmt s)
            : base(message)
        {
            Severity = sev;
            Line = s.Line;
            Column = s.Column;
            OffendingStatement = s;
        }
    }
}
