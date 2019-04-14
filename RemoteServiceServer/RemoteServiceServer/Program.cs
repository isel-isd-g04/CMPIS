using System;
using Grpc.Core;
using Grpc.Core.Utils;


namespace RemoteServiceServer
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
            const Int32 Port = 50052;
  var server = new Server
            {
                Services = { ValidationService.ValidationServiceReflection.BindService(new ValidationServiceImpl()) },
                Ports = { new ServerPort("127.0.0.1", 5000, ServerCredentials.Insecure) }
            };
            server.Start();

            Console.WriteLine("RouteGuide server listening on port " + Port);
            Console.WriteLine("Press any key to stop the server...");
            Console.ReadKey();

            server.ShutdownAsync().Wait();

        }
    }
}
