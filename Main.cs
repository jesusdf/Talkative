// Talkative#
// Copyright (C) 2012 Jesús Diéguez Fernández
// This program is free software; you can redistribute it and/or modify it under the terms of the GNU General Public License as published by the Free Software Foundation; either version 3 of the License, or (at your option) any later version.
// This program is distributed in the hope that it will be useful, but WITHOUT ANY WARRANTY; without even the implied warranty of MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE. See the GNU General Public License for more details. You should have received a copy of the GNU General Public License along with this program; if not, write to the Free Software Foundation, Inc., 59 Temple Place, Suite 330, Boston, MA 02111-1307 USA or see http://www.gnu.org/licenses/.

using System;
using Gtk;

namespace Talkative
{
	class MainClass
	{
		
		private static MainWindow _win;
		private static StatusIcon _trayIcon;
		
		public static void Main (string[] args)
		{
			Application.Init ();
			
			_win = new MainWindow ();
			_win.Title = AppName ();
			_win.Icon = new Image (Me ().GetManifestResourceStream ("Talkative.Resources.normal.png")).Pixbuf;
			_win.Visible = false;
			
			_trayIcon = new StatusIcon (_win.Icon);
			_trayIcon.Visible = true;
			_trayIcon.Activate += delegate {
				_win.Visible = !_win.Visible;
				StatusIconState (_win.Visible, false);
				if (_win.Visible) {
					_win.CenterMe ();
				}
			};
			_trayIcon.PopupMenu += OnTrayIconPopup;
			_trayIcon.Tooltip = _win.Title;
			
			_win.DeleteEvent += delegate {
				StatusIconState (false, false);
			};
			_win.OnUnreadMessages += delegate {
				StatusIconState (_win.Visible, true);
			};
			
			Application.Run ();
			
		}
		
		/// <summary>
		/// Event to handle the Tray Icon Popup Menu.
		/// </summary>
		private static void OnTrayIconPopup (object o, EventArgs args)
		{
			Menu popupMenu = new Menu ();
			ImageMenuItem menuItemExit = new ImageMenuItem ("Exit");
			Gtk.Image quitImg = new Gtk.Image (Stock.Quit, IconSize.Menu);
			menuItemExit.Image = quitImg;
			popupMenu.Add (menuItemExit);
			menuItemExit.Activated += delegate {
				_trayIcon.Dispose ();
				Application.Quit ();
			};
			
			popupMenu.ShowAll ();
			popupMenu.Popup ();
			
		}
		
		/// <summary>
		/// Function to change the Tray Icon based on the state of the window and if there are unread messages.
		/// </summary>
		private static void StatusIconState (bool windowOpen, bool unreadMessages)
		{
			if (windowOpen) {
				_trayIcon.Pixbuf = new Image (Me().GetManifestResourceStream ("Talkative.Resources.open.png")).Pixbuf;
			} else {
				if (unreadMessages) {
					_trayIcon.Pixbuf = new Image (Me ().GetManifestResourceStream ("Talkative.Resources.new.png")).Pixbuf;
				} else {
					_trayIcon.Pixbuf = new Image (Me ().GetManifestResourceStream ("Talkative.Resources.normal.png")).Pixbuf;
				}
			}
		}
		
		public static string AppName ()
		{
			
			return Me ().GetName ().Name + " v." + Me ().GetName ().Version.ToString ();
		}
		
		public static System.Reflection.Assembly Me ()
		{
			return System.Reflection.Assembly.GetExecutingAssembly ();
		}
		
	}
}
