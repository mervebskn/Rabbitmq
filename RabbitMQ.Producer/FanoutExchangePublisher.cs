using Newtonsoft.Json;
using RabbitMQ.Client;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace RabbitMQ.Producer
{
    public static class FanoutExchangePublisher
    {
        public static void Publis(IModel channel)
        {
            var ttle = new Dictionary<string, object>
            {
                {"x-message-title",30000 }
            };

            channel.ExchangeDeclare("demo-fanout-exchange", ExchangeType.Fanout, arguments: ttle);
            var count = 0;
            while (true)
            {
                var message = new { Name = "Producer", Message = $"Count: {count}" };
                var body = Encoding.UTF8.GetBytes(JsonConvert.SerializeObject(message));

                var properties = channel.CreateBasicProperties();
                properties.Headers = new Dictionary<string, object> { { "account", "update" } };

                channel.BasicPublish("demo-fanout-exchange", string.Empty, properties, body);

                count++;
                Thread.Sleep(1000);
            }
        }
    }
}
