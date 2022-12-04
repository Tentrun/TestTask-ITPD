using Microsoft.AspNetCore.Mvc;
using System.Net;
using TestTaskITPD.Domain.Entity;
using TestTaskITPD.Service.Interfaces.Implementations;

namespace TestTaskITPD.Controllers;

public class ProjectController : Controller
{
    private readonly IProjectService _projectService;

    public ProjectController(IProjectService projectService)
    {
        _projectService = projectService;
    }

    //GET
    [HttpGet]
    public async Task<IActionResult> GetProjects()
    {
        var response = await _projectService.GetAll();

        if (response.StatusCode == HttpStatusCode.OK)
        {
            return StatusCode((int)response.StatusCode, response.Data);
        }
        return StatusCode((int)response.StatusCode);
    }

    //Get
    [HttpGet]
    public async Task<IActionResult> GetProject(Guid id)
    {
        var response = await _projectService.Get(id);
        if (response.StatusCode == HttpStatusCode.OK)
        {
            return StatusCode((int)response.StatusCode, response.Data);
        }

        return StatusCode((int)response.StatusCode);
    }

    //Delete
    [HttpDelete]
    public async Task<IActionResult> Delete(Guid id)
    {
        var response = await _projectService.Delete(id);

        return StatusCode((int)response.StatusCode);
    }

    //Post
    public async Task<IActionResult> Create(string projectName)
    {
        if (string.IsNullOrEmpty(projectName))
        {
            return BadRequest();
        }

        var projectModel = new Project()
        {
            Id = Guid.NewGuid(),
            ProjectName = projectName,
            CreateDate = DateTime.Now,
            UpdateDate = DateTime.Now
        };
        var response = await _projectService.Create(projectModel);

        return StatusCode((int)response.StatusCode);
    }
}