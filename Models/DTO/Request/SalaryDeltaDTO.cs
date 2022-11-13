using Models.Enums;

namespace Models.DTO.Request
{
    public class SalaryDeltaDTO
    {
        public string? Name { get; set; }
        public string? Description { get; set; }
        public string? FormulaName { get; set; }
        public int FromMonth { get; set; }
        public int ToMonth { get; set; }
        public int Year { get; set; }
        public string? Type { get; set; }
        public int? GroupId { get; set; }
    }
}
