using Models.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models.Models
{
    public class SalaryDeltaFormula
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public string? Name { get; set; }

        [Required]
        public string? Define { get; set; }
        public string? Description { get; set; }
        public List<SalaryDelta>? SalaryDeltaList { get; set; }
        public List<SalaryDeltaVariable>? Variables { get; set; }
    }
}
