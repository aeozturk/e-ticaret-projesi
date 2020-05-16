using Entity.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Abstract
{
    public interface IMailService
    {
        void SendOrderMail(string email, string subject, Order order);
    }
}
