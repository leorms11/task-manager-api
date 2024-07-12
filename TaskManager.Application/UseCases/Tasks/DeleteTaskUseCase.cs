using TaskManager.Application.Repositories;
using TaskManager.Communication.Exceptions;

namespace TaskManager.Application.UseCases.Tasks;

public class DeleteTaskUseCase(TasksRepository tasksRepository)
{
    public void Execute(Guid taskId)
    {
        var task = tasksRepository.GetById(taskId)
            ?? throw new TaskNotFoundException();

        tasksRepository.Delete(task);
    }
}