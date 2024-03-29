﻿namespace Models.Models
{
    public class Group
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        public string? Description { get; set; }
        public List<User>? Users { get; set; }
        public List<SalaryGroup>? SalaryGroups { get; set; }
        public List<SalaryDelta>? SalaryDeltas { get; set; }
    }
}
