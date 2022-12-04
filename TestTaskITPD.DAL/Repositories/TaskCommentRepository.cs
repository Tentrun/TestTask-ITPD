using Microsoft.EntityFrameworkCore;
using TestTaskITPD.DAL.Interfaces.Implementations;
using TestTaskITPD.Domain.Entity;

namespace TestTaskITPD.DAL.Repositories;

public class TaskCommentRepository : ITaskCommentRepository
{
    private readonly ApplicationDbContext _dbContext;

    public TaskCommentRepository(ApplicationDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public async Task<bool> Create(TaskComment entity)
    {
        await _dbContext.TaskComments.AddAsync(entity);
        await _dbContext.SaveChangesAsync();

        return true;
    }

    public async Task<TaskComment> Get(Guid id)
    {
        return (await _dbContext.TaskComments.FirstOrDefaultAsync(p => p.TaskId == id))!;
    }

    public async Task<List<TaskComment>> Select()
    {
        return await _dbContext.TaskComments.ToListAsync();
    }

    public async Task<bool> Delete(TaskComment entity)
    {
        _dbContext.TaskComments.Remove(entity);
        await _dbContext.SaveChangesAsync();

        return true;
    }

    public async Task<List<TaskComment>> SelectByTask(Guid id)
    {
        return await _dbContext.TaskComments.Where(e => e.TaskId == id).ToListAsync();
    }

    public async Task<TaskComment> Update(TaskComment entity)
    {
        _dbContext.TaskComments.Update(entity);
        await _dbContext.SaveChangesAsync();

        return entity;
    }
}