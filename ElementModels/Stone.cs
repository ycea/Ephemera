

using Ephemera.Enums;
using Ephemera.Managers;

namespace Ephemera.ElementModels
{
    public class Stone : ElementBase
    {
        public Stone(int x, int y)
        {
            X = x;
            Y = y;
            weight = 10;
            currentColor = Color.DimGray;
        }
        public override void Draw(Graphics g)
        {
            SolidBrush stoneBrush = new SolidBrush(Color.FromArgb(Math.Min(255, fadeTime * 10), currentColor));
            g.FillRectangle(stoneBrush, X, Y, Width, Height);
        }
        public override void Update(WorldController world)
        {
            base.Update(world);
            if (inWaterTime >= 100)
            {
                world.MarkForDeletion(this);
            }
            
            else if ((State == BasicStates.Normal))
            {
                inWaterTime = 0;
            }
        }
    }
}
