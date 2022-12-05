using System.Runtime.Serialization;

namespace Models.Enums
{
    public enum TaskHistoryAction
    {
        [EnumMember(Value = "create_task")]
        CreateTask,
        [EnumMember(Value = "move_task")]
        MoveTask,
        [EnumMember(Value = "update_description")]
        UpdateDescription,
        [EnumMember(Value = "add_comment")]
        AddComment,
        [EnumMember(Value = "update_fields")]
        UpdateFields,

        [EnumMember(Value = "update_label")]
        AddLabel,
        [EnumMember(Value = "delete_label")]
        DeleteLabel,

        [EnumMember(Value = "add_file")]
        AddFile,
        [EnumMember(Value = "update_file")]
        UpdateFile,
        [EnumMember(Value = "delete_file")]
        DeleteFile
    }
}
