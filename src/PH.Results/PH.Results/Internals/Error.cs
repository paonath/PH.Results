﻿using System;
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
        /// <summary>Gets the error unique identifier.</summary>
        /// <value>The error unique identifier.</value>
        public Guid ErrorGuid { get; }

        /// <summary>Initializes a new instance of the <see cref="Error"/> class.</summary>
        public Error()
        {
            ErrorGuid = Guid.NewGuid();
        }

        /// <summary>Initializes a new instance of the <see cref="Error"/> class.</summary>
        /// <param name="errorMessage">The error message.</param>
        /// <param name="innerError">The inner error.</param>
        /// <param name="eventId">The event identifier.</param>
        internal Error([NotNull] string errorMessage, [CanBeNull] IError innerError = null,[CanBeNull] EventId? eventId = null)
            : this()
        {
            ErrorMessage = errorMessage;
            InnerError   = innerError;
            ErrorEventId = eventId;
        }

        /// <summary>Initializes a new instance of the <see cref="Error"/> class.</summary>
        /// <param name="errorMessage">The error message.</param>
        /// <param name="innerError">The inner error.</param>
        internal Error([NotNull] string errorMessage, [NotNull] IError innerError)
            : this(errorMessage, innerError,null)
        {
            
        }

        /// <summary>Initializes a new instance of the <see cref="Error"/> class.</summary>
        /// <param name="errorMessage">The error message.</param>
        /// <param name="eventId">The event identifier.</param>
        internal Error([NotNull] string errorMessage, EventId eventId)
            : this(errorMessage,null, eventId)
        {
            
        }

        
        /// <summary>
        /// Error Message
        /// </summary>
        public string ErrorMessage { get; set; }

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
        public IError InnerError { get; set; }

        /// <summary>Return new instance of the specified error</summary>
        /// <param name="errorMessage">The error message.</param>
        /// <param name="innerError">The inner error.</param>
        /// <param name="eventId">The event identifier.</param>
        /// <returns></returns>
        [NotNull]
        public static Error Instance([NotNull] string errorMessage, [CanBeNull] IError innerError = null,[CanBeNull] EventId? eventId = null)
        {
            return new Error(errorMessage, innerError, eventId);
        }


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


        /// <summary>Serves as the default hash function.</summary>
        /// <returns>A hash code for the current object.</returns>
        public override int GetHashCode()
        {
            return ToString().GetHashCode();
        }

        /// <summary>Returns a string that represents the current object.</summary>
        /// <returns>A string that represents the current object.</returns>
        [NotNull]
        public override string ToString()
        {
            string s = "";
            if (ErrorEventId.HasValue)
            {
                s = $" Ev. Id '{ErrorEventId.Value}' - ";
            }

            s += $"{ErrorGuid:N}";
            return $"{ErrorMessage} [{s}]";
        }
    }
}