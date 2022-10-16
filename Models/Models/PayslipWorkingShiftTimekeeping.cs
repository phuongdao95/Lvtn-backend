using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models.Models
{
    public class PayslipWorkingShiftTimekeeping
    {
        public int Id { get; set; }
        public DateTime? StartTime { get; set; }
        public DateTime? EndTime { get; set; }
        public bool DidCheckIn { get; set; }
        public DateTime? CheckinTime { get; set; }
        public bool DidCheckout { get; set; }
        public DateTime? CheckoutTime { get; set; }
        public decimal? Amount { get; set; }
        public string? Formula { get; set; }
        public int PayslipId { get; set; }
        public Payslip? Payslip { get; set; }
    }
}
