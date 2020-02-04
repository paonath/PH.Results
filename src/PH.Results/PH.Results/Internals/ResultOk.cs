namespace PH.Results.Internals
{
    internal class ResultOk<TIdentifier, TContent> : Result<TIdentifier, TContent>, IResultOk<TIdentifier, TContent>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="Result{TIdentifier, TContent}"/> class.
        /// </summary>
        /// <param name="identifier">The identifier.</param>
        /// <param name="content">The content.</param>
        internal ResultOk(TIdentifier identifier, TContent content) : base(identifier, content, null)
        {
        }
    }

    internal class ResultOk<TContent> : ResultOk<object, TContent>, IResultOk<TContent>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="Result{TIdentifier, TContent}"/> class.
        /// </summary>
        /// <param name="identifier">The identifier.</param>
        /// <param name="content">The content.</param>
        internal ResultOk(object identifier, TContent content) : base(identifier, content)
        {
        }
    }
}