using Models.Enums;

namespace Models.Models
{
    public class Constant
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public FormulaDataType DataType { get; set; }

        public List<Formula>? Formulas { get; set; }
    }
}
