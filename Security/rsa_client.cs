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
    public partial class rsa_client : Form
    {
        NetworkStream output_stream;
        BinaryReader reader;
        BinaryWriter writer;
        Thread readthread;
        string message = "";
        TcpClient client; // for Sending Data to Server
        long p, q, e, n, Fn;
        long[] CipherText;
        rsa_c rsa_algo;
        public rsa_client()
        {
            InitializeComponent();
            rsa_algo = new rsa_c();
           
            ThreadStart client_thread = new ThreadStart(Run_client);
            readthread = new Thread(client_thread);
            readthread.Start();
        }

        void decode(string msg)
        {
            string[] sr = msg.Split(' ');
            CipherText = new long[sr.Length - 3];
            Fn = long.Parse(sr[0]); e = long.Parse(sr[1]); n = long.Parse(sr[2]);
            for (int i = 3; i < sr.Length; i++)
                CipherText[i - 3] = long.Parse(sr[i]);
            E.Text = sr[1];
            p_ki.Text = gen_str();
        }

        public void Send()
        {
            try
            {
                string s = Fn.ToString() + " " + e.ToString() + " " + n.ToString() + " " + gen_str();
                writer.Write(s); // Send to Sever 
            }
            catch (SocketException se)
            {
                MessageBox.Show("Error Send");
            }
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
                        if (message.Length > 0)
                            decode(message);
                    }
                    catch (Exception e)
                    {
                       // System.Environment.Exit(System.Environment.ExitCode);
                    }
                } while (message != "Server>>terminate");


                // Step 4: Closing Connection 
                writer.Close();
                reader.Close();
                output_stream.Close();
                client.Close();
               // Application.Exit();
            }
            catch (SocketException se)
            {
                MessageBox.Show(se.Message);
            }

        }

        private void closed(object sender, FormClosedEventArgs e)
        {
            writer.Close();
            reader.Close();
            output_stream.Close();
            client.Close();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        string gen_str()
        {
            string s = "";
            for (int i = 0; i < CipherText.Length ; i++ )
            {
                s += CipherText[i].ToString();
                s += " ";
            }
                return s;
        }

        private void generate(object sender, EventArgs en)
        {
            if (user.Text == "reciever")
            {
                string Decryption_plaintext = "";
                long d = rsa_algo.Multiplicative_Invese(Fn, e);
                Decryption_plaintext = rsa_algo.Dencryption(d, n, CipherText);
                p_ki.Text = gen_str();
                output_val.Text = Decryption_plaintext;
            }
            else
            {
                p = long.Parse(P.Text);
                q = long.Parse(Q.Text);
                e = long.Parse(E.Text);
                n = p * q;
                Fn = (p - 1) * (q - 1);
                CipherText = new long[p_ki.Text.Length];
                CipherText = rsa_algo.alphanumeric(p_ki.Text, e, n);
                string s = output_val.Text = gen_str();
                Send();
            }
        }

        private void user_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

    }
}
