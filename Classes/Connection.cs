using System;
using System.Collections.Generic;
using System.Text;
using System.Net;
using System.Net.Sockets;

namespace Talkative
{
    class Connection
    {

        private int _port;

        public Connection() {
            
        }
        
        ~Connection()
        {

        }
		
		public static string MyIP() {
            
			IPHostEntry host;
			string localIP = "?";
			
			host = Dns.GetHostEntry(Dns.GetHostName());
			
			for(int i = 0; i < host.AddressList.GetLength(0); i++)
			{
			    if (host.AddressList[i].AddressFamily == AddressFamily.InterNetwork)
			    {
			        localIP = host.AddressList[i].ToString();
					break;
			    }
			}
			
			return localIP;
			
        }

        public void Listen(int port)
        {
            _port = port;
        }

        public void Send(Message message) { 
            message.Source = MyIP();
			
        }

    }
}
