using Models.Enums;
using System.Text.Json.Serialization;

namespace Models.DTO.Response
{
    public class PayslipTimekeepingInfoDTO
    {
        public int Id { get; set; }
        public DateTime? StartTime { get; set; }
        public DateTime? EndTime { get; set; }
        public bool DidCheckIn { get; set; }
        public DateTime? CheckinTime { get; set; }
        public bool DidCheckout { get; set; }
        public DateTime? CheckoutTime { get; set; }
        public decimal Amount { get; set; }
        public string? FormulaDefine { get; set; }

        [JsonConverter(typeof(JsonStringEnumConverter))]
        public WorkingShiftType Type { get; set; }
        public int PayslipId { get; set; }
        public string? PayslipName { get; set; }
    }
}
