using Ephemera.ElementModels;
using Ephemera.Managers;
using System.Windows.Forms;

namespace Ephemera
{
    public partial class MainForm : Form
    {
        private WorldController world;
        private CanvasManager canvas;
        private GameLoop gameLoop;
        public MainForm()
        {

            InitializeComponent();
            world = new WorldController(sandBox.Width, sandBox.Height);
            canvas = new CanvasManager(sandBox, world);
            gameLoop = new GameLoop(world, canvas);

        }


        private void sandBox_Click(object sender, MouseEventArgs e)
        {
            if (comboBoxElements.SelectedIndex != -1) 
            {
                string selected = comboBoxElements.SelectedItem.ToString();
                ElementBase element = null;

                if (selected == "Огонь") element = new Fire(e.X, e.Y);
                else if (selected == "Земля") element = new Soil(e.X, e.Y);

                if (element != null)
                {
                    element.Width = (int)elementSizeNumericUpDown.Value;
                    element.Height = (int)elementSizeNumericUpDown.Value;
                    world.AddElement(element);
                    gameLoop.Run();
                }
            }
        }

        private void startGameButton_Click(object sender, EventArgs e)
        {
            gameLoop.Start();
        }

        private void stopGameButton_Click(object sender, EventArgs e)
        {
            gameLoop.Stop();
            world.Reset();
            canvas.ClearCanvas();
        }
    }
}
