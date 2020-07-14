using System;
using System.Runtime.CompilerServices;
using JetBrains.Annotations;
using Microsoft.Extensions.Logging;
using PH.Results.Internals;

namespace PH.Results
{
    
    
    
    /// <summary>
    /// Static Factory class for init Result 
    /// </summary>
    public static class ResultFactory
    {
        #region OK

        /// <summary>Initialize Ok Result wrapping wrapping <see cref="IResult{TContent}.Content">Content</see></summary>
        /// <typeparam name="TContent">The type of the content.</typeparam>
        /// <param name="id">The identifier.</param>
        /// <param name="content">The content.</param>
        /// <returns>Wrapper for <see cref="IResult{TContent}.Content"/> OK</returns>
        [NotNull]
        public static IResult<TContent> Ok<TContent>([NotNull] object id, [NotNull] TContent content)
        {
            return new ResultOk<TContent>(id, content);
        }

        /// <summary>Initialize Ok Result wrapping <see cref="IResult{TContent}.Content">Content</see>  </summary>
        /// <typeparam name="TIdentifier">The type of the key.</typeparam>
        /// <typeparam name="TContent">The type of the content.</typeparam>
        /// <param name="id">The identifier.</param>
        /// <param name="content">The content.</param>
        /// <returns>Wrapper for <see cref="IResult{TContent}.Content"/> OK</returns>
        [NotNull]
        public static IResult<TIdentifier,TContent> Ok<TIdentifier,TContent>([NotNull] TIdentifier id, [NotNull] TContent content)
        {
            return new ResultOk<TIdentifier,TContent>(id, content);
        }


        #endregion

        #region Fail

        #region private


        /// <summary>Raises the fail result.</summary>
        /// <typeparam name="TContent">The type of the content.</typeparam>
        /// <param name="id">The identifier.</param>
        /// <param name="error">The error.</param>
        /// <param name="memberName">Name of the member.</param>
        /// <param name="sourceFilePath">The source file path.</param>
        /// <param name="sourceLineNumber">The source line number.</param>
        /// <returns></returns>
        [NotNull]
        private static Result<TContent> RaiseFail<TContent>([NotNull] object id, [NotNull] IError error, string memberName,
                                                            string sourceFilePath, int sourceLineNumber)
        {
            if (error is MainError e)
            {
                return new ResultFail<TContent>(id,e);
            }
           
            var m = new MainError(memberName, sourceFilePath, sourceLineNumber, error.ErrorMessage, error?.InnerError, error?.ErrorEventId);
            return new ResultFail<TContent>(id, m);
           

        }
        /// <summary>Raises the fail result.</summary>
        /// <typeparam name="TContent">The type of the content.</typeparam>
        /// <param name="id">The identifier.</param>
        /// <param name="content">The content.</param>
        /// <param name="error">The error.</param>
        /// <param name="memberName">Name of the member.</param>
        /// <param name="sourceFilePath">The source file path.</param>
        /// <param name="sourceLineNumber">The source line number.</param>
        /// <returns></returns>
        [NotNull]
        private static Result<TContent> RaiseFail<TContent>([NotNull] object id, [NotNull] TContent content, [NotNull] IError error, string memberName,
                                                            string sourceFilePath, int sourceLineNumber)
        {
            if (error is MainError e)
            {
                return new ResultFail<TContent>(id, content,e);
            }
           
            var m = new MainError(memberName, sourceFilePath, sourceLineNumber, error.ErrorMessage, error?.InnerError, error?.ErrorEventId);
            return new ResultFail<TContent>(id, content, m);
           

        }



        /// <summary>Raises the fail result.</summary>
        /// <typeparam name="TIdentifier">The type of the identifier.</typeparam>
        /// <typeparam name="TContent">The type of the content.</typeparam>
        /// <param name="id">The identifier.</param>
        /// <param name="error">The error.</param>
        /// <param name="memberName">Name of the member.</param>
        /// <param name="sourceFilePath">The source file path.</param>
        /// <param name="sourceLineNumber">The source line number.</param>
        /// <returns></returns>
        [NotNull]
        private static Result<TIdentifier,TContent> RaiseFail<TIdentifier,TContent>([NotNull] TIdentifier id, [NotNull] IError error, string memberName, string sourceFilePath,
                                                                                    int sourceLineNumber)
        {
            if (error is MainError e)
            {
                return new ResultFail<TIdentifier,TContent>(id,e);
            }
           
            var m = new MainError(memberName, sourceFilePath, sourceLineNumber, error.ErrorMessage, error?.InnerError, error?.ErrorEventId);
            return new ResultFail<TIdentifier,TContent>(id, m);
            
        }

        /// <summary>Raises the fail.</summary>
        /// <typeparam name="TIdentifier">The type of the identifier.</typeparam>
        /// <typeparam name="TContent">The type of the content.</typeparam>
        /// <param name="id">The identifier.</param>
        /// <param name="content">The content.</param>
        /// <param name="error">The error.</param>
        /// <param name="memberName">Name of the member.</param>
        /// <param name="sourceFilePath">The source file path.</param>
        /// <param name="sourceLineNumber">The source line number.</param>
        /// <returns></returns>
        [NotNull]
        private static Result<TIdentifier,TContent> RaiseFail<TIdentifier,TContent>([NotNull] TIdentifier id, [NotNull] TContent content, [NotNull] IError error, string memberName, string sourceFilePath,
                                                                                    int sourceLineNumber)
        {
            if (error is MainError e)
            {
                return new ResultFail<TIdentifier,TContent>(id, content,e);
            }
           
            var m = new MainError(memberName, sourceFilePath, sourceLineNumber, error.ErrorMessage, error?.InnerError, error?.ErrorEventId);
            return new ResultFail<TIdentifier,TContent>(id, content, m);
            
        }

        /// <summary>Raises the fail from result.</summary>
        /// <typeparam name="TContent">The type of the content.</typeparam>
        /// <typeparam name="TOtherContent">The type of the other content.</typeparam>
        /// <param name="otherResultOnError">The other result on error.</param>
        /// <param name="memberName">Name of the member.</param>
        /// <param name="sourceFilePath">The source file path.</param>
        /// <param name="sourceLineNumber">The source line number.</param>
        /// <returns></returns>
        /// <exception cref="NotImplementedException"></exception>
        [NotNull]
        private static Result<TContent> RaiseFailFromResult<TContent,TOtherContent>([NotNull] IResult<TOtherContent> otherResultOnError, string memberName, string sourceFilePath, int sourceLineNumber)
        {
            var e = new MainError(memberName, sourceFilePath, sourceLineNumber, otherResultOnError.Error.ErrorMessage,
                                  otherResultOnError.Error, otherResultOnError.Error?.ErrorEventId);

            var m = new ResultChainFail<TContent, TOtherContent>(otherResultOnError.Identifier,
                                                                         e, otherResultOnError);
            return m;
        }

        /// <summary>Raises the fail from result.</summary>
        /// <typeparam name="TContent">The type of the content.</typeparam>
        /// <typeparam name="TOtherContent">The type of the other content.</typeparam>
        /// <param name="errorMessage">The error message.</param>
        /// <param name="otherResultOnError">The other result on error.</param>
        /// <param name="memberName">Name of the member.</param>
        /// <param name="sourceFilePath">The source file path.</param>
        /// <param name="sourceLineNumber">The source line number.</param>
        /// <returns></returns>
        [NotNull]
        private static Result<TContent> RaiseFailFromResult<TContent,TOtherContent>([NotNull] string errorMessage, [NotNull] IResult<TOtherContent> otherResultOnError, string memberName, string sourceFilePath, int sourceLineNumber)
        {
            var e = new MainError(memberName, sourceFilePath, sourceLineNumber, errorMessage,
                                  otherResultOnError.Error?.InnerError, otherResultOnError.Error?.ErrorEventId);

            var m = new ResultChainFail<TContent, TOtherContent>(otherResultOnError.Identifier,
                                                                 e, otherResultOnError);
            return m;
        }

        /// <summary>Raises the fail from result.</summary>
        /// <typeparam name="TIdentifier">The type of the identifier.</typeparam>
        /// <typeparam name="TContent">The type of the content.</typeparam>
        /// <typeparam name="TOtherContent">The type of the other content.</typeparam>
        /// <param name="otherResultOnError">The other result on error.</param>
        /// <param name="memberName">Name of the member.</param>
        /// <param name="sourceFilePath">The source file path.</param>
        /// <param name="sourceLineNumber">The source line number.</param>
        /// <returns></returns>
        [NotNull]
        private static Result<TIdentifier,TContent> RaiseFailFromResult<TIdentifier,TContent,TOtherContent>([NotNull] IResult<TIdentifier,TOtherContent> otherResultOnError, string memberName, string sourceFilePath, int sourceLineNumber)
        {
            var e = new MainError(memberName, sourceFilePath, sourceLineNumber, otherResultOnError.Error.ErrorMessage,
                                  otherResultOnError.Error?.InnerError, otherResultOnError.Error?.ErrorEventId);

            var m = new ResultChainFail<TIdentifier,TContent, TOtherContent>(otherResultOnError.TypedIdentifier,
                                                                            e, otherResultOnError);
            return m;
        }

        /// <summary>Raises the fail from result.</summary>
        /// <typeparam name="TIdentifier">The type of the identifier.</typeparam>
        /// <typeparam name="TContent">The type of the content.</typeparam>
        /// <typeparam name="TOtherContent">The type of the other content.</typeparam>
        /// <param name="errorMessage">The error message.</param>
        /// <param name="otherResultOnError">The other result on error.</param>
        /// <param name="memberName">Name of the member.</param>
        /// <param name="sourceFilePath">The source file path.</param>
        /// <param name="sourceLineNumber">The source line number.</param>
        /// <returns></returns>
        [NotNull]
        private static Result<TIdentifier,TContent> RaiseFailFromResult<TIdentifier,TContent,TOtherContent>([NotNull] string errorMessage,[NotNull] IResult<TIdentifier,TOtherContent> otherResultOnError, string memberName, string sourceFilePath, int sourceLineNumber)
        {
            var e = new MainError(memberName, sourceFilePath, sourceLineNumber, errorMessage,
                                  otherResultOnError.Error?.InnerError, otherResultOnError.Error?.ErrorEventId);

            var m = new ResultChainFail<TIdentifier,TContent, TOtherContent>(otherResultOnError.TypedIdentifier,
                                                                             e, otherResultOnError);
            return m;
        }


        #endregion

        /// <summary>Initialize Fails result.</summary>
        /// <typeparam name="TContent">The type of the content.</typeparam>
        /// <param name="id">The identifier.</param>
        /// <param name="error">The error.</param>
        /// <param name="memberName">Name of the member.</param>
        /// <param name="sourceFilePath">The source file path.</param>
        /// <param name="sourceLineNumber">The source line number.</param>
        /// <returns></returns>
        [NotNull]
        public static Result<TContent> Fail<TContent>([NotNull] object id, [NotNull] IError error,
                                                      [CallerMemberName]
                                                      string memberName = "",
                                                      [CallerFilePath]
                                                      string sourceFilePath = "",
                                                      [CallerLineNumber]
                                                      int sourceLineNumber = 0)
        {
            return RaiseFail<TContent>(id, error, memberName, sourceFilePath, sourceLineNumber);
        }

        /// <summary>Initialize Fails result.</summary>
        /// <typeparam name="TIdentifier">The type of the identifier.</typeparam>
        /// <typeparam name="TContent">The type of the content.</typeparam>
        /// <param name="id">The identifier.</param>
        /// <param name="error">The error.</param>
        /// <param name="memberName">Name of the member.</param>
        /// <param name="sourceFilePath">The source file path.</param>
        /// <param name="sourceLineNumber">The source line number.</param>
        /// <returns></returns>
        [NotNull]
        public static Result<TIdentifier,TContent> Fail<TIdentifier,TContent>([NotNull] TIdentifier id, [NotNull] IError error,
                                                                              [CallerMemberName]
                                                                              string memberName = "",
                                                                              [CallerFilePath]
                                                                              string sourceFilePath = "",
                                                                              [CallerLineNumber]
                                                                              int sourceLineNumber = 0)
        {
            return RaiseFail<TIdentifier,TContent>(id, error, memberName, sourceFilePath, sourceLineNumber);
        }




        /// <summary>Initialize Fails result.</summary>
        /// <typeparam name="TContent">The type of the content.</typeparam>
        /// <param name="id">The identifier.</param>
        /// <param name="message">The message.</param>
        /// <param name="memberName">Name of the member.</param>
        /// <param name="sourceFilePath">The source file path.</param>
        /// <param name="sourceLineNumber">The source line number.</param>
        /// <returns></returns>
        [NotNull]
        public static Result<TContent> Fail<TContent>([NotNull] object id, [NotNull] string message,
                                                       [CallerMemberName] string memberName = "",
                                                       [CallerFilePath] string sourceFilePath = "",
                                                       [CallerLineNumber] int sourceLineNumber = 0)
        {
            
            return RaiseFail<TContent>(id, new Error(message), memberName, sourceFilePath, sourceLineNumber);
        }

        /// <summary>Initialize Fails result.</summary>
        /// <typeparam name="TIdentifier">The type of the identifier.</typeparam>
        /// <typeparam name="TContent">The type of the content.</typeparam>
        /// <param name="id">The identifier.</param>
        /// <param name="message">The message.</param>
        /// <param name="memberName">Name of the member.</param>
        /// <param name="sourceFilePath">The source file path.</param>
        /// <param name="sourceLineNumber">The source line number.</param>
        /// <returns></returns>
        [NotNull]
        public static Result<TIdentifier,TContent> Fail<TIdentifier,TContent>([NotNull] TIdentifier id, [NotNull] string message,
                                                                               [CallerMemberName] string memberName = "",
                                                                               [CallerFilePath] string sourceFilePath = "",
                                                                               [CallerLineNumber] int sourceLineNumber = 0)
        {
            return RaiseFail<TIdentifier,TContent>(id, new Error(message), memberName, sourceFilePath, sourceLineNumber);
        }



        /// <summary>Initialize Fails result.</summary>
        /// <typeparam name="TContent">The type of the content.</typeparam>
        /// <param name="id">The identifier.</param>
        /// <param name="message">The message.</param>
        /// <param name="eventId">The event identifier.</param>
        /// <param name="memberName">Name of the member.</param>
        /// <param name="sourceFilePath">The source file path.</param>
        /// <param name="sourceLineNumber">The source line number.</param>
        /// <returns></returns>
        [NotNull]
        public static Result<TContent> Fail<TContent>([NotNull] object id, [NotNull] string message, EventId eventId,
                                                       [CallerMemberName] string memberName = "",
                                                       [CallerFilePath] string sourceFilePath = "",
                                                       [CallerLineNumber] int sourceLineNumber = 0)
        {
            return RaiseFail<TContent>(id, new Error(message, eventId), memberName, sourceFilePath, sourceLineNumber);
        }

        /// <summary>Initialize Fails result.</summary>
        /// <typeparam name="TIdentifier">The type of the identifier.</typeparam>
        /// <typeparam name="TContent">The type of the content.</typeparam>
        /// <param name="id">The identifier.</param>
        /// <param name="message">The message.</param>
        /// <param name="eventId">The event identifier.</param>
        /// <param name="memberName">Name of the member.</param>
        /// <param name="sourceFilePath">The source file path.</param>
        /// <param name="sourceLineNumber">The source line number.</param>
        /// <returns></returns>
        [NotNull]
        public static Result<TIdentifier,TContent> Fail<TIdentifier,TContent>([NotNull] TIdentifier id, [NotNull] string message, EventId eventId,
                                                                               [CallerMemberName] string memberName = "",
                                                                               [CallerFilePath] string sourceFilePath = "",
                                                                               [CallerLineNumber] int sourceLineNumber = 0)
        {
            return RaiseFail<TIdentifier,TContent>(id, new Error(message, eventId), memberName, sourceFilePath, sourceLineNumber);
        }


        /// <summary>Initialize Fails result.</summary>
        /// <typeparam name="TContent">The type of the content.</typeparam>
        /// <param name="id">The identifier.</param>
        /// <param name="message">The message.</param>
        /// <param name="inner">The inner.</param>
        /// <param name="memberName">Name of the member.</param>
        /// <param name="sourceFilePath">The source file path.</param>
        /// <param name="sourceLineNumber">The source line number.</param>
        /// <returns></returns>
        [NotNull]
        public static Result<TContent> Fail<TContent>([NotNull] object id, [NotNull] string message, [NotNull] IError inner,
                                                       [CallerMemberName] string memberName = "",
                                                       [CallerFilePath] string sourceFilePath = "",
                                                       [CallerLineNumber] int sourceLineNumber = 0)
        {
            return RaiseFail<TContent>(id, new Error(message, inner), memberName, sourceFilePath, sourceLineNumber);
        }

        /// <summary>Initialize Fails result.</summary>
        /// <typeparam name="TIdentifier">The type of the identifier.</typeparam>
        /// <typeparam name="TContent">The type of the content.</typeparam>
        /// <param name="id">The identifier.</param>
        /// <param name="message">The message.</param>
        /// <param name="inner">The inner.</param>
        /// <param name="memberName">Name of the member.</param>
        /// <param name="sourceFilePath">The source file path.</param>
        /// <param name="sourceLineNumber">The source line number.</param>
        /// <returns></returns>
        [NotNull]
        public static Result<TIdentifier,TContent> Fail<TIdentifier,TContent>([NotNull] TIdentifier id, [NotNull] string message, [NotNull] IError inner,
                                                                               [CallerMemberName] string memberName = "",
                                                                               [CallerFilePath] string sourceFilePath = "",
                                                                               [CallerLineNumber] int sourceLineNumber = 0)
        {
            return RaiseFail<TIdentifier,TContent>(id, new Error(message, inner), memberName, sourceFilePath, sourceLineNumber);
        }


        /// <summary>Initialize Fails result.</summary>
        /// <typeparam name="TContent">The type of the content.</typeparam>
        /// <param name="id">The identifier.</param>
        /// <param name="message">The message.</param>
        /// <param name="eventId">The event identifier.</param>
        /// <param name="inner">The inner.</param>
        /// <param name="memberName">Name of the member.</param>
        /// <param name="sourceFilePath">The source file path.</param>
        /// <param name="sourceLineNumber">The source line number.</param>
        /// <returns></returns>
        [NotNull]
        public static Result<TContent> Fail<TContent>([NotNull] object id, [NotNull] string message, EventId eventId, IError inner,
                                                       [CallerMemberName] string memberName = "",
                                                       [CallerFilePath] string sourceFilePath = "",
                                                       [CallerLineNumber] int sourceLineNumber = 0)
        {
            return RaiseFail<TContent>(id, new Error(message, inner, eventId), memberName, sourceFilePath, sourceLineNumber);
        }

        /// <summary>Initialize Fails result.</summary>
        /// <typeparam name="TIdentifier">The type of the identifier.</typeparam>
        /// <typeparam name="TContent">The type of the content.</typeparam>
        /// <param name="id">The identifier.</param>
        /// <param name="message">The message.</param>
        /// <param name="eventId">The event identifier.</param>
        /// <param name="inner">The inner.</param>
        /// <param name="memberName">Name of the member.</param>
        /// <param name="sourceFilePath">The source file path.</param>
        /// <param name="sourceLineNumber">The source line number.</param>
        /// <returns></returns>
        [NotNull]
        public static Result<TIdentifier,TContent> Fail<TIdentifier,TContent>([NotNull] TIdentifier id, [NotNull] string message, EventId eventId, IError inner,
                                                                               [CallerMemberName] string memberName = "",
                                                                               [CallerFilePath] string sourceFilePath = "",
                                                                               [CallerLineNumber] int sourceLineNumber = 0)
        {
            return RaiseFail<TIdentifier,TContent>(id, new Error(message, inner, eventId), memberName, sourceFilePath, sourceLineNumber);
        }




        /// <summary>Initialize Fails result.</summary>
        /// <typeparam name="TContent">The type of the content.</typeparam>
        /// <param name="id">The identifier.</param>
        /// <param name="content">The content.</param>
        /// <param name="error">The error.</param>
        /// <param name="memberName">Name of the member.</param>
        /// <param name="sourceFilePath">The source file path.</param>
        /// <param name="sourceLineNumber">The source line number.</param>
        /// <returns></returns>
        [NotNull]
        public static Result<TContent> Fail<TContent>([NotNull] object id, [CanBeNull] TContent content, [NotNull] IError error,
                                                       [CallerMemberName] string memberName = "",
                                                       [CallerFilePath] string sourceFilePath = "",
                                                       [CallerLineNumber] int sourceLineNumber = 0)
        {
            return RaiseFail<TContent>(id, content, error, memberName, sourceFilePath, sourceLineNumber);
        }


        /// <summary>Initialize Fails result.</summary>
        /// <typeparam name="TIdentifier">The type of the identifier.</typeparam>
        /// <typeparam name="TContent">The type of the content.</typeparam>
        /// <param name="id">The identifier.</param>
        /// <param name="content">The content.</param>
        /// <param name="error">The error.</param>
        /// <param name="memberName">Name of the member.</param>
        /// <param name="sourceFilePath">The source file path.</param>
        /// <param name="sourceLineNumber">The source line number.</param>
        /// <returns></returns>
        [NotNull]
        public static Result<TIdentifier,TContent> Fail<TIdentifier,TContent>([NotNull] TIdentifier id, [CanBeNull] TContent content, [NotNull] IError error,
                                                                               [CallerMemberName] string memberName = "",
                                                                               [CallerFilePath] string sourceFilePath = "",
                                                                               [CallerLineNumber] int sourceLineNumber = 0)
        {
            return RaiseFail<TIdentifier,TContent>(id, content, error, memberName, sourceFilePath, sourceLineNumber);
        }


        /// <summary>Initialize Fails result.</summary>
        /// <typeparam name="TContent">The type of the content.</typeparam>
        /// <param name="id">The identifier.</param>
        /// <param name="content">The content.</param>
        /// <param name="message">The message.</param>
        /// <param name="memberName">Name of the member.</param>
        /// <param name="sourceFilePath">The source file path.</param>
        /// <param name="sourceLineNumber">The source line number.</param>
        /// <returns></returns>
        [NotNull]
        public static Result<TContent> Fail<TContent>([NotNull] object id, [CanBeNull] TContent content, [NotNull] string message,
                                                       [CallerMemberName] string memberName = "",
                                                       [CallerFilePath] string sourceFilePath = "",
                                                       [CallerLineNumber] int sourceLineNumber = 0)
        {
            return RaiseFail<TContent>(id, content, new Error(message), memberName, sourceFilePath, sourceLineNumber);
        }

        /// <summary>Initialize Fails result.</summary>
        /// <typeparam name="TIdentifier">The type of the identifier.</typeparam>
        /// <typeparam name="TContent">The type of the content.</typeparam>
        /// <param name="id">The identifier.</param>
        /// <param name="content">The content.</param>
        /// <param name="message">The message.</param>
        /// <param name="memberName">Name of the member.</param>
        /// <param name="sourceFilePath">The source file path.</param>
        /// <param name="sourceLineNumber">The source line number.</param>
        /// <returns></returns>
        [NotNull]
        public static Result<TIdentifier,TContent> Fail<TIdentifier,TContent>([NotNull] TIdentifier id, [CanBeNull] TContent content, [NotNull] string message,
                                                                               [CallerMemberName] string memberName = "",
                                                                               [CallerFilePath] string sourceFilePath = "",
                                                                               [CallerLineNumber] int sourceLineNumber = 0)
        {
            return RaiseFail<TIdentifier,TContent>(id, content, new Error(message), memberName, sourceFilePath, sourceLineNumber);
        }

        /// <summary>Initialize Fails result.</summary>
        /// <typeparam name="TContent">The type of the content.</typeparam>
        /// <param name="id">The identifier.</param>
        /// <param name="content">The content.</param>
        /// <param name="message">The message.</param>
        /// <param name="eventId">The event identifier.</param>
        /// <param name="memberName">Name of the member.</param>
        /// <param name="sourceFilePath">The source file path.</param>
        /// <param name="sourceLineNumber">The source line number.</param>
        /// <returns></returns>
        [NotNull]
        public static Result<TContent> Fail<TContent>([NotNull] object id, [CanBeNull] TContent content, [NotNull] string message, EventId eventId,
                                                       [CallerMemberName] string memberName = "",
                                                       [CallerFilePath] string sourceFilePath = "",
                                                       [CallerLineNumber] int sourceLineNumber = 0)
        {
           return RaiseFail<TContent>(id, content, new Error(message, eventId), memberName, sourceFilePath, sourceLineNumber);
        }


        /// <summary>Initialize Fails result.</summary>
        /// <typeparam name="TIdentifier">The type of the identifier.</typeparam>
        /// <typeparam name="TContent">The type of the content.</typeparam>
        /// <param name="id">The identifier.</param>
        /// <param name="content">The content.</param>
        /// <param name="message">The message.</param>
        /// <param name="eventId">The event identifier.</param>
        /// <param name="memberName">Name of the member.</param>
        /// <param name="sourceFilePath">The source file path.</param>
        /// <param name="sourceLineNumber">The source line number.</param>
        /// <returns></returns>
        [NotNull]
        public static Result<TIdentifier,TContent> Fail<TIdentifier,TContent>([NotNull] TIdentifier id, [CanBeNull] TContent content, [NotNull] string message, EventId eventId,
                                                                               [CallerMemberName] string memberName = "",
                                                                               [CallerFilePath] string sourceFilePath = "",
                                                                               [CallerLineNumber] int sourceLineNumber = 0)
        {
            return RaiseFail<TIdentifier,TContent>(id, content, new Error(message, eventId), memberName, sourceFilePath, sourceLineNumber);
        }

        /// <summary>Initialize Fails result.</summary>
        /// <typeparam name="TContent">The type of the content.</typeparam>
        /// <param name="id">The identifier.</param>
        /// <param name="content">The content.</param>
        /// <param name="message">The message.</param>
        /// <param name="inner">The inner.</param>
        /// <param name="memberName">Name of the member.</param>
        /// <param name="sourceFilePath">The source file path.</param>
        /// <param name="sourceLineNumber">The source line number.</param>
        /// <returns></returns>
        [NotNull]
        public static Result<TContent> Fail<TContent>([NotNull] object id, [CanBeNull] TContent content, [NotNull] string message, [NotNull] IError inner,
                                                       [CallerMemberName] string memberName = "",
                                                       [CallerFilePath] string sourceFilePath = "",
                                                       [CallerLineNumber] int sourceLineNumber = 0)
        {
            return RaiseFail<TContent>(id, content, new Error(message, inner), memberName, sourceFilePath, sourceLineNumber);
        }

        /// <summary>Initialize Fails result.</summary>
        /// <typeparam name="TIdentifier">The type of the identifier.</typeparam>
        /// <typeparam name="TContent">The type of the content.</typeparam>
        /// <param name="id">The identifier.</param>
        /// <param name="content">The content.</param>
        /// <param name="message">The message.</param>
        /// <param name="inner">The inner.</param>
        /// <param name="memberName">Name of the member.</param>
        /// <param name="sourceFilePath">The source file path.</param>
        /// <param name="sourceLineNumber">The source line number.</param>
        /// <returns></returns>
        [NotNull]
        public static Result<TIdentifier,TContent> Fail<TIdentifier,TContent>([NotNull] TIdentifier id, [CanBeNull] TContent content, [NotNull] string message, [NotNull] IError inner,
                                                                               [CallerMemberName] string memberName = "",
                                                                               [CallerFilePath] string sourceFilePath = "",
                                                                               [CallerLineNumber] int sourceLineNumber = 0)
        {
            return RaiseFail<TIdentifier,TContent>(id, content, new Error(message, inner), memberName, sourceFilePath, sourceLineNumber);
        }

        /// <summary>Initialize Fails result.</summary>
        /// <typeparam name="TContent">The type of the content.</typeparam>
        /// <param name="id">The identifier.</param>
        /// <param name="content">The content.</param>
        /// <param name="message">The message.</param>
        /// <param name="eventId">The event identifier.</param>
        /// <param name="inner">The inner.</param>
        /// <param name="memberName">Name of the member.</param>
        /// <param name="sourceFilePath">The source file path.</param>
        /// <param name="sourceLineNumber">The source line number.</param>
        /// <returns></returns>
        [NotNull]
        public static Result<TContent> Fail<TContent>([NotNull] object id, [CanBeNull] TContent content,
                                                       [NotNull] string message, EventId eventId, IError inner,
                                                       [CallerMemberName] string memberName = "",
                                                       [CallerFilePath] string sourceFilePath = "",
                                                       [CallerLineNumber] int sourceLineNumber = 0)
        {
            return RaiseFail<TContent>(id, content, new Error(message, inner, eventId), memberName, sourceFilePath, sourceLineNumber);
        }

        /// <summary>Initialize Fails result.</summary>
        /// <typeparam name="TIdentifier">The type of the identifier.</typeparam>
        /// <typeparam name="TContent">The type of the content.</typeparam>
        /// <param name="id">The identifier.</param>
        /// <param name="content">The content.</param>
        /// <param name="message">The message.</param>
        /// <param name="eventId">The event identifier.</param>
        /// <param name="inner">The inner.</param>
        /// <param name="memberName">Name of the member.</param>
        /// <param name="sourceFilePath">The source file path.</param>
        /// <param name="sourceLineNumber">The source line number.</param>
        /// <returns></returns>
        [NotNull]
        public static Result<TIdentifier, TContent> Fail<TIdentifier, TContent>([NotNull] TIdentifier id, [CanBeNull] TContent content, [NotNull] string message, EventId eventId, IError inner,
                                                                                 [CallerMemberName] string memberName = "",
                                                                                 [CallerFilePath] string sourceFilePath = "",
                                                                                 [CallerLineNumber] int sourceLineNumber = 0)
        {
            return RaiseFail<TIdentifier,TContent>(id, content, new Error(message, inner, eventId), memberName, sourceFilePath, sourceLineNumber);
        }


        /// <summary>Initialize Fails result from other result.</summary>
        /// <typeparam name="TContent">The type of the content.</typeparam>
        /// <typeparam name="TOtherContent">The type of the other content.</typeparam>
        /// <param name="otherResultOnError">The other result on error.</param>
        /// <param name="memberName">Name of the member.</param>
        /// <param name="sourceFilePath">The source file path.</param>
        /// <param name="sourceLineNumber">The source line number.</param>
        /// <returns></returns>
        [NotNull]
        public static Result<TContent> FailFromResult<TContent,TOtherContent>([NotNull] IResult<TOtherContent> otherResultOnError,
                                                                              [CallerMemberName] string memberName = "",
                                                                              [CallerFilePath] string sourceFilePath = "",
                                                                              [CallerLineNumber] int sourceLineNumber = 0)
        {
            
            return RaiseFailFromResult<TContent,TOtherContent>(otherResultOnError, memberName, sourceFilePath, sourceLineNumber);
        }

        /// <summary>Initialize Fails result from other result.</summary>
        /// <typeparam name="TContent">The type of the content.</typeparam>
        /// <typeparam name="TOtherContent">The type of the other content.</typeparam>
        /// <param name="errorMessage">The error message.</param>
        /// <param name="otherResultOnError">The other result on error.</param>
        /// <param name="memberName">Name of the member.</param>
        /// <param name="sourceFilePath">The source file path.</param>
        /// <param name="sourceLineNumber">The source line number.</param>
        /// <returns></returns>
        [NotNull]
        public static Result<TContent> FailFromResult<TContent,TOtherContent>([NotNull] string errorMessage,[NotNull] IResult<TOtherContent> otherResultOnError,
                                                                              [CallerMemberName] string memberName = "",
                                                                              [CallerFilePath] string sourceFilePath = "",
                                                                              [CallerLineNumber] int sourceLineNumber = 0)
        {
            
            return RaiseFailFromResult<TContent,TOtherContent>(errorMessage,otherResultOnError, memberName, sourceFilePath, sourceLineNumber);
        }

        /// <summary>Initialize Fails result from other result.</summary>
        /// <typeparam name="TIdentifier">The type of the identifier.</typeparam>
        /// <typeparam name="TContent">The type of the content.</typeparam>
        /// <typeparam name="TOtherContent">The type of the other content.</typeparam>
        /// <param name="otherResultOnError">The other result on error.</param>
        /// <param name="memberName">Name of the member.</param>
        /// <param name="sourceFilePath">The source file path.</param>
        /// <param name="sourceLineNumber">The source line number.</param>
        /// <returns></returns>
        [NotNull]
        public static Result<TIdentifier,TContent> FailFromResult<TIdentifier,TContent,TOtherContent>([NotNull] IResult<TIdentifier,TOtherContent> otherResultOnError,
                                                                                                      [CallerMemberName] string memberName = "",
                                                                                                      [CallerFilePath] string sourceFilePath = "",
                                                                                                      [CallerLineNumber] int sourceLineNumber = 0)
        {
            
            return RaiseFailFromResult<TIdentifier,TContent,TOtherContent>(otherResultOnError, memberName, sourceFilePath, sourceLineNumber);
        }

        /// <summary>Initialize Fails result from other result.</summary>
        /// <typeparam name="TIdentifier">The type of the identifier.</typeparam>
        /// <typeparam name="TContent">The type of the content.</typeparam>
        /// <typeparam name="TOtherContent">The type of the other content.</typeparam>
        /// <param name="errorMessage">The error message.</param>
        /// <param name="otherResultOnError">The other result on error.</param>
        /// <param name="memberName">Name of the member.</param>
        /// <param name="sourceFilePath">The source file path.</param>
        /// <param name="sourceLineNumber">The source line number.</param>
        /// <returns></returns>
        [NotNull]
        public static Result<TIdentifier,TContent> FailFromResult<TIdentifier,TContent,TOtherContent>([NotNull] string errorMessage,[NotNull] IResult<TIdentifier,TOtherContent> otherResultOnError,
                                                                                                      [CallerMemberName] string memberName = "",
                                                                                                      [CallerFilePath] string sourceFilePath = "",
                                                                                                      [CallerLineNumber] int sourceLineNumber = 0)
        {
            
            return RaiseFailFromResult<TIdentifier,TContent,TOtherContent>(errorMessage,otherResultOnError, memberName, sourceFilePath, sourceLineNumber);
        }

        /// <summary>Initialize Fails result from exception.</summary>
        /// <typeparam name="TContent">The type of the content.</typeparam>
        /// <param name="id">The identifier.</param>
        /// <param name="exception">The exception.</param>
        /// <param name="eventId">The event identifier.</param>
        /// <returns></returns>
        [NotNull]
        public static Result<TContent> Fail<TContent>([NotNull] object id, [NotNull] Exception exception, EventId? eventId = null)
        {
            var e = Error.FromException(exception, eventId);
            return new ResultFail<TContent>(id, e);
        }
        /// <summary>Initialize Fails result from exception.</summary>
        /// <typeparam name="TIdentifier">The type of the identifier.</typeparam>
        /// <typeparam name="TContent">The type of the content.</typeparam>
        /// <param name="id">The identifier.</param>
        /// <param name="exception">The exception.</param>
        /// <param name="eventId">The event identifier.</param>
        /// <returns></returns>
        [NotNull]
        public static Result<TIdentifier,TContent> Fail<TIdentifier,TContent>([NotNull] TIdentifier id, [NotNull] Exception exception, EventId? eventId = null)
        {
            var e = Error.FromException(exception, eventId);
            return new ResultFail<TIdentifier,TContent>(id, e);
        }

        

        #endregion


        #region Error

        /// <summary>Builds the error.</summary>
        /// <param name="errorMessage">The error message.</param>
        /// <param name="memberName">Name of the member.</param>
        /// <param name="sourceFilePath">The source file path.</param>
        /// <param name="sourceLineNumber">The source line number.</param>
        /// <returns></returns>
        [NotNull]
        public static IError BuildError([NotNull] string errorMessage
                                        , [CallerMemberName] string memberName = "",
                                        [CallerFilePath] string sourceFilePath = "",
                                        [CallerLineNumber] int sourceLineNumber = 0)
        {
            return new MainError(memberName, sourceFilePath, sourceLineNumber, errorMessage);

        }
        /// <summary>Builds the error.</summary>
        /// <param name="errorMessage">The error message.</param>
        /// <param name="innerError">The inner error.</param>
        /// <returns></returns>
        [NotNull]
        public static IError BuildError([NotNull] string errorMessage, [NotNull] IError innerError)
        {
            //return new MainError(memberName, sourceFilePath, sourceLineNumber, errorMessage, innerError);
            return Error.Instance(errorMessage, innerError);
        }

        /// <summary>Builds the error.</summary>
        /// <param name="errorMessage">The error message.</param>
        /// <param name="eventId">The event identifier.</param>
        /// <param name="memberName">Name of the member.</param>
        /// <param name="sourceFilePath">The source file path.</param>
        /// <param name="sourceLineNumber">The source line number.</param>
        /// <returns></returns>
        [NotNull]
        public static IError BuildError([NotNull] string errorMessage, [NotNull] EventId eventId
                                        , [CallerMemberName] string memberName = "",
                                        [CallerFilePath] string sourceFilePath = "",
                                        [CallerLineNumber] int sourceLineNumber = 0)
        {
            return new MainError(memberName, sourceFilePath, sourceLineNumber, errorMessage, eventId);
        }

        /// <summary>Builds the error.</summary>
        /// <param name="errorMessage">The error message.</param>
        /// <param name="innerError">The inner error.</param>
        /// <param name="eventId">The event identifier.</param>
        /// <returns></returns>
        [NotNull]
        public static IError BuildError([NotNull] string errorMessage, [NotNull] IError innerError, [NotNull] EventId eventId)
        {
            return Error.Instance(errorMessage, innerError, eventId);
        }

        #endregion

    }
}