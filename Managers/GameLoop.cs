
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
        private List<(string, string)> quotes = new List<(string, string)>()
        {
            ("В одну реку нельзя войти дважды.", "Гераклит"),
            ("Время есть река из возникающих событий; сильное её течение. Только появится что-нибудь, как уже проносится мимо.", "Марк Аврелий"),
            ("Всё составное непостоянно.", "Будда"),
            ("Искусство существует, чтобы мы не погибли от истины.", "Фридрих Ницше"),
            ("Творчество — это смерть, поставленная на паузу.", "Альбер Камю"),
            ("Искусство — это интенсивная форма индивидуализма.", "Оскар Уайльд"),
            ("То, что сжимается, расширяется. То, что ослабевает, усиливается. То, что разрушается, обновляется.", "Лао-цзы"),
            ("Всё имеет своё время... время разрушать и время строить.", "Экклезиаст"),
            ("Цени момент. В нем — вечность.", "Сэн-но Рикю"),
            ("Человек есть не что иное, как то, чем он делает себя сам.", "Жан-Поль Сартр")
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
                numOfFinishes = 0;
                world.isFinished = false;
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
            if (world.averageFade < 17)
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
            var selectedQuote = quotes[rand.Next(quotes.Count)];
            MessageBox.Show(selectedQuote.Item1, selectedQuote.Item2, MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
    }


}
