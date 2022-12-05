
namespace Models.DTO.Response
{
    public class GroupInfoDTO
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        public string? Description { get; set; }
        public List<string>? UserIds { get; set; }
        public List<string>? UserUserames { get; set; }
    }
}
