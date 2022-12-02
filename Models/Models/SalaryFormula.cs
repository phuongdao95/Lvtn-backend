using Models.Enums;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Models.Models
{
    public class SalaryFormula
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public string? Name { get; set; }

        public FormulaArea? Area { get; set; }

        [Required]
        public string? DisplayName { get; set; }

        [Required]
        [DefaultValue("0")]
        public string? Define { get; set; }

        public string? Description { get; set; }
    }
}
