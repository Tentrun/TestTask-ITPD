using System.ComponentModel.DataAnnotations;

namespace TestTaskITPD.Domain.Entity;

public class Project
{
    [Required]
    public Guid Id { get; set; }
    
    [Required]
    public string ProjectName { get; set; }
    
    [Required]
    public DateTime CreateDate { get; set; }
    [Required]
    public DateTime UpdateDate { get; set; }
}