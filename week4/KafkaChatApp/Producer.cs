using Confluent.Kafka;

class Producer
{
    public async Task RunAsync()
    {
        var config = new ProducerConfig { BootstrapServers = "localhost:9092" };
        using var p = new ProducerBuilder<Null, string>(config).Build();

        while (true)
        {
            Console.Write("Enter message: ");
            var msg = Console.ReadLine();
            var dr = await p.ProduceAsync("chat-topic", new Message<Null, string> { Value = msg });
            Console.WriteLine($"Sent '{msg}' to {dr.TopicPartitionOffset}");
        }
    }
}
