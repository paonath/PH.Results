namespace PH.Results.Internals
{
    internal class ResultChainFail<TIdentifier, TContent, TOtherContent> : ResultFail<TIdentifier, TContent>,
                                                                           IResultFail<TIdentifier, TContent>,
                                                                           IResult<TIdentifier, TContent>
    {
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