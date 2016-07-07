using Microsoft.Owin.Hosting;
using System;

namespace OWINSelfHost.Server
{
    class Program
    {
        static void Main(string[] args)
        {
            string baseUri = "http://localhost:8080";
            Console.WriteLine("Starting Server");
            WebApp.Start<Startup>(baseUri);
            Console.WriteLine("Server Started");
            Console.ReadLine();
        }
    }
}
