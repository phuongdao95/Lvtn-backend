using Models.Enums;

namespace Models.DTO.Response
{
    public class SalaryFormulaInfoDTO
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        public string? DisplayName { get; set; }
        public string? Define { get; set; }
        public FormulaArea? Area { get; set; }
        public string? Description { get; set; }
    }
}
