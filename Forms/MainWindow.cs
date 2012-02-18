// Talkative#
// Copyright (C) 2012 Jesús Diéguez Fernández
// This program is free software; you can redistribute it and/or modify it under the terms of the GNU General Public License as published by the Free Software Foundation; either version 3 of the License, or (at your option) any later version.
// This program is distributed in the hope that it will be useful, but WITHOUT ANY WARRANTY; without even the implied warranty of MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE. See the GNU General Public License for more details. You should have received a copy of the GNU General Public License along with this program; if not, write to the Free Software Foundation, Inc., 59 Temple Place, Suite 330, Boston, MA 02111-1307 USA or see http://www.gnu.org/licenses/.

using System;
using Gtk;
using Talkative;

public partial class MainWindow: Gtk.Window
{	
	
	Talk _talk;
	
	public delegate void UnreadMessagesHandler(object myObject);
	public event UnreadMessagesHandler OnUnreadMessages;
	
	public MainWindow (): base (Gtk.WindowType.Toplevel)
	{
		Build ();
		_talk = new Talk ();
	}
	
	protected void OnDeleteEvent (object sender, DeleteEventArgs a)
	{
		this.HideOnDelete();
		a.RetVal = true;
	}
	
	public void CenterMe()
	{
		int x = 0;
		int y = 0;
		
		x = this.DefaultSize.Width + (int)(this.Screen.Width * 0.0125);
		y = this.DefaultSize.Height + (int)(this.Screen.Height * 0.1);
		
		this.Move(this.Screen.Width - x, this.Screen.Height - y);
		
	}
	
	public string AppName()
	{
		return this.GetType().Assembly.GetName().Name + " v." + this.GetType().Assembly.GetName().Version.ToString ();
	}
	
	protected void OnCmdSendClicked (object sender, System.EventArgs e)
	{
		OnUnreadMessages (this);
	}
	
}
