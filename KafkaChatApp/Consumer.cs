using Confluent.Kafka;

class Consumer
{
    public void Run()
    {
        var config = new ConsumerConfig
        {
            BootstrapServers = "localhost:9092",
            GroupId = "chat-group",
            AutoOffsetReset = AutoOffsetReset.Earliest
        };

        using var c = new ConsumerBuilder<Ignore, string>(config).Build();
        c.Subscribe("chat-topic");

        Console.WriteLine("Listening for messages...");
        while (true)
        {
            var cr = c.Consume();
            Console.WriteLine($"Received: {cr.Message.Value}");
        }
    }
}
