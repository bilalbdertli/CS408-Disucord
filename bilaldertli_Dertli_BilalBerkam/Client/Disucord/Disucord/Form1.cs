using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Disucord
{
    public partial class Form1 : Form
    {
        bool terminating = false; //check for termination true if terminating, false otherwise
        bool connected = false;   //check for connection, true if connection established false otherwise
        Socket clientSocket;

        public Form1()
        {
            Control.CheckForIllegalCrossThreadCalls = false;
            this.FormClosing += new FormClosingEventHandler(Form1_FormClosing);
            InitializeComponent();
        }

        private void button_connect_Click(object sender, EventArgs e) // clicked to connect button
        {
            if (button_connect.Text == "Connect") // connect
            {
                //initialize the socket
                clientSocket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);

                //get ip and port, then try to connect to the server
                string IP = textBox_IP.Text;
                string Username = textBox_Username.Text;
                string PortText = textBox_Port.Text;

                //check whether client enter ip,username, and portText
                if (IP == "" || PortText == "" || Username == "")
                {
                    if(IP == "")
                    {
                        logs_status.AppendText("Please enter an IP address!\n");
                    }
                    if(PortText == "")
                    {
                        logs_status.AppendText("Please enter a port number!\n");
                    }
                    if(Username == "")
                    {
                        logs_status.AppendText("Please enter a username!\n");
                    }
                }
                else
                {
                    int Port;
                    if (Int32.TryParse(PortText, out Port))
                    {
                        // try to connect

                        try
                        {
                            clientSocket.Connect(IP, Port); //connect to the server
                            connected = true; // can receive messages
                            logs_status.AppendText("Connecting to the server...\n");
                            //send username, server checks whether client with that username exists or not
                            Byte[] buffer = Encoding.Default.GetBytes(Username);
                            clientSocket.Send(buffer);

                            Byte[] receive_buffer = new Byte[1024];
                            clientSocket.Receive(receive_buffer);
                            string verification = Encoding.Default.GetString(receive_buffer);
                            verification = verification.Substring(0, verification.IndexOf("\0"));

                            if (verification == "SUCCESS")
                            {
                                //successfull connection        
                                logs_status.AppendText("Successfully connected to the server!\n");
                                button_connect.Text = "Disconnect";
                                //disable IP, Port, and username
                                textBox_IP.Enabled = false;
                                textBox_Port.Enabled = false;
                                textBox_Username.Enabled = false;

                                //format subscribe buttons  
                                if (button_IF100.Text == "Unsubscribe IF 100")
                                {
                                    button_IF100.Text = "Subscribe IF 100";
                                }
                                if (button_SPS101.Text == "Unsubscribe SPS 101")
                                {
                                    button_SPS101.Text = "Subscribe SPS 101";
                                }


                                groupBox_IF100.Visible = true;
                                groupBox_SPS101.Visible = true;

                                //receive messages from server 
                                Thread receiveThread = new Thread(Receive);
                                receiveThread.Start();


                            }
                            else if (verification == "FAILURE")
                            {
                                //unsuccessfull connection
                                logs_status.AppendText("Could not connect to the server!\nClient with that username has already connected to the server!\n");
                                clientSocket.Close();
                                connected = false;

                            }


                        }
                        catch
                        {
                            //display error message
                            logs_status.AppendText("Could not connect to the server!\n");

                        }


                    }
                    else
                    {
                        //display error message invalid port num
                        logs_status.AppendText("Invalid port num! Please check your port number..\n");

                    }

                }                
            }
            else // disconnect
            {
                connected = false;
                clientSocket.Close();
                button_connect.Text = "Connect";
                //enable IP, Port, and username
                textBox_IP.Enabled = true;
                textBox_Port.Enabled = true;
                textBox_Username.Enabled = true;



                //change visibilities
                groupBox_IF100.Visible = false;
                groupBox_SPS101.Visible = false;
                // clear displays
                logs_IF100.Clear();
                logs_SPS101.Clear();
                logs_status.Clear();
                textBox_composeIF100.Clear();
                textBox_composeSPS101.Clear();
                button_IF100.Text = "Subscribe IF 100";
                //disable messaging
                textBox_composeIF100.Enabled = false;
                button_sendmsgIF100.Enabled = false;
                button_SPS101.Text = "Subscribe SPS 101";
                //disable messaging
                button_sendmsgSPS101.Enabled = false;
                textBox_composeSPS101.Enabled = false;
                logs_status.AppendText("Disconnected from the server!\n");

            }
        }
            

        private void Receive()
        {
            while (connected) // receive message while connected
            {
                try
                {
                    // get the incoming message
                    Byte[] buffer = new Byte[1024];
                    clientSocket.Receive(buffer);

                    string incomingMessage = Encoding.Default.GetString(buffer);
                    incomingMessage = incomingMessage.Substring(0, incomingMessage.IndexOf("\0"));


                    // parse the message to get command and message
                    int indexOfFirstComma = incomingMessage.IndexOf(',');
                    string command = incomingMessage.Substring(0, indexOfFirstComma);
                    string message = incomingMessage.Substring(indexOfFirstComma + 1);

                    if (command == "SUBSCRIBE")
                    {
                        if (message == "IF100-OK\n")
                        {
                            logs_status.AppendText("Channel IF 100 is subscribed!\n");
                            logs_IF100.AppendText("Welcome to IF 100 Channel!\n");
                            button_IF100.Text = "Unsubscribe IF 100";

                            //enable messaging
                            textBox_composeIF100.Enabled = true;
                            button_sendmsgIF100.Enabled = true;

                        }
                        else if (message == "IF100-NO\n")
                        {
                            //display failure message
                            logs_status.AppendText("Could not subscribe channel IF 100!");

                        }
                        else if (message == "SPS101-OK\n")
                        {
                            logs_status.AppendText("Channel SPS 101 is subscribed!\n");
                            logs_SPS101.AppendText("Welcome to SPS 101 Channel!\n");
                            button_SPS101.Text = "Unsubscribe SPS 101";

                            //enable messaging    
                            textBox_composeSPS101.Enabled = true;
                            button_sendmsgSPS101.Enabled = true;

                        }
                        else //if message is SPS101-NO (there is no option)
                        {
                            //display failure message
                            logs_status.AppendText("Could not subscribe channel SPS 101!");
                        }

                    }
                    else if (command == "UNSUBSCRIBE")
                    {
                        if (message == "IF100-OK\n")
                        {
                            // display unsubs message
                            logs_status.AppendText("Channel IF 100 is unsubscribed!\n");
                            logs_IF100.AppendText("See you later!\n");
                            button_IF100.Text = "Subscribe IF 100";

                            //disable messaging
                            textBox_composeIF100.Enabled = false;
                            button_sendmsgIF100.Enabled = false;

                            logs_IF100.Clear();
                            textBox_composeIF100.Clear();
                        }
                        else if (message == "IF100-NO\n")
                        {
                            //display failure message
                            logs_status.AppendText("Could not unsubscribe channel IF 100!\n");

                        }
                        else if (message == "SPS101-OK\n")
                        {
                            //display unsubs message
                            logs_status.AppendText("Channel SPS 101 is unsubscribed!\n");
                            logs_SPS101.AppendText("See you later!\n");
                            button_SPS101.Text = "Subscribe SPS 101";

                            //disable messaging
                            button_sendmsgSPS101.Enabled = false;
                            textBox_composeSPS101.Enabled = false;

                            logs_SPS101.Clear();
                            textBox_composeSPS101.Clear();

                        }
                        else //if message is SPS101-NO (there is no option)
                        {
                            //display failure message
                            logs_status.AppendText("Could not unsubscribe channel SPS 101!\n");

                        }

                    } 
                    else if (command == "IF100")
                    {
                        //display the message or error (no difference)
                        logs_status.AppendText("Got message from the IF 100 channel!\n");
                        logs_IF100.AppendText(message);
                    
                    }
                    else // if command is SPS 101 (no other command)
                    {
                        logs_status.AppendText("Got message from the SPS 101 channel!\n");
                        logs_SPS101.AppendText(message);
                    }

                    

                }
                catch
                {
                    if (connected) //if cannot receive message and not terminating, then display server is disconnected
                    {                        
                        button_connect.Text = "Connect";
                        //enable IP, Port, and username
                        textBox_IP.Enabled = true;
                        textBox_Port.Enabled = true;
                        textBox_Username.Enabled = true;
                        //change visibility of channels
                        groupBox_IF100.Visible = false;
                        groupBox_SPS101.Visible = false;

                        //clear display screens
                        logs_IF100.Clear();
                        logs_SPS101.Clear();
                        logs_status.Clear();
                        textBox_composeIF100.Clear();
                        textBox_composeSPS101.Clear();
                        //show message after cleared the status screen 
                        logs_status.AppendText("The server has disconnected!\n");

                    }
                    //close the socket and terminate
                    clientSocket.Close();
                    connected = false;

                }
            }
        }


        private void button_IF100_Click(object sender, EventArgs e) // clicked to subscribe IF 100 button
        {
            if(button_IF100.Text == "Subscribe IF 100")
            {
                // send subs message to server
                string message = "SUBSCRIBE,IF100";
                Byte[] buffer = Encoding.Default.GetBytes(message);
                clientSocket.Send(buffer);

            }
            else
            {
                //send unsubs message to server
                string message = "UNSUBSCRIBE,IF100";
                Byte[] buffer = Encoding.Default.GetBytes(message);
                clientSocket.Send(buffer);

            }
            
        }

        private void button_SPS101_Click(object sender, EventArgs e) // clicked to subscribe SPS 101 button
        {
            if (button_SPS101.Text == "Subscribe SPS 101")
            {
                // send subs message to server
                string message = "SUBSCRIBE,SPS101";
                Byte[] buffer = Encoding.Default.GetBytes(message);
                clientSocket.Send(buffer);

            }
            else
            {
                //send the unsubs message to server
                string message = "UNSUBSCRIBE,SPS101";
                Byte[] buffer = Encoding.Default.GetBytes(message);
                clientSocket.Send(buffer); 

            }
            
        }

        private void button_sendmsgIF100_Click(object sender, EventArgs e)  //clicked to send message to IF 100 button
        {

            //send clients message for IF 100 channel to the server
            string incoming = textBox_composeIF100.Text;
            //check whether the message is empty or not
            if(incoming == "")
            {
                logs_status.AppendText("Please write your message to send IF 100 Channel!\n");
            }
            else
            {
                textBox_composeIF100.Clear();
                string message = "IF100," + incoming;
                Byte[] buffer = Encoding.Default.GetBytes(message);
                clientSocket.Send(buffer);
                logs_status.AppendText("Your message sent to the IF 100 Channel!\n");

            }

        }

        private void button_sendmsgSPS101_Click(object sender, EventArgs e)  //clicked to send message to SPS 101 button
        {
            //send clients message for SPS 101 channel to the server 
            string incoming = textBox_composeSPS101.Text;
            //check whether the message is empty or not
            if (incoming == "")
            {
                logs_status.AppendText("Please write your message to send SPS 101 Channel!\n");
            }
            else
            {
                textBox_composeSPS101.Clear();
                string message = "SPS101," + incoming;
                Byte[] buffer = Encoding.Default.GetBytes(message);
                clientSocket.Send(buffer);
                logs_status.AppendText("Your message sent to the SPS 101 Channel!\n");
            }           
        }

        private void Form1_FormClosing(object sender, System.ComponentModel.CancelEventArgs e) //arrange closing events (when closing)
        {
            connected = false;
            terminating = true;
            Environment.Exit(0);
        }

    }
}
