using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models.Enums
{
    public enum WorkflowStatusEnum
    {
        WaitingForApproving, // user created new request, must wait for approver
        Approved,            // approver approved request
        Submitted,           // the request changed to submitted after approved (automatically)
        Waiting,             // involved users need more infomation for this request or user who created the request didn't accept the resolution
        Passed,              // involved users accept the request
        Accepted,            // user who created request accept the resolution
        Denied,              
        Cancelled
    }
}
