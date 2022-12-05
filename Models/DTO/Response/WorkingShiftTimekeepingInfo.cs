using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models.DTO.Response
{
    public class WorkingShiftTimekeepingInfoDTO
    {
        public int Id { get; set; }
        public bool DidCheckIn { get; set; }
        public DateTime? CheckinTime { get; set; }
        public bool DidCheckout { get; set; }
        public DateTime? CheckoutTime { get; set; }
        public int? EmployeeId { get; set; }
        public UserInfoDTO? Employee { get; set; }
        public int? WorkingShiftEventId { get; set; }
        public WorkingShiftEventResponseDTO? WorkingShiftEvent { get; set; }
        public Boolean? isFullShift { get; set; }
    }
}
