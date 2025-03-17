
using Ephemera.Enums;
using Ephemera.Managers;

namespace Ephemera.ElementModels
{
    public abstract class ElementBase
    {
        public int X { get; set; }
        public int Y { get; set; }
        public int Width { get; set; } = 10;
        public int Height { get; set; } = 10;

        public BasicStates State { get;  set; } = BasicStates.Normal; // Начальное состояние

        public abstract void Draw(Graphics g); // Отрисовка элемента
        public virtual void Update(WorldController world) { } // Для обновления состояния
        public virtual void ApplyGravity(WorldController world)
        {
            if (Y >= world.Height - Height - 3)
                return; // Достигли дна, не двигаемся

            int maxFall = 5; // Максимальный шаг падения
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
                Y += actualFall; // Двигаемся вниз, но не проходим сквозь объекты
        }


        private bool CheckCollisionBelow(ElementBase other, int fallStep)
        {
            return X < other.X + other.Width &&
                   X + Width > other.X &&
                   Y + Height <= other.Y &&  // Убеждаемся, что объект сверху
                   Y + Height + fallStep >= other.Y; // Проверяем столкновение
        }




        protected virtual void IgniteOthers(WorldController world)
        {
            // Огонь может сжигать траву и дерево
            foreach (var element in world.Elements)
            {
                if (element is Soil)
                {
                    if (world.CheckCollision(this, element) )
                    {
                        element.State = BasicStates.Burning;
                    }
                }
            }
        }

    }

}
