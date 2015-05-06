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
    public partial class railfence : Form
    {
        bool users;
        helperFunc hf;
        List<int> key;
        public railfence()
        {
            InitializeComponent();
            users = true;
            hf = new helperFunc();
            key = new List<int>();
        }

        //---------- generate the output string -----------//
        string generateOutput(int stag, string plain)
        {
            string s;
            while (stag-- != 0)
            {
                s = "";
                if (users) //encryption
                {
                    int rem = (plain.Length % key.Count != 0 ? 1 : 0);
                    for (int i = 0; i < key.Count; i++)
                        for (int j = 0; j < plain.Length / key.Count + rem; j++)
                            if (key[i] + (j * key.Count)<plain.Length)
                            s += plain[key[i] + (j * key.Count)];
                }
                else //decryption
                {
                    int k = plain.Length / key.Count;
                    int rem = plain.Length % key.Count;
                    for (int i = 0; i < k+rem; i++)
                        for (int j = 0; j < key.Count; j++)
                            if ((key[j] * (k + 1)) - (key[j] > rem ? key[j] - rem : 0) + i < plain.Length)
                                if( !( i == k+rem-1 && j>= rem))
                                s += plain[(key[j] * (k+1)) - (key[j] > rem ? key[j]-rem : 0 ) + i];
                }
                plain = s;
            }
            if (users)
                plain = plain.ToUpper();
            return plain;
        }

        //----------- get the key and format the input string ---------//
        string init()
        {
            key.Clear();
            int dp = Int32.Parse(dps.Text);
            for (int i = 0; i < dp; i++)
                key.Add(i);
            return hf.format(this.pt.Text);
        }

        private void Gener_Click(object sender, EventArgs e)
        {
            users = (this.user.Text == "reciever" ? false : true);
            int stag = Int32.Parse(this.stages.Text);
            this.ct.Text = generateOutput(stag, init());
        }
    }
}
