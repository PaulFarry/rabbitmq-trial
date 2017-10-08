

using RabbitMQ.Client;
using RabbitMQ.Client.Events;
using System;
using System.IO;
using System.Text;


namespace Dequeue.Subscription
{
    class Program
    {
        static void Main(string[] args)
        {

            Console.WriteLine(" Press [enter] when ready to read.");
            Console.ReadLine();

            var queueName = "priority";

            var factory = new ConnectionFactory() { HostName = "localhost", VirtualHost = "Dev", UserName = "Reader", Password = "password" };
            using (var connection = factory.CreateConnection())
            using (var channel = connection.CreateModel())
            {

                var consumer = new EventingBasicConsumer(channel);
                consumer.Received += (ch, ea) =>
                {
                    var body = ea.Body;

                    var data = Rabbit.Core.Utility.DeSerialise(body);

                    switch(data.MessageType)
                    {
                        
                    }
                    Console.WriteLine(" [x] Received {0}", data.MessageType);

                    channel.BasicAck(ea.DeliveryTag, false);
                };
                String consumerTag = channel.BasicConsume(queueName, false, consumer);
                Console.WriteLine(" Press [enter] when ready to exit.");
                Console.ReadLine();
            }
        }
    }
}
