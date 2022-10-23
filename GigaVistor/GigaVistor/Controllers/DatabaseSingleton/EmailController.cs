using GigaVistor.Models;
using Microsoft.AspNetCore.Mvc;
using System.Linq.Expressions;
using System.Net;
using System.Net.Http;
using System.Net.Mail;

namespace GigaVistor.Controllers.DatabaseSingleton
{
    public class EmailController : Controller
    {
        #region SINGLETON
        public EmailController EmailControllerActive;
        private static EmailController instance = null;

        private EmailController()
        {

        }

        public static EmailController Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new EmailController();
                }
                return instance;
            }
        }
        #endregion


        public JsonResult SendEmail(string body, string idSentTo, string header)
        {
            bool result = true;
            bool sendBool = true;

            if (idSentTo == null)
                sendBool = false;
            if (body == null)
                sendBool = false;
            if (header == null)
                sendBool = false;

            if (sendBool)
            {
                try
                {
                    string fromMail = "gigavistor@gmail.com";
                    string fromPassword = "zzmzhmcarqxmwxce";

                    MailMessage message = new MailMessage();

                    message.From = new MailAddress(fromMail);
                    message.Subject = header;
                    message.To.Add(new MailAddress(idSentTo));
                    message.Body = "<html<body>" + body + "</body></html>";
                    message.IsBodyHtml = true;

                    var smtpClient = new SmtpClient("smtp.gmail.com")
                    {
                        Port = 587,
                        Credentials = new NetworkCredential(fromMail, fromPassword),
                        EnableSsl = true,
                    };
                    smtpClient.Send(message);
                }
                catch
                {
                    result = false;
                }
            }
            else
            {
                result = false;
            }
            return Json(result);
        }




    }
}
