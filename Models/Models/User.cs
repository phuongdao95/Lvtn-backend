using System.ComponentModel.DataAnnotations;

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
        [Required]
        public decimal BaseSalary { get; set; }      
        public decimal LeaveBalance { get; set; }
        public string? Address { get; set; }
        public string? PhoneNumber { get; set; }
        public string? Gender { get; set; }
        public DateTime? Birthday { get; set; }

        [Required]
        public string? CitizenId { get; set; }
        public string? Email { get; set; }
        public int? TeamId { get; set; }
        public string? FaceId { get; set; }
        public string? TokenSlack { get; set; }
        public string? TokenTrello { get; set; }
        public int? RoleId { get; set; }
        public string? SocialInsuranceId { get; set; }
        //public int? TaxPercentId { get; set; }
        //public int? ContractId { get; set; }
        public int? BankInfoId { get; set; }
        public string? TaxCode { get; set; }
        public string? InsuranceCode { get; set; }

        // Navigation properties
        public Role? Role { get; set; }
        public Team? TeamManage { get; set; }
        public Department? DepartmentManage { get; set; }
        public Team? Team { get; set; }
        public BankInfo? BankInfo { get; set; }
        public List<Group>? Groups { get; set; }
        public List<WorkingShiftTimekeeping>? Timekeepings { get; set; }
        public List<WorkingShift>? WorkingShiftEvents { get; set; }
        public List<WorkingShiftRegistration>? WorkingShiftRegistrationList { get; set; }
        public List<SalaryDelta>? SalaryDeltaList { get; set; }
        public List<Payslip>? Payslips { get; set; }
        public List<Notification>? Notifications { get; set; }
        public List<WorkingShiftRegistrationUser>? WorkingShiftRegistrationUsers { get; set; }

    }
}
