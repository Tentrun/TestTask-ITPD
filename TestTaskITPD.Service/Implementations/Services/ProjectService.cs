using System.Net;
using TestTaskITPD.DAL.Interfaces.Implementations;
using TestTaskITPD.Domain.Entity;
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
        try
        {
            var projects = await _projectRepository.Select();
            
            if (projects.Count is 0)
            {
                baseResponse.Description = "Проекты отсутствуют";
                baseResponse.StatusCode = HttpStatusCode.OK;
                return baseResponse;
            }

            baseResponse.Data = projects;
            baseResponse.StatusCode = HttpStatusCode.OK;
            
            return baseResponse;
        }
        catch (Exception ex)
        {
            return new BaseResponse<IEnumerable<Project>>()
            {
                Description = ex.Message,
                StatusCode = HttpStatusCode.InternalServerError
            };
        }
    }

    public async Task<IBaseResponse<Project>> Get(Guid id)
    {
        var baseResponse = new BaseResponse<Project>();
        try
        {
            var project = await _projectRepository.Get(id);
            
            if (project is null)
            {
                baseResponse.Description = "Проект не найден";
                baseResponse.StatusCode = HttpStatusCode.NotFound;
                return baseResponse;
            }

            baseResponse.Data = project;
            baseResponse.StatusCode = HttpStatusCode.OK;

            return baseResponse;
        }
        catch (Exception ex)
        {
            return new BaseResponse<Project>()
            {
                Description = ex.Message,
                StatusCode = HttpStatusCode.InternalServerError
            };
        }
    }

    public async Task<IBaseResponse<bool>> Delete(Guid id)
    {
        var baseResponse = new BaseResponse<bool>();
        
        try
        {
            var project = await _projectRepository.Get(id);
            if (project is null)
            {
                baseResponse.Description = "Проект не найден";
                baseResponse.StatusCode = HttpStatusCode.NotFound;
                return baseResponse;
            }

            await _projectRepository.Delete(project);

            baseResponse.StatusCode = HttpStatusCode.OK;
        }
        catch (Exception ex)
        {
            return new BaseResponse<bool>()
            {
                Description = ex.Message,
                StatusCode = HttpStatusCode.InternalServerError
            };
        }
        return baseResponse;
    }

    public async Task<IBaseResponse<Project>> Create(Project _project)
    {
        var baseResponse = new BaseResponse<Project>();
        try
        {
            var project = new Project()
            {
                Id = _project.Id,
                ProjectName = _project.ProjectName,
                CreateDate = _project.CreateDate,
                UpdateDate = _project.UpdateDate
            };

            baseResponse.StatusCode = HttpStatusCode.Created;
            
            await _projectRepository.Create(project);
        }
        catch (Exception ex)
        {
            return new BaseResponse<Project>()
            {
                Description = ex.Message,
                StatusCode = HttpStatusCode.InternalServerError
            };
        }
        return baseResponse;
    }

    public Task<IBaseResponse<Project>> Edit(Guid id, Project project)
    {
        throw new NotImplementedException();
    }
}