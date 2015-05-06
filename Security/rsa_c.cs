using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Security
{
    public class rsa_c
    {
        public long Multiplicative_Invese(long e, long Fn)
        {
            long d = multiplicative_inverse_extended_euclid_numbers(e, Fn);
            return d;
        }
        public long Encryption(long e, long n, long M)
        {
            long CipherText = 0;
            CipherText = big_power(M, e, n);
            return CipherText;
        }
        public long[] alphanumeric(string alphanum, long e, long n)
        {
            int length = alphanum.Length;
            long[] CipherText = new long[length];

            char[] c = new char[length + 1];
            for (int i = 0; i < length; i++)
            {
                int M = alphanum[i];

                CipherText[i] = Encryption(e, n, M);

            }

            return CipherText;
        }
        public long multiplicative_inverse_extended_euclid_numbers(long val1, long val2)
        {

            long greater, other;
            if (val1 >= val2)
            {
                greater = val1;
                other = val2;
            }
            else
            {
                greater = val2;
                other = val1;
            }

            long multiplicative_inverse = 0;
            //    //+++++++++++++++++++++++++++++++++++++++++++++++++++++
            long[,] extended_euclid = new long[100, 7];
            /*  extended_euclid[0, 0] = "Q";
              extended_euclid[0, 1] = "A1";
              extended_euclid[0, 2] = "A2";
              extended_euclid[0, 3] = "A3";
              extended_euclid[0, 4] = "B1";
              extended_euclid[0, 5] = "B2";
              extended_euclid[0, 6] = "B3";*/
            //++++++++++++++++++++++++++++++++++++++++++++++++++++++

            // extended_euclid[1, 0] = "X";
            extended_euclid[1, 1] = 1;
            extended_euclid[1, 2] = 0;
            extended_euclid[1, 3] = greater;//.ToString();
            extended_euclid[1, 4] = 0;
            extended_euclid[1, 5] = 1;
            extended_euclid[1, 6] = other;//.ToString();
            //++++++++++++++++++++++++++++++++++++++++++++++++++++++
            long current = 2;
            while (extended_euclid[current - 1, 6] != 1 && extended_euclid[current - 1, 6] != 0)
            {
                for (long j = 0; j < 7; j++)//columns
                {
                    if (j == 0)
                    {
                        // plynomial division
                        extended_euclid[current, 0] = extended_euclid[current - 1, 3] / extended_euclid[current - 1, 6];
                        extended_euclid[current, 6] = extended_euclid[current - 1, 3] % extended_euclid[current - 1, 6];

                    }
                    else if (j == 1 || j == 2 || j == 3)
                    {
                        //Ai=Bi-1
                        extended_euclid[current, j] = extended_euclid[current - 1, j + 3];
                    }
                    else if (j == 4 || j == 5)
                    {
                        //Bi=Ai=Q*Bi-1
                        extended_euclid[current, j] = extended_euclid[current - 1, j - 3] - (extended_euclid[current - 1, j] * extended_euclid[current, 0]);
                    }
                }
                current++;
            }
            multiplicative_inverse = extended_euclid[current - 1, 5];
            while (multiplicative_inverse < 0)
            {
                multiplicative_inverse = multiplicative_inverse + greater;
            }
            if (extended_euclid[current - 1, 6] == 0)
            {
                Console.Write("GCD not Multiplicative inverse:");
            }
            return multiplicative_inverse;
        }

        public long big_power(long Base, long power, long n)
        {
            long result = Base;
            for (long i = 0; i < power - 1; i++)
            {
                result = (result * Base) % n;
            }
            return result;
        }
        public string Dencryption(long d, long n, long[] M)
        {
            string PlainText = "";
            char c;
            for (long i = 0; i < M.Length; i++)
            {
                long Plaintext = Encryption(d, n, M[i]);

                c = (char)Plaintext;
                PlainText += c;
            }

            return PlainText;
        }
    }
}
