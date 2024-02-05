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
using System.Collections.Specialized;
using System.Net;
using System.Threading;

namespace CS408Project_Server
{
    public partial class Form1 : Form
    {
        Socket serverSocket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
        OrderedDictionary connectedClients = new OrderedDictionary(); //This will hold the users
        bool terminating = false;
        bool listening = false;
        public Form1()
        {
            Control.CheckForIllegalCrossThreadCalls = false;
            this.FormClosing += new FormClosingEventHandler(Form1_FormClosing);
            InitializeComponent();
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e) //When form is closing 
        {
            listening = false;
            terminating = true;
            Environment.Exit(0);
        }

        private void groupBox4_Enter(object sender, EventArgs e)
        {

        }

        private void richTextBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void labelPort_Click(object sender, EventArgs e)
        {

        }

        private void btnListen_Click(object sender, EventArgs e)
        {
            int serverPort;
            if (Int32.TryParse(txtBoxPort.Text, out serverPort))
            {
                if (1024 > serverPort || serverPort > 65535) //Just to make sure that we do not interrupt some other task
                {
                    logs.AppendText("Please make sure the port number is in the 1024-65535 range.\n");
                    return;
                }
                // Start the server and attach the server socket to it
                IPEndPoint endPoint = new IPEndPoint(IPAddress.Any, serverPort);
                serverSocket.Bind(endPoint);
                serverSocket.Listen(8);
                listening = true;
                btnListen.Enabled = false;
                txtBoxPort.Enabled = false;
                // Start a thread to accept incoming connections
                Thread acceptThread = new Thread(AcceptConnections);
                acceptThread.Start();
                logs.AppendText($"Listening on port: {serverPort}\n");
            }
            else
            {
                logs.AppendText("Please enter a valid port number.\n");
            }
        }

        private void AcceptConnections()
        {
            while (listening)
            {
                try
                {
                    //Get the new client socket, 
                    Socket newClient = serverSocket.Accept();
                    Byte[] getName = new Byte[64];
                    int bytesRead = newClient.Receive(getName);
                    string username = Encoding.Default.GetString(getName, 0, bytesRead).Trim('\0');
                    username = username.ToLower();
                    if (connectedClients.Contains(username))
                    {
                        //Inform the client that this a user with this username is already connected
                        newClient.Send(Encoding.Default.GetBytes("FAILURE"));
                        newClient.Close();
                        logs.AppendText($"Rejected connection because a user with username {username} is already connected.\n");
                    }
                    else
                    {
                        //Inform the client that they've been sucessfully connected, add to the dictionary of users
                        newClient.Send(Encoding.Default.GetBytes("SUCCESS"));
                        logs.AppendText($"{username} connected.\n");
                        User connectingUser = new User(username, newClient);
                        //Add the user to dictinoary with key as is name
                        connectedClients.Add(connectingUser.Username, connectingUser); 
                        RefreshConnectedClients(); //Refresh the RichTextBox
                        Thread receiveThread = new Thread(() => ReceiveMessages(connectingUser)); 
                        receiveThread.Start(); //This thread will receive messages from the new user
                    }
                }
                catch (Exception e)
                {
                    //If the server stops
                    if (terminating)
                    {   listening = false;}
                    else
                    { logs.AppendText($"The listener socket stopped: {e.Message}\n");}
                }
            }
        }

        private void ReceiveMessages(User user){
            bool connected = true;
            while(!terminating && connected)
            {
                try
                {
                    Byte[] msgBuffer = new Byte[64];
                    int bytesRead = user.Socket.Receive(msgBuffer);
                    string incomingMsg = Encoding.Default.GetString(msgBuffer, 0, bytesRead).Trim('\0');
                    if (incomingMsg.Equals("SUBSCRIBE,IF100")) //User requests to subscribe to the IF100 channel
                    {
                        if (!user.isSubscribedToIF100){ //Notify channel subscribers, add the user to the subscribers of IF100, inform the user
                            NotifyAllIF100Subscribers($"IF100,User {user.Username} has subscribed to IF100 channel!\n");
                            user.isSubscribedToIF100 = true;
                            SendMessage(user.Username, "SUBSCRIBE,IF100-OK\n");
                            RefreshChannelSubscribers();
                            logs.AppendText($"{user.Username} subscribed to IF100 channel!\n");


                        }
                        else  //If the user is already subscribed(error case), inform him/her
                        {
                            SendMessage(user.Username, "SUBSCRIBE,IF100-NO\n");
                            logs.AppendText($"User {user.Username} tried to subscribe to IF100 channel, while he was already subscribed.\n");

                        }
                    }
                    else if (incomingMsg.Equals("UNSUBSCRIBE,IF100"))//User requests to unsubscribe from the IF100 channel
                    {
                        if (user.isSubscribedToIF100)//Remove the user from the subscribers of IF100, notify channel subscribers,inform the user
                        {
                            user.isSubscribedToIF100 = false;
                            NotifyAllIF100Subscribers($"IF100,User {user.Username} unsubscribed from IF100 channel!\n");
                            SendMessage(user.Username, "UNSUBSCRIBE,IF100-OK\n");
                            RefreshChannelSubscribers(); //Refresh the RichTextBox
                            logs.AppendText($"{user.Username} unsubscribed from IF100 channel!\n");

                        }
                        else
                        {
                            //If the user is not a subscriber(error case), inform him/her
                            SendMessage(user.Username, "UNSUBSCRIBE,IF100-NO\n");
                            logs.AppendText($"User {user.Username} tried to unsubscribe from IF100 channel, while he was already unsubscribed.\n");

                        }
                    }
                    else if (incomingMsg.Equals("SUBSCRIBE,SPS101"))//User requests to subscribe to the SPS101 channel
                    {
                        if (!user.isSubscribedToSPS101){ //Notify channel subscribers, add the user to the subscribers of IF100, inform the user
                            NotifyAllSPS101Subscribers($"SPS101,User {user.Username} has subscribed to SPS101 channel!\n");
                            user.isSubscribedToSPS101 = true;
                            SendMessage(user.Username, "SUBSCRIBE,SPS101-OK\n");
                            RefreshChannelSubscribers();
                            logs.AppendText($"{user.Username} subscribed to SPS101 channel!\n");


                        }
                        else //If the user is already subscribed(error case), inform him/her
                        {
                            SendMessage(user.Username, "SUBSCRIBE,SPS101-NO\n");
                            logs.AppendText($"User {user.Username} tried to subscribe to SPS101 channel, while he was already subscribed.\n");
                        }
                    }

                    else if (incomingMsg.Equals("UNSUBSCRIBE,SPS101")) //User requests to unsubscribe from the SPS101 channel
                    {
                        if (user.isSubscribedToSPS101) //Remove the user from the subscribers of SPS101, notify channel subscribers,inform the user
                        {
                            user.isSubscribedToSPS101 = false;
                            NotifyAllSPS101Subscribers($"SPS101,User {user.Username} unsubscribed from SPS101 channel!\n");
                            SendMessage(user.Username, "UNSUBSCRIBE,SPS101-OK\n");
                            RefreshChannelSubscribers();
                            logs.AppendText($"{user.Username} unsubscribed from SPS101 channel!\n");
                        }
                        else
                        {
                            //If the user is not a subscriber(error case), inform him/her
                            SendMessage(user.Username, "UNSUBSCRIBE,SPS101-NO\n");
                            logs.AppendText($"User {user.Username} tried to unsubscribe from SPS101 channel, while he was already unsubscribed.\n");

                        }
                    }
                    else if (incomingMsg.StartsWith("IF100,")) //If there is an incoming message in IF100 channel
                    {
                        if (user.isSubscribedToIF100) //If the requester is subscriber (authorization check)
                        {
                            //Send the message to all of the subscribers of the channel
                            StringBuilder sb = new StringBuilder();
                            sb.Append("IF100,");
                            sb.Append($"{user.Username}: ");
                            sb.Append(incomingMsg.Substring(6));
                            sb.Append("\n");
                            NotifyAllIF100Subscribers(sb.ToString());

                            logs.AppendText("Channel " + sb.ToString());
                        }
                        else
                        {
                            //Error case: if the user tries to send a message to a channel that he is not subscribed to (just to make sure), inform the user
                            SendMessage(user.Username, "UNAUTHORIZED-IF100\n");
                            logs.AppendText($"{user.Username} tried to send message to IF100 but was unauthorized.\n");
                        }
                        
                    }
                    else if (incomingMsg.StartsWith("SPS101,")) //If there is an incoming message in IF100 channel
                    {
                        if (user.isSubscribedToSPS101) //If the requester is subscriber (authorization check)
                        {
                            //Send the message to all of the subscribers of the channel
                            StringBuilder sb = new StringBuilder();
                            sb.Append("SPS101,");
                            sb.Append($"{user.Username}: ");
                            sb.Append(incomingMsg.Substring(7));
                            sb.Append("\n");
                            NotifyAllSPS101Subscribers(sb.ToString());
                            logs.AppendText("Channel " + sb.ToString());
                        }
                        else
                        {
                            //Error case: if the user tries to send a message to a channel that he is not subscribed to (just to make sure), inform the user
                            SendMessage(user.Username, "UNAUTHORIZED-SPS101\n");
                            logs.AppendText($"{user.Username} tried to send message to SPS101 but was unauthorized.\n");
                        }

                    }
                    else
                    {
                        //Error Handling: If there is a message that is not expected(just to make sure, we have the check in client side as well)
                        logs.AppendText("UNEXPECTED MESSAGE\n");
                        StringBuilder sb = new StringBuilder();
                        sb.Append(incomingMsg);
                        sb.Append("\n");
                        logs.AppendText(sb.ToString());
                    }

                }
                //Disconnection of client
                catch
                {
                    logs.AppendText($"User {user.Username} tries to disconnect.\n");
                    connected = false;
                    try {
                        string exitingUser = user.Username;
                        user.Socket.Close();
                        connectedClients.Remove(exitingUser); //Remove the user from the list
                        if (user.isSubscribedToIF100) //If the user is in IF100 channel, inform the remaining subscribers that the user has left the channel.
                        {
                            user.isSubscribedToIF100 = false;
                            NotifyAllIF100Subscribers($"IF100,User {user.Username} unsubscribed from IF100 channel!\n");
                            logs.AppendText($"{user.Username} unsubscribed from IF100 channel!\n");

                        }
                        if (user.isSubscribedToSPS101) //If the user is in SPS101 channel, inform the remaining subscribers that the user has left the channel.
                        {
                            user.isSubscribedToSPS101 = false;
                            NotifyAllSPS101Subscribers($"SPS101,User {user.Username} unsubscribed from SPS101 channel!\n");
                            logs.AppendText($"{user.Username} unsubscribed from SPS101 channel!\n");
                        }
                        user = null;
                        RefreshConnectedClients(); //Refresh the clients, and channel subscribers
                        RefreshChannelSubscribers();
                        logs.AppendText($"{exitingUser} disconnected.\n");
                    }
                    catch {
                        logs.AppendText("An error occurred after a client user disconnected.\n");
                    }
                    

                }
            }
        }


        // Function to list all connected users
        private void RefreshConnectedClients()
        {
            connectedCli.Clear();
            StringBuilder sb = new StringBuilder();
            foreach(string username in connectedClients.Keys)
            {
                sb.Append($"- {username}\n");
            }
            connectedCli.AppendText(sb.ToString());
        }


        //To refresh both of the channel's subscribers
        private void RefreshChannelSubscribers()
        {
            if100subs.Clear();
            sps101subs.Clear();

            StringBuilder if100 = new StringBuilder();
            StringBuilder sps101 = new StringBuilder();

            foreach (User user in connectedClients.Values)
            {
                if (user.isSubscribedToIF100)
                {
                    if100.Append($"- {user.Username}\n");
                }
                if(user.isSubscribedToSPS101)
                {
                    sps101.Append($"- {user.Username}\n");
                }
            }
            if100subs.AppendText(if100.ToString());
            sps101subs.AppendText(sps101.ToString());
        }

        //Send a message to a spesific client user
        private void SendMessage(string username, string message)
        {
            try
            {
                Byte[] buffer = Encoding.Default.GetBytes(message);
                ((User)connectedClients[username]).Socket.Send(buffer);
            }
            catch
            {
                logs.AppendText($"Error occurred when sending a message to user: {username}\n");
            }
        }

        // To notify all users
        private void NotifyAllUsers(string message)
        {
            foreach(string username in connectedClients.Keys)
            {
                SendMessage(username, message);
            }
        }

        //To notify all IF100 subscribers, if the connected client is subscribed, inform them
        private void NotifyAllIF100Subscribers(string message)
        {
            foreach (User user in connectedClients.Values)

                if (user.isSubscribedToIF100)
                {
                    SendMessage(user.Username, message);
                }
        }

        //To notify all SPS101 subscribers, if the connected client is subscribed, inform them
        private void NotifyAllSPS101Subscribers(string message)
        {
            foreach (User user in connectedClients.Values)

                if (user.isSubscribedToSPS101)
                {
                    SendMessage(user.Username, message);
                }
        }


        private void connectedCli_TextChanged(object sender, EventArgs e)
            {

            }
    }
}
