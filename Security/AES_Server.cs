using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using System.Net.Sockets;
using System.Threading;

namespace Security
{
    public partial class AES_Server : Form
    {

        Socket connection; //Socket is used to Link  Transport layer(TCPlistener OR TCPClient) With Network layer(NetworkStream)  
        Thread read_thread; // to Run this Connection With anthor processes 
        NetworkStream socket_stream; // Encapsulate object from Socket Class(Connection) 
        BinaryReader reader; // Encapsulate object from Networkstream(socket_stream)  and  Reading from Network  
        // String ciphertext;
        string theReply = "";
        BinaryWriter writer; // Encapsulate object from Networkstream(socket_stream)  and  Writing on Network 
        public AES_Server()
        {
            InitializeComponent();

            ThreadStart ts = new ThreadStart(Run_Server);
            read_thread = new Thread(ts);
            read_thread.Start();
        }

        public void Run_Server()
        {
            TcpListener Tcp_listener;
            int counter = 1;


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
                            MessageBox.Show(theReply);
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

                    ++counter;

                    Application.Exit();
                }
            } // end try

            catch (Exception error)
            {
                MessageBox.Show(error.ToString());
            }

        }
        private void button1_Click(object sender, EventArgs e)
        {
            if (textBox1.Text == "")
            { MessageBox.Show("PLEASE, Enter Values"); }

            else
            {
                // string ciphertext = "3DC07FA9A125D0466AD57168BE7DCA3C3DC07FA9A125D0466AD57168BE7DCA3C3DC07FA9A125D0466AD57168BE7DCA3C3DC07FA9A125D0466AD57168BE7DCA3C3DC07FA9A125D0466AD57168BE7DCA3C";
                string ciphertext = theReply;
                //string key = "0F1571C947D9E8590CB7ADD6AF7F6798";
                string key = textBox1.Text;

                string[,] keys = AES_Decryption.startKeyGeneration(key);
                string[] strings = AES_Decryption.Div_Text(ciphertext);
                string res_value = "";
                bool input_type = false;//hex
                for (int i = 0; i < strings.Length; i++)
                {
                    res_value += AES_Decryption.DECRYPTION(strings[i], keys, input_type);
                }
                MessageBox.Show(res_value);
                textBox2.Text = res_value;
            }

        }

        private void label1_Click(object sender, EventArgs e)
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
