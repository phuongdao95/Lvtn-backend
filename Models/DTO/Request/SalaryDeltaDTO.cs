using Models.Enums;

namespace Models.DTO.Request
{
    public class SalaryDeltaDTO
    {
        public string? Name { get; set; }
        public string? Description { get; set; }
        public DateTime FromMonth { get; set; }
        public DateTime ToMonth { get; set; }
        public SalaryDeltaType DeltaType { get; set; }
        public List<int>? UserIds { get; set; }
    }
}
