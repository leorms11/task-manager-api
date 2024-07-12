using TaskManager.Communication.Enums;

namespace TaskManager.Communication.Requests;

public abstract class BaseTaskRequest
{
    private readonly List<string> _validationErrors = [];  
    
    public string Name { get; set; } = string.Empty;
    public string Description { get; set; } = string.Empty;
    public DateTime Deadline { get; set; }
    public PriorityType Priority { get; set; } = PriorityType.Low; 
    
    public bool IsValid()
    {
        if (string.IsNullOrEmpty(Name))
            _validationErrors.Add("Invalid name!");
        
        if (string.IsNullOrEmpty(Description))
            _validationErrors.Add("Invalid description!");
        
        if (Deadline < DateTime.Now)
            _validationErrors.Add("The Deadline date has to be greater than today");

        return _validationErrors.Count == 0;
    }

    public IEnumerable<string> GetErrors() => _validationErrors;
}