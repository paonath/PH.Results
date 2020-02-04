namespace PH.Results.Internals
{
    /// <summary>
    /// Generic Result Fail instance
    /// </summary>
    /// <typeparam name="TIdentifier">The type of the identifier.</typeparam>
    /// <typeparam name="TContent">The type of the content.</typeparam>
    /// <seealso cref="PH.Results.Internals.Result{TIdentifier, TContent}" />
    /// <seealso cref="PH.Results.Internals.IResultFail{TIdentifier, TContent}" />
    internal class ResultFail<TIdentifier, TContent> : Result<TIdentifier, TContent>, IResultFail<TIdentifier, TContent>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="Result{TIdentifier, TContent}"/> class.
        /// </summary>
        /// <param name="identifier">The identifier.</param>
        /// <param name="content">The content.</param>
        /// <param name="error">The error.</param>
        internal ResultFail(TIdentifier identifier, TContent content, IError error) : base(identifier, content, error)
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="Result{TIdentifier, TContent}"/> class on Error.
        /// </summary>
        /// <param name="identifier">The identifier.</param>
        /// <param name="error">The error.</param>
        internal ResultFail(TIdentifier identifier, IError error) : base(identifier, error)
        {
        }
    }

    /// <summary>
    /// Generic Result Fail instance
    /// </summary>
    /// <typeparam name="TContent">The type of the content.</typeparam>
    /// <seealso cref="PH.Results.Internals.Result{TIdentifier, TContent}" />
    /// <seealso cref="PH.Results.Internals.IResultFail{TIdentifier, TContent}" />
    internal class ResultFail<TContent> : ResultFail<object, TContent>, IResultFail<TContent>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="Result{TIdentifier, TContent}"/> class.
        /// </summary>
        /// <param name="identifier">The identifier.</param>
        /// <param name="content">The content.</param>
        /// <param name="error">The error.</param>
        internal ResultFail(object identifier, TContent content, IError error) : base(identifier, content, error)
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="Result{TIdentifier, TContent}"/> class on Error.
        /// </summary>
        /// <param name="identifier">The identifier.</param>
        /// <param name="error">The error.</param>
        internal ResultFail(object identifier, IError error) : base(identifier, error)
        {
        }
    }


}