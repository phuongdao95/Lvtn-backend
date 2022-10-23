using System.Runtime.Serialization;

namespace Models.Enums
{
    public enum VariableDataType
    {
        [EnumMember(Value = "Text")]
        Text,
        [EnumMember(Value = "Decimal")]
        Decimal,
        [EnumMember(Value = "Boolean")]
        Boolean,
        [EnumMember(Value = "Integer")]
        Integer
    }
}
