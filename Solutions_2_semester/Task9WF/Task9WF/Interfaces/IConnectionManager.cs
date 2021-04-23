﻿using System;
using System.Net;
using System.Net.Sockets;

namespace Task9WF.Interfaces
{
	public interface IConnectionManager
	{
		event EventHandler<string> NewMessage;
		event EventHandler<string> SystemMessage;
		event EventHandler<string> ChangeConnection;

		TaskManager TaskManager { set; }
		Info MyInfo { set; }
		IMessager Messager { set; }
		string Name { get; set; }
		bool Started { get; }

		void Start();
		void AddConnection(object sender, Socket socket);
		string TryConnect(string address, int port);
		string TryConnect(EndPoint endPoint);
		void SendToAll(MessageType type, string message);
		void Stop();
	}
}
