using Confluent.Kafka;
using System.Text.Json;

namespace KafkaChatProducer;

public class ChatMessage
{
    public string Username { get; set; } = string.Empty;
    public string Message { get; set; } = string.Empty;
    public DateTime Timestamp { get; set; }
}

public class Program
{
    private const string BootstrapServers = "localhost:9092";
    private const string TopicName = "chat-topic";

    public static async Task Main(string[] args)
    {
        Console.Title = "Kafka Chat Producer";
        Console.ForegroundColor = ConsoleColor.Green;
        Console.WriteLine("╔══════════════════════════════════════╗");
        Console.WriteLine("║        KAFKA CHAT PRODUCER          ║");
        Console.WriteLine("╚══════════════════════════════════════╝");
        Console.ResetColor();
        Console.WriteLine();

        // Get username
        Console.Write("Enter your username: ");
        var username = Console.ReadLine();

        if (string.IsNullOrWhiteSpace(username))
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("❌ Username cannot be empty!");
            Console.ResetColor();
            Console.WriteLine("Press any key to exit...");
            Console.ReadKey();
            return;
        }

        // Configure Kafka producer
        var config = new ProducerConfig
        {
            BootstrapServers = BootstrapServers,
            ClientId = Environment.MachineName,
            MessageTimeoutMs = 10000,
            RequestTimeoutMs = 5000
        };

        try
        {
            using var producer = new ProducerBuilder<Null, string>(config).Build();

            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine($"\n🎉 Welcome {username}! You're now connected to the chat.");
            Console.WriteLine("💬 Type your messages below (type 'exit' to quit):");
            Console.WriteLine("📤 Press Enter after each message to send it.");
            Console.WriteLine("═══════════════════════════════════════════════════");
            Console.ResetColor();
            Console.WriteLine();

            while (true)
            {
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.Write($"{username}> ");
                Console.ResetColor();

                var message = Console.ReadLine();

                if (string.IsNullOrWhiteSpace(message))
                    continue;

                if (message.ToLower() == "exit")
                {
                    Console.ForegroundColor = ConsoleColor.Magenta;
                    Console.WriteLine("👋 Goodbye! Disconnecting from chat...");
                    Console.ResetColor();
                    break;
                }

                var chatMessage = new ChatMessage
                {
                    Username = username,
                    Message = message,
                    Timestamp = DateTime.Now
                };

                var messageJson = JsonSerializer.Serialize(chatMessage);

                try
                {
                    var deliveryResult = await producer.ProduceAsync(TopicName, new Message<Null, string>
                    {
                        Value = messageJson
                    });

                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.WriteLine($"   ✓ Delivered to partition {deliveryResult.Partition}, offset {deliveryResult.Offset}");
                    Console.ResetColor();
                }
                catch (ProduceException<Null, string> e)
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine($"   ❌ Failed to send: {e.Error.Reason}");
                    Console.ResetColor();
                }
                catch (Exception ex)
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine($"   ❌ Error: {ex.Message}");
                    Console.ResetColor();
                }
            }
        }
        catch (Exception ex)
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine($"❌ Failed to connect to Kafka: {ex.Message}");
            Console.WriteLine("💡 Make sure Kafka is running on localhost:9092");
            Console.ResetColor();
            Console.WriteLine("\nPress any key to exit...");
            Console.ReadKey();
        }
    }
}
