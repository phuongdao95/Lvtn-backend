namespace Models.DTO.Request
{
    public class TaskColumnDTO
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        public string? Description { get; set; }
        public int? Order { get; set; }
        public int? TaskBoardId { get; set; }
    }
}
