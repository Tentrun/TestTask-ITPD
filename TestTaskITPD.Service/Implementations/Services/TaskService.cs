using System.Net;
using TestTaskITPD.DAL.Interfaces.Implementations;
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
        try
        {
            var tasks = await _taskRepository.Select();

            if (tasks.Count is 0)
            {
                baseResponse.Description = "Задачи отсутствуют";
                baseResponse.StatusCode = HttpStatusCode.NoContent;
                return baseResponse;
            }

            baseResponse.Data = tasks;
            baseResponse.StatusCode = HttpStatusCode.OK;

            return baseResponse;
        }
        catch (Exception ex)
        {
            return new BaseResponse<IEnumerable<Task>>()
            {
                Description = ex.Message,
                StatusCode = HttpStatusCode.InternalServerError
            };
        }
    }

    public async Task<IBaseResponse<Task>> Get(Guid id)
    {
        var baseResponse = new BaseResponse<Task>();
        try
        {
            var task = await _taskRepository.Get(id);
            
            if (task == null)
            {
                baseResponse.Description = "Задача не найдена";
                baseResponse.StatusCode = HttpStatusCode.NotFound;
                return baseResponse;
            }
            baseResponse.Data = task;
            baseResponse.StatusCode = HttpStatusCode.OK;

            return baseResponse;
        }
        catch (Exception ex)
        {
            return new BaseResponse<Task>()
            {
                Description = ex.Message,
                StatusCode = HttpStatusCode.InternalServerError
            };
        }
    }

    public async Task<IBaseResponse<bool>> Delete(Guid id)
    {
        var baseResponse = new BaseResponse<bool>();
        try
        {
            var task = await _taskRepository.Get(id);
            if (task is null)
            {
                baseResponse.Description = "Задача не найдена";
                baseResponse.StatusCode = HttpStatusCode.NotFound;
                return baseResponse;
            }
            baseResponse.StatusCode = HttpStatusCode.OK;
            
            await _taskRepository.Delete(task);
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

    public async Task<IBaseResponse<Task>> Create(Task entity)
    {
        var baseResponse = new BaseResponse<Task>();
        try
        {
            var task = new Task()
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
        }
        catch (Exception ex)
        {
            return new BaseResponse<Task>()
            {
                Description = ex.Message,
                StatusCode = HttpStatusCode.InternalServerError
            };
        }
        return baseResponse;
    }

    public async Task<IBaseResponse<Task>> Edit(Guid id, Task entity)
    {
        var baseResponse = new BaseResponse<Task>();
        try
        {
            var task = await _taskRepository.Get(id);
            if (task is null)
            {
                baseResponse.Description = "Задача не найдена";
                baseResponse.StatusCode = HttpStatusCode.NotFound;
                return baseResponse;
            }

            task.TaskName = entity.TaskName;
            task.UpdateDate = DateTime.Now;
            task.StartDate = entity.StartDate;
            task.CancelDate = entity.CancelDate;

            await _taskRepository.Update(task);
            baseResponse.StatusCode = HttpStatusCode.OK;

            return baseResponse;
        }
        catch (Exception ex)
        {
            return new BaseResponse<Task>()
            {
                Description = ex.Message,
                StatusCode = HttpStatusCode.InternalServerError
            };
        }
    }

    public async Task<IBaseResponse<IEnumerable<Task>>> GetAllByProject(Guid id)
    {
        var baseResponse = new BaseResponse<IEnumerable<Task>>();
        try
        {
            var tasks = await _taskRepository.SelectByProject(id);

            if (tasks.Count is 0)
            {
                baseResponse.Description = "Задачи отсутствуют";
                baseResponse.StatusCode = HttpStatusCode.NoContent;
                return baseResponse;
            }
            baseResponse.Data = tasks;
            baseResponse.StatusCode = HttpStatusCode.OK;

            return baseResponse;
        }
        catch (Exception ex)
        {
            return new BaseResponse<IEnumerable<Task>>()
            {
                Description = ex.Message,
                StatusCode = HttpStatusCode.InternalServerError
            };
        }
    }

    public async Task<IBaseResponse<string>> GetRemainTimeByTask(Guid id)
    {
        var baseResponse = new BaseResponse<string>();
        try
        {
            DateTime remainTime = new DateTime(0);
            var task = await _taskRepository.Get(id);

            if (task == null)
            {
                baseResponse.StatusCode = HttpStatusCode.NotFound;
                return baseResponse;
            }

            if (task.StartDate != null)
            {
                TimeSpan? date;
                
                if (task.CancelDate == null)
                {
                    date = DateTime.Now - task.StartDate;
                }
                
                else
                {
                    date = task.CancelDate - task.StartDate; 
                }

                remainTime = remainTime.Add(TimeSpan.Parse(date.ToString()));
                    
                baseResponse.StatusCode = HttpStatusCode.OK;
                baseResponse.Data = remainTime.ToShortTimeString();
        
                return baseResponse;
            }
            
            baseResponse.StatusCode = HttpStatusCode.NoContent;
            return baseResponse;
        }
        catch (Exception ex)
        {
            return new BaseResponse<string>()
            {
                Description = ex.Message,
                StatusCode = HttpStatusCode.InternalServerError
            };
        }
    }
    
    public async Task<IBaseResponse<string>> GetTotalTimeSpentByProject(Guid id)
    {
        var baseResponse = new BaseResponse<string>();
        try
        {
            TimeSpan spentTime = new();
            var tasks = await _taskRepository.SelectByProject(id);
            var totalNotEmptyTasksList = tasks.FindAll(p => p.StartDate != null);

            if (totalNotEmptyTasksList.Count != 0)
            {
                foreach (var task in totalNotEmptyTasksList)
                {
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
                }

                baseResponse.StatusCode = HttpStatusCode.OK;
                baseResponse.Data = Math.Round(spentTime.TotalMinutes) + "min ";
        
                return baseResponse;
            }
            
            baseResponse.StatusCode = HttpStatusCode.NoContent;
            return baseResponse;
        }
        catch (Exception ex)
        {
            return new BaseResponse<string>()
            {
                Description = ex.Message,
                StatusCode = HttpStatusCode.InternalServerError
            };
        }

    }
}