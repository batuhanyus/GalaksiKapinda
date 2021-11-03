using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Threading.Tasks;
using RestSharp;
using RestSharp.Authenticators;

namespace Galaxy.PL.CoreMVC.Helpers
{
    public static class MailHelper
    {
        //Uses MailGun.
        public static IRestResponse SendMail(string mailto, string content)
        {
            RestClient client = new ();
            client.BaseUrl = new Uri("https://api.mailgun.net/v3/");
            client.Authenticator =
                new HttpBasicAuthenticator("api",
                    "6d4dbc4f56f3962c7ef20a2606718cd3-10eedde5-ee0d7bee");
            RestRequest request = new();
            request.AddParameter("domain", "sandbox928d5b9c1f524e718348ab6fc7a528dd.mailgun.org", ParameterType.UrlSegment);
            request.Resource = "{domain}/messages";
            request.AddParameter("from", "Excited User oylesineyaratilmishesap@gmail.com");
            request.AddParameter("to", mailto);
            request.AddParameter("subject", "Galaksi Kapında Mail Service");
            request.AddParameter("text", content);
            request.Method = Method.POST;
            return client.Execute(request);
        }
    }
}
