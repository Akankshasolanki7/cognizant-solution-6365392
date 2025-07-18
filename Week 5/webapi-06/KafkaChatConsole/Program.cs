using Confluent.Kafka;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace KafkaChatConsole
{
    class Program
    {
        private static readonly string BootstrapServers = "localhost:9092";
        private static readonly string TopicName = "chat-messages";

        static async Task Main(string[] args)
        {
            Console.WriteLine("=== Kafka Chat Application ===");
            Console.WriteLine("Choose mode:");
            Console.WriteLine("1. Producer (Send Messages)");
            Console.WriteLine("2. Consumer (Receive Messages)");
            Console.Write("Enter choice (1 or 2): ");

            var choice = Console.ReadLine();

            switch (choice)
            {
                case "1":
                    await RunProducer();
                    break;
                case "2":
                    await RunConsumer();
                    break;
                default:
                    Console.WriteLine("Invalid choice. Exiting...");
                    break;
            }
        }

        static async Task RunProducer()
        {
            var config = new ProducerConfig
            {
                BootstrapServers = BootstrapServers,
                ClientId = Environment.MachineName
            };

            using var producer = new ProducerBuilder<string, string>(config).Build();

            Console.WriteLine("=== Chat Producer Started ===");
            Console.WriteLine("Enter your username:");
            var username = Console.ReadLine();
            Console.WriteLine($"Welcome {username}! Type messages (type 'exit' to quit):");

            while (true)
            {
                var message = Console.ReadLine();

                if (message?.ToLower() == "exit")
                    break;

                var chatMessage = $"[{DateTime.Now:HH:mm:ss}] {username}: {message}";

                try
                {
                    var deliveryResult = await producer.ProduceAsync(TopicName,
                        new Message<string, string>
                        {
                            Key = username,
                            Value = chatMessage
                        });

                    Console.WriteLine($"Message sent to partition {deliveryResult.Partition} at offset {deliveryResult.Offset}");
                }
                catch (ProduceException<string, string> ex)
                {
                    Console.WriteLine($"Failed to send message: {ex.Error.Reason}");
                }
            }

            producer.Flush(TimeSpan.FromSeconds(10));
            Console.WriteLine("Producer stopped.");
        }

        static async Task RunConsumer()
        {
            var config = new ConsumerConfig
            {
                BootstrapServers = BootstrapServers,
                GroupId = "chat-consumer-group",
                AutoOffsetReset = AutoOffsetReset.Latest,
                EnableAutoCommit = true
            };

            using var consumer = new ConsumerBuilder<string, string>(config).Build();

            Console.WriteLine("=== Chat Consumer Started ===");
            Console.WriteLine("Listening for chat messages... (Press Ctrl+C to exit)");

            consumer.Subscribe(TopicName);

            var cts = new CancellationTokenSource();
            Console.CancelKeyPress += (_, e) =>
            {
                e.Cancel = true;
                cts.Cancel();
            };

            try
            {
                while (!cts.Token.IsCancellationRequested)
                {
                    var consumeResult = consumer.Consume(cts.Token);

                    if (consumeResult?.Message != null)
                    {
                        Console.WriteLine($"Received: {consumeResult.Message.Value}");
                    }
                }
            }
            catch (OperationCanceledException)
            {
                Console.WriteLine("\nConsumer stopped.");
            }
            finally
            {
                consumer.Close();
            }
        }
    }
}
