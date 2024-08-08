//using RabbitMQ.Client;
//using System.Text;
//using Microsoft.Extensions.Options;
//using RabbitMQ.Client.Events;
//using System.Runtime.InteropServices;
//using System;

//namespace ShopCredit.Application.Services
//{
//    public class NotificationSender
//    {
//        private readonly RabbitMQSettings _settings;

//        public NotificationSender(IOptions<RabbitMQSettings> settings)
//        {
//            _settings = settings.Value;
//        }

//        public void SendNotification(string message)
//        {
//            var factory = new ConnectionFactory()
//            {
//                HostName = _settings.Hostname,
//                UserName = _settings.Username,
//                Password = _settings.Password,
//                VirtualHost = _settings.Username,
//                Port = 5672,
//                //Uri = new Uri("amqps://fjhsmxke:PBNW7X_Toi7qE0fnJZQOQKnl-p0871Bg@rat.rmq2.cloudamqp.com/fjhsmxke")
//            };
//            using var connection = factory.CreateConnection();
//            using var channel = connection.CreateModel();

//            channel.QueueDeclare(queue: "notifications", durable: false, exclusive: false, autoDelete: false, arguments: null);

//            var body = Encoding.UTF8.GetBytes(message);
//            var consumer = new EventingBasicConsumer(channel);

//            channel.BasicPublish(exchange: "", routingKey: "notifications", basicProperties: null, body: body);
//            Console.WriteLine(" [x] Sent {0}", message);
//        }

//        public void ReadNotification(string message)
//        {
//            var factory = new ConnectionFactory()
//            {
//                HostName = _settings.Hostname,
//                UserName = _settings.Username,
//                Password = _settings.Password,
//                VirtualHost = _settings.Username,
//                Port = 5672,
//                //Uri = new Uri("amqps://fjhsmxke:PBNW7X_Toi7qE0fnJZQOQKnl-p0871Bg@rat.rmq2.cloudamqp.com/fjhsmxke")
//            };
//            using var connection = factory.CreateConnection();
//            using var channel = connection.CreateModel();

//            channel.QueueDeclare(queue: "notifications", durable: false, exclusive: false, autoDelete: false, arguments: null);

//            var body = Encoding.UTF8.GetBytes(message);
//            var consumer = new EventingBasicConsumer(channel);
//            channel.BasicConsume("notifications", true, consumer);
//            consumer.Received += Consumer_Received;

//        }

//        private void Consumer_Received(object? sender, BasicDeliverEventArgs e)
//        {
//            var message = Encoding.UTF8.GetString(e.Body.ToArray());
//            Console.WriteLine("Received Message: " + message);

//        }

//        //public static IBusControl ConfigureBus(Action<IRabbitMqBusFactoryConfigurator> registrationAction = null)
//        //{
//        //    return Bus.Factory.CreateUsingRabbitMq(configuration =>
//        //    {
//        //        configuration.Host(RabbitMQConstants.Uri, hostConfiguration =>
//        //        {
//        //            hostConfiguration.Username(RabbitMQConstants.Username);
//        //            hostConfiguration.Password(RabbitMQConstants.Password);
//        //        });

//        //        registrationAction?.Invoke(configuration);
//        //    });
//        //}
//    }
//}


using RabbitMQ.Client;
using RabbitMQ.Client.Events;
using System.Text;
using System;
using Microsoft.Extensions.Options;

namespace ShopCredit.Application.Services
{
    public class NotificationSender
    {
        private readonly RabbitMQSettings _settings;

        public NotificationSender(IOptions<RabbitMQSettings> settings)
        {
            _settings = settings.Value;
        }

        public void StartConsuming()
        {
            var factory = new ConnectionFactory()
            {
                HostName = _settings.Hostname,
                UserName = _settings.Username,
                Password = _settings.Password,
                VirtualHost = _settings.Username,
                Port = 5672,
            };

            var connection = factory.CreateConnection();
            var channel = connection.CreateModel();
            channel.QueueDeclare(queue: "notifications", durable: false, exclusive: false, autoDelete: false, arguments: null);
            var consumer = new EventingBasicConsumer(channel);
            consumer.Received += Consumer_Received;
            channel.BasicConsume(queue: "notifications", autoAck: true, consumer: consumer);
        }

        private void Consumer_Received(object? sender, BasicDeliverEventArgs e)
        {
            var message = Encoding.UTF8.GetString(e.Body.ToArray());
            Console.WriteLine($"Gelen consumed : " + message);
        }
    }
}
