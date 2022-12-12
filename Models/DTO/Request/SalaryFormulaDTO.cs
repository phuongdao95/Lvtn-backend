using Models.Enums;

namespace Models.DTO.Request
{
    public class SalaryFormulaDTO
    {
        public string? Name { get; set; }
        public string? DisplayName { get; set; }
        public string? Define { get; set; }
        public string? FormulaArea { get; set; }
        public string? Description { get; set; }
    }
}
