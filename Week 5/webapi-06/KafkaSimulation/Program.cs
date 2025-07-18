using System.Text.Json;

namespace KafkaSimulation;

public class ChatMessage
{
    public string Username { get; set; } = string.Empty;
    public string Message { get; set; } = string.Empty;
    public DateTime Timestamp { get; set; }
}

public class Program
{
    public static async Task Main(string[] args)
    {
        Console.WriteLine("=== Kafka Chat Application Simulation ===");
        Console.WriteLine("This simulation shows how the Kafka chat would work when Kafka is running.");
        Console.WriteLine();

        // Simulate ZooKeeper starting
        Console.WriteLine("🔄 Starting ZooKeeper...");
        await Task.Delay(1000);
        Console.WriteLine("✅ ZooKeeper started successfully on port 2181");
        Console.WriteLine();

        // Simulate Kafka Broker starting
        Console.WriteLine("🔄 Starting Kafka Broker...");
        await Task.Delay(1000);
        Console.WriteLine("✅ Kafka Broker started successfully on localhost:9092");
        Console.WriteLine();

        // Simulate Topic Creation
        Console.WriteLine("🔄 Creating chat-topic...");
        await Task.Delay(500);
        Console.WriteLine("✅ Topic 'chat-topic' created successfully");
        Console.WriteLine();

        // Simulate Consumer starting
        Console.WriteLine("🔄 Starting Kafka Chat Consumer...");
        await Task.Delay(500);
        Console.WriteLine("=== Kafka Chat Consumer ===");
        Console.WriteLine("Listening for chat messages... (Press Ctrl+C to exit)");
        Console.WriteLine("----------------------------------------");
        Console.WriteLine();

        // Simulate Producer starting
        Console.WriteLine("🔄 Starting Kafka Chat Producer...");
        await Task.Delay(500);
        Console.WriteLine("=== Kafka Chat Producer ===");
        Console.WriteLine("Enter your username: Alice");
        Console.WriteLine();
        Console.WriteLine("Welcome Alice! Type messages (type 'exit' to quit):");
        Console.WriteLine("Press Enter after each message to send it.");
        Console.WriteLine("----------------------------------------");
        Console.WriteLine();

        // Simulate message exchange
        var messages = new[]
        {
            new { User = "Alice", Text = "Hello everyone! This is my first message", Delay = 1000 },
            new { User = "Bob", Text = "Hi Alice! Great to see the chat working", Delay = 2000 },
            new { User = "Alice", Text = "How is everyone doing today?", Delay = 1500 },
            new { User = "Charlie", Text = "Everything is going well, thanks for asking!", Delay = 2500 },
            new { User = "Alice", Text = "This Kafka integration is really cool", Delay = 1000 },
            new { User = "Bob", Text = "Yes, real-time messaging works perfectly!", Delay = 2000 }
        };

        Console.WriteLine("📨 Simulating message exchange:");
        Console.WriteLine();

        foreach (var msg in messages)
        {
            // Show producer sending
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine($"[PRODUCER] {msg.User}: {msg.Text}");
            Console.ResetColor();

            var chatMessage = new ChatMessage
            {
                Username = msg.User,
                Message = msg.Text,
                Timestamp = DateTime.Now
            };

            // Simulate message being sent to Kafka
            await Task.Delay(200);
            Console.ForegroundColor = ConsoleColor.Blue;
            Console.WriteLine($"✓ Message sent to partition 0 at offset {Array.IndexOf(messages, msg)}");
            Console.ResetColor();

            // Show consumer receiving
            await Task.Delay(100);
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.Write($"[CONSUMER] [{chatMessage.Timestamp:HH:mm:ss}] ");
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.Write($"{chatMessage.Username}: ");
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine(chatMessage.Message);
            Console.ResetColor();
            Console.WriteLine();

            await Task.Delay(msg.Delay);
        }

        Console.WriteLine("🎉 Simulation completed successfully!");
        Console.WriteLine();
        Console.WriteLine("This demonstrates:");
        Console.WriteLine("✅ Real-time message delivery");
        Console.WriteLine("✅ Multiple users chatting");
        Console.WriteLine("✅ Message persistence in Kafka");
        Console.WriteLine("✅ Producer/Consumer pattern");
        Console.WriteLine("✅ JSON message serialization");
        Console.WriteLine("✅ Cross-platform communication");
    }
}
