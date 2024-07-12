using System.Net;

namespace TaskManager.Communication.Exceptions;

public class TaskValidationException(IEnumerable<string> errors) : BaseTaskException(ResourceErrorMessages
        .ERROR_ON_REQUEST_VALIDATE, HttpStatusCode.BadRequest, errors);