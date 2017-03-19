using System;

namespace Sudoku_gs
{
	public static  class Logics
	{
		public static void GenerateBasic(int [,] area){
			for (int i = 0; i < 9; i++) {
				for (int j = 0; j < 9; j++) {
					if (j + i + 1<= 9)
						area [(int)Math.Floor(i/3d)+ i % 3 * 3, j] = j + 1 + i;
					else
						area [(int)Math.Floor(i/3d)+ i % 3 * 3, j] = j + 1 + i - 9;
				}
			}
		}
		public static void SwapRowsHorizontal(int [,] area, int start, int end){
			for (int i = 0; i < 9; i++) {
				int tmp;
				tmp = area [end * 3, i];
				area [end * 3, i] = area [start * 3, i];
				area [start * 3, i] = tmp;
				tmp = area [end * 3+1, i];
				area [end * 3+1, i] = area [start * 3+1, i];
				area [start * 3+1, i] = tmp;
				tmp = area [end * 3+2, i];
				area [end * 3+2, i] = area [start * 3+2, i];
				area [start * 3+2, i] = tmp;
			}
		}
		public static void SwapRowsVertical(int [,] area, int start, int end){
			for (int i = 0; i < 9; i++) {
				int tmp;
				tmp = area [end, i];
				area [end, i] = area [start, i];
				area [start, i] = tmp;
				tmp = area [end+3, i];
				area [end+3, i] = area [start+3, i];
				area [start+3, i] = tmp;
				tmp = area [end+6, i];
				area [end+6, i] = area [start+6, i];
				area [start+6, i] = tmp;
			}
		}
		public static void SwapColsHorizontal(int [,] area, int blocks, int start, int end){
			for (int i = 0; i < 3; i++) {
				int tmp;
				tmp = area [blocks * 3, end * 3+i];
				area [blocks * 3, end * 3+i] = area [blocks * 3, start * 3+i];
				area [blocks * 3, start * 3+i] = tmp;
				tmp = area [blocks * 3 + 1, end * 3+i];
				area [blocks * 3 + 1, end * 3+i] = area [blocks * 3 + 1, start * 3+i];
				area [blocks * 3 + 1, start * 3+i] = tmp;
				tmp = area [blocks * 3 + 2, end * 3+i];
				area [blocks * 3 + 2, end * 3+i] = area [blocks * 3 + 2, start * 3+i];
				area [blocks * 3 + 2, start * 3+i] = tmp;
			}
		}
		public static void SwapColsVertical(int [,] area, int blocks, int start, int end){
			for (int i = 0; i < 3; i++) {
				int tmp;
				tmp = area [blocks , end + (i*3)];
				area [blocks, end + (i*3)] = area [blocks, start + (i*3)];
				area [blocks, start + (i*3)] = tmp;
				tmp = area [blocks+3 , end + (i*3)];
				area [blocks+3, end + (i*3)] = area [blocks+3, start + (i*3)];
				area [blocks+3, start + (i*3)] = tmp;
				tmp = area [blocks+6 , end + (i*3)];
				area [blocks+6, end + (i*3)] = area [blocks+6, start + (i*3)];
				area [blocks+6, start + (i*3)] = tmp;
			}
		}
	}
}