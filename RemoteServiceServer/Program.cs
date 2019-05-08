using System;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Threading.Tasks;
using Grpc.Core;
using Grpc.Core.Utils;
namespace RemoteServiceServer
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("CMPIS listener service is starting!");

            int port = 5000;
            Server server = new Server{
                Services =
                {
                    ValidationService.ValidationService.BindService(new ValidationServiceImpl())
                },
                Ports = {new ServerPort("localhost", port, ServerCredentials.Insecure)}
            };
            server.Start();
            Console.WriteLine("Grpc Server started");
            Console.Read();

        }
    }
}
