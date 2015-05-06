namespace Security
{
    partial class diffieHellman2
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
            this.snd = new System.Windows.Forms.Button();
            this.p_ki = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.sh_ki = new System.Windows.Forms.TextBox();
            this.prim = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.gen = new System.Windows.Forms.Button();
            this.bs = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.Status = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // snd
            // 
            this.snd.Location = new System.Drawing.Point(267, 136);
            this.snd.Name = "snd";
            this.snd.Size = new System.Drawing.Size(75, 23);
            this.snd.TabIndex = 28;
            this.snd.Text = "send";
            this.snd.UseVisualStyleBackColor = true;
            this.snd.Click += new System.EventHandler(this.snd_Click);
            // 
            // p_ki
            // 
            this.p_ki.Location = new System.Drawing.Point(15, 136);
            this.p_ki.Name = "p_ki";
            this.p_ki.Size = new System.Drawing.Size(127, 20);
            this.p_ki.TabIndex = 27;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Tahoma", 12F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(11, 105);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(102, 19);
            this.label5.TabIndex = 26;
            this.label5.Text = "Private key";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Tahoma", 12F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(17, 12);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(58, 19);
            this.label4.TabIndex = 25;
            this.label4.Text = "Public";
            // 
            // sh_ki
            // 
            this.sh_ki.Location = new System.Drawing.Point(15, 199);
            this.sh_ki.Name = "sh_ki";
            this.sh_ki.Size = new System.Drawing.Size(127, 20);
            this.sh_ki.TabIndex = 24;
            // 
            // prim
            // 
            this.prim.Location = new System.Drawing.Point(242, 61);
            this.prim.Name = "prim";
            this.prim.Size = new System.Drawing.Size(100, 20);
            this.prim.TabIndex = 23;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Tahoma", 11.25F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(15, 169);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(92, 18);
            this.label3.TabIndex = 22;
            this.label3.Text = "Shared key";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(239, 44);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(72, 13);
            this.label2.TabIndex = 21;
            this.label2.Text = "Prime number";
            // 
            // gen
            // 
            this.gen.Location = new System.Drawing.Point(267, 196);
            this.gen.Name = "gen";
            this.gen.Size = new System.Drawing.Size(75, 23);
            this.gen.TabIndex = 20;
            this.gen.Text = "Generate";
            this.gen.UseVisualStyleBackColor = true;
            this.gen.Click += new System.EventHandler(this.generate);
            // 
            // bs
            // 
            this.bs.Location = new System.Drawing.Point(15, 61);
            this.bs.Name = "bs";
            this.bs.Size = new System.Drawing.Size(109, 20);
            this.bs.TabIndex = 19;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 45);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(30, 13);
            this.label1.TabIndex = 18;
            this.label1.Text = "Base";
            // 
            // Status
            // 
            this.Status.AutoSize = true;
            this.Status.Location = new System.Drawing.Point(296, 12);
            this.Status.Name = "Status";
            this.Status.Size = new System.Drawing.Size(19, 13);
            this.Status.TabIndex = 29;
            this.Status.Text = "    ";
            // 
            // diffieHellman2
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(361, 248);
            this.Controls.Add(this.Status);
            this.Controls.Add(this.snd);
            this.Controls.Add(this.p_ki);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.sh_ki);
            this.Controls.Add(this.prim);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.gen);
            this.Controls.Add(this.bs);
            this.Controls.Add(this.label1);
            this.Name = "diffieHellman2";
            this.Text = "Diffie Hellman Client2";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.closed);
            this.Load += new System.EventHandler(this.diffieHellman2_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button snd;
        private System.Windows.Forms.TextBox p_ki;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox sh_ki;
        private System.Windows.Forms.TextBox prim;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button gen;
        private System.Windows.Forms.TextBox bs;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label Status;
    }
}