using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models.DTO.Request
{
    public class NghiPhepDTO
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public string? Reason { get; set; } = "";
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
    }

    public class NghiThaiSanDTO
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public bool IsHusband { get; set; }
        public DateTime StartDate { get; set; }
    }

    public class CheckInOutDTO
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public DateTime CheckedinTime { get; set; }
        public DateTime CheckedoutTime { get; set; }
        public int TimekeepingId { get; set; }
    }
}
