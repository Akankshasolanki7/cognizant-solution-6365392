using Confluent.Kafka;
using System;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace KafkaChatWinForms;

public partial class Form1 : Form
{
    private readonly string BootstrapServers = "localhost:9092";
    private readonly string TopicName = "chat-messages";
    private IProducer<string, string> producer;
    private IConsumer<string, string> consumer;
    private CancellationTokenSource cancellationTokenSource;
    private string username;

    public Form1()
    {
        InitializeComponent();
        InitializeKafka();
    }

    private void InitializeKafka()
    {
        // Initialize Producer
        var producerConfig = new ProducerConfig
        {
            BootstrapServers = BootstrapServers,
            ClientId = Environment.MachineName
        };
        producer = new ProducerBuilder<string, string>(producerConfig).Build();

        // Initialize Consumer
        var consumerConfig = new ConsumerConfig
        {
            BootstrapServers = BootstrapServers,
            GroupId = $"chat-winforms-{Guid.NewGuid()}",
            AutoOffsetReset = AutoOffsetReset.Latest,
            EnableAutoCommit = true
        };
        consumer = new ConsumerBuilder<string, string>(consumerConfig).Build();
        consumer.Subscribe(TopicName);

        cancellationTokenSource = new CancellationTokenSource();

        // Start consuming messages
        Task.Run(() => ConsumeMessages(cancellationTokenSource.Token));
    }

    private async Task ConsumeMessages(CancellationToken cancellationToken)
    {
        try
        {
            while (!cancellationToken.IsCancellationRequested)
            {
                var consumeResult = consumer.Consume(cancellationToken);

                if (consumeResult?.Message != null)
                {
                    // Update UI on main thread
                    this.Invoke(new Action(() =>
                    {
                        txtChatDisplay.AppendText(consumeResult.Message.Value + Environment.NewLine);
                        txtChatDisplay.ScrollToCaret();
                    }));
                }
            }
        }
        catch (OperationCanceledException)
        {
            // Expected when cancellation is requested
        }
        catch (Exception ex)
        {
            this.Invoke(new Action(() =>
            {
                MessageBox.Show($"Error consuming messages: {ex.Message}", "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }));
        }
    }

    private async void btnSend_Click(object sender, EventArgs e)
    {
        if (string.IsNullOrWhiteSpace(username))
        {
            username = txtUsername.Text.Trim();
            if (string.IsNullOrWhiteSpace(username))
            {
                MessageBox.Show("Please enter a username first!", "Username Required",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtUsername.Focus();
                return;
            }
            txtUsername.ReadOnly = true;
            lblStatus.Text = $"Connected as: {username}";
        }

        var message = txtMessage.Text.Trim();
        if (string.IsNullOrWhiteSpace(message))
            return;

        var chatMessage = $"[{DateTime.Now:HH:mm:ss}] {username}: {message}";

        try
        {
            await producer.ProduceAsync(TopicName,
                new Message<string, string>
                {
                    Key = username,
                    Value = chatMessage
                });

            txtMessage.Clear();
            txtMessage.Focus();
        }
        catch (ProduceException<string, string> ex)
        {
            MessageBox.Show($"Failed to send message: {ex.Error.Reason}", "Error",
                MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
    }

    private void txtMessage_KeyPress(object sender, KeyPressEventArgs e)
    {
        if (e.KeyChar == (char)Keys.Enter)
        {
            e.Handled = true;
            btnSend_Click(sender, e);
        }
    }

    protected override void OnFormClosing(FormClosingEventArgs e)
    {
        cancellationTokenSource?.Cancel();
        producer?.Flush(TimeSpan.FromSeconds(5));
        producer?.Dispose();
        consumer?.Close();
        consumer?.Dispose();
        base.OnFormClosing(e);
    }
}
