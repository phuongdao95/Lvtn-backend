using Models.Enums;

namespace Models.Models
{
    public class DeductionAllowanceBonus
    {
        public int Id { get; set; }
        public AllowanceBonusType Type { get; set; }
        public string? Description { get; set; }
        public int? TemplateId { get; set; }
        public DateTime FromDate { get; set; }
        public DateTime ToDate { get; set; }
        public int Number { get; set; }

        public List<User>? Users { get; set; }
        public DeductionAllowanceBonusTemplate? Template { get; set; }
    }
}
