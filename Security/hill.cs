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
    public partial class hill : Form
    {
        bool users;
        helperFunc hf;
        int[,] key;
        int[,] kInv;
        int[,] ptMx;
        int[,] oMx;
        int ksz, cols;
        public hill()
        {
            InitializeComponent();
            users = true;
            hf = new helperFunc();
        }

        bool initKey(string k)
        {
            if (k.Length == 9 || k.Length == 4)
            {
                if (k.Length == 9)
                {
                    key = new int[3, 3];
                    ksz = 3;
                }
                else if (k.Length == 4)
                {
                    key = new int[2, 2];
                    ksz = 2;
                }
                int l = 0;
                for (int i = 0; i < ksz; i++)
                    for (int j = 0; j < ksz; j++)
                        key[j, i] = k[l++] - 'a';
                return true;
            }
            return false;
        }

        //====== generate determinant for a given cell
        int getDet( int x, int y)
        {
            if (ksz == 2)
                return key[(x + 1) % 2, (y + 1) % 2];
            int x1 = (x + 1) % 3, x2 = (x + 2) % 3, y1 = (y + 1) % 3, y2 = (y + 2) % 3;
            int xMin = Math.Min(x1,x2), xMax = Math.Max(x1,x2), yMin = Math.Min(y1,y2), yMax = Math.Max(y1,y2);
            return (key[xMin, yMin] * key[xMax, yMax]) - (key[xMin, yMax] * key[xMax, yMin]);

        }

        //==== generate multiplicative inverse of the key
        bool keyInverse()
        {
            int detK = 0;
            if (ksz == 2)
                detK = (key[0, 0] * key[1, 1]) - (key[1, 0] * key[0, 1]);
            else
                detK = key[0, 0] * getDet(0, 0) - key[0, 1] * getDet(0, 1) + key[0, 2] * getDet(0, 2);
            detK = ((detK % 26) + 26) % 26;
            int b;
            bool check = false;
            for (b = 1; b < 27; b++)
            {
                if ((b * detK) % 26 == 1)
                {
                    check = true;
                    break;
                }
            }

            if (!check) //====== no multiplicative inverse found
                return check;
            //===== Apply rule kij ={b x (-1)i+j * Dij mod 26} mod 26
            kInv = new int[ksz, ksz];
            int[,] tempK = new int[ksz, ksz];
            for (int i = 0; i < ksz; i++)
                for (int j = 0; j < ksz; j++)
                    tempK[i, j] = (((b * ((i + j) % 2 == 1 ? -1 : 1) * getDet(i, j)) % 26) + 26) % 26;

            //==== transpose of keyInv matrix
            for (int i = 0; i < ksz; i++)
                for (int j = 0; j < ksz; j++)
                    kInv[i, j] = tempK[j, i];

            return true;
        }

        //======= fill input matrix with input text
        void init_pt_matrix(string p)
        {
            if (p.Length % ksz != 0)
            {
                int rem = ksz - (p.Length % ksz);
                for (int i = 0; i < rem; i++)
                    p += 'x';
            }
            cols = p.Length / ksz;
            ptMx = new int[ksz, cols];
            oMx = new int[ksz, cols];

            int l = 0;
            for (int i = 0; i < cols; i++)
                for (int j = 0; j < ksz; j++)
                    ptMx[j, i] = p[l++] - 'a';
        }

        //===== multiply input text and key to get the output
        string get_output()
        {
            //===== init
            string o = "";
            for (int i = 0; i < ksz; i++)
                for (int j = 0; j < cols; j++)
                    oMx[i, j] = 0;

            //===== multiplication
            for (int i = 0; i < ksz; i++)
                for (int j = 0; j < cols; j++)
                    for (int k = 0; k < ksz; k++)
                        oMx[i, j] += ((users == true ? key[i, k] : kInv[i, k]) * ptMx[k, j]);

            //===== generate string
            for (int i = 0; i < cols; i++)
            {
                for (int j = 0; j < ksz; j++)
                {
                    oMx[j, i] = oMx[j, i] % 26;
                    o += (char)(oMx[j, i] + 'a');
                }

            }

            if (users)
                o = o.ToUpper();
            return o;
        }

        private void gener(object sender, EventArgs e)
        {
            users = (this.user.Text == "reciever" ? false : true);
            if (!initKey(hf.format(ki.Text)))
            {
                MessageBox.Show("Error in key!");
                return;
            }

            if (!users && !keyInverse())
            {
                MessageBox.Show("Key has no multiplicative inverse!");
                return;
            }
            init_pt_matrix(hf.format(pt.Text));
            ct.Text = get_output();
        }
    }
}
