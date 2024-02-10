using System;
using System.Collections.Generic;
using System.Text;

namespace GameCreator.Framework
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
        ErrorSeverity severity;
        public ErrorSeverity Severity { get; set; }
        public object Object { get; set; }
        public Error Error { get; set; }
        bool wasMessageGiven = false;

        public ProgramError(string message, ErrorSeverity sev, int line, int col) 
            : base(message) 
        {
            Severity = sev;
            Line = line;
            Column = col;
            wasMessageGiven = !string.IsNullOrEmpty(message);
        }

        public ProgramError(string msg, ErrorSeverity errorSeverity)
            : base(msg)
        {
            Severity = errorSeverity;
            wasMessageGiven = !string.IsNullOrEmpty(msg);
        }

        public ProgramError(Error error)
        {
            Error = error;
            Severity = Errors.ErrorDefinitions[error].Severity;
        }

        public ProgramError(Error error, object obj)
            : this(error)
        {
            Object = obj;
        }

        public ProgramError(Error err, int line, int col)
            : this(err)
        {
            Line = line;
            Column = col;
        }

        public ProgramError(Error err, object obj, int line, int col)
            : this(err, obj)
        {
            Line = line;
            Column = col;
        }

        public override string Message
        {
            get
            {
                if (wasMessageGiven)
                    return base.Message;
                return string.Format(Errors.ErrorDefinitions[Error].Message, Object);
            }
        }
    }
}
