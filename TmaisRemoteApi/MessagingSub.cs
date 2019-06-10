using System;
using System.Text;
using RabbitMQ.Client;
using RabbitMQ.Client.Events;
using TmaisRemoteApi;

namespace TMAISAPI
{
    public class MessagingSub : IDisposable
    {
        private IConnection rabbitConnection;
        private IModel rabbitChannel;
        private string eventTopic;

        public EventHandler<BasicDeliverEventArgs> OnUpdate;

        public MessagingSub(string topic)
        {
            var factory = new ConnectionFactory() { HostName = "localhost" };
            eventTopic = topic;
            rabbitConnection = factory.CreateConnection();

            rabbitChannel = rabbitConnection.CreateModel();
            rabbitChannel.QueueDeclare(queue: eventTopic,
                        durable: false, exclusive: false, autoDelete: false, arguments: null);
            
            //add a event processor to the listening topic
            var consumer = new EventingBasicConsumer(rabbitChannel);
            consumer.Received += NotificationProcessor;
            
            rabbitChannel.BasicConsume(queue: eventTopic,
                autoAck: true, consumer: consumer);

        }

        private void NotificationProcessor(object model, BasicDeliverEventArgs messageNotification)
        {
            var body = messageNotification.Body;
            var message = Encoding.UTF8.GetString(body);
            Console.WriteLine(" [x] Received {0}", message);
            //Persistance.Instance.AddCMOITransaction();

            if (OnUpdate != null)
                OnUpdate.BeginInvoke(model, messageNotification, null, null);
        }


        
        public void Dispose()
        {
            rabbitConnection?.Dispose();
            rabbitChannel?.Dispose();
        }
    }
}