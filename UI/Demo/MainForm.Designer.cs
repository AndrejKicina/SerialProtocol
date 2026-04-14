namespace Demo
{
    partial class MainForm
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

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
            label1 = new Label();
            tbDataSend = new TextBox();
            label2 = new Label();
            cbComPorts = new ComboBox();
            label3 = new Label();
            btnRefresh = new Button();
            btnOpen = new Button();
            btnClose = new Button();
            gbCommunication = new GroupBox();
            numCmd = new NumericUpDown();
            btnSend = new Button();
            tbCmdReceived = new TextBox();
            label5 = new Label();
            tbDataReceived = new TextBox();
            label6 = new Label();
            gbReceived = new GroupBox();
            btnClear = new Button();
            gbCommunication.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)numCmd).BeginInit();
            gbReceived.SuspendLayout();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(6, 27);
            label1.Name = "label1";
            label1.Size = new Size(64, 15);
            label1.TabIndex = 0;
            label1.Text = "Command";
            // 
            // tbDataSend
            // 
            tbDataSend.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            tbDataSend.Location = new Point(112, 45);
            tbDataSend.Name = "tbDataSend";
            tbDataSend.Size = new Size(325, 23);
            tbDataSend.TabIndex = 3;
            tbDataSend.Text = "This text shall be returned";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(112, 27);
            label2.Name = "label2";
            label2.Size = new Size(31, 15);
            label2.TabIndex = 2;
            label2.Text = "Data";
            // 
            // cbComPorts
            // 
            cbComPorts.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            cbComPorts.DropDownStyle = ComboBoxStyle.DropDownList;
            cbComPorts.FormattingEnabled = true;
            cbComPorts.Location = new Point(78, 27);
            cbComPorts.Name = "cbComPorts";
            cbComPorts.Size = new Size(155, 23);
            cbComPorts.TabIndex = 4;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(12, 30);
            label3.Name = "label3";
            label3.Size = new Size(60, 15);
            label3.TabIndex = 5;
            label3.Text = "COM port";
            // 
            // btnRefresh
            // 
            btnRefresh.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            btnRefresh.Location = new Point(239, 27);
            btnRefresh.Name = "btnRefresh";
            btnRefresh.Size = new Size(66, 23);
            btnRefresh.TabIndex = 6;
            btnRefresh.Text = "Refresh";
            btnRefresh.UseVisualStyleBackColor = true;
            btnRefresh.Click += btnRefresh_Click;
            // 
            // btnOpen
            // 
            btnOpen.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            btnOpen.Location = new Point(311, 27);
            btnOpen.Name = "btnOpen";
            btnOpen.Size = new Size(66, 23);
            btnOpen.TabIndex = 7;
            btnOpen.Text = "Open";
            btnOpen.UseVisualStyleBackColor = true;
            btnOpen.Click += btnOpen_Click;
            // 
            // btnClose
            // 
            btnClose.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            btnClose.Enabled = false;
            btnClose.Location = new Point(383, 27);
            btnClose.Name = "btnClose";
            btnClose.Size = new Size(66, 23);
            btnClose.TabIndex = 8;
            btnClose.Text = "Close";
            btnClose.UseVisualStyleBackColor = true;
            btnClose.Click += btnClose_Click;
            // 
            // gbCommunication
            // 
            gbCommunication.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            gbCommunication.Controls.Add(numCmd);
            gbCommunication.Controls.Add(btnSend);
            gbCommunication.Controls.Add(label1);
            gbCommunication.Controls.Add(tbDataSend);
            gbCommunication.Controls.Add(label2);
            gbCommunication.Enabled = false;
            gbCommunication.Location = new Point(12, 67);
            gbCommunication.Name = "gbCommunication";
            gbCommunication.Size = new Size(451, 115);
            gbCommunication.TabIndex = 9;
            gbCommunication.TabStop = false;
            gbCommunication.Text = "Command sending";
            // 
            // numCmd
            // 
            numCmd.Location = new Point(6, 46);
            numCmd.Maximum = new decimal(new int[] { 255, 0, 0, 0 });
            numCmd.Name = "numCmd";
            numCmd.Size = new Size(100, 23);
            numCmd.TabIndex = 10;
            numCmd.Value = new decimal(new int[] { 50, 0, 0, 0 });
            // 
            // btnSend
            // 
            btnSend.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            btnSend.Location = new Point(358, 74);
            btnSend.Name = "btnSend";
            btnSend.Size = new Size(79, 32);
            btnSend.TabIndex = 9;
            btnSend.Text = "Send";
            btnSend.UseVisualStyleBackColor = true;
            btnSend.Click += btnSend_Click;
            // 
            // tbCmdReceived
            // 
            tbCmdReceived.Location = new Point(6, 41);
            tbCmdReceived.Name = "tbCmdReceived";
            tbCmdReceived.ReadOnly = true;
            tbCmdReceived.Size = new Size(100, 23);
            tbCmdReceived.TabIndex = 6;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(6, 23);
            label5.Name = "label5";
            label5.Size = new Size(64, 15);
            label5.TabIndex = 5;
            label5.Text = "Command";
            // 
            // tbDataReceived
            // 
            tbDataReceived.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            tbDataReceived.Location = new Point(112, 41);
            tbDataReceived.Name = "tbDataReceived";
            tbDataReceived.ReadOnly = true;
            tbDataReceived.Size = new Size(325, 23);
            tbDataReceived.TabIndex = 8;
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Location = new Point(112, 23);
            label6.Name = "label6";
            label6.Size = new Size(31, 15);
            label6.TabIndex = 7;
            label6.Text = "Data";
            // 
            // gbReceived
            // 
            gbReceived.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            gbReceived.Controls.Add(btnClear);
            gbReceived.Controls.Add(tbDataReceived);
            gbReceived.Controls.Add(tbCmdReceived);
            gbReceived.Controls.Add(label6);
            gbReceived.Controls.Add(label5);
            gbReceived.Enabled = false;
            gbReceived.Location = new Point(12, 188);
            gbReceived.Name = "gbReceived";
            gbReceived.Size = new Size(455, 111);
            gbReceived.TabIndex = 10;
            gbReceived.TabStop = false;
            gbReceived.Text = "Data received";
            // 
            // btnClear
            // 
            btnClear.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            btnClear.Location = new Point(358, 70);
            btnClear.Name = "btnClear";
            btnClear.Size = new Size(79, 32);
            btnClear.TabIndex = 10;
            btnClear.Text = "Clear";
            btnClear.UseVisualStyleBackColor = true;
            // 
            // MainForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(475, 314);
            Controls.Add(gbReceived);
            Controls.Add(gbCommunication);
            Controls.Add(btnClose);
            Controls.Add(btnOpen);
            Controls.Add(btnRefresh);
            Controls.Add(label3);
            Controls.Add(cbComPorts);
            Name = "MainForm";
            Text = "Serial Communication DEMO";
            gbCommunication.ResumeLayout(false);
            gbCommunication.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)numCmd).EndInit();
            gbReceived.ResumeLayout(false);
            gbReceived.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private TextBox tbDataSend;
        private Label label2;
        private ComboBox cbComPorts;
        private Label label3;
        private Button btnRefresh;
        private Button btnOpen;
        private Button btnClose;
        private GroupBox gbCommunication;
        private TextBox tbCmdReceived;
        private Label label5;
        private TextBox tbDataReceived;
        private Label label6;
        private Button btnSend;
        private GroupBox gbReceived;
        private Button btnClear;
        private NumericUpDown numCmd;
    }
}
