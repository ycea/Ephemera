
using Ephemera.Enums;
using Ephemera.Managers;

namespace Ephemera.ElementModels
{
    public class Fire : ElementBase
    {
        private int burnTime = 5; 
        public Fire(int x, int y)
        {
            X = x;
            Y = y;
            State = BasicStates.Burning;
        }

        public override void Draw(Graphics g)
        {
            Brush brush = new SolidBrush(Color.Red);
            g.FillRectangle(brush, X, Y, Width, Height);
        }


        public override void Update(WorldController world)
        {
            burnTime--;

            // Если время горения закончилось, удаляем огонь
            if (burnTime <= 0)
            {
                world.MarkForDeletion(this);
                return;
            }
            IgniteOthers(world);

        }
    }

}
