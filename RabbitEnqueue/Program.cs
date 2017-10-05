using RabbitMQ.Client;
using System;
using System.Text;

namespace RabbitEnqueue
{
    class Program
    {
        static void Main(string[] args)
        {
            var exit = false;

            var factory = new ConnectionFactory() { HostName = "localhost" };
            var queueName = "priority";

            while (!exit)
            {

                using (var connection = factory.CreateConnection())
                using (var channel = connection.CreateModel())
                {
                    channel.QueueDeclare(queue: queueName,
                                         durable: false,
                                         exclusive: false,
                                         autoDelete: false,
                                         arguments: null);

                    string message = $"Hello World {Guid.NewGuid().ToString()}!";
                    var body = Encoding.UTF8.GetBytes(message);

                    channel.BasicPublish(exchange: "",
                                         routingKey: queueName,
                                         basicProperties: null,
                                         body: body);
                    Console.WriteLine(" [x] Sent {0}", message);
                }

                Console.WriteLine(" Type [Exit | X] to exit, Anything else to repeat.");
                var result = Console.ReadLine().Trim();
                if (result.Equals("exit", StringComparison.OrdinalIgnoreCase) || result.Equals("x", StringComparison.OrdinalIgnoreCase))
                {
                    exit = true;
                }
            }
        }
    }
}
