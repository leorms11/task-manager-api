using Microsoft.AspNetCore.Mvc;
using TaskManager.Application.UseCases.Tasks;
using TaskManager.Communication.Requests;
using TaskManager.Communication.Responses;

namespace TaskManager.Api.Controllers;

[Route("api/[controller]")]
[ApiController]
public class TasksController(CreateTaskUseCase createTaskUseCase, GetAllTasksUseCase getAllTasksUseCase,
    UpdateTaskUseCase updateTaskUseCase, GetTaskByIdUseCase getTaskByIdUseCase,
    DeleteTaskUseCase deleteTaskUseCase) : ControllerBase
{
    [HttpPost]
    [ProducesResponseType(typeof(TaskResponse), StatusCodes.Status201Created)]
    [ProducesResponseType(typeof(ErrorsResponse), StatusCodes.Status400BadRequest)]
    public IActionResult Create([FromBody] RegisterTaskRequest request)
    {
        var response = createTaskUseCase.Execute(request);
        return Created(string.Empty, response);
    }
    
    [HttpGet]
    [ProducesResponseType(typeof(TaskResponse), StatusCodes.Status200OK)]
    public IActionResult GetAll()
    {
        var response = getAllTasksUseCase.Execute();
        return Ok(response);
    }
    
    [HttpPut("{taskId}")]
    [ProducesResponseType(typeof(TaskResponse), StatusCodes.Status200OK)]
    [ProducesResponseType(typeof(ErrorsResponse), StatusCodes.Status400BadRequest)]
    [ProducesResponseType(typeof(ErrorsResponse), StatusCodes.Status404NotFound)]
    public IActionResult Update([FromRoute] Guid taskId, [FromBody] UpdateTaskRequest request)
    {
        var response = updateTaskUseCase.Execute(taskId, request);
        return Ok(response);
    }
    
    [HttpGet("{taskId}")]
    [ProducesResponseType(typeof(TaskResponse), StatusCodes.Status200OK)]
    [ProducesResponseType(typeof(ErrorsResponse), StatusCodes.Status404NotFound)]
    public IActionResult GetById([FromRoute] Guid taskId)
    {
        var response = getTaskByIdUseCase.Execute(taskId);
        return Ok(response);
    }
    
    [HttpDelete("{taskId}")]
    [ProducesResponseType(typeof(TaskResponse), StatusCodes.Status200OK)]
    [ProducesResponseType(typeof(ErrorsResponse), StatusCodes.Status404NotFound)]
    public IActionResult Delete([FromRoute] Guid taskId)
    {
        deleteTaskUseCase.Execute(taskId);
        return NoContent();
    }
}