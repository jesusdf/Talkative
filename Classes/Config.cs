using System;
using System.Collections.Generic;
using System.Text;

namespace Talkative
{
    class Config
    {
        private string _user="user";
        private string _IP = "localhost";
        
        public Config() { 
            
        }
        
        public List<User> GetUserList() {
            User lUser = new User("me","127.0.0.1");
            List<User> lUsers = new List<User>();

			lUsers.Add(lUser);

            return lUsers;

        }
		
		public static string MyName()
		{
            return System.Environment.UserName;
        }

    }
}
