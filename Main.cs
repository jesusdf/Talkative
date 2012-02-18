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
			_win.Title = _win.AppName ();
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
		
		private static void OnTrayIconPopup (object o, EventArgs args) {
			Menu popupMenu = new Menu();
			ImageMenuItem menuItemExit = new ImageMenuItem("Exit");
			Gtk.Image quitImg = new Gtk.Image(Stock.Quit, IconSize.Menu);
			menuItemExit.Image = quitImg;
			popupMenu.Add(menuItemExit);
			menuItemExit.Activated += delegate {
				Application.Quit();
			};
			
			popupMenu.ShowAll();
			popupMenu.Popup();
			
		}
		
		private static void StatusIconState(bool windowOpen, bool unreadMessages)
		{
			if(windowOpen)
			{
				_trayIcon.Pixbuf = global::Stetic.IconLoader.LoadIcon(_win, "stock_book_open", global::Gtk.IconSize.LargeToolbar);
			}
			else
			{
				if (unreadMessages)
				{
					_trayIcon.Pixbuf = global::Stetic.IconLoader.LoadIcon(_win, "stock_book_green", global::Gtk.IconSize.LargeToolbar);
				}
				else
				{
					_trayIcon.Pixbuf = global::Stetic.IconLoader.LoadIcon(_win, "stock_book_blue", global::Gtk.IconSize.LargeToolbar);
				}
			}
		}
		
	}
}
