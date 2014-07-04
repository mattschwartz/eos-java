using System;
using System.Net;
using System.Net.Mail;
using eos.Properties;

namespace eos.Services
{
    public class EmailService
    {
        public static void SendMail(String to, String subject, String body)
        {
            var client = new SmtpClient(Settings.Default.SmtpServer, Settings.Default.SmtpPort) {
                Credentials = new NetworkCredential(Settings.Default.SmtpUser, Settings.Default.SmtpPassword),
                EnableSsl = true
            };
            client.Send(String.Format("{0} <{1}>", Settings.Default.FromEmailDisplay, Settings.Default.FromEmail), to, subject, body);
        }
    }
}