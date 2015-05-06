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
    public partial class rc42 : Form
    {
        bool users;
        List<int> key;
        List<int> S;
        List<int> T;

        NetworkStream output_stream;
        BinaryReader reader;
        BinaryWriter writer;
        Thread readthread;
        string message = "";
        string plaintext;
        string Key;
        TcpClient client; // for Sending Data to Server
        // String ServerIP = "127.0.0.1";

        public rc42()
        {
            InitializeComponent();
            users = true;
            key = new List<int>();
            S = new List<int>();
            T = new List<int>();

            ThreadStart ts = new ThreadStart(Run_client);
            readthread = new Thread(ts);
            readthread.Start();
        }

        public void Run_client()
        {
            try
            {
                
                // Step 1: Create TCPClient and connect to the Server 
                client = new TcpClient();
                client.Connect("127.0.0.1", 5000); // 5000 is the port number  that the Sever is listening on it 

                // Step 2: Get NetworkStream Associated With TcpClient 
                output_stream = client.GetStream();

                // Step 3: Create Object for Writing and Reading Across Stream( NetworkStream)
                writer = new BinaryWriter(output_stream);
                reader = new BinaryReader(output_stream);

                do
                {
                    //Step 3: 
                    try
                    {
                        //Reading the message form Server  
                        message = reader.ReadString();
                        decode();
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
                //Application.Exit();
            }
            catch (SocketException se)
            {
                MessageBox.Show(se.Message);
            }

        }
        public void Send()
        {
            try
            {
                string s = ki.Text + "$" + ct.Text;
                message = ct.Text;
                writer.Write(s); // Send to Sever 
            }
            catch (SocketException se)
            {
                //label5.Text = "Error Send";
            }
        }

        void decode()
        {
            string[] sr = message.Split('$');
            init(sr[0], sr[1].Length);
            message = sr[1];
        }

        //----------- generating binary representation of key ----------//
        void generate_binary(string k)
        {
            for (int i = k.Length - 1; i >= 0; i--)
            {
                int a = 0, c = k[i];
                while (a++ < 8)
                {
                    key.Add(c % 2);
                    c /= 2;
                }
            }
        }

        //--------- key-scheduling algorithm (KSA) -------//
        void KSA(string k)
        {
            for (int i = 0; i < 256; i++)
                S.Add(i);
            int j = 0;
            for (int i = 0; i < 256; i++)
            {
                j = (j + S[i] + k[i % k.Length]) % 256;

                //swaping
                S[i] += S[j];
                S[j] = S[i] - S[j];
                S[i] -= S[j];
            }
        }

        //-------  pseudo-random generation algorithm (PRGA) -----//
        void PRGA(int msgL)
        {
            int i = 0, j = 0;
            for (int k = 0; k < msgL; k++)
            {
                i = (i + 1) % 256;
                j = (j + S[i]) % 256;

                //swaping
                S[i] += S[j];
                S[j] = S[i] - S[j];
                S[i] -= S[j];
                T.Add(S[(S[i] + S[j]) % 256]);
            }
        }

        //-------- initiating the algorithm ----//
        void init(string k, int msgL)
        {
            S.Clear();
            key.Clear();
            T.Clear();
            generate_binary(k);
            KSA(k);
            PRGA(msgL);
        }

        //----- generating output msg -----//
        string getOutput(string msg)
        {
            string O = "";
            for (int i = 0; i < msg.Length; i++)
            {
                int c = msg[i];
                c = (c ^ T[i]);
                O += (char)c;
            }
            return O;
        }

        private void gener(object sender, EventArgs e)
        {
            users = (this.user.Text == "reciever" ? false : true);
            if( users )
            {
                init(ki.Text, pt.Text.Length);
                ct.Text = getOutput(pt.Text);
                Send();
            }
            else
                ct.Text = getOutput(message);
            
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
