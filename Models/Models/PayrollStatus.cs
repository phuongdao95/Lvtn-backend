using System.Runtime.Serialization;

namespace Models.Models
{
    public enum PayrollStatus
    {
        [EnumMember(Value = "Draft")]
        Draft,
        [EnumMember(Value = "Sent")]
        Sent,
    }
}
