using System;
using EasyNetQ;
using Messages;

namespace Publisher
{
    class Program
    {
        static void Main(string[] args)
        {
            using (var bus = RabbitHutch.CreateBus("host=localhost"))
            {
                var input = "";
                Console.WriteLine("Enter a message. 'q' to quit.");
                while ((input = Console.ReadLine()) != "q")
                {
                    bus.Publish(new TextMessage
                        {
                            Text = input
                        });
                }
            }
        }
    }
}