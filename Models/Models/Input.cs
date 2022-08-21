using Models.Enums;

namespace Models.Models
{
    public class Input
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string ModelName { get; set; }
        public string FieldName { get; set; }
        public FormulaDataType DataType { get; set; }

        public List<Formula>? Formulas { get; set; }
    }
}
