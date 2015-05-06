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
    public partial class diffieHellman2 : Form
    {

        NetworkStream output_stream;
        BinaryReader reader;
        BinaryWriter writer;
        Thread readthread;
        string message = "";

        TcpClient client; // for Sending Data to Server
      

        helperFunc hf;
        long p, bas, pvtK, shared_ki;

        public diffieHellman2()
        {
            InitializeComponent();
            hf = new helperFunc();

            ThreadStart ts = new ThreadStart(Run_client);
            readthread = new Thread(ts);
            readthread.Start();
        }

        long pow(long b, long pw)
        {
            if (pw == 0)
                return 1;
            long res = pow(b, pw / 2);
            res = (res * res) % p;
            if (pw % 2 == 1)
                res = (res * b) % p;
            return res;
        }

        public void Send()
        {
            try
            {
                p = Int64.Parse(prim.Text);
                bas = Int64.Parse(bs.Text);
                pvtK = Int64.Parse(p_ki.Text);
                //hf.sendFile(pow(bas, pvtK).ToString());
                writer.Write(pow(bas, pvtK).ToString()); // Send to Sever 

            }
            catch (SocketException se)
            {
                //Status.Text = "Error Send";
            }
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
        private void diffieHellman2_Load(object sender, EventArgs e)
        {

        }

        private void snd_Click(object sender, EventArgs e)
        {
            Send();
        }

        private void generate(object sender, EventArgs e)
        {
            long num = Int64.Parse(message);
            shared_ki = pow(num, pvtK);
            sh_ki.Text = shared_ki.ToString();
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
