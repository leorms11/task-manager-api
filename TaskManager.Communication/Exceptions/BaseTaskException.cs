using System.Net;

namespace TaskManager.Communication.Exceptions;

public class BaseTaskException(string message, HttpStatusCode statusCode, IEnumerable<string> errors = default) : Exception(message)
{
    public readonly HttpStatusCode StatusCode = statusCode;
    public readonly IEnumerable<string> Errors = errors;
}