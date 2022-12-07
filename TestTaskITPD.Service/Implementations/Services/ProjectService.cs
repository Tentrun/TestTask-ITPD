using System.Net;
using TestTaskITPD.DAL.Interfaces.Implementations;
using TestTaskITPD.Domain.Entity;
using TestTaskITPD.Domain.Entity.Exception;
using TestTaskITPD.Domain.Response;
using TestTaskITPD.Service.Interfaces.Implementations;

namespace TestTaskITPD.Service.Implementations.Services;

public class ProjectService : IProjectService
{
    private readonly IProjectRepository _projectRepository;

    public ProjectService(IProjectRepository projectRepository)
    {
        _projectRepository = projectRepository;
    }

    public async Task<IBaseResponse<IEnumerable<Project>>> GetAll()
    {
        var baseResponse = new BaseResponse<IEnumerable<Project>>();
        var projects = await _projectRepository.Select();

        baseResponse.Data = projects;
        baseResponse.StatusCode = HttpStatusCode.OK;

        return baseResponse;
    }

    public async Task<IBaseResponse<Project>> Get(Guid id)
    {
        var baseResponse = new BaseResponse<Project>();
        var project = await _projectRepository.Get(id);

        baseResponse.Data = project;
        baseResponse.StatusCode = HttpStatusCode.OK;

        return baseResponse;
    }

    public async Task<IBaseResponse<bool>> Delete(Guid id)
    {
        var baseResponse = new BaseResponse<bool>();
        var project = await _projectRepository.Get(id);
        
        await _projectRepository.Delete(project);

        baseResponse.StatusCode = HttpStatusCode.OK;
        return baseResponse;
    }

    public async Task<IBaseResponse<Project>> Create(Project _project)
    {
        var baseResponse = new BaseResponse<Project>();
        var project = new Project
        {
            Id = _project.Id,
            ProjectName = _project.ProjectName,
            CreateDate = _project.CreateDate,
            UpdateDate = _project.UpdateDate
        };

        baseResponse.StatusCode = HttpStatusCode.Created;

        await _projectRepository.Create(project);
        return baseResponse;
    }

    public Task<IBaseResponse<Project>> Edit(Guid id, Project project)
    {
        throw new NotImplementedException();
    }
}