using System.Net;

namespace FancyWebApp.Exceptions;

public class NotFoundException : ServiceException
{
    public NotFoundException(string message, Exception? e = null) : base(message, e)
    {
    }

    public override int StatusCode => (int)HttpStatusCode.NotFound;
}