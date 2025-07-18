using System.Text.Json;

namespace LiveTerminalDemo;

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
        Console.WriteLine("=== KAFKA CHAT APPLICATION LIVE TERMINAL DEMO ===");
        Console.WriteLine("This demonstrates exactly what you would see when running the applications");
        Console.WriteLine("with Kafka properly installed and configured.");
        Console.WriteLine();

        // Simulate starting infrastructure
        await SimulateInfrastructureStartup();

        // Simulate running applications
        await SimulateApplicationExecution();

        Console.WriteLine();
        Console.WriteLine("🎉 Demo completed! This is exactly how your Kafka Chat Application would work!");
        Console.WriteLine();
        Console.WriteLine("To run this for real:");
        Console.WriteLine("1. Install Apache Kafka");
        Console.WriteLine("2. Start ZooKeeper and Kafka Broker");
        Console.WriteLine("3. Create the chat-topic");
        Console.WriteLine("4. Run the Consumer and Producer applications");
        Console.WriteLine("5. Start chatting!");
    }

    private static async Task SimulateInfrastructureStartup()
    {
        Console.WriteLine("📋 STEP 1: Starting Kafka Infrastructure");
        Console.WriteLine("========================================");
        Console.WriteLine();

        // ZooKeeper
        Console.WriteLine("🔄 Terminal 1 - Starting ZooKeeper:");
        Console.WriteLine("PS C:\\> cd C:\\kafka_2.13-3.7.2");
        Console.WriteLine("PS C:\\kafka_2.13-3.7.2> bin\\windows\\zookeeper-server-start.bat config\\zookeeper.properties");
        await Task.Delay(1000);
        Console.WriteLine("[2024-07-10 21:45:00,123] INFO binding to port 0.0.0.0/0.0.0.0:2181");
        Console.WriteLine("[2024-07-10 21:45:00,234] INFO Started ServerCnxnFactory");
        Console.WriteLine("✅ ZooKeeper started successfully!");
        Console.WriteLine();

        // Kafka Broker
        Console.WriteLine("🔄 Terminal 2 - Starting Kafka Broker:");
        Console.WriteLine("PS C:\\> cd C:\\kafka_2.13-3.7.2");
        Console.WriteLine("PS C:\\kafka_2.13-3.7.2> bin\\windows\\kafka-server-start.bat config\\server.properties");
        await Task.Delay(1000);
        Console.WriteLine("[2024-07-10 21:45:05,456] INFO started (kafka.server.KafkaServer)");
        Console.WriteLine("[2024-07-10 21:45:05,567] INFO Kafka Server started");
        Console.WriteLine("✅ Kafka Broker started successfully!");
        Console.WriteLine();

        // Topic Creation
        Console.WriteLine("🔄 Terminal 3 - Creating Chat Topic:");
        Console.WriteLine("PS C:\\kafka_2.13-3.7.2> bin\\windows\\kafka-topics.bat --create --topic chat-topic --bootstrap-server localhost:9092 --partitions 1 --replication-factor 1");
        await Task.Delay(500);
        Console.WriteLine("Created topic chat-topic.");
        Console.WriteLine("✅ Topic created successfully!");
        Console.WriteLine();
    }
