using System;

namespace CellularAutomataLib
{
	public class Field
	{
		private bool[,] _cells;

		public int Width => _cells.GetLength(0);

		public int Height => _cells.GetLength(1);

		public Field(uint width, uint height)
		{
			if (0 == width || 0 == height)
			{
				throw new ArgumentOutOfRangeException("Width and height must not be 0");
			}

			_cells = new bool[width, height];
		}

		public bool GetCell(uint x, uint y)
		{
			if (x >= Width || y >= Height)
			{
				return false;
			}

			return _cells[x, y];
		}

		public void SetCell(uint x, uint y)
		{
			if (x >= Width || y >= Height)
			{
				throw new ArgumentOutOfRangeException("Indices must be within field dimensions");
			}

			_cells[x, y] = true;
		}

		public void Update()
		{
			var updateCells = (bool[,])_cells.Clone();

			for (var x = 0; x < Width; ++x)
			{
				for (var y = 0; y < Height; ++y)
				{
					var neighbourCount = GetNeighbourCount(x, y);

					if (neighbourCount < 2 || neighbourCount > 3)
					{
						updateCells[x, y] = false;
					}

					if (neighbourCount == 3)
					{
						updateCells[x, y] = true;
					}
				}
			}

			_cells = (bool[,])updateCells.Clone();
		}

		private int GetNeighbourCount(int x, int y)
		{
			var count = 0;

			for (var i = -1; i < 2; ++i)
			{
				for (var j = -1; j < 2; ++j)
				{
					if (i == 0 && j == 0)
						continue;

					try
					{
						if (GetCell((uint)(x + i), (uint)(y + j)))
						{
							++count;
						}
					}
					catch (ArgumentOutOfRangeException)
					{

					}
				}
			}

			return count;
		}
	}
}
