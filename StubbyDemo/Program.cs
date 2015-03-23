using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using stubby;

namespace StubbyDemo
{
    class Program
    {
        static void Main(string[] args)
        {
            /*
               Admin = 8889;
               Stubs = 8882;
               Tls = 7443;
               Location = "localhost";
               Data = null;
               Mute = true;
               Watch = false;
             */
            Stubby stubby = new Stubby(new Arguments
            {
                Data="stubby.yaml",
                Mute = false
            });

            stubby.Start();

            Console.WriteLine("Waiting...");
            Console.ReadLine();
            stubby.Stop();
        }
    }
}
