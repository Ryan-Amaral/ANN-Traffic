using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ANN_Traffic_Library
{
    /// <summary>
    /// The ANN to be used by traffic controller. (4-5-1)
    /// </summary>
    class NeuralNetwork
    {
        // this is a 4-5-1 neural network
         
        // input layer
        private float[] _iNeurons = new float[4];
        private float[,] _iWeights = new float[4,5];

        // hidden layer
        private float[] _hNeurons = new float[5];
        private float[] _hBiases = new float[5];
        private float[] _hWeights = new float[5];

        // output layer
        private float _oNeuron;
        private float _oBias;

        private Direction _outDirection; // what the neural net returns

        /// <summary>
        /// Take in the weights of the neural network.
        /// </summary>
        public NeuralNetwork(float[] weights)
        {
            _iWeights[0,0] = weights[0];
            _iWeights[0,1] = weights[1];
            _iWeights[0,2] = weights[2];
            _iWeights[0,3] = weights[3];
            _iWeights[0,4] = weights[4];
            _iWeights[1,0] = weights[5];
            _iWeights[1,1] = weights[6];
            _iWeights[1,2] = weights[7];
            _iWeights[1,3] = weights[8];
            _iWeights[1,4] = weights[9];
            _iWeights[2,0] = weights[10];
            _iWeights[2,1] = weights[11];
            _iWeights[2,2] = weights[12];
            _iWeights[2,3] = weights[13];
            _iWeights[2,4] = weights[14];
            _iWeights[3,0] = weights[15];
            _iWeights[3,1] = weights[16];
            _iWeights[3,2] = weights[17];
            _iWeights[3,3] = weights[18];
            _iWeights[3,4] = weights[19];
            _hBiases[0] = weights[20];
            _hBiases[1] = weights[21];
            _hBiases[2] = weights[22];
            _hBiases[3] = weights[23];
            _hBiases[4] = weights[24];
            _hWeights[0] = weights[25];
            _hWeights[1] = weights[26];
            _hWeights[2] = weights[27];
            _hWeights[3] = weights[28];
            _hWeights[4] = weights[29]; 
            _oBias = weights[30];

            // set initial neuron values
            for (int i = 0; i < 5; i++ )
            {
                _hNeurons[i] = 0f;
            }
            _oNeuron = 0;
        }

        /// <summary>
        /// The function to keep each neuron within a certain range.
        /// </summary>
        private float ActivationFunction(float inVal)
        {
            return (float)(2 / (1 + Math.Pow(Math.E, -2 * inVal)));
        }

        /// <summary>
        /// Runs the neural network, each car value must be passed in between 1 and zero, where 1 represents 100 cars.
        /// </summary>
        /// <param name="leftCar"></param>
        /// <param name="rightCar"></param>
        /// <param name="upCar"></param>
        /// <param name="downCar"></param>
        /// <returns></returns>
        public Axis ExecuteNeuronNetwork(float leftCar, float rightCar, float upCar, float downCar)
        {
            // input neuron values
            _iNeurons[0] = leftCar;
            _iNeurons[1] = rightCar;
            _iNeurons[2] = upCar;
            _iNeurons[3] = downCar;

            // get values for output neurons
            for (int i = 0; i < 5; i++ )
            {
                _hNeurons[i] = 0f;
                for (int j = 0; j < 4; j++)
                {
                    // hidden neuron i += input neuron j * input weight to hidden neuron i of neuron j
                    _hNeurons[i] += _iNeurons[j] * _iWeights[j, i];
                }
                _hNeurons[i] += _hBiases[i]; // add bias
                _hNeurons[i] = ActivationFunction(_hNeurons[i]); // apply activation function
            }

            // get value for output
            _oNeuron = 0f;
            for (int i = 0; i < 5; i++)
            {
                // output neuron += each hidden layer neuron times it's weight
                _oNeuron += _hNeurons[i] * _hWeights[i];
            }
            _oNeuron += _oBias; // add bias
            _oNeuron = ActivationFunction(_oNeuron); // apply activation function

            if(_oNeuron > 0.5f)
            {
                return Axis.Horizontal;
            }
            else
            {
                return Axis.Vertical;
            }
        }
    }
}
