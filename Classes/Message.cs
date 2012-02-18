// Talkative#
// Copyright (C) 2012 Jesús Diéguez Fernández
// This program is free software; you can redistribute it and/or modify it under the terms of the GNU General Public License as published by the Free Software Foundation; either version 3 of the License, or (at your option) any later version.
// This program is distributed in the hope that it will be useful, but WITHOUT ANY WARRANTY; without even the implied warranty of MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE. See the GNU General Public License for more details. You should have received a copy of the GNU General Public License along with this program; if not, write to the Free Software Foundation, Inc., 59 Temple Place, Suite 330, Boston, MA 02111-1307 USA or see http://www.gnu.org/licenses/.

using System;
using System.Collections.Generic;
using System.Text;

namespace Talkative
{
    class Message
    {
		
		#region Enumerations
		
		public enum MessageTypes
		{
			Ping = 0,
			Warning,
			Notify,
			Talk
		}
		
		#endregion
		
		#region Variables
		
		private string _source;
		private string _destination;
		private MessageTypes _messageType;
		private string _nick;
		private string _information;
		private bool _isBroadcast;
		
		#endregion
		
        public Message() {
            InitData(string.Empty, string.Empty, MessageTypes.Ping, string.Empty, string.Empty, false);
        }
		
		public Message(string information) {
            InitData(string.Empty, string.Empty, MessageTypes.Talk, string.Empty, string.Empty, false);
        }
		
		public Message(MessageTypes messageType, string information) {
            InitData(string.Empty, string.Empty, messageType, string.Empty, information, false);
        }
		
		public Message(string source, string destination, MessageTypes messageType, string nick, string information, bool isBroadcast)
		{
			InitData(source, destination, messageType, nick, information, isBroadcast);
		}
		
		private void InitData(string source, string destination, MessageTypes messageType, string nick, string information, bool isBroadcast)
		{
			_source = source;
			_destination = destination;
			_messageType = messageType;
			_nick = nick;
			_information = information;
			_isBroadcast = isBroadcast;
		}
		
		public string Source
        {
            get
            {
                return _source;
            }
            set
            {
                _source = Source;
            }
        }
		
		public string Destination
        {
            get
            {
                return _destination;
            }
            set
            {
                _destination = Destination;
            }
        }
		
		public string Nick
        {
            get
            {
                return _nick;
            }
            set
            {
                _nick = Nick;
            }
        }
		
		public string Information
        {
            get
            {
                return _information;
            }
            set
            {
                _information = Information;
            }
        }
		
		public bool IsBroadcast
        {
            get
            {
                return _isBroadcast;
            }
            set
            {
                _isBroadcast = IsBroadcast;
            }
        }
		
    }
}
