// Talkative#
// Copyright (C) 2012 Jesús Diéguez Fernández
// This program is free software; you can redistribute it and/or modify it under the terms of the GNU General Public License as published by the Free Software Foundation; either version 3 of the License, or (at your option) any later version.
// This program is distributed in the hope that it will be useful, but WITHOUT ANY WARRANTY; without even the implied warranty of MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE. See the GNU General Public License for more details. You should have received a copy of the GNU General Public License along with this program; if not, write to the Free Software Foundation, Inc., 59 Temple Place, Suite 330, Boston, MA 02111-1307 USA or see http://www.gnu.org/licenses/.

using System;
using System.Collections.Generic;
using System.Text;

namespace Talkative
{
    class UserList : System.Collections.Specialized.NameObjectCollectionBase
    {

        #region Constants
        
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
