using TaskManager.Communication.Enums;

namespace TaskManager.Communication.Responses;

public class TaskShortResponse
{
    public Guid Id { get; init; } = Guid.NewGuid();
    public string Name { get; init; } = string.Empty;
    public PriorityType Priority { get; init; }
    public StatusType Status { get; init; }
}