using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace COMUN.Mail
{
    public class SystemSupportMail:MasterMailServices
    {
        public SystemSupportMail()
        {
            senderMail = "acasoporte03@hotmail.com";
            Password = "hffvzupxgcfnfhza";
            Host = "smtp.office365.com";
            Port = 587;
            ssl = true;
            initializeSmtpClient();
        }
    }
}
