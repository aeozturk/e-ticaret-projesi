using Business.Abstract;
using Entity.Concrete;
using Service.EmailSender;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace Business.Concrete
{
    public class MailManager : IMailService
    {
        private IEmailService _emailService;
        private IUserService _userService;

        public MailManager(IEmailService emailService, IUserService userService)
        {
            _emailService = emailService;
            _userService = userService;
        }

        public void SendOrderMail(string email, string subject, Order order)
        {
            var userToSendMail = _userService.GetUserByEmail(email);
            var emailBody = "";
            if (userToSendMail.UserStatusId != 1)
            {
                emailBody = OrderMailForUserFill(order.Id + "", userToSendMail.Name, userToSendMail.Surname);
            }
            else
            {
                emailBody = OrderMailForAdminFill(order.Id.ToString(), order.UserId.ToString(), userToSendMail.Name);
            }
            _emailService.SendEmail(email, subject, emailBody, userToSendMail.Name, userToSendMail.Surname);
        }

        private string OrderMailForUserFill(string orderId, string name, string surname)
        {
            try
            {
                string body;

                using (var sr = new StreamReader("wwwroot\\EmailTemplates\\OrderMailForUser.txt"))
                {
                    body = sr.ReadToEnd();
                }

                return string.Format(body, name + " " + surname, orderId);
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        private string OrderMailForAdminFill(string orderId, string userId, string adminName)
        {
            try
            {
                string body;

                using (var sr = new StreamReader("wwwroot\\EmailTemplates\\OrderMailForAdmin.txt"))
                {
                    body = sr.ReadToEnd();
                }

                return string.Format(body, adminName, userId, orderId,"http://www.google.com.tr");
            }
            catch (Exception ex)
            {
                return null;
            }
        }
    }
}
