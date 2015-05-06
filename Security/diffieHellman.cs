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
    public partial class diffieHellman : Form
    {
        Socket connection; //Socket is used to Link  Transport layer(TCPlistener OR TCPClient) With Network layer(NetworkStream)  
        Thread read_thread; // to Run this Connection With anthor processes 
        NetworkStream socket_stream; // Encapsulate object from Socket Class(Connection) 
        BinaryReader reader; // Encapsulate object from Networkstream(socket_stream)  and  Reading from Network  
        // String ciphertext;
        string theReply = "";
        BinaryWriter writer; // Encapsulate object from Networkstream(socket_stream)  and  Writing on Network 



        helperFunc hf;
        long p, bas, pvtK, shared_ki;
        public diffieHellman()
        {
            InitializeComponent();
            hf = new helperFunc();

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

                    label4.Text = "Connected";

                    // inform client that connection was successfull  ; Writin in the Stream (Network)

                    writer.Write("Connected");



                    // Step 9: read String data sent from client 
                    do
                    {
                        try
                        {
                            // read the string sent to the server  
                            theReply = reader.ReadString(); // Reading from Network
                            // ciphertext = theReply;
                       //     MessageBox.Show(theReply);
                            //    MessageBox.Show(My_Key.Text);
                        }

                        // handle exception if error reading data
                        catch (Exception)
                        {
                            break;
                        }

                    } while ((theReply != "Client>>terminate") && (connection.Connected)); // important

                    label4.Text += "\r\nUser terminated connection";

                    // Step 10: close connection

                    writer.Close();

                    reader.Close();

                    socket_stream.Close();

                    connection.Close();

                    

                    Application.Exit();
                }
            } // end try

            catch (Exception error)
            {
                MessageBox.Show(error.ToString());
            }

        }

        long pow( long b, long pw)
        {
            if ( pw == 0)
                return 1;
            long res = pow(b, pw / 2);
            res = (res * res) % p;
            if (pw % 2 == 1)
                res = (res * b) % p;
            return res;
        }

        private void label1_Click(object sender, EventArgs e)
        {
        }

        private void send(object sender, EventArgs e)
        {
            Send();
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
        private void generate(object sender, EventArgs e)
        {
            long num = Int64.Parse(theReply);
            shared_ki = pow(num, pvtK);
            sh_ki.Text = shared_ki.ToString();
        }

        private void diffieHellman_Load(object sender, EventArgs e)
        {

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
