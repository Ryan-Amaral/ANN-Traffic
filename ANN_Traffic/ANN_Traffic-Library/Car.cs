﻿using System;
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
        /// Tells if the car passed the finish.
        /// </summary>
        public bool IsFinished { get; set; }

        private int _finishLinePos; // the coordinate location of the finish line

        private int _width;
        private int _height;

        // direction to move to
        private Direction _direction;

        public Rectangle CarRect;
        private Rectangle _drawRect;

        private int _speed;

        /// <summary>
        /// Create a car with passing in the drawing area (the control the car is being drawn to), and others.
        /// </summary>
        /// <param name="drawArea"></param>
        public Car(Rectangle drawRect, int x, int y, int width, int height, Direction direction, int finishLinePos, int speed)
        {
            CarRect = new Rectangle(x, y, width, height);
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
                    CarRect.Y -= _speed;
                    if (CarRect.Y <= _finishLinePos)
                    {
                        IsFinished = true;
                    }
                    break;
                case Direction.Down:
                    CarRect.Y += _speed;
                    if (CarRect.Y + _height >= _finishLinePos)
                    {
                        IsFinished = true;
                    }
                    break;
                case Direction.Left:
                    CarRect.X -= _speed;
                    if (CarRect.X <= _finishLinePos)
                    {
                        IsFinished = true;
                    }
                    break;
                case Direction.Right:
                    CarRect.X += _speed;
                    if (CarRect.X + _width >= _finishLinePos)
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
            graphics.FillRectangle(Brushes.Yellow, CarRect);
        }
    }
}
