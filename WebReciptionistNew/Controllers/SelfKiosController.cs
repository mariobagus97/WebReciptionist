using SelfServiceReceptionist.Core.Models;
using SelfServiceReceptionist.Core.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using WebReciptionistNew;
using WebReciptionistNew.Models;

namespace ReceiptionistWeb.Controllers
{
    public class SelfKiosController : ApiController
    {
        MeetingService meetingservice = new MeetingService();

        [HttpPost]
        public MeetingInfo NewMeeting(MeetingInfo createmeeting)
        {
            ResponseData response = meetingservice.CreateMeeting(createmeeting);

            MeetingInfo meetinginfo = response.meetinginfo;

            return meetinginfo;
            
        }

        [HttpPost]
        public MeetingInfo NotifyEmployee(MeetingInfo notifyemployee)
        {
            ResponseData response = meetingservice.SendMessage(notifyemployee);

            MeetingInfo meetinginfo = response.meetinginfo;

            return meetinginfo;
        }

        [HttpPost]
        public MeetingInfo NotifyEmailEmployee(MeetingInfo notifyemployee)
        {
            ResponseData response = meetingservice.SendEmail(notifyemployee);

            MeetingInfo meetinginfo = response.meetinginfo;

            return meetinginfo;
        }

        

    }
}
