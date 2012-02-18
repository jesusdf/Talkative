// Talkative#
// Copyright (C) 2012 Jesús Diéguez Fernández
// This program is free software; you can redistribute it and/or modify it under the terms of the GNU General Public License as published by the Free Software Foundation; either version 3 of the License, or (at your option) any later version.
// This program is distributed in the hope that it will be useful, but WITHOUT ANY WARRANTY; without even the implied warranty of MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE. See the GNU General Public License for more details. You should have received a copy of the GNU General Public License along with this program; if not, write to the Free Software Foundation, Inc., 59 Temple Place, Suite 330, Boston, MA 02111-1307 USA or see http://www.gnu.org/licenses/.

using System;
using System.Collections.Generic;
using System.Text;

namespace Talkative
{
    class Config
    {
        private string _user="user";
        private string _IP = "localhost";
        
        public Config ()
		{ 
            
		}
  		
		/// <summary>
		/// Returns an array of users.
		/// </summary>
		/// <remarks>
		/// 
		/// </remarks>      
		
        public List<User> GetUserList ()
		{
			User lUser = new User ("me", "127.0.0.1");
			List<User> lUsers = new List<User> ();

			lUsers.Add (lUser);

			return lUsers;

		}
		
		/// <summary>
		/// Returns the user's name.
		/// </summary>
		/// <remarks>
		/// Currently it uses the logged on user on the system.
		/// </remarks>
		public static string MyName()
		{
            return System.Environment.UserName;
        }

    }
}
