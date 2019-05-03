using SelfServiceReceptionist.Core.Models;
using SelfServiceReceptionist.Core.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Web.Http;
using WebReciptionistNew.Models;
using static ReceiptionistWeb.Controllers.SelfKiosController;

namespace WebReciptionistNew.Controllers
{
    public class TestingController : ApiController
    {
        MeetingService meetingservice = new MeetingService();

        [HttpPost]
        public MeetingInfo SendEmail(MeetingInfo EmailMeeting)
        {
            ResponseData response = meetingservice.SendEmail(EmailMeeting);

            MeetingInfo meetinginfo = response.meetinginfo;

            return meetinginfo;
        }
       
        }
        
    }

