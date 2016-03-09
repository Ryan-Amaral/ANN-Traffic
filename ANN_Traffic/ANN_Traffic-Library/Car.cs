using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ANN_Traffic_Library
{
    public class Car : Sprite
    {
        /// <summary>
        /// The x coordinate of the car.
        /// </summary>
        public int X { get; set; }
        /// <summary>
        /// The y coordinate of the car.
        /// </summary>
        private int Y { get; set; }

        /// <summary>
        /// Tells if the car passed the finish.
        /// </summary>
        public bool IsFinished { get; set; }

        private int _finishLinePos; // the coordinate location of the finish line

        private int _width;
        private int _height;

        // direction to move to
        private Direction _direction;

        private Rectangle _carRect;
        private Rectangle _drawRect;

        private int _speed;

        /// <summary>
        /// Create a car with passing in the drawing area (the control the car is being drawn to), and others.
        /// </summary>
        /// <param name="drawArea"></param>
        public Car(Rectangle drawRect, int x, int y, int width, int height, Direction direction, int finishLinePos, int speed)
        {
            _carRect = new Rectangle(x, y, width, height);
            _drawRect = drawRect;
            _direction = direction;
            _finishLinePos = finishLinePos;
            _speed = speed;
        }

        /// <summary>
        /// Move the sprite in it's current direction, at it's speed.
        /// </summary>
        public void Move()
        {
            switch (_direction)
            {
                case Direction.Up:
                    _carRect.Y -= _speed;
                    Y = _carRect.Y;
                    if(Y <= _finishLinePos)
                    {
                        IsFinished = true;
                    }
                    break;
                case Direction.Down:
                    _carRect.Y += _speed;
                    Y = _carRect.Y;
                    if(Y + _height >= _finishLinePos)
                    {
                        IsFinished = true;
                    }
                    break;
                case Direction.Left:
                    _carRect.X -= _speed;
                    X = _carRect.X;
                    if(X <= _finishLinePos)
                    {
                        IsFinished = true;
                    }
                    break;
                case Direction.Right:
                    _carRect.X += _speed;
                    X = _carRect.X;
                    if(X + _width >= _finishLinePos)
                    {
                        IsFinished = true;
                    }
                    break;
            }
        }

        /// <summary>
        /// Draw the car to make it show up.
        /// </summary>
        /// <param name="graphics"></param>
        public void Draw(Graphics graphics)
        {
            throw new NotImplementedException();
        }
    }
}
