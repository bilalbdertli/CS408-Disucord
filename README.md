# Disucord - Network

Term project for CS408 - Computer Networks Course.

## Introduction
- This project implements a simple client-server architecture for a communication app similar to Discord
- The server module listens the connection requests of clients from a predetermined port.
- The client module connects to the server and sends text messages to subscribed channels.

## Details
- Disucord supports text messaging across two channels named IF100 and SPS101, allowing clients subscribed to a common channel to communicate in real-time.
- Once a client is connected to the server, it can subscribe to two channels named IF100 and SPS101.
- Clients in the same channel can send messages to the channel and receive other clients' messages.
- If a client is not subscribed to a channel, it cannot see the messages that are sent to that channel.
- The server can see which clients are connected, which channels they are subscribed to, and which messages are sent by which clients to which channels.

## Installation
- Download and install the .NET Framework Runtime
- Download the server and client modules

## Objectives
- Learn the basics of socket programming.
- Learn the basics of C# and the .NET Framework.
- Learn the basics of GUI programming with Windows Forms.

## Usage
1. Launch the server module, enter a valid port number and click Listen button.
2. Launch the client module, choose a username and connect to the server by entering the IP address and port of the server.
3. Once a client has connected, it can subscribe to the channels, send messages to channels, and unsubscribe.
4. The server can see all connection, subscription and message actions through its user interface. 
