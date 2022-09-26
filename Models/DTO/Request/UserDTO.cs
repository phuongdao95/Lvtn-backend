namespace Models.DTO.Request
{
    public class UserDTO
    {
        // General Info
        public string UserName { get; set; }
        public string Password { get; set; }
        public string Name { get; set; }
        public string Address { get; set; }
        public string PhoneNumber { get; set; }
        public string CitizenId { get; set; }
        public string Email { get; set; }
        public bool Sex { get; set; }
        public DateTime Birthday { get; set; }

        // Salary Info
        public decimal BaseSalary { get; set; }
        public string? BankName { get; set; }
        public string? BankCode { get; set; }
        public string? BankBranch { get; set; }
        public string? AccountNumber { get; set; }
        public string? AccountName { get; set; }

        // Administration Info
        public int? RoleId { get; set; }
        public int? TeamId { get; set; }
    }
}
