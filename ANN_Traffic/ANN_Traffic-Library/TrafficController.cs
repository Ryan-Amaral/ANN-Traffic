using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ANN_Traffic_Library
{
    /// <summary>
    /// The entity that will be using a neural network to learn when is best to change flow of traffic.
    /// </summary>
    class TrafficController
    {
        public int Points { get; set; }
        public NeuralNetwork NeuralNetwork { get; set; }

        public TrafficController(NeuralNetwork neuralNetwork)
        {
            Points = 0;
            NeuralNetwork = neuralNetwork;
        }

        /// <summary>
        /// Determines what axis cars can move in.
        /// </summary>
        /// <param name="leftCar"></param>
        /// <param name="rightCar"></param>
        /// <param name="upCar"></param>
        /// <param name="downCar"></param>
        /// <returns></returns>
        public Axis DetermineAxis(double leftCar, double rightCar, double upCar, double downCar)
        {
            return NeuralNetwork.ExecuteNeuralNetwork(leftCar, rightCar, upCar, downCar);
        }

        /// <summary>
        /// Makes this traffic controller use a new neural network.
        /// </summary>
        /// <param name="neuralNetwork"></param>
        public void NewNeuralNetwork(NeuralNetwork neuralNetwork)
        {
            NeuralNetwork = neuralNetwork;
        }
    }
}
