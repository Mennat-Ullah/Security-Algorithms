using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Net.Sockets;
using System.Threading;
using System.IO;

namespace Security
{
    public partial class AES_Client : Form
    {

        NetworkStream output_stream;
        BinaryReader reader;
        BinaryWriter writer;
        Thread readthread;
        string message = "";
        string plaintext;
        string Key;
        TcpClient client; // for Sending Data to Server
       // String ServerIP = "127.0.0.1";

        public AES_Client()
        {
            InitializeComponent();
            ThreadStart ts = new ThreadStart(Run_client);
            readthread = new Thread(ts);
            readthread.Start();
        }

        public void Run_client()
        {
            try
            {
                Status.Text = "Connecting";

                // Step 1: Create TCPClient and connect to the Server 
                client = new TcpClient();
                client.Connect("127.0.0.1", 5000); // 5000 is the port number  that the Sever is listening on it 

                // Step 2: Get NetworkStream Associated With TcpClient 
                output_stream = client.GetStream();

                // Step 3: Create Object for Writing and Reading Across Stream( NetworkStream)
                writer = new BinaryWriter(output_stream);
                reader = new BinaryReader(output_stream);
                // output_text.Text += "\r\nGot IO Stream \r\n";
                Status.ReadOnly = false;

                do
                {
                    //Step 3: 
                    try
                    {
                        //Reading the message form Server  
                        message = reader.ReadString();
                        Status.Text = message;
                    }
                    catch (Exception e)
                    {
                        System.Environment.Exit(System.Environment.ExitCode);
                    }
                } while (message != "Server>>terminate");


                // Step 4: Closing Connection 
                writer.Close();
                reader.Close();
                output_stream.Close();
                client.Close();

                Application.Exit();
            }
            catch (SocketException se)
            {
                MessageBox.Show(se.Message);
            }

        }
        public void Send(String CT)
        {
            try
            {

                writer.Write(CT/*Returnes String From Encryption*/); // Send to Sever 

            }
            catch (SocketException se)
            {
                Status.Text = "Error Send";
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (pt.Text == "" || Key == "")
            { MessageBox.Show("PLEASE, Enter Values"); }

            else
            {
                plaintext = pt.Text;
                Key = ki.Text;
                string[,] keys = AES_Encryption.startKeyGeneration(Key);
                string[] strings = AES_Encryption.Div_Text(plaintext);
                string res_value = "";
                bool input_type = false;//hex
                for (int i = 0; i < strings.Length; i++)
                {
                    res_value += AES_Encryption.ENCRYPTION(strings[i], keys, input_type);
                }
               
                ct.Text = res_value;

                Console.WriteLine(res_value.Length);
            }

        }

        private void button2_Click(object sender, EventArgs e)
        {

            if (pt.Text == "" || Key == "")
            { MessageBox.Show("PLEASE, Enter Values"); }

            else
            {
                plaintext = pt.Text;
                Key = ki.Text;

                string[,] keys = AES_Encryption.startKeyGeneration(Key);
                string[] strings = AES_Encryption.Div_Text(plaintext);
                string res_value = "";
                bool input_type = false;//hex
                for (int i = 0; i < strings.Length; i++)
                {
                    res_value += AES_Encryption.ENCRYPTION(strings[i], keys, input_type);
                }

                ct.Text = res_value;
                Send(res_value);
            }




            // 0123456789ABCDEF9876543210FEDCBA70123456789ABCDEF9876543210FEDCB45567879234567890123456789ABCDEF9876543210FEDCBA70123456789ABCDEF9876543210FEDCB4556787923456789
            //  0F1571C947D9E8590CB7ADD6AF7F6798
        }

        private void closed(object sender, FormClosedEventArgs e)
        {
            writer.Close();
            reader.Close();
            output_stream.Close();
            client.Close();
        }
    }
}
