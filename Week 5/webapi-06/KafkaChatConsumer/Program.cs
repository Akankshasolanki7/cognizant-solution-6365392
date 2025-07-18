using Confluent.Kafka;
using System.Text.Json;

namespace KafkaChatConsumer;

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
    private const string ConsumerGroupId = "chat-consumer-group";

    public static async Task Main(string[] args)
    {
        Console.Title = "Kafka Chat Consumer";
        Console.ForegroundColor = ConsoleColor.Blue;
        Console.WriteLine("╔══════════════════════════════════════╗");
        Console.WriteLine("║        KAFKA CHAT CONSUMER          ║");
        Console.WriteLine("╚══════════════════════════════════════╝");
        Console.ResetColor();
        Console.WriteLine();

        Console.ForegroundColor = ConsoleColor.Cyan;
        Console.WriteLine("🔄 Connecting to Kafka...");
        Console.ResetColor();

        var config = new ConsumerConfig
        {
            BootstrapServers = BootstrapServers,
            GroupId = ConsumerGroupId,
            AutoOffsetReset = AutoOffsetReset.Latest,
            EnableAutoCommit = true,
            SessionTimeoutMs = 10000,
            HeartbeatIntervalMs = 3000
        };

        try
        {
            using var consumer = new ConsumerBuilder<Ignore, string>(config).Build();
            consumer.Subscribe(TopicName);

            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("✅ Connected successfully!");
            Console.WriteLine("📨 Listening for chat messages...");
            Console.WriteLine("🛑 Press Ctrl+C to exit");
            Console.WriteLine("═══════════════════════════════════════════════════");
            Console.ResetColor();
            Console.WriteLine();

            var cts = new CancellationTokenSource();
            Console.CancelKeyPress += (_, e) =>
            {
                e.Cancel = true;
                cts.Cancel();
                Console.ForegroundColor = ConsoleColor.Magenta;
                Console.WriteLine("\n\n🛑 Shutting down consumer...");
                Console.ResetColor();
            };

            int messageCount = 0;

            while (!cts.Token.IsCancellationRequested)
            {
                try
                {
                    var consumeResult = consumer.Consume(cts.Token);

                    if (consumeResult?.Message?.Value != null)
                    {
                        var chatMessage = JsonSerializer.Deserialize<ChatMessage>(consumeResult.Message.Value);
                        if (chatMessage != null)
                        {
                            messageCount++;

                            // Display message with enhanced formatting
                            Console.ForegroundColor = ConsoleColor.DarkGray;
                            Console.Write($"[{messageCount:D3}] ");
                            Console.ForegroundColor = ConsoleColor.Cyan;
                            Console.Write($"[{chatMessage.Timestamp:HH:mm:ss}] ");
                            Console.ForegroundColor = ConsoleColor.Yellow;
                            Console.Write($"{chatMessage.Username}: ");
                            Console.ForegroundColor = ConsoleColor.White;
                            Console.WriteLine(chatMessage.Message);
                            Console.ResetColor();
                        }
                    }
                }
                catch (ConsumeException e)
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine($"❌ Error consuming message: {e.Error.Reason}");
                    Console.ResetColor();
                }
                catch (OperationCanceledException)
                {
                    break;
                }
                catch (Exception ex)
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine($"❌ Unexpected error: {ex.Message}");
                    Console.ResetColor();
                }
            }

            consumer.Close();
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine($"\n✅ Consumer closed. Total messages received: {messageCount}");
            Console.ResetColor();
        }
        catch (Exception ex)
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine($"❌ Failed to connect to Kafka: {ex.Message}");
            Console.WriteLine("💡 Make sure Kafka is running on localhost:9092");
            Console.WriteLine("💡 Make sure the 'chat-topic' exists");
            Console.ResetColor();
            Console.WriteLine("\nPress any key to exit...");
            Console.ReadKey();
        }
    }
}
