using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ANN_Traffic_Library
{
    public class Scenery : Sprite
    {
        private Rectangle _drawRect;

        private Rectangle _roadHor;
        private Rectangle _roadVer;
        private Rectangle _stopLineLeft;
        private Rectangle _stopLineRight;
        private Rectangle _stopLineUp;
        private Rectangle _stopLineDown;



        public Scenery(Rectangle drawRect)
        {
            _drawRect = drawRect;

            // vertical road
            _roadVer = new Rectangle(
                    _drawRect.Width / 3,
                    0,
                    _drawRect.Width / 3,
                    _drawRect.Height);

            // horizontal road
            _roadHor = new Rectangle(
                    0,
                    _drawRect.Height / 3,
                    _drawRect.Width,
                    _drawRect.Height / 3);

            // road line left
            _stopLineLeft = new Rectangle(
                    (_drawRect.Width / 3) - 10,
                    _drawRect.Height / 2,
                    5,
                    _drawRect.Height / 6);

            // road line right
            _stopLineRight = new Rectangle(
                    (_drawRect.Width * 2 / 3) + 5,
                    _drawRect.Height / 3,
                    5,
                    _drawRect.Height / 6);

            // road line up
            _stopLineUp = new Rectangle(
                    _drawRect.Width / 3,
                    (_drawRect.Height / 3) - 10,
                    _drawRect.Width / 6,
                    5);

            // road line down
            _stopLineDown = new Rectangle(
                    _drawRect.Width / 2,
                    (_drawRect.Height * 2 / 3) + 5,
                    _drawRect.Width / 6,
                    5);
        }

        public void Move()
        {
            
        }

        public void Draw(System.Drawing.Graphics graphics)
        {
            // since scenery always stays the same just put all in here
            // road is one third size
            
            // vertical road
            graphics.FillRectangle(Brushes.SlateGray, _roadVer);

            // horizontal road
            graphics.FillRectangle(Brushes.SlateGray, _roadHor);

            // road line left
            graphics.FillRectangle(Brushes.White, _stopLineLeft);

            // road line right
            graphics.FillRectangle(Brushes.White, _stopLineRight);

            // road line up
            graphics.FillRectangle(Brushes.White, _stopLineUp);

            // road line down
            graphics.FillRectangle(Brushes.White, _stopLineDown);
        }
    }
}
