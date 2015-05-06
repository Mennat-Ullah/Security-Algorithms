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
    public partial class playfair : Form
    {
        int Users;
        bool[] alpha = new bool[26];
        int[,] matrix = new int[5, 5];
        helperFunc hf;
        public playfair()
        {
            InitializeComponent();
            hf = new helperFunc();
        }

        //--------- generate the payfair 5x5 matrix ---------//
        private void generateMatrix( string Key)
        {
            alpha = new bool[26];
            matrix = new int[5, 5];
            int idx = 0;

            for (int i = 0; i < 26; i++)
                alpha[i] = false;

            for (int i = 0; i < Key.Length; i++)
            {
                int c = Key[i] - 'a';
                if (!alpha[c])
                {
                    alpha[c] = true;
                    matrix[idx / 5, idx % 5] = c;
                    idx++;
                    if (c == 7 || c == 8)
                        alpha[7] = alpha[8] = true;
                }
            }
            for (int i = 0; i < 26; i++)
            {
                if (!alpha[i])
                {
                    alpha[i] = true;
                    matrix[idx / 5, idx % 5] = i;
                    idx++;
                    if (i == 7 || i == 8)
                        alpha[7] = alpha[8] = true;
                }
            }
        }

        //-------- gets the pace of a char in the playfair matrix ---------//
        private Tuple<int,int> get_idx(int n)
        {
            Tuple<int, int> idx = new Tuple<int, int>(0,0);
            for ( int i = 0; i < 5; i++ )
            {
                for( int j=0 ; j<5 ; j++ )
                {
                    if (matrix[i, j] == n)
                        idx = new Tuple<int, int>(i, j);
                    if( (n == 7 || n == 8) &&  ( matrix[i, j]==7 || matrix[i, j] == 8) )
                        idx = new Tuple<int, int>(i, j);
                }
            }
                return idx;
        }

        //---------- generate the output msg -----------//
        private string generate_msg( string M)
        {
            string ci = "";
            for (int i = 0; i < M.Length; i+=2 )
            {
                if (i + 1 == M.Length)
                    M += "x";
                else if (M[i] == M[i + 1])
                    M = M.Insert(i+1, "x");
                Tuple<int, int> idx = get_idx(M[i]-'a');
                Tuple<int, int> idx1 = get_idx(M[i+1] - 'a');

                if( idx.Item1 == idx1.Item1 ) // 2 char in the same row
                {
                    idx = new Tuple<int, int>(idx.Item1, (idx.Item2 + Users + 5) % 5);
                    idx1 = new Tuple<int, int>(idx1.Item1, (idx1.Item2 + Users + 5) % 5);
                }
                else if( idx.Item2 == idx1.Item2 ) // 2 char in the same column
                {
                    idx = new Tuple<int, int>((idx.Item1 + Users + 5) % 5, idx.Item2);
                    idx1 = new Tuple<int, int>((idx1.Item1 + Users + 5) % 5, idx1.Item2);
                }
                else // 2 char in different row & col
                {
                    int num = idx.Item2;
                    idx = new Tuple<int,int>( idx.Item1,idx1.Item2);
                    idx1 = new Tuple<int,int>(idx1.Item1,num);
                }
                ci += (char)(matrix[idx.Item1,idx.Item2] + 'a');
                ci += (char)(matrix[idx1.Item1, idx1.Item2] + 'a');
            }
            if ( Users == -1 )
                ci = ci.ToUpper();
           return ci;
        }

        private void generation(object sender, EventArgs e)
        {
            Users = (this.user.Text == "reciever" ? -1 : 1);
            generateMatrix(this.key.Text);
            this.cyber.Text = generate_msg( hf.format(this.msg.Text) );
        }
    }
}
