using Models.Enums;

namespace Models.Models
{
    public class SalaryDelta
    {
        public int Id { get; set; }
        public SalaryDeltaType Type { get; set; }
        public string? Description { get; set; }
        public DateTime FromDate { get; set; }
        public DateTime ToDate { get; set; }
        public SalaryDeltaFormula? Formula { get; set; }
        public int FormulaId { get; set; }
        public List<User>? Users { get; set; }
    }
}
