using TestTaskITPD.DAL.Interfaces.BaseInterfaces;
using TestTaskITPD.Domain.Entity;

namespace TestTaskITPD.DAL.Interfaces.Implementations;

public interface ITaskCommentRepository : IRepository<TaskComment>
{
    Task<List<TaskComment>> SelectByTask(Guid id);
    Task<TaskComment> Update(TaskComment entity);
}