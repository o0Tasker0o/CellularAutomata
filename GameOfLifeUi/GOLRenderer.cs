using CellularAutomataLib;
using System;
using System.Drawing;

namespace GameOfLifeUi
{
	public class GOLRenderer
	{
		private const int CellSize = 10;
		private readonly Field _field;
		private readonly Bitmap _bmp;

		public GOLRenderer()
		{
			const int width = 1920;
			const int height = 1080;

			_field = new Field(width / CellSize, height / CellSize);

			var rand = new Random((int)DateTime.Now.Ticks);

			for (var x = 0; x < _field.Width; ++x)
			{
				for (var y = 0; y < _field.Height; ++y)
				{
					if (rand.NextDouble() > 0.5)
					{
						_field.SetCell((uint)x, (uint)y);
					}
				}
			}

			_bmp = new Bitmap(width, height);
		}

		public Bitmap Render()
		{
			var graphics = Graphics.FromImage(_bmp);

			DrawBackGround(CellSize, graphics);

			for (var x = 0; x < _field.Width; ++x)
			{
				for (var y = 0; y < _field.Height; ++y)
				{
					if (_field.GetCell((uint)x, (uint)y))
					{
						DrawLiveCell(x, y, CellSize, graphics);
					}
					else
					{
						DrawDeadCell(x, y, CellSize, graphics);
					}
				}
			}

			_field.Update();
			return _bmp;
		}

		private void DrawBackGround(int size, Graphics graphics)
		{
			graphics.FillRectangle(new SolidBrush(Color.White), new Rectangle(0, 0, _field.Width * size, _field.Height * size));
		}

		private static void DrawLiveCell(int x, int y, int size, Graphics graphics)
		{
			graphics.FillRectangle(new SolidBrush(Color.Black), new Rectangle(x * size, y * size, size, size));
		}

		private static void DrawDeadCell(int x, int y, int size, Graphics graphics)
		{

		}
	}
}
