using Microsoft.EntityFrameworkCore;
using TestTaskITPD.DAL.Interfaces.Implementations;
using TestTaskITPD.Domain.Entity;

namespace TestTaskITPD.DAL.Repositories;

public class ProjectRepository : IProjectRepository
{
    private readonly ApplicationDbContext _dbContext;

    public ProjectRepository(ApplicationDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public async Task<bool> Create(Project entity)
    {
        await _dbContext.Project.AddAsync(entity);
        await _dbContext.SaveChangesAsync();

        return true;
    }

    public async Task<Project> Get(Guid id)
    {
        return (await _dbContext.Project.FirstOrDefaultAsync(p => p.Id == id))!;
    }

    public async Task<List<Project>> Select()
    {
        return await _dbContext.Project.ToListAsync();
    }

    public async Task<bool> Delete(Project entity)
    {
        _dbContext.Project.Remove(entity);
        await _dbContext.SaveChangesAsync();

        return true;
    }
}