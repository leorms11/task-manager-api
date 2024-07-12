using System.Net;

namespace TaskManager.Communication.Exceptions;

public class TaskNotFoundException() : BaseTaskException(ResourceErrorMessages
        .TASK_NOT_FOUND, HttpStatusCode.NotFound);