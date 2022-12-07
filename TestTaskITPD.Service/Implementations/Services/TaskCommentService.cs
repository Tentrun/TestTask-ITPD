using System.Net;
using System.Text;
using TestTaskITPD.DAL.Interfaces.Implementations;
using TestTaskITPD.Domain.Entity;
using TestTaskITPD.Domain.Response;
using TestTaskITPD.Service.Interfaces.Implementations;
using Microsoft.AspNetCore.Http;
using TestTaskITPD.Domain.Entity.Exception;
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
        var comments = await _taskCommentRepository.Select();

        baseResponse.Data = comments;
        baseResponse.StatusCode = HttpStatusCode.OK;

        return baseResponse;
    }

    //Get single task comment by id from entity
    public async Task<IBaseResponse<TaskComment>> Get(Guid id)
    {
        var baseResponse = new BaseResponse<TaskComment>();
        var comment = await _taskCommentRepository.Get(id);

        baseResponse.Data = comment;
        baseResponse.StatusCode = HttpStatusCode.OK;

        return baseResponse;
    }
    
    //Get all task comments with same taskId
    public async Task<IBaseResponse<IEnumerable<TaskComment>>> GetAllByTask(Guid id)
    {
        var baseResponse = new BaseResponse<IEnumerable<TaskComment>>();
        var comments = await _taskCommentRepository.SelectByTask(id);

        baseResponse.Data = comments;
        baseResponse.StatusCode = HttpStatusCode.OK;

        return baseResponse;
    }

    //Delete task comment entity
    public async Task<IBaseResponse<bool>> Delete(Guid id)
    {
        var baseResponse = new BaseResponse<bool>();
        var comment = await _taskCommentRepository.Get(id);

        await _taskCommentRepository.Delete(comment);
        baseResponse.StatusCode = HttpStatusCode.OK;

        return baseResponse;
    }

    //Create task comment by received entity
    public async Task<IBaseResponse<TaskComment>> Create(TaskComment entity)
    {
        var baseResponse = new BaseResponse<TaskComment>();
        var comment = new TaskComment
        {
            Id = new Guid(),
            TaskId = entity.TaskId,
            CommentType = entity.CommentType,
            Content = entity.Content
        };
        await _taskCommentRepository.Create(comment);

        baseResponse.StatusCode = HttpStatusCode.Created;
        return baseResponse;
    }

    //Edit exist task comment
    public async Task<IBaseResponse<TaskComment>> Edit(Guid id, TaskComment entity)
    {
        var baseResponse = new BaseResponse<TaskComment>();
        var comment = await _taskCommentRepository.Get(id);

        comment.Content = entity.Content;
        comment.CommentType = entity.CommentType;

        await _taskCommentRepository.Update(comment);
        baseResponse.StatusCode = HttpStatusCode.OK;

        return baseResponse;
    }
}