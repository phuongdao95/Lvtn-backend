using Models.Enums;
using System.Text.Json.Serialization;

namespace Models.Models
{
    public class SalarySystemVariable
    {
        public string? DisplayName { get; set; }
        public string? Name { get; set; }
        public string? Value { get; set; }
        public string? Description { get; set; }

        [JsonConverter(typeof(JsonStringEnumConverter))]
        public SalarySystemVariableKind IsUsedFor { get; set; }

        [JsonConverter(typeof(JsonStringEnumConverter))]
        public VariableDataType DataType { get; set; }
    }
}
