using Gtk;
using System;
using System.Collections.Generic;
using Pango;

namespace Sudoku_gs
{
	public class Field
	{
		public EventBox tFixed;
		public int num = 0;
		public bool []draws = new bool[9];
		public Frame tFrame = new Frame();
		GameField p_game;

		//----------
		public bool set = false;
		private List<Label>SmallDrafts = new List<Label>();
		private Table Net = new Table(9,9,false);
		private Label MainLabel = new Label(" ");
		public Field (GameField parent)
		{
			Array.Clear (draws, 0, draws.Length);
			p_game = parent;
			tFixed = new EventBox();
			tFixed.ModifyBg (StateType.Normal, Globals.inactiveF);
			this.tFixed.Events |= Gdk.EventMask.ButtonPressMask;
			this.tFixed.ButtonPressEvent += fClicked;
			this.tFixed.BorderWidth = 0;
			this.tFixed.Add (tFrame);
			this.tFrame.Add (this.Net);
			for (int i = 0; i < 9; i++) {
				this.SmallDrafts.Add(new Label (" "));
			}
			this.update ();

		}

		private void fClicked(System.Object obj, EventArgs args){
			foreach (FieldBox fb in p_game.c_fbonxes) {
				foreach (Field f in fb.c_flist) {
					f.tFixed.ModifyBg (StateType.Normal, Globals.inactiveF);
				}
			}
			this.tFixed.ModifyBg (StateType.Normal, Globals.activeF);
			p_game.selectedf = this;
		}
		//---------------------------------



		public void update(){
			int h = this.tFrame.Allocation.Height;
			if (set == false) {//draw frame
				Pango.FontDescription fd = new Pango.FontDescription ();
				fd.Size = Convert.ToInt32 (h * 0.15 * Pango.Scale.PangoScale);
				this.Net.SetSizeRequest (0, 0);
				for (int i = 0; i < 9; i++) {
					this.SmallDrafts [i].ModifyFont (fd);
					this.SmallDrafts [i].Unparent ();
					this.Net.Attach (this.SmallDrafts [i], (uint)i % 3, (uint)i % 3 + 1, (uint)Math.Floor ((double)i / 3d), (uint)Math.Floor ((double)i / 3d) + 1);
				}
			}
			this.MainLabel.Text = this.num.ToString ();
			if (num == 0) {
				this.MainLabel.Text = " ";
				for (int i = 0; i < 9; i++) {
					if (this.draws [i] == true)
						this.SmallDrafts [i].Text = (i + 1).ToString ();
					else
						this.SmallDrafts [i].Text = " ";
				}
			}
			else {
				for (int i = 0; i < 9; i++)
					this.SmallDrafts [i].Text = " ";
			}
			this.Net.Attach (this.MainLabel, 1, 2, 1, 2);
		}
	}
}