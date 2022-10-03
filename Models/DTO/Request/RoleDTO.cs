namespace Models.DTO.Request
{
    public class RoleDTO
    {
        public string? Name { get; set; }
        public string? Description { get; set; }
        public List<string>? PermissionNames { get; set; }
    }
}
