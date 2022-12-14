using System.ComponentModel.DataAnnotations;

namespace Models.Models
{
    public class TaskFile
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string? DisplayFileName { get; set; }
        public string? Description { get; set; }
        [Required]
        public string? Name { get; set; }
        [Required]
        public int? TaskId { get; set; }
        public Task? Task { get; set; }
    }
}
