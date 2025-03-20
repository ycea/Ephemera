
using System.Windows.Forms; 
namespace Ephemera.Managers
{
    public class GameLoop
    {
        private System.Windows.Forms.Timer timer;
        private WorldController world;
        private CanvasManager canvas;
        private bool isRunning;
        private int numOfFinishes = 0;
        private List<string> quotes = new List<string>()
        {
            "Мир не оканчивается. Оканчиваются только истории.",
            "И в конце концов, даже звезды гаснут...",
            "Каждый конец — это новый шанс.",
            "Не бойся тьмы. Это просто отсутствие света."
        };
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
                world.isFinished = false;
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
            if (world.averageFade < 17 && world.averageFade > 0)
            {
                Stop();
                isRunning = false;
                canvas.FinishWorld();
                world.isFinished = true;
                numOfFinishes++;
                if (numOfFinishes < 2)
                {
                    ShowQuote();
                }
                if (numOfFinishes > 4)
                {

                    world.Reset();
                }
                
                return;
            }
            canvas.Redraw();
        }
        private void ShowQuote()
        {
            if (quotes.Count == 0) return;

            Random rand = new Random();
            string selectedQuote = quotes[rand.Next(quotes.Count)];
            MessageBox.Show(selectedQuote, "Мудрые слова", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
    }


}
