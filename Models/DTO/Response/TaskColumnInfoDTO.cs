namespace Models.DTO.Response
{
    public class TaskColumnInfoDTO
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        public string? Description { get; set; }
        public int? Order { get; set; }
        public int? BoardId { get; set; }
        public string? BoardName { get; set; }
    }
}
