using System;
using Gtk;
using System.Collections.Generic;

namespace Sudoku_gs
{
	public class FieldBox
	{
		public Frame fFrame;
		public List<Field> c_flist = new List<Field>();
		GameField p_game;
		public FieldBox (GameField parent)
		{
			p_game = parent;
			Table fTab = new Table (9, 9, false);
			for (int i = 0; i < 9; i++) {
				c_flist.Add(new Field(p_game));
				fTab.Attach (c_flist [i].tFixed, (uint)i % 3, (uint)i % 3 + 1, (uint)Math.Floor ((double)i / 3d), (uint)Math.Floor ((double)i / 3d) + 1);
			}
			fFrame = new Frame ();
			fFrame.Add (fTab);
		}
	}
}

