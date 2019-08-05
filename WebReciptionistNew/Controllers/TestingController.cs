//using SelfServiceReceptionist.Core.Models;
//using SelfServiceReceptionist.Core.Services;
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
        //MeetingService meetingservice = new MeetingService();

        //[HttpPost]
        //public MeetingInfo SendEmail(MeetingInfo EmailMeeting)
        //{
        //    ResponseData response = meetingservice.SendEmail(EmailMeeting);

        //    MeetingInfo meetinginfo = response.meetinginfo;

        //    return meetinginfo;
        //}

        //private ReceptEntities db = new ReceptEntities();
        ////[HttpPost]
        ////public VisitorInfo SearchingVisitor(GetVisitorRequestParameter filter)
        ////{
        ////    ResponseData response = meetingservice.SearchVisitor(filter);
        ////    VisitorInfo visitorinfo = response.visitorinfo;
        ////    return visitorinfo;
        ////}
        //[HttpPost]
        //public Visitor SearchVisitor(VisitorPhone visitors)
        //{
        //    try
        //    {
        //        Visitor visitor = db.Visitors.Where(x => x.Phone.Equals(visitors.phone)).FirstOrDefault();

        //        if (!string.IsNullOrEmpty(visitor.Name))
        //        {
        //            return visitor;
        //        }
        //        else
        //        {
        //            return null;
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        return null;
        //    }
        //}
    }
}




