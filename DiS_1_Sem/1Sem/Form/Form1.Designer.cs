namespace Simulation
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            components = new System.ComponentModel.Container();
            label1 = new Label();
            textBox1 = new TextBox();
            button1 = new Button();
            label2 = new Label();
            label3 = new Label();
            label4 = new Label();
            label5 = new Label();
            formsPlot1 = new ScottPlot.FormsPlot();
            timer1 = new System.Windows.Forms.Timer(components);
            button2 = new Button();
            button4 = new Button();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(256, 18);
            label1.Name = "label1";
            label1.Size = new Size(56, 15);
            label1.TabIndex = 0;
            label1.Text = "Iterations";
            // 
            // textBox1
            // 
            textBox1.Location = new Point(318, 15);
            textBox1.Name = "textBox1";
            textBox1.Size = new Size(89, 23);
            textBox1.TabIndex = 1;
            // 
            // button1
            // 
            button1.Location = new Point(256, 56);
            button1.Name = "button1";
            button1.Size = new Size(151, 23);
            button1.TabIndex = 2;
            button1.Text = "Simulate";
            button1.UseVisualStyleBackColor = true;
            button1.Click += button1_Click;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(557, 18);
            label2.Name = "label2";
            label2.Size = new Size(0, 15);
            label2.TabIndex = 3;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(557, 56);
            label3.Name = "label3";
            label3.Size = new Size(0, 15);
            label3.TabIndex = 4;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(513, 18);
            label4.Name = "label4";
            label4.Size = new Size(43, 15);
            label4.TabIndex = 5;
            label4.Text = "Task A:";
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(513, 56);
            label5.Name = "label5";
            label5.Size = new Size(42, 15);
            label5.TabIndex = 6;
            label5.Text = "Task B:";
            // 
            // formsPlot1
            // 
            formsPlot1.Location = new Point(46, 94);
            formsPlot1.Margin = new Padding(4, 3, 4, 3);
            formsPlot1.Name = "formsPlot1";
            formsPlot1.Size = new Size(706, 346);
            formsPlot1.TabIndex = 7;
            // 
            // timer1
            // 
            timer1.Tick += timerRender_Tick;
            // 
            // button2
            // 
            button2.Location = new Point(413, 56);
            button2.Name = "button2";
            button2.Size = new Size(75, 23);
            button2.TabIndex = 8;
            button2.Text = "STOP";
            button2.UseVisualStyleBackColor = true;
            button2.Click += button2_Click;
            // 
            // button4
            // 
            button4.Location = new Point(12, 12);
            button4.Name = "button4";
            button4.Size = new Size(94, 23);
            button4.TabIndex = 12;
            button4.Text = "Main menu";
            button4.UseVisualStyleBackColor = true;
            button4.Click += button4_Click;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(button4);
            Controls.Add(button2);
            Controls.Add(formsPlot1);
            Controls.Add(label5);
            Controls.Add(label4);
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(button1);
            Controls.Add(textBox1);
            Controls.Add(label1);
            Name = "Form1";
            Text = "Form1";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private TextBox textBox1;
        private Button button1;
        private Label label2;
        private Label label3;
        private Label label4;
        private Label label5;
        private ScottPlot.FormsPlot formsPlot1;
        private System.Windows.Forms.Timer timer1;
        private Button button2;
        private Button button4;
    }
}