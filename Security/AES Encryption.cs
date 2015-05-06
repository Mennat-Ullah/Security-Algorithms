
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Security
{
    public struct division_pair_Dec
    {
        public string quotien;
        public string remainder;
    };
    public struct Vector_poly_Dec
    {
        public bool modified;
        public string ploynomial;
    };

    public class AES_Encryption
    {
       


        //AES

        public static string ENCRYPTION(string msg, string[,] keys, bool input_type)
        {
            string round_output = "";//result of each round
            string[,] state_matrix = form_state_matrix(msg, input_type);//form the state matrix of the input msg

            int roundNumber = 0;
            string[,] subKey = new string[4, 4];
            int key_round_cursor = roundNumber * 4;


            while (roundNumber <= 9)
            {
                //-------------------------------------------------initial add round key ----------------------------------------
                if (roundNumber == 0)
                {
                    for (int i = 0; i < 4; i++)
                    {
                        for (int j = 0; j < 4; j++)
                        {
                            subKey[i, j] = keys[i, key_round_cursor + j];
                        }
                    }
                    state_matrix = Add_Round_Key(state_matrix, subKey);

                }

                //---------------------------------------------substitute bytes -------------------------------------------------
                for (int i = 0; i < 4; i++)//substitute the bytes :D
                {
                    for (int j = 0; j < 4; j++)
                    {
                        state_matrix[i, j] = Sub_Bytes(state_matrix[i, j]);
                    }
                }


                state_matrix = Shift_Rows(state_matrix);

                //---------------------------------------------------mix coumns -------------------------------------------------------
                if (roundNumber < 9)
                {
                    string[] col = new string[4];
                    for (int i = 0; i < 4; i++)
                    {
                        for (int j = 0; j < 4; j++)
                        {
                            col[j] = state_matrix[j, i];
                        }
                        col = Mix_Column(col);
                        for (int j = 0; j < 4; j++)
                        {
                            state_matrix[j, i] = col[j];
                        }
                    }
                }

                //------------------------------------------------ Add round Key----------------------------------------------------------
                subKey = new string[4, 4];
                key_round_cursor = (roundNumber + 1) * 4;
                for (int i = 0; i < 4; i++)
                {
                    for (int j = 0; j < 4; j++)
                    {
                        subKey[i, j] = keys[i, key_round_cursor + j];
                        Console.Write(subKey[i, j] + "  ");
                    }
                    Console.WriteLine();
                }

                state_matrix = Add_Round_Key(state_matrix, subKey);


                for (int i = 0; i < 4; i++)
                {
                    for (int j = 0; j < 4; j++)
                    {
                        Console.Write(state_matrix[i, j]);
                    }
                    Console.WriteLine();
                }
                roundNumber++;
                Console.WriteLine("......................");
            }


            //to dispay encrypted msg 
            for (int i = 0; i < 4; i++)
            {
                for (int j = 0; j < 4; j++)
                {
                    String hs = state_matrix[j, i];
                    //round_output +=char s= System.Convert.ToChar(System.Convert.ToUInt32(hs, 16)).ToString();
                    round_output += state_matrix[j, i];
                }
            }

            return round_output;

            //// mix coulmns 




        }

        public static string[] Div_Text(string plaintext)
        {
            int length = plaintext.Length;//length of text
            int d = length / 32;//number of 32
            int i = 0;
            string[] strings;
            if (length % 32 == 0)
            {
                strings = new string[d];
                while (i < d)
                {
                    string plain_text = plaintext.Substring(0, 32);//sub of 32 
                    //Console.WriteLine(plain_text);
                    strings[i] = plain_text;
                    plaintext = plaintext.Remove(0, 32);//remove the read sub
                    i++;

                }
            }
            else
            {
                strings = new string[d + 1];
                while (i < d)
                {
                    string plain_text = plaintext.Substring(0, 32);//sub of 32 
                    //Console.WriteLine(plain_text);
                    strings[i] = plain_text;
                    plaintext = plaintext.Remove(0, 32);//remove the read sub
                    i++;

                }
                strings[i] = plaintext;
            }

            //Console.WriteLine(plaintext);
            return strings;
        }

        public static string[,] startKeyGeneration(string key)
        {
            string[,] RoundKey = new string[4, 44];
            string[] RoKey_1 = new string[4];
            string[] RoKey_4 = new string[4];
            string[] minbox_RN = new string[4];
            RoundKey = Initial_Key(key);
            for (int j = 4; j < 44; j++)
            {
                for (int i = 0; i < 4; i++)
                {
                    RoKey_1[i] = RoundKey[i, j - 1];
                    RoKey_4[i] = RoundKey[i, j - 4];
                }

                if (j % 4 == 0)
                {
                    RoKey_1 = shift_column(RoKey_1);
                    minbox_RN = lasa(j);
                    for (int g = 0; g < 4; g++)
                    {
                        RoKey_1[g] = Sub_Bytes(RoKey_1[g]);
                        RoundKey[g, j] = binary_hex_map_AES(xor(xor(hex_binary_map(RoKey_1[g]), hex_binary_map(RoKey_4[g]), 8), hex_binary_map(minbox_RN[g]), 8));
                    }


                }
                else
                {
                    for (int g = 0; g < 4; g++)
                    {
                        RoundKey[g, j] = binary_hex_map_AES(xor(hex_binary_map(RoKey_1[g]), hex_binary_map(RoKey_4[g]), 8));
                    }

                }

            }
            return RoundKey;

        }
        public static string[] Sub_SBox(string[] column)
        {
            string[,] SBox = 
{
	{"63", "7C", "77", "7B", "F2", "6B", "6F", "C5", "30", "01", "67", "2B", "FE", "D7", "AB", "76"},
	{"CA", "82", "C9", "7D", "FA", "59", "47", "F0", "AD", "D4", "A2", "AF", "9C", "A4", "72", "C0"},
	{"B7", "FD", "93", "26", "36", "3F", "F7", "CC", "34", "A5", "E5", "F1", "71", "D8", "31", "15"},
	{"04", "C7", "23", "C3", "18", "96", "05", "9A", "07", "12", "80", "E2", "EB", "27", "B2", "75"},
	{"09", "83", "2C", "1A", "1B", "6E", "5A", "A0", "52", "3B", "D6", "B3", "29", "E3", "2F", "84"},
	{"53", "D1", "00", "ED", "20", "FC", "B1", "5B", "6A", "CB", "BE", "39", "4A", "4C", "58", "CF"},
	{"D0", "EF", "AA", "FB", "43", "4D", "33", "85", "45", "F9", "02", "7F", "50", "3C", "9F", "A8"},
	{"51", "A3", "40", "8F", "92", "9D", "38", "F5", "BC", "B6", "DA", "21", "10", "FF", "F3", "D2"},
	{"CD", "0C", "13", "EC", "5F", "97", "44", "17", "C4", "A7", "7E", "3D", "64", "5D", "19", "73"},
	{"60", "81", "4F", "DC", "22", "2A", "90", "88", "46", "EE", "B8", "14", "DE", "5E", "0B", "DB"},
	{"E0", "32", "3A", "0A", "49", "06", "24", "5C", "C2", "D3", "AC", "62", "91", "95", "E4", "79"},
	{"E7", "C8", "37", "6D", "8D", "D5", "4E", "A9", "6C", "56", "F4", "EA", "65", "7A", "AE", "08"},
	{"BA", "78", "25", "2E", "1C", "A6", "B4", "C6", "E8", "DD", "74", "1F", "4B", "BD", "8B", "8A"},
	{"70", "3E", "B5", "66", "48", "03", "F6", "0E", "61", "35", "57", "B9", "86", "C1", "1D", "9E"},
	{"E1", "F8", "98", "11", "69", "D9", "8E", "94", "9B", "1E", "87", "E9", "CE", "55", "28", "DF"},
	{"8C", "A1", "89", "0D", "BF", "E6", "42", "68", "41", "99", "2D", "0F", "B0", "54", "BB", "16"}
};
            string[,] hex = new string[,] { { "A", "10" }, { "B", "11" }, { "C", "12" }, { "D", "13" }, { "E", "14" }, { "F", "15" } };

            char tempR, tempC;
            int row = 0, colm = 0;
            string index = " ";
            for (int i = 0; i < 4; i++)
            {

                tempR = column[i][0];
                tempC = column[i][1];
                if (tempR == 'A' || tempR == 'B' || tempR == 'C' || tempR == 'D' || tempR == 'E' || tempR == 'F')
                {

                    for (int h = 0; h < 6; h++)
                    {
                        if (tempR == Convert.ToChar(hex[h, 0]))
                        {
                            index = hex[h, 1];
                            row = int.Parse(index);

                        }

                    }
                }
                else
                {
                    row = (int)Char.GetNumericValue(tempR);

                }

                if (tempC == 'A' || tempC == 'B' || tempC == 'C' || tempC == 'D' || tempC == 'E' || tempC == 'F')
                {
                    for (int h = 0; h < 6; h++)
                    {
                        if (tempC == Convert.ToChar(hex[h, 0]))
                        {
                            index = hex[h, 1];

                            colm = int.Parse(index);

                        }

                    }

                }
                else
                {
                    colm = (int)Char.GetNumericValue(tempC);

                }

                column[i] = SBox[row, colm];

            }
            return column;
        }
        public static string[] lasa(int RoundNumber)
        {
            RoundNumber = (RoundNumber / 4) - 1;
            string[] minbox_RN = new string[4];
            string[,] minbox = new string[,] {{"01","00","00","00"} ,{"02","00","00","00"} ,{"04","00","00","00"} ,{"08","00","00","00"} ,
				                            {"10","00","00","00"} ,{"20","00","00","00"} ,{"40","00","00","00"} ,
				                           {"80","00","00","00"} ,{"1B","00","00","00"} ,{"36","00","00","00"}};
            for (int i = 0; i < 4; i++)
            {
                minbox_RN[i] = minbox[RoundNumber, i];
            }
            return minbox_RN;
        }

        public static string binary_hex_map_AES(string binary)
        {
            string hex = "";
            string hex_upper = "";
            string hex_lower = "";
            //----index----0 1 2 3 4 5 6 7 8
            //---degree----8 7 6 5 4 3 2 1 0
            for (int i = 4; i < 8; i++)
            {
                hex_upper += binary[i - 4];
                hex_lower += binary[i];
            }
            hex_upper = binary_hex_nipple_map(hex_upper);
            hex_lower = binary_hex_nipple_map(hex_lower);
            hex = hex_upper + hex_lower;
            return hex;
        }

        public static string[,] Initial_Key(string Key)
        {
            string[,] First_Round_Key = new string[4, 44];
            int i = 0;
            while (i < Key.Length)
            {
                for (int j = 0; j < 4; j++)
                {

                    for (int k = 0; k < 4; k++)
                    {
                        if (j < 4)
                        {
                            First_Round_Key[k, j] = Key[i].ToString() + Key[i + 1].ToString();
                            i += 2;
                        }
                        else
                        {
                            First_Round_Key[k, j] = "00";
                        }
                    }

                }
            }
            return First_Round_Key;
        }
        public static string[,] form_state_matrix(string msg, bool input_type)
        {
            string[,] state_matrix = new string[4, 4];//4*4 matrix
            char[] chars = msg.ToCharArray();//convert msg to array of chars
            string hexaOutput;
            if (input_type == true)//string
            {
                if (msg.Length < 16)
                {
                    for (int i = msg.Length; i < 16; i++)
                    {
                        msg += "0";
                    }
                }
                for (int i = 0; i < msg.Length; i++)//for loop to convert the msg to hex matrix
                {
                    int value = Convert.ToInt32(msg[i]);
                    hexaOutput = String.Format("{0:X}", value);
                    state_matrix[i % 4, (i / 4)] = hexaOutput;//formula to make best use of this loop --> to calculate and fill at the same time

                }
            }
            //hex input
            else
            {
                if (msg.Length < 32)
                {
                    for (int i = msg.Length; i < 32; i++)
                    {
                        msg += "00";
                    }
                }
                int pos = 0;
                for (int i = 0; i < 4; i++)
                {
                    for (int j = 0; j < 4; j++)
                    {
                        state_matrix[j, i] = msg[pos].ToString() + msg[pos + 1].ToString();
                        pos += 2;
                    }
                }
            }


            return state_matrix;
        }

        public static string multiplicative_inverse_extended_euclid_polynomial(string val)
        {
            string multiplicative_inverse = "";
            //    //+++++++++++++++++++++++++++++++++++++++++++++++++++++
            string[,] extended_euclid = new string[100, 7];
            extended_euclid[0, 0] = "Q";
            extended_euclid[0, 1] = "A1";
            extended_euclid[0, 2] = "A2";
            extended_euclid[0, 3] = "A3";
            extended_euclid[0, 4] = "B1";
            extended_euclid[0, 5] = "B2";
            extended_euclid[0, 6] = "B3";
            //++++++++++++++++++++++++++++++++++++++++++++++++++++++

            extended_euclid[1, 0] = "X";
            extended_euclid[1, 1] = "000000001";
            extended_euclid[1, 2] = "000000000";
            extended_euclid[1, 3] = "100011011";// hex_binary_map(greater);//greater.ToString();
            extended_euclid[1, 4] = "000000000";
            extended_euclid[1, 5] = "000000001";
            extended_euclid[1, 6] = "0" + hex_binary_map(val);
            //++++++++++++++++++++++++++++++++++++++++++++++++++++++
            int current = 2;
            while (extended_euclid[current - 1, 6] != "000000001")
            {
                for (int j = 0; j < 7; j++)//columns
                {
                    if (j == 0)
                    {
                        // plynomial division
                        extended_euclid[current, 0] = polynomial_division(extended_euclid[current - 1, 3], extended_euclid[current - 1, 6]).quotien;
                        extended_euclid[current, 6] = polynomial_division(extended_euclid[current - 1, 3], extended_euclid[current - 1, 6]).remainder;

                    }
                    else if (j == 1 || j == 2 || j == 3)
                    {
                        //Ai=Bi-1
                        extended_euclid[current, j] = extended_euclid[current - 1, j + 3];
                    }
                    else if (j == 4 || j == 5)
                    {
                        //Bi=Ai=Q*Bi-1
                        extended_euclid[current, j] = polynomial_subtraction(extended_euclid[current - 1, j - 3], polynomial_multiplication(extended_euclid[current - 1, j], extended_euclid[current, 0]));
                    }
                }
                current++;
            }
            multiplicative_inverse = binary_hex_map(extended_euclid[current - 1, 5]);
            //  Console.Write(extended_euclid[current-1,5 ]);
            return multiplicative_inverse;

            /*  for(int i=0;i<7;i++)
             {
                 Console.Write(extended_euclid[0, i]);
             }
             Console.WriteLine();
             for (int i = 0; i < 7; i++)
             {
                 Console.Write(extended_euclid[1, i]);
             }
             Console.WriteLine();
        
             Console.WriteLine(x);*/




        }

        public static int multiplicative_inverse_extended_euclid_numbers(int val1, int val2)
        {

            int greater, other;
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

            int multiplicative_inverse = 0;
            //    //+++++++++++++++++++++++++++++++++++++++++++++++++++++
            int[,] extended_euclid = new int[100, 7];
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
            int current = 2;
            while (extended_euclid[current - 1, 6] != 1 && extended_euclid[current - 1, 6] != 0)
            {
                for (int j = 0; j < 7; j++)//columns
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


        public static string rotate_multiplicative_inverse(string multiplicative_inverse)
        {
            string rotated_value = "";
            char MSB, LSB;
            char[] charArr = new char[8];
            for (int i = 0; i < 8; i++)
            {
                charArr[i] = multiplicative_inverse[i];
            }
            LSB = charArr[7];
            MSB = charArr[0];
            charArr[0] = LSB;
            charArr[7] = MSB;
            if (charArr[0] == '1')
            {
                charArr[7] = '1';
            }
            else
            {
                charArr[7] = '0';
            }
            //----index----0 1 2 3 4 5 6 7 
            //---degree----7 6 5 4 3 2 1 0

            rotated_value = new string(charArr);
            return rotated_value;
        }

        public static char bitwise_xor(char a, char b)
        {
            if (a == '1' && b == '0' || a == '0' && b == '1')
            {
                return '1';
            }
            else
                return '0';
        }

        public static string decimal_hex_map(string Decimal)
        {
            string hex = "";
            switch (Decimal)
            {
                case "0":
                    {
                        hex += "00";
                        break;
                    }
                case "1":
                    {
                        hex += "01";
                        break;
                    }
                case "2":
                    {
                        hex += "02";
                        break;
                    }
                case "3":
                    {
                        hex += "03";
                        break;
                    }
                case "4":
                    {
                        hex += "04";
                        break;
                    }
                case "5":
                    {
                        hex += "05";
                        break;
                    }
                case "6":
                    {
                        hex += "06";
                        break;
                    }
                case "7":
                    {
                        hex += "07";
                        break;
                    }
                case "8":
                    {
                        hex += "08";
                        break;
                    }
                case "9":
                    {
                        hex += "09";
                        break;
                    }
                case "10":
                    {
                        hex += "0A";
                        break;
                    }
                case "11":
                    {
                        hex += "0B";
                        break;
                    }
                case "12":
                    {
                        hex += "0C";
                        break;
                    }
                case "13":
                    {
                        hex += "0D";
                        break;
                    }
                case "14":
                    {
                        hex += "0E";
                        break;
                    }
                case "15":
                    {
                        hex += "0F";
                        break;
                    }
                default:
                    {
                        break;
                    }
            }
            return hex;
        }

        public static string binary_hex_nipple_map(string binary)
        {
            string hex_nipple = "";
            switch (binary)
            {
                case "0000":
                    {
                        hex_nipple = "0";
                        break;
                    }
                case "0001":
                    {
                        hex_nipple = "1";
                        break;
                    }
                case "0010":
                    {
                        hex_nipple = "2";
                        break;
                    }
                case "0011":
                    {
                        hex_nipple = "3";
                        break;
                    }
                case "0100":
                    {
                        hex_nipple = "4";
                        break;
                    }
                case "0101":
                    {
                        hex_nipple = "5";
                        break;
                    }
                case "0110":
                    {
                        hex_nipple = "6";
                        break;
                    }
                case "0111":
                    {
                        hex_nipple = "7";
                        break;
                    }
                case "1000":
                    {
                        hex_nipple = "8";
                        break;
                    }
                case "1001":
                    {
                        hex_nipple = "9";
                        break;
                    }
                case "1010":
                    {
                        hex_nipple = "A";
                        break;
                    }
                case "1011":
                    {
                        hex_nipple = "B";
                        break;
                    }
                case "1100":
                    {
                        hex_nipple = "C";
                        break;
                    }
                case "1101":
                    {
                        hex_nipple = "D";
                        break;
                    }
                case "1110":
                    {
                        hex_nipple = "E";
                        break;
                    }
                case "1111":
                    {
                        hex_nipple = "F";
                        break;
                    }
                default:
                    {
                        break;
                    }
            }
            return hex_nipple;
        }

        public static string binary_hex_map(string binary)
        {
            string hex = "";
            string hex_upper = "";
            string hex_lower = "";
            //----index----0 1 2 3 4 5 6 7 8
            //---degree----8 7 6 5 4 3 2 1 0
            for (int i = 1; i <= 4; i++)
            {
                hex_upper += binary[i];
                hex_lower += binary[(i + 4)];
            }
            hex_upper = binary_hex_nipple_map(hex_upper);
            hex_lower = binary_hex_nipple_map(hex_lower);
            hex = hex_upper + hex_lower;
            return hex;
        }

        public static string hex_binary_map(string Hex)
        {
            string binary = "";
            for (int i = 0; i < 2; i++)
            {
                switch (Hex[i])
                {
                    case '0':
                        {
                            binary += "0000";
                            break;
                        }
                    case '1':
                        {
                            binary += "0001";
                            break;
                        }
                    case '2':
                        {
                            binary += "0010";
                            break;
                        }
                    case '3':
                        {
                            binary += "0011";
                            break;
                        }
                    case '4':
                        {
                            binary += "0100";
                            break;
                        }
                    case '5':
                        {
                            binary += "0101";
                            break;
                        }
                    case '6':
                        {
                            binary += "0110";
                            break;
                        }
                    case '7':
                        {
                            binary += "0111";
                            break;
                        }
                    case '8':
                        {
                            binary += "1000";
                            break;
                        }
                    case '9':
                        {
                            binary += "1001";
                            break;
                        }
                    case 'A':
                        {
                            binary += "1010";
                            break;
                        }
                    case 'B':
                        {
                            binary += "1011";
                            break;
                        }
                    case 'C':
                        {
                            binary += "1100";
                            break;
                        }
                    case 'D':
                        {
                            binary += "1101";
                            break;
                        }
                    case 'E':
                        {
                            binary += "1110";
                            break;
                        }
                    case 'F':
                        {
                            binary += "1111";
                            break;
                        }
                    default:
                        {
                            break;
                        }

                }
            }
            return binary;
        }

        public static string binary_mul(string binary_polynoial, int index)
        {
            string temp_binary_polynomial = binary_polynoial;
            string irreducabe_polynomial = "100011011";/////////////////////////////////////////////////////////////
            char MSB;
            while (index >= 1)
            {
                MSB = temp_binary_polynomial[1]; //bit x^7 :D
                temp_binary_polynomial = temp_binary_polynomial.Substring(1, temp_binary_polynomial.Length - 1) + '0';
                if (MSB == '1')
                {
                    temp_binary_polynomial = xor(temp_binary_polynomial, irreducabe_polynomial, 9);
                }
                index--;
            }
            return temp_binary_polynomial;
        }

        public static string xor(string value1, string value2, int size)
        {

            string result = "";
            char[] charArr = new char[size];
            for (int i = 0; i < size; i++)
            {
                if ((value1[i] == '0' && value2[i] == '1') || (value1[i] == '1' && value2[i] == '0'))
                {
                    charArr[i] = '1'; // freely modify the array
                }
                else
                {
                    charArr[i] = '0'; // freely modify the array
                }
                result = new string(charArr); // create a new string with array contents.
            }
            return result;
            //char[] charAArray = value1.ToCharArray();
            //char[] charBArray = value2.ToCharArray();
            //string result = "";
            //int len = 0;

            //// Set length to be the length of the shorter string

            //for (int i = 0; i < size; i++)
            //{
            //    int x;

            //    x = ((Convert.ToInt32(charAArray[i])) ^ (Convert.ToInt32(charBArray[i]))); //error here
            //    result = Convert.ToString(x) + result;
            //}

            //return result;
        }
        public static string polynomial_multiplication(string poly1, string poly2)
        {
            Vector_poly_Dec[] sub_results = new Vector_poly_Dec[9];

            char[] charArray = poly2.ToCharArray();
            Array.Reverse(charArray);//reverse because i==0 match to power 8
            poly2 = new string(charArray);
            string result = "000000000";
            for (int i = 0; i < 9; i++)//to 9 because it is 9 bits to be polynomial of 8th degree
            {
                if (poly2[i] == '1')//means if there is value corresponding to this part of the polynomial
                {
                    sub_results[i].modified = true;//mark this part as modified for further user to calculate the total result
                    sub_results[i].ploynomial = binary_mul(poly1, i);
                    result = xor(result, sub_results[i].ploynomial, 9);//xor the sub result with the total result to get the final result by the end of this for loop
                }
            }
            return result;
        }

        public static division_pair_Dec polynomial_division(string poly1, string poly2)
        {
            division_pair_Dec output = new division_pair_Dec();
            string qoutien = "000000000";
            string sub_quotient = "000000000";
            string tmp_poly1 = "000000000";
            int poly1_deg = degree(poly1);
            int poly2_deg = degree(poly2);
            int greater, other;
            int diff;
            if (poly1_deg >= poly2_deg)
            {
                greater = poly1_deg;
                other = poly2_deg;
                diff = greater - other;
            }
            else
            {
                /*  greater = poly2_deg;
                  other = poly1_deg;*/
                diff = -1;
            }


            if (diff > 0)
            {
                sub_quotient = sub_qoutien_construction(diff);
                tmp_poly1 = polynomial_multiplication(poly2, sub_quotient);//we multiplicate the sub_quotient * el ma2som 3aleh
                qoutien = xor(qoutien, sub_quotient, 9);//we add the sub quotient to the old quotient
                poly1 = polynomial_subtraction(poly1, tmp_poly1);//we subtract the multiplictaion value of ( sub_quotient * el ma2som 3aleh) from the el ma2som 3ashan nekamel 2esma
                division_pair_Dec tmp_output = polynomial_division(poly1, poly2);
                qoutien = xor(qoutien, tmp_output.quotien, 9);//habda2 el 3amaleya mn el awel bel ma2som el geded w mafs el ma2som 3aleh
                output.quotien = qoutien;
                output.remainder = tmp_output.remainder;
                // output.remainder = poly1;
            }
            else
            {

                if (diff == 0)//we can add 1 to the quotient polynomial
                {
                    poly1 = polynomial_subtraction(poly1, poly2);//since the difference is 0 this means that both have the same degree so we can 1 to the quotient
                    char[] charArr = { '0', '0', '0', '0', '0', '0', '0', '0', '1' };
                    string last_part_of_quotient = new string(charArr);
                    qoutien = xor(qoutien, last_part_of_quotient, 9);
                    output.quotien = qoutien;
                    output.remainder = poly1;
                    return output;
                }
                else//we have to stop now 
                {
                    output.quotien = qoutien;
                    output.remainder = poly1;
                    return output;
                }

            }
            return output;




            //  return qoutien;
        }

        public static int degree(string polynomial)
        {
            //  int deg = 0;
            char[] charArray = polynomial.ToCharArray();
            Array.Reverse(charArray);
            for (int i = 0; i < polynomial.Length; i++)
            {
                if (polynomial[i] == '1')
                {
                    return (polynomial.Length - 1) - i;//the degree of the polynomial
                    //----index----0 1 2 3 4 5 6 7 8
                    //---degree----8 7 6 5 4 3 2 1 0
                }
            }
            return 0;
        }

        public static string sub_qoutien_construction(int diff)
        {
            string result = "";
            char[] charArr = new char[9];
            for (int i = 0; i < 9; i++)
            {
                if (i == diff)
                {
                    charArr[8 - i] = '1'; // freely modify the array
                }
                else
                {
                    charArr[8 - i] = '0'; // freely modify the array
                }
                result = new string(charArr); // create a new string with array contents.
            }
            return result;
        }

        public static string polynomial_subtraction(string poly1, string poly2)
        {
            string difference = "";
            char[] charArr = new char[9];
            for (int i = 0; i < 9; i++)
            {
                if (poly1[i] == '1' && poly2[i] == '0' || poly1[i] == '0' && poly2[i] == '1')
                {
                    charArr[i] = '1';
                }
                else
                {
                    charArr[i] = '0';
                }
            }
            difference = new string(charArr);
            return difference;

        }

        public static string[] shift_column(string[] column)
        {
            string tepm = column[0];
            for (int i = 0; i < 3; i++)
            {
                column[i] = column[i + 1];
            }
            column[3] = tepm;
            return column;
        }
        public static string Sub_Bytes(string value)
        {
            string[,] S_BOX = 
{
	{"63", "7C", "77", "7B", "F2", "6B", "6F", "C5", "30", "01", "67", "2B", "FE", "D7", "AB", "76"},
	{"CA", "82", "C9", "7D", "FA", "59", "47", "F0", "AD", "D4", "A2", "AF", "9C", "A4", "72", "C0"},
	{"B7", "FD", "93", "26", "36", "3F", "F7", "CC", "34", "A5", "E5", "F1", "71", "D8", "31", "15"},
	{"04", "C7", "23", "C3", "18", "96", "05", "9A", "07", "12", "80", "E2", "EB", "27", "B2", "75"},
	{"09", "83", "2C", "1A", "1B", "6E", "5A", "A0", "52", "3B", "D6", "B3", "29", "E3", "2F", "84"},
	{"53", "D1", "00", "ED", "20", "FC", "B1", "5B", "6A", "CB", "BE", "39", "4A", "4C", "58", "CF"},
	{"D0", "EF", "AA", "FB", "43", "4D", "33", "85", "45", "F9", "02", "7F", "50", "3C", "9F", "A8"},
	{"51", "A3", "40", "8F", "92", "9D", "38", "F5", "BC", "B6", "DA", "21", "10", "FF", "F3", "D2"},
	{"CD", "0C", "13", "EC", "5F", "97", "44", "17", "C4", "A7", "7E", "3D", "64", "5D", "19", "73"},
	{"60", "81", "4F", "DC", "22", "2A", "90", "88", "46", "EE", "B8", "14", "DE", "5E", "0B", "DB"},
	{"E0", "32", "3A", "0A", "49", "06", "24", "5C", "C2", "D3", "AC", "62", "91", "95", "E4", "79"},
	{"E7", "C8", "37", "6D", "8D", "D5", "4E", "A9", "6C", "56", "F4", "EA", "65", "7A", "AE", "08"},
	{"BA", "78", "25", "2E", "1C", "A6", "B4", "C6", "E8", "DD", "74", "1F", "4B", "BD", "8B", "8A"},
	{"70", "3E", "B5", "66", "48", "03", "F6", "0E", "61", "35", "57", "B9", "86", "C1", "1D", "9E"},
	{"E1", "F8", "98", "11", "69", "D9", "8E", "94", "9B", "1E", "87", "E9", "CE", "55", "28", "DF"},
	{"8C", "A1", "89", "0D", "BF", "E6", "42", "68", "41", "99", "2D", "0F", "B0", "54", "BB", "16"}
};
            string hex = "ABCDEF";//to identify the hex values greater than 9
            int row = 0, col = 0;//to access the sbox
            string substituted_byte = "";//for return value
            string tmpvalue;
            int tmp;
            int position;
            for (int i = 0; i < 2; i++)//<2 to access first and second byte of the cell
            {
                tmpvalue = value[i].ToString();
                position = hex.IndexOf(tmpvalue);//here position will be the index of the letter if it contain letter otherwise position will be -1
                if (position >= 0)//is letter--> exist
                {
                    tmp = position + 10;//because A-10,B->11,C->12.....
                }
                else
                {
                    tmp = (int)Char.GetNumericValue(value[i]);//not letter so  number :D so get the numeric value of it only
                }
                if (i == 0)
                {
                    row = tmp;//if i==0; then we are assigning the row value
                }
                else//otherwise it's the column's value
                {
                    col = tmp;
                }
            }
            substituted_byte = S_BOX[row, col];//access the desired value :)
            return substituted_byte;
        }
        public static string[,] Shift_Rows(string[,] matrix)
        {
            string[] tmp_row = new string[4];//to get each row values to shift it
            int shift_val;
            for (int i = 1; i < 4; i++)//started by one because the first row won't be shifted
            {

                for (int row_fill = 0; row_fill < 4; row_fill++)//fill the tmp_row by the its values
                {
                    tmp_row[row_fill] = matrix[i, row_fill];
                }
                shift_val = i;
                for (int j = 0; j < 4; j++)
                {
                    matrix[i, j] = tmp_row[(shift_val + j) % 4];

                    //row 0:         W X Y Z
                    //shifted row 0: W X Y Z

                    //row 1:         W X Y Z
                    //shifted row 1: X Y Z W

                    //row 2:         W X Y Z
                    //shifted row 2: Y Z W X

                    //row 3:         W X Y Z
                    //shifted row 3: Z W X Y
                }

            }
            return matrix;
        }
        public static string[] Mix_Column(string[] PlainText)
        {
            string[,] Mix_Colum1 = new string[4, 4];
            string[] Mix_Colum = new string[4];
            string[,] matrix_ind = new string[,] { { "02", "03", "01", "01" }, 
                                                   { "01", "02", "03", "01" },
                                                   { "01", "01", "02", "03" }, 
                                                   { "03", "01", "01", "02" } };
            for (int i = 0; i < 4; i++)
            {
                PlainText[i] = '0' + hex_binary_map(PlainText[i]);
                for (int j = 0; j < 4; j++)
                {
                    matrix_ind[i, j] = '0' + hex_binary_map(matrix_ind[i, j]);
                }
            }

            for (int i = 0; i < 4; i++)
            {
                for (int j = 0; j < 4; j++)
                {

                    Mix_Colum1[i, j] = polynomial_multiplication(matrix_ind[i, j], PlainText[j]);
                    Mix_Colum1[i, j] = Mix_Colum1[i, j].Substring(1, Mix_Colum1[i, j].Length - 1);

                }

            }
            for (int i = 0; i < 4; i++)
            {

                Mix_Colum[i] = binary_hex_map_AES(xor(xor(xor(Mix_Colum1[i, 0], Mix_Colum1[i, 1], 8), Mix_Colum1[i, 2], 8), Mix_Colum1[i, 3], 8));

            }


            return Mix_Colum;
        }
        public static string[,] Add_Round_Key(string[,] matrix, string[,] key)
        {
            string[,] result = new string[4, 4];
            string[] tmp_col_matrix = new string[4];//to get the column that we will xor it with the corresponding col in the key
            string[] tmp_col_key = new string[4];


            for (int j = 0; j < 4; j++)
            {
                for (int col = 0; col < 4; col++)
                {
                    tmp_col_matrix[col] = matrix[col, j];
                    tmp_col_key[col] = key[col, j];
                }

                for (int i = 0; i < 4; i++)
                {
                    string s1 = "", s2 = "", finalresult1 = "";
                    s1 = hex_binary_map(tmp_col_matrix[i]);
                    s2 = hex_binary_map(tmp_col_key[i]);
                    finalresult1 = xor(s1, s2, 8);
                    finalresult1 = binary_hex_map_AES(finalresult1);
                    result[i, j] = finalresult1;
                }
            }
            return result;
        }

    }


}

