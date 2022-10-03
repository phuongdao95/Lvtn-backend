using Models.Models;
using System.Text.Json.Serialization;

namespace Models.DTO.Response
{
    public class PayrollInfoDTO
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        public string? Description { get; set; }
        public DateTime FromDate { get; set; }
        public DateTime ToDate { get; set; }

        [JsonConverter(typeof(JsonStringEnumConverter))]
        public PayrollStatus Status { get; set; }
    }
}
