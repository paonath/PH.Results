using JetBrains.Annotations;

namespace PH.Results.Internals
{
    /// <summary>
    /// Generic Result Ok instance
    /// </summary>
    /// <typeparam name="TIdentifier">The type of the identifier.</typeparam>
    /// <typeparam name="TContent">The type of the content.</typeparam>
    /// <seealso cref="PH.Results.Internals.Result{TIdentifier, TContent}" />
    /// <seealso cref="PH.Results.Internals.IResultOk{TIdentifier, TContent}" />
    internal class ResultOk<TIdentifier, TContent> : Result<TIdentifier, TContent>, IResultOk<TIdentifier, TContent> , IResult<TIdentifier,TContent>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="Result{TIdentifier, TContent}"/> class.
        /// </summary>
        /// <param name="identifier">The identifier.</param>
        /// <param name="content">The content.</param>
        internal ResultOk([NotNull] TIdentifier identifier, [NotNull] TContent content) : base(identifier, content, null)
        {
        }
    }

    /// <summary>
    /// Generic Result Ok instance
    /// </summary>
    /// <typeparam name="TContent">The type of the content.</typeparam>
    /// <seealso cref="PH.Results.Internals.Result{TIdentifier, TContent}" />
    /// <seealso cref="PH.Results.Internals.IResultOk{TIdentifier, TContent}" />
    internal class ResultOk<TContent> : Result<TContent>, IResultOk<TContent>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="Result{TIdentifier, TContent}"/> class.
        /// </summary>
        /// <param name="identifier">The identifier.</param>
        /// <param name="content">The content.</param>
        internal ResultOk([NotNull] object identifier, [NotNull] TContent content) 
            : base(identifier, content)
        {
        }
    }
}