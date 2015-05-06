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
    public partial class monoalphabetic : Form
    {
        bool users;
        helperFunc hf;
        public monoalphabetic()
        {
            InitializeComponent();
            users = true;
            hf = new helperFunc();
        }

        //-------- generate output by substitution --------//
        private string outPut(string s, string k)
        {
            s = hf.format(s);
            string S = "";
            for (int i = 0; i < s.Length; i++)
                if (users)
                    S += k[ s[i]-'a' ];
                else
                    S += (char)('a' + k.IndexOf(s[i]) );
            if (users)
                S = S.ToUpper();
            return S;
        }

        private void generateTex(object sender, EventArgs e)
        {
            string Ky = hf.format(ki.Text);
            users = (this.user.Text == "reciever" ? false : true);
            if(Ky.Length != 26 )
            {
                MessageBox.Show("Error in Key size");
                return;
            }
            this.ct.Text = outPut(this.pt.Text, Ky);
        }
    }
}
