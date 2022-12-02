using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models.Models
{
    public class BankInfo
    {
        public int Id { get; set; }
        [Required]
        public string? BankName { get; set; }
        public string? BankCode { get; set; }
        public string? BankBranch { get; set; }
        [Required]
        public string? AccountName { get; set; }
    }
}
