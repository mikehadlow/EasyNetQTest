using EasyNetQ;
using System;
using System.Threading.Tasks;

namespace MultiBindingTestConsumer
{
    class MultiBindingConsumerProgram
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Starting Consumer...");

            using var bus = RabbitHutch.CreateBus("host=localhost").Advanced;

            var exchange = bus.ExchangeDeclare(Messages.Constants.MultiBindingExchange, "topic");
            var queue = bus.QueueDeclare("multibinding.test.consumer");

            // create 1000 bindings
            for(var i1=0; i1<10; i1++)
            {
                for(var i2=0; i2<10; i2++)
                {
                    for(var i3=0; i3<10; i3++)
                    {
                        bus.Bind(exchange, queue, $"{i1}.{i2}.{i3}");
                    }
                }
            }

            bus.Consume<Messages.TextMessage>(queue, async (msg, info) => 
            {
                Console.WriteLine($"Message: {msg.Body.Text}");
                await Task.Delay(10);
            });

            Console.WriteLine("Consumer started. Enter to quit");
            Console.ReadLine();
        }
    }
}
