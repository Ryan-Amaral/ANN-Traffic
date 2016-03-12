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
        private Rectangle _hNeuron1;
        private Rectangle _hNeuron2;
        private Rectangle _hNeuron3;
        private Rectangle _hNeuron4;
        private Rectangle _hNeuron5;
        private Rectangle _oNeuron1;

        private Pen _weightPen; // pen to draw the weight lines with

        private Rectangle _drawArea;

        /// <summary>
        /// Create what is needed to draw.
        /// </summary>
        public NeuralNetworkDrawer(Rectangle drawArea)
        {
            drawArea = _drawArea;

            int neuronWidth = 40;

            _iNeuron1 = new Rectangle(80, 30, neuronWidth, neuronWidth);
            _iNeuron2 = new Rectangle(80, 80, neuronWidth, neuronWidth);
            _iNeuron3 = new Rectangle(80, 130, neuronWidth, neuronWidth);
            _iNeuron4 = new Rectangle(80, 180, neuronWidth, neuronWidth);
            _hNeuron1 = new Rectangle(250, 5, neuronWidth, neuronWidth);
            _hNeuron2 = new Rectangle(250, 55, neuronWidth, neuronWidth);
            _hNeuron3 = new Rectangle(250, 105, neuronWidth, neuronWidth);
            _hNeuron4 = new Rectangle(250, 155, neuronWidth, neuronWidth);
            _hNeuron5 = new Rectangle(250, 205, neuronWidth, neuronWidth);
            _oNeuron1 = new Rectangle(420, 105, neuronWidth, neuronWidth);

            _weightPen = new Pen(Color.Wheat);
        }

        public void DrawNeuralNetwork(Graphics graphics, NeuralNetwork neuralNetwork)
        {
            graphics.Clear(Color.FromArgb(255, 255, 192, 128));

            _weightPen.Color = (neuralNetwork._iWeights[0,0] > 0) ? Color.Black : Color.Gray;
            _weightPen.Width = 10 * Math.Abs((float)neuralNetwork._iWeights[0,0] + (float)0.1);

            graphics.FillEllipse(Brushes.Blue, _iNeuron1);
            graphics.FillEllipse(Brushes.Blue, _iNeuron2);
            graphics.FillEllipse(Brushes.Blue, _iNeuron3);
            graphics.FillEllipse(Brushes.Blue, _iNeuron4);
            graphics.FillEllipse(Brushes.Blue, _hNeuron1);
            graphics.FillEllipse(Brushes.Blue, _hNeuron2);
            graphics.FillEllipse(Brushes.Blue, _hNeuron3);
            graphics.FillEllipse(Brushes.Blue, _hNeuron4);
            graphics.FillEllipse(Brushes.Blue, _hNeuron5);
            graphics.FillEllipse(Brushes.Blue, _oNeuron1);
        }
    }
}
