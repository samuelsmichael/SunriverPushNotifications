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
            this.radioButtonIsTestNotification = new System.Windows.Forms.RadioButton();
            this.radioButtonIsSunriverNotification = new System.Windows.Forms.RadioButton();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(335, 245);
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
            this.Results.Location = new System.Drawing.Point(36, 274);
            this.Results.Name = "Results";
            this.Results.Size = new System.Drawing.Size(45, 13);
            this.Results.TabIndex = 7;
            this.Results.Text = "Results:";
            this.Results.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // labelResults
            // 
            this.labelResults.AutoSize = true;
            this.labelResults.Location = new System.Drawing.Point(87, 274);
            this.labelResults.Name = "labelResults";
            this.labelResults.Size = new System.Drawing.Size(0, 13);
            this.labelResults.TabIndex = 8;
            // 
            // radioButtonIsTestNotification
            // 
            this.radioButtonIsTestNotification.AutoSize = true;
            this.radioButtonIsTestNotification.Checked = true;
            this.radioButtonIsTestNotification.Location = new System.Drawing.Point(27, 19);
            this.radioButtonIsTestNotification.Name = "radioButtonIsTestNotification";
            this.radioButtonIsTestNotification.Size = new System.Drawing.Size(107, 17);
            this.radioButtonIsTestNotification.TabIndex = 101;
            this.radioButtonIsTestNotification.TabStop = true;
            this.radioButtonIsTestNotification.Text = "Is test notification";
            this.radioButtonIsTestNotification.UseVisualStyleBackColor = true;
            // 
            // radioButtonIsSunriverNotification
            // 
            this.radioButtonIsSunriverNotification.AutoSize = true;
            this.radioButtonIsSunriverNotification.Location = new System.Drawing.Point(151, 19);
            this.radioButtonIsSunriverNotification.Name = "radioButtonIsSunriverNotification";
            this.radioButtonIsSunriverNotification.Size = new System.Drawing.Size(134, 17);
            this.radioButtonIsSunriverNotification.TabIndex = 102;
            this.radioButtonIsSunriverNotification.Text = "Is Sunriver Notification ";
            this.radioButtonIsSunriverNotification.UseVisualStyleBackColor = true;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.radioButtonIsTestNotification);
            this.groupBox1.Controls.Add(this.radioButtonIsSunriverNotification);
            this.groupBox1.Location = new System.Drawing.Point(86, 194);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(324, 45);
            this.groupBox1.TabIndex = 103;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Notification Receiver";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(442, 342);
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
        private System.Windows.Forms.RadioButton radioButtonIsTestNotification;
        private System.Windows.Forms.RadioButton radioButtonIsSunriverNotification;
        private System.Windows.Forms.GroupBox groupBox1;
    }
}

