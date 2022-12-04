using Microsoft.EntityFrameworkCore;
using TestTaskITPD.Domain.Entity;
using Task = System.Threading.Tasks.Task;

namespace TestTaskITPD.DAL;

public class ApplicationDbContext : DbContext
{
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
    {
        
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Project>().HasData(new Project[]
        {
            new Project
            {
                Id = new Guid("3d210c1b-41fd-4a02-beab-526315fccce6"),
                ProjectName = "TestProject1",
                CreateDate = DateTime.Now,
                UpdateDate = DateTime.Now
            }, 
            new Project
            {
                Id = new Guid("b41627fb-c020-4c4d-b503-e45e60ff1ea7"),
                ProjectName = "TestProject2",
                CreateDate = DateTime.Now,
                UpdateDate = DateTime.Now
            }
        });
        modelBuilder.Entity<TestTaskITPD.Domain.Entity.Task>().HasData(new TestTaskITPD.Domain.Entity.Task[]
        {
            new TestTaskITPD.Domain.Entity.Task
            {
                Id = new Guid("23C10D0A-6A76-4B1E-872E-090455DA1F6E"),
                ProjectId = new Guid("3D210C1B-41FD-4A02-BEAB-526315FCCCE6"),
                TaskName = "TestTask1",
                CreateDate = DateTime.Now,
                UpdateDate = DateTime.Now,
                StartDate = DateTime.Parse("2022-12-04 22:34:00"),
                CancelDate = DateTime.Parse("2022-12-05 22:40:00")
            }, 
            new TestTaskITPD.Domain.Entity.Task
            {
                Id = new Guid("749E270C-9B66-4954-ABC1-D2CDEA203A9E"),
                ProjectId = new Guid("3D210C1B-41FD-4A02-BEAB-526315FCCCE6"),
                TaskName = "EditedTask2",
                CreateDate = DateTime.Now,
                UpdateDate = DateTime.Now,
            }
        });
        modelBuilder.Entity<TaskComment>().HasData(new TaskComment[]
        {
            new TaskComment
            {
                Id = new Guid("CC8BA1D9-B394-4B78-3E7F-08DAD62E9F56"),
                TaskId = new Guid("3D210C1B-41FD-4A02-BEAB-526315FCCCE6"),
                CommentType = 0,
                Content = Convert.FromBase64String("VGVzdERlc2NyaXB0aW9uDQpBZGRlZCBmcm9tIHR4dCBmaWxl")
            }, 
            new TaskComment
            {
                Id = new Guid("AA1C412F-A734-416B-3E80-08DAD62E9F56"),
                TaskId = new Guid("749E270C-9B66-4954-ABC1-D2CDEA203A9E"),
                CommentType = 1,
                Content = Convert.FromBase64String("VGVzdERlc2NyaXB0aW9uIEFkZGVkIGZyb20gdHh0IGZpbGU=")
            }
        });
    }

    public DbSet<Project> Project { get; set; }
    public DbSet<TestTaskITPD.Domain.Entity.Task> Task { get; set; }
    public DbSet<TaskComment> TaskComments { get; set; }
}