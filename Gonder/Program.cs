using RabbitMQ.Client;
using System;
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


            var factory = new ConnectionFactory();
            factory.Uri = new Uri("amqps://fbyckwif:g5RPAMeMvtjN1OWOtwoUPJVARvB1ZaHS@puffin.rmq2.cloudamqp.com/fbyckwif");
            using var connection = factory.CreateConnection();

            var channel = connection.CreateModel();

            channel.QueueDeclare("mesaj-kuyruk", true, false, false);

            var mesaj = "Deneme mesaj";
            var body = Encoding.UTF8.GetBytes(mesaj);
            channel.BasicPublish(String.Empty, "mesaj-kuyruk", null, body);
            Console.WriteLine("Hello World!");
            Console.ReadLine();
        }
    }
}
