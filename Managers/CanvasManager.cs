
using Timer = System.Windows.Forms.Timer;

namespace Ephemera.Managers
{
    public class CanvasManager
    {
        private PictureBox pictureBox;
        private Bitmap canvas;
        private WorldController world;

        public CanvasManager(PictureBox pb, WorldController wc)
        {
            pictureBox = pb;
            world = wc;
            canvas = new Bitmap(pb.Width, pb.Height);
            pb.Image = canvas;
        }

        public void Redraw()
        {
            using (Graphics g = Graphics.FromImage(canvas))
            {
                g.Clear(Color.White);
                foreach (var element in world.Elements)
                {
                    element.Draw(g);
                }
            }
            pictureBox.Refresh();
        }
   
        public void FinishWorld()
        {
            using (Graphics g = Graphics.FromImage(canvas))
            {
                Pen crackPen = new Pen(Color.Black, 3); // Цвет и толщина линий трещин
                Random rand = new Random();

                for (int i = 0; i < 5; i++)
                {
                    List<Point> crackPoints = new List<Point>();

                    // Определяем случайный стартовый край (0 - верх, 1 - низ, 2 - лево, 3 - право)
                    int side = rand.Next(4);
                    Point start;

                    switch (side)
                    {
                        case 0: start = new Point(rand.Next(pictureBox.Width), 0); break;         // Верх
                        case 1: start = new Point(rand.Next(pictureBox.Width), pictureBox.Height); break;    // Низ
                        case 2: start = new Point(0, rand.Next(pictureBox.Height)); break;        // Лево
                        default: start = new Point(pictureBox.Width, rand.Next(pictureBox.Height)); break;   // Право
                    }

                    crackPoints.Add(start);

                    // Генерируем несколько точек, чтобы создать зигзагообразную трещину
                    for (int j = 0; j < 6; j++)
                    {
                        int offsetX = rand.Next(-20, rand.Next(20,50));
                        int offsetY = rand.Next(-20, rand.Next(20, 50));
                        Point last = crackPoints.Last();
                        crackPoints.Add(new Point(
                            Math.Clamp(last.X + offsetX, 0, pictureBox.Width),
                            Math.Clamp(last.Y + offsetY, 0, pictureBox.Height)
                        ));
                    }

                    g.DrawLines(crackPen, crackPoints.ToArray());
                }

                crackPen.Dispose();
            }
            pictureBox.Refresh();
            

        }

        public void ClearCanvas()
        {
            world.Reset();
            Redraw();
        }

    }

}
