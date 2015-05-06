using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Security
{
    public class helperFunc
    {
        public helperFunc()
        { }
        public string format(string s)
        {
            string S = "";
            for (int i = 0; i < s.Length; i++)
                if (s[i] != ' ')
                    S += Char.ToLower(s[i]);
            return S;
        }

        public void ReceiveEnc()
        {
           
        }

        public string readFile()
        {
            string s="8";
            return s;
        }

        public void sendFile(string s)
        { }

        public void sendEnc()
        {

        }


    }
}
