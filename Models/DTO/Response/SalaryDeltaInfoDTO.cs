using Models.Enums;
using System.ComponentModel;
using System.Text.Json.Serialization;

namespace Models.DTO.Response
{
    public class SalaryDeltaInfoDTO
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string Formula { get; set; }
        public string FromMonth { get; set; }
        public string ToMonth { get; set; }

        [JsonConverter(typeof(JsonStringEnumConverter))]
        public SalaryDeltaType SalaryDeltaType { get; set; }
    }
}
