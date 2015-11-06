using System;

namespace CellularAutomataLib
{
    public class Field
    {
        bool[,] mCells;

        public int Width
        {
            get
            {
                return mCells.GetLength(0);
            }
        }

        public int Height
        {
            get
            {
                return mCells.GetLength(1);
            }
        }

        public Field(UInt32 width, UInt32 height)
        {
            if (0 == width || 0 == height)
            {
                throw new ArgumentOutOfRangeException("Width and height must not be 0");
            }

            mCells = new bool[width, height];
        }

        public bool GetCell(UInt32 x, UInt32 y)
        {
            if (x >= Width || y >= Height)
            {
                return false;
            }

            return mCells[x, y];
        }

        public void SetCell(UInt32 x, UInt32 y)
        {
            if (x >= Width || y >= Height)
            {
                throw new ArgumentOutOfRangeException("Indices must be within field dimensions");
            }

            mCells[x, y] = true;
        }

        public void Update()
        {
            bool [,] updateCells =  (bool [,]) mCells.Clone();

            for(int x = 0; x < Width; ++x)
            {
                for(int y = 0; y < Height; ++y)
                {
                    int neighbourCount = GetNeighbourCount(x, y);

                    if(neighbourCount < 2 || neighbourCount > 3)
                    {
                        updateCells[x, y] = false;
                    }

                    if(neighbourCount == 3)
                    {
                        updateCells[x, y] = true;
                    }
                }
            }

            mCells = (bool[,]) updateCells.Clone();
        }

        private int GetNeighbourCount(int x, int y)
        {
            int count = 0;

            for (int i = -1; i < 2; ++i)
            {
                for (int j = -1; j < 2; ++j)
                {
                    if(!(i == 0 && j == 0))
                    {
                        try
                        {
                            if(GetCell((UInt32) (x + i), (UInt32) (y + j)))
                            {
                                ++count;
                            }
                        }
                        catch(ArgumentOutOfRangeException)
                        {

                        }
                    }
                }
            }
                
            return count;
        }
    }
}
