using JetBrains.Annotations;
using Microsoft.Extensions.Logging;

namespace PH.Results.Internals
{
    /// <summary>
    /// Main Error Instance with CallerMemberName, CallerFilePath and CallerLineNumber
    /// </summary>
    /// <seealso cref="PH.Results.Internals.Error" />
    /// <seealso cref="PH.Results.IError" />
    public class MainError : Error, IError
    {
        
        /// <summary>
        /// Initializes a new instance of the <see cref="MainError"/> class.
        /// </summary>
        /// <param name="callerMemberName">Name of the caller member.</param>
        /// <param name="callerFilePath">The caller file path.</param>
        /// <param name="callerLineNumber">The caller line number.</param>
        /// <param name="errorMessage">The error message.</param>
        /// <param name="innerError">The inner error.</param>
        /// <param name="eventId">The event identifier.</param>
        internal MainError(string callerMemberName, string callerFilePath, int callerLineNumber
                           , [NotNull] string errorMessage, IError innerError = null, EventId? eventId = null)
            : base(errorMessage, innerError, eventId)
        {
            CallerMemberName = callerMemberName;
            CallerFilePath   = callerFilePath;
            CallerLineNumber = callerLineNumber;
        }

        /// <summary>Gets the name of the caller member.</summary>
        /// <value>The name of the caller member.</value>
        public string CallerMemberName { get; }

        /// <summary>Gets the caller file path.</summary>
        /// <value>The caller file path.</value>
        public string CallerFilePath { get; }

        /// <summary>Gets the caller line number.</summary>
        /// <value>The caller line number.</value>
        public int CallerLineNumber { get; }

        /// <summary>
        /// Initializes a new instance of the <see cref="MainError"/> class.
        /// </summary>
        /// <param name="callerMemberName">Name of the caller member.</param>
        /// <param name="callerFilePath">The caller file path.</param>
        /// <param name="callerLineNumber">The caller line number.</param>
        /// <param name="errorMessage">The error message.</param>
        /// <param name="innerError">The inner error.</param>
        internal MainError(string callerMemberName, string callerFilePath, int callerLineNumber,[NotNull] string errorMessage, IError innerError) 
            : this(callerMemberName,callerFilePath, callerLineNumber,errorMessage, innerError,null)
        {

        }

        /// <summary>
        /// Initializes a new instance of the <see cref="MainError"/> class.
        /// </summary>
        /// <param name="callerMemberName">Name of the caller member.</param>
        /// <param name="callerFilePath">The caller file path.</param>
        /// <param name="callerLineNumber">The caller line number.</param>
        /// <param name="errorMessage">The error message.</param>
        /// <param name="eventId">The event identifier.</param>
        internal MainError(string callerMemberName, string callerFilePath, int callerLineNumber,[NotNull] string errorMessage, EventId eventId) 
            : this(callerMemberName,callerFilePath, callerLineNumber,errorMessage, null,eventId)
        {

        }

        
    }
}