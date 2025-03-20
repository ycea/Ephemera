
using Ephemera.Enums;
using Ephemera.Managers;
namespace Ephemera.ElementModels
{
    public class Water : ElementBase
    {
        private int waterHp = 2;
        public Water(int x, int y)
        {
            X = x;
            Y = y;
            State = BasicStates.Wet;
            currentColor = Color.Blue;
        }
        public override void Draw(Graphics g)
        {
            Brush waterBrush = new SolidBrush(Color.FromArgb(Math.Min(255, fadeTime * 10), currentColor));
            g.FillRectangle(waterBrush, X, Y, Width, Height);

        }
        public override void ApplyGravity(WorldController world)
        {
            base.ApplyGravity(world);
            Random rand = new Random();
            int flowSpeed = 2;
            bool canMoveLeft = true;
            bool canMoveRight = true;
            bool hitFromAbove = false; // Флаг удара сверху
           
            if(X + Width >= world.Width)
            {
                canMoveRight = false;
            }
            if(X <= 0)
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
                int maxDecision = 1000;
                int chooseChance = rand.Next(maxDecision);
                // Если оба направления открыты, выбираем случайно
                if (chooseChance < maxDecision/4) this.X -= flowSpeed;
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
        

        public override void Update(WorldController world)
        {
            base.Update(world);
            if (State == BasicStates.Burning)
            {
                waterHp--;
                if ((waterHp <= 0))
                {
                    world.MarkForDeletion(this);
                    return;

                }
            }
            ChangeOthersStates(world, BasicStates.Wet);

        }
    }
}
