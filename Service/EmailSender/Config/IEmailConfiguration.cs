﻿using System;
using System.Collections.Generic;
using System.Text;

namespace Service.EmailSender.Config
{
    public interface IEmailConfiguration
    {
        string SmtpServer { get; }
        int SmtpPort { get; }
        string SmtpUsername { get; set; }
        string SmtpPassword { get; set; }
    }
}
