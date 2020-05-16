using System;
using System.Collections.Generic;
using System.Text;

namespace Service.EmailSender
{
    public interface IEmailService
    {
        void SendEmail(string email, string subject, string emailBody, string userName, string userSurname);
    }
}
