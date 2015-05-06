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
    public partial class columnair : Form
    {
        bool users;
        helperFunc hf;
        List<int> key;
        public columnair()
        {
            InitializeComponent();
            hf = new helperFunc();
            users = true;
            key = new List<int>();
        }

        //---------- generate the output string -----------//
        string generateOutput (int stag, string plain)
        {
            string s;
            while (stag-- != 0)
            {
                s = "";
                if (users) //encryption
                {
                    for (int i = 0; i < key.Count; i++)
                        for (int j = 0; j < plain.Length / key.Count; j++)
                            s += plain[key[i] + (j * key.Count)];
                }
                else //decryption
                {
                    int k = plain.Length / key.Count;
                    for (int i = 0; i < k; i++)
                        for (int j = 0; j < key.Count; j++)
                            s += plain[key[j] * k + i];
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

            string[] sr = this.ki.Text.Split(' ');
            for (int i = 0; i < sr.Length; i++)
                key.Add(Int32.Parse(sr[i]) - 1);


            string plain = hf.format(this.pt.Text);
            int rem = (key.Count - (plain.Length % key.Count)) % key.Count;
            for (int i = 0; i < rem; i++)
                plain += 'x';

            return plain;
        }

        private void generate_Click(object sender, EventArgs e)
        {
            users = (this.user.Text == "reciever" ? false : true);
            int stag = Int32.Parse(this.stages.Text);           
            this.ct.Text = generateOutput(stag, init() );
        }
    }
}
