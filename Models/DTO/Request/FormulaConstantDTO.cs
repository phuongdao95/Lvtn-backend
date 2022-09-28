using Models.Enums;

namespace Models.DTO.Request
{
    public class FormulaConstantDTO
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        public string? Define { get; set; }
        public string? Description { get; set; }
        public FormulaDataType DataType { get; set; }
    }
}
