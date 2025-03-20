
using Ephemera.Enums;
using Ephemera.Managers;

namespace Ephemera.ElementModels
{
    public abstract class ElementBase
    {
        public int X { get; set; }
        public int Y { get; set; }
        public int fadeTime { get; set; } = 100;
        public int Width { get; set; } = 10;
        public int Height { get; set; } = 10;
        protected int weight { get; set; } = 5;
        public int inWaterTime { get; set; } = 0;
        public BasicStates State { get;  set; } = BasicStates.Normal; // Начальное состояние
        public Color currentColor { get; set; }
        public abstract void Draw(Graphics g); // Отрисовка элемента
        public virtual void Update(WorldController world) 
        {
            if (State == BasicStates.Wet && inWaterTime <= 200)
            {
                inWaterTime++;
            }
            else if(inWaterTime > 0)
            {
                inWaterTime--;
            }
            if(fadeTime > 15)
            {
                fadeTime--;
            }

        } // Для обновления состояния
        public virtual void ApplyGravity(WorldController world)
        {
            if (Y >= world.Height - Height - 3)
                return; // Достигли дна, не двигаемся

            int maxFall = weight; // Максимальный шаг падения
            int actualFall = maxFall; // Сколько реально можем упасть

            foreach (var element in world.Elements)
            {
                if (element != this)
                {
                    int distanceToElement = element.Y - (Y + Height); // Расстояние до объекта снизу
                    if (distanceToElement >= 0 && distanceToElement < actualFall && CheckCollisionBelow(element, distanceToElement))
                    {
                        actualFall = distanceToElement; // Корректируем шаг падения, чтобы не провалиться
                    }
                }
            }

            if (actualFall > 0)
                Y += actualFall ; // Двигаемся вниз, но не проходим сквозь объекты
        }

        private bool CheckCollisionBelow(ElementBase other, int fallStep)
        {
            return X < other.X + other.Width &&
                   X + Width > other.X &&
                   Y + Height <= other.Y &&  // Убеждаемся, что объект сверху
                   Y + Height + fallStep >= other.Y; // Проверяем столкновение
        }




        protected virtual void ChangeOthersStates(WorldController world, BasicStates toChange)
        {
            int spreadRadius = Width; // Радиус распространения огня

            foreach (var element in world.Elements)
            {
                if ((element.State != BasicStates.Burnt && toChange == BasicStates.Burning)
                    || (toChange == BasicStates.Wet))
                {
                    // Вычисляем расстояние между центрами объектов
                    int dx = Math.Abs(this.X - element.X);
                    int dy = Math.Abs(this.Y - element.Y);

                    if (dx <= spreadRadius && dy <= spreadRadius)
                    {

                        element.State = toChange;
                        if(toChange == BasicStates.Wet)
                        {
                            world.MarkAsWet(element);
                        }
                        
                    }
                }
            }
        }


    }

}
