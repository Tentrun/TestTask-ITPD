using TestTaskITPD.Domain.Entity;
using TestTaskITPD.Domain.Response;
using TestTaskITPD.Service.Interfaces.BaseIntefaces;

namespace TestTaskITPD.Service.Interfaces.Implementations;

public interface ITaskCommentService : IBaseService<TaskComment>
{ 
    public Task<IBaseResponse<IEnumerable<TaskComment>>> GetAllByTask(Guid id);
    public Task<IBaseResponse<TaskComment>> Edit(Guid id, TaskComment entity);
}