using System;
using System.Collections.Generic;
using System.Text;

namespace Talkative
{
    public class User
    {
		
		#region Variables
        
		private string _name = null;
        private string _IP = null;
        private bool _blocked = false;
		
		#endregion 
		
        public User() {
            InitData(null, null, false);
        }

        public User(string Name, string IP) {
            InitData(Name, IP, false);
        }

        private void InitData(string name, string IP, bool blocked) {
            _name = name;
            _IP = IP;
            _blocked = blocked;
        }

        public string Name {
            get {
                return _name;
            }
            set {
                _name = Name;
            }
        }

        public string IP
        {
            get
            {
                return _IP;
            }
            set
            {
                _IP = IP;
            }
        }

        public bool Blocked
        {
            get
            {
                return _blocked;
            }
            set
            {
                _blocked = Blocked;
            }
        }

    }
}
