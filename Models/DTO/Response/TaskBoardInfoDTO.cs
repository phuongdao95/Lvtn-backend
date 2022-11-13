namespace Models.DTO.Response
{
    public class TaskBoardInfoDTO
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        public string? Description { get; set; }
        public string? TeamName { get; set; }
        public int? TeamId { get; set; }
    }
}
