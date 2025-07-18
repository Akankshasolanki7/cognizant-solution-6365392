# Kafka Chat Applications Testing Guide

## 🎯 Objective
Complete testing guide for both Console and Windows Forms Kafka chat applications.

## 📋 Prerequisites
- Kafka and Zookeeper running (see Installation Guide)
- .NET 6.0 or higher installed
- Both chat applications built successfully

## 🚀 Task 1: Console Chat Application Testing

### Step 1: Build the Console Application
```bash
cd "Week 5/webapi-06/KafkaChatConsole"
dotnet build
```

### Step 2: Test Producer (Message Sender)
1. **Open First Terminal**:
   ```bash
   dotnet run
   ```

2. **Choose Producer Mode**:
   ```
   === Kafka Chat Application ===
   Choose mode:
   1. Producer (Send Messages)
   2. Consumer (Receive Messages)
   Enter choice (1 or 2): 1
   ```

3. **Enter Username**:
   ```
   === Chat Producer Started ===
   Enter your username:
   Alice
   ```

4. **Send Messages**:
   ```
   Welcome Alice! Type messages (type 'exit' to quit):
   Hello everyone!
   How is everyone doing?
   This is a test message
   exit
   ```

### Step 3: Test Consumer (Message Receiver)
1. **Open Second Terminal**:
   ```bash
   dotnet run
   ```

2. **Choose Consumer Mode**:
   ```
   === Kafka Chat Application ===
   Choose mode:
   1. Producer (Send Messages)
   2. Consumer (Receive Messages)
   Enter choice (1 or 2): 2
   ```

3. **Observe Messages**:
   ```
   === Chat Consumer Started ===
   Listening for chat messages... (Press Ctrl+C to exit)
   Received: [14:30:15] Alice: Hello everyone!
   Received: [14:30:22] Alice: How is everyone doing?
   Received: [14:30:35] Alice: This is a test message
   ```

### Step 4: Test Multiple Producers and Consumers
1. **Open 4 terminals total**:
   - Terminal 1: Producer (User: Alice)
   - Terminal 2: Producer (User: Bob)
   - Terminal 3: Consumer
   - Terminal 4: Consumer

2. **Send messages from both producers**
3. **Verify both consumers receive all messages**

## 🖥️ Task 2: Windows Forms Chat Application Testing

### Step 1: Build the WinForms Application
```bash
cd "Week 5/webapi-06/KafkaChatWinForms"
dotnet build
```

### Step 2: Run First Client
1. **Start Application**:
   ```bash
   dotnet run
   ```

2. **Enter Username**:
   - Type "Alice" in Username field
   - Click Send or press Enter

3. **Send Messages**:
   - Type message in Message field
   - Click Send or press Enter
   - Observe message appears in chat display

### Step 3: Run Multiple Clients
1. **Open 3 instances** of the WinForms application:
   ```bash
   # Terminal 1
   dotnet run

   # Terminal 2  
   dotnet run

   # Terminal 3
   dotnet run
   ```

2. **Set Different Usernames**:
   - Client 1: "Alice"
   - Client 2: "Bob" 
   - Client 3: "Charlie"

3. **Test Cross-Communication**:
   - Send message from Alice → Should appear in Bob and Charlie
   - Send message from Bob → Should appear in Alice and Charlie
   - Send message from Charlie → Should appear in Alice and Bob

## 🔄 Task 3: Cross-Platform Testing

### Test Console + WinForms Integration
1. **Start Console Consumer**:
   ```bash
   cd KafkaChatConsole
   dotnet run
   # Choose option 2 (Consumer)
   ```

2. **Start WinForms Client**:
   ```bash
   cd KafkaChatWinForms
   dotnet run
   # Enter username and send messages
   ```

3. **Verify Integration**:
   - Messages from WinForms should appear in Console
   - Both applications use same Kafka topic

### Test Multiple WinForms + Console
1. **Start 2 WinForms clients** with different usernames
2. **Start 1 Console producer** with another username
3. **Start 1 Console consumer**
4. **Verify all messages** are received by all consumers

## 📊 Expected Results

### Console Application Results:
```
Producer Output:
=== Chat Producer Started ===
Enter your username:
Alice
Welcome Alice! Type messages (type 'exit' to quit):
Hello from console!
Message sent to partition 0 at offset 15

Consumer Output:
=== Chat Consumer Started ===
Listening for chat messages... (Press Ctrl+C to exit)
Received: [14:45:10] Alice: Hello from console!
Received: [14:45:15] Bob: Hi Alice!
Received: [14:45:20] Charlie: Hello everyone!
```

### WinForms Application Results:
```
Chat Display Window:
[14:45:10] Alice: Hello from console!
[14:45:15] Bob: Hi Alice!
[14:45:20] Charlie: Hello everyone!
[14:45:25] Alice: This is from WinForms!

Status: Connected as: Alice
```

## 🧪 Advanced Testing Scenarios

### Scenario 1: Message Persistence
1. **Send messages** with producer
2. **Stop all consumers**
3. **Start new consumer**
4. **Verify**: Consumer receives all previous messages (from beginning)

### Scenario 2: Network Resilience
1. **Start producer and consumer**
2. **Stop Kafka server** briefly
3. **Restart Kafka server**
4. **Verify**: Applications reconnect automatically

### Scenario 3: High Volume Testing
1. **Send 100+ messages** rapidly
2. **Verify**: All messages received in order
3. **Check**: No message loss

### Scenario 4: Special Characters
1. **Send messages** with emojis: "Hello! 😊🎉"
2. **Send messages** with special chars: "Test: @#$%^&*()"
3. **Verify**: All characters display correctly

## 🔍 Monitoring and Debugging

### Check Kafka Topics:
```bash
cd C:\kafka
bin\windows\kafka-topics.bat --list --bootstrap-server localhost:9092
```

### Monitor Topic Messages:
```bash
bin\windows\kafka-console-consumer.bat --topic chat-messages --from-beginning --bootstrap-server localhost:9092
```

### Check Consumer Groups:
```bash
bin\windows\kafka-consumer-groups.bat --bootstrap-server localhost:9092 --list
```

### View Consumer Group Details:
```bash
bin\windows\kafka-consumer-groups.bat --bootstrap-server localhost:9092 --group chat-consumer-group --describe
```

## ❌ Troubleshooting

### Common Issues:

1. **Connection Refused**:
   - Verify Kafka is running on localhost:9092
   - Check firewall settings

2. **No Messages Received**:
   - Verify topic name matches ("chat-messages")
   - Check consumer group configuration

3. **WinForms UI Freezing**:
   - Ensure async/await is used properly
   - Check UI thread invocation

4. **Duplicate Messages**:
   - Check consumer group IDs
   - Verify offset management

### Debug Commands:
```bash
# Check if Kafka is running
netstat -ano | findstr :9092

# Check Zookeeper
netstat -ano | findstr :2181

# View Kafka logs
type C:\kafka\logs\server.log
```

## ✅ Success Criteria

- [ ] Console producer sends messages successfully
- [ ] Console consumer receives all messages
- [ ] WinForms application sends and receives messages
- [ ] Multiple clients can communicate
- [ ] Cross-platform communication works (Console ↔ WinForms)
- [ ] Messages persist when consumers restart
- [ ] Real-time message delivery
- [ ] Proper error handling
- [ ] Clean application shutdown

## 🎯 Learning Outcomes

After completing this testing:

1. **Kafka Architecture**: Understanding of producers, consumers, topics
2. **Real-time Messaging**: Implementation of streaming communication
3. **Cross-Platform Integration**: Console and GUI applications
4. **Distributed Systems**: Multiple client coordination
5. **Error Handling**: Robust application design
6. **Performance**: High-throughput message processing

**Your Kafka chat applications are now fully tested and ready for production use!** 🚀
