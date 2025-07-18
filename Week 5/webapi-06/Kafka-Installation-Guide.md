# Apache Kafka Installation and Configuration Guide for Windows

## 🎯 Objective
Step-by-step installation and configuration guide for Apache Kafka on Windows operating system.

## 📋 Prerequisites
- Java 8 or higher installed
- Windows 10/11 operating system
- Administrator privileges
- At least 4GB RAM available

## 📥 Step 1: Download Required Software

### 1.1 Download Java JDK
1. Go to [Oracle JDK Downloads](https://www.oracle.com/java/technologies/downloads/)
2. Download Java 8 or higher for Windows
3. Install Java and set JAVA_HOME environment variable

### 1.2 Download Apache Kafka
1. Go to [Apache Kafka Downloads](https://kafka.apache.org/downloads)
2. Download the latest stable version (Binary downloads)
3. Choose "Scala 2.13" version (e.g., kafka_2.13-3.6.0.tgz)
4. Extract to `C:\kafka` directory

## 🔧 Step 2: Environment Setup

### 2.1 Set Environment Variables
1. **JAVA_HOME**: Point to Java installation directory
   ```
   JAVA_HOME=C:\Program Files\Java\jdk-11.0.x
   ```

2. **KAFKA_HOME**: Point to Kafka installation directory
   ```
   KAFKA_HOME=C:\kafka
   ```

3. **PATH**: Add Kafka bin directory
   ```
   PATH=%PATH%;%KAFKA_HOME%\bin\windows
   ```

### 2.2 Verify Java Installation
Open Command Prompt and run:
```bash
java -version
```

## 🚀 Step 3: Configure Kafka

### 3.1 Zookeeper Configuration
1. Navigate to `C:\kafka\config`
2. Open `zookeeper.properties`
3. Verify/Update configuration:
   ```properties
   dataDir=C:/kafka/zookeeper-data
   clientPort=2181
   maxClientCnxns=0
   admin.enableServer=false
   ```

### 3.2 Kafka Server Configuration
1. Open `server.properties` in `C:\kafka\config`
2. Update key configurations:
   ```properties
   broker.id=0
   listeners=PLAINTEXT://localhost:9092
   log.dirs=C:/kafka/kafka-logs
   zookeeper.connect=localhost:2181
   ```

### 3.3 Create Required Directories
Create these directories manually:
```
C:\kafka\zookeeper-data
C:\kafka\kafka-logs
```

## 🏃‍♂️ Step 4: Start Kafka Services

### 4.1 Start Zookeeper (First Terminal)
Open Command Prompt as Administrator:
```bash
cd C:\kafka
bin\windows\zookeeper-server-start.bat config\zookeeper.properties
```

### 4.2 Start Kafka Server (Second Terminal)
Open another Command Prompt as Administrator:
```bash
cd C:\kafka
bin\windows\kafka-server-start.bat config\server.properties
```

## 🧪 Step 5: Test Kafka Installation

### 5.1 Create a Topic
Open third Command Prompt:
```bash
cd C:\kafka
bin\windows\kafka-topics.bat --create --topic chat-messages --bootstrap-server localhost:9092 --partitions 1 --replication-factor 1
```

### 5.2 List Topics
```bash
bin\windows\kafka-topics.bat --list --bootstrap-server localhost:9092
```

### 5.3 Test Producer
```bash
bin\windows\kafka-console-producer.bat --topic chat-messages --bootstrap-server localhost:9092
```

### 5.4 Test Consumer (Fourth Terminal)
```bash
bin\windows\kafka-console-consumer.bat --topic chat-messages --from-beginning --bootstrap-server localhost:9092
```

## 🔍 Understanding Zookeeper

### What is Zookeeper?
Apache Zookeeper is a centralized coordination service for distributed applications. In Kafka:

- **Configuration Management**: Stores Kafka cluster configuration
- **Leader Election**: Manages broker leadership for partitions
- **Service Discovery**: Helps brokers find each other
- **Synchronization**: Coordinates distributed processes

### Zookeeper Architecture:
```
┌─────────────┐    ┌─────────────┐    ┌─────────────┐
│  Kafka      │    │  Kafka      │    │  Kafka      │
│  Broker 1   │    │  Broker 2   │    │  Broker 3   │
└─────────────┘    └─────────────┘    └─────────────┘
       │                   │                   │
       └───────────────────┼───────────────────┘
                           │
                  ┌─────────────┐
                  │  Zookeeper  │
                  │   Ensemble  │
                  └─────────────┘
```

### Key Zookeeper Concepts:
- **Ensemble**: Cluster of Zookeeper servers
- **Leader**: One server handles writes
- **Followers**: Other servers handle reads
- **Znodes**: Data nodes in Zookeeper namespace

## 🛠️ Troubleshooting

### Common Issues:

1. **Port Already in Use**:
   ```bash
   netstat -ano | findstr :9092
   taskkill /PID <process_id> /F
   ```

2. **Java Not Found**:
   - Verify JAVA_HOME is set correctly
   - Check PATH includes Java bin directory

3. **Zookeeper Connection Failed**:
   - Ensure Zookeeper is running first
   - Check firewall settings
   - Verify port 2181 is available

4. **Kafka Logs Directory Error**:
   - Create log directories manually
   - Check write permissions

### Useful Commands:

**Stop Services**:
```bash
# Stop Kafka
bin\windows\kafka-server-stop.bat

# Stop Zookeeper
bin\windows\zookeeper-server-stop.bat
```

**Delete Topic**:
```bash
bin\windows\kafka-topics.bat --delete --topic chat-messages --bootstrap-server localhost:9092
```

**Describe Topic**:
```bash
bin\windows\kafka-topics.bat --describe --topic chat-messages --bootstrap-server localhost:9092
```

## ✅ Verification Checklist

- [ ] Java installed and JAVA_HOME set
- [ ] Kafka downloaded and extracted
- [ ] Environment variables configured
- [ ] Zookeeper starts without errors
- [ ] Kafka server starts without errors
- [ ] Can create topics successfully
- [ ] Producer and consumer work
- [ ] Chat applications can connect

## 🎯 Next Steps

After successful installation:
1. Run the Console Chat Application
2. Test the Windows Forms Chat Application
3. Create multiple consumer instances
4. Experiment with different topics
5. Monitor Kafka logs for troubleshooting

**Your Kafka installation is now ready for the chat applications!** 🚀
