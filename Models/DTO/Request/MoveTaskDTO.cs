namespace Models.DTO.Request
{
    public class MoveTaskDTO
    {
        public int TaskBoardId { get; set; }
        public string? sourceColumnName { get; set; }
        public string? destinationColumnName { get; set; }
    }
}
