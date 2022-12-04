using Microsoft.EntityFrameworkCore;
using TestTaskITPD.DAL.Interfaces.Implementations;
using Task = TestTaskITPD.Domain.Entity.Task;

namespace TestTaskITPD.DAL.Repositories;

public class TaskRepository : ITaskRepository
{
    private readonly ApplicationDbContext _dbContext;

    public TaskRepository(ApplicationDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public async Task<bool> Create(Task entity)
    {
        await _dbContext.Task.AddAsync(entity);
        await _dbContext.SaveChangesAsync();

        return true;
    }

    public async Task<Task> Get(Guid id)
    {
        return (await _dbContext.Task.FirstOrDefaultAsync(p => p.Id == id))!;
    }

    public async Task<List<Task>> Select()
    {
        return await _dbContext.Task.ToListAsync();
    }

    public async Task<bool> Delete(Task entity)
    {
        _dbContext.Task.Remove(entity);
        await _dbContext.SaveChangesAsync();

        return true;
    }

    public async Task<List<Task>> SelectByProject(Guid id)
    {
        return await _dbContext.Task.Where(e => e.ProjectId == id).ToListAsync();
    }

    public async Task<Task> Update(Task entity)
    {
        _dbContext.Task.Update(entity);
        await _dbContext.SaveChangesAsync();

        return entity;
    }
}