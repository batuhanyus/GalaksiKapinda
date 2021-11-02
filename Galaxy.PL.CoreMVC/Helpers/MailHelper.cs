using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Threading.Tasks;
using Microsoft.Extensions.Hosting;

namespace Galaxy.PL.CoreMVC.Helpers
{
    public static class MailHelper
    {
        static String FROM = "noreply@galaksikapinda.com";
        static String FROMNAME = "Galaksi Kapında";
        static String SMTP_USERNAME = "AKIAVJVA3DZCV6FK3XL2";
        static String SMTP_PASSWORD = "BLc71ij8COgxC2ODY//+qr86i+s/RZDWc5ucpHYUDBzN";
        static String HOST = "email-smtp.eu-west-1.amazonaws.com";
        static int PORT = 587;


        public static void SendMailViaAmazon(string mailto, string content)
        {
            String SUBJECT = "Welcome to Galaksi Kapında";
            String BODY = content;
            String TO = mailto;

            MailMessage message = new MailMessage();
            message.IsBodyHtml = true;
            message.From = new MailAddress(FROM, FROMNAME);
            message.To.Add(new MailAddress(TO));
            message.Subject = SUBJECT;
            message.Body = BODY;

            using (var client = new SmtpClient(HOST, PORT))
            {
                // Pass SMTP credentials
                client.Credentials =
                    new NetworkCredential(SMTP_USERNAME, SMTP_PASSWORD);

                // Enable SSL encryption
                client.EnableSsl = true;


                client.Send(message);
            }

        }
    }
}
