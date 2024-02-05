namespace CS408Project_Server
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
            this.logs = new System.Windows.Forms.RichTextBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.connectedCli = new System.Windows.Forms.RichTextBox();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.if100subs = new System.Windows.Forms.RichTextBox();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.sps101subs = new System.Windows.Forms.RichTextBox();
            this.txtBoxPort = new System.Windows.Forms.TextBox();
            this.labelPort = new System.Windows.Forms.Label();
            this.btnListen = new System.Windows.Forms.Button();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.groupBox4.SuspendLayout();
            this.SuspendLayout();
            // 
            // logs
            // 
            this.logs.HideSelection = false;
            this.logs.ImeMode = System.Windows.Forms.ImeMode.Off;
            this.logs.Location = new System.Drawing.Point(6, 21);
            this.logs.Name = "logs";
            this.logs.ReadOnly = true;
            this.logs.Size = new System.Drawing.Size(271, 347);
            this.logs.TabIndex = 0;
            this.logs.Text = "";
            this.logs.TextChanged += new System.EventHandler(this.richTextBox1_TextChanged);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.logs);
            this.groupBox1.Location = new System.Drawing.Point(12, 25);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(283, 374);
            this.groupBox1.TabIndex = 1;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Logs";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.connectedCli);
            this.groupBox2.Location = new System.Drawing.Point(378, 25);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(283, 374);
            this.groupBox2.TabIndex = 2;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Connected Clients";
            // 
            // connectedCli
            // 
            this.connectedCli.HideSelection = false;
            this.connectedCli.ImeMode = System.Windows.Forms.ImeMode.Off;
            this.connectedCli.Location = new System.Drawing.Point(0, 21);
            this.connectedCli.Name = "connectedCli";
            this.connectedCli.ReadOnly = true;
            this.connectedCli.Size = new System.Drawing.Size(271, 347);
            this.connectedCli.TabIndex = 0;
            this.connectedCli.Text = "";
            this.connectedCli.TextChanged += new System.EventHandler(this.connectedCli_TextChanged);
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.if100subs);
            this.groupBox3.Location = new System.Drawing.Point(765, 25);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(283, 271);
            this.groupBox3.TabIndex = 3;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "IF100 Subscribers";
            // 
            // if100subs
            // 
            this.if100subs.HideSelection = false;
            this.if100subs.ImeMode = System.Windows.Forms.ImeMode.Off;
            this.if100subs.Location = new System.Drawing.Point(6, 21);
            this.if100subs.Name = "if100subs";
            this.if100subs.ReadOnly = true;
            this.if100subs.Size = new System.Drawing.Size(271, 250);
            this.if100subs.TabIndex = 0;
            this.if100subs.Text = "";
            // 
            // groupBox4
            // 
            this.groupBox4.Controls.Add(this.sps101subs);
            this.groupBox4.Location = new System.Drawing.Point(765, 343);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(283, 271);
            this.groupBox4.TabIndex = 4;
            this.groupBox4.TabStop = false;
            this.groupBox4.Text = "SPS101 Subscribers";
            this.groupBox4.Enter += new System.EventHandler(this.groupBox4_Enter);
            // 
            // sps101subs
            // 
            this.sps101subs.HideSelection = false;
            this.sps101subs.ImeMode = System.Windows.Forms.ImeMode.Off;
            this.sps101subs.Location = new System.Drawing.Point(6, 21);
            this.sps101subs.Name = "sps101subs";
            this.sps101subs.ReadOnly = true;
            this.sps101subs.Size = new System.Drawing.Size(271, 250);
            this.sps101subs.TabIndex = 0;
            this.sps101subs.Text = "";
            // 
            // txtBoxPort
            // 
            this.txtBoxPort.Location = new System.Drawing.Point(459, 468);
            this.txtBoxPort.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.txtBoxPort.Name = "txtBoxPort";
            this.txtBoxPort.Size = new System.Drawing.Size(151, 22);
            this.txtBoxPort.TabIndex = 7;
            // 
            // labelPort
            // 
            this.labelPort.Location = new System.Drawing.Point(404, 466);
            this.labelPort.Name = "labelPort";
            this.labelPort.Size = new System.Drawing.Size(70, 24);
            this.labelPort.TabIndex = 6;
            this.labelPort.Text = "Port:";
            this.labelPort.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.labelPort.Click += new System.EventHandler(this.labelPort_Click);
            // 
            // btnListen
            // 
            this.btnListen.Location = new System.Drawing.Point(513, 494);
            this.btnListen.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnListen.Name = "btnListen";
            this.btnListen.Size = new System.Drawing.Size(97, 32);
            this.btnListen.TabIndex = 5;
            this.btnListen.Text = "Listen";
            this.btnListen.UseVisualStyleBackColor = true;
            this.btnListen.Click += new System.EventHandler(this.btnListen_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1116, 683);
            this.Controls.Add(this.txtBoxPort);
            this.Controls.Add(this.labelPort);
            this.Controls.Add(this.btnListen);
            this.Controls.Add(this.groupBox4);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Name = "Form1";
            this.Text = "DiSUCord Server";
            this.groupBox1.ResumeLayout(false);
            this.groupBox2.ResumeLayout(false);
            this.groupBox3.ResumeLayout(false);
            this.groupBox4.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.RichTextBox logs;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.RichTextBox connectedCli;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.RichTextBox if100subs;
        private System.Windows.Forms.GroupBox groupBox4;
        private System.Windows.Forms.RichTextBox sps101subs;
        private System.Windows.Forms.TextBox txtBoxPort;
        private System.Windows.Forms.Label labelPort;
        private System.Windows.Forms.Button btnListen;
    }
}

