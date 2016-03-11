using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ANN_Traffic_Library
{
    // event for when update
    public delegate void UpdatedHandler();
    public delegate void FinishedHandler();

    /// <summary>
    /// Where pretty much everything runs.
    /// </summary>
    public class Simulation
    {
        public event UpdatedHandler Updated;
        public event FinishedHandler Finished;

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
        // the cars
        private List<Car> _leftCars;
        private List<Car> _rightCars;
        private List<Car> _upCars;
        private List<Car> _downCars;

        private int _carWidth = 10;
        private int _carBuffer = 3;

        private Rectangle _drawArea;// The full area to draw everything to

        private int _updatesSinceOrganismStart; // the amount of updates since the organism started
        private const int UPDATES_PER_ORGANISM = 200; // the amount of updates to do before using next organism 

        // stuff for neural net
        private double _mutationProb;
        private double _stepSize;

        /// <summary>
        /// Tells when the simulation is over.
        /// </summary>
        public bool NeedStop { get; set; }

        private Axis _goAxis; // the direction that the cars can go in currently

        private Random _rand;
        private int _carRand;

        private int _carLeftSpawnX;
        private int _carLeftSpawnY;
        private int _carRightSpawnX;
        private int _carRightSpawnY;
        private int _carUpSpawnX;
        private int _carUpSpawnY;
        private int _carDownSpawnX;
        private int _carDownSpawnY;

        private List<Car> finishedCars;

        private const int _numGenes = 31; // amount of genes
        private double[,] _annGenes; // the genes for neural networks
        private TrafficController _trafficController; // what determines when to change light at intersections
        private double[] _tmpDoubleArr;

        public Simulation(Rectangle drawArea, int gens, int orgsPerGen, int carSpeed, int carAccel, int carSpawnRate, double mutationProb, double stepSize)
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

            _goAxis = Axis.Vertical;

            _leftCars = new List<Car>();
            _rightCars = new List<Car>();
            _upCars = new List<Car>();
            _downCars = new List<Car>();

            _carLeftSpawnX = (drawArea.Width / 3) - (_carWidth * 2);
            _carLeftSpawnY = (drawArea.Height / 2) + 5;
            _carRightSpawnX = 2 * (drawArea.Width / 3) + _carWidth;
            _carRightSpawnY = (drawArea.Height / 3) + 5;
            _carUpSpawnX = (drawArea.Width / 3) + 5;
            _carUpSpawnY = (drawArea.Height / 3) - (_carWidth * 2);
            _carDownSpawnX = (drawArea.Width / 2) + 5;
            _carDownSpawnY = 2 * (drawArea.Height / 3) + _carWidth;

            _rand = new Random();

            _annGenes = new double[_generations, _numGenes];

            // fill initial generation of genes
            for (int i = 0; i < _organismsPerGeneration; i++ )
            {
                for (int j = 0; j < _numGenes; j++)
                {
                    _annGenes[i, j] = (_rand.NextDouble() * 8) - 4; // rand value between 0 and 1
                }
            }

            _tmpDoubleArr = new double[_numGenes];
            // get first genes for traffic controller
            for (int i = 0; i < _numGenes; i++ )
            {
                _tmpDoubleArr[i] = _annGenes[0, i];
            }
            _trafficController = new TrafficController(new NeuralNetwork(_tmpDoubleArr));
        }

        /// <summary>
        /// The function called once a clock tick, which is regulated by form.
        /// If isDraw is true, the objects get drawn.
        /// </summary>
        public void Update(bool isDraw, Graphics graphics)
        {
            IsReady = false;

            _updatesSinceOrganismStart++;

            if (isDraw)
            {
                _scenery.Draw(graphics);
            }

            // get what axis to go to from TrafficController
            // log(x + 1) * 144.26951
            // log to make smaller values more significant
            _goAxis = _trafficController.DetermineAxis(Math.Log10(35 * ((double)_leftCars.Count / (double)100) + 1) * 0.64255,
                Math.Log10(35 * ((double)_rightCars.Count / (double)100) + 1) * 0.64255,
                Math.Log10(35 * ((double)_upCars.Count / 100) + 1) * 0.64255,
                Math.Log10(35 * ((double)_downCars.Count / (double)100) + 1) * 0.64255);

            // spawn new car
            if(_updatesSinceOrganismStart % 5 == 0){
                _carRand = _rand.Next(4);
                if (_carRand < 1 && _leftCars.Count < 100)
                {
                    // spawn left
                    if (_leftCars.Count == 0)
                    {
                        _leftCars.Add(new Car(
                            _drawArea, 
                            _carLeftSpawnX,
                            _carLeftSpawnY,
                            _carWidth,
                            _carWidth,
                            Direction.Right,
                            _drawArea.Width / 3,
                            _carSpeed
                            ));
                    }
                    else
                    {
                        _leftCars.Add(new Car(
                            _drawArea, 
                            _leftCars[_leftCars.Count - 1]._carRect.X - _carWidth - _carBuffer,
                            _carLeftSpawnY,
                            _carWidth,
                            _carWidth,
                            Direction.Right,
                            _drawArea.Width / 3,
                            _carSpeed
                            ));
                    }
                }
                else if (_carRand < 2 && _rightCars.Count < 100)
                {
                    // spawn right
                    if (_rightCars.Count == 0)
                    {
                        _rightCars.Add(new Car(
                            _drawArea,
                            _carRightSpawnX,
                            _carRightSpawnY,
                            _carWidth,
                            _carWidth,
                            Direction.Left,
                            (_drawArea.Width / 3) * 2,
                            _carSpeed
                            ));
                    }
                    else
                    {
                        _rightCars.Add(new Car(
                            _drawArea,
                            _rightCars[_rightCars.Count - 1]._carRect.X + _carWidth + _carBuffer,
                            _carRightSpawnY,
                            _carWidth,
                            _carWidth,
                            Direction.Left,
                            (_drawArea.Width / 3) * 2,
                            _carSpeed
                            ));
                    }
                }
                else if (_carRand < 3 && _upCars.Count < 100)
                {
                    // spawn up
                    if (_upCars.Count == 0)
                    {
                        _upCars.Add(new Car(
                            _drawArea,
                            _carUpSpawnX,
                            _carUpSpawnY,
                            _carWidth,
                            _carWidth,
                            Direction.Down,
                            _drawArea.Height / 3,
                            _carSpeed
                            ));
                    }
                    else
                    {
                        _upCars.Add(new Car(
                            _drawArea,
                            _carUpSpawnX,
                            _upCars[_upCars.Count - 1]._carRect.Y - _carWidth - _carBuffer,
                            _carWidth,
                            _carWidth,
                            Direction.Down,
                            _drawArea.Height / 3,
                            _carSpeed
                            ));
                    }
                }
                else if (_carRand < 4 && _downCars.Count < 100)
                {
                    // spawn down
                    if (_downCars.Count == 0)
                    {
                        _downCars.Add(new Car(
                            _drawArea,
                            _carDownSpawnX,
                            _carDownSpawnY,
                            _carWidth,
                            _carWidth,
                            Direction.Up,
                            (_drawArea.Height / 3) * 2,
                            _carSpeed
                            ));
                    }
                    else
                    {
                        _downCars.Add(new Car(
                            _drawArea,
                            _carDownSpawnX,
                            _downCars[_downCars.Count - 1]._carRect.Y + _carWidth + _carBuffer,
                            _carWidth,
                            _carWidth,
                            Direction.Up,
                            (_drawArea.Height / 3) * 2,
                            _carSpeed
                            ));
                    }
                }
            }

            // move cars
            if(_goAxis == Axis.Horizontal)
            {
                finishedCars = new List<Car>();
                foreach (Car car in _leftCars)
                {
                    car.Move();
                    if(isDraw)
                    {
                        car.Draw(graphics);
                    }
                    if(car.IsFinished)
                    {
                        finishedCars.Add(car);
                    }
                }
                // remove done cars
                foreach (Car delCar in finishedCars)
                {
                    _leftCars.Remove(delCar);
                }

                finishedCars = new List<Car>();
                foreach (Car car in _rightCars)
                {
                    car.Move();
                    if (isDraw)
                    {
                        car.Draw(graphics);
                    }
                    if (car.IsFinished)
                    {
                        finishedCars.Add(car);
                    }
                }
                // remove done cars
                foreach (Car delCar in finishedCars)
                {
                    _rightCars.Remove(delCar);
                }


                // just draw others
                foreach (Car car in _upCars)
                {
                    if (isDraw)
                    {
                        car.Draw(graphics);
                    }
                }
                foreach (Car car in _downCars)
                {
                    if (isDraw)
                    {
                        car.Draw(graphics);
                    }
                }
            }
            else
            {
                finishedCars = new List<Car>();
                foreach (Car car in _upCars)
                {
                    car.Move();
                    if (isDraw)
                    {
                        car.Draw(graphics);
                    }
                    if (car.IsFinished)
                    {
                        finishedCars.Add(car);
                    }
                }
                // remove done cars
                foreach (Car delCar in finishedCars)
                {
                    _upCars.Remove(delCar);
                }

                finishedCars = new List<Car>();
                foreach (Car car in _downCars)
                {
                    car.Move();
                    if (isDraw)
                    {
                        car.Draw(graphics);
                    }
                    if (car.IsFinished)
                    {
                        finishedCars.Add(car);
                    }
                }
                // remove done cars
                foreach (Car delCar in finishedCars)
                {
                    _downCars.Remove(delCar);
                }

                // just draw others
                foreach (Car car in _leftCars)
                {
                    if (isDraw)
                    {
                        car.Draw(graphics);
                    }
                }
                foreach (Car car in _rightCars)
                {
                    if (isDraw)
                    {
                        car.Draw(graphics);
                    }
                }
            }

            // add / subtract points in TrafficController
            foreach (Car car in _leftCars)
            {
                if(_goAxis == Axis.Horizontal)
                {
                    _trafficController.Points++;
                }
                else
                {
                    _trafficController.Points--;
                }
            }
            foreach (Car car in _rightCars)
            {
                if (_goAxis == Axis.Horizontal)
                {
                    _trafficController.Points++;
                }
                else
                {
                    _trafficController.Points--;
                }
            }
            foreach (Car car in _upCars)
            {
                if (_goAxis == Axis.Horizontal)
                {
                    _trafficController.Points--;
                }
                else
                {
                    _trafficController.Points++;
                }
            }
            foreach (Car car in _downCars)
            {
                if (_goAxis == Axis.Horizontal)
                {
                    _trafficController.Points--;
                }
                else
                {
                    _trafficController.Points++;
                }
            }

            // see if need new TrafficController
            if (_updatesSinceOrganismStart >= UPDATES_PER_ORGANISM)
            {
                // remove all cars
                _leftCars = new List<Car>();
                _rightCars = new List<Car>();
                _upCars = new List<Car>();
                _downCars = new List<Car>();


                // get score for current organism
                // see if score is better than best score
                if(_trafficController.Points > BestFitness)
                {
                    BestFitness = _trafficController.Points;
                }

                _updatesSinceOrganismStart = 0;
                CurrentOrganismInGeneration++;
                // set new TrafficController or get new generation
                if (CurrentOrganismInGeneration == _organismsPerGeneration)
                {
                    // new generation
                    CurrentOrganismInGeneration = 0;
                    CurrentGeneration++;

                    // do genetic algorithm stuff

                    if(CurrentGeneration == _generations)
                    {
                        // tell we are finished
                        if(Finished != null)
                        {
                            Finished();
                        }
                    }
                }

                // spawn new traffic controller
                for (int i = 0; i < _numGenes; i++)
                {
                    _tmpDoubleArr[i] = _annGenes[CurrentOrganismInGeneration, i];
                }
                _trafficController = new TrafficController(new NeuralNetwork(_tmpDoubleArr));
            }

            IsReady = true;
        }

        /// <summary>
        /// Keeps on calling update untill at end.
        /// </summary>
        public void AsyncUpdate()
        {
            while(!NeedStop)
            {
                Update(false, null);

                if (Updated != null && _updatesSinceOrganismStart % 100 == 0)
                {
                    Updated();
                }
            }
        }
    }
}