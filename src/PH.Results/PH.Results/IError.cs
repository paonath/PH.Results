using System;
using Microsoft.Extensions.Logging;

namespace PH.Results
{
    /// <summary>
    /// Error 
    /// </summary>
    public interface IError
    {

        /// <summary>
        /// Error Message
        /// </summary>
        string ErrorMessage { get; }

        /// <summary>
        /// Event Id
        /// </summary>
        EventId? ErrorEventId { get; }

        /// <summary>
        /// Optional Message to Service that received the error
        /// </summary>
        string OutputMessage { get; }

        /// <summary>
        /// Inner Error
        /// </summary>
        IError InnerError { get; }

        /// <summary>Gets the deep of nested errors.</summary>
        /// <value>The deep.</value>
        int Deep { get; }

    }
}