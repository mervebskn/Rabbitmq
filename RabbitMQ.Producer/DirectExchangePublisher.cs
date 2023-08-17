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
    public static class DirectExchangePublisher
    {
        public static void Publis(IModel channel)
        {
            var title = new Dictionary<string, object>
            {
                {"x-message-title",30000 }
            };

            channel.ExchangeDeclare("demo-direct-exchange", ExchangeType.Direct, arguments: title);
            var count = 0;
            while (true)
            {
                var message = new { Name = "Producer", Message = $"This is producer! {count}" };
                var body = Encoding.UTF8.GetBytes(JsonConvert.SerializeObject(message));

                channel.BasicPublish("demo-direct-exchange", "account.init", null, body);

                count++;
                Thread.Sleep(1000);
            }
        }
    }
}
