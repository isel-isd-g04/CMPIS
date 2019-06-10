using System;
using System.Globalization;
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

        public EventHandler<BasicDeliverEventArgs> OnUpdate;

        public MessagingSub(string topic)
        {
            var factory = new ConnectionFactory() { HostName = Helpers.MsgConnection };
            rabbitConnection = factory.CreateConnection();

            rabbitChannel = rabbitConnection.CreateModel();
            rabbitChannel.QueueDeclare(queue: Helpers.TMAISTopicUser,
                        durable: false, exclusive: false, autoDelete: false, arguments: null);

            rabbitChannel.QueueDeclare(queue: Helpers.TMAISTopicCMOI,
                durable: false, exclusive: false, autoDelete: false, arguments: null);

            //add a event processor to the listening topic
            var consumerUser = new EventingBasicConsumer(rabbitChannel);
            consumerUser.Received += NotificationProcessorUser;
            rabbitChannel.BasicConsume( queue: Helpers.TMAISTopicUser, autoAck: true, consumer: consumerUser);

            var consumerCMOI = new EventingBasicConsumer(rabbitChannel);
            consumerCMOI.Received += NotificationProcessorCMOI;
            rabbitChannel.BasicConsume(queue: Helpers.TMAISTopicCMOI, autoAck: true, consumer: consumerCMOI);


        }

        private void NotificationProcessorUser(object model, BasicDeliverEventArgs messageNotification)
        {
            var body = messageNotification.Body;
            var message = Encoding.UTF8.GetString(body);
            //Console.WriteLine("User Received {0}", message);

            string[] strArray = message.Split('|');

            if (strArray.Length < 3)
                return;

            string iban = strArray[0];
            string nif = strArray[1];
            bool result = bool.Parse(strArray[2]);
            float value = float.Parse( strArray[3]);
            User user = new User(iban, nif, result, value);

            Persistance.Instance.AddUserTransaction(user);

            if (OnUpdate != null)
                OnUpdate.BeginInvoke(model, messageNotification, null, null);
        }



        private void NotificationProcessorCMOI(object model, BasicDeliverEventArgs messageNotification)
        {
            var body = messageNotification.Body;
            var message = Encoding.UTF8.GetString(body);
            //Console.WriteLine("CMOI Received {0}", message);

            string[] strArray = message.Split('|');

            if (strArray.Length < 2)
                return;

            string iban = strArray[0];
            string nif = strArray[1];
            float value = float.Parse(strArray[2],NumberStyles.Float);

            CmoiData cmoi = new CmoiData(iban,nif,value );
            Persistance.Instance.AddCMOITransaction(cmoi);

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