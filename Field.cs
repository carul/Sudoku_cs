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
		public bool hinted = false;
		GameField p_game;

		//----------
		public bool set = true;
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
					if (f.set == false)
						f.tFixed.ModifyBg (StateType.Normal, Globals.inactiveF);
					else
						f.tFixed.ModifyBg (StateType.Normal, Globals.lockedF);

				}
			}
			if (this.set == false)
				this.tFixed.ModifyBg (StateType.Normal, Globals.activeF);
			else
				this.tFixed.ModifyBg (StateType.Normal, Globals.lockedactiveF);
			p_game.selectedf = this;
			foreach (FieldBox fb in p_game.c_fbonxes) {
				foreach (Field f in fb.c_flist) {
					if (f == this)
						continue;
					if (f.num == this.num && num != 0)
						f.tFixed.ModifyBg (StateType.Normal, Globals.samenumF);
				}
			}
		}
		//---------------------------------



		public void update(){
			int h = this.tFrame.Allocation.Height;
			if (this.set == false) {
				if (true) {//draw frame
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
				} else {
					for (int i = 0; i < 9; i++)
						this.SmallDrafts [i].Text = " ";
				}
			} else {
				this.Net.SetSizeRequest (0, 0);
				Pango.FontDescription fd = new Pango.FontDescription ();
				fd.Size = Convert.ToInt32 (h * 0.15 * Pango.Scale.PangoScale);
				for (int i = 0; i < 9; i++) {
					this.SmallDrafts [i].Text = " ";
					this.SmallDrafts [i].ModifyFont (fd);
					this.Net.Attach (this.SmallDrafts [i], (uint)i % 3, (uint)i % 3 + 1, (uint)Math.Floor ((double)i / 3d), (uint)Math.Floor ((double)i / 3d) + 1);
				}
				this.tFixed.ModifyBg (StateType.Normal, Globals.lockedF);
				this.MainLabel.Text = this.num.ToString ();
				if (num == 0)
					this.MainLabel.Text = " ";
			}
			this.Net.Attach (this.MainLabel, 1, 2, 1, 2);
		}
	}
}