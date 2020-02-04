using System;

namespace PH.Results
{
    
    /// <summary>
    /// Transport object result wrapping a contents
    /// </summary>
    /// <typeparam name="TIdentifier">The type of the identifier.</typeparam>
    /// <typeparam name="TContent">Type of the Result content</typeparam>
    public interface IResult<out TIdentifier, out TContent> 
    {
        /// <summary>Gets the identifier.</summary>
        /// <value>The identifier.</value>
        TIdentifier Identifier { get; }

        /// <summary>Gets the UTC time when the Result was generated.</summary>
        /// <value>The UTC time.</value>
        DateTime UtcTime { get; }

        /// <summary>
        /// Gets a value indicating whether if content is set.
        /// </summary>
        /// <value><c>true</c> if null content [Content not set]; otherwise, <c>false</c>.</value>
        bool NullContent { get; }


        /// <summary>
        /// Gets a value indicating whether on error.
        /// </summary>
        /// <value><c>true</c> if on error; otherwise, <c>false</c>.</value>
        bool OnError { get; }

        

        /// <summary>Gets the error, if any.</summary>
        /// <value>The error.</value>
        IError Error { get; }

        /// <summary>
        /// Result Content
        /// </summary>
        TContent Content { get; }
    }

    /// <summary>
    /// Transport object result wrapping a contents
    /// </summary>
    /// <typeparam name="TContent">Type of the Result content</typeparam>
    public interface IResult<out TContent> : IResult<object,TContent>
    {
        
    }


    




    

    
}
