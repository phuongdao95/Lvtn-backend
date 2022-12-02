﻿namespace Models.Models
{
    public class CreateOrUpdateOverTimeShiftDTO
    {
        public string? Name { get; set; }
        public string? Description { get; set; }
        public DateTime Date { get; set; }
        public DateTime RegistrationStartDate { get; set; }
        public DateTime RegistrationEndDate { get; set; }
        public DateTime StartTime { get; set; }
        public DateTime EndTime { get; set; }
        public string? FormulaName { get; set; }
        public int GroupId { get; set; }
    }
}
