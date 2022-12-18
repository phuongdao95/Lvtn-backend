using System.ComponentModel.DataAnnotations;

namespace Models.Models
{
    public class LeaveBalance
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public decimal TotalDays { get; set; }
        public decimal TakenDays { get; set; }
        public int Year { get; set; }

        [Required]
        public User? User { get; set; }
    }
}
