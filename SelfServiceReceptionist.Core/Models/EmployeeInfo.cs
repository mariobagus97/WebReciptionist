using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SelfServiceReceptionist.Core.Models
{
    public class SendEmail
    {
        #region contructor
        public SendEmail()
        {

        }

        #endregion

        #region properties
        public string Emailemployee { get; set; }

        public string Emailvisitor { get; set; }
        public string NameVisitor { get; set; }

        #endregion
    }
}
