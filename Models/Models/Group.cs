using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Models.Models
{
    public class Group
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string? Name { get; set; }
        public string? Description { get; set; }

        [Required]
        [DefaultValue("base_salary + allowance + bonus - deduction")]
        public string? FormulaName { get; set; }
        public List<User>? Users { get; set; }
    }
}
