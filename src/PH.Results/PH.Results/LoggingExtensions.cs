using System;
using System.Runtime.CompilerServices;
using JetBrains.Annotations;
using Microsoft.Extensions.Logging;
using PH.Results.Internals;
// ReSharper disable ExplicitCallerInfoArgument

namespace PH.Results
{
    /// <summary>
    /// Logging useful extensions
    /// </summary>
    public static class ResultLoggingExtensions
    {


        private static (string Message, string Source) PrepareMessage([NotNull] IError error)
        {
            string s = "";
            if (error is MainError m)
            {
                s = $"Generated at {m.CallerFilePath} line {m.CallerLineNumber} [{m.CallerMemberName}]";
            }
            else
            {
                var cp = PrepareMessage(error.InnerError);
                s = cp.Source;
            }

            return (error.ErrorMessage, s);
        }

        /// <summary>
        /// Log error
        /// </summary>
        /// <param name="l">logger</param>
        /// <param name="error">error</param>
        public static void LogError(this ILogger l, [NotNull] IError error)
        {
            var msg = PrepareMessage(error);
            if (error.ErrorEventId.HasValue)
            {
                var evId = error.ErrorEventId.Value;
                l.Log(LogLevel.Error,evId, $"{error.ErrorMessage} {msg.Source}");
            }
            else
            {
                l.LogError($"{error.ErrorMessage} {msg.Source}");
            }
        }

        

        /// <summary>
        /// log critical
        /// </summary>
        /// <param name="l">logger</param>
        /// <param name="error">error</param>
        public static void LogCritical(this ILogger l, [NotNull] IError error)
        {
            var msg = PrepareMessage(error);
            if (error.ErrorEventId.HasValue)
            {
                var evId = error.ErrorEventId.Value;
                l.Log(LogLevel.Critical,evId, $"{error.ErrorMessage} {msg.Source}");
            }
            else
            {
                l.LogCritical($"{error.ErrorMessage} {msg.Source}");
            }

            
        }





        

        
    }
}