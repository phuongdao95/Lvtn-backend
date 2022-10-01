using System.Runtime.Serialization;

namespace Models.Enums
{
    public enum SalaryDeltaType
    {
        [EnumMember(Value = "deduction")]
        Deduction,
        [EnumMember(Value = "allowance")]
        Allowance,
        [EnumMember(Value = "bonus")]
        Bonus
    }
}
