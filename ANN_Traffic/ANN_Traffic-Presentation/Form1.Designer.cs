namespace ANN_Traffic_Presentation
{
    partial class FormAnnTrafficMain
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.buttonStop = new System.Windows.Forms.Button();
            this.buttonStart = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.comboBoxCarSpawnRate = new System.Windows.Forms.ComboBox();
            this.labelCarSpawnRate = new System.Windows.Forms.Label();
            this.checkBoxDraw = new System.Windows.Forms.CheckBox();
            this.comboBoxSimulationSpeed = new System.Windows.Forms.ComboBox();
            this.comboBoxMutationProb = new System.Windows.Forms.ComboBox();
            this.comboBoxCarAcceleration = new System.Windows.Forms.ComboBox();
            this.comboBoxCarSpeed = new System.Windows.Forms.ComboBox();
            this.comboBoxOrganismsPerGen = new System.Windows.Forms.ComboBox();
            this.comboBoxGenerations = new System.Windows.Forms.ComboBox();
            this.comboBoxStepSize = new System.Windows.Forms.ComboBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.panelTrafficDrawArea = new System.Windows.Forms.Panel();
            this.groupBoxANN = new System.Windows.Forms.GroupBox();
            this.panelANNDrawArea = new System.Windows.Forms.Panel();
            this.labelValOrganismInGen = new System.Windows.Forms.Label();
            this.labelOrganismInGen = new System.Windows.Forms.Label();
            this.labelValCurrentGen = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.labelValAchieved = new System.Windows.Forms.Label();
            this.labelAchieved = new System.Windows.Forms.Label();
            this.labelValBestFitness = new System.Windows.Forms.Label();
            this.labelBestFitness = new System.Windows.Forms.Label();
            this.timerSimulation = new System.Windows.Forms.Timer(this.components);
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBoxANN.SuspendLayout();
            this.SuspendLayout();
            // 
            // buttonStop
            // 
            this.buttonStop.Enabled = false;
            this.buttonStop.Location = new System.Drawing.Point(160, 331);
            this.buttonStop.Name = "buttonStop";
            this.buttonStop.Size = new System.Drawing.Size(75, 23);
            this.buttonStop.TabIndex = 10;
            this.buttonStop.Text = "Stop";
            this.buttonStop.UseVisualStyleBackColor = true;
            this.buttonStop.Click += new System.EventHandler(this.buttonStop_Click);
            // 
            // buttonStart
            // 
            this.buttonStart.Location = new System.Drawing.Point(59, 331);
            this.buttonStart.Name = "buttonStart";
            this.buttonStart.Size = new System.Drawing.Size(75, 23);
            this.buttonStart.TabIndex = 9;
            this.buttonStart.Text = "Start";
            this.buttonStart.UseVisualStyleBackColor = true;
            this.buttonStart.Click += new System.EventHandler(this.buttonStart_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(6, 34);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(122, 17);
            this.label2.TabIndex = 3;
            this.label2.Text = "Simulation Speed:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(6, 106);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(100, 17);
            this.label4.TabIndex = 5;
            this.label4.Text = "Mutation Prob:";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(6, 58);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(136, 17);
            this.label5.TabIndex = 6;
            this.label5.Text = "Organisms per Gen:";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(6, 82);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(90, 17);
            this.label6.TabIndex = 7;
            this.label6.Text = "Generations:";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(6, 130);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(101, 17);
            this.label7.TabIndex = 8;
            this.label7.Text = "Max Step Size:";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(6, 181);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(79, 17);
            this.label8.TabIndex = 9;
            this.label8.Text = "Car Speed:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(6, 206);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(116, 17);
            this.label3.TabIndex = 11;
            this.label3.Text = "Car Acceleration:";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.comboBoxCarSpawnRate);
            this.groupBox1.Controls.Add(this.labelCarSpawnRate);
            this.groupBox1.Controls.Add(this.checkBoxDraw);
            this.groupBox1.Controls.Add(this.comboBoxSimulationSpeed);
            this.groupBox1.Controls.Add(this.comboBoxMutationProb);
            this.groupBox1.Controls.Add(this.comboBoxCarAcceleration);
            this.groupBox1.Controls.Add(this.comboBoxCarSpeed);
            this.groupBox1.Controls.Add(this.comboBoxOrganismsPerGen);
            this.groupBox1.Controls.Add(this.comboBoxGenerations);
            this.groupBox1.Controls.Add(this.comboBoxStepSize);
            this.groupBox1.Controls.Add(this.buttonStop);
            this.groupBox1.Controls.Add(this.buttonStart);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.label8);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.label7);
            this.groupBox1.Controls.Add(this.label6);
            this.groupBox1.Location = new System.Drawing.Point(12, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(295, 363);
            this.groupBox1.TabIndex = 4;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Configure";
            // 
            // comboBoxCarSpawnRate
            // 
            this.comboBoxCarSpawnRate.FormattingEnabled = true;
            this.comboBoxCarSpawnRate.Items.AddRange(new object[] {
            "Very Slow",
            "Slow",
            "Medium",
            "Fast",
            "Very Fast"});
            this.comboBoxCarSpawnRate.Location = new System.Drawing.Point(154, 227);
            this.comboBoxCarSpawnRate.Name = "comboBoxCarSpawnRate";
            this.comboBoxCarSpawnRate.Size = new System.Drawing.Size(121, 24);
            this.comboBoxCarSpawnRate.TabIndex = 13;
            this.comboBoxCarSpawnRate.SelectedIndexChanged += new System.EventHandler(this.comboBoxCarSpawnRate_SelectedIndexChanged);
            // 
            // labelCarSpawnRate
            // 
            this.labelCarSpawnRate.AutoSize = true;
            this.labelCarSpawnRate.Location = new System.Drawing.Point(6, 230);
            this.labelCarSpawnRate.Name = "labelCarSpawnRate";
            this.labelCarSpawnRate.Size = new System.Drawing.Size(114, 17);
            this.labelCarSpawnRate.TabIndex = 12;
            this.labelCarSpawnRate.Text = "Car Spawn Rate:";
            // 
            // checkBoxDraw
            // 
            this.checkBoxDraw.AutoSize = true;
            this.checkBoxDraw.Checked = true;
            this.checkBoxDraw.CheckState = System.Windows.Forms.CheckState.Checked;
            this.checkBoxDraw.Location = new System.Drawing.Point(154, 282);
            this.checkBoxDraw.Name = "checkBoxDraw";
            this.checkBoxDraw.Size = new System.Drawing.Size(70, 21);
            this.checkBoxDraw.TabIndex = 8;
            this.checkBoxDraw.Text = "Draw?";
            this.checkBoxDraw.UseVisualStyleBackColor = true;
            this.checkBoxDraw.CheckedChanged += new System.EventHandler(this.checkBoxDraw_CheckedChanged);
            // 
            // comboBoxSimulationSpeed
            // 
            this.comboBoxSimulationSpeed.FormattingEnabled = true;
            this.comboBoxSimulationSpeed.Items.AddRange(new object[] {
            "Very Slow",
            "Slow",
            "Medium",
            "Fast",
            "Very Fast",
            "ASAP"});
            this.comboBoxSimulationSpeed.Location = new System.Drawing.Point(154, 31);
            this.comboBoxSimulationSpeed.Name = "comboBoxSimulationSpeed";
            this.comboBoxSimulationSpeed.Size = new System.Drawing.Size(121, 24);
            this.comboBoxSimulationSpeed.TabIndex = 1;
            this.comboBoxSimulationSpeed.SelectedIndexChanged += new System.EventHandler(this.comboBoxSimulationSpeed_SelectedIndexChanged);
            // 
            // comboBoxMutationProb
            // 
            this.comboBoxMutationProb.FormattingEnabled = true;
            this.comboBoxMutationProb.Items.AddRange(new object[] {
            "Very Low",
            "Low",
            "Medium",
            "High",
            "Very High"});
            this.comboBoxMutationProb.Location = new System.Drawing.Point(154, 103);
            this.comboBoxMutationProb.Name = "comboBoxMutationProb";
            this.comboBoxMutationProb.Size = new System.Drawing.Size(121, 24);
            this.comboBoxMutationProb.TabIndex = 2;
            this.comboBoxMutationProb.SelectedIndexChanged += new System.EventHandler(this.comboBoxMutationProb_SelectedIndexChanged);
            // 
            // comboBoxCarAcceleration
            // 
            this.comboBoxCarAcceleration.FormattingEnabled = true;
            this.comboBoxCarAcceleration.Items.AddRange(new object[] {
            "Very Slow",
            "Slow",
            "Medium",
            "Fast",
            "Very Fast",
            "Instant"});
            this.comboBoxCarAcceleration.Location = new System.Drawing.Point(154, 203);
            this.comboBoxCarAcceleration.Name = "comboBoxCarAcceleration";
            this.comboBoxCarAcceleration.Size = new System.Drawing.Size(121, 24);
            this.comboBoxCarAcceleration.TabIndex = 7;
            this.comboBoxCarAcceleration.SelectedIndexChanged += new System.EventHandler(this.comboBoxCarAcceleration_SelectedIndexChanged);
            // 
            // comboBoxCarSpeed
            // 
            this.comboBoxCarSpeed.FormattingEnabled = true;
            this.comboBoxCarSpeed.Items.AddRange(new object[] {
            "Very Slow",
            "Slow",
            "Medium",
            "Fast",
            "Very Fast"});
            this.comboBoxCarSpeed.Location = new System.Drawing.Point(154, 178);
            this.comboBoxCarSpeed.Name = "comboBoxCarSpeed";
            this.comboBoxCarSpeed.Size = new System.Drawing.Size(121, 24);
            this.comboBoxCarSpeed.TabIndex = 6;
            this.comboBoxCarSpeed.SelectedIndexChanged += new System.EventHandler(this.comboBoxCarSpeed_SelectedIndexChanged);
            // 
            // comboBoxOrganismsPerGen
            // 
            this.comboBoxOrganismsPerGen.FormattingEnabled = true;
            this.comboBoxOrganismsPerGen.Items.AddRange(new object[] {
            "5",
            "10",
            "20",
            "50",
            "100"});
            this.comboBoxOrganismsPerGen.Location = new System.Drawing.Point(154, 55);
            this.comboBoxOrganismsPerGen.Name = "comboBoxOrganismsPerGen";
            this.comboBoxOrganismsPerGen.Size = new System.Drawing.Size(121, 24);
            this.comboBoxOrganismsPerGen.TabIndex = 3;
            this.comboBoxOrganismsPerGen.SelectedIndexChanged += new System.EventHandler(this.comboBoxOrganismsPerGen_SelectedIndexChanged);
            // 
            // comboBoxGenerations
            // 
            this.comboBoxGenerations.FormattingEnabled = true;
            this.comboBoxGenerations.Items.AddRange(new object[] {
            "10",
            "100",
            "500",
            "1000",
            "10000"});
            this.comboBoxGenerations.Location = new System.Drawing.Point(154, 79);
            this.comboBoxGenerations.Name = "comboBoxGenerations";
            this.comboBoxGenerations.Size = new System.Drawing.Size(121, 24);
            this.comboBoxGenerations.TabIndex = 4;
            this.comboBoxGenerations.SelectedIndexChanged += new System.EventHandler(this.comboBoxGenerations_SelectedIndexChanged);
            // 
            // comboBoxStepSize
            // 
            this.comboBoxStepSize.FormattingEnabled = true;
            this.comboBoxStepSize.Items.AddRange(new object[] {
            "0.1",
            "0.25",
            "0.5",
            "0.75",
            "1.0"});
            this.comboBoxStepSize.Location = new System.Drawing.Point(154, 127);
            this.comboBoxStepSize.Name = "comboBoxStepSize";
            this.comboBoxStepSize.Size = new System.Drawing.Size(121, 24);
            this.comboBoxStepSize.TabIndex = 5;
            this.comboBoxStepSize.SelectedIndexChanged += new System.EventHandler(this.comboBoxMaxStep_SelectedIndexChanged);
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.panelTrafficDrawArea);
            this.groupBox2.Location = new System.Drawing.Point(313, 12);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(457, 363);
            this.groupBox2.TabIndex = 5;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Traffic Visualization";
            // 
            // panelTrafficDrawArea
            // 
            this.panelTrafficDrawArea.BackColor = System.Drawing.Color.Green;
            this.panelTrafficDrawArea.Location = new System.Drawing.Point(7, 22);
            this.panelTrafficDrawArea.Name = "panelTrafficDrawArea";
            this.panelTrafficDrawArea.Size = new System.Drawing.Size(444, 335);
            this.panelTrafficDrawArea.TabIndex = 0;
            // 
            // groupBoxANN
            // 
            this.groupBoxANN.Controls.Add(this.panelANNDrawArea);
            this.groupBoxANN.Controls.Add(this.labelValOrganismInGen);
            this.groupBoxANN.Controls.Add(this.labelOrganismInGen);
            this.groupBoxANN.Controls.Add(this.labelValCurrentGen);
            this.groupBoxANN.Controls.Add(this.label1);
            this.groupBoxANN.Controls.Add(this.labelValAchieved);
            this.groupBoxANN.Controls.Add(this.labelAchieved);
            this.groupBoxANN.Controls.Add(this.labelValBestFitness);
            this.groupBoxANN.Controls.Add(this.labelBestFitness);
            this.groupBoxANN.Location = new System.Drawing.Point(12, 381);
            this.groupBoxANN.Name = "groupBoxANN";
            this.groupBoxANN.Size = new System.Drawing.Size(757, 354);
            this.groupBoxANN.TabIndex = 6;
            this.groupBoxANN.TabStop = false;
            this.groupBoxANN.Text = "ANN";
            // 
            // panelANNDrawArea
            // 
            this.panelANNDrawArea.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(128)))));
            this.panelANNDrawArea.Location = new System.Drawing.Point(9, 39);
            this.panelANNDrawArea.Name = "panelANNDrawArea";
            this.panelANNDrawArea.Size = new System.Drawing.Size(742, 309);
            this.panelANNDrawArea.TabIndex = 8;
            this.panelANNDrawArea.Paint += new System.Windows.Forms.PaintEventHandler(this.panelANNDrawArea_Paint);
            // 
            // labelValOrganismInGen
            // 
            this.labelValOrganismInGen.AutoSize = true;
            this.labelValOrganismInGen.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelValOrganismInGen.Location = new System.Drawing.Point(305, 18);
            this.labelValOrganismInGen.Name = "labelValOrganismInGen";
            this.labelValOrganismInGen.Size = new System.Drawing.Size(20, 17);
            this.labelValOrganismInGen.TabIndex = 7;
            this.labelValOrganismInGen.Text = "--";
            // 
            // labelOrganismInGen
            // 
            this.labelOrganismInGen.AutoSize = true;
            this.labelOrganismInGen.Location = new System.Drawing.Point(180, 18);
            this.labelOrganismInGen.Name = "labelOrganismInGen";
            this.labelOrganismInGen.Size = new System.Drawing.Size(119, 17);
            this.labelOrganismInGen.TabIndex = 6;
            this.labelOrganismInGen.Text = "Organism in Gen:";
            // 
            // labelValCurrentGen
            // 
            this.labelValCurrentGen.AutoSize = true;
            this.labelValCurrentGen.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelValCurrentGen.Location = new System.Drawing.Point(112, 18);
            this.labelValCurrentGen.Name = "labelValCurrentGen";
            this.labelValCurrentGen.Size = new System.Drawing.Size(20, 17);
            this.labelValCurrentGen.TabIndex = 5;
            this.labelValCurrentGen.Text = "--";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(16, 18);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(90, 17);
            this.label1.TabIndex = 4;
            this.label1.Text = "Current Gen:";
            // 
            // labelValAchieved
            // 
            this.labelValAchieved.AutoSize = true;
            this.labelValAchieved.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelValAchieved.Location = new System.Drawing.Point(661, 18);
            this.labelValAchieved.Name = "labelValAchieved";
            this.labelValAchieved.Size = new System.Drawing.Size(20, 17);
            this.labelValAchieved.TabIndex = 3;
            this.labelValAchieved.Text = "--";
            // 
            // labelAchieved
            // 
            this.labelAchieved.AutoSize = true;
            this.labelAchieved.Location = new System.Drawing.Point(539, 18);
            this.labelAchieved.Name = "labelAchieved";
            this.labelAchieved.Size = new System.Drawing.Size(116, 17);
            this.labelAchieved.TabIndex = 2;
            this.labelAchieved.Text = "Achieved in Gen:";
            // 
            // labelValBestFitness
            // 
            this.labelValBestFitness.AutoSize = true;
            this.labelValBestFitness.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelValBestFitness.Location = new System.Drawing.Point(461, 18);
            this.labelValBestFitness.Name = "labelValBestFitness";
            this.labelValBestFitness.Size = new System.Drawing.Size(20, 17);
            this.labelValBestFitness.TabIndex = 1;
            this.labelValBestFitness.Text = "--";
            // 
            // labelBestFitness
            // 
            this.labelBestFitness.AutoSize = true;
            this.labelBestFitness.Location = new System.Drawing.Point(366, 18);
            this.labelBestFitness.Name = "labelBestFitness";
            this.labelBestFitness.Size = new System.Drawing.Size(89, 17);
            this.labelBestFitness.TabIndex = 0;
            this.labelBestFitness.Text = "Best Fitness:";
            // 
            // timerSimulation
            // 
            this.timerSimulation.Tick += new System.EventHandler(this.timerSimulation_Tick);
            // 
            // FormAnnTrafficMain
            // 
            this.AcceptButton = this.buttonStart;
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(781, 741);
            this.Controls.Add(this.groupBoxANN);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Name = "FormAnnTrafficMain";
            this.Text = "ANN Traffic";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.FormAnnTrafficMain_FormClosing);
            this.Load += new System.EventHandler(this.FormAnnTrafficMain_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBoxANN.ResumeLayout(false);
            this.groupBoxANN.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button buttonStop;
        private System.Windows.Forms.Button buttonStart;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.ComboBox comboBoxOrganismsPerGen;
        private System.Windows.Forms.ComboBox comboBoxGenerations;
        private System.Windows.Forms.ComboBox comboBoxStepSize;
        private System.Windows.Forms.ComboBox comboBoxSimulationSpeed;
        private System.Windows.Forms.ComboBox comboBoxMutationProb;
        private System.Windows.Forms.ComboBox comboBoxCarAcceleration;
        private System.Windows.Forms.ComboBox comboBoxCarSpeed;
        private System.Windows.Forms.CheckBox checkBoxDraw;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Panel panelTrafficDrawArea;
        private System.Windows.Forms.GroupBox groupBoxANN;
        private System.Windows.Forms.Label labelValOrganismInGen;
        private System.Windows.Forms.Label labelOrganismInGen;
        private System.Windows.Forms.Label labelValCurrentGen;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label labelValAchieved;
        private System.Windows.Forms.Label labelAchieved;
        private System.Windows.Forms.Label labelValBestFitness;
        private System.Windows.Forms.Label labelBestFitness;
        private System.Windows.Forms.Panel panelANNDrawArea;
        private System.Windows.Forms.ComboBox comboBoxCarSpawnRate;
        private System.Windows.Forms.Label labelCarSpawnRate;
        private System.Windows.Forms.Timer timerSimulation;
    }
}

