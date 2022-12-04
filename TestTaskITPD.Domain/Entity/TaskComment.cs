using System.ComponentModel.DataAnnotations;

namespace TestTaskITPD.Domain.Entity;

public class TaskComment
{
    public Guid Id { get; set; }
    [Required]
    public Guid TaskId { get; set; }
    [Required]
    public byte CommentType { get; set; }
    [Required]
    public byte[] Content { get; set; }
}