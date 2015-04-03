using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using stubby;
using stubby.Domain;

namespace StubbyDemo
{
    class Program
    {
        static void Main(string[] args)
        {
            Stubby stubby = new Stubby(new Arguments
            {
                Data = "stubby.yaml",
                Mute = false
            });

            uint id = 0;

            Endpoint endpoint = new Endpoint();
            endpoint.Request.Method.Add("GET");
            endpoint.Request.Url = "/healthcheck";
            endpoint.Responses.Add(new Response
            {
                Body = "PASS",
                Status = 200
            });
            stubby.Add(endpoint, out id);
            stubby.Start();

            Console.WriteLine("Waiting...");
            Console.ReadLine();
            stubby.Stop();
        }
    }
}
