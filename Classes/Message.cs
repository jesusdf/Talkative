using System;
using System.Collections.Generic;
using System.Text;

namespace Talkative
{
    class Message
    {
		
		#region Enumeraciones
		
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
