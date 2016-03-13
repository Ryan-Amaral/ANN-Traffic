using ANN_Traffic_Library;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ANN_Traffic_Presentation
{
    public partial class FormAnnTrafficMain : Form
    {
        private Simulation _simulation; // the simulation, that does most things
        private bool _isDraw = true; // determinces whether we will draw stuff

        private int _simSpeed = 100;
        private double _mutationProb = 0.10;
        private double _maxStepSize = 0.1;
        private int _organismsPerGen = 10;
        private int _generations = 500;
        private int _carSpeed = 9;
        private int _carAcceleration = 15;
        private int _carSpawnRate = 20;

        private int _curGen = 0;
        private int _bestFitness = -9999999;

        private Graphics _curGraphics;

        Thread _asap;

        private NeuralNetworkDrawer _annDrawer;

        public FormAnnTrafficMain()
        {
            InitializeComponent();
            timerSimulation.Stop();
        }

        /// <summary>
        /// Update ui when simulation updates.
        /// </summary>
        private void OnSimulationUpdated()
        {
            // update cur gen
            if(labelValCurrentGen.InvokeRequired)
            {
                MethodInvoker invoker = new MethodInvoker(
                        delegate
                        {
                            if (_simulation.CurrentGeneration != _curGen && _simulation.CurrentGeneration <= _generations)
                            {
                                _curGen = _simulation.CurrentGeneration;
                                labelValCurrentGen.Text = _curGen.ToString();
                            }
                        }
                    );
                labelValCurrentGen.BeginInvoke(invoker);
            }

            // ignore cur organism because too fast

            //update best score
            if(labelValBestFitness.InvokeRequired)
            {
                MethodInvoker invoker = new MethodInvoker(
                        delegate
                        {
                            if (_simulation.BestFitness > _bestFitness)
                            {
                                _bestFitness = _simulation.BestFitness;
                                labelValBestFitness.Text = _bestFitness.ToString();
                                labelValAchieved.Text = _simulation.CurrentGeneration.ToString();
                            }
                        }
                    );
                labelValBestFitness.BeginInvoke(invoker);
            }
        }

        private void UpdateANNInfo()
        {
            // say what organism we are on
            labelValOrganismInGen.Text = _simulation.CurrentOrganismInGeneration.ToString();

            if (_simulation.CurrentGeneration != _curGen)
            {
                _curGen = _simulation.CurrentGeneration;
                labelValCurrentGen.Text = _curGen.ToString();
            }

            // update ann info if needed
            if (_simulation.BestFitness > _bestFitness)
            {
                _bestFitness = _simulation.BestFitness;
                labelValBestFitness.Text = _bestFitness.ToString();
                labelValAchieved.Text = _simulation.CurrentGeneration.ToString();
            }

            //panelANNDrawArea.Invalidate(); // updates the ann visualization
            UpdateAnnVisual();
        }

        private void buttonStart_Click(object sender, EventArgs e)
        {
            StartSim();
        }

        private void buttonStop_Click(object sender, EventArgs e)
        {
            StopSim();
        }

        private void checkBoxDraw_CheckedChanged(object sender, EventArgs e)
        {
            _isDraw = checkBoxDraw.Checked;
        }

        private void comboBoxSimulationSpeed_SelectedIndexChanged(object sender, EventArgs e)
        {
            switch (comboBoxSimulationSpeed.SelectedIndex)
            {
                case 0:
                    _simSpeed = 500; // twice per second
                    break;
                case 1:
                    _simSpeed = 250;
                    break;
                case 2:
                    _simSpeed = 150;
                    break;
                case 3:
                    _simSpeed = 50;
                    break;
                case 4:
                    _simSpeed = 1;
                    break;
                case 5:
                    _simSpeed = 2; // can't be zero but 2 will do
                    break;
            }

            timerSimulation.Interval = _simSpeed;
        }

        private void comboBoxMutationProb_SelectedIndexChanged(object sender, EventArgs e)
        {
            switch (comboBoxMutationProb.SelectedIndex)
            {
                case 0:
                    _mutationProb = 0.01f;
                    break;
                case 1:
                    _mutationProb = 0.05f;
                    break;
                case 2:
                    _mutationProb = 0.1f;
                    break;
                case 3:
                    _mutationProb = 0.15f;
                    break;
                case 4:
                    _mutationProb = 0.2f;
                    break;
            }
        }

        private void comboBoxOrganismsPerGen_SelectedIndexChanged(object sender, EventArgs e)
        {
            _organismsPerGen = int.Parse(comboBoxOrganismsPerGen.SelectedItem.ToString());
        }

        private void comboBoxGenerations_SelectedIndexChanged(object sender, EventArgs e)
        {
            _generations = int.Parse(comboBoxGenerations.SelectedItem.ToString());
        }

        private void comboBoxMaxStep_SelectedIndexChanged(object sender, EventArgs e)
        {
            _maxStepSize = float.Parse(comboBoxStepSize.SelectedItem.ToString());
        }

        private void comboBoxCarSpeed_SelectedIndexChanged(object sender, EventArgs e)
        {
            switch (comboBoxSimulationSpeed.SelectedIndex)
            {
                case 0:
                    _carSpeed = 3;
                    break;
                case 1:
                    _carSpeed = 8;
                    break;
                case 2:
                    _carSpeed = 16;
                    break;
                case 3:
                    _carSpeed = 30;
                    break;
                case 4:
                    _carSpeed = 50;
                    break;
            }
        }

        private void comboBoxCarAcceleration_SelectedIndexChanged(object sender, EventArgs e)
        {
            switch (comboBoxSimulationSpeed.SelectedIndex)
            {
                case 0:
                    _carAcceleration = 25;
                    break;
                case 1:
                    _carAcceleration = 20;
                    break;
                case 2:
                    _carAcceleration = 15;
                    break;
                case 3:
                    _carAcceleration = 10;
                    break;
                case 4:
                    _carAcceleration = 5;
                    break;
                case 5:
                    _carAcceleration = 0;
                    break;
            }
        }

        private void comboBoxCarSpawnRate_SelectedIndexChanged(object sender, EventArgs e)
        {
            switch (comboBoxSimulationSpeed.SelectedIndex)
            {
                case 0:
                    _carSpawnRate = 20;
                    break;
                case 1:
                    _carSpawnRate = 15;
                    break;
                case 2:
                    _carSpawnRate = 10;
                    break;
                case 3:
                    _carSpawnRate = 5;
                    break;
                case 4:
                    _carSpawnRate = 2;
                    break;
            }
        }

        private void FormAnnTrafficMain_Load(object sender, EventArgs e)
        {
            comboBoxSimulationSpeed.SelectedIndex = 2;
            comboBoxMutationProb.SelectedIndex = 2;
            comboBoxStepSize.SelectedIndex = 2;
            comboBoxOrganismsPerGen.SelectedIndex = 2;
            comboBoxGenerations.SelectedIndex = 2;
            comboBoxCarSpeed.SelectedIndex = 2;
            comboBoxCarAcceleration.SelectedIndex = 2;
            comboBoxCarSpawnRate.SelectedIndex = 2;

            // don't really need to create here, just so initial draw can happen
            _simulation = new Simulation(panelTrafficDrawArea.DisplayRectangle,
                _generations, _organismsPerGen, _carSpeed, _carAcceleration, _carSpawnRate, _mutationProb, _maxStepSize);

            _annDrawer = new NeuralNetworkDrawer(panelANNDrawArea.ClientRectangle);
            
        }

        private void timerSimulation_Tick(object sender, EventArgs e)
        {
            // stop if at the end of simulation
            if (_simulation.NeedStop)
            {
                StopSim();
                return;
            }

            //panelTrafficDrawArea.Invalidate(); // updates the simulation
            UpdateTrafficVisual();

            UpdateANNInfo();
        }

        /// <summary>
        /// Updates the visuals in the traffic.
        /// </summary>
        private void UpdateTrafficVisual()
        {
            _curGraphics = panelTrafficDrawArea.CreateGraphics();

            if (_simulation.IsReady)
            {
                _simulation.Update(_isDraw, _curGraphics); // update the simulation and draw if needed
            }
        }

        /// <summary>
        /// Updates the visuals in the ANN.
        /// </summary>
        private void UpdateAnnVisual()
        {
            // just draw it here
            _curGraphics = panelANNDrawArea.CreateGraphics();
            if (_simulation.TrafficController != null && _isDraw)
            {
                _annDrawer.DrawNeuralNetwork(_curGraphics, _simulation.TrafficController.NeuralNetwork);
            }
        }

        /// <summary>
        /// Does what needs to be done to start the simulation.
        /// </summary>
        private void StartSim()
        {
            // create the simulation
            _simulation = new Simulation(panelTrafficDrawArea.DisplayRectangle,
                _generations, _organismsPerGen, _carSpeed, _carAcceleration, _carSpawnRate, _mutationProb, _maxStepSize);

            _bestFitness = -9999999;

            // disable buttons
            comboBoxSimulationSpeed.Enabled = false;
            comboBoxMutationProb.Enabled = false;
            comboBoxStepSize.Enabled = false;
            comboBoxOrganismsPerGen.Enabled = false;
            comboBoxGenerations.Enabled = false;
            comboBoxCarSpeed.Enabled = false;
            comboBoxCarAcceleration.Enabled = false;
            comboBoxCarSpawnRate.Enabled = false;
            checkBoxDraw.Enabled = false;
            buttonStart.Enabled = false;
            buttonStop.Enabled = true;

            _simulation.Finished += new FinishedHandler(OnSimulationFinished);

            if(_simSpeed != 2)
            {
                timerSimulation.Start();
            }
            else
            {
                _simulation.Updated += new UpdatedHandler(OnSimulationUpdated); // add listener
                DoAsapSim();
            }
        }

        /// <summary>
        /// Finish and save best scoring ann to file.
        /// </summary>
        private void OnSimulationFinished()
        {
            if (this.InvokeRequired)
            {
                MethodInvoker invoker = new MethodInvoker(
                        delegate
                        {
                            StopSim();
                        }
                    );
                this.BeginInvoke(invoker);
            }
            else
            {
                StopSim();
            }
            
        }

        /// <summary>
        /// Uses separate thread to run sim as fast as possible, drawing off.
        /// </summary>
        private void DoAsapSim()
        {
            _asap = new Thread(_simulation.AsyncUpdate);
            _asap.Name = "ASAP";
            _asap.Start();
        }

        /// <summary>
        /// Does stuff to stop simulation.
        /// </summary>
        private void StopSim()
        {
            // enable buttons
            comboBoxSimulationSpeed.Enabled = true;
            comboBoxMutationProb.Enabled = true;
            comboBoxStepSize.Enabled = true;
            comboBoxOrganismsPerGen.Enabled = true;
            comboBoxGenerations.Enabled = true;
            comboBoxCarSpeed.Enabled = true;
            comboBoxCarAcceleration.Enabled = true;
            comboBoxCarSpawnRate.Enabled = true;
            checkBoxDraw.Enabled = true;
            buttonStart.Enabled = true;
            buttonStop.Enabled = false;

            labelValAchieved.Text = "--";
            labelValBestFitness.Text = "--";
            labelValCurrentGen.Text = "--";
            labelValOrganismInGen.Text = "--";

            timerSimulation.Stop();

            _simulation.NeedStop = true;

            if(_asap != null && _asap.IsAlive)
            {
                _asap.Join();
            }
        }

        private void panelANNDrawArea_Paint(object sender, PaintEventArgs e)
        {
            // update the ann visual
        }

        private void FormAnnTrafficMain_FormClosing(object sender, FormClosingEventArgs e)
        {
            _simulation.NeedStop = true;
            if (_asap != null && _asap.IsAlive)
            {
                _asap.Join();
            }
        }
        
    }
}