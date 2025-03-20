
using Ephemera.Enums;
using Ephemera.Managers;

namespace Ephemera.ElementModels
{


    public class Soil : ElementBase
    {
        private GrassStates grassState; // Состояние травы
        private int grassGrowthTime; // Счетчик роста травы
        private int burnTime; // Время горения

        public Soil(int x, int y)
        {
            X = x;
            Y = y;
            State = BasicStates.Normal;
            grassState = GrassStates.None;
            currentColor = Color.Brown;
            grassGrowthTime = 0;
            burnTime = 0;
        }

        public override void Draw(Graphics g)
        {
            Brush soilBrush;
            Brush grassBrush = null;

            // Определяем цвет земли
            switch (State)
            {
                case BasicStates.Wet:
                    currentColor = Color.SaddleBrown;
                    break;
                case BasicStates.Burnt:
                    currentColor = Color.Gray;
                    break;
                default:
                    if(inWaterTime > 0)
                    {
                        currentColor = Color.SaddleBrown;
                        break;
                    }
                    currentColor = Color.Brown;
                    break;
            }
            soilBrush = new SolidBrush(Color.FromArgb(Math.Min(255, fadeTime * 10), currentColor));
            g.FillRectangle(soilBrush, X, Y, Width, Height);

            // Определяем цвет травы
            if (grassState == GrassStates.Growing || grassState == GrassStates.FullyGrown || grassState == GrassStates.Burning)
            {
                grassBrush = new SolidBrush(grassState == GrassStates.Burning ? Color.FromArgb(Math.Min(255, fadeTime * 10), Color.Orange)
                    : Color.FromArgb(Math.Min(255, fadeTime * 10), Color.Green));
                g.FillRectangle(grassBrush, X, Y, Width, Height / 4); // Покрываем верхнюю часть земли
            }
        }

        public override void Update(WorldController world)
        {
            base.Update(world);
            CheckGrassBurning();

            if (State == BasicStates.Burnt)
            {
                grassState = GrassStates.None; // На сгоревшей земле трава не растет
                return; // Выходим, больше ничего не обновляем
            }

            if (grassState == GrassStates.None && world.RandomChance(10))
            {
                grassState = GrassStates.Growing;
                grassGrowthTime = 0;
            }
            else if (grassState == GrassStates.Growing)
            {
                grassGrowthTime++;
                if (grassGrowthTime >= world.IntervalOfMomet / 10)
                {
                    grassState = GrassStates.FullyGrown;
                }
            }
            else if (grassState == GrassStates.Burning)
            {
                burnTime++;
                ChangeOthersStates(world, BasicStates.Burning);

                if (burnTime >= world.IntervalOfMomet /4)
                {
                    grassState = GrassStates.None;
                    State = BasicStates.Burnt; // Теперь земля становится навсегда Burnt
                    burnTime = 0;
                }
            }
        }


        public void CheckGrassBurning()
        {
            if (State == BasicStates.Burning)
            {
                if (grassState == GrassStates.Growing || grassState == GrassStates.FullyGrown)
                {
                    grassState = GrassStates.Burning;
                }
            }
            if(State == BasicStates.Wet && grassState == GrassStates.Burning)
            {
                grassState = GrassStates.None;
            }
        }
    }
}

