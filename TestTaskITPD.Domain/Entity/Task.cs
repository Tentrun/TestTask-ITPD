using System.ComponentModel.DataAnnotations;

namespace TestTaskITPD.Domain.Entity;

public class Task
{
    public Guid Id { get; set; }
    
    [Required]
    public string TaskName { get; set; }
    
    public DateTime CreateDate { get; set; }
    public DateTime? StartDate { get; set; }
    public DateTime? CancelDate { get; set; }
    public DateTime UpdateDate { get; set; }
    
    [Required]
    public Guid ProjectId { get; set; }
}