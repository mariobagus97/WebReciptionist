using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WebReciptionistNew;

namespace WebReciptionistNew.Models
{
    public class NewMeeting
    {
       
        #region Properties
        public System.Guid MeetingID { get; set; }
        public string MeetingPin { get; set; }
        public string Purpose { get; set; }
        public Nullable<System.DateTime> StartTime { get; set; }
        public Nullable<System.DateTime> EndTime { get; set; }
        

            public System.Guid VisitorID { get; set; }
            public string NameVisitor { get; set; }
            public string EmailVisitor { get; set; }
            public int PhoneVisitor { get; set; }


            public System.Guid EmployeeID { get; set; }
            public string NameEmployee { get; set; }
            public string EmailEmployee { get; set; }
            public Nullable<decimal> PhoneEmployee { get; set; }
      
        #endregion
        // 3112 13:39

    }
}
