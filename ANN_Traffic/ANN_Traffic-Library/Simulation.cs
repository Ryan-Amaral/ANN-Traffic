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


        /// <summary>
        /// How many generations to run the simulation for.
        /// </summary>
        public int Generations { get; set; }

        /// <summary>
        /// The generation we are currently on.
        /// </summary>
        public int CurrentGeneration { get; set; }

        /// <summary>
        /// The amount of organisms to do per generation.
        /// </summary>
        public int OrganismsPerGeneration { get; set; }

        /// <summary>
        /// What organism we are into the generation.
        /// </summary>
        public int CurrentOrganismInGeneration { get; set; }


        /// <summary>
        /// How far the car goes per update.
        /// </summary>
        public int CarSpeed { get; set; }

        /// <summary>
        /// How many updates it takes to get to full speed.
        /// </summary>
        public int CarAcceleration { get; set; }

        /// <summary>
        /// The amount of updates it takes for a new car to spawn.
        /// </summary>
        public int CarSpawnRate { get; set; }

        private Scenery _scenery; // The scenery of the visual area
        private List<Car> _cars; // the cars

        private Rectangle _drawArea;// The full area to draw everything to


        private int _updatesSinceOrganismStart; // the amount of updates since the organism started
        private const int UPDATES_PER_ORGANISM = 500; // the amount of updates to do before using next organism 

        public Simulation(Rectangle drawArea, int gens, int orgsPerGen, int carSpeed, int carAccel, int carSpawnRate)
        {
            IsReady = true;
            _drawArea = drawArea;
            _scenery = new Scenery(drawArea);
            _updatesSinceOrganismStart = 0;

            Generations = gens;
            CurrentGeneration = 0;
            OrganismsPerGeneration = orgsPerGen;
            CurrentOrganismInGeneration = 0;
            CarSpeed = carSpeed;
            CarAcceleration = carAccel;
            CarSpawnRate = carSpawnRate;
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
                CurrentOrganismInGeneration++;
                // set new TrafficController or get new generation
                if (CurrentOrganismInGeneration == OrganismsPerGeneration)
                {
                    // spawn new generation
                    CurrentOrganismInGeneration = 0;
                }

                // use proper element in list of TrafficControllers
            }

            IsReady = true;
        }
    }
}
