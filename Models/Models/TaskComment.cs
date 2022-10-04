using System.ComponentModel.DataAnnotations;

namespace Models.Models
{
    public class TaskComment
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public string? Message { get; set; }

        [Required]
        public int? TaskId { get; set; }

        [Required]
        public int? UserId { get; set; }

        public List<TaskFile>? TaskFiles { get; set; }
        public Task? Task { get; set; }
        public User? User { get; set; }
    }
}
