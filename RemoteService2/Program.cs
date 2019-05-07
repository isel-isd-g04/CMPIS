using System;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
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
                Services = {ValidationService.ValidationService.BindService(new ValidationServiceImpl())},
                Ports = {new ServerPort("localhost", port, ServerCredentials.Insecure)}
            };
            server.Start();
            Console.WriteLine("Grpc Server started");
            Console.Read();
            //shutdown.WaitOne();
        

        }

   
     }	
}
