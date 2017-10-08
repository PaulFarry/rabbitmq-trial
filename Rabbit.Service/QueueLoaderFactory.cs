using RabbitMQ.Client;
using System;

namespace Rabbit.Service
{
    public class QueueWriterFactory
    {
        private class Queue : IDisposable
        {
            ConnectionFactory factory;
            IConnection connection;
            IModel channel;
            public string Name { get; set; }
            public string Password { get; set; }
            public string Username { get; set; }
            public string Host { get; set; }
            public string VirtualHost { get; set; }

            private string queueName;
            public void Create()
            {
                factory = new ConnectionFactory()
                {
                    HostName = Host,
                    AutomaticRecoveryEnabled = true,
                    UserName = Username,
                    Password = Password,
                    VirtualHost = VirtualHost

                };
                queueName = Name;
                connection = factory.CreateConnection();
                channel = connection.CreateModel();
                channel.QueueDeclare(queueName, true, false, false, null);

            }

            public bool Write(byte[] data)
            {
                if (channel != null && factory != null)
                {
                    channel.BasicPublish(string.Empty, queueName, null, data);
                    return true;
                }
                return false;
            }

            public void Dispose()
            {
                if (factory != null)
                {

                    channel.Dispose();
                    channel = null;
                    connection.Dispose();
                    connection = null;
                    factory = null;
                }
            }
        }


        internal class QueueWriter : IDisposable
        {
            Queue standard;
            Queue priority;


            public QueueWriter()
            {
                var virtualHost = "Dev";
                var user = "Writer";
                var password = "password";
                var host = "localhost";

                //standard = new Queue() { Host = host, VirtualHost = virtualHost, Username = user, Password = password, Name = "standard" };
                standard = new Queue() { Host = host, VirtualHost = virtualHost, Username = user, Password = password, Name = "priority" };
                standard.Create();
                priority = new Queue() { Host = host, VirtualHost = virtualHost, Username = user, Password = password, Name = "priority" };
                priority.Create();
            }


            public bool Write(QueueType queueType, byte[] data)
            {
                Queue queue = null;
                switch (queueType)
                {
                    case QueueType.Standard:
                        queue = standard;
                        break;
                    case QueueType.Priority:
                        queue = priority;
                        break;
                    default:
                        return false;
                }
                return queue.Write(data);
            }


            public void Dispose()
            {
                if (priority != null)
                {
                    priority.Dispose();
                    priority = null;
                }
                if (standard != null)
                {
                    standard.Dispose();
                    standard = null;
                }
            }
        }

        private static QueueWriter instance;

        private static QueueWriter GetInstance()
        {
            if (instance == null)
            {

                instance = new QueueWriter();
            }

            return instance;
        }

        internal static void SetInstance(QueueWriter instance)
        {
            QueueWriterFactory.instance = instance;
        }

        public static bool Write(QueueType queueType, byte[] data)
        {
            var instnace = GetInstance();
            return instance.Write(queueType, data);
        }
    }
}
