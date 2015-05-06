namespace Security
{
    partial class railfence
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
            this.dps = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.pt = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.stages = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.Gener = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(282, 27);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(29, 13);
            this.label4.TabIndex = 17;
            this.label4.Text = "User";
            // 
            // user
            // 
            this.user.FormattingEnabled = true;
            this.user.Items.AddRange(new object[] {
            "sender",
            "reciever"});
            this.user.Location = new System.Drawing.Point(282, 43);
            this.user.Name = "user";
            this.user.Size = new System.Drawing.Size(121, 21);
            this.user.TabIndex = 16;
            // 
            // ct
            // 
            this.ct.Location = new System.Drawing.Point(19, 193);
            this.ct.Multiline = true;
            this.ct.Name = "ct";
            this.ct.Size = new System.Drawing.Size(227, 55);
            this.ct.TabIndex = 15;
            // 
            // dps
            // 
            this.dps.Location = new System.Drawing.Point(19, 129);
            this.dps.Name = "dps";
            this.dps.Size = new System.Drawing.Size(100, 20);
            this.dps.TabIndex = 14;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(16, 177);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(39, 13);
            this.label3.TabIndex = 13;
            this.label3.Text = "Output";
            
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(16, 112);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(34, 13);
            this.label2.TabIndex = 12;
            this.label2.Text = "depth";
            // 
            // pt
            // 
            this.pt.Location = new System.Drawing.Point(19, 43);
            this.pt.Multiline = true;
            this.pt.Name = "pt";
            this.pt.Size = new System.Drawing.Size(227, 55);
            this.pt.TabIndex = 10;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(16, 27);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(31, 13);
            this.label1.TabIndex = 9;
            this.label1.Text = "Input";
            // 
            // stages
            // 
            this.stages.Location = new System.Drawing.Point(289, 131);
            this.stages.Name = "stages";
            this.stages.Size = new System.Drawing.Size(100, 20);
            this.stages.TabIndex = 19;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(286, 114);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(92, 13);
            this.label5.TabIndex = 18;
            this.label5.Text = "Number of Stages";
            // 
            // Gener
            // 
            this.Gener.Location = new System.Drawing.Point(304, 209);
            this.Gener.Name = "Gener";
            this.Gener.Size = new System.Drawing.Size(75, 23);
            this.Gener.TabIndex = 20;
            this.Gener.Text = "Generate";
            this.Gener.UseVisualStyleBackColor = true;
            this.Gener.Click += new System.EventHandler(this.Gener_Click);
            // 
            // railfence
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(431, 277);
            this.Controls.Add(this.Gener);
            this.Controls.Add(this.stages);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.user);
            this.Controls.Add(this.ct);
            this.Controls.Add(this.dps);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.pt);
            this.Controls.Add(this.label1);
            this.Name = "railfence";
            this.Text = "Rail Fence cipher";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.ComboBox user;
        private System.Windows.Forms.TextBox ct;
        private System.Windows.Forms.TextBox dps;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button generate;
        private System.Windows.Forms.TextBox pt;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox stages;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Button Gener;
    }
}