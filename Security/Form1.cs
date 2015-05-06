using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Security
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void choice(object sender, EventArgs e)
        {

        }

        private void go_to(object sender, EventArgs e)
        {

            if (this.choices.Text == "AES")
            {
                new AES_Client().Show();
                new AES_Server().Show();
            }
            else if (this.choices.Text == "AES-Image")
                new aesImage().Show();
            else if (this.choices.Text == "Ceaser")
                new ceaser().Show();
            else if (this.choices.Text == "Columnair")
                new columnair().Show();
            else if (this.choices.Text == "DiffieHellman")
            {
                new diffieHellman().Show();
                new diffieHellman2().Show();
            }
            else if (this.choices.Text == "Hill Cipher")
                new hill().Show();
            else if (this.choices.Text == "Monoalphabetic")
                new monoalphabetic().Show();
            else if (this.choices.Text == "Playfair")
                new playfair().Show();
            else if (this.choices.Text == "Rail fence")
                new railfence().Show();
            else if (this.choices.Text == "RC4")
            {
                new rc4().Show();
                new rc42().Show();
            }
            else if (this.choices.Text == "RSA")
            {
                
               new rsa_client().Show();
                new rsa_server().Show();
            }
            else if (this.choices.Text == "Vigenere")
                new vigenere().Show();

        }
    }
}
