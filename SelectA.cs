using System;
using Gtk;

namespace Sudoku_gs
{
	class SelectA : Gtk.Dialog
	{
		Window select_c;
		int ammount;
		Label amm;
		GameField fd;
		public SelectA(GameField f){
			fd =f;
			ammount = 50;
			Label desc = new Label("Select ammount of fields to remove\nMore removed fields- harder");
			amm = new Label ("Number of fields to be removed: " + ammount.ToString ());
			Button lBtn = new Button ("More");
			lBtn.Clicked += less;
			Button mBtn = new Button ("Less");
			mBtn.Clicked += more;
			Button okBtn = new Button ("OK");
			okBtn.Clicked += quit;
			Table tab = new Table (3, 4, false);
			tab.Attach (lBtn, 2, 3, 1, 2);
			tab.Attach (mBtn, 2, 3, 2, 3);
			tab.Attach (desc, 0, 3, 0, 1);
			tab.Attach(amm, 0, 2, 1, 4);
			tab.Attach (okBtn, 2, 3, 3, 4);
			select_c = new Window ("Select ammount of fields to remove");
			select_c.SetSizeRequest (400, 200);
			select_c.Resizable = false;
			select_c.BorderWidth = 10;
			select_c.Add (tab);
			select_c.ShowAll();
		}

		void more (System.Object obj, System.EventArgs args ){
			if (this.ammount > 10)
				this.ammount--;
			amm.Text = "Number of fields to be removed: " + ammount.ToString ();
		}

		void less (System.Object obj, System.EventArgs args ){
			if (this.ammount < 70)
				this.ammount++;
			amm.Text = "Number of fields to be removed: " + ammount.ToString ();
		}

		void quit (System.Object obj, System.EventArgs args ){
			this.Destroy ();
			this.select_c.Destroy ();
			fd.generate (this.ammount);
		}
	}
}


