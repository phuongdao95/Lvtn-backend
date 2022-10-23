using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Models.Models
{
    public class SalaryGroup
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string? Name { get; set; }
        public string? Description { get; set; }
        [Required]
        public string? FormulaName { get; set; }
        [Required]
        public int GroupId { get; set; }
        [Required]
        public int? Priority { get; set; }
        public Group? Group { get; set; }
    }
}
