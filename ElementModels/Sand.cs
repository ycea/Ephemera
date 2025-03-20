using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ephemera.ElementModels
{
    public class Sand : ElementBase
    {
        public Sand(int x, int y)
        {
            X = x;
            Y = y;
            currentColor = Color.SandyBrown;
        }

        public override void Draw(Graphics g)
        {
            
            SolidBrush sandBrush = new SolidBrush(Color.FromArgb(Math.Min(255, fadeTime * 10), currentColor));
            g.FillRectangle(sandBrush, X, Y, Width, Height);

        }
        
    }
}
