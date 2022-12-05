using System.ComponentModel.DataAnnotations;

namespace Models.Models
{
    public class TaskFileHistory : BaseEntity
    {
        [Key]
        public int Id { get; set; }
        public int TaskFileId { get; set; }
        public string? DisplayFileName { get; set; }
        public string? Description { get; set; }
        public int? TaskHistoryId { get; set; }
        public TaskHistory? TaskHistory { get; set; }
    }
}
