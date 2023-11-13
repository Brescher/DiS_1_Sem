namespace Simulation.STK.Forms
{
    partial class GraphB
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
            formsPlot1 = new ScottPlot.FormsPlot();
            textBox1 = new TextBox();
            label1 = new Label();
            SuspendLayout();
            // 
            // button1
            // 
            button1.Location = new Point(12, 12);
            button1.Name = "button1";
            button1.Size = new Size(106, 23);
            button1.TabIndex = 0;
            button1.Text = "Main menu";
            button1.UseVisualStyleBackColor = true;
            button1.Click += button1_Click;
            // 
            // button2
            // 
            button2.Location = new Point(505, 12);
            button2.Name = "button2";
            button2.Size = new Size(75, 23);
            button2.TabIndex = 1;
            button2.Text = "Start";
            button2.UseVisualStyleBackColor = true;
            button2.Click += button2_Click;
            // 
            // button3
            // 
            button3.Location = new Point(124, 12);
            button3.Name = "button3";
            button3.Size = new Size(147, 23);
            button3.TabIndex = 2;
            button3.Text = "Main simulation";
            button3.UseVisualStyleBackColor = true;
            button3.Click += button3_Click;
            // 
            // formsPlot1
            // 
            formsPlot1.Location = new Point(12, 92);
            formsPlot1.Margin = new Padding(4, 3, 4, 3);
            formsPlot1.Name = "formsPlot1";
            formsPlot1.Size = new Size(775, 346);
            formsPlot1.TabIndex = 3;
            // 
            // textBox1
            // 
            textBox1.Location = new Point(438, 12);
            textBox1.Name = "textBox1";
            textBox1.Size = new Size(45, 23);
            textBox1.TabIndex = 5;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(325, 15);
            label1.Name = "label1";
            label1.Size = new Size(98, 15);
            label1.TabIndex = 6;
            label1.Text = "Number of clerks";
            // 
            // GraphB
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(label1);
            Controls.Add(textBox1);
            Controls.Add(formsPlot1);
            Controls.Add(button3);
            Controls.Add(button2);
            Controls.Add(button1);
            Name = "GraphB";
            Text = "GraphB";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button button1;
        private Button button2;
        private Button button3;
        private ScottPlot.FormsPlot formsPlot1;
        private TextBox textBox1;
        private Label label1;
    }
}