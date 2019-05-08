using System;
using System.Threading.Tasks;
using Grpc.Core;
using ValidationModels;

namespace RemoteServiceServer
{


    public class ValidationServiceImpl : ValidationService.ValidationService.ValidationServiceBase
    {
        public ValidationServiceImpl()
        {

        }

        public override Task<ValidationReply> ValidationSingle(ValidationRequest request, ServerCallContext context)
        {

            Console.WriteLine("{0}", request.CodeCSMP);

            
            return base.ValidationSingle(request, context);
        }


        public override Task ValidationStreaming(IAsyncStreamReader<ValidationRequest> requestStream, IServerStreamWriter<ValidationReply> responseStream,
            ServerCallContext context)
        {
            return base.ValidationStreaming(requestStream, responseStream, context);
        }
    }

}