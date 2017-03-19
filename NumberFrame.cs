using System;
using Gtk;
using System.Collections.Generic;
using System.Linq;

namespace Sudoku_gs
{
	public class NumberFrame
	{

		List<Button> c_buttons = new List<Button> ();
		public NumberFrame (Table parent_t, GameField pgf, string name="", uint row = 0 , uint col = 0, uint rowspan = 0, uint colspan = 0)
		{
			Frame frame;
			Box container;
			Table localtable = new Table(9, 1, false);

			frame = new Frame ("t_frame");
			frame.Label = name;
			frame.ShadowType = (ShadowType)4;
			container = new HBox (false, 0);

			for (int i = 0; i < 9; i++) {
				c_buttons.Add (new Button ((i+1).ToString()));
				var current = i+1;
				c_buttons [i].Clicked += (sender, EventArgs) => InputController.SetNum (sender, EventArgs, current, name);
				localtable.Attach (c_buttons[i], 0, 1, (uint)i, (uint)i+1);
			}

			frame.Add (localtable);
			container.PackStart (frame, true, true, 5);

			localtable.Show ();

			if (name == "Pen") {
				localtable.Resize (10, 1);
				Button hint = new Button ("Hint");
				localtable.Attach (hint, 0, 1, 9, 10);
				hint.Clicked += pgf.hint;
			} else if (name == "Pencil") {
				localtable.Resize (10, 1);
				Button clear = new Button ("Clean");
				localtable.Attach (clear, 0, 1, 9, 10);
				clear.Clicked += pgf.clearDrafts;
			}

			parent_t.Attach (container, col, colspan+col, row, rowspan+row);
		}
	}
}

