using System;
using System.Collections.Generic;
using System.Text;

namespace Talkative
{
    class Talk
    {

        #region Variables
        
        private Connection _conn;
        private string _name;
		private UserList _userList;

        #endregion

        #region Interfaz

        public Talk()
        {
			
            _conn = new Connection();
			_userList = new UserList(_conn);
			
            _name = Config.MyName();
            _userList.ReloadUserList();
            
            _conn.Listen(69);

        }

        ~Talk() {
            
        }

        #endregion

    }
}
