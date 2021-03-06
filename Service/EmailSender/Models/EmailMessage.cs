﻿using System;
using System.Collections.Generic;
using System.Text;

namespace Service.EmailSender.Models
{
    public class EmailMessage
    {
        public string Subject { get; set; }
        public string Content { get; set; }
        public List<EmailAddress> ToAddresses { get; set; }
        public List<EmailAddress> FromAddresses { get; set; }

        public EmailMessage()
        {
            ToAddresses = new List<EmailAddress>();
            FromAddresses = new List<EmailAddress>();
        }
    }
}
