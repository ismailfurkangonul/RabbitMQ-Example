using RabbitMQ.Client;
using RabbitMQ.Client.Events;
using System;
using System.Text;

namespace MesajiYakala
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var factory = new ConnectionFactory();
            factory.Uri = new Uri("amqps://fbyckwif:g5RPAMeMvtjN1OWOtwoUPJVARvB1ZaHS@puffin.rmq2.cloudamqp.com/fbyckwif");
           using var connection = factory.CreateConnection();
            
            var channel = connection.CreateModel();
            channel.QueueDeclare("mesaj-kuyruk", true, false, false);
            var consumer = new EventingBasicConsumer(channel);
            channel.BasicConsume("mesaj-kuyruk", true, consumer);
            consumer.Received += Consumer_Received; 
            Console.ReadLine(); 
        }
        private static void Consumer_Received(object sender, BasicDeliverEventArgs e)
        {
            Console.WriteLine("Gelen Mesaj:" + Encoding.UTF8.GetString(e.Body.ToArray()));


        }
            
    }
}
