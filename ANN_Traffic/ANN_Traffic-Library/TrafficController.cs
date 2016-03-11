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

        public TrafficController()
        {
            Points = 0;
        }
    }
}
