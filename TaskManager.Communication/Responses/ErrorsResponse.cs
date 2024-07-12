namespace TaskManager.Communication.Responses;

public class ErrorsResponse
{
    public string Message { get; init; }
    public IEnumerable<string> RejectionReasons { get; init; }
}