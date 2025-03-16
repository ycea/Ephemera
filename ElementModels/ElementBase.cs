
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
            if (Y < world.Height - Height - 3) // Проверяем, не достиг ли элемент дна
            {
                Y += 5; // Смещаем элемент вниз (можно изменить значение)
            }
        }
        protected virtual void IgniteOthers(WorldController world)
        {
            // Огонь может сжигать траву и дерево
            foreach (var element in world.Elements)
            {
                if (element is Soil)
                {
                    if (world.CheckCollision(this, element))
                    {
                        element.State = BasicStates.Burning;
                    }
                }
            }
        }

    }

}
