using Models.Models;

namespace Models.DTO.Request
{
    public class PayrollDTO
    {
        public int? Id { get; set; }
        public string? Name { get; set; }
        public string? Description { get; set; }
        public int Month { get; set; }
        public int Year { get; set; }
        public PayrollStatus Status { get; set; }
    }
}
