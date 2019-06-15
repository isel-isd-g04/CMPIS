using System;
using System.Threading;
using Grpc.Core;

namespace RemoteServiceServer
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("CMPIS listener service is starting!");
            Helpers.ReadConfigs();
            Server server = new Server{
                Services =
                {
                    ValidationService.ValidationService.BindService(new ValidationServiceImpl())
                },
                Ports = {new ServerPort("0.0.0.0", Helpers.GrpcPort, ServerCredentials.Insecure)}
            };
            server.Start();
            Console.WriteLine("Grpc Server started at port:{0}",Helpers.GrpcPort);
            while (true)
            {
                Thread.Sleep(5000);
            }
            //Console.Read();

        }
    }
}
