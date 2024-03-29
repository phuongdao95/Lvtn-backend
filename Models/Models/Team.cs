﻿using System.ComponentModel.DataAnnotations.Schema;

namespace Models.Models
{
    public class Team
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        [ForeignKey("Leader")]
        public int? LeaderId { get; set; }
        public int? DepartmentId { get; set; }
        public string? Detail { get; set; }
        public Department? Department { get; set; }
        public User? Leader { get; set; }
        public List<User>? Members { get; set; }
        public List<TaskBoard>? TaskBoards { get; set; }
    }
}
