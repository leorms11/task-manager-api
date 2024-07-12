using Task = TaskManager.Application.Entities.Task;

namespace TaskManager.Application.Repositories;

public class TasksRepository
{
    private List<Task> _tasks = [];

    public Task Create(Task task)
    {
        _tasks.Add(task);
        return task;
    }

    public Task Update(Task task)
    {
        var taskIndex = _tasks.FindIndex(x => x.Id == task.Id);
        _tasks[taskIndex] = task;
        return task;
    }

    public Task? GetById(Guid taskId) => _tasks.Find(x => x.Id == taskId);

    public IEnumerable<Task> GetAll() => _tasks;

    public void Delete(Task task) => _tasks = _tasks.Where(x => x.Id != task.Id).ToList();
}