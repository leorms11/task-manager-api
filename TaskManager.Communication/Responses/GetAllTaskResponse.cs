namespace TaskManager.Communication.Responses;

public class GetAllTaskResponse
{
    public IEnumerable<TaskShortResponse> Tasks { get; set; } = [];
}