using Gtk;
using System;
using System.Collections.Generic;

namespace Sudoku_gs
{
	public class Field
	{
		public uint num;
		public bool []draws = new bool[9];
		public Frame tFrame = new Frame();
		public DrawingArea tDraw = new DrawingArea();
		GameField p_game;
		public Field (GameField parent)
		{
			Array.Clear (draws, 0, draws.Length);
			p_game = parent;
			tFrame.Add (tDraw);
			tDraw.Events |= Gdk.EventMask.ButtonPressMask;
			tDraw.ButtonPressEvent += fClicked ;
			tDraw.ModifyBg (StateType.Normal, Globals.activeF);
			tDraw.ModifyBg (StateType.Normal, Globals.inactiveF);
		}

		private void fClicked(System.Object obj, EventArgs args){
			foreach (FieldBox fb in p_game.c_fbonxes) {
				foreach (Field f in fb.c_flist) {
					f.tDraw.ModifyBg (StateType.Normal, Globals.inactiveF);
				}
			}
			this.tDraw.ModifyBg (StateType.Normal, Globals.activeF);
			p_game.selectedf = this;
		}
	}
}

