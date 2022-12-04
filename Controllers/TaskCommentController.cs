using Microsoft.AspNetCore.Mvc;
using System.Net;
using TestTaskITPD.Domain.Entity;
using TestTaskITPD.Service.Interfaces.Implementations;

namespace TestTaskITPD.Controllers;

public class TaskCommentController : Controller
{
    private readonly ITaskCommentService _taskCommentService;

    public TaskCommentController(ITaskCommentService taskCommentService)
    {
        _taskCommentService = taskCommentService;
    }

    [HttpPost]
    public async Task<IActionResult> EditComment(TaskComment model)
    {
        if (!ModelState.IsValid) return BadRequest();
        var response = await _taskCommentService.Edit(model.TaskId, model);

        return StatusCode((int)response.StatusCode);
    }

    [HttpPost]
    public async Task<IActionResult> CreateComment([FromForm] TaskComment model)
    {
        if (!ModelState.IsValid) return BadRequest();

        var response = await _taskCommentService.Create(model);
        return StatusCode((int)response.StatusCode);
    }

    [HttpGet]
    public async Task<IActionResult> GetCommentByProject(Guid id)
    {
        var response = await _taskCommentService.Get(id);
        if (response.StatusCode == HttpStatusCode.OK)
        {
            return StatusCode((int)response.StatusCode, response.Data);
        }

        return StatusCode((int)response.StatusCode);
    }
}