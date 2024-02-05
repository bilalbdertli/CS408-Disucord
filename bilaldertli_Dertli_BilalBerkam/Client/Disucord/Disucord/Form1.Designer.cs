namespace Disucord
{
    partial class Form1
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
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
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.textBox_IP = new System.Windows.Forms.TextBox();
            this.label_IP = new System.Windows.Forms.Label();
            this.label_Port = new System.Windows.Forms.Label();
            this.label_Username = new System.Windows.Forms.Label();
            this.textBox_Port = new System.Windows.Forms.TextBox();
            this.textBox_Username = new System.Windows.Forms.TextBox();
            this.button_connect = new System.Windows.Forms.Button();
            this.logs_status = new System.Windows.Forms.RichTextBox();
            this.label_status = new System.Windows.Forms.Label();
            this.label_IF100 = new System.Windows.Forms.Label();
            this.logs_IF100 = new System.Windows.Forms.RichTextBox();
            this.label_SPS101 = new System.Windows.Forms.Label();
            this.logs_SPS101 = new System.Windows.Forms.RichTextBox();
            this.button_IF100 = new System.Windows.Forms.Button();
            this.button_SPS101 = new System.Windows.Forms.Button();
            this.textBox_composeIF100 = new System.Windows.Forms.TextBox();
            this.textBox_composeSPS101 = new System.Windows.Forms.TextBox();
            this.label_compose_IF100 = new System.Windows.Forms.Label();
            this.label_compose_SPS101 = new System.Windows.Forms.Label();
            this.button_sendmsgIF100 = new System.Windows.Forms.Button();
            this.button_sendmsgSPS101 = new System.Windows.Forms.Button();
            this.label_disucord = new System.Windows.Forms.Label();
            this.groupBox_IF100 = new System.Windows.Forms.GroupBox();
            this.groupBox_SPS101 = new System.Windows.Forms.GroupBox();
            this.groupBox_IF100.SuspendLayout();
            this.groupBox_SPS101.SuspendLayout();
            this.SuspendLayout();
            // 
            // textBox_IP
            // 
            this.textBox_IP.Location = new System.Drawing.Point(95, 114);
            this.textBox_IP.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.textBox_IP.Name = "textBox_IP";
            this.textBox_IP.Size = new System.Drawing.Size(132, 22);
            this.textBox_IP.TabIndex = 0;
            // 
            // label_IP
            // 
            this.label_IP.AutoSize = true;
            this.label_IP.Location = new System.Drawing.Point(59, 118);
            this.label_IP.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label_IP.Name = "label_IP";
            this.label_IP.Size = new System.Drawing.Size(24, 17);
            this.label_IP.TabIndex = 1;
            this.label_IP.Text = "IP:";
            // 
            // label_Port
            // 
            this.label_Port.AutoSize = true;
            this.label_Port.Location = new System.Drawing.Point(44, 185);
            this.label_Port.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label_Port.Name = "label_Port";
            this.label_Port.Size = new System.Drawing.Size(38, 17);
            this.label_Port.TabIndex = 2;
            this.label_Port.Text = "Port:";
            // 
            // label_Username
            // 
            this.label_Username.AutoSize = true;
            this.label_Username.Location = new System.Drawing.Point(-1, 252);
            this.label_Username.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label_Username.Name = "label_Username";
            this.label_Username.Size = new System.Drawing.Size(77, 17);
            this.label_Username.TabIndex = 3;
            this.label_Username.Text = "Username:";
            // 
            // textBox_Port
            // 
            this.textBox_Port.Location = new System.Drawing.Point(95, 185);
            this.textBox_Port.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.textBox_Port.Name = "textBox_Port";
            this.textBox_Port.Size = new System.Drawing.Size(132, 22);
            this.textBox_Port.TabIndex = 4;
            // 
            // textBox_Username
            // 
            this.textBox_Username.Location = new System.Drawing.Point(95, 252);
            this.textBox_Username.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.textBox_Username.Name = "textBox_Username";
            this.textBox_Username.Size = new System.Drawing.Size(132, 22);
            this.textBox_Username.TabIndex = 5;
            // 
            // button_connect
            // 
            this.button_connect.Location = new System.Drawing.Point(48, 342);
            this.button_connect.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.button_connect.Name = "button_connect";
            this.button_connect.Size = new System.Drawing.Size(180, 28);
            this.button_connect.TabIndex = 6;
            this.button_connect.Text = "Connect";
            this.button_connect.UseVisualStyleBackColor = true;
            this.button_connect.Click += new System.EventHandler(this.button_connect_Click);
            // 
            // logs_status
            // 
            this.logs_status.Location = new System.Drawing.Point(316, 58);
            this.logs_status.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.logs_status.Name = "logs_status";
            this.logs_status.ReadOnly = true;
            this.logs_status.Size = new System.Drawing.Size(415, 437);
            this.logs_status.TabIndex = 7;
            this.logs_status.Text = "";
            // 
            // label_status
            // 
            this.label_status.AutoSize = true;
            this.label_status.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label_status.Location = new System.Drawing.Point(476, 32);
            this.label_status.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label_status.Name = "label_status";
            this.label_status.Size = new System.Drawing.Size(57, 20);
            this.label_status.TabIndex = 8;
            this.label_status.Text = "Status";
            this.label_status.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label_IF100
            // 
            this.label_IF100.AutoSize = true;
            this.label_IF100.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label_IF100.Location = new System.Drawing.Point(113, 14);
            this.label_IF100.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label_IF100.Name = "label_IF100";
            this.label_IF100.Size = new System.Drawing.Size(55, 20);
            this.label_IF100.TabIndex = 10;
            this.label_IF100.Text = "IF 100";
            this.label_IF100.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // logs_IF100
            // 
            this.logs_IF100.BackColor = System.Drawing.SystemColors.Control;
            this.logs_IF100.Location = new System.Drawing.Point(12, 39);
            this.logs_IF100.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.logs_IF100.Name = "logs_IF100";
            this.logs_IF100.ReadOnly = true;
            this.logs_IF100.Size = new System.Drawing.Size(273, 207);
            this.logs_IF100.TabIndex = 9;
            this.logs_IF100.Text = "";
            // 
            // label_SPS101
            // 
            this.label_SPS101.AutoSize = true;
            this.label_SPS101.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label_SPS101.Location = new System.Drawing.Point(100, 14);
            this.label_SPS101.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label_SPS101.Name = "label_SPS101";
            this.label_SPS101.Size = new System.Drawing.Size(74, 20);
            this.label_SPS101.TabIndex = 12;
            this.label_SPS101.Text = "SPS 101";
            this.label_SPS101.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // logs_SPS101
            // 
            this.logs_SPS101.Location = new System.Drawing.Point(8, 39);
            this.logs_SPS101.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.logs_SPS101.Name = "logs_SPS101";
            this.logs_SPS101.ReadOnly = true;
            this.logs_SPS101.Size = new System.Drawing.Size(273, 207);
            this.logs_SPS101.TabIndex = 11;
            this.logs_SPS101.Text = "";
            // 
            // button_IF100
            // 
            this.button_IF100.Location = new System.Drawing.Point(12, 276);
            this.button_IF100.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.button_IF100.Name = "button_IF100";
            this.button_IF100.Size = new System.Drawing.Size(275, 39);
            this.button_IF100.TabIndex = 13;
            this.button_IF100.Text = "Subscribe IF 100";
            this.button_IF100.UseVisualStyleBackColor = true;
            this.button_IF100.Click += new System.EventHandler(this.button_IF100_Click);
            // 
            // button_SPS101
            // 
            this.button_SPS101.Location = new System.Drawing.Point(11, 279);
            this.button_SPS101.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.button_SPS101.Name = "button_SPS101";
            this.button_SPS101.Size = new System.Drawing.Size(275, 39);
            this.button_SPS101.TabIndex = 14;
            this.button_SPS101.Text = "Subscribe SPS 101";
            this.button_SPS101.UseVisualStyleBackColor = true;
            this.button_SPS101.Click += new System.EventHandler(this.button_SPS101_Click);
            // 
            // textBox_composeIF100
            // 
            this.textBox_composeIF100.BackColor = System.Drawing.SystemColors.Window;
            this.textBox_composeIF100.Enabled = false;
            this.textBox_composeIF100.Location = new System.Drawing.Point(100, 383);
            this.textBox_composeIF100.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.textBox_composeIF100.Name = "textBox_composeIF100";
            this.textBox_composeIF100.Size = new System.Drawing.Size(185, 22);
            this.textBox_composeIF100.TabIndex = 15;
            // 
            // textBox_composeSPS101
            // 
            this.textBox_composeSPS101.Enabled = false;
            this.textBox_composeSPS101.Location = new System.Drawing.Point(104, 386);
            this.textBox_composeSPS101.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.textBox_composeSPS101.Name = "textBox_composeSPS101";
            this.textBox_composeSPS101.Size = new System.Drawing.Size(180, 22);
            this.textBox_composeSPS101.TabIndex = 16;
            // 
            // label_compose_IF100
            // 
            this.label_compose_IF100.AutoSize = true;
            this.label_compose_IF100.Location = new System.Drawing.Point(8, 386);
            this.label_compose_IF100.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label_compose_IF100.Name = "label_compose_IF100";
            this.label_compose_IF100.Size = new System.Drawing.Size(71, 17);
            this.label_compose_IF100.TabIndex = 17;
            this.label_compose_IF100.Text = "Compose:";
            // 
            // label_compose_SPS101
            // 
            this.label_compose_SPS101.AutoSize = true;
            this.label_compose_SPS101.Location = new System.Drawing.Point(7, 390);
            this.label_compose_SPS101.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label_compose_SPS101.Name = "label_compose_SPS101";
            this.label_compose_SPS101.Size = new System.Drawing.Size(71, 17);
            this.label_compose_SPS101.TabIndex = 18;
            this.label_compose_SPS101.Text = "Compose:";
            // 
            // button_sendmsgIF100
            // 
            this.button_sendmsgIF100.Enabled = false;
            this.button_sendmsgIF100.Location = new System.Drawing.Point(12, 442);
            this.button_sendmsgIF100.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.button_sendmsgIF100.Name = "button_sendmsgIF100";
            this.button_sendmsgIF100.Size = new System.Drawing.Size(275, 39);
            this.button_sendmsgIF100.TabIndex = 19;
            this.button_sendmsgIF100.Text = "Send message to IF 100";
            this.button_sendmsgIF100.UseVisualStyleBackColor = true;
            this.button_sendmsgIF100.Click += new System.EventHandler(this.button_sendmsgIF100_Click);
            // 
            // button_sendmsgSPS101
            // 
            this.button_sendmsgSPS101.Enabled = false;
            this.button_sendmsgSPS101.Location = new System.Drawing.Point(11, 446);
            this.button_sendmsgSPS101.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.button_sendmsgSPS101.Name = "button_sendmsgSPS101";
            this.button_sendmsgSPS101.Size = new System.Drawing.Size(275, 39);
            this.button_sendmsgSPS101.TabIndex = 20;
            this.button_sendmsgSPS101.Text = "Send message to SPS 101";
            this.button_sendmsgSPS101.UseVisualStyleBackColor = true;
            this.button_sendmsgSPS101.Click += new System.EventHandler(this.button_sendmsgSPS101_Click);
            // 
            // label_disucord
            // 
            this.label_disucord.AutoSize = true;
            this.label_disucord.Font = new System.Drawing.Font("Microsoft Sans Serif", 20F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label_disucord.Location = new System.Drawing.Point(40, 11);
            this.label_disucord.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label_disucord.Name = "label_disucord";
            this.label_disucord.Size = new System.Drawing.Size(201, 39);
            this.label_disucord.TabIndex = 21;
            this.label_disucord.Text = "DISUCORD";
            this.label_disucord.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // groupBox_IF100
            // 
            this.groupBox_IF100.BackColor = System.Drawing.SystemColors.Control;
            this.groupBox_IF100.Controls.Add(this.button_sendmsgIF100);
            this.groupBox_IF100.Controls.Add(this.label_compose_IF100);
            this.groupBox_IF100.Controls.Add(this.textBox_composeIF100);
            this.groupBox_IF100.Controls.Add(this.button_IF100);
            this.groupBox_IF100.Controls.Add(this.label_IF100);
            this.groupBox_IF100.Controls.Add(this.logs_IF100);
            this.groupBox_IF100.Location = new System.Drawing.Point(805, 15);
            this.groupBox_IF100.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.groupBox_IF100.Name = "groupBox_IF100";
            this.groupBox_IF100.Padding = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.groupBox_IF100.Size = new System.Drawing.Size(311, 501);
            this.groupBox_IF100.TabIndex = 22;
            this.groupBox_IF100.TabStop = false;
            this.groupBox_IF100.Visible = false;
            // 
            // groupBox_SPS101
            // 
            this.groupBox_SPS101.BackColor = System.Drawing.SystemColors.Control;
            this.groupBox_SPS101.Controls.Add(this.button_sendmsgSPS101);
            this.groupBox_SPS101.Controls.Add(this.label_compose_SPS101);
            this.groupBox_SPS101.Controls.Add(this.textBox_composeSPS101);
            this.groupBox_SPS101.Controls.Add(this.button_SPS101);
            this.groupBox_SPS101.Controls.Add(this.label_SPS101);
            this.groupBox_SPS101.Controls.Add(this.logs_SPS101);
            this.groupBox_SPS101.Location = new System.Drawing.Point(1188, 11);
            this.groupBox_SPS101.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.groupBox_SPS101.Name = "groupBox_SPS101";
            this.groupBox_SPS101.Padding = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.groupBox_SPS101.Size = new System.Drawing.Size(299, 500);
            this.groupBox_SPS101.TabIndex = 23;
            this.groupBox_SPS101.TabStop = false;
            this.groupBox_SPS101.Visible = false;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1540, 587);
            this.Controls.Add(this.groupBox_SPS101);
            this.Controls.Add(this.groupBox_IF100);
            this.Controls.Add(this.label_disucord);
            this.Controls.Add(this.label_status);
            this.Controls.Add(this.logs_status);
            this.Controls.Add(this.button_connect);
            this.Controls.Add(this.textBox_Username);
            this.Controls.Add(this.textBox_Port);
            this.Controls.Add(this.label_Username);
            this.Controls.Add(this.label_Port);
            this.Controls.Add(this.label_IP);
            this.Controls.Add(this.textBox_IP);
            this.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.Name = "Form1";
            this.Text = "Form1";
            this.groupBox_IF100.ResumeLayout(false);
            this.groupBox_IF100.PerformLayout();
            this.groupBox_SPS101.ResumeLayout(false);
            this.groupBox_SPS101.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox textBox_IP;
        private System.Windows.Forms.Label label_IP;
        private System.Windows.Forms.Label label_Port;
        private System.Windows.Forms.Label label_Username;
        private System.Windows.Forms.TextBox textBox_Port;
        private System.Windows.Forms.TextBox textBox_Username;
        private System.Windows.Forms.Button button_connect;
        private System.Windows.Forms.RichTextBox logs_status;
        private System.Windows.Forms.Label label_status;
        private System.Windows.Forms.Label label_IF100;
        private System.Windows.Forms.RichTextBox logs_IF100;
        private System.Windows.Forms.Label label_SPS101;
        private System.Windows.Forms.RichTextBox logs_SPS101;
        private System.Windows.Forms.Button button_IF100;
        private System.Windows.Forms.Button button_SPS101;
        private System.Windows.Forms.TextBox textBox_composeIF100;
        private System.Windows.Forms.TextBox textBox_composeSPS101;
        private System.Windows.Forms.Label label_compose_IF100;
        private System.Windows.Forms.Label label_compose_SPS101;
        private System.Windows.Forms.Button button_sendmsgIF100;
        private System.Windows.Forms.Button button_sendmsgSPS101;
        private System.Windows.Forms.Label label_disucord;
        private System.Windows.Forms.GroupBox groupBox_IF100;
        private System.Windows.Forms.GroupBox groupBox_SPS101;
    }
}

