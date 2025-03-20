
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
            currentColor = Color.Red;
        }

        public override void Draw(Graphics g)
        {
            Brush brush = new SolidBrush(currentColor);
            g.FillRectangle(brush, X, Y, Width, Height);
        }


        public override void Update(WorldController world)
        {
            burnTime--;
            ChangeOthersStates(world, BasicStates.Burning);

            // Если время горения закончилось, удаляем огонь
            if (burnTime <= 0 || State == BasicStates.Wet)
            {
                world.MarkForDeletion(this);
                return;
            }

        }
    }

}
