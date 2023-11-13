using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net;
using System.Net.Mail;

namespace COMUN.Mail
{
    public abstract class MasterMailServices
    {
        private SmtpClient smtpClient;
        protected string senderMail { get; set; }
        protected string Password { get; set; }
        protected string Host { get; set; }
        protected int Port { get; set; }
        protected bool ssl { get; set; }

        protected void initializeSmtpClient()
        {
            smtpClient = new SmtpClient();
            smtpClient.Credentials = new NetworkCredential(senderMail, Password);
            smtpClient.Host = Host;
            smtpClient.Port = Port;
            smtpClient.EnableSsl = ssl;
        }

        public void sendMail(string subjet, string body, List<string> recipientMail)
        {
            var mailMessage = new MailMessage();
            try 
            { 
                mailMessage.From = new MailAddress(senderMail);
                foreach(string mail in recipientMail)
                {
                    mailMessage.To.Add(mail);
                }
                mailMessage.Subject = subjet;
                mailMessage.Body= body;
                mailMessage.Priority = MailPriority.Normal;
                smtpClient.Send(mailMessage);
            }
            catch(Exception ex){}
            finally
            {
                mailMessage.Dispose();
                smtpClient.Dispose();
            }
        }

    }
}
