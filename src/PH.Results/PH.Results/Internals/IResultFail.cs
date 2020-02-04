namespace PH.Results.Internals
{
    /// <summary>
    /// Generic Result Fail
    /// </summary>
    /// <typeparam name="TIdentifier">The type of the identifier.</typeparam>
    /// <typeparam name="TContent">Type of the Result content</typeparam>
    public interface IResultFail<out TIdentifier, out TContent> : IResult<TIdentifier,TContent> 
    {

    }

    /// <summary>
    /// Generic Result Fail
    /// </summary>
    /// <typeparam name="TContent">Type of the Result content</typeparam>
    public interface IResultFail<out TContent> : IResultFail<object,TContent> , IResult<TContent> 
    {
        
    }

}