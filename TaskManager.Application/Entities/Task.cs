using TaskManager.Communication.Enums;
using TaskManager.Communication.Requests;

namespace TaskManager.Application.Entities;

public class Task
{
    private Task(string name, string description, DateTime deadline,  PriorityType priority)
    {
        Name = name;
        Description = description;
        Deadline = deadline;
        Priority = priority;
    }
    
    public Guid Id { get; set; } = Guid.NewGuid();
    public string Name { get; set; } = string.Empty;
    public string Description { get; set; } = string.Empty;
    public DateTime Deadline { get; set; }
    public PriorityType Priority { get; set; }
    public StatusType Status { get; set; } = StatusType.Waiting;

    public static Task Create(RegisterTaskRequest task) =>
        new(task.Name, task.Description, task.Deadline, task.Priority);
    
    public void Update(UpdateTaskRequest task)
    {
        Name = task.Name;
        Description = task.Description;
        Deadline = task.Deadline;
        Priority = task.Priority;
        Status = task.Status;
    }
}