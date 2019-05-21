using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SelfServiceReceptionist.Core.Models
{
    public class MeetingInfo
    {
        #region Constructors

        public MeetingInfo()
        {

        }

        #endregion

        #region Properties
        public Guid MeetingID { get; set; }
        public string MeetingPin { get; set; }
        public string MeetingKey { get; set; }
        public string Purpose { get; set; }
        
        public string Company { get; set; }
        public DateTime? StartTime { get; set; }
        public DateTime? EndTime { get; set; }

        public string NameEmployee { get; set; }
        public string NameVisitor { get; set; }
        
        public List<EmployeeInfo> Employees { get; set; }
        public List<VisitorInfo> Visitors { get; set; }


        
        #endregion
    }
}
