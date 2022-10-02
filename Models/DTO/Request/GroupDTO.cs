namespace Models.DTO.Request
{
    public class GroupDTO
    {
        public string? Name { get; set; }
        public string? Description { get; set; }
        public string? FormulaName { get; set; }
        public List<int>? UserIds { get; set; }
    }
}
