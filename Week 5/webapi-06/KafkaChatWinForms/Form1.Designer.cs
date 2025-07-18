namespace KafkaChatWinForms;

partial class Form1
{
    /// <summary>
    ///  Required designer variable.
    /// </summary>
    private System.ComponentModel.IContainer components = null;
    private TextBox txtUsername;
    private TextBox txtMessage;
    private TextBox txtChatDisplay;
    private Button btnSend;
    private Label lblUsername;
    private Label lblMessage;
    private Label lblStatus;

    /// <summary>
    ///  Clean up any resources being used.
    /// </summary>
    /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
    protected override void Dispose(bool disposing)
    {
        if (disposing && (components != null))
        {
            components.Dispose();
        }
        base.Dispose(disposing);
    }

    #region Windows Form Designer generated code

    /// <summary>
    ///  Required method for Designer support - do not modify
    ///  the contents of this method with the code editor.
    /// </summary>
    private void InitializeComponent()
    {
        this.txtUsername = new TextBox();
        this.txtMessage = new TextBox();
        this.txtChatDisplay = new TextBox();
        this.btnSend = new Button();
        this.lblUsername = new Label();
        this.lblMessage = new Label();
        this.lblStatus = new Label();
        this.SuspendLayout();

        //
        // lblUsername
        //
        this.lblUsername.AutoSize = true;
        this.lblUsername.Location = new System.Drawing.Point(12, 15);
        this.lblUsername.Name = "lblUsername";
        this.lblUsername.Size = new System.Drawing.Size(70, 15);
        this.lblUsername.TabIndex = 0;
        this.lblUsername.Text = "Username:";

        //
        // txtUsername
        //
        this.txtUsername.Location = new System.Drawing.Point(88, 12);
        this.txtUsername.Name = "txtUsername";
        this.txtUsername.Size = new System.Drawing.Size(200, 23);
        this.txtUsername.TabIndex = 1;

        //
        // lblStatus
        //
        this.lblStatus.AutoSize = true;
        this.lblStatus.Location = new System.Drawing.Point(300, 15);
        this.lblStatus.Name = "lblStatus";
        this.lblStatus.Size = new System.Drawing.Size(150, 15);
        this.lblStatus.TabIndex = 2;
        this.lblStatus.Text = "Enter username to start";

        //
        // txtChatDisplay
        //
        this.txtChatDisplay.Location = new System.Drawing.Point(12, 50);
        this.txtChatDisplay.Multiline = true;
        this.txtChatDisplay.Name = "txtChatDisplay";
        this.txtChatDisplay.ReadOnly = true;
        this.txtChatDisplay.ScrollBars = ScrollBars.Vertical;
        this.txtChatDisplay.Size = new System.Drawing.Size(760, 350);
        this.txtChatDisplay.TabIndex = 3;

        //
        // lblMessage
        //
        this.lblMessage.AutoSize = true;
        this.lblMessage.Location = new System.Drawing.Point(12, 415);
        this.lblMessage.Name = "lblMessage";
        this.lblMessage.Size = new System.Drawing.Size(60, 15);
        this.lblMessage.TabIndex = 4;
        this.lblMessage.Text = "Message:";

        //
        // txtMessage
        //
        this.txtMessage.Location = new System.Drawing.Point(78, 412);
        this.txtMessage.Name = "txtMessage";
        this.txtMessage.Size = new System.Drawing.Size(600, 23);
        this.txtMessage.TabIndex = 5;
        this.txtMessage.KeyPress += new KeyPressEventHandler(this.txtMessage_KeyPress);

        //
        // btnSend
        //
        this.btnSend.Location = new System.Drawing.Point(684, 411);
        this.btnSend.Name = "btnSend";
        this.btnSend.Size = new System.Drawing.Size(88, 25);
        this.btnSend.TabIndex = 6;
        this.btnSend.Text = "Send";
        this.btnSend.UseVisualStyleBackColor = true;
        this.btnSend.Click += new EventHandler(this.btnSend_Click);

        //
        // Form1
        //
        this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
        this.AutoScaleMode = AutoScaleMode.Font;
        this.ClientSize = new System.Drawing.Size(784, 450);
        this.Controls.Add(this.btnSend);
        this.Controls.Add(this.txtMessage);
        this.Controls.Add(this.lblMessage);
        this.Controls.Add(this.txtChatDisplay);
        this.Controls.Add(this.lblStatus);
        this.Controls.Add(this.txtUsername);
        this.Controls.Add(this.lblUsername);
        this.Name = "Form1";
        this.Text = "Kafka Chat Application";
        this.ResumeLayout(false);
        this.PerformLayout();
    }

    #endregion
}
