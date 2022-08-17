namespace lvtn_backend.Models
{
    public class User
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public bool Sex { get; set; }
        public int? TeamId { get; set; }

        public Team? TeamManage { get; set; }
        public Department? DepartmentManage { get; set; }

        public Team? TeamBelong { get; set; }
    }
}
