using System.Runtime.Serialization;

namespace Models.Enums
{
    public enum SalarySystemVariableKind
    {
        [EnumMember(Value = "Salary Delta")]
        SalaryDelta,
        [EnumMember(Value = "Salary Group")]
        SalaryGroup,
        [EnumMember(Value = "Timekeeping")]
        Timekeeping,
        [EnumMember(Value = "KPI")]
        KPI
    }
}
