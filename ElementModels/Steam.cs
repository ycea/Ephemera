
using Ephemera.Managers;

namespace Ephemera.ElementModels
{
    public class Steam : ElementBase
    {
        public Steam(int x, int y) 
        {
            X = x; Y = y;
            currentColor = Color.LightGray;

        }
        public override void Draw(Graphics g)
        {
            Brush steamBrush = new SolidBrush(Color.FromArgb(Math.Min(255, fadeTime * 10), currentColor));
            g.FillRectangle(steamBrush, X, Y, Width, Height);
        }
        public override void ApplyGravity(WorldController world)
        {
            base.Update(world);
            Random rand = new Random();
            if (Y >= 0)
            {
                Y -= 2;
                int flowSpeed = 2;
                bool canMoveLeft = true;
                bool canMoveRight = true;
                bool hitFromAbove = false; // Флаг удара сверху

                if (X + Width >= world.Width)
                {
                    canMoveRight = false;
                }
                if (X <= 0)
                {
                    canMoveLeft = false;
                }
                foreach (var element in world.Elements)
                {
                    if (world.CheckCollision(this, element))
                    {
                        // Проверяем стены слева и справа
                        if (this.X - flowSpeed == element.X + element.Width) canMoveLeft = false;
                    }
                }


                //  Если не может падать, то пытается растекаться
                if (canMoveLeft && canMoveRight)
                {

                    // Если оба направления открыты, выбираем случайно
                    if (rand.Next(2)==0) this.X -= flowSpeed;
                    else this.X += flowSpeed;
                }
                else if (canMoveLeft)
                {
                    this.X -= flowSpeed;
                }
                else if (canMoveRight)
                {
                    this.X += flowSpeed;
                }
            }

      

        }
    }
}
