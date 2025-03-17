
using Ephemera.ElementModels;

namespace Ephemera.Managers
{
    public class WorldController
    {
        public List<ElementBase> Elements { get; private set; } = new List<ElementBase>();
        private List<ElementBase> toRemove = new List<ElementBase>();
        public int Width { get; private set; }
        public int Height { get; private set; }
        public int IntervalOfMomet { get; private set; } = 200;
        public void AddElement(ElementBase element)
        {
            Elements.Add(element);
        }
        public WorldController(int width, int height)
        {
            Width = width;
            Height = height;
        }


        public void MarkForDeletion(ElementBase element)
        {
            toRemove.Add(element);
        }
        public bool CheckMainCollision(ElementBase a, ElementBase b)
        {
            int penetrationDepth = 3; // Максимально допустимое пересечение

            return a.X < b.X + b.Width + penetrationDepth && // Позволяем небольшой заход справа
                   a.X + a.Width > b.X - penetrationDepth && // Позволяем небольшой заход слева
                   a.Y < b.Y + b.Height + penetrationDepth && // Позволяем небольшой заход снизу
                   a.Y + a.Height > b.Y - penetrationDepth;   // Позволяем небольшой заход сверху

        }
        public bool CheckCollision(ElementBase a, ElementBase b)
        {
            int penetrationDepth = 3; // Максимально допустимое пересечение

            return a.X < b.X + b.Width - penetrationDepth && 
                   a.X + a.Width > b.X + penetrationDepth && 
                   a.Y < b.Y + b.Height + penetrationDepth &&
                   a.Y + a.Height > b.Y - penetrationDepth ;   
        }




        public void UpdateAll()
        {
            foreach (var element in Elements)
            {
                element.Update(this);
                element.ApplyGravity(this); // Гравитация
            }

            // Удаляем сгоревшие элементы
            foreach (var e in toRemove)
            {
                Elements.Remove(e);
            }
            toRemove.Clear();
        }
        public bool RandomChance(int percent)
        {
            return new Random().Next(100) < percent;
        }

        public void Reset()
        {
            Elements.Clear();
        }

    }

}
