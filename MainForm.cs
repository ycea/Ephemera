using Ephemera.ElementModels;
using Ephemera.Managers;
using Microsoft.VisualBasic.Devices;
using System.Windows.Forms;

namespace Ephemera
{
    public partial class MainForm : Form
    {
        private WorldController world;
        private CanvasManager canvas;
        private GameLoop gameLoop;
        private bool isMouseDown = false;
        private string selected = "Земля";
        private int mouseX;
        private int mouseY;
        public MainForm()
        {

            InitializeComponent();
            world = new WorldController(sandBox.Width, sandBox.Height);
            canvas = new CanvasManager(sandBox, world);
            gameLoop = new GameLoop(world, canvas);
            CurrentElement.Text = $"Текущий элемент: {selected}";
            canvas.Redraw();

            this.MaximizeBox = false;
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

        private void sandBox_MouseDown(object sender, MouseEventArgs e)
        {
            isMouseDown = true;
            mouseX = e.X;
            mouseY = e.Y;
            AddElement(e.X, e.Y);
        }

        private void sandBox_MouseMove(object sender, MouseEventArgs e)
        {
            if (isMouseDown)
            {
                AddElement(e.X, e.Y);
            }
        }

        private void sandBox_MouseUp(object sender, MouseEventArgs e)
        {
            isMouseDown = false;

        }

        private void AddElement(int x, int y)
        {

            ElementBase element = null;
            switch (selected)
            {
                case "Огонь":
                    element = new Fire(x, y);
                    break;
                case "Земля":
                    element = new Soil(x, y);
                    break;
                case "Вода":
                    element = new Water(x, y);
                    break;
                case "Камень":
                    element = new Stone(x, y);
                    break;
            }

            if (element != null)
            {
                element.Width = (int)elementSizeNumericUpDown.Value;
                element.Height = (int)elementSizeNumericUpDown.Value;

                // Проверяем, нет ли уже элемента в этом месте
                bool hasCollision = world.Elements.Any(e => world.CheckCollision(e, element));
                if (!hasCollision || selected == "Огонь")
                {
                    world.AddElement(element);
                }
                canvas.Redraw();
            }

        }

        private void SoilButton_Click(object sender, EventArgs e)
        {
            selected = "Земля";
            CurrentElement.Text = $"Текущий элемент: {selected}";
        }

        private void WaterButton_Click(object sender, EventArgs e)
        {
            selected = "Вода";
            CurrentElement.Text = $"Текущий элемент: {selected}";
        }

        private void Stone_Click(object sender, EventArgs e)
        {
            selected = "Камень";
            CurrentElement.Text = $"Текущий элемент: {selected}";

        }

        private void FireButton_Click(object sender, EventArgs e)
        {
            selected = "Огонь";
            CurrentElement.Text = $"Текущий элемент: {selected}";
        }
    }
}
