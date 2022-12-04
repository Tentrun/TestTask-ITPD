using System.Net;
using System.Text;
using TestTaskITPD.DAL.Interfaces.Implementations;
using TestTaskITPD.Domain.Entity;
using TestTaskITPD.Domain.Response;
using TestTaskITPD.Service.Interfaces.Implementations;
using Microsoft.AspNetCore.Http;
using TestTaskITPD.Domain.Enum;


namespace TestTaskITPD.Service.Implementations.Services;

public class TaskCommentService : ITaskCommentService
{
    #region Constructor
    
    //Repository entity
    private readonly ITaskCommentRepository _taskCommentRepository;

    public TaskCommentService(ITaskCommentRepository taskCommentRepository)
    {
        _taskCommentRepository = taskCommentRepository;
    }
    
    #endregion


    //Get all task comments
    public async Task<IBaseResponse<IEnumerable<TaskComment>>> GetAll()
    {
        var baseResponse = new BaseResponse<IEnumerable<TaskComment>>();
        try
        {
            var comments = await _taskCommentRepository.Select();

            if (comments.Count is 0)
            {
                baseResponse.Description = "Комментарии отсутствуют";
                baseResponse.StatusCode = HttpStatusCode.NoContent;
                return baseResponse;
            }

            baseResponse.Data = comments;
            baseResponse.StatusCode = HttpStatusCode.OK;

            return baseResponse;
        }
        catch (Exception ex)
        {
            return new BaseResponse<IEnumerable<TaskComment>>()
            {
                Description = ex.Message,
                StatusCode = HttpStatusCode.InternalServerError
            };
        }
    }

    //Get single task comment by id from entity
    public async Task<IBaseResponse<TaskComment>> Get(Guid id)
    {
        var baseResponse = new BaseResponse<TaskComment>();
        try
        {
            var comment = await _taskCommentRepository.Get(id);
            
            if (comment == null)
            {
                baseResponse.Description = "Комментарий не найден";
                baseResponse.StatusCode = HttpStatusCode.NotFound;
                return baseResponse;
            }
            baseResponse.Data = comment;
            baseResponse.StatusCode = HttpStatusCode.OK;

            return baseResponse;
        }
        catch (Exception ex)
        {
            return new BaseResponse<TaskComment>()
            {
                Description = ex.Message,
                StatusCode = HttpStatusCode.InternalServerError
            };
        }
    }
    
    //Get all task comments with same taskId
    public async Task<IBaseResponse<IEnumerable<TaskComment>>> GetAllByTask(Guid id)
    {
        var baseResponse = new BaseResponse<IEnumerable<TaskComment>>();
        try
        {
            var comments = await _taskCommentRepository.SelectByTask(id);

            if (comments.Count is 0)
            {
                baseResponse.Description = "Комментарии отсутствуют";
                baseResponse.StatusCode = HttpStatusCode.NoContent;
                
                return baseResponse;
            }

            foreach (var comment in comments)
            {
            }
            
            baseResponse.Data = comments;
            baseResponse.StatusCode = HttpStatusCode.OK;

            return baseResponse;
        }
        catch (Exception ex)
        {
            return new BaseResponse<IEnumerable<TaskComment>>()
            {
                Description = ex.Message,
                StatusCode = HttpStatusCode.InternalServerError
            };
        }
    }

    //Delete task comment entity
    public async Task<IBaseResponse<bool>> Delete(Guid id)
    {
        var baseResponse = new BaseResponse<bool>();
        try
        {
            var comment = await _taskCommentRepository.Get(id);
            if (comment is null)
            {
                baseResponse.Description = "Комментарий не найден";
                baseResponse.StatusCode = HttpStatusCode.NotFound;
                return baseResponse;
            }
            baseResponse.StatusCode = HttpStatusCode.OK;
            
            await _taskCommentRepository.Delete(comment);
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

    //Create task comment by received entity
    public async Task<IBaseResponse<TaskComment>> Create(TaskComment entity)
    {
        var baseResponse = new BaseResponse<TaskComment>();
        try
        {
            var comment = new TaskComment()
            {
                Id = new Guid(),
                TaskId = entity.TaskId,
                CommentType = entity.CommentType,
                Content = entity.Content
            };
            await _taskCommentRepository.Create(comment);
            
            baseResponse.StatusCode = HttpStatusCode.Created;
        }
        catch (Exception ex)
        {
            return new BaseResponse<TaskComment>()
            {
                Description = ex.Message,
                StatusCode = HttpStatusCode.InternalServerError
            };
        }
        return baseResponse;
    }

    //Edit exist task comment
    public async Task<IBaseResponse<TaskComment>> Edit(Guid id, TaskComment entity)
    {
        var baseResponse = new BaseResponse<TaskComment>();
        try
        {
            var comment = await _taskCommentRepository.Get(id);
            if (comment is null)
            {
                baseResponse.Description = "Комментарий не найден";
                baseResponse.StatusCode = HttpStatusCode.NotFound;
                return baseResponse;
            }

            comment.Content = entity.Content;
            comment.CommentType = entity.CommentType;

            await _taskCommentRepository.Update(comment);
            baseResponse.StatusCode = HttpStatusCode.OK;

            return baseResponse;
        }
        catch (Exception ex)
        {
            return new BaseResponse<TaskComment>()
            {
                Description = ex.Message,
                StatusCode = HttpStatusCode.InternalServerError
            };
        }
    }
}