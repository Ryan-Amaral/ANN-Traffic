using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ANN_Traffic_Library
{
    /// <summary>
    /// Where pretty much everything runs.
    /// </summary>
    public class Simulation
    {
        /// <summary>
        /// True when simulation is ready for clock tick.
        /// </summary>
        public bool IsReady { get; set; }

        private int _generations; // How many generations to run the simulation for.
        private int _organismsPerGeneration; // The amount of organisms to do per generation.
        private int _carSpeed; // How far the car goes per update.
        private int _carAcceleration; // How many updates it takes to get to full speed.
        private int _carSpawnRate; // The amount of updates it takes for a new car to spawn.

        /// <summary>
        /// The generation we are currently on.
        /// </summary>
        public int CurrentGeneration { get; set; }

        /// <summary>
        /// What organism we are into the generation.
        /// </summary>
        public int CurrentOrganismInGeneration { get; set; }

        /// <summary>
        /// The overall best fitness.
        /// </summary>
        public int BestFitness { get; set; }

        /// <summary>
        /// The fitness of the current organism.
        /// </summary>
        public int CurrentFitness { get; set; }


        private Scenery _scenery; // The scenery of the visual area
        private List<Car> _cars; // the cars

        private Rectangle _drawArea;// The full area to draw everything to

        private int _updatesSinceOrganismStart; // the amount of updates since the organism started
        private const int UPDATES_PER_ORGANISM = 500; // the amount of updates to do before using next organism 

        // stuff for neural net
        private float _mutationProb;
        private float _stepSize;

        /// <summary>
        /// Tells when the simulation is over.
        /// </summary>
        public bool NeedStop { get; set; }


        public Simulation(Rectangle drawArea, int gens, int orgsPerGen, int carSpeed, int carAccel, int carSpawnRate, float mutationProb, float stepSize)
        {
            IsReady = true;
            _drawArea = drawArea;
            _scenery = new Scenery(drawArea);
            _updatesSinceOrganismStart = 0;

            _generations = gens;
            CurrentGeneration = 0;
            _organismsPerGeneration = orgsPerGen;
            CurrentOrganismInGeneration = 0;
            _carSpeed = carSpeed;
            _carAcceleration = carAccel;
            _carSpawnRate = carSpawnRate;

            _mutationProb = mutationProb;
            _stepSize = stepSize;

            NeedStop = false;

            // set to extremely low
            BestFitness = -9999999;
        }

        /// <summary>
        /// The function called once a clock tick, which is regulated by form.
        /// If isDraw is true, the objects get drawn.
        /// </summary>
        public void Update(bool isDraw, Graphics graphics)
        {
            IsReady = false;

            _updatesSinceOrganismStart++;

            if(isDraw){
                _scenery.Draw(graphics);
            }

            // 

            // see if need new TrafficController
            if(_updatesSinceOrganismStart >= UPDATES_PER_ORGANISM)
            {
                // get score for current organism
                // see if score is better than best score

                CurrentOrganismInGeneration++;
                // set new TrafficController or get new generation
                if (CurrentOrganismInGeneration == _organismsPerGeneration)
                {
                    // spawn new generation
                    CurrentOrganismInGeneration = 0;
                    CurrentGeneration++;
                }

                // use proper element in list of TrafficControllers
            }

            IsReady = true;
        }
    }
}
