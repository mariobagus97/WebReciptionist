using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SelfServiceReceptionist.Core.Models
{
    public class ResponseData
    {
        public string ErrorMessage { get; set; }

        public MeetingInfo meetinginfo { get; set; }

        public VisitorInfo visitorinfo { get; set; }

        public List<EmployeeInfo> EmployeeInfo { get; set; }
        
    }
}
