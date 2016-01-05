namespace SRPushNotificationsWindowsApp {
    partial class Form1 {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing) {
            if (disposing && (components != null)) {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent() {
            this.button1 = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.textBoxMessage = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.textBoxTitle = new System.Windows.Forms.TextBox();
            this.Results = new System.Windows.Forms.Label();
            this.labelResults = new System.Windows.Forms.Label();
            this.radioButtonAlertNotification = new System.Windows.Forms.RadioButton();
            this.radioButtonIsNewsfeed = new System.Windows.Forms.RadioButton();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.radioButtonIsEmergency = new System.Windows.Forms.RadioButton();
            this.labelMapURL = new System.Windows.Forms.Label();
            this.textBoxEmergencyMapURL = new System.Windows.Forms.TextBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.buttonStartScheduler = new System.Windows.Forms.Button();
            this.buttonStopScheduler = new System.Windows.Forms.Button();
            this.textBoxLog = new System.Windows.Forms.TextBox();
            this.buttonClearLog = new System.Windows.Forms.Button();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(335, 268);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 100;
            this.button1.Text = "Send";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(28, 44);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(53, 13);
            this.label2.TabIndex = 2;
            this.label2.Text = "Message:";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // textBoxMessage
            // 
            this.textBoxMessage.Location = new System.Drawing.Point(87, 44);
            this.textBoxMessage.Multiline = true;
            this.textBoxMessage.Name = "textBoxMessage";
            this.textBoxMessage.Size = new System.Drawing.Size(323, 144);
            this.textBoxMessage.TabIndex = 7;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(51, 16);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(30, 13);
            this.label3.TabIndex = 5;
            this.label3.Text = "Title:";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // textBoxTitle
            // 
            this.textBoxTitle.Location = new System.Drawing.Point(87, 18);
            this.textBoxTitle.Name = "textBoxTitle";
            this.textBoxTitle.Size = new System.Drawing.Size(323, 20);
            this.textBoxTitle.TabIndex = 6;
            // 
            // Results
            // 
            this.Results.AutoSize = true;
            this.Results.Location = new System.Drawing.Point(36, 299);
            this.Results.Name = "Results";
            this.Results.Size = new System.Drawing.Size(45, 13);
            this.Results.TabIndex = 7;
            this.Results.Text = "Results:";
            this.Results.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // labelResults
            // 
            this.labelResults.AutoSize = true;
            this.labelResults.Location = new System.Drawing.Point(87, 299);
            this.labelResults.Name = "labelResults";
            this.labelResults.Size = new System.Drawing.Size(0, 13);
            this.labelResults.TabIndex = 8;
            // 
            // radioButtonAlertNotification
            // 
            this.radioButtonAlertNotification.AutoSize = true;
            this.radioButtonAlertNotification.Checked = true;
            this.radioButtonAlertNotification.Location = new System.Drawing.Point(27, 19);
            this.radioButtonAlertNotification.Name = "radioButtonAlertNotification";
            this.radioButtonAlertNotification.Size = new System.Drawing.Size(46, 17);
            this.radioButtonAlertNotification.TabIndex = 101;
            this.radioButtonAlertNotification.TabStop = true;
            this.radioButtonAlertNotification.Text = "Alert";
            this.radioButtonAlertNotification.UseVisualStyleBackColor = true;
            this.radioButtonAlertNotification.CheckedChanged += new System.EventHandler(this.radioButtonAlertNotification_CheckedChanged);
            // 
            // radioButtonIsNewsfeed
            // 
            this.radioButtonIsNewsfeed.AutoSize = true;
            this.radioButtonIsNewsfeed.Location = new System.Drawing.Point(88, 19);
            this.radioButtonIsNewsfeed.Name = "radioButtonIsNewsfeed";
            this.radioButtonIsNewsfeed.Size = new System.Drawing.Size(79, 17);
            this.radioButtonIsNewsfeed.TabIndex = 102;
            this.radioButtonIsNewsfeed.Text = "News Feed";
            this.radioButtonIsNewsfeed.UseVisualStyleBackColor = true;
            this.radioButtonIsNewsfeed.CheckedChanged += new System.EventHandler(this.radioButtonIsNewsfeed_CheckedChanged);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.radioButtonIsEmergency);
            this.groupBox1.Controls.Add(this.radioButtonAlertNotification);
            this.groupBox1.Controls.Add(this.radioButtonIsNewsfeed);
            this.groupBox1.Location = new System.Drawing.Point(86, 194);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(324, 45);
            this.groupBox1.TabIndex = 103;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Type of Notification";
            // 
            // radioButtonIsEmergency
            // 
            this.radioButtonIsEmergency.AutoSize = true;
            this.radioButtonIsEmergency.Location = new System.Drawing.Point(177, 19);
            this.radioButtonIsEmergency.Name = "radioButtonIsEmergency";
            this.radioButtonIsEmergency.Size = new System.Drawing.Size(78, 17);
            this.radioButtonIsEmergency.TabIndex = 103;
            this.radioButtonIsEmergency.Text = "Emergency";
            this.radioButtonIsEmergency.UseVisualStyleBackColor = true;
            this.radioButtonIsEmergency.CheckedChanged += new System.EventHandler(this.radioButtonIsEmergency_CheckedChanged);
            // 
            // labelMapURL
            // 
            this.labelMapURL.AutoSize = true;
            this.labelMapURL.Location = new System.Drawing.Point(28, 242);
            this.labelMapURL.Name = "labelMapURL";
            this.labelMapURL.Size = new System.Drawing.Size(59, 13);
            this.labelMapURL.TabIndex = 104;
            this.labelMapURL.Text = "Map URL?";
            this.labelMapURL.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.labelMapURL.Visible = false;
            // 
            // textBoxEmergencyMapURL
            // 
            this.textBoxEmergencyMapURL.Location = new System.Drawing.Point(87, 239);
            this.textBoxEmergencyMapURL.Name = "textBoxEmergencyMapURL";
            this.textBoxEmergencyMapURL.Size = new System.Drawing.Size(323, 20);
            this.textBoxEmergencyMapURL.TabIndex = 105;
            this.textBoxEmergencyMapURL.Visible = false;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.textBoxLog);
            this.groupBox2.Controls.Add(this.buttonStopScheduler);
            this.groupBox2.Controls.Add(this.buttonStartScheduler);
            this.groupBox2.Location = new System.Drawing.Point(427, 12);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(191, 300);
            this.groupBox2.TabIndex = 106;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Scheduler";
            // 
            // buttonStartScheduler
            // 
            this.buttonStartScheduler.Location = new System.Drawing.Point(18, 43);
            this.buttonStartScheduler.Name = "buttonStartScheduler";
            this.buttonStartScheduler.Size = new System.Drawing.Size(75, 23);
            this.buttonStartScheduler.TabIndex = 0;
            this.buttonStartScheduler.Text = "Start";
            this.buttonStartScheduler.UseVisualStyleBackColor = true;
            this.buttonStartScheduler.Click += new System.EventHandler(this.buttonStartScheduler_Click);
            // 
            // buttonStopScheduler
            // 
            this.buttonStopScheduler.Enabled = false;
            this.buttonStopScheduler.Location = new System.Drawing.Point(110, 43);
            this.buttonStopScheduler.Name = "buttonStopScheduler";
            this.buttonStopScheduler.Size = new System.Drawing.Size(75, 23);
            this.buttonStopScheduler.TabIndex = 1;
            this.buttonStopScheduler.Text = "Stop";
            this.buttonStopScheduler.UseVisualStyleBackColor = true;
            this.buttonStopScheduler.Click += new System.EventHandler(this.buttonStopScheduler_Click);
            // 
            // textBoxLog
            // 
            this.textBoxLog.Location = new System.Drawing.Point(18, 82);
            this.textBoxLog.Multiline = true;
            this.textBoxLog.Name = "textBoxLog";
            this.textBoxLog.ReadOnly = true;
            this.textBoxLog.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.textBoxLog.Size = new System.Drawing.Size(167, 208);
            this.textBoxLog.TabIndex = 2;
            // 
            // buttonClearLog
            // 
            this.buttonClearLog.Location = new System.Drawing.Point(487, 318);
            this.buttonClearLog.Name = "buttonClearLog";
            this.buttonClearLog.Size = new System.Drawing.Size(75, 23);
            this.buttonClearLog.TabIndex = 107;
            this.buttonClearLog.Text = "Clear";
            this.buttonClearLog.UseVisualStyleBackColor = true;
            this.buttonClearLog.Click += new System.EventHandler(this.buttonClearLog_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(630, 346);
            this.Controls.Add(this.buttonClearLog);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.textBoxEmergencyMapURL);
            this.Controls.Add(this.labelMapURL);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.labelResults);
            this.Controls.Add(this.Results);
            this.Controls.Add(this.textBoxTitle);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.textBoxMessage);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.button1);
            this.Name = "Form1";
            this.Text = "Sunriver Send Test Notification";
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox textBoxMessage;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox textBoxTitle;
        private System.Windows.Forms.Label Results;
        private System.Windows.Forms.Label labelResults;
        private System.Windows.Forms.RadioButton radioButtonAlertNotification;
        private System.Windows.Forms.RadioButton radioButtonIsNewsfeed;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.RadioButton radioButtonIsEmergency;
        private System.Windows.Forms.Label labelMapURL;
        private System.Windows.Forms.TextBox textBoxEmergencyMapURL;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Button buttonStopScheduler;
        private System.Windows.Forms.Button buttonStartScheduler;
        private System.Windows.Forms.TextBox textBoxLog;
        private System.Windows.Forms.Button buttonClearLog;
    }
}

