using Models.Enums;

namespace Models.Models
{
    public class SalaryDeltaVariable
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        public string? Value { get; set; }
        public string? Description { get; set; }
        public FormulaDataType DataType { get; set; }
        public List<SalaryDeltaFormula>? Formulas { get; set; }
    }
}
