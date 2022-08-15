namespace lvtn_backend.Models
{
    public class Department
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int? ManagerId { get; set; }
        public int? ParentDepartmentId { get; set; }

        public User? Manager { get; set; }
        public Department? ParentDepartment { get; set; }

        public List<Team>? Teams { get; set; }
        public List<Department>? Departments { get; set; }
    }
}
