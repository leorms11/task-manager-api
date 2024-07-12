using TaskManager.Application.Repositories;
using TaskManager.Communication.Exceptions;
using TaskManager.Communication.Requests;
using TaskManager.Communication.Responses;
using Task = TaskManager.Application.Entities.Task;

namespace TaskManager.Application.UseCases.Tasks;

public class CreateTaskUseCase(TasksRepository tasksRepository)
{
    public TaskResponse Execute(RegisterTaskRequest request)
    {
        if (!request.IsValid())
            throw new TaskValidationException(request.GetErrors());
        
        var task = Task.Create(request);
        tasksRepository.Create(task);

        return new()
        {
            Id = task.Id,
            Name = task.Name,
            Description = task.Description,
            Deadline = task.Deadline,
            Priority = task.Priority,
            Status = task.Status
        };
    }
}