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
    public static class TopicExchangePublisher
    {
        public static void Publis(IModel channel)
        {
            var ttle = new Dictionary<string, object>
            {
                {"x-message-title",30000 }
            };

            channel.ExchangeDeclare("demo-topic-exchange", ExchangeType.Topic, arguments: ttle);
            var count = 0;
            while (true)
            {
                var message = new { Name = "Producer", Message = $"Count: {count}" };
                var body = Encoding.UTF8.GetBytes(JsonConvert.SerializeObject(message));

                channel.BasicPublish("demo-topic-exchange", "account.update", null, body);

                count++;
                Thread.Sleep(1000);
            }
        }
    }
}
