using System.Net;

namespace FancyWebApp.Exceptions;

public class ConflictException : ServiceException
{
    public ConflictException(HttpRequestMessage message, Exception? e = null) : base(message, e)
    {
    }
    public override int StatusCode => (int)HttpStatusCode.Conflict;
}