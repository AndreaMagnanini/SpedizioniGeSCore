using System.Net;

namespace FancyWebApp.Exceptions;

public class ForbiddenException : ServiceException
{
    public ForbiddenException(HttpRequestMessage message, Exception? e = null) : base(message, e)
    {
    }

    public override int StatusCode => (int)HttpStatusCode.Forbidden;
}