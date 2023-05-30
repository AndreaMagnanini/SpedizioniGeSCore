using System.Net;

namespace FancyWebApp.Exceptions;

public class GenericException : ServiceException
{
    public GenericException(HttpRequestMessage message, Exception? e = null) : base(message, e)
    {
    }

    public override int StatusCode => (int)HttpStatusCode.InternalServerError;
}