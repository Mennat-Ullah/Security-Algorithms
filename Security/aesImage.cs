using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;

namespace Security
{
    public partial class aesImage : Form
    {
         string loadImage = "";
       string loadcipher = "";


        public aesImage()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            disable_all();
        }





        private void button3_Click(object sender, EventArgs e)
        {

        }

        private void button5_Click(object sender, EventArgs e)
        {

            string key = "0F1571C947D9E8590CB7ADD6AF7F6798";//"00112233445566778899AABBCCDDEEFF";//"12345678123456700ABCACBFEABCACBF"; //"0F1571C974D9E8590CB7ADD6AF7F6798";//"000102030405060708090A0B0C0D0E0F";
            string[,] keys = AES_Encryption.startKeyGeneration(key);
            String[] arr = loadImage.Split('-');

            StringBuilder builder = new StringBuilder();
            foreach (string value in arr)
            {
                builder.Append(value);
            }
            builder.ToString();

            //string[] strings = Algorithm.Div_Text(loadImage);
            string[] strings = AES_Encryption.Div_Text(builder.ToString());

            string res_value = "";
            bool input_type = false;//hex
            for (int i = 0; i < strings.Length; i++)
            {
                //res_value += Algorithm.ENCRYPTION(strings[i], keys, input_type);
                res_value += AES_Encryption.ENCRYPTION(strings[i], keys, input_type);
            }
            MessageBox.Show(res_value);


            File.WriteAllText(textBox5.Text, res_value);
            MessageBox.Show("Encryption Done");
            button1.Enabled = true;
        }

        private void button6_Click(object sender, EventArgs e)
        {
            string ciphertext = loadcipher;
            string key = "0F1571C947D9E8590CB7ADD6AF7F6798";//"00112233445566778899AABBCCDDEEFF";//"12345678123456700ABCACBFEABCACBF"; //"0F1571C974D9E8590CB7ADD6AF7F6798";//"000102030405060708090A0B0C0D0E0F";
            string[,] keys = AES_Encryption.startKeyGeneration(key);
            string[] strings = AES_Encryption.Div_Text(ciphertext);
            string res_value = "";
            bool input_type = false;//hex
            //  decrypte el msg
            for (int i = 0; i < strings.Length; i++)
            {
                res_value += AES_Decryption.DECRYPTION(strings[i], keys, input_type);
            }

            byte[] newByte = ToByteArray(res_value);



            pictureBox1.Image = pictureBox1.Image = ImageCrypto.library.ConvertByteToImage(newByte);
            MessageBox.Show("Decryption Done");
            pictureBox1.Image.Save(textBox6.Text, System.Drawing.Imaging.ImageFormat.Jpeg);
            MessageBox.Show("Picture Saved");

        }



        // Function converts hex data into byte array
        public static byte[] ToByteArray(String HexString)
        {
            int NumberChars = HexString.Length;

            byte[] bytes = new byte[NumberChars / 2];

            for (int i = 0; i < NumberChars; i += 2)
            {
                bytes[i / 2] = Convert.ToByte(HexString.Substring(i, 2), 16);
            }
            return bytes;
        }

        // convert string  to byte array
        static byte[] GetBytes(string str)
        {
            byte[] bytes = new byte[str.Length * sizeof(char)];
            System.Buffer.BlockCopy(str.ToCharArray(), 0, bytes, 0, bytes.Length);
            return bytes;
        }



        private void button8_Click(object sender, EventArgs e)
        {
        }

        private void button2_Click(object sender, EventArgs e)
        {
            loadImage = BitConverter.ToString(ImageCrypto.library.ConvertImageToByte(pictureBox1.Image));
            MessageBox.Show("Image Load Successfully");

        }

        private void button4_Click(object sender, EventArgs e)
        {
            SaveFileDialog save1 = new SaveFileDialog();
            save1.Filter = "TEXT|*.txt";
            if (save1.ShowDialog() == DialogResult.OK)
            {
                textBox5.Text = save1.FileName;
                // button5.Enabled = true;
            }
            else
            {
                textBox5.Text = "";
                //button5.Enabled = false;
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            OpenFileDialog open1 = new OpenFileDialog();
            open1.Filter = "JPG|*.JPG";
            if (open1.ShowDialog() == DialogResult.OK)
            {
                textBox1.Text = open1.FileName;
                pictureBox1.Image = Image.FromFile(textBox1.Text);
                button2.Enabled = true;
                FileInfo fi = new FileInfo(textBox1.Text);

                label9.Text = "File Name: " + fi.Name;
                label10.Text = "Image Resolution: " + pictureBox1.Image.PhysicalDimension.Height + " X " + pictureBox1.Image.PhysicalDimension.Width;

                double imageMB = ((fi.Length / 1024f) / 1024f);

                label11.Text = "Image Size: " + imageMB.ToString(".##") + "MB";
            }
            else
            {
                textBox1.Text = "";
                label9.Text = "File Name: ";
                label10.Text = "Image Resolution: ";
                label11.Text = "Image Size: ";


                button2.Enabled = false;

            }
        }

        private void disable_all()
        {

        }
        private void button10_Click(object sender, EventArgs e)
        {
            OpenFileDialog open1 = new OpenFileDialog();
            open1.Filter = "TEXT|*.txt";
            if (open1.ShowDialog() == DialogResult.OK)
            {
                textBox7.Text = open1.FileName;
                button9.Enabled = true;
            }
            else
            {
                textBox7.Text = "";
                button9.Enabled = false;
            }
        }

        private void button9_Click(object sender, EventArgs e)
        {
            loadcipher = File.ReadAllText(textBox7.Text);
            MessageBox.Show("Load Cipher Successfully");

        }

        private void button7_Click(object sender, EventArgs e)
        {
            SaveFileDialog save1 = new SaveFileDialog();
            save1.Filter = "JPG|*.JPG";
            if (save1.ShowDialog() == DialogResult.OK)
            {
                textBox6.Text = save1.FileName;
                button6.Enabled = true;
            }
            else
            {
                textBox6.Text = "";
                // button6.Enabled = false;
            }
        }
    }
}
