namespace FancyWebApp.Exceptions;

public class ServiceException : Exception
{
    private protected ServiceException(string message, Exception? e = null) : base(message, e)
    {
        
    }
    private protected ServiceException(HttpRequestMessage message, Exception? e = null) : base(message.ToString(), e)
    {
        
    }

    public override string ToString() => this.Message;
    public virtual int StatusCode => throw new NotImplementedException();
}