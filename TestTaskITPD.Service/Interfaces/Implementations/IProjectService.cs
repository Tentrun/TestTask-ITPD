using TestTaskITPD.Domain.Entity;
using TestTaskITPD.Domain.Response;
using TestTaskITPD.Service.Interfaces.BaseIntefaces;

namespace TestTaskITPD.Service.Interfaces.Implementations;

public interface IProjectService : IBaseService<Project>
{
    public Task<IBaseResponse<Project>> Edit(Guid id, Project entity);
}