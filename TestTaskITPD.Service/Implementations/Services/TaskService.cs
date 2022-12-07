using System.Net;
using TestTaskITPD.DAL.Interfaces.Implementations;
using TestTaskITPD.Domain.Entity.Exception;
using TestTaskITPD.Domain.Response;
using TestTaskITPD.Service.Interfaces.Implementations;
using Task = TestTaskITPD.Domain.Entity.Task;

namespace TestTaskITPD.Service.Implementations.Services;

public class TaskService : ITaskService
{
    private readonly ITaskRepository _taskRepository;

    public TaskService(ITaskRepository taskRepository)
    {
        _taskRepository = taskRepository;
    }

    public async Task<IBaseResponse<IEnumerable<Task>>> GetAll()
    {
        var baseResponse = new BaseResponse<IEnumerable<Task>>();
        var tasks = await _taskRepository.Select();

        baseResponse.Data = tasks;
        baseResponse.StatusCode = HttpStatusCode.OK;

        return baseResponse;
    }

    public async Task<IBaseResponse<Task>> Get(Guid id)
    {
        var baseResponse = new BaseResponse<Task>();
        var task = await _taskRepository.Get(id);

        baseResponse.Data = task;
        baseResponse.StatusCode = HttpStatusCode.OK;

        return baseResponse;
    }

    public async Task<IBaseResponse<bool>> Delete(Guid id)
    {
        var baseResponse = new BaseResponse<bool>();
        var task = await _taskRepository.Get(id);
        
        baseResponse.StatusCode = HttpStatusCode.OK;

        await _taskRepository.Delete(task);
        return baseResponse;
    }

    public async Task<IBaseResponse<Task>> Create(Task entity)
    {
        var baseResponse = new BaseResponse<Task>();
        var task = new Task
        {
            Id = entity.Id,
            ProjectId = entity.ProjectId,
            TaskName = entity.TaskName,
            CreateDate = entity.CreateDate,
            StartDate = entity.StartDate,
            CancelDate = entity.CancelDate,
            UpdateDate = entity.UpdateDate
        };
        baseResponse.Data = task;
        baseResponse.StatusCode = HttpStatusCode.OK;

        await _taskRepository.Create(task);
        return baseResponse;
    }

    public async Task<IBaseResponse<Task>> Edit(Guid id, Task entity)
    {
        var baseResponse = new BaseResponse<Task>();
        var task = await _taskRepository.Get(id);
        
        task.TaskName = entity.TaskName;
        task.UpdateDate = DateTime.Now;
        task.StartDate = entity.StartDate;
        task.CancelDate = entity.CancelDate;

        await _taskRepository.Update(task);
        baseResponse.StatusCode = HttpStatusCode.OK;

        return baseResponse;
    }

    public async Task<IBaseResponse<IEnumerable<Task>>> GetAllByProject(Guid id)
    {
        var baseResponse = new BaseResponse<IEnumerable<Task>>();

        var tasks = await _taskRepository.SelectByProject(id);

        baseResponse.Data = tasks;
        baseResponse.StatusCode = HttpStatusCode.OK;

        return baseResponse;
    }

    public async Task<IBaseResponse<string>> GetRemainTimeByTask(Guid id)
    {
        var baseResponse = new BaseResponse<string>();
        var remainTime = new DateTime(0);
        var task = await _taskRepository.Get(id);

        if (task.StartDate != null)
        {
            TimeSpan? date;

            if (task.CancelDate == null)
                date = DateTime.Now - task.StartDate;

            else
                date = task.CancelDate - task.StartDate;

            remainTime = remainTime.Add(TimeSpan.Parse(date.ToString()));

            baseResponse.StatusCode = HttpStatusCode.OK;
            baseResponse.Data = remainTime.ToShortTimeString();

            return baseResponse;
        }

        baseResponse.StatusCode = HttpStatusCode.NoContent;
        return baseResponse;
    }
    
    public async Task<IBaseResponse<string>> GetTotalTimeSpentByProject(Guid id)
    {
        var baseResponse = new BaseResponse<string>();
        TimeSpan spentTime = new();
        var tasks = await _taskRepository.SelectByProject(id);
        var totalNotEmptyTasksList = tasks.FindAll(p => p.StartDate != null);

        if (totalNotEmptyTasksList.Count != 0)
        {
            foreach (var task in totalNotEmptyTasksList)
                if (task.CancelDate != null)
                {
                    //Нaдеюсь мне не слoмают пaльцы за такой костыль
                    var date = task.StartDate - task.CancelDate;
                    var spanString = Convert.ToString(date)?.Remove(0, 1);

                    spentTime = spentTime + TimeSpan.Parse(spanString);
                }
                else
                {
                    var date = DateTime.Now - task.StartDate;
                    var spanString = Convert.ToString(date)?.Remove(0, 1);

                    spentTime = spentTime + TimeSpan.Parse(spanString);
                }

            baseResponse.StatusCode = HttpStatusCode.OK;
            baseResponse.Data = Math.Round(spentTime.TotalMinutes) + "min ";

            return baseResponse;
        }

        baseResponse.StatusCode = HttpStatusCode.NoContent;
        return baseResponse;
    }
}