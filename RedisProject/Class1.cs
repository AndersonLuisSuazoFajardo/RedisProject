using StackExchange.Redis;
using System;

namespace RedisPubSubAlternative
{
    class Publisher
    {
        private readonly ISubscriber _subscriber;

        public Publisher(string connectionString)
        {
            // Crear conexión
            var redis = ConnectionMultiplexer.Connect(connectionString);
            _subscriber = redis.GetSubscriber();
        }

        public void PublishMessage(string channel, string message)
        {
            _subscriber.Publish(channel, message);
            Console.WriteLine($"Mensaje publicado en '{channel}': {message}");
        }
    }
}
