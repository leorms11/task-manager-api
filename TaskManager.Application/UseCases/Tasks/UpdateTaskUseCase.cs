using TaskManager.Application.Repositories;
using TaskManager.Communication.Exceptions;
using TaskManager.Communication.Requests;
using TaskManager.Communication.Responses;

namespace TaskManager.Application.UseCases.Tasks;

public class UpdateTaskUseCase(TasksRepository tasksRepository)
{
    public TaskResponse Execute(Guid taskId, UpdateTaskRequest request)
    {
        if (!request.IsValid())
            throw new TaskValidationException(request.GetErrors());

        var task = tasksRepository.GetById(taskId)
            ?? throw new TaskNotFoundException();
        
        task.Update(request);
        tasksRepository.Update(task);

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