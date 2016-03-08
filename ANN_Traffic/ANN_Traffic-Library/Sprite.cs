using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace ANN_Traffic_Library
{
    public interface Sprite
    {
        void Move();
        void Draw(Graphics graphics);
    }
}
