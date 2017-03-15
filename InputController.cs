using System;

namespace Sudoku_gs
{
	public class InputController
	{
		static GameField Gref;
		public static void setGTarget(GameField s)
		{
			Gref = s;
		}
		public static void SetNum(Object obj, EventArgs args, int which, string type){
			if (type == "Pen")
				Gref.setField (which);
			else if (type == "Pencil")
				Gref.setFieldDraw (which);
		}
	}
}