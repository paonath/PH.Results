namespace PH.Results.Internals
{
    /// <summary>
    /// Generic Result Fail starting from another fail result
    /// </summary>
    /// <typeparam name="TIdentifier">The type of the identifier.</typeparam>
    /// <typeparam name="TContent">The type of the content.</typeparam>
    /// <typeparam name="TOtherContent">The type of the other content.</typeparam>
    /// <seealso cref="PH.Results.Internals.ResultFail{TIdentifier, TContent}" />
    /// <seealso cref="PH.Results.Internals.IResultFail{TIdentifier, TContent}" />
    /// <seealso cref="PH.Results.IResult{TIdentifier, TContent}" />
    internal class ResultChainFail<TIdentifier, TContent, TOtherContent> : ResultFail<TIdentifier, TContent>,
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
        internal ResultChainFail(TIdentifier identifier, TContent content, IError error, IResult<TIdentifier, TOtherContent> innerResultOnError) : base(identifier, content, error)
        {
            InnerResultOnError = innerResultOnError;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="Result{TIdentifier, TContent}"/> class on Error.
        /// </summary>
        /// <param name="identifier">The identifier.</param>
        /// <param name="error">The error.</param>
        /// <param name="innerResultOnError"></param>
        internal ResultChainFail(TIdentifier identifier, IError error, IResult<TIdentifier, TOtherContent> innerResultOnError) : base(identifier, error)
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
    internal class ResultChainFail<TContent, TOtherContent> : ResultChainFail<object, TContent, TOtherContent>,
                                                              IResultFail<TContent>, IResult<TContent>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="Result{TIdentifier, TContent}"/> class.
        /// </summary>
        /// <param name="identifier">The identifier.</param>
        /// <param name="content">The content.</param>
        /// <param name="error">The error.</param>
        /// <param name="innerResultOnError">The inner result on error</param>
        internal ResultChainFail(object identifier, TContent content, IError error, IResult<object, TOtherContent> innerResultOnError) : base(identifier, content, error, innerResultOnError)
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="Result{TIdentifier, TContent}"/> class on Error.
        /// </summary>
        /// <param name="identifier">The identifier.</param>
        /// <param name="error">The error.</param>
        /// <param name="innerResultOnError"></param>
        internal ResultChainFail(object identifier, IError error, IResult<object, TOtherContent> innerResultOnError) : base(identifier, error, innerResultOnError)
        {
        }
    }
}