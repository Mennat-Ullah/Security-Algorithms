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
    public partial class rc4 : Form
    {
        bool users;
        List<int> key;
        List<int> S;
        List<int> T;

        Socket connection; //Socket is used to Link  Transport layer(TCPlistener OR TCPClient) With Network layer(NetworkStream)  
        Thread read_thread; // to Run this Connection With anthor processes 
        NetworkStream socket_stream; // Encapsulate object from Socket Class(Connection) 
        BinaryReader reader; // Encapsulate object from Networkstream(socket_stream)  and  Reading from Network  
        string theReply = "";
        BinaryWriter writer; // Encapsulate object from Networkstream(socket_stream)  and  Writing on Network 

        public rc4()
        {
            InitializeComponent();
            users = true;
            key = new List<int>();
            S = new List<int>();
            T = new List<int>();

            ThreadStart ts = new ThreadStart(Run_Server);
            read_thread = new Thread(ts);
            read_thread.Start();
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
                            decode();
                        }

                        // handle exception if error reading data
                        catch (Exception)
                        {
                            break;
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

        public void Send()
        {
            try
            {
                string s = ki.Text + "$" + ct.Text;
                theReply = ct.Text;
                writer.Write(s); // Send to Sever 
            }
            catch (SocketException se)
            {
                //label5.Text = "Error Send";
            }
        }

        void decode()
        {
            string[] sr = theReply.Split('$');
            init(sr[0], sr[1].Length);
            theReply = sr[1];
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
            if (users)
            {
                init(ki.Text, pt.Text.Length);
                ct.Text = getOutput(pt.Text);
                Send();
            }
            else
                ct.Text = getOutput(theReply);
        }

        private void closed(object sender, FormClosedEventArgs e)
        {
            writer.Close();
            reader.Close();
            socket_stream.Close();
            connection.Close();
        }
    }
}
