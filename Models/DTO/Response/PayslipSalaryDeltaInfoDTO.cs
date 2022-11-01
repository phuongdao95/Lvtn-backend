using Models.Enums;
using System.Text.Json.Serialization;

namespace Models.DTO.Response
{
    public class PayslipSalaryDeltaInfoDTO
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        public string? Description { get; set; }
        public string? GroupName { get; set; }
        public string? GroupId { get; set; }
        [JsonConverter(typeof(JsonStringEnumConverter))]
        public SalaryDeltaType SalaryDeltaType { get; set; }
        public DateTime FromMonth { get; set; }
        public DateTime ToMonth { get; set; }
        public decimal? Amount { get; set; }
        public string? FormulaDefine { get; set; }
        public int? PayslipId { get; set; }
        public string? PayslipName { get; set; }
    }
}
