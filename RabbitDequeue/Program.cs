using RabbitMQ.Client;
using System;
using System.Text;

namespace RabbitDequeue
{
    class Program
    {
        static void Main(string[] args)
        {

            Console.WriteLine(" Press [enter] when ready to read.");
            Console.ReadLine();

            var queueName = "priority";
            var factory = new ConnectionFactory() { HostName = "localhost" };
            using (var connection = factory.CreateConnection())
            using (var channel = connection.CreateModel())
            {
                channel.QueueDeclare(queue: queueName, durable: false, exclusive: false, autoDelete: false, arguments: null);
                var mm = channel.MessageCount(queueName);

                while (true)
                {


                    bool noAck = false;
                    BasicGetResult result = channel.BasicGet(queueName, noAck);
                    if (result == null)
                    {
                        // No message available at this time.
                        System.Threading.Thread.Sleep(1000);
                    }
                    else
                    {
                        IBasicProperties props = result.BasicProperties;
                        byte[] body = result.Body;
                        var message = Encoding.UTF8.GetString(body);
                        Console.WriteLine(" [x] Received {0}", message);
                        // acknowledge receipt of the message
                        channel.BasicAck(result.DeliveryTag, false);

                        System.Threading.Thread.Sleep(50);
                    }
                }
            }
        }
    }
}
