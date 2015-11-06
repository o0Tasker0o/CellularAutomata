using System;
using System.Windows.Forms;

namespace GameOfLifeUi
{
	public partial class MainForm : Form
	{
		private readonly GOLRenderer _renderer;

		public MainForm()
		{
			InitializeComponent();

			_renderer = new GOLRenderer();

			updateTimer.Start();
		}

		private void updateTimer_Tick(object sender, EventArgs e)
		{
			fieldPanel.BackgroundImage = _renderer.Render();
			fieldPanel.Refresh();
		}
	}
}
