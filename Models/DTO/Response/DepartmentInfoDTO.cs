namespace Models.DTO.Response
{
    public class DepartmentInfoDTO
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        public string? Detail { get; set; }
        public int? ManagerId { get; set; }
        public string? ManagerName { get; set; }
        public int? ParentDepartmentId { get; set; }
        public string? ParentDepartmentName { get; set; }
    }
}
