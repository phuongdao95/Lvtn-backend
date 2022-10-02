using Models.Enums;
using System.Text.Json.Serialization;

namespace Models.DTO.Response
{
    public class SalaryVariableInfoDTO
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        public string? DisplayName { get; set; }
        public string? Value { get; set; }
        public string? Description { get; set; }
        [JsonConverter(typeof(JsonStringEnumConverter))]
        public VariableDataType DataType { get; set; }
    }
}
