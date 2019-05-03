using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SelfServiceReceptionist.Core.Models
{
    public class EmployeeInfo
    {
        #region contructor
        public EmployeeInfo()
        {

        }

        #endregion

        #region properties
        public Nullable<System.Guid> EmployeeID { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }

        public string Company { get; set; }

        #endregion
    }
}
