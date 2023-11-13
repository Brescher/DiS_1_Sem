namespace Simulation.STK.Forms
{
    partial class Sim2
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
            button1 = new Button();
            button2 = new Button();
            button3 = new Button();
            button4 = new Button();
            checkBox1 = new CheckBox();
            textBox1 = new TextBox();
            label17 = new Label();
            label18 = new Label();
            textBox2 = new TextBox();
            label19 = new Label();
            textBox3 = new TextBox();
            label20 = new Label();
            textBox5 = new TextBox();
            textBox6 = new TextBox();
            label21 = new Label();
            label22 = new Label();
            textBox7 = new TextBox();
            trackBar1 = new TrackBar();
            dataGridView1 = new DataGridView();
            Column1 = new DataGridViewTextBoxColumn();
            Column2 = new DataGridViewTextBoxColumn();
            dataGridView2 = new DataGridView();
            Column3 = new DataGridViewTextBoxColumn();
            Column4 = new DataGridViewTextBoxColumn();
            Column9 = new DataGridViewTextBoxColumn();
            dataGridView3 = new DataGridView();
            Column5 = new DataGridViewTextBoxColumn();
            Column6 = new DataGridViewTextBoxColumn();
            Column7 = new DataGridViewTextBoxColumn();
            Column8 = new DataGridViewTextBoxColumn();
            checkBox2 = new CheckBox();
            label23 = new Label();
            label24 = new Label();
            button5 = new Button();
            button6 = new Button();
            button7 = new Button();
            label3 = new Label();
            label4 = new Label();
            label5 = new Label();
            ((System.ComponentModel.ISupportInitialize)trackBar1).BeginInit();
            ((System.ComponentModel.ISupportInitialize)dataGridView1).BeginInit();
            ((System.ComponentModel.ISupportInitialize)dataGridView2).BeginInit();
            ((System.ComponentModel.ISupportInitialize)dataGridView3).BeginInit();
            SuspendLayout();
            // 
            // button1
            // 
            button1.Location = new Point(12, 12);
            button1.Name = "button1";
            button1.Size = new Size(94, 23);
            button1.TabIndex = 0;
            button1.Text = "Main menu";
            button1.UseVisualStyleBackColor = true;
            button1.Click += button1_Click;
            // 
            // button2
            // 
            button2.Location = new Point(795, 18);
            button2.Name = "button2";
            button2.Size = new Size(168, 35);
            button2.TabIndex = 1;
            button2.Text = "Start";
            button2.UseVisualStyleBackColor = true;
            button2.Click += StartSim;
            // 
            // button3
            // 
            button3.Location = new Point(795, 59);
            button3.Name = "button3";
            button3.Size = new Size(168, 35);
            button3.TabIndex = 19;
            button3.Text = "Pause";
            button3.UseVisualStyleBackColor = true;
            button3.Click += PauseSim;
            // 
            // button4
            // 
            button4.Location = new Point(795, 99);
            button4.Name = "button4";
            button4.Size = new Size(168, 35);
            button4.TabIndex = 20;
            button4.Text = "Stop";
            button4.UseVisualStyleBackColor = true;
            button4.Click += StopSim;
            // 
            // checkBox1
            // 
            checkBox1.AutoSize = true;
            checkBox1.Location = new Point(394, 93);
            checkBox1.Name = "checkBox1";
            checkBox1.Size = new Size(91, 19);
            checkBox1.TabIndex = 21;
            checkBox1.Text = "Turbo mode";
            checkBox1.UseVisualStyleBackColor = true;
            // 
            // textBox1
            // 
            textBox1.Location = new Point(713, 18);
            textBox1.Name = "textBox1";
            textBox1.Size = new Size(41, 23);
            textBox1.TabIndex = 22;
            // 
            // label17
            // 
            label17.AutoSize = true;
            label17.Location = new Point(603, 21);
            label17.Name = "label17";
            label17.Size = new Size(98, 15);
            label17.TabIndex = 23;
            label17.Text = "Number of clerks";
            // 
            // label18
            // 
            label18.AutoSize = true;
            label18.Location = new Point(576, 58);
            label18.Name = "label18";
            label18.Size = new Size(125, 15);
            label18.TabIndex = 25;
            label18.Text = "Number of mechanics";
            // 
            // textBox2
            // 
            textBox2.Location = new Point(713, 55);
            textBox2.Name = "textBox2";
            textBox2.Size = new Size(41, 23);
            textBox2.TabIndex = 24;
            // 
            // label19
            // 
            label19.AutoSize = true;
            label19.Location = new Point(590, 134);
            label19.Name = "label19";
            label19.Size = new Size(164, 15);
            label19.TabIndex = 29;
            label19.Text = "Sleep time in seconds (0,2 - 2)";
            // 
            // textBox3
            // 
            textBox3.Location = new Point(713, 91);
            textBox3.Name = "textBox3";
            textBox3.Size = new Size(41, 23);
            textBox3.TabIndex = 28;
            // 
            // label20
            // 
            label20.AutoSize = true;
            label20.Location = new Point(510, 94);
            label20.Name = "label20";
            label20.Size = new Size(191, 15);
            label20.TabIndex = 30;
            label20.Text = "Interval of system event in minutes";
            // 
            // textBox5
            // 
            textBox5.Location = new Point(385, 18);
            textBox5.Name = "textBox5";
            textBox5.Size = new Size(100, 23);
            textBox5.TabIndex = 31;
            // 
            // textBox6
            // 
            textBox6.Location = new Point(385, 55);
            textBox6.Name = "textBox6";
            textBox6.Size = new Size(100, 23);
            textBox6.TabIndex = 32;
            // 
            // label21
            // 
            label21.AutoSize = true;
            label21.Location = new Point(232, 21);
            label21.Name = "label21";
            label21.Size = new Size(129, 15);
            label21.TabIndex = 33;
            label21.Text = "Number of replications";
            // 
            // label22
            // 
            label22.AutoSize = true;
            label22.Location = new Point(185, 55);
            label22.Name = "label22";
            label22.Size = new Size(176, 15);
            label22.TabIndex = 34;
            label22.Text = "Max time of simulation in hours";
            // 
            // textBox7
            // 
            textBox7.Location = new Point(1017, 18);
            textBox7.Multiline = true;
            textBox7.Name = "textBox7";
            textBox7.ReadOnly = true;
            textBox7.Size = new Size(361, 270);
            textBox7.TabIndex = 35;
            // 
            // trackBar1
            // 
            trackBar1.Location = new Point(594, 171);
            trackBar1.Maximum = 2000;
            trackBar1.Minimum = 200;
            trackBar1.Name = "trackBar1";
            trackBar1.Size = new Size(164, 45);
            trackBar1.TabIndex = 36;
            trackBar1.TickFrequency = 200;
            trackBar1.Value = 200;
            trackBar1.Scroll += trackBar1_Scroll;
            // 
            // dataGridView1
            // 
            dataGridView1.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridView1.Columns.AddRange(new DataGridViewColumn[] { Column1, Column2 });
            dataGridView1.Location = new Point(277, 336);
            dataGridView1.Name = "dataGridView1";
            dataGridView1.RowTemplate.Height = 25;
            dataGridView1.Size = new Size(251, 474);
            dataGridView1.TabIndex = 38;
            // 
            // Column1
            // 
            Column1.HeaderText = "ID";
            Column1.Name = "Column1";
            Column1.ReadOnly = true;
            // 
            // Column2
            // 
            Column2.HeaderText = "Place in system";
            Column2.Name = "Column2";
            Column2.ReadOnly = true;
            // 
            // dataGridView2
            // 
            dataGridView2.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridView2.Columns.AddRange(new DataGridViewColumn[] { Column3, Column4, Column9 });
            dataGridView2.Location = new Point(552, 336);
            dataGridView2.Name = "dataGridView2";
            dataGridView2.RowTemplate.Height = 25;
            dataGridView2.Size = new Size(350, 474);
            dataGridView2.TabIndex = 39;
            // 
            // Column3
            // 
            Column3.HeaderText = "ID";
            Column3.Name = "Column3";
            Column3.ReadOnly = true;
            // 
            // Column4
            // 
            Column4.HeaderText = "Current job";
            Column4.Name = "Column4";
            Column4.ReadOnly = true;
            // 
            // Column9
            // 
            Column9.HeaderText = "Customer ID";
            Column9.Name = "Column9";
            // 
            // dataGridView3
            // 
            dataGridView3.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridView3.Columns.AddRange(new DataGridViewColumn[] { Column5, Column6, Column7, Column8 });
            dataGridView3.Location = new Point(925, 336);
            dataGridView3.Name = "dataGridView3";
            dataGridView3.RowTemplate.Height = 25;
            dataGridView3.Size = new Size(453, 474);
            dataGridView3.TabIndex = 40;
            // 
            // Column5
            // 
            Column5.HeaderText = "ID";
            Column5.Name = "Column5";
            Column5.ReadOnly = true;
            // 
            // Column6
            // 
            Column6.HeaderText = "Current job";
            Column6.Name = "Column6";
            Column6.ReadOnly = true;
            // 
            // Column7
            // 
            Column7.HeaderText = "Type of car";
            Column7.Name = "Column7";
            Column7.ReadOnly = true;
            // 
            // Column8
            // 
            Column8.HeaderText = "Customer ID";
            Column8.Name = "Column8";
            // 
            // checkBox2
            // 
            checkBox2.AutoSize = true;
            checkBox2.Location = new Point(393, 118);
            checkBox2.Name = "checkBox2";
            checkBox2.Size = new Size(92, 19);
            checkBox2.TabIndex = 41;
            checkBox2.Text = "Track people";
            checkBox2.UseVisualStyleBackColor = true;
            checkBox2.CheckedChanged += checkBox2_CheckedChanged;
            // 
            // label23
            // 
            label23.AutoSize = true;
            label23.Location = new Point(594, 201);
            label23.Name = "label23";
            label23.Size = new Size(22, 15);
            label23.TabIndex = 42;
            label23.Text = "0,2";
            // 
            // label24
            // 
            label24.AutoSize = true;
            label24.Location = new Point(732, 201);
            label24.Name = "label24";
            label24.Size = new Size(22, 15);
            label24.TabIndex = 43;
            label24.Text = "2,0";
            // 
            // button5
            // 
            button5.Location = new Point(795, 140);
            button5.Name = "button5";
            button5.Size = new Size(168, 35);
            button5.TabIndex = 44;
            button5.Text = "Show statistics";
            button5.UseVisualStyleBackColor = true;
            button5.Click += ShowStatistics;
            // 
            // button6
            // 
            button6.Location = new Point(795, 181);
            button6.Name = "button6";
            button6.Size = new Size(168, 35);
            button6.TabIndex = 45;
            button6.Text = "Clerks / Customers in queue";
            button6.UseVisualStyleBackColor = true;
            button6.Click += button6_Click;
            // 
            // button7
            // 
            button7.Location = new Point(795, 222);
            button7.Name = "button7";
            button7.Size = new Size(168, 35);
            button7.TabIndex = 46;
            button7.Text = "Mechanics / Time in system";
            button7.UseVisualStyleBackColor = true;
            button7.Click += button7_Click;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(277, 308);
            label3.Name = "label3";
            label3.Size = new Size(117, 15);
            label3.TabIndex = 51;
            label3.Text = "Customers in system";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(552, 308);
            label4.Name = "label4";
            label4.Size = new Size(39, 15);
            label4.TabIndex = 52;
            label4.Text = "Clerks";
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(925, 308);
            label5.Name = "label5";
            label5.Size = new Size(64, 15);
            label5.TabIndex = 53;
            label5.Text = "Mechanics";
            // 
            // Sim2
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1390, 822);
            Controls.Add(label5);
            Controls.Add(label4);
            Controls.Add(label3);
            Controls.Add(button7);
            Controls.Add(button6);
            Controls.Add(button5);
            Controls.Add(label24);
            Controls.Add(label23);
            Controls.Add(checkBox2);
            Controls.Add(dataGridView3);
            Controls.Add(dataGridView2);
            Controls.Add(dataGridView1);
            Controls.Add(trackBar1);
            Controls.Add(textBox7);
            Controls.Add(label22);
            Controls.Add(label21);
            Controls.Add(textBox6);
            Controls.Add(textBox5);
            Controls.Add(label20);
            Controls.Add(label19);
            Controls.Add(textBox3);
            Controls.Add(label18);
            Controls.Add(textBox2);
            Controls.Add(label17);
            Controls.Add(textBox1);
            Controls.Add(checkBox1);
            Controls.Add(button4);
            Controls.Add(button3);
            Controls.Add(button2);
            Controls.Add(button1);
            Name = "Sim2";
            Text = "Sim2";
            Load += Sim2_Load;
            ((System.ComponentModel.ISupportInitialize)trackBar1).EndInit();
            ((System.ComponentModel.ISupportInitialize)dataGridView1).EndInit();
            ((System.ComponentModel.ISupportInitialize)dataGridView2).EndInit();
            ((System.ComponentModel.ISupportInitialize)dataGridView3).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button button1;
        private Button button2;
        private Button button3;
        private Button button4;
        private CheckBox checkBox1;
        private TextBox textBox1;
        private Label label17;
        private Label label18;
        private TextBox textBox2;
        private Label label19;
        private TextBox textBox3;
        private Label label20;
        private TextBox textBox5;
        private TextBox textBox6;
        private Label label21;
        private Label label22;
        private TextBox textBox7;
        private TrackBar trackBar1;
        private DataGridView dataGridView1;
        private DataGridView dataGridView2;
        private DataGridView dataGridView3;
        private CheckBox checkBox2;
        private Label label23;
        private Label label24;
        private Button button5;
        private DataGridViewTextBoxColumn Column1;
        private DataGridViewTextBoxColumn Column2;
        private DataGridViewTextBoxColumn Column3;
        private DataGridViewTextBoxColumn Column4;
        private DataGridViewTextBoxColumn Column5;
        private DataGridViewTextBoxColumn Column6;
        private DataGridViewTextBoxColumn Column7;
        private Button button6;
        private Button button7;
        private DataGridViewTextBoxColumn Column8;
        private DataGridViewTextBoxColumn Column9;
        private Label label3;
        private Label label4;
        private Label label5;
    }
}