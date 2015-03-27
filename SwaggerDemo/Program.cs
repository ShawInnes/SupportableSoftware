using System;
using System.Web.Http;
using Microsoft.Owin.Hosting;

namespace SwaggerDemo
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            var baseAddress = "http://localhost:9999/";

            var config = new HttpConfiguration();
            config.Routes.MapHttpRoute("DefaultApi", "api/{controller}/{id}", new {id = RouteParameter.Optional}
                );

            // Start OWIN host 
            using (WebApp.Start<Startup>(baseAddress))
            {
                Console.WriteLine("serving requests...");
                Console.ReadLine();
            }
        }
    }
}