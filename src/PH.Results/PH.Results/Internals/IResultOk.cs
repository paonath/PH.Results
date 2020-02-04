namespace PH.Results.Internals
{
    /// <summary>
    /// Generic Result Ok
    /// </summary>
    /// <typeparam name="TIdentifier">The type of the identifier.</typeparam>
    /// <typeparam name="TContent">Type of the Result content</typeparam>
    public interface IResultOk<out TIdentifier, out TContent> : IResult<TIdentifier,TContent> 
    {
        

    }

    /// <summary>
    /// Generic Result Ok
    /// </summary>
    /// <typeparam name="TContent">Type of the Result content</typeparam>
    public interface IResultOk<out TContent> : IResultOk<object,TContent> , IResult<TContent>
    {
        
    }
}