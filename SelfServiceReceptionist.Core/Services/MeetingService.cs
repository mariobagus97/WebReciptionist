using SelfServiceReceptionist.Core.Models;
using SelfServiceReceptionist.Core.RestRequestModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;
using Twilio;
using Twilio.Rest.Api.V2010.Account;
using Twilio.Types;

namespace SelfServiceReceptionist.Core.Services
{
    public class MeetingService
    {
        private Receiptionist db = new Receiptionist();
        public string MeetingRandomPin()
        {
            int _min = 000;
            int _max = 999;
            Random _rdm = new Random();
            var id = (DateTime.Now.ToString("ddMMyy." + _rdm.Next(_min, _max)));
            return id;
        }

        //public ResponseData SearchEmployee(MeetingInfo MeetingInfo)
        //{
        //    try
        //    {
        //        foreach (var employees in MeetingInfo.Employees)
        //        {

        //            List<Employee> list_employees = db.Employees.Where(x => x.Name.StartsWith(employees.Name)).ToList();

        //            MeetingInfo.Employees = new List<EmployeeInfo>();

        //                List<Employee> list_employee = db.Employees.Where(x => x.Name.Contains(employees.Name)).ToList();

        //                foreach (var split_employee in list_employee)

        //                {
        //                    string[] splitData = split_employee.Name.Split(new string[] { " " }, StringSplitOptions.RemoveEmptyEntries);

        //                    foreach (var employee_splitData in splitData)

        //                    {

        //                        if (employees.Name == employee_splitData)
        //                        {
        //                            EmployeeInfo employeeinfo = new EmployeeInfo();
        //                            employeeinfo.Name = split_employee.Name;
        //                            employeeinfo.Company = split_employee.Company;
        //                            employeeinfo.Email = split_employee.Email;
        //                            employeeinfo.Phone = split_employee.Phone;
        //                            employeeinfo.EmployeeID = split_employee.EmployeeID;

        //                            MeetingInfo.Employees.Add(employeeinfo);
        //                        }
        //                    }
        //                }
        //        }

        //        return new ResponseData() { meetinginfo = MeetingInfo };
        //    }
        //    catch (Exception ex)
        //    {
        //        return new ResponseData() { ErrorMessage = ex.Message };
        //    }
        //}

        public ResponseData SearchEmployee(GetEmployeeRequestParameter filter)
        {
            try
            {
                List<EmployeeInfo> EmployeesInfo = new List<EmployeeInfo>();
                List<Employee> list_employee = db.Employees.Where(x => x.Name.Contains(filter.Name)).ToList();

                    foreach (var split_employee in list_employee)

                    {
                        string[] splitData = split_employee.Name.Split(new string[] { " " }, StringSplitOptions.RemoveEmptyEntries);

                        foreach (var employee_splitData in splitData)
                        {
                            if (filter.Name == employee_splitData)
                            {
                                EmployeeInfo employeeinfo = new EmployeeInfo();
                                employeeinfo.Name = split_employee.Name;
                                employeeinfo.Company = split_employee.Company;
                                employeeinfo.Email = split_employee.Email;
                                employeeinfo.Phone = split_employee.Phone;
                                employeeinfo.EmployeeID = split_employee.EmployeeID;

                                EmployeesInfo.Add(employeeinfo);
                            }
                        }
                    }
                return new ResponseData() { EmployeeInfo = EmployeesInfo };
            }
            catch (Exception ex)
            {
                return new ResponseData() { ErrorMessage = ex.Message };
            }
        }

        //public ResponseData SearchVisitor(VisitorInfo visitorinfo)
        //{
        //    try
        //    {
        //        Visitor visitors = new Visitor();

        //        visitors = db.Visitors.Where(x => x.Phone.Equals(visitorinfo.Phone)).FirstOrDefault();

        //        if (visitors != null)
        //        {
        //            visitorinfo = new VisitorInfo();
        //            visitorinfo.VisitorID = visitors.VisitorID;
        //            visitorinfo.Name = visitors.Name;
        //            visitorinfo.Phone = visitors.Phone;
        //            visitorinfo.Company = visitors.Company;
        //            visitorinfo.Email = visitors.Email;
        //        }

        //        return new ResponseData() { visitorinfo = visitorinfo };
        //    }
        //    catch (Exception ex)
        //    {
        //        return new ResponseData() { ErrorMessage = ex.Message };
        //    }
        //}

        public ResponseData SearchVisitor(GetVisitorRequestParameter filter)
        {
            try
            {
                Visitor visitor = db.Visitors.Where(x => x.Phone.Equals(filter.PhoneNumber)).FirstOrDefault();

                VisitorInfo visitorinfo = new VisitorInfo();

                if (visitor != null)
                {
                    visitorinfo.VisitorID = visitor.VisitorID;
                    visitorinfo.Name = visitor.Name;
                    visitorinfo.Phone = visitor.Phone;
                    visitorinfo.Company = visitor.Company;
                    visitorinfo.Email = visitor.Email;
                }

                return new ResponseData() { visitorinfo = visitorinfo };
            }
            catch (Exception ex)
            {
                return new ResponseData() { ErrorMessage = ex.Message };
            }
        }

        public ResponseData SearchMeeting(MeetingInfo MeetingInfo)
        {
            try
            {
                var Meetings = db.Meetings
                         .Include("EmployeeMeetings.Employee")
                         .Include("VisitorMeetings.Visitor")
                         .Where(x => x.MeetingPin == MeetingInfo.MeetingPin && x.MeetingKey == MeetingInfo.MeetingKey).FirstOrDefault();

                MeetingInfo = new MeetingInfo();

                MeetingInfo.Purpose = Meetings.Purpose;
                MeetingInfo.StartTime = Meetings.StartTime;
                MeetingInfo.EndTime = Meetings.EndTime;
                MeetingInfo.MeetingPin = Meetings.MeetingPin;

                MeetingInfo.Employees = new List<EmployeeInfo>();
                MeetingInfo.Visitors = new List<VisitorInfo>();

                foreach (var employee in Meetings.EmployeeMeetings)
                {
                    EmployeeInfo employeeInfo = new EmployeeInfo();
                    employeeInfo.Name = employee.Employee.Name;
                    //employeeInfo.Email = employee.Employee.Email;
                    employeeInfo.Phone = employee.Employee.Phone;

                    MeetingInfo.Employees.Add(employeeInfo);

                }

                foreach (var visitor in Meetings.VisitorMeetings)
                {
                    VisitorInfo visitorinfo = new VisitorInfo();
                    visitorinfo.Name = visitor.Visitor.Name;
                    visitorinfo.Email = visitor.Visitor.Email;
                    visitorinfo.Phone = visitor.Visitor.Phone;

                    MeetingInfo.Visitors.Add(visitorinfo);
                }
                return new ResponseData() { meetinginfo = MeetingInfo };
            }
            catch (Exception ex)
            {
                return new ResponseData() { ErrorMessage = ex.Message };
            }
        }
    

        public ResponseData CreateMeeting(MeetingInfo MeetingInfo)
        {
            try
            {
                EmployeeMeeting employeeMeeting = new EmployeeMeeting();
                VisitorMeeting visitormeeting = new VisitorMeeting();
                Visitor visitor = new Visitor();
                Meeting meeting = new Meeting();

                meeting.MeetingPin = MeetingRandomPin();
                meeting.MeetingKey = MeetingRandomPin();
                meeting.MeetingID = Guid.NewGuid();
                meeting.StartTime = MeetingInfo.StartTime;
                meeting.EndTime = MeetingInfo.EndTime;
                meeting.Purpose = MeetingInfo.Purpose;

                MeetingInfo.MeetingPin = meeting.MeetingPin;
                MeetingInfo.MeetingKey = meeting.MeetingKey;

                db.Meetings.Add(meeting);

                foreach (var itememp in MeetingInfo.Employees)
                {
                    List<Employee> searchemployee = db.Employees.Where(t => t.Email.Contains(itememp.Email)).ToList();

                    if (searchemployee.Any())
                    {
                        foreach (Employee employee in searchemployee)
                        {
                            employeeMeeting.EmployeeMeetingID = Guid.NewGuid();
                            employeeMeeting.EmployeeID = employee.EmployeeID;
                            employeeMeeting.MeetingID = meeting.MeetingID;

                            db.EmployeeMeetings.Add(employeeMeeting);
                        }
                        db.SaveChanges();
                        employeeMeeting = new EmployeeMeeting();
                    }
                    else 
                    {
                        return new ResponseData() { ErrorMessage = "error" };
                    }
                }

                foreach (var itemvis in MeetingInfo.Visitors)
                {
                    List<Visitor> searchvisitor = db.Visitors.Where(t => t.Email.Contains(itemvis.Email)).ToList();

                    if (searchvisitor.Any())
                    {
                        foreach (Visitor visitoring in searchvisitor)
                        {
                            visitormeeting.VisitorMeetingID = Guid.NewGuid();
                            visitormeeting.VisitorID = visitoring.VisitorID;
                            visitormeeting.MeetingID = meeting.MeetingID;

                            db.VisitorMeetings.Add(visitormeeting);
                            db.SaveChanges();
                            visitormeeting = new VisitorMeeting();
                        }
                    }
                    else
                    {
                        foreach (var newitemvis in MeetingInfo.Visitors)
                        {
                            visitor.VisitorID = Guid.NewGuid();
                            visitor.Name = newitemvis.Name;
                            visitor.Email = newitemvis.Email;
                            visitor.Phone = newitemvis.Phone;
                            visitor.Company = newitemvis.Company;
                            db.Visitors.Add(visitor);

                            visitormeeting.VisitorMeetingID = Guid.NewGuid();
                            visitormeeting.VisitorID = visitor.VisitorID;
                            visitormeeting.MeetingID = meeting.MeetingID;
                            db.VisitorMeetings.Add(visitormeeting);

                            db.SaveChanges();
                            visitormeeting = new VisitorMeeting();
                            visitor = new Visitor();
                        }
                    }
                }
            return new ResponseData() { meetinginfo = MeetingInfo };
        }
            catch (Exception ex)
            {
                return new ResponseData() { ErrorMessage = ex.Message };
            }
            
            

       
}

    
//        public ResponseData SendMessage(MeetingInfo MeetingInfo)
//        {
//            try
//            {
//                VisitorInfo visitorinfo = new VisitorInfo();

//                foreach (var visitor in MeetingInfo.Visitors)
//                {
//                    visitorinfo.Name = visitor.Name;
//                }
                
//                var accountSid = "AC0570cbb489f7b533cf2517f08f578cbc";
//                var authToken = "318d9a8b8a2faa57fc21791d985e04ed";
//                TwilioClient.Init(accountSid, authToken);

//                var messageOptions = new CreateMessageOptions(
//                    new PhoneNumber("whatsapp:+6289601688992"));
//                messageOptions.From = new PhoneNumber("whatsapp:+14155238886");
//                messageOptions.Body = visitorinfo.Name + " want to " + MeetingInfo.Purpose + " with you";

//                MessageResource.Create(messageOptions);

//                return new ResponseData() { meetinginfo = MeetingInfo };
//        }
//            catch (Exception ex)
//            {
//                return new ResponseData() { ErrorMessage = ex.Message };
//    }
//}


        public ResponseData SendEmail(MeetingInfo MeetingInfo)
        {
            try
            {
                MailMessage email = new MailMessage();
                SmtpClient SmtpServer = new SmtpClient("smtp.gmail.com");

                var employee = new StringBuilder();

                SendEmail sendemail = new SendEmail();

                foreach (var meetingin in MeetingInfo.Employees)
                {
                    sendemail.Emailemployee = meetingin.Email;
                }

                foreach (var meetingin in MeetingInfo.Visitors)
                {
                    sendemail.NameVisitor = meetingin.Name;
                }


                email.From = new MailAddress("ultravouchergroup@gmail.com");
                email.To.Add(sendemail.Emailemployee );
                email.Subject = MeetingInfo.Purpose;
                email.Body = sendemail.NameVisitor + " want to " + MeetingInfo.Purpose + " you" ;
                

                SmtpServer.Port = 587;
                SmtpServer.Credentials = new System.Net.NetworkCredential("ultravouchergroup@gmail.com", "muzamil123");
                SmtpServer.EnableSsl = true;

                SmtpServer.Send(email);
                return new ResponseData() { meetinginfo = MeetingInfo };
            }
            catch (Exception ex)
            {
                return new ResponseData() { ErrorMessage = ex.Message };
            }

        }
    }
}
