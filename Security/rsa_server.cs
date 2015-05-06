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
    public partial class rsa_server : Form
    {
        Socket connection; //Socket is used to Link  Transport layer(TCPlistener OR TCPClient) With Network layer(NetworkStream)  
        Thread read_thread; // to Run this Connection With anthor processes 
        NetworkStream socket_stream; // Encapsulate object from Socket Class(Connection) 
        BinaryReader reader; // Encapsulate object from Networkstream(socket_stream)  and  Reading from Network  
        string theReply = "";
        BinaryWriter writer; // Encapsulate object from Networkstream(socket_stream)  and  Writing on Network 
        rsa_c rsa_algo;

       
        long p, q, e, n, Fn;
        long[] CipherText;

        public rsa_server()
        {
            InitializeComponent();
            rsa_algo = new rsa_c();

            ThreadStart server = new ThreadStart(Run_Server);
            read_thread = new Thread(server);
            read_thread.Start();
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
                //Status.Text = "Error Send";
            }
        }

        public void Run_Server()
        {
            TcpListener Tcp_listener;
            // wait for a client connection and display the text 
            // that the client sends 
            try
            {
                // Step 1: create TcpListener 
                Tcp_listener = new TcpListener(5000);

                // Step 2: TcpListener waits for connection request 
                Tcp_listener.Start(); // Start listening  for incomming connection Requests

                // Step 3: establish connection upon client request 
                while (true)
                {
                    // label1.Text = "Waiting.....";

                    // accept an incoming connection ; Step 5
                    connection = Tcp_listener.AcceptSocket(); // Socket Class in Encapsulates TCPlistener Class

                    // create NetworkStream object associated with socket ; step 6
                    socket_stream = new NetworkStream(connection);// NetworkStream Class in Encapsulates Socket Class

                    // create objects for transferring data across stream  Step 7 & 8
                    writer = new BinaryWriter(socket_stream);

                    reader = new BinaryReader(socket_stream);

                    // Step 9: read String data sent from client 
                    do
                    {
                        try
                        {
                            // read the string sent to the server  
                            theReply = reader.ReadString(); // Reading from Network
                            if (theReply.Length > 0)
                                decode(theReply);
                        }

                        // handle exception if error reading data
                        catch (Exception)
                        {
                           // break;
                        }

                    } while ((theReply != "Client>>terminate") && (connection.Connected)); // important

                    // Step 10: close connection

                    writer.Close();
                    reader.Close();
                    socket_stream.Close();
                    connection.Close();
                    //Application.Exit();
                }
            } // end try

            catch (Exception error)
            {
                MessageBox.Show(error.ToString());
            }

        }

        private void closed(object sender, FormClosedEventArgs e)
        {
            writer.Close();
            reader.Close();
            socket_stream.Close();
            connection.Close();
        }

        string gen_str()
        {
            string s = "";
            for (int i = 0; i < CipherText.Length ; i++)
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
                CipherText = rsa_algo.alphanumeric(p_ki.Text, e, n); // i think plaint text here wrong
                output_val.Text = gen_str();
                Send();
            }
        }
    }
}
