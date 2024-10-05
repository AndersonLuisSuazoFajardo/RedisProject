using StackExchange.Redis;
using System;

namespace RedisPubSubAlternative
{
    class Subscriber
    {
        private readonly ISubscriber _subscriber;

        public Subscriber(string connectionString)
        {
            // Crear conexión
            var redis = ConnectionMultiplexer.Connect(connectionString);
            _subscriber = redis.GetSubscriber();
        }

        public void SubscribeToChannel(string channel)
        {
            _subscriber.Subscribe(channel, (ch, message) =>
            {
                Console.WriteLine($"Mensaje recibido en '{channel}': {message}");
            });
        }
    }
}
