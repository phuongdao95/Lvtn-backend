using Models.Enums;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Models.Models
{
    public class SalaryVariable
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public string? Name { get; set; }

        [Required]
        public string? DisplayName { get; set; }

        [Required]
        [DefaultValue("0")]
        public string? Value { get; set; }
        public FormulaArea? Area { get; set; }
        [Required]
        [DefaultValue(VariableDataType.Decimal)]
        public VariableDataType DataType { get; set; }
        public string? Description { get; set; }
    }
}
