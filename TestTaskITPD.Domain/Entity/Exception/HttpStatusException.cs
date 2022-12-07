using System.Net;
using TestTaskITPD.Domain.Response;

namespace TestTaskITPD.Domain.Entity.Exception;

public class HttpStatusException : System.Exception
{
    public HttpStatusCode Status { get; private set; }
    
    public HttpStatusException(HttpStatusCode status, string msg) : base(msg)
    {
        Status = status;
    }
}