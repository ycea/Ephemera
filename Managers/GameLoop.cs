
using System.Windows.Forms; 
namespace Ephemera.Managers
{
    public class GameLoop
    {
        private System.Windows.Forms.Timer timer;
        private WorldController world;
        private CanvasManager canvas;
        private bool isRunning;

        public GameLoop(WorldController wc, CanvasManager cm)
        {
            world = wc;
            canvas = cm;
            timer = new System.Windows.Forms.Timer();
            timer.Interval = wc.IntervalOfMomet; // 10 кадров в секунду
            timer.Tick += (s, e) => Run();
        }

        public void Start()
        {
            if (!isRunning)
            {
                isRunning = true;
                timer.Start();
            }
        }

        public void Stop()
        {
            isRunning = false;
            timer.Stop();
        }

        public void Run()
        {
            if (isRunning) 
            {
                world.UpdateAll();
            }

            canvas.Redraw();
        }
    }


}
