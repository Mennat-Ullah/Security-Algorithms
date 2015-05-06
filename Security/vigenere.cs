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
    public partial class vigenere : Form
    {
        string stream;
        bool typ;
        helperFunc hf;
        bool users;
        public vigenere()
        {
            InitializeComponent();
            hf = new helperFunc();
            typ = true; // true: repeating / false: autokey
            users = true;
            stream = "";
        }

        //--------- generate the keyStream ----------//
        private void generate_stream(string s, int l)
        {
            while (stream.Length < l)
            {
                if (l - stream.Length >= s.Length)
                    stream += s;
                else
                    stream += s.Substring(0, l - stream.Length);
            }
        }

        //-------- generate output for sender --------//
        private string ciphered(string s)
        {
            string m = "";
            for (int i = 0; i < s.Length; i++)
                m += (char)('A' + (s[i] - 'a' + stream[i] - 'a') % 26);
            return m;
        }

        //------- generate output for reciever --------//
        private string plainT(string s)
        {
            string m = "";
            for (int i = 0; i < s.Length; i++)
            {
                m += (char)('a' + ((s[i] - stream[i] + 26) % 26));
                if (!typ)
                    stream += m[i];
            }
            return m;
        }

        private void generate_Click(object sender, EventArgs e)
        {
            string msg = hf.format(this.pt.Text), key = this.ki.Text.ToLower();
            typ = (this.type.Text == "autokey" ? false : true);
            users = (this.user.Text == "reciever" ? false : true);
            stream = key;
            if (users)
                generate_stream((typ ? key : msg), msg.Length);
            else if (typ)
                generate_stream(key, msg.Length);
            this.ct.Text = ( users == true ? ciphered(msg) : plainT(msg));
        }

    }
}
