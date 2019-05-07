using System;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Grpc.Core;
using Grpc.Core.Utils;


namespace RemoteServiceServer
{
    class Program
    {   
		public static void Main(string[] args)
        {
            //CreateHostBuilder(args).Build().Run();

        
            int port = 5000;
            Console.WriteLine("Hello World!");
            Server server = new Server{
                Services = {ValidationService.BindService(new ValidationService())},
                Ports = {new ServerPort("localhost", port, ServerCredentials.Insecure)}
            };
            server.Start();
            Console.WriteLine("Grpc Server started");
            Console.Read();
            shutdown.WaitOne();
        

        }

    //     public static IHostBuilder CreateHostBuilder(string[] args) =>
    //         Host.CreateDefaultBuilder(args)
    //             .ConfigureWebHostDefaults(webBuilder =>
    //             {
    //                 webBuilder.UseStartup<Startup>();
    //             });	
     }	
}
