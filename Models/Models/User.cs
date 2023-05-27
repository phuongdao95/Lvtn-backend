using System.ComponentModel.DataAnnotations;
using System.Reflection.Metadata;

namespace Models.Models
{
    public class User
    {
        public int Id { get; set; }
        [Required]
        public string? Username { get; set; }
        [Required]
        public string? Name { get; set; }
        [Required]
        public string? Password { get; set; }
        public string? UrlImage { get; set; }

        public byte[]? Image { get; set; }

        [Required]
        public decimal BaseSalary { get; set; }
        public string? Address { get; set; }
        public string? PhoneNumber { get; set; }
        public string? Gender { get; set; }
        public string? AboutMe { get; set; }
        public DateTime? Birthday { get; set; }
        [Required]
        public string? CitizenId { get; set; }
        public string? Email { get; set; }
        public int? TeamId { get; set; }
        public int? RoleId { get; set; }
        public int? BankInfoId { get; set; }

        // Navigation properties
        public List<LeaveBalance>? LeaveBalances { get; set; }
        public Role? Role { get; set; }
        public Team? TeamManage { get; set; }
        public Department? DepartmentManage { get; set; }
        public Team? Team { get; set; }
        public BankInfo? BankInfo { get; set; }
        public List<Group>? Groups { get; set; }
        public List<WorkingShiftTimekeeping>? Timekeepings { get; set; }
        public List<Payslip>? Payslips { get; set; }
        public List<Notification>? Notifications { get; set; }
        public List<WorkingShiftRegistrationUser>? WorkingShiftRegistrationUsers { get; set; }
    }
}
