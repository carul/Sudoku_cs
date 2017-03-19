using System;
using Gtk;
using System.Collections.Generic;
using System.Linq;

namespace Sudoku_gs
{
	public class GameField
	{
		public int [,]save = new int[9,9];	
		public bool gamestarted =false;
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
			if (selectedf.set == false) {
				if (selectedf.num != n)
					selectedf.num = n;
				else
					selectedf.num = 0;
			}
			selectedf.update ();
		}

		public void setFieldDraw(int num){
			if (selectedf == null)
				return;
			if (selectedf.set == false) {
				selectedf.draws [num - 1] ^= true;
				selectedf.update ();
			}
		}

		public void updateAll(object obj, EventArgs args){
			foreach(FieldBox fb in c_fbonxes){
				foreach(Field f in fb.c_flist){
					f.update ();
				}
			}
		}
		public void updateAll(){
			foreach(FieldBox fb in c_fbonxes){
				foreach(Field f in fb.c_flist){
					f.update ();
				}
			}
		}
		public void clearDrafts(){
			foreach(FieldBox fb in c_fbonxes){
				foreach(Field f in fb.c_flist){
					for (int i = 0; i < 9; i++) {
						f.draws [i] = false;
					}
				}
			}
			updateAll ();
		}
		public void clearDrafts(System.Object obj, EventArgs evnt){
			foreach(FieldBox fb in c_fbonxes){
				foreach(Field f in fb.c_flist){
					for (int i = 0; i < 9; i++) {
						f.draws [i] = false;
					}
				}
			}
			updateAll ();
		}
		public void hint(System.Object obj, EventArgs evnt){
			Random rand = new Random ();
			int maxrands = 0;
			while (gamestarted == true) {
				int w = rand.Next (0, 9);
				int f = rand.Next (0, 9);
				if (this.c_fbonxes [w].c_flist [f].set == false && this.c_fbonxes [w].c_flist [f].num == 0 ) {
					this.c_fbonxes [w].c_flist [f].num = this.save [w, f];
					this.c_fbonxes [w].c_flist [f].tFixed.ModifyBg (StateType.Normal, Globals.hintF);
					this.c_fbonxes [w].c_flist [f].update ();
					this.c_fbonxes [w].c_flist [f].hinted = true;
					break;
				}
				maxrands++;
				if (maxrands > 10000)
					break;
			}
		}


		public void generate(int hide){
			this.clearDrafts ();
			int[,] area = new int[9, 9];
			Random rand = new Random ();
			Logics.GenerateBasic (area);
			for (int i = 0; i < 16; i++) {//should be random enough
				int r = rand.Next (1, 5);
				switch (r) {
				case 1:
					Logics.SwapColsHorizontal(area, rand.Next(0,3), rand.Next(0,3), rand.Next(0,3));
					break;

				case 2:
					Logics.SwapColsVertical(area, rand.Next(0,3), rand.Next(0,3), rand.Next(0,3));
					break;

				case 3:
					Logics.SwapRowsHorizontal(area, rand.Next(0,3), rand.Next(0,3));
					break;

				case 4:
					Logics.SwapRowsVertical(area, rand.Next(0,3), rand.Next(0,3));
					break;
				}

			}

			for (int i = 0; i < 9; i++)
				for (int j = 0; j < 9; j++) {
					this.c_fbonxes [i].c_flist [j].num = area [i, j];
					this.c_fbonxes [i].c_flist [j].set = true;
				}

			save = area;

			while (hide > 0) {
				int w = rand.Next (0, 9);
				int f = rand.Next (0, 9);
				if (this.c_fbonxes [w].c_flist [f].set == true) {
					this.c_fbonxes [w].c_flist [f].set = false;
					this.c_fbonxes [w].c_flist [f].num = 0;
					hide--;
				}
			}

			updateAll ();

			foreach(FieldBox fb in this.c_fbonxes)
				foreach(Field f in fb.c_flist)
					if(f.set == false)
						f.tFixed.ModifyBg(StateType.Normal, Globals.inactiveF);
			gamestarted = true;
		}
	}
}

