using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Http.SelfHost;


namespace One.Services.API.Gateway
{
    class Program
    {
        static void Main(string[] args)
        {
            var config = new HttpSelfHostConfiguration("http://localhost:9091");
            config.MapHttpAttributeRoutes();

            using (HttpSelfHostServer server = new HttpSelfHostServer(config))
            {
                server.OpenAsync().Wait();
                Console.WriteLine("Server is started...");
                while(Console.ReadKey().Key != ConsoleKey.Escape)
                {

                }
            }
        }
    }
}
