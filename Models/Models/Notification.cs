﻿namespace Models.Models
{
    public class Notification
    {
        public int Id { get; set; }
        public string? Title { get; set; }
        public string? Message { get; set; }
        public bool? IsGlobal { get; set; }
        public bool? IsRead { get; set; }   
        public DateTime? DateTime { get; set; }
        public int UserId { get; set; }
        public User? User { get; set; }
    }
}
