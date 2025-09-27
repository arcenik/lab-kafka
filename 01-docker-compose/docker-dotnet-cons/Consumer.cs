using Confluent.Kafka;

public class Consumer
{
    ConsumerConfig _consumerConfig;

    public Consumer(string connection)
    {
        _consumerConfig = new ConsumerConfig
        {
            BootstrapServers = connection,
            GroupId = "default",
            AutoOffsetReset = AutoOffsetReset.Earliest,
            EnableAutoCommit = true, // this is the default but good to know about
            EnableAutoOffsetStore = true // this is the default but good to know about
        };
    }

    public void ReceiveMessages(string topic)
    {
        using var consumer = new ConsumerBuilder<string, string>(_consumerConfig).Build();
        consumer.Subscribe(topic);

        while (true)
        {
            Console.WriteLine($"Looking for a message on topic: {topic}");
            var consumeResult = consumer.Consume();

            Console.WriteLine($"Received: '{consumeResult.Message.Value}'. Topic '{consumeResult.Topic}'.");
        }
    }
}
