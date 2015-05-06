namespace Security
{
    partial class rsa_client
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
            this.p_ki = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.output_val = new System.Windows.Forms.TextBox();
            this.Q = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.gen = new System.Windows.Forms.Button();
            this.P = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.E = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.user = new System.Windows.Forms.ComboBox();
            this.SuspendLayout();
            // 
            // p_ki
            // 
            this.p_ki.Location = new System.Drawing.Point(7, 138);
            this.p_ki.Name = "p_ki";
            this.p_ki.Size = new System.Drawing.Size(127, 20);
            this.p_ki.TabIndex = 37;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Tahoma", 12F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(3, 107);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(53, 19);
            this.label5.TabIndex = 36;
            this.label5.Text = "Input";
            // 
            // output_val
            // 
            this.output_val.Location = new System.Drawing.Point(7, 201);
            this.output_val.Name = "output_val";
            this.output_val.Size = new System.Drawing.Size(127, 20);
            this.output_val.TabIndex = 35;
            // 
            // Q
            // 
            this.Q.Location = new System.Drawing.Point(119, 74);
            this.Q.Name = "Q";
            this.Q.Size = new System.Drawing.Size(67, 20);
            this.Q.TabIndex = 34;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Tahoma", 11.25F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(7, 171);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(59, 18);
            this.label3.TabIndex = 33;
            this.label3.Text = "Output";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(116, 58);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(15, 13);
            this.label2.TabIndex = 32;
            this.label2.Text = "Q";
            // 
            // gen
            // 
            this.gen.Location = new System.Drawing.Point(235, 166);
            this.gen.Name = "gen";
            this.gen.Size = new System.Drawing.Size(75, 23);
            this.gen.TabIndex = 31;
            this.gen.Text = "Generate";
            this.gen.UseVisualStyleBackColor = true;
            this.gen.Click += new System.EventHandler(this.generate);
            // 
            // P
            // 
            this.P.Location = new System.Drawing.Point(7, 74);
            this.P.Name = "P";
            this.P.Size = new System.Drawing.Size(56, 20);
            this.P.TabIndex = 30;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(4, 58);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(13, 13);
            this.label1.TabIndex = 29;
            this.label1.Text = "P";
            this.label1.Click += new System.EventHandler(this.label1_Click);
            // 
            // E
            // 
            this.E.Location = new System.Drawing.Point(243, 74);
            this.E.Name = "E";
            this.E.Size = new System.Drawing.Size(67, 20);
            this.E.TabIndex = 40;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(240, 58);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(13, 13);
            this.label4.TabIndex = 39;
            this.label4.Text = "e";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(8, 11);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(29, 13);
            this.label6.TabIndex = 42;
            this.label6.Text = "User";
            // 
            // user
            // 
            this.user.FormattingEnabled = true;
            this.user.Items.AddRange(new object[] {
            "sender",
            "reciever"});
            this.user.Location = new System.Drawing.Point(8, 27);
            this.user.Name = "user";
            this.user.Size = new System.Drawing.Size(121, 21);
            this.user.TabIndex = 41;
            this.user.SelectedIndexChanged += new System.EventHandler(this.user_SelectedIndexChanged);
            // 
            // rsa_client
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(360, 241);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.user);
            this.Controls.Add(this.E);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.p_ki);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.output_val);
            this.Controls.Add(this.Q);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.gen);
            this.Controls.Add(this.P);
            this.Controls.Add(this.label1);
            this.Name = "rsa_client";
            this.Text = "RSA Client";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.closed);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox p_ki;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox output_val;
        private System.Windows.Forms.TextBox Q;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button gen;
        private System.Windows.Forms.TextBox P;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox E;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.ComboBox user;
    }
}