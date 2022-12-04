namespace TestTaskITPD.DAL.Interfaces.BaseInterfaces;

public interface IRepository<T>
{
    Task<bool> Create(T entity);

    Task<T> Get(Guid id);

    Task<List<T>> Select();

    Task<bool> Delete(T entity);
}