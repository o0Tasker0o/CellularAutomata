using System.Windows.Forms;

namespace GameOfLifeUi
{
	public sealed partial class DoubleBufferedPanel : UserControl
	{
		public DoubleBufferedPanel()
		{
			InitializeComponent();

			DoubleBuffered = true;
		}
	}
}
