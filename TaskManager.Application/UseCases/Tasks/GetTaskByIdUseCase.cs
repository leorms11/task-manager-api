using TaskManager.Application.Repositories;
using TaskManager.Communication.Exceptions;
using TaskManager.Communication.Responses;

namespace TaskManager.Application.UseCases.Tasks;

public class GetTaskByIdUseCase(TasksRepository tasksRepository)
{
    public TaskResponse Execute(Guid taskId)
    {
        var task = tasksRepository.GetById(taskId)
            ?? throw new TaskNotFoundException();

        return new TaskResponse
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