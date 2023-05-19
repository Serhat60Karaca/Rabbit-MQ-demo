using RabbitMQ.Client;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gonder
{
    internal class Program
    {
        static void Main(string[] args)
        {
            for (int i = 0; i < 10; i++)
            {
                MesajGonder();
            }
        }
        public static void MesajGonder()
        {
            var factory = new ConnectionFactory();//rabbit mq(host) ya bağlanmak için kullanılır
            factory.Uri = new Uri("amqps://avyxqfbb:ym0Ukt7rJTj5-TCiU38ZfOrkDDlW6pOV@sparrow.rmq.cloudamqp.com/avyxqfbb");//Url yapıştırdık

            var connection = factory.CreateConnection();//bağlantı oluştur

            var channel = connection.CreateModel();//channel oluşyur

            channel.QueueDeclare("mesaz-kuyruk", true, false, false);//kuyruk adı, memory dışında tutulsun mu, bağlantıya dışardan erişilebilsin mi,alıcı bağlantıyı terk ettiğinde mesaj silinsin mi
            var message = "mesaz deneme basarili";//gönderilecek mesaj

            var body = Encoding.UTF8.GetBytes(message);

            channel.BasicPublish(String.Empty, "mesaz-kuyruk", null, body);//kuyruğu kanala ekledik
            Console.WriteLine("mesaz tavsan");
            Console.ReadLine();
        }
    }
}
