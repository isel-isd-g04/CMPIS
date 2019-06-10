using System;
using System.Text;
using RabbitMQ.Client;

namespace RemoteServiceServer
{
    public class MessagingPub :IDisposable
    {

        private IConnection rabbitConnection;
        private IModel rabbitChannel;


        public MessagingPub(string remoteIP)
        {

            var factory = new ConnectionFactory() { HostName = remoteIP};
            rabbitConnection = factory.CreateConnection();

            rabbitChannel = rabbitConnection.CreateModel();
            rabbitChannel.QueueDeclare(queue: Helpers.TMAISTopicUser, durable: false, exclusive: false, autoDelete: false,  arguments: null);
            rabbitChannel.QueueDeclare(queue: Helpers.TMAISTopicCMOI, durable: false, exclusive: false, autoDelete: false, arguments: null);
        }
        

        public void PushMessageUserData(string iban, string nif, bool result,float valor)
        {
            string message = String.Format("{0}|{1}|{2}|{3}", iban, nif, result.ToString(), valor.ToString("F"));

            var body = Encoding.UTF8.GetBytes(message);

            rabbitChannel.BasicPublish(exchange: "",
                routingKey: Helpers.TMAISTopicUser,
                basicProperties: null,
                body: body);

            Console.WriteLine("[User] Sent {0}", message);
        }



        public void PushMessageTransfer(string iban, string nif, float valor)
        {
            string message = String.Format("{0}|{1}|{2}", iban, nif, valor.ToString("F"));            
            var body = Encoding.UTF8.GetBytes(message);

            rabbitChannel.BasicPublish(exchange: "",
                routingKey: Helpers.TMAISTopicCMOI,
                basicProperties: null,
                body: body);

            Console.WriteLine("[CMOI] Sent {0}", message);
        }


        public void Dispose()
        {
            rabbitChannel?.Dispose();
            rabbitConnection?.Dispose();
        }
    }
}