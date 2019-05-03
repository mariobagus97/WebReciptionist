using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebReciptionistNew.Models
{

    public class TestingMeeting
    {
        public System.Guid MeetingID { get; set; }
        public string MeetingPin { get; set; }
        public string MeetingKey { get; set; }
        public string Purpose { get; set; }
        public Nullable<System.DateTime> StartTime { get; set; }
        public Nullable<System.DateTime> EndTime { get; set; }

        public List<Employee> emp { get; set; }
        public List<Visitor> vis { get; set; }
    }
}