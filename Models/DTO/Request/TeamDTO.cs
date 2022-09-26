namespace Models.DTO.Request
{
    public class TeamDTO
    {
        public string? Name { get; set; }
        public string? Detail { get; set; }
        public int? LeaderId { get; set; }
        public List<int>? MemberIds { get; set; }
    }
}
