using ANN_Traffic_Library;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ANN_Traffic_Presentation
{
    public partial class FormAnnTrafficMain : Form
    {
        private Scenery _scenery;
        private bool isDraw = true;

        public FormAnnTrafficMain()
        {
            InitializeComponent();
        }

        private void buttonStart_Click(object sender, EventArgs e)
        {

        }

        private void buttonStop_Click(object sender, EventArgs e)
        {

        }

        private void checkBoxDraw_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void comboBoxSimulationSpeed_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void comboBoxMutationProb_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void comboBoxOrganismsPerGen_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void comboBoxGenerations_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void comboBoxMaxCarsPerQueue_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void comboBoxCarSpeed_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void comboBoxCarAcceleration_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void comboBoxCarSpawnRate_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void FormAnnTrafficMain_Load(object sender, EventArgs e)
        {
            _scenery = new Scenery(panelTrafficDrawArea.DisplayRectangle);
        }

        private void PanelTrafficDrawArea_Paint(object sender, PaintEventArgs e)
        {
            if(isDraw)
            {
                _scenery.Draw(e.Graphics);
            }
        }
    }
}
