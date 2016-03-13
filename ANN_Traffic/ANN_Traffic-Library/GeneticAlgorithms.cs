using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ANN_Traffic_Library
{
    /// <summary>
    /// Contains static functions to modify genes for the ANN.
    /// </summary>
    public class GeneticAlgorithms
    {
        /// <summary>
        /// Recombines for this ANN. Fixed for my ANN in this project.
        /// </summary>
        /// <param name="genes1"></param>
        /// <param name="genes2"></param>
        /// <param name="mutationProb"></param>
        /// <param name="stepSize"></param>
        /// <returns></returns>
        public static double[] CombineGenes(double[] genes1, double[] genes2, double mutationProb, double stepSize)
        {
            double[] outGenes = new double[5];

            // first four are weights, between -1 and +1
            for (int i = 0; i < 4; i++)
            {
                // 50% from either gene
                if(Utils.Random.NextDouble() > 0.5)
                {
                    outGenes[i] = genes1[i];
                }
                else
                {
                    outGenes[i] = genes2[i];
                }

                // mutate
                if(Utils.Random.NextDouble() > mutationProb)
                {
                    outGenes[i] += (Utils.Random.NextDouble() * (stepSize * 2)) - stepSize;
                    if(outGenes[i] > 1)
                    {
                        outGenes[i] = 1;
                    }
                    else if(outGenes[i] < -1)
                    {
                        outGenes[i] = -1;
                    }
                }
            }

            return outGenes;
        }
    }
}
