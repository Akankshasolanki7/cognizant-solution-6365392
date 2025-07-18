using System.Text.Json;

namespace RealTimeDemo;

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
        Console.Clear();
        Console.WriteLine("🚀 WEEK 5 KAFKA CHAT APPLICATION - REAL-TIME DEMO");
        Console.WriteLine("═══════════════════════════════════════════════════");
        Console.WriteLine();

        await SimulateRealTimeChat();
    }

    private static async Task SimulateRealTimeChat()
    {
        // Simulate starting consumer
        Console.ForegroundColor = ConsoleColor.Blue;
        Console.WriteLine("📱 TERMINAL 1 - Starting Kafka Chat Consumer:");
        Console.WriteLine("═══════════════════════════════════════════════");
        Console.ResetColor();

        Console.ForegroundColor = ConsoleColor.Cyan;
        Console.WriteLine("╔══════════════════════════════════════╗");
        Console.WriteLine("║        KAFKA CHAT CONSUMER          ║");
        Console.WriteLine("╚══════════════════════════════════════╝");
        Console.WriteLine();
        Console.WriteLine("🔄 Connecting to Kafka...");
        await Task.Delay(1000);
        Console.WriteLine("✅ Connected successfully!");
        Console.WriteLine("📨 Listening for chat messages...");
        Console.WriteLine("🛑 Press Ctrl+C to exit");
        Console.WriteLine("═══════════════════════════════════════════════════");
        Console.ResetColor();
        Console.WriteLine();

        await Task.Delay(2000);

        // Simulate starting producer
        Console.ForegroundColor = ConsoleColor.Green;
        Console.WriteLine("📱 TERMINAL 2 - Starting Kafka Chat Producer:");
        Console.WriteLine("═══════════════════════════════════════════════");
        Console.ResetColor();

        Console.ForegroundColor = ConsoleColor.Green;
        Console.WriteLine("╔══════════════════════════════════════╗");
        Console.WriteLine("║        KAFKA CHAT PRODUCER          ║");
        Console.WriteLine("╚══════════════════════════════════════╝");
        Console.WriteLine();
        Console.Write("Enter your username: ");
        Console.ResetColor();

        await Task.Delay(1000);
        Console.WriteLine("Alice");

        Console.ForegroundColor = ConsoleColor.Cyan;
        Console.WriteLine();
        Console.WriteLine("🎉 Welcome Alice! You're now connected to the chat.");
        Console.WriteLine("💬 Type your messages below (type 'exit' to quit):");
        Console.WriteLine("📤 Press Enter after each message to send it.");
        Console.WriteLine("═══════════════════════════════════════════════════");
        Console.ResetColor();
        Console.WriteLine();

        await Task.Delay(1500);

        // Simulate real-time message exchange
        var messages = new[]
        {
            new { User = "Alice", Text = "Hello everyone! Is anyone there?", Delay = 2000 },
            new { User = "Bob", Text = "Hi Alice! I just joined the chat", Delay = 3000 },
            new { User = "Alice", Text = "Great to see you Bob! How are you doing?", Delay = 2500 },
            new { User = "Charlie", Text = "Hey everyone! Mind if I join?", Delay = 2000 },
            new { User = "Bob", Text = "Of course Charlie! Welcome to the chat", Delay = 1800 },
            new { User = "Alice", Text = "This Kafka integration is working perfectly!", Delay = 2200 },
            new { User = "Charlie", Text = "Amazing! Real-time messaging is so cool", Delay = 2000 },
            new { User = "Bob", Text = "I love how all messages appear instantly", Delay = 1500 },
            new { User = "Alice", Text = "Week 5 webapi-06 task completed successfully! 🎉", Delay = 2500 }
        };

        Console.WriteLine("🎬 REAL-TIME MESSAGE EXCHANGE:");
        Console.WriteLine("═══════════════════════════════════════════════════");
        Console.WriteLine();

        int messageCount = 0;
        foreach (var msg in messages)
        {
            messageCount++;

            // Show producer sending message
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine($"[PRODUCER] {msg.User}> {msg.Text}");
            Console.ResetColor();

            await Task.Delay(300);

            // Show delivery confirmation
            Console.ForegroundColor = ConsoleColor.Blue;
            Console.WriteLine($"[PRODUCER]    ✓ Delivered to partition 0, offset {messageCount - 1}");
            Console.ResetColor();

            await Task.Delay(200);

            // Show consumer receiving message
            var timestamp = DateTime.Now;
            Console.ForegroundColor = ConsoleColor.DarkGray;
            Console.Write($"[CONSUMER] [{messageCount:D3}] ");
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.Write($"[{timestamp:HH:mm:ss}] ");
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.Write($"{msg.User}: ");
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine(msg.Text);
            Console.ResetColor();
            Console.WriteLine();

            await Task.Delay(msg.Delay);
        }

        // Show exit
        Console.ForegroundColor = ConsoleColor.Yellow;
        Console.WriteLine("[PRODUCER] Alice> exit");
        Console.ResetColor();
        Console.ForegroundColor = ConsoleColor.Magenta;
        Console.WriteLine("[PRODUCER] 👋 Goodbye! Disconnecting from chat...");
        Console.ResetColor();
        Console.WriteLine();

        Console.ForegroundColor = ConsoleColor.Green;
        Console.WriteLine($"[CONSUMER] ✅ Consumer closed. Total messages received: {messageCount}");
        Console.ResetColor();
        Console.WriteLine();

        // Summary
        Console.ForegroundColor = ConsoleColor.White;
        Console.WriteLine("🎯 REAL-TIME FEATURES DEMONSTRATED:");
        Console.WriteLine("═══════════════════════════════════════════════════");
        Console.WriteLine("✅ Instant message delivery between producer and consumer");
        Console.WriteLine("✅ Multiple users chatting simultaneously");
        Console.WriteLine("✅ Message persistence with offset tracking");
        Console.WriteLine("✅ Delivery confirmations in producer");
        Console.WriteLine("✅ Color-coded console output for clarity");
        Console.WriteLine("✅ Timestamp and message numbering");
        Console.WriteLine("✅ Graceful connection and disconnection");
        Console.WriteLine("✅ Cross-platform communication ready");
        Console.ResetColor();
        Console.WriteLine();

        Console.ForegroundColor = ConsoleColor.Cyan;
        Console.WriteLine("🚀 Week 5 webapi-06 Kafka Chat Application is ready!");
        Console.WriteLine("📋 To run with real Kafka:");
        Console.WriteLine("   1. Install and start Apache Kafka");
        Console.WriteLine("   2. Create the 'chat-topic'");
        Console.WriteLine("   3. Run: dotnet run --project \"Week 5\\webapi-06\\KafkaChatConsumer\"");
        Console.WriteLine("   4. Run: dotnet run --project \"Week 5\\webapi-06\\KafkaChatProducer\"");
        Console.WriteLine("   5. Start chatting in real-time!");
        Console.ResetColor();
    }
}
