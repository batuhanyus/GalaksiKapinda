using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using RestSharp.Authenticators;
using RestSharp;

namespace MailTest
{
    public static class MailHelper
    {
        static String FROM = "oylesineyaratilmishesap@gmail.com";
        static String FROMNAME = "Galaksi Kapında";
        static String SMTP_USERNAME = "AKIAVJVA3DZCV6FK3XL2";
        static String SMTP_PASSWORD = "BLc71ij8COgxC2ODY//+qr86i+s/RZDWc5ucpHYUDBzN";
        static String HOST = "email-smtp.us-west-2.amazonaws.com";
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

        private const string APIKey = "xxxxxxxxxxxxxxx-xxxxx-xxxxx";
        private const string BaseUri = "https://api.mailgun.net/v3";
        private const string Domain = "xxxxxx.xxx";
        private const string SenderAddress = "sender@xxxxxxxx.xxx";
        private const string SenderDisplayName = "Sender Name";
        private const string Tag = "sampleTag";

        public static IRestResponse SendEmail(UserEmailOptions userEmailOptions)
        {

            RestClient client = new RestClient
            {
                BaseUrl = new Uri(BaseUri),
                Authenticator = new HttpBasicAuthenticator("api", APIKey)
            };

            RestRequest request = new RestRequest();
            request.AddParameter("domain", Domain, ParameterType.UrlSegment);
            request.Resource = "{domain}/messages";
            request.AddParameter("from", $"{SenderDisplayName} <{SenderAddress}>");

            foreach (var toEmail in userEmailOptions.ToEmails)
            {
                request.AddParameter("to", toEmail);
            }

            request.AddParameter("subject", userEmailOptions.Subject);
            request.AddParameter("html", userEmailOptions.Body);
            request.AddParameter("o:tag", Tag);
            request.Method = Method.POST;
            return client.Execute(request);
        }

        public static void SendMailViaMailGun()
        {

        }
    }

}



public class UserEmailOptions
{
    public List<string> ToEmails { get; set; }
    public string Subject { get; set; }
    public string Body { get; set; }
}
}
