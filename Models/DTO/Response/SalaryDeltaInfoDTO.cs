using Models.Enums;
using System.ComponentModel;
using System.Text.Json.Serialization;

namespace Models.DTO.Response
{
    public class SalaryDeltaInfoDTO
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        public string? Description { get; set; }
        public string? Formula { get; set; }
        public DateTime? FromMonth { get; set; }
        public DateTime? ToMonth { get; set; }

        [JsonConverter(typeof(JsonStringEnumConverter))]
        public SalaryDeltaType SalaryDeltaType { get; set; }
        public string? GroupName { get; set; }
        public int? GroupId { get; set; }
    }
}
