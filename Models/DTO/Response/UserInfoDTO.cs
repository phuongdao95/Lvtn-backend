namespace Models.DTO.Response
{
    public class UserInfoDTO
    {
        public int Id { get; set; }
        public string? Username { get; set; }
        public string? Address { get; set; }
        public string? UrlImage { get; set; }
        public string? PhoneNumber { get; set; }
        public string? Name { get; set; }
        public string? Age { get; set; }
        public string? Email { get; set; }
        public string? Gender { get; set; }
        public DateTime Birthday { get; set; }
        
        public decimal BaseSalary { get; set; }
        public string? BankName { get; set; }
        public string? BankBranch { get; set; }
        public string? AccountName { get; set; }

        public int RoleId { get; set; }
        public string? RoleName { get; set; }

        public int DepartmentId { get; set; }
        public string? DepartmentName { get; set; }

        public int TeamId { get; set; }
        public string? TeamName { get; set; }
    }
}
