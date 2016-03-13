using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ANN_Traffic_Library
{
    /// <summary>
    /// Just draws the neural network.
    /// </summary>
    public class NeuralNetworkDrawer
    {
        // the neurons, will be ellipse when drawn
        private Rectangle _iNeuron1;
        private Rectangle _iNeuron2;
        private Rectangle _iNeuron3;
        private Rectangle _iNeuron4;
        private Rectangle _oNeuron1;

        private Point _iNeuron1Point;
        private Point _iNeuron2Point;
        private Point _iNeuron3Point;
        private Point _iNeuron4Point;
        private Point _oNeuron1Point;

        private Pen _weightPen; // pen to draw the weight lines with

        private Rectangle _drawArea;

        private string _axis;
        private Point _axisPoint;

        /// <summary>
        /// Create what is needed to draw.
        /// </summary>
        public NeuralNetworkDrawer(Rectangle drawArea)
        {
            drawArea = _drawArea;

            int neuronWidth = 40;

            _iNeuron1 = new Rectangle(130, 30, neuronWidth, neuronWidth);
            _iNeuron2 = new Rectangle(130, 80, neuronWidth, neuronWidth);
            _iNeuron3 = new Rectangle(130, 130, neuronWidth, neuronWidth);
            _iNeuron4 = new Rectangle(130, 180, neuronWidth, neuronWidth);
            _oNeuron1 = new Rectangle(370, 105, neuronWidth, neuronWidth);

            _iNeuron1Point = new Point(_iNeuron1.X + (_iNeuron1.Width / 2), _iNeuron1.Y + (_iNeuron1.Height / 2));
            _iNeuron2Point = new Point(_iNeuron2.X + (_iNeuron2.Width / 2), _iNeuron2.Y + (_iNeuron2.Height / 2));
            _iNeuron3Point = new Point(_iNeuron3.X + (_iNeuron3.Width / 2), _iNeuron3.Y + (_iNeuron3.Height / 2));
            _iNeuron4Point = new Point(_iNeuron4.X + (_iNeuron4.Width / 2), _iNeuron4.Y + (_iNeuron4.Height / 2));
            _oNeuron1Point = new Point(_oNeuron1.X + (_oNeuron1.Width / 2), _oNeuron1.Y + (_oNeuron1.Height / 2));

            _weightPen = new Pen(Color.Wheat);

            _axisPoint = new Point(_oNeuron1.X, _oNeuron1.Y + (_oNeuron1.Height * 2));
        }

        public void DrawNeuralNetwork(Graphics graphics, NeuralNetwork neuralNetwork)
        {
            graphics.Clear(Color.FromArgb(255, 255, 192, 128));

            // draw weights

            _weightPen.Color = (neuralNetwork.IWeights[0] > 0) ? Color.Black : Color.Gray;
            _weightPen.Width = 10 * Math.Abs((float)neuralNetwork.IWeights[0] + (float)0.1);
            graphics.DrawLine(_weightPen, _iNeuron1Point, _oNeuron1Point);

            _weightPen.Color = (neuralNetwork.IWeights[1] > 0) ? Color.Black : Color.Gray;
            _weightPen.Width = 10 * Math.Abs((float)neuralNetwork.IWeights[1] + (float)0.1);
            graphics.DrawLine(_weightPen, _iNeuron2Point, _oNeuron1Point);

            _weightPen.Color = (neuralNetwork.IWeights[2] > 0) ? Color.Black : Color.Gray;
            _weightPen.Width = 10 * Math.Abs((float)neuralNetwork.IWeights[2] + (float)0.1);
            graphics.DrawLine(_weightPen, _iNeuron3Point, _oNeuron1Point);

            _weightPen.Color = (neuralNetwork.IWeights[3] > 0) ? Color.Black : Color.Gray;
            _weightPen.Width = 10 * Math.Abs((float)neuralNetwork.IWeights[3] + (float)0.1);
            graphics.DrawLine(_weightPen, _iNeuron4Point, _oNeuron1Point);

            // draw nodes

            graphics.FillEllipse(Brushes.Aqua, _iNeuron1);
            graphics.FillEllipse(Brushes.Aqua, _iNeuron2);
            graphics.FillEllipse(Brushes.Aqua, _iNeuron3);
            graphics.FillEllipse(Brushes.Aqua, _iNeuron4);
            graphics.FillEllipse(Brushes.Aqua, _oNeuron1);

            // draw node value strings

            graphics.DrawString(neuralNetwork.INeurons[0].ToString(), SystemFonts.DefaultFont, Brushes.Black, _iNeuron1.Location);
            graphics.DrawString(neuralNetwork.INeurons[1].ToString(), SystemFonts.DefaultFont, Brushes.Black, _iNeuron2.Location);
            graphics.DrawString(neuralNetwork.INeurons[2].ToString(), SystemFonts.DefaultFont, Brushes.Black, _iNeuron3.Location);
            graphics.DrawString(neuralNetwork.INeurons[3].ToString(), SystemFonts.DefaultFont, Brushes.Black, _iNeuron4.Location);
            graphics.DrawString(neuralNetwork.ONeuron.ToString(), SystemFonts.DefaultFont, Brushes.Black, _oNeuron1.Location);

            // say what axis is currently moving
            _axis = (neuralNetwork.OutDirection == Axis.Horizontal) ? "Horizontal" : "Vertical";
            graphics.DrawString("Moving Axis: " + _axis, SystemFonts.DefaultFont, Brushes.Black, _axisPoint);
        }
    }
}
