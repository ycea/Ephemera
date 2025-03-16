
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
        public void ClearCanvas()
        {
            world.Reset();
            Redraw();
        }
    }

}
