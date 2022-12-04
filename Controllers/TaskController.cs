using Microsoft.AspNetCore.Mvc;
using System.Net;
using TestTaskITPD.Service.Interfaces.Implementations;
using Task = TestTaskITPD.Domain.Entity.Task;

namespace TestTaskITPD.Controllers;

public class TaskController : Controller
{
    private readonly ITaskService _taskService;

    public TaskController(ITaskService taskService)
    {
        _taskService = taskService;
    }

    //Get
    [HttpGet]
    public async Task<IActionResult> GetTasksByProject(Guid id)
    {
        var response = await _taskService.GetAllByProject(id);
        if (response.StatusCode == HttpStatusCode.OK)
        {
            return StatusCode((int)response.StatusCode, response.Data);
        }

        return StatusCode((int)response.StatusCode);
    }

    //Post
    [HttpPost]
    public async Task<IActionResult> Edit(Task model)
    {
        if (ModelState.IsValid)
        {
            var response = await _taskService.Edit(model.Id, model);

            return StatusCode((int)response.StatusCode);
        }

        return BadRequest();
    }

    //Get
    [HttpGet]
    public async Task<IActionResult> GetRemainTime(Guid taskId)
    {
        var response = await _taskService.GetRemainTimeByTask(taskId);
        if (response.StatusCode == HttpStatusCode.OK)
        {
            return StatusCode((int)response.StatusCode, response.Data);
        }

        return StatusCode((int)response.StatusCode);
    }

    //Get
    [HttpGet]
    public async Task<IActionResult> GetTotalSpentTimeByProject(Guid projectId)
    {
        var response = await _taskService.GetTotalTimeSpentByProject(projectId);
        return StatusCode((int)response.StatusCode, response.Data);
    }

    //Post
    [HttpPost]
    public async Task<IActionResult> Create(Task model)
    {
        if (!ModelState.IsValid)
        {
            return BadRequest();
        }
        model.Id = Guid.NewGuid();
        model.CreateDate = DateTime.Now;
        model.UpdateDate = DateTime.Now;

        var response = await _taskService.Create(model);
        return response.StatusCode == HttpStatusCode.OK ? StatusCode((int)response.StatusCode, response.Data) : BadRequest();
    }

    //Get
    [HttpGet]
    public async Task<IActionResult> GetTaskById(Guid id)
    {
        var response = await _taskService.Get(id);
        return response.StatusCode == HttpStatusCode.OK ? StatusCode((int)response.StatusCode, response.Data) : BadRequest();
    }
}