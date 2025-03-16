
using Ephemera.ElementModels;

namespace Ephemera.Managers
{
    public class WorldController
    {
        public List<ElementBase> Elements { get; private set; } = new List<ElementBase>();
        private List<ElementBase> toRemove = new List<ElementBase>();
        public int Width { get; private set; }
        public int Height { get; private set; }
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

        public bool CheckCollision(ElementBase a, ElementBase b)
        {
            return (Math.Abs(a.X - b.X) < a.Width) && (Math.Abs(a.Y - b.Y) < a.Height);
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
