using TaskManager.Communication.Enums;

namespace TaskManager.Communication.Requests;

public class UpdateTaskRequest : BaseTaskRequest
{
    public StatusType Status { get; set; } = StatusType.Waiting;
}