# webapi-06: Kafka Chat Application with C#

## 🎯 Objectives
This module demonstrates Apache Kafka integration with C# applications through real-time chat applications:

- **Apache Kafka Streaming**: Real-time message streaming platform
- **Producer/Consumer Pattern**: Message publishing and consumption
- **Multiple Client Types**: Console and Windows Forms applications
- **Cross-Platform Communication**: Different applications communicating via Kafka
- **Real-time Messaging**: Instant message delivery and display
- **Distributed Architecture**: Scalable messaging system

## 📋 Project Structure

```
webapi-06/
├── KafkaChatConsole/           # Combined Producer/Consumer Console App
├── KafkaChatProducer/          # Dedicated Producer Console App
├── KafkaChatConsumer/          # Dedicated Consumer Console App
├── KafkaChatWinForms/          # Windows Forms GUI Chat App
├── README.md                   # This documentation
├── Testing-Guide.md            # Comprehensive testing instructions
└── Kafka-Installation-Guide.md # Kafka setup instructions
```

## 🚀 Applications Overview

### 1. KafkaChatConsole
**Type**: Console Application (Combined Producer/Consumer)
**Features**:
- Interactive mode selection (Producer or Consumer)
- Real-time message sending and receiving
- Color-coded console output
- Graceful shutdown handling

### 2. KafkaChatProducer
**Type**: Dedicated Producer Console Application
**Features**:
- Focused message sending interface
- Username-based message identification
- Delivery confirmation feedback
- Simple and clean user experience

### 3. KafkaChatConsumer
**Type**: Dedicated Consumer Console Application
**Features**:
- Real-time message listening
- Color-coded message display
- Timestamp formatting
- Continuous message monitoring

### 4. KafkaChatWinForms
**Type**: Windows Forms GUI Application
**Features**:
- User-friendly graphical interface
- Real-time chat display
- Username management
- Send button and Enter key support
- Status indicators and connection feedback

## 🔧 Technical Implementation

### Kafka Configuration
```csharp
// Producer Configuration
var producerConfig = new ProducerConfig
{
    BootstrapServers = "localhost:9092",
    ClientId = Environment.MachineName
};

// Consumer Configuration
var consumerConfig = new ConsumerConfig
{
    BootstrapServers = "localhost:9092",
    GroupId = "chat-consumer-group",
    AutoOffsetReset = AutoOffsetReset.Latest,
    EnableAutoCommit = true
};
```

### Message Format
```csharp
public class ChatMessage
{
    public string Username { get; set; } = string.Empty;
    public string Message { get; set; } = string.Empty;
    public DateTime Timestamp { get; set; }
}
```

### Key Features
- **Topic**: `chat-topic` for all message communication
- **Serialization**: JSON format for message payload
- **Consumer Groups**: Separate groups for different application types
- **Error Handling**: Robust exception management
- **Async Operations**: Non-blocking message operations

## 🚀 Quick Start Guide

### Prerequisites
1. **Apache Kafka**: Download and install from [Apache Kafka Downloads](https://kafka.apache.org/downloads)
2. **Java 8+**: Required for Kafka (set JAVA_HOME environment variable)
3. **.NET 8.0**: For running the C# applications
4. **Windows OS**: Applications designed for Windows environment

### Step-by-Step Execution

#### 1. Start ZooKeeper
```bash
cd C:\kafka_2.13-3.7.2
bin\windows\zookeeper-server-start.bat config\zookeeper.properties
```

#### 2. Start Kafka Broker
```bash
cd C:\kafka_2.13-3.7.2
bin\windows\kafka-server-start.bat config\server.properties
```

#### 3. Create Kafka Topic (if not already created)
```bash
cd C:\kafka_2.13-3.7.2
bin\windows\kafka-topics.bat --create --topic chat-topic --bootstrap-server localhost:9092 --partitions 1 --replication-factor 1
```

#### 4. Run Applications

**Option A: Dedicated Producer/Consumer**
```bash
# Terminal 1 - Consumer
cd "Week 5\webapi-06\KafkaChatConsumer"
dotnet run

# Terminal 2 - Producer
cd "Week 5\webapi-06\KafkaChatProducer"
dotnet run
```

**Option B: Combined Console Application**
```bash
# Terminal 1 - Consumer Mode
cd "Week 5\webapi-06\KafkaChatConsole"
dotnet run
# Choose option 2 (Consumer)

# Terminal 2 - Producer Mode
cd "Week 5\webapi-06\KafkaChatConsole"
dotnet run
# Choose option 1 (Producer)
```

**Option C: Windows Forms GUI**
```bash
cd "Week 5\webapi-06\KafkaChatWinForms"
dotnet run
```

## 🔧 Application Features

### Console Applications
- **Interactive Mode Selection**: Choose between Producer and Consumer modes
- **Real-time Messaging**: Instant message delivery and display
- **Color-coded Output**: Enhanced readability with console colors
- **Graceful Shutdown**: Proper cleanup on exit (Ctrl+C)
- **Error Handling**: Robust exception management and user feedback

### Windows Forms Application
- **GUI Interface**: User-friendly graphical interface
- **Username Management**: Set username before chatting
- **Real-time Updates**: Automatic message refresh in chat display
- **Keyboard Shortcuts**: Enter key support for sending messages
- **Status Indicators**: Connection status and message delivery feedback
- **Cross-platform Communication**: Works with console applications

## 🧪 Testing Scenarios

### Basic Functionality
1. **Single Producer/Consumer**: Test basic message flow
2. **Multiple Producers**: Multiple users sending messages
3. **Multiple Consumers**: Multiple clients receiving messages
4. **Cross-platform**: Console and WinForms communication

### Advanced Testing
1. **Message Persistence**: Stop/restart consumers to verify message retention
2. **High Volume**: Send multiple messages rapidly
3. **Special Characters**: Test with emojis and special characters
4. **Network Resilience**: Test reconnection after Kafka restart

## 🎯 Learning Outcomes

After completing this module, you will understand:

1. **Apache Kafka Architecture**: Topics, partitions, producers, consumers
2. **Real-time Messaging**: Streaming data processing
3. **Distributed Systems**: Message queuing and event-driven architecture
4. **C# Kafka Integration**: Using Confluent.Kafka library
5. **Producer/Consumer Patterns**: Message publishing and consumption
6. **Cross-platform Communication**: Different application types communicating
7. **Error Handling**: Robust exception management in distributed systems
8. **GUI Development**: Windows Forms with real-time data updates

## ✅ Success Criteria

- ✅ Kafka and ZooKeeper running successfully
- ✅ Chat topic created and accessible
- ✅ Console Producer sending messages
- ✅ Console Consumer receiving messages
- ✅ Windows Forms application functional
- ✅ Cross-platform communication working
- ✅ Multiple clients can communicate simultaneously
- ✅ Messages persist when consumers restart
- ✅ Proper error handling and user feedback
- ✅ Clean application shutdown
**This module demonstrates real-time messaging with Apache Kafka and C# applications!** 🚀
