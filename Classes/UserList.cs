using System;
using System.Collections.Generic;
using System.Text;

namespace Talkative
{
    class UserList : System.Collections.Specialized.NameObjectCollectionBase
    {

        #region Constantes
        
        public const string ALL_USERS = "[ALL]";

        #endregion

        #region Variables

		private Connection _conn;
        private List<User> _users;

        #endregion
		
		public UserList(Connection c)
		{
			_conn = c;
			_users = new List<User>();			
		}
		
		~UserList()
		{
			this.BroadcastMessage(new Message(Message.MessageTypes.Notify, Config.MyName() + " - Bye bye..."));
		}

        public void Add(string Key, User User)
        {
            base.BaseAdd(Key, User);
        }

        public List<User> GetUserList() {
            return _users;
        }

        public User SearchUser(string name)
        {
            User uFound = null;
            int i = 0;

            for (User u = _users[i]; i < _users.Count; u = _users[i++])
            {
                if (u.Name.ToUpper().Equals(name.ToUpper())) {
                    uFound = u;
                    break;
                }
            }
            
            return uFound;

        }

        public User SearchIP(string IP) {
            User uFound = null;
            int i = 0;

            for (User u = _users[i]; i < _users.Count; u = _users[i++])
            {
                if (u.IP.Equals(IP))
                {
                    uFound = u;
                    break;
                }
            }

            return uFound;

        }

        public void ReloadUserList()
        {
			for(int i = _users.Count - 1; i >= 0; i--)
			{
				_users.Remove(_users[i]);
			}
            _users.Add(new User(ALL_USERS, null));
            _users.AddRange((new Config()).GetUserList());
        }

        public void SendMessage(User user, Message message)
        {
            if (user.Name == ALL_USERS)
            {
                this.BroadcastMessage(message);
            }
            else
            {
				message.Destination = user.IP;
				message.Nick = Config.MyName();
				message.IsBroadcast = false;
                _conn.Send(message);
            }
        }

        private void BroadcastMessage(Message message)
        {
            foreach (User u in _users)
            {
				message.Destination = u.IP;
				message.Nick = Config.MyName();
				message.IsBroadcast = true;
                _conn.Send(message);
            }
        }

    }
}
