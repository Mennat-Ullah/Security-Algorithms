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
    public partial class ceaser : Form
    {
        bool users;
        helperFunc hf;
        public ceaser()
        {
            InitializeComponent();
            users = true;
            hf = new helperFunc();
        }

        //--------- generation of the output msg by susbstituting in the new msg --------//
        private string outPut(string s, int k)
        {
            s = hf.format(s); // to remove spaces and make all string lowe case
            k %= 26;
            string S = "";
            for (int i = 0; i < s.Length; i++)
                if (users)
                    S += (char)(((s[i] - 'a' + k) % 26) + 'a');
                else
                    S += (char)(((s[i] - 'a' - k + 26) % 26) + 'a');
            if (users)
                S = S.ToUpper();
            return S;
        }

        private void generate(object sender, EventArgs e)
        {
            users = (this.user.Text == "reciever" ? false : true);
            this.ct.Text = outPut(this.pt.Text, Int32.Parse(this.ki.Text));
        }
    }
}
