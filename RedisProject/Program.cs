using System;

namespace RedisPubSubAlternative
{
    class Program
    {
        static void Main(string[] args)
        {
            string connectionString = "redis-11152.c278.us-east-1-4.ec2.redns.redis-cloud.com:11152,password=UGtXRZtAC1hPTatgOdYgBjOWno8Twieb";

            // Crear y ejecutar el suscriptor en un hilo separado
            Subscriber subscriber = new Subscriber(connectionString);
            subscriber.SubscribeToChannel("test-channel");

            Console.WriteLine("Suscrito al canal 'test-channel'. Presiona cualquier tecla para enviar mensajes...");

            // Crear el publicador
            Publisher publisher = new Publisher(connectionString);

            // Enviar mensajes
            while (true)
            {
                string message = Console.ReadLine();
                publisher.PublishMessage("test-channel", message);
            }
        }
    }
}
