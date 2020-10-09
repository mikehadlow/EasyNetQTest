using System;
using RabbitMQ.Client;

namespace RabbitMqClientConnection
{
    class Program
    {
        static void Main(string[] args)
        {
            var timeout = TimeSpan.FromSeconds(72);
            //var connectionFactory = new ConnectionFactory
            //{
            //    HostName = "localhost",
            //    ContinuationTimeout = timeout,
            //    HandshakeContinuationTimeout = timeout,
            //    RequestedConnectionTimeout = timeout,
            //    SocketReadTimeout = timeout,
            //    SocketWriteTimeout = timeout
            //};
            var connectionFactory = new ConnectionFactory
            {
                Uri = new Uri(@"amqp://localhost/?connection_timeout=72000")
            };

            using var connection = connectionFactory.CreateConnection();

            Console.WriteLine("connected! Hit return to end.");
            Console.ReadLine();
        }
    }
}
