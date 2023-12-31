﻿using Confluent.Kafka;

var config = new ConsumerConfig { GroupId = "group-test", BootstrapServers = "localhost:9092" };

using var consumer = new ConsumerBuilder<string, string>(config).Build();

consumer.Subscribe("test-topic");
while (true)
{
    var result = consumer.Consume();
    Console.WriteLine($"Message: {result.Message.Key} - {result.Message.Value}");
}
