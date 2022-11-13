namespace Models.DTO.Response
{
    public class TaskLabelInfoDTO
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        public string? Description { get; set; }
        public int? TaskBoardId { get; set; }
        public string? TaskBoardName { get; set; }
    }
}
