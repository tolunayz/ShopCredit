
using RabbitMQ.Client;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShopCredit.Infrastructure.RabbitMQ
{
    internal class Publisher
    {
        public class RabbitMQ_Publisher
        {
            private readonly string RabbitMQ_Uri = "amqps://fjhsmxke:PBNW7X_Toi7qE0fnJZQOQKnl-p0871Bg@rat.rmq2.cloudamqp.com/fjhsmxke";
            public void Publish()
            {
                var factroy = new ConnectionFactory();
                factroy.Uri = new Uri(RabbitMQ_Uri);

                var connection = factroy.CreateConnection();
                var channel = connection.CreateModel();

                channel.QueueDeclare("ShopCredit-queue", true, false, false);

                var message = "kayit kuyruga alındi";
                var body = Encoding.UTF8.GetBytes(message);

                channel.BasicPublish(exchange: "", routingKey: "ShopCredit-queue", basicProperties: null, body: body);



            }
        }
    }
}
