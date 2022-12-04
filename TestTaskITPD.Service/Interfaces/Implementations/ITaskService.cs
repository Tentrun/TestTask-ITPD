using TestTaskITPD.Domain.Response;
using TestTaskITPD.Service.Interfaces.BaseIntefaces;
using Task = TestTaskITPD.Domain.Entity.Task;

namespace TestTaskITPD.Service.Interfaces.Implementations;

public interface ITaskService : IBaseService<Task>
{
    public Task<IBaseResponse<Task>> Edit(Guid id, Task entity);
    public Task<IBaseResponse<IEnumerable<Task>>> GetAllByProject(Guid id);
    public Task<IBaseResponse<string>> GetTotalTimeSpentByProject(Guid id);
    public Task<IBaseResponse<string>> GetRemainTimeByTask(Guid id);
}