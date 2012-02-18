using System;
using Gtk;

public partial class MainWindow: Gtk.Window
{	
	
	public delegate void UnreadMessagesHandler(object myObject);
	public event UnreadMessagesHandler OnUnreadMessages;
	
	public MainWindow (): base (Gtk.WindowType.Toplevel)
	{
		Build ();
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
