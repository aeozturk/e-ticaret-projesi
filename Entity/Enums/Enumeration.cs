using System;
using System.Collections.Generic;
using System.Text;

namespace Entity.Enums
{
    public class Enumeration
    {
        public enum OrderStatuses
        {
            Hazirlaniyor = 1,
            KargoyaVerildi = 2,
            Tamamlandı = 3
        }

        public enum UserStatuses
        {
            Admin = 1,
            Beklemede = 2,
            Onayli = 3
        }
    }
}
