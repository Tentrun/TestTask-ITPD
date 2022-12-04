using System.Net;

namespace TestTaskITPD.Domain.Response;

public class BaseResponse<T> : IBaseResponse<T>
{
    public string Description { get; set; }
    
    public HttpStatusCode StatusCode { get; set; }
    
    public T Data { get; set; }
}

public interface IBaseResponse<T>
{
    T Data { get; }
    HttpStatusCode StatusCode { get; set; }
}