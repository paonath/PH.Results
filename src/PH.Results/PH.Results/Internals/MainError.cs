using Microsoft.Extensions.Logging;

namespace PH.Results.Internals
{
    public class MainError : Error, IError
    {
        internal MainError(string callerMemberName, string callerFilePath, int callerLineNumber,string errorMessage, IError innerError = null, EventId? eventId = null) 
            : base(errorMessage, innerError, eventId)
        {
            CallerMemberName = callerMemberName;
            CallerFilePath   = callerFilePath;
            CallerLineNumber = callerLineNumber;
        }

        public string CallerMemberName { get; }
        public string CallerFilePath { get; }
        public int CallerLineNumber { get; }

        internal MainError(string callerMemberName, string callerFilePath, int callerLineNumber,string errorMessage, IError innerError) 
            : this(callerMemberName,callerFilePath, callerLineNumber,errorMessage, innerError,null)
        {

        }

        internal MainError(string callerMemberName, string callerFilePath, int callerLineNumber,string errorMessage, EventId eventId) 
            : this(callerMemberName,callerFilePath, callerLineNumber,errorMessage, null,eventId)
        {

        }

        
    }
}