
using Ephemera.ElementModels;
using Ephemera.Enums;
using System.Net.Http.Headers;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.Rebar;

namespace Ephemera.Managers
{
    public class WorldController
    {
        public List<ElementBase> Elements { get; private set; } = new List<ElementBase>();
        private List<ElementBase> toRemove = new List<ElementBase>();
        private HashSet<ElementBase> currentlyWet = new HashSet<ElementBase>();

        public int Width { get; private set; }
        public int Height { get; private set; }
        public int IntervalOfMomet { get; private set; } = 100;
        public double averageFade = 0;
        public bool isFinished = false;
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
                if (element.State == BasicStates.Wet && !currentlyWet.Contains(element))
                {

                    element.State = BasicStates.Normal;
                }
                element.ApplyGravity(this); // Гравитация
                averageFade += element.fadeTime;
            }
            averageFade /= Elements.Count;

            currentlyWet.Clear();
            

            List<ElementBase> toAddElems = new List<ElementBase>();

            // Отмечаем позиции, куда добавлять пар
            foreach (var e in toRemove)
            {
                if (e is Water)
                {
                    var s = new Steam(e.X,e.Y);
                    s.Width = e.Width;
                    s.Height = e.Height;
                    toAddElems.Add(s);
                }
                if(e is Stone)
                {
                    var s = new Sand(e.X, e.Y);
                    s.Width = e.Width;
                    s.Height = e.Height;
                    toAddElems.Add(s);
                }
                Elements.Remove(e);
            }
            toRemove.Clear();

            // Добавляем пар после удаления
            foreach (var elem in toAddElems)
            {
                Elements.Add(elem);
            }

        }
        public bool RandomChance(int percent)
        {
            return new Random().Next(100) < percent;
        }
        
        public void Reset()
        {
            Elements.Clear();
            averageFade = 0;
        }

        internal void MarkAsWet(ElementBase element)
        {
            currentlyWet.Add(element);
        }
    }

}
