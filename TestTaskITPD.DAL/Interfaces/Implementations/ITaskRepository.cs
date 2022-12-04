using TestTaskITPD.DAL.Interfaces.BaseInterfaces;
using Task = TestTaskITPD.Domain.Entity.Task;

namespace TestTaskITPD.DAL.Interfaces.Implementations;

public interface ITaskRepository : IRepository<Task>
{
    Task<List<Task>> SelectByProject(Guid id);
    Task<Task> Update(Task entity);
}