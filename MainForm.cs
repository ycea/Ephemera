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
        private string selected = "�����";
        private int mouseX;
        private int mouseY;
        public MainForm()
        {

            InitializeComponent();
            world = new WorldController(sandBox.Width, sandBox.Height);
            canvas = new CanvasManager(sandBox, world);
            gameLoop = new GameLoop(world, canvas);
            CurrentElement.Text = $"������� �������: {selected}";
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
                case "�����":
                    element = new Fire(x, y);
                    break;
                case "�����":
                    element = new Soil(x, y);
                    break;
                case "����":
                    element = new Water(x, y);
                    break;
                case "������":
                    element = new Stone(x, y);
                    break;
            }

            if (element != null)
            {
                element.Width = (int)elementSizeNumericUpDown.Value;
                element.Height = (int)elementSizeNumericUpDown.Value;

                // ���������, ��� �� ��� �������� � ���� �����
                bool hasCollision = world.Elements.Any(e => world.CheckCollision(e, element));
                if (!hasCollision || selected == "�����")
                {
                    world.AddElement(element);
                }
                canvas.Redraw();
            }

        }

        private void SoilButton_Click(object sender, EventArgs e)
        {
            selected = "�����";
            CurrentElement.Text = $"������� �������: {selected}";
        }

        private void WaterButton_Click(object sender, EventArgs e)
        {
            selected = "����";
            CurrentElement.Text = $"������� �������: {selected}";
        }

        private void Stone_Click(object sender, EventArgs e)
        {
            selected = "������";
            CurrentElement.Text = $"������� �������: {selected}";

        }

        private void FireButton_Click(object sender, EventArgs e)
        {
            selected = "�����";
            CurrentElement.Text = $"������� �������: {selected}";
        }
    }
}
