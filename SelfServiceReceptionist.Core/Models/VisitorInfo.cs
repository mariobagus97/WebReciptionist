using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SelfServiceReceptionist.Core.Models
{
    public class VisitorInfo
    {
        #region contructor
        public VisitorInfo()
        {

        }

        #endregion

        #region properties
        public System.Guid VisitorID { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public string Company { get; set; }

        #endregion
    }
}
