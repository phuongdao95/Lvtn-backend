using Models.Enums;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Models.Models
{
    public class SalaryDelta
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public string? Name { get; set; }

        [Required]
        public string? Description { get; set; }

        [Required]
        public string? FormulaName { get; set; }

        [Required]
        public SalaryDeltaType Type { get; set; }

        [Required]
        public DateTime FromMonth { get; set; }

        [Required]
        public DateTime ToMonth { get; set; }
        public int GroupId { get; set; }
        public Group? Group { get; set; }
    }
}
