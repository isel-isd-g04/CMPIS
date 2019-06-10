using System;
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
                Ports = {new ServerPort("localhost", Helpers.GrpcPort, ServerCredentials.Insecure)}
            };
            server.Start();
            Console.WriteLine("Grpc Server started at port:{0}",Helpers.GrpcPort);
            Console.Read();

        }
    }
}
