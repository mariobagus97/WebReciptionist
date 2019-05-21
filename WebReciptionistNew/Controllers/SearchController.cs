using SelfServiceReceptionist.Core;
using SelfServiceReceptionist.Core.Models;
using SelfServiceReceptionist.Core.RestRequestModel;
using SelfServiceReceptionist.Core.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http;

namespace WebReciptionistNew.Controllers
{
    public class SearchController : ApiController
    {
        MeetingService meetingservice = new MeetingService();

        private Receiptionist db = new Receiptionist();

        [HttpPost]
        public MeetingInfo ListSearchVisitor(VisitorInfo visitorinfo)
        {
            MeetingInfo meetinginfo = new MeetingInfo();

            try
            {
                var visitors = db.Visitors.Where(x => x.Name.StartsWith(visitorinfo.Name)).ToList();

             //   var visitor = db.Visitors.Where(x => x.Name.StartsWith(visitorinfo.Name)).ToList();

                foreach (var visitor in visitors)
                {
                    VisitorInfo visitorinfoes = new VisitorInfo();
                    visitorinfoes.Name = visitor.Name;

                    meetinginfo.Employees = new List<EmployeeInfo>();
                  //  meetinginfo.Employees.Add(EmployeeInfo);
                }
            }
            catch (Exception ex)
            {
                
            }
           return meetinginfo;
        }

        [HttpPost]
        public MeetingInfo SearchingMeeting(MeetingInfo requestmeetinginfo)
        {
            ResponseData response = meetingservice.SearchMeeting(requestmeetinginfo);

            MeetingInfo meetinginfo = response.meetinginfo;

            return meetinginfo;
        }

        //[HttpPost]
        //public MeetingInfo SearchingMeeting(GetMeetingRequestData requestmeetinginfo)
        //{
        //    ResponseData response = meetingservice.SearchMeeting(requestmeetinginfo);

        //    MeetingInfo meetinginfo = response.meetinginfo;

        //    return meetinginfo;
        //}

        [HttpPost]
        public List<EmployeeInfo> SearchingEmployee(GetEmployeeRequestParameter filter)
        {
            ResponseData response = meetingservice.SearchEmployee(filter);
            List<EmployeeInfo> EmployeeInfo = response.EmployeeInfo;
            return EmployeeInfo;
        }

        //[HttpPost]
        //public VisitorInfo SearchingVisitor(VisitorInfo VisitorInfo)
        //{
        //    ResponseData response = meetingservice.SearchVisitor(VisitorInfo);
        //    VisitorInfo visitorinfo = response.visitorinfo;
        //    return visitorinfo;
        //}

        [HttpPost]
        public VisitorInfo SearchingVisitor(GetVisitorRequestParameter filter)
        {
            ResponseData response = meetingservice.SearchVisitor(filter);

            VisitorInfo visitorinfo = response.visitorinfo;

            return visitorinfo;
        }
    }
}
