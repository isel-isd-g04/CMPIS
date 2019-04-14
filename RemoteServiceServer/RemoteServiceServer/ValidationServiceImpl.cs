using System;
using System.Collections.Generic;
using System.Text;
using Grpc.Core;

namespace RemoteServiceServer
{
    class ValidationServiceImpl 
    {

        public ValidationServiceImpl()
        {
            var server = new Server
            {
                Services = { ValidationService.ValidationServiceReflection.BindService(new ValidationServiceImpl()) },
                Ports = { new ServerPort("127.0.0.1", 5000, ServerCredentials.Insecure) }
            };
            server.Start();
        }
    }
}
