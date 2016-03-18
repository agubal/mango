using System;
using System.Configuration;
using EASendMail;
using Mango.Common.Results;
using Mango.Entities.Domain;

namespace Mango.BLL.Mails
{
    public class MailService:IMailService
    {
        private const string Email = "nataliia.hubal@gmail.com";
        private const string Password = "Yf)06051987";

        private string GoogleImap => ConfigurationManager.AppSettings["Gmail.Imap"];
        private string GoogleSmtp => ConfigurationManager.AppSettings["Gmail.Smtp"];
        private string ClientCode => ConfigurationManager.AppSettings["Gmail.ClientCode"];



        public void Dispose()
        {
            throw new System.NotImplementedException();
        }


        public ServiceResult SendEmail(EmailItem email)
        {
            var smtpMail = new SmtpMail(ClientCode)
            {
                From = Email,
                To = Email,
                TextBody = $"Contact detail: {email.SenderContactDetails}, Senders name: {email.SenderName} Message: {email.Message}"
            };

            var smtpServer = new SmtpServer(GoogleSmtp, 465)
            {
                User = Email,
                Password = Password,
                Port = 465,
                ConnectType = SmtpConnectType.ConnectSSLAuto
            };

            try
            {
                var smtpClient = new SmtpClient();
                smtpClient.SendMail(smtpServer, smtpMail);
                return new ServiceResult();
            }
            catch (Exception ep)
            {
                return new ServiceResult(ep.Message);
            }
        }



    }
}
