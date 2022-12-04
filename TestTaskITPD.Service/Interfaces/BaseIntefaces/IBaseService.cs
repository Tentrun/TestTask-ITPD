using TestTaskITPD.Domain.Response;

namespace TestTaskITPD.Service.Interfaces.BaseIntefaces;

public interface IBaseService<T>
{
    Task<IBaseResponse<IEnumerable<T>>> GetAll();
    Task<IBaseResponse<T>> Get(Guid id);
    Task<IBaseResponse<bool>> Delete(Guid id);
    Task<IBaseResponse<T>> Create(T model);
}