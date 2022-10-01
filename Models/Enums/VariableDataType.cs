using System.Runtime.Serialization;

namespace Models.Enums
{
    public enum VariableDataType
    {
        [EnumMember(Value = "Text")]
        Text,
        [EnumMember(Value = "Number")]
        Number,
        [EnumMember(Value = "Boolean")]
        Boolean,
        [EnumMember(Value = "DateTime")]
        DateTime
    }
}
