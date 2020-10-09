using EasyNetQ;
using EasyNetQ.Topology;
using System;

namespace MultiBindingTestProducer
{
    class MultiBindingProducerProgram
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Starting Producer...");

            using var bus = RabbitHutch.CreateBus("host=localhost").Advanced;

            var exchange = bus.ExchangeDeclare(Messages.Constants.MultiBindingExchange, ExchangeType.Topic);

            // publish 1000 messages to each binding
            for (var i1 = 0; i1 < 10; i1++)
            {
                for (var i2 = 0; i2 < 10; i2++)
                {
                    for (var i3 = 0; i3 < 10; i3++)
                    {
                        var routingKey = $"{i1}.{i2}.{i3}";
                        Publish(routingKey);
                    }
                }
            }

            void Publish(string routingKey) => 
                bus.Publish(exchange, routingKey, false, new Message<Messages.TextMessage>(new Messages.TextMessage 
                {
                    Text = routingKey
                }));
        }
    }
}
