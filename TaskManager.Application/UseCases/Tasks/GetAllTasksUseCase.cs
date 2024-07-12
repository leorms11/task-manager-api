using TaskManager.Application.Repositories;
using TaskManager.Communication.Responses;

namespace TaskManager.Application.UseCases.Tasks;

public class GetAllTasksUseCase(TasksRepository tasksRepository)
{
    public GetAllTaskResponse Execute()
    {
        var tasks = tasksRepository.GetAll();

        if (tasks.Any())
            return new()
            {
                Tasks = tasks.Select(x => new TaskShortResponse()
                {
                    Id = x.Id,
                    Name = x.Name,
                    Priority = x.Priority,
                    Status = x.Status
                })
            };

        return new GetAllTaskResponse();
    }
}