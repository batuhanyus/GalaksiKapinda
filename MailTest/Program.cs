using System;
using System.IO;
using System.Security.Cryptography;
using System.Text;
using RestSharp;
using RestSharp.Authenticators;
public class Program
{
    public static void Main(string[] args)
    {

        Console.WriteLine(SendSimpleMessage().IsSuccessful);
        Console.WriteLine(SendSimpleMessage().Content.ToString());
        Console.ReadKey();
    }
    public static IRestResponse SendSimpleMessage()
    {
        RestClient client = new RestClient();
        client.BaseUrl = new Uri("https://api.mailgun.net/v3/");
        client.Authenticator =
            new HttpBasicAuthenticator("api",
                "6d4dbc4f56f3962c7ef20a2606718cd3-10eedde5-ee0d7bee");
        RestRequest request = new RestRequest();
        request.AddParameter("domain", "sandbox928d5b9c1f524e718348ab6fc7a528dd.mailgun.org", ParameterType.UrlSegment);
        request.Resource = "{domain}/messages";
        request.AddParameter("from", "Excited User oylesineyaratilmishesap@gmail.com");
        request.AddParameter("to", "batuhanavcix@gmail.com");
        request.AddParameter("subject", "Hello");
        request.AddParameter("text", "Testing some Mailgun awesomness!");
        request.Method = Method.POST;
        return client.Execute(request);
    }
}