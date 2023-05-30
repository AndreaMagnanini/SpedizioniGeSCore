using System.Net;

namespace FancyWebApp.Exceptions;

public class UnauthorizedException : ServiceException
{
    public UnauthorizedException(HttpRequestMessage message, Exception? e = null) : base(message, e)
    {
    }
    public override int StatusCode => (int)HttpStatusCode.Unauthorized;
}