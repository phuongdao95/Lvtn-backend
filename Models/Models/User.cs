using System.ComponentModel.DataAnnotations;

namespace Models.Models
{
    public class User
    {
        public int Id { get; set; }
        public string? UrlImage { get; set; }
        [Required]
        public string? Name { get; set; }
        public string? Address { get; set; }
        public string? PhoneNumber { get; set; }
        public bool Sex { get; set; }
        public DateTime Birthday { get; set; }
        [Required]
        public string? CitizenId { get; set; }
        public string? Email { get; set; }
        public int? TeamId { get; set; }
        public string? FaceId { get; set; }
        public string? TokenSlack { get; set; }
        public string? TokenTrello { get; set; }
        //public int? RoleId { get; set; }
        public string? SocialInsuranceId { get; set; }
        //public int? TaxPercentId { get; set; }
        //public int? ContractId { get; set; }
        public int? BankInfoId { get; set; }
        public string? TaxCode { get; set; }
        public string? InsuranceCode { get; set; }

        // Navigation properties
        public Team? TeamManage { get; set; }
        public Department? DepartmentManage { get; set; }
        public Team? TeamBelong { get; set; }
        public BankInfo? BankInfo { get; set; }
        public List<Workday>? Workdays { get; set; }
    }
}
