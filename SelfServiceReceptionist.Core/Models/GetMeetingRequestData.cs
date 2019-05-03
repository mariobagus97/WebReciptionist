using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SelfServiceReceptionist.Core.Models
{
    public class GetMeetingRequestData : RequestData
    {
        public string MeetingPin { get; set; }
        public string MeetingKey { get; set; }

    }
}
