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
    public class NeuralNetwork
    {
        // this is a 4-5-1 neural network
         
        // input layer
        public double[] INeurons = new double[4];
        public double[] IWeights = new double[4];

        // no hidden layer

        // output layer
        public double ONeuron;
        //public double OBias;

        public Axis OutDirection; // what the neural net returns

        /// <summary>
        /// Take in the weights of the neural network.
        /// </summary>
        public NeuralNetwork(double[] weights)
        {
            IWeights[0] = weights[0];
            IWeights[1] = weights[1];
            IWeights[2] = weights[2];
            IWeights[3] = weights[3];
            //OBias = weights[4];

            // set initial neuron values
            ONeuron = 0;
        }

        /// <summary>
        /// The function to keep each neuron within a certain range.
        /// </summary>
        private double ActivationFunction(double inVal)
        {
            return (1.0 / (1.0 + Math.Pow(Math.E, -2.0 * inVal)));
        }

        /// <summary>
        /// Runs the neural network, each car value must be passed in between 1 and zero, where 1 represents 100 cars.
        /// </summary>
        /// <param name="leftCar"></param>
        /// <param name="rightCar"></param>
        /// <param name="upCar"></param>
        /// <param name="downCar"></param>
        /// <returns></returns>
        public Axis ExecuteNeuralNetwork(double leftCar, double rightCar, double upCar, double downCar)
        {
            // input neuron values
            INeurons[0] = leftCar;
            INeurons[1] = rightCar;
            INeurons[2] = upCar;
            INeurons[3] = downCar;

            // get value for output
            ONeuron = 0f;
            for (int i = 0; i < 4; i++)
            {
                // output neuron += each hidden layer neuron times it's weight
                ONeuron += INeurons[i] * IWeights[i];
            }
            //ONeuron += OBias; // add bias
            ONeuron = ActivationFunction(ONeuron); // apply activation function

            if (ONeuron > 0.5f)
            {
                OutDirection = Axis.Horizontal;
            }
            else
            {
                OutDirection = Axis.Vertical;
            }

            return OutDirection;
        }
    }
}
