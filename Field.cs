using Gtk;
using System;
using System.Collections.Generic;
using Pango;

namespace Sudoku_gs
{
	public class Field
	{
		private class FieldContents
		{
			Label MainLabel;
			public Table Net;
			public bool drawframe;
			private Label[] DrawsLabels;
			public FieldContents()
			{
				this.MainLabel = new Label(" ");
				this.Net = new Table(9,9, false);
				this.DrawsLabels = new Label[9];
				for(int i = 0; i < 9; i++){
					this.DrawsLabels[i] = new Label(" ");
				}
			}
			public void update(uint num, bool[]d )
			{
				foreach (Widget w in this.Net.Children)
					this.Net.Remove (w);
				if (this.drawframe == false) {
					Console.WriteLine (num.ToString ());
					this.MainLabel.Text = num.ToString ();
					this.Net.Resize (1, 1);
					this.Net.Attach (this.MainLabel, 0, 1, 0, 1);
				} else {
					this.Net.Resize (9, 9);
					for (int i = 0; i < 9; i++) {
						if (d [i] == true)
							this.DrawsLabels [i].Text = (i+1).ToString ();
						else
							this.DrawsLabels [i].Text = " ";
						this.Net.Attach(this.DrawsLabels[i], (uint)i % 3, (uint)i % 3 + 1, (uint)Math.Floor ((double)i / 3d), (uint)Math.Floor ((double)i / 3d) + 1);
					}
				}
			}
		}
		public EventBox tFixed;
		public uint num = 0;
		public bool []draws = new bool[9];
		public Frame tFrame = new Frame();
		GameField p_game;
		FieldContents DrawContents;
		public Field (GameField parent)
		{
			Array.Clear (draws, 0, draws.Length);
			p_game = parent;
			//tFrame.Add (tDraw);
			tFixed = new EventBox();
			tFixed.ModifyBg (StateType.Normal, Globals.inactiveF);
			DrawContents = new FieldContents ();
			this.update ();
			this.tFixed.Events |= Gdk.EventMask.ButtonPressMask;
			this.tFixed.ButtonPressEvent += fClicked;
			this.tFixed.BorderWidth = 0;
			this.tFixed.Add (this.tFrame);
			this.tFrame.Add (this.DrawContents.Net);
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

		public void update(){
			if (this.num == 0)
				this.DrawContents.drawframe = true;
			else
				this.DrawContents.drawframe = false;

			this.DrawContents.update (this.num, this.draws);

		}
	}
}

