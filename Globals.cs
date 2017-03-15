using System;
using Gdk;
using Gtk;

namespace Sudoku_gs
{
	public static class Globals
	{
		public static Gdk.Color activeF = new Gdk.Color();
		public static Gdk.Color inactiveF = new Gdk.Color(255,255,255);
		static Globals(){
			Gdk.Color.Parse ("green", ref activeF);
		}
	}
}

