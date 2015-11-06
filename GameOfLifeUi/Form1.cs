using CellularAutomataLib;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GameOfLifeUi
{
    public partial class Form1 : Form
    {
        private Field mField;

        public Form1()
        {
            InitializeComponent();
            this.DoubleBuffered = true;

            mField = new Field(192, 108);

            Random rand = new Random((int) DateTime.Now.Ticks);

            for (int x = 0; x < mField.Width; ++x)
            {
                for (int y = 0; y < mField.Height; ++y)
                {
                    if(rand.NextDouble() > 0.5)
                    {
                        mField.SetCell((uint)x, (uint)y);
                    }
                }
            }

            updateTimer.Start();
        }
        
        private void Form1_Paint(object sender, PaintEventArgs e)
        {
            int cellSize = 4;

            for(int x = 0; x < mField.Width; ++x)
            {
                for (int y = 0; y < mField.Height; ++y)
                {
                    if(mField.GetCell((UInt32) x, (UInt32) y))
                    {
                        e.Graphics.FillRectangle(new SolidBrush(Color.Black), new Rectangle(x * cellSize, y * cellSize, cellSize, cellSize));
                    }
                }
            }
        }

        private void updateTimer_Tick(object sender, EventArgs e)
        {
            mField.Update();
            Refresh();
        }
    }
}
