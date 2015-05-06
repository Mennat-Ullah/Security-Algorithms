namespace Security
{
    partial class rc4
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
            this.label4 = new System.Windows.Forms.Label();
            this.user = new System.Windows.Forms.ComboBox();
            this.ct = new System.Windows.Forms.TextBox();
            this.ki = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.pt = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(278, 23);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(29, 13);
            this.label4.TabIndex = 26;
            this.label4.Text = "User";
            // 
            // user
            // 
            this.user.FormattingEnabled = true;
            this.user.Items.AddRange(new object[] {
            "sender",
            "reciever"});
            this.user.Location = new System.Drawing.Point(278, 39);
            this.user.Name = "user";
            this.user.Size = new System.Drawing.Size(121, 21);
            this.user.TabIndex = 25;
            // 
            // ct
            // 
            this.ct.Location = new System.Drawing.Point(15, 222);
            this.ct.Multiline = true;
            this.ct.Name = "ct";
            this.ct.Size = new System.Drawing.Size(227, 67);
            this.ct.TabIndex = 24;
            // 
            // ki
            // 
            this.ki.Location = new System.Drawing.Point(15, 125);
            this.ki.Multiline = true;
            this.ki.Name = "ki";
            this.ki.Size = new System.Drawing.Size(227, 70);
            this.ki.TabIndex = 23;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(12, 206);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(41, 13);
            this.label3.TabIndex = 22;
            this.label3.Text = "Output";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 108);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(25, 13);
            this.label2.TabIndex = 21;
            this.label2.Text = "Key";
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(308, 135);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 20;
            this.button1.Text = "Generate";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.gener);
            // 
            // pt
            // 
            this.pt.Location = new System.Drawing.Point(15, 39);
            this.pt.Multiline = true;
            this.pt.Name = "pt";
            this.pt.Size = new System.Drawing.Size(227, 55);
            this.pt.TabIndex = 19;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 23);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(33, 13);
            this.label1.TabIndex = 18;
            this.label1.Text = "Input";
            // 
            // rc4
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(410, 301);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.user);
            this.Controls.Add(this.ct);
            this.Controls.Add(this.ki);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.pt);
            this.Controls.Add(this.label1);
            this.Name = "rc4";
            this.Text = "RC4 server";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.closed);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.ComboBox user;
        private System.Windows.Forms.TextBox ct;
        private System.Windows.Forms.TextBox ki;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.TextBox pt;
        private System.Windows.Forms.Label label1;
    }
}