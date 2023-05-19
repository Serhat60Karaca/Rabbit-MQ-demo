using RabbitMQ.Client;
using RabbitMQ.Client.Events;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MesajıYakala
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var factory = new ConnectionFactory();
            factory.Uri = new Uri("amqps://avyxqfbb:ym0Ukt7rJTj5-TCiU38ZfOrkDDlW6pOV@sparrow.rmq.cloudamqp.com/avyxqfbb");
            var connection = factory.CreateConnection();

            var channel = connection.CreateModel();
            channel.QueueDeclare("mesaz-kuyruk", true, false, false);
            var consumer = new EventingBasicConsumer(channel);//kuyruktaki yapıyı yakalamak için
            channel.BasicConsume("mesaz-kuyruk",true, consumer);

            consumer.Received += Consumer_Received;
            Console.ReadLine();
        }

        private static void Consumer_Received(object sender, BasicDeliverEventArgs e)
        {
            Console.WriteLine("Gelen mesaz" + Encoding.UTF8.GetString(e.Body.ToArray()));
        }
    }
}
