using Gtk;
using System;
using System.Drawing;


namespace Sudoku_gs
{

	public class sudoku_gs : Window 
	{
		public const int scr_width = 640;
		public const int scr_height = 480;
		public sudoku_gs() :base(""){
			Window window = new Window ("Sudoku");
			window.DeleteEvent += delegate {
				Application.Quit();
			};

			window.SetSizeRequest(scr_width, scr_height);
			window.BorderWidth= 10;

			Table m_table = new Table (5, 8, false);

			GameField gf = new GameField (m_table, 1, 1, 4, 6);
			InputController.setGTarget (gf);
			new NumberFrame (m_table, "Pen", 1, 0, 4, 1);
			new NumberFrame (m_table, "Pencil", 1, 7, 4, 1);

			m_table.Show ();
			window.Add (m_table);

			MenuBar mb = new MenuBar ();
			MenuItem QuitMenu = new MenuItem ("Exit");
			QuitMenu.ButtonPressEvent += delegate {	Application.Quit(); };
			MenuItem ResetMenu = new MenuItem ("Start / Reset");
			mb.Append (ResetMenu);
			mb.Append (QuitMenu);
			window.Resizable = false;
			m_table.Attach (mb, 0, 8, 0, 1);
			window.ShowAll();
		}

		public static void Main( string[] args)
		{
			Application.Init();
			new sudoku_gs ();
			Application.Run();
		}
	}

}