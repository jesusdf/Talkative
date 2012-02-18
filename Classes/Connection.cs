// Talkative#
// Copyright (C) 2012 Jesús Diéguez Fernández
// This program is free software; you can redistribute it and/or modify it under the terms of the GNU General Public License as published by the Free Software Foundation; either version 3 of the License, or (at your option) any later version.
// This program is distributed in the hope that it will be useful, but WITHOUT ANY WARRANTY; without even the implied warranty of MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE. See the GNU General Public License for more details. You should have received a copy of the GNU General Public License along with this program; if not, write to the Free Software Foundation, Inc., 59 Temple Place, Suite 330, Boston, MA 02111-1307 USA or see http://www.gnu.org/licenses/.

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
        
        ~Connection ()
		{

		}
		
		/// <summary>
		/// Returns the host's IP.
		/// </summary>
		/// <remarks>
		/// It looks for the first Adapter that has an internal network IP.
		/// </remarks>
		public static string MyIP ()
		{
            
			IPHostEntry host;
			string localIP = "?";
			
			host = Dns.GetHostEntry (Dns.GetHostName ());
			
			for (int i = 0; i < host.AddressList.GetLength(0); i++) {
				if (host.AddressList [i].AddressFamily == AddressFamily.InterNetwork) {
					localIP = host.AddressList [i].ToString ();
					break;
				}
			}
			
			return localIP;
			
		}
		
		/// <summary>
		/// Begins listening at the specified port.
		/// </summary>
		/// <remarks>
		/// This way we can use alternate ports based on needs.
		/// </remarks>
        public void Listen (int port)
		{
			_port = port;
		}
		
		/// <summary>
		/// Sends a message to a destination.
		/// </summary>
		/// <remarks>
		/// It uses a Message class to describe all the information sent.
		/// </remarks>
        public void Send(Message message) { 
            message.Source = MyIP();
			
        }

    }
}
