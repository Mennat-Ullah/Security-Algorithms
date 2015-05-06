namespace Security
{
    partial class columnair
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
            this.stages = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.user = new System.Windows.Forms.ComboBox();
            this.ct = new System.Windows.Forms.TextBox();
            this.ki = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.generate = new System.Windows.Forms.Button();
            this.pt = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // stages
            // 
            this.stages.Location = new System.Drawing.Point(295, 129);
            this.stages.Name = "stages";
            this.stages.Size = new System.Drawing.Size(100, 20);
            this.stages.TabIndex = 30;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(292, 112);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(93, 13);
            this.label5.TabIndex = 29;
            this.label5.Text = "Number of Stages";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(288, 25);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(29, 13);
            this.label4.TabIndex = 28;
            this.label4.Text = "User";
            // 
            // user
            // 
            this.user.FormattingEnabled = true;
            this.user.Items.AddRange(new object[] {
            "sender",
            "reciever"});
            this.user.Location = new System.Drawing.Point(288, 41);
            this.user.Name = "user";
            this.user.Size = new System.Drawing.Size(121, 21);
            this.user.TabIndex = 27;
            // 
            // ct
            // 
            this.ct.Location = new System.Drawing.Point(25, 191);
            this.ct.Multiline = true;
            this.ct.Name = "ct";
            this.ct.Size = new System.Drawing.Size(227, 55);
            this.ct.TabIndex = 26;
            // 
            // ki
            // 
            this.ki.Location = new System.Drawing.Point(25, 127);
            this.ki.Name = "ki";
            this.ki.Size = new System.Drawing.Size(100, 20);
            this.ki.TabIndex = 25;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(22, 175);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(41, 13);
            this.label3.TabIndex = 24;
            this.label3.Text = "Output";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(22, 110);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(25, 13);
            this.label2.TabIndex = 23;
            this.label2.Text = "Key";
            // 
            // generate
            // 
            this.generate.Location = new System.Drawing.Point(321, 209);
            this.generate.Name = "generate";
            this.generate.Size = new System.Drawing.Size(75, 23);
            this.generate.TabIndex = 22;
            this.generate.Text = "Generate";
            this.generate.UseVisualStyleBackColor = true;
            this.generate.Click += new System.EventHandler(this.generate_Click);
            // 
            // pt
            // 
            this.pt.Location = new System.Drawing.Point(25, 41);
            this.pt.Multiline = true;
            this.pt.Name = "pt";
            this.pt.Size = new System.Drawing.Size(227, 55);
            this.pt.TabIndex = 21;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(22, 25);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(33, 13);
            this.label1.TabIndex = 20;
            this.label1.Text = "Input";
            // 
            // columnair
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(431, 277);
            this.Controls.Add(this.stages);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.user);
            this.Controls.Add(this.ct);
            this.Controls.Add(this.ki);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.generate);
            this.Controls.Add(this.pt);
            this.Controls.Add(this.label1);
            this.Name = "columnair";
            this.Text = "Columnair cipher";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox stages;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.ComboBox user;
        private System.Windows.Forms.TextBox ct;
        private System.Windows.Forms.TextBox ki;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button generate;
        private System.Windows.Forms.TextBox pt;
        private System.Windows.Forms.Label label1;
    }
}