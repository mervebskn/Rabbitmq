using Newtonsoft.Json;
using RabbitMQ.Client;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RabbitMQ.Producer
{
    public static class Program
    {
        public static void Main(string[] args)
        {
            var factory = new ConnectionFactory
            {
                Uri = new Uri("amqp://guest:guest@localhost:5672")
            };
            using (var connection = factory.CreateConnection())
            using (var channel = connection.CreateModel())
            {
                //channel.QueueDeclare("demo-queue",
                //    durable: true,
                //    exclusive: false,
                //    autoDelete: false,
                //    arguments: null);
                //var message = new { Name = "Producer", Message="This is producer!"};
                //var body = Encoding.UTF8.GetBytes(JsonConvert.SerializeObject(message));

                //channel.BasicPublish("", "demo-queue",null,body);
                //DirectExchangePublisher.Publis(channel);
                //HeaderExchangePublisher.Publis(channel);

                FanoutExchangePublisher.Publis(channel);
            }

        }
    }
}
