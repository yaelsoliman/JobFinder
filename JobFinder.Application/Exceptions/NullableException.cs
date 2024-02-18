using System.Net;

namespace JobFinder.Application.Exceptions;

public class NullableException : CustomException
{
    public NullableException(string message)
        : base(message, null, HttpStatusCode.BadRequest)
    {
    }
}