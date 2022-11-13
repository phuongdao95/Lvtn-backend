namespace Models.DTO.Response
{
    public class SalaryGroupInfoDTO
    {
        public int Id { get; set; }
        public int Priority { get; set; }
        public string? Name { get; set; }
        public string? Description { get; set; } 
        public string? FormulaName { get; set; }
        public int? GroupId { get; set; }
        public string? GroupName { get; set; }
    }
}
