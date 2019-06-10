using System;
using System.Text;
using RabbitMQ.Client;

namespace RemoteServiceServer
{
    public class MessagingPub :IDisposable
    {

        private IConnection rabbitConnection;
        private IModel rabbitChannel;
        private string pubTopic;


        public MessagingPub(string topic)
        {

            var factory = new ConnectionFactory() { HostName = "localhost"};
            rabbitConnection = factory.CreateConnection();
            pubTopic = topic;

            rabbitChannel = rabbitConnection.CreateModel();
            rabbitChannel.QueueDeclare(queue: pubTopic, durable: false, exclusive: false, autoDelete: false,  arguments: null);
        }
        

        public void PushMessage(string message)
        {
            var body = Encoding.UTF8.GetBytes(message);

            rabbitChannel.BasicPublish(exchange: "",
                routingKey: pubTopic,
                basicProperties: null,
                body: body);

            Console.WriteLine("[x] Sent {0}", message);
        }
        

        public void Dispose()
        {
            rabbitChannel?.Dispose();
            rabbitConnection?.Dispose();
        }
    }
}