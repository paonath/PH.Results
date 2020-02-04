using Microsoft.Extensions.Logging;

namespace PH.Results.Internals
{
    public class MainErrorFromException : MainError
    {
        internal MainErrorFromException(string stacktrace, string errorMessage, IError innerError = null, EventId? eventId = null) 
            : base(string.Empty, stacktrace, -1, errorMessage, innerError, eventId)
        {
        }

        internal MainErrorFromException(string stacktrace, string errorMessage, IError innerError) 
            : base(string.Empty, stacktrace, -1, errorMessage, innerError)
        {
        }

        internal MainErrorFromException(string stacktrace, string errorMessage, EventId eventId) : base(string.Empty, stacktrace,-1, errorMessage, eventId)
        {
        }
    }
}