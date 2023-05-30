using System.Net;

namespace FancyWebApp.Exceptions;

public class BadRequestException : ServiceException
{
    public BadRequestException(string message, Exception? e = null) : base(message, e)
    {
    }

    public override int StatusCode => (int)HttpStatusCode.BadRequest;
}