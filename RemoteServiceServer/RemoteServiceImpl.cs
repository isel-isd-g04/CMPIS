using System;
using System.Threading.Tasks;
using Grpc.Core;
using ValidationModels;

namespace RemoteServiceServer
{
    public class ValidationServiceImpl : ValidationService.ValidationService.ValidationServiceBase, IDisposable
    {

        private MessagingPub tmaisNotifier;


        public ValidationServiceImpl()
        {
            try
            {
                tmaisNotifier = new MessagingPub(Helpers.TMAISTopic);
            }
            catch (Exception e)
            {
                Console.WriteLine("Fail to connect to RabbitMQ. Message:{0}",e.Message);
            }
            
        }

        public override Task<ValidationReply> ValidationSingle(ValidationRequest request, ServerCallContext context)
        {

            Console.WriteLine("CSMP code: {0}", request.CodeCSMP);


            return Task<ValidationReply>.Factory.StartNew(() => Validation(request,context));
            //return base.ValidationSingle(request, context);
        }


        public override Task ValidationStreaming(IAsyncStreamReader<ValidationRequest> requestStream, IServerStreamWriter<ValidationReply> responseStream,
            ServerCallContext context)
        {
            return base.ValidationStreaming(requestStream, responseStream, context);
        }



        private ValidationReply Validation(ValidationRequest requestInfo, ServerCallContext ctx)
        {

            ValidationReply reply = new ValidationReply();

            reply.Authorised = Payment.Instance.Debit(requestInfo.UserFiscalNumber, requestInfo.Price);

            string message = String.Format("{0}|{1}|{2}", requestInfo.UserFiscalNumber, requestInfo.Price, requestInfo.CodeCSMP);

            tmaisNotifier?.PushMessage(message);
            

            return reply;
        }

        public void Dispose()
        {
            tmaisNotifier?.Dispose();
        }
    }

}