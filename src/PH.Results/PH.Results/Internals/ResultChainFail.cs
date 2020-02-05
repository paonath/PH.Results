using JetBrains.Annotations;

namespace PH.Results.Internals
{
    internal class ResultChainFail<TIdentifier, TContent, TOtherContent> : ResultFail<TIdentifier,TContent>,
                                                                           IResultFail<TIdentifier, TContent>,
                                                                           IResult<TIdentifier, TContent>
    {
        /// <summary>Gets the inner result on error.</summary>
        /// <value>The inner result on error.</value>
        public IResult<TIdentifier, TOtherContent> InnerResultOnError { get; }

        /// <summary>
        /// Initializes a new instance of the <see cref="Result{TIdentifier, TContent}"/> class.
        /// </summary>
        /// <param name="identifier">The identifier.</param>
        /// <param name="content">The content.</param>
        /// <param name="error">The error.</param>
        /// <param name="innerResultOnError">The inner result on error</param>
        internal ResultChainFail([NotNull] TIdentifier identifier, [NotNull] TContent content, IError error, IResult<TIdentifier,TOtherContent> innerResultOnError) : base(identifier, content, error)
        {
            InnerResultOnError = innerResultOnError;
        }


        /// <summary>
        /// Initializes a new instance of the <see cref="Result{TIdentifier, TContent}"/> class on Error.
        /// </summary>
        /// <param name="identifier">The identifier.</param>
        /// <param name="error">The error.</param>
        /// <param name="innerResultOnError"></param>
        internal ResultChainFail([NotNull] TIdentifier identifier, [NotNull] IError error, IResult<TIdentifier, TOtherContent> innerResultOnError) : base(identifier, error)
        {
            InnerResultOnError = innerResultOnError;
        }

      
    }

    /// <summary>
    /// Generic Result Fail starting from another fail result
    /// </summary>
    /// <typeparam name="TContent">The type of the content.</typeparam>
    /// <typeparam name="TOtherContent">The type of the other content.</typeparam>
    /// <seealso cref="PH.Results.Internals.ResultFail{TIdentifier, TContent}" />
    /// <seealso cref="PH.Results.Internals.IResultFail{TIdentifier, TContent}" />
    /// <seealso cref="PH.Results.IResult{TIdentifier, TContent}" />
    internal class ResultChainFail<TContent, TOtherContent> : ResultFail<TContent>,
                                                              IResultFail<TContent>, IResult<TContent>
    {
        /// <summary>Gets the inner result on error.</summary>
        /// <value>The inner result on error.</value>
        public IResult<TOtherContent> InnerResultOnError { get; }

        /// <summary>
        /// Initializes a new instance of the <see cref="Result{TIdentifier, TContent}"/> class.
        /// </summary>
        /// <param name="identifier">The identifier.</param>
        /// <param name="content">The content.</param>
        /// <param name="error">The error.</param>
        /// <param name="innerResultOnError">The inner result on error</param>
        internal ResultChainFail([NotNull] object identifier, [NotNull] TContent content, IError error, IResult<TOtherContent> innerResultOnError) : base(identifier, content, error)
        {
            InnerResultOnError = innerResultOnError;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="Result{TIdentifier, TContent}"/> class on Error.
        /// </summary>
        /// <param name="identifier">The identifier.</param>
        /// <param name="error">The error.</param>
        /// <param name="innerResultOnError"></param>
        internal ResultChainFail([NotNull] object identifier, [NotNull] IError error, IResult<TOtherContent> innerResultOnError) : base(identifier, error)
        {
            InnerResultOnError = innerResultOnError;
        }
    }
}