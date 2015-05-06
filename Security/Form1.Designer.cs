namespace Security
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
            this.label1 = new System.Windows.Forms.Label();
            this.choices = new System.Windows.Forms.ComboBox();
            this.go = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.ForeColor = System.Drawing.Color.Purple;
            this.label1.Location = new System.Drawing.Point(81, 38);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(85, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Choose the algo";
            // 
            // choices
            // 
            this.choices.FormattingEnabled = true;
            this.choices.Items.AddRange(new object[] {
            "AES",
            "AES-Image",
            "Ceaser",
            "Columnair",
            "DiffieHellman",
            "Hill Cipher",
            "Monoalphabetic",
            "Playfair",
            "Rail fence",
            "RC4",
            "RSA",
            "Vigenere"});
            this.choices.Location = new System.Drawing.Point(66, 67);
            this.choices.Name = "choices";
            this.choices.Size = new System.Drawing.Size(121, 21);
            this.choices.TabIndex = 1;
            this.choices.SelectedIndexChanged += new System.EventHandler(this.choice);
            // 
            // go
            // 
            this.go.Location = new System.Drawing.Point(84, 107);
            this.go.Name = "go";
            this.go.Size = new System.Drawing.Size(75, 23);
            this.go.TabIndex = 2;
            this.go.Text = "Go";
            this.go.UseVisualStyleBackColor = true;
            this.go.Click += new System.EventHandler(this.go_to);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(240, 142);
            this.Controls.Add(this.go);
            this.Controls.Add(this.choices);
            this.Controls.Add(this.label1);
            this.Name = "Form1";
            this.Text = "Security";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox choices;
        private System.Windows.Forms.Button go;
    }
}

