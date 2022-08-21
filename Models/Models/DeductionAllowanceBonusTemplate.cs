using Models.Enums;

namespace Models.Models
{
    public class DeductionAllowanceBonusTemplate
    {
        public int Id { get; set; }
        public int? FormulaId { get; set; }
        public AllowanceTemplateType Type { get; set; }
        public string? Description { get; set; }
        public ApplyType ApplyType { get; set; }

        public Formula? Formula { get; set; }
    }
}
