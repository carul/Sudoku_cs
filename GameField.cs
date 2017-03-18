using System;
using Gtk;
using System.Collections.Generic;
using System.Linq;

namespace Sudoku_gs
{
	public class GameField
	{
		public Field selectedf;
		public List<FieldBox> c_fbonxes = new List<FieldBox> ();
		public GameField (Table p_table, uint row, uint col, uint rowspan, uint colspan)
		{	
			AspectFrame m_frame = new AspectFrame ("Sudoku", 0, 0, 1, false);
			Table localtable = new Table(9, 9, false);
			m_frame.Add (localtable);

			p_table.Attach (m_frame, col, col + colspan, row, row + rowspan);

			for (int i = 0; i < 9; i++) {
				
				c_fbonxes.Add(new FieldBox(this));
				localtable.Attach(c_fbonxes[i].fFrame, (uint)i % 3, (uint)i % 3 + 1, (uint)Math.Floor ((double)i / 3d), (uint)Math.Floor ((double)i / 3d) + 1);
			}
		}

		public void setField(int n){
			if (selectedf == null)
				return;
			selectedf.set = true;
			if (selectedf.num != n)
				selectedf.num = n;
			else
				selectedf.num = 0;
			selectedf.update ();
		}

		public void setFieldDraw(int num){
			if (selectedf == null)
				return;
			selectedf.set = false;
			selectedf.draws [num-1] ^= true;
			selectedf.update ();
		}

		public void updateAll(object obj, EventArgs args){
			Console.Write ("cl");
			foreach(FieldBox fb in c_fbonxes){
				foreach(Field f in fb.c_flist){
					f.update ();
				}
			}
		}
	}
}

