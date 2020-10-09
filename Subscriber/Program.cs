using System;
using EasyNetQ;
using Messages;

namespace Subscriber
{
    class Program
    {
        static void Main(string[] args)
        {
            using (var bus = RabbitHutch.CreateBus("amqp://localhost/;timeout=72"))
            //using (var bus = RabbitHutch.CreateBus("host=localhost;timeout=72"))
            {
                bus.Subscribe<TextMessage>("test", HandleTextMessage);

                Console.WriteLine("Listening for messages. Hit <return> to quit.");
                Console.ReadLine();
            }
        }

        static void HandleTextMessage(TextMessage textMessage)
        {
            Console.WriteLine("Got message: {0}", textMessage.Text);
        }
    }
}