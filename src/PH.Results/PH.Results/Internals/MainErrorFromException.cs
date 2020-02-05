using JetBrains.Annotations;
using Microsoft.Extensions.Logging;

namespace PH.Results.Internals
{
    /// <summary>
    /// Main Error Instance with CallerFilePath initialized from Exception Stacktrace
    /// </summary>
    /// <seealso cref="PH.Results.Internals.MainError" />
    public class MainErrorFromException : MainError
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="MainErrorFromException"/> class.
        /// </summary>
        /// <param name="stacktrace">The stacktrace.</param>
        /// <param name="errorMessage">The error message.</param>
        /// <param name="innerError">The inner error.</param>
        /// <param name="eventId">The event identifier.</param>
        internal MainErrorFromException(string stacktrace, [NotNull] string errorMessage, IError innerError = null, EventId? eventId = null) 
            : base(string.Empty, stacktrace, -1, errorMessage, innerError, eventId)
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="MainErrorFromException"/> class.
        /// </summary>
        /// <param name="stacktrace">The stacktrace.</param>
        /// <param name="errorMessage">The error message.</param>
        /// <param name="innerError">The inner error.</param>
        internal MainErrorFromException(string stacktrace, [NotNull] string errorMessage, IError innerError) 
            : base(string.Empty, stacktrace, -1, errorMessage, innerError)
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="MainErrorFromException"/> class.
        /// </summary>
        /// <param name="stacktrace">The stacktrace.</param>
        /// <param name="errorMessage">The error message.</param>
        /// <param name="eventId">The event identifier.</param>
        internal MainErrorFromException(string stacktrace, [NotNull] string errorMessage, EventId eventId) : base(string.Empty, stacktrace,-1, errorMessage, eventId)
        {
        }
    }
}