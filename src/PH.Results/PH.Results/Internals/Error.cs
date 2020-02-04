using System;
using JetBrains.Annotations;
using Microsoft.Extensions.Logging;

namespace PH.Results.Internals
{
    /// <summary>
    /// Error Instance
    /// </summary>
    /// <seealso cref="PH.Results.IError" />
    public class Error : IError
    {
        /// <summary>Initializes a new instance of the <see cref="Error"/> class.</summary>
        /// <param name="errorMessage">The error message.</param>
        /// <param name="innerError">The inner error.</param>
        /// <param name="eventId">The event identifier.</param>
        public Error(string errorMessage, IError innerError = null, EventId? eventId = null)
        {
            ErrorMessage = errorMessage;
            InnerError   = innerError;
            ErrorEventId = eventId;
        }

        /// <summary>Initializes a new instance of the <see cref="Error"/> class.</summary>
        /// <param name="errorMessage">The error message.</param>
        /// <param name="innerError">The inner error.</param>
        public Error(string errorMessage, IError innerError)
            : this(errorMessage, innerError,null)
        {
            
        }

        /// <summary>Initializes a new instance of the <see cref="Error"/> class.</summary>
        /// <param name="errorMessage">The error message.</param>
        /// <param name="eventId">The event identifier.</param>
        public Error(string errorMessage, EventId eventId)
            : this(errorMessage,null, eventId)
        {
            
        }


        /// <summary>
        /// Error Message
        /// </summary>
        public string ErrorMessage { get; }

        /// <summary>
        /// Event Id
        /// </summary>
        public EventId? ErrorEventId { get; set; }

        /// <summary>
        /// Optional Message to Service that received the error
        /// </summary>
        public string OutputMessage { get; set; }

        /// <summary>
        /// Inner Error
        /// </summary>
        public IError InnerError { get; internal set; }


        /// <summary>Initializes a new instance of the <see cref="Error"/> class from a exception.</summary>
        /// <param name="errorMessage">the error message</param>
        /// <param name="exception">The exception.</param>
        /// <param name="eventId">The event identifier.</param>
        /// <returns></returns>
        /// <exception cref="ArgumentNullException">exception if null exception given</exception>
        [NotNull]
        public static Error FromException(string errorMessage,[NotNull] Exception exception, EventId? eventId = null)
        {
            Error r = null;
            r = null == exception.InnerException 
                    ? new MainErrorFromException(exception.StackTrace, errorMessage) 
                    : new Error(exception.Message);

            if (null != eventId)
            {
                r.ErrorEventId = eventId;
            }
            if (null != exception.InnerException)
            {
                r.InnerError = FromException(exception.InnerException);
            }

            return r;
        }
        /// <summary>Initializes a new instance of the <see cref="Error"/> class from a exception.</summary>
        /// <param name="exception">The exception.</param>
        /// <param name="eventId">The event identifier.</param>
        /// <returns></returns>
        /// <exception cref="ArgumentNullException">exception if null exception given</exception>
        [NotNull]
        public static Error FromException([NotNull] Exception exception, EventId? eventId = null)
        {
            Error r = null;
            r = null == exception.InnerException 
                    ? new MainErrorFromException(exception.StackTrace, exception.Message) 
                    : new Error(exception.Message);

            if (null != eventId)
            {
                r.ErrorEventId = eventId;
            }
            if (null != exception.InnerException)
            {
                r.InnerError = FromException(exception.InnerException);
            }

            return r;
        }
    }
}