using System;
using Gdk;
using Gtk;

namespace Sudoku_gs
{
	public static class Globals
	{
		public static Gdk.Color activeF = new Gdk.Color(0, 255, 0);
		public static Gdk.Color inactiveF = new Gdk.Color(255,255,255);
		public static Gdk.Color lockedF = new Gdk.Color(230,230,230);
		public static Gdk.Color lockedactiveF = new Gdk.Color(255,30,30);
		public static Gdk.Color samenumF = new Gdk.Color(30,40,200);
		public static Gdk.Color hintF = new Gdk.Color(255,255,0);
		static Globals(){
			
		}
	}
}
