using System;
using JetBrains.Annotations;

namespace PH.Results.Internals
{
    /// <summary>
    /// Implementation of Transport object result wrapping a contents
    /// </summary>
    /// <typeparam name="TIdentifier">The type of the identifier.</typeparam>
    /// <typeparam name="TContent"></typeparam>
    /// <seealso cref="PH.Results.IResult{TIdentifier, TContent}" />
    public abstract class Result<TIdentifier, TContent> : Result<TContent> , IResult<TIdentifier, TContent>
    {

        /// <summary>
        /// Initializes a new instance of the <see cref="Result{TIdentifier, TContent}"/> class.
        /// </summary>
        /// <param name="identifier">The identifier.</param>
        /// <param name="content">The content.</param>
        /// <param name="error">The error.</param>
        protected Result([NotNull] TIdentifier identifier, [NotNull] TContent content,  [CanBeNull] IError error = null) : base(identifier, content, error)
        {
            TypedIdentifier = identifier;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="Result{TContent}"/> class on Error.
        /// </summary>
        /// <param name="identifier">The identifier.</param>
        /// <param name="error">The error.</param>
        protected Result([NotNull] TIdentifier identifier, [NotNull] IError error) : base(identifier, error)
        {
            TypedIdentifier = identifier;
        }

        /// <summary>Gets the typed identifier.</summary>
        /// <value>The typed identifier.</value>
        public TIdentifier TypedIdentifier { get; }
    }

    /// <summary>
    /// Implementation of Transport object result wrapping a contents
    /// </summary>
    /// <typeparam name="TContent">The type of the content.</typeparam>
    /// <seealso cref="PH.Results.IResult{TIdentifier, TContent}" />
    public abstract class Result<TContent> : IResult<TContent> 
    {

        /// <summary>
        /// Initializes a new instance of the <see cref="Result{TContent}"/> class.
        /// </summary>
        /// <param name="identifier">The identifier.</param>
        /// <param name="content">The content.</param>
        /// <param name="error">The error.</param>
        protected internal Result([NotNull] object identifier, [NotNull] TContent content, [CanBeNull] IError error = null)
        {
            UtcTime    = DateTime.UtcNow;
            Identifier = identifier;
            Content = content;
            Error = error;
            _nullContent = false;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="Result{TContent}"/> class on Error.
        /// </summary>
        /// <param name="identifier">The identifier.</param>
        /// <param name="error">The error.</param>
        protected internal Result([NotNull] object identifier, [NotNull] IError error)
        {
            UtcTime = DateTime.UtcNow;
            Error = error;
            Identifier = identifier;
            _nullContent = true;
        }


        /// <summary>Gets the UTC time when the Result was generated.</summary>
        /// <value>The UTC time.</value>
        public DateTime UtcTime { get; }

        /// <summary>Gets the identifier.</summary>
        /// <value>The identifier.</value>
        public object Identifier { get; }

        /// <summary>
        /// Gets a value indicating whether on error.
        /// </summary>
        /// <value><c>true</c> if on error; otherwise, <c>false</c>.</value>
        public bool OnError => Error != null;

        /// <summary>Gets the error, if any.</summary>
        /// <value>The error.</value>
        public IError Error { get;  }

        /// <summary>
        /// Result Content
        /// </summary>
        public TContent Content { get;  }

        private readonly bool _nullContent;

        /// <summary>
        /// Gets a value indicating whether if content is set.
        /// </summary>
        /// <value>
        ///   <c>true</c> if null content [Content not set]; otherwise, <c>false</c>.
        /// </value>
        public bool NullContent => _nullContent;

        
    }


    
}