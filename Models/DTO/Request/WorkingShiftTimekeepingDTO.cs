using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models.DTO.Request
{
    public class WorkingShiftTimekeepingDTO
    {
        public int Id { get; set; }
        public bool DidCheckIn { get; set; }
        public DateTime? CheckinTime { get; set; }
        public bool DidCheckout { get; set; }
        public DateTime? CheckoutTime { get; set; }
        public int? EmployeeId { get; set; }
        public UserDTO? Employee { get; set; }
        public int? WorkingShiftEventId { get; set; }
        public WorkingShiftEventDTO? WorkingShiftEvent { get; set; }
    }
}
