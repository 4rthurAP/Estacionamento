﻿using Estacionamento.CrossCutting.ViewModel;

using RabbitMQ.Client;
using RabbitMQ.Client.Events;

using System;
using System.Text;

public class Receive
{
    public static void Main()
    {
        while (true)
        {
            var factory = new ConnectionFactory() { HostName = "localhost" };
            using var connection = factory.CreateConnection();
            using var channel = connection.CreateModel();
            channel.QueueDeclare(queue: "Order_Queue",
                                 durable: false,
                                 exclusive: false,
                                 autoDelete: false,
                                 arguments: null);

            var consumer = new EventingBasicConsumer(channel);
            consumer.Received += (model, ea) =>
            {
                var body = ea.Body.ToArray();
                var message = Encoding.UTF8.GetString(body);
                var client = System.Text.Json.JsonSerializer.Deserialize<ClientViewModel>(message);
                Console.WriteLine(" [x] Received {0}", message);
                
            };
            channel.BasicConsume(queue: "Order_Queue",
                                 autoAck: true,
                                 consumer: consumer);

            Console.WriteLine(" Press [enter] to exit.");
            Console.ReadLine();
            
            Task.Delay(1000).Wait();
        }
    }
}