namespace WindowsFormsApp
{
    partial class Form3
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
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.textBox2 = new System.Windows.Forms.TextBox();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.radioButton4 = new System.Windows.Forms.RadioButton();
            this.radioButton3 = new System.Windows.Forms.RadioButton();
            this.radioButton2 = new System.Windows.Forms.RadioButton();
            this.radioButton1 = new System.Windows.Forms.RadioButton();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.checkBox3Round = new System.Windows.Forms.CheckBox();
            this.checkBox2Triangle = new System.Windows.Forms.CheckBox();
            this.checkBox1Square = new System.Windows.Forms.CheckBox();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.checkBox6Blue = new System.Windows.Forms.CheckBox();
            this.checkBox5Red = new System.Windows.Forms.CheckBox();
            this.checkBox4Green = new System.Windows.Forms.CheckBox();
            this.button1 = new System.Windows.Forms.Button();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.textBox2);
            this.groupBox1.Controls.Add(this.textBox1);
            this.groupBox1.Controls.Add(this.radioButton4);
            this.groupBox1.Controls.Add(this.radioButton3);
            this.groupBox1.Controls.Add(this.radioButton2);
            this.groupBox1.Controls.Add(this.radioButton1);
            this.groupBox1.Location = new System.Drawing.Point(56, 44);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(687, 110);
            this.groupBox1.TabIndex = 6;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Difficulty";
            // 
            // textBox2
            // 
            this.textBox2.Location = new System.Drawing.Point(532, 50);
            this.textBox2.Name = "textBox2";
            this.textBox2.Size = new System.Drawing.Size(44, 22);
            this.textBox2.TabIndex = 4;
            this.textBox2.Visible = false;
            this.textBox2.TextChanged += new System.EventHandler(this.textBox2_TextChanged_1);
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(482, 50);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(44, 22);
            this.textBox1.TabIndex = 4;
            this.textBox1.Visible = false;
            this.textBox1.TextChanged += new System.EventHandler(this.textBox1_TextChanged_1);
            // 
            // radioButton4
            // 
            this.radioButton4.AutoSize = true;
            this.radioButton4.Location = new System.Drawing.Point(394, 51);
            this.radioButton4.Name = "radioButton4";
            this.radioButton4.Size = new System.Drawing.Size(82, 20);
            this.radioButton4.TabIndex = 3;
            this.radioButton4.TabStop = true;
            this.radioButton4.Text = "Custom : ";
            this.radioButton4.UseVisualStyleBackColor = true;
            this.radioButton4.CheckedChanged += new System.EventHandler(this.radioButton4_CheckedChanged);
            // 
            // radioButton3
            // 
            this.radioButton3.AutoSize = true;
            this.radioButton3.Location = new System.Drawing.Point(272, 51);
            this.radioButton3.Name = "radioButton3";
            this.radioButton3.Size = new System.Drawing.Size(58, 20);
            this.radioButton3.TabIndex = 2;
            this.radioButton3.TabStop = true;
            this.radioButton3.Text = "Hard";
            this.radioButton3.UseVisualStyleBackColor = true;
            this.radioButton3.CheckedChanged += new System.EventHandler(this.radioButton3_CheckedChanged);
            // 
            // radioButton2
            // 
            this.radioButton2.AutoSize = true;
            this.radioButton2.Location = new System.Drawing.Point(152, 51);
            this.radioButton2.Name = "radioButton2";
            this.radioButton2.Size = new System.Drawing.Size(72, 20);
            this.radioButton2.TabIndex = 1;
            this.radioButton2.TabStop = true;
            this.radioButton2.Text = "Normal";
            this.radioButton2.UseVisualStyleBackColor = true;
            this.radioButton2.CheckedChanged += new System.EventHandler(this.radioButton2_CheckedChanged);
            // 
            // radioButton1
            // 
            this.radioButton1.AutoSize = true;
            this.radioButton1.Location = new System.Drawing.Point(34, 51);
            this.radioButton1.Name = "radioButton1";
            this.radioButton1.Size = new System.Drawing.Size(59, 20);
            this.radioButton1.TabIndex = 0;
            this.radioButton1.TabStop = true;
            this.radioButton1.Text = "Easy";
            this.radioButton1.UseVisualStyleBackColor = true;
            this.radioButton1.CheckedChanged += new System.EventHandler(this.radioButton1_CheckedChanged);
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.checkBox3Round);
            this.groupBox2.Controls.Add(this.checkBox2Triangle);
            this.groupBox2.Controls.Add(this.checkBox1Square);
            this.groupBox2.Location = new System.Drawing.Point(90, 204);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(255, 139);
            this.groupBox2.TabIndex = 7;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Shape Option";
            // 
            // checkBox3Round
            // 
            this.checkBox3Round.AutoSize = true;
            this.checkBox3Round.Location = new System.Drawing.Point(22, 88);
            this.checkBox3Round.Name = "checkBox3Round";
            this.checkBox3Round.Size = new System.Drawing.Size(69, 20);
            this.checkBox3Round.TabIndex = 2;
            this.checkBox3Round.Text = "Round";
            this.checkBox3Round.UseVisualStyleBackColor = true;
            // 
            // checkBox2Triangle
            // 
            this.checkBox2Triangle.AutoSize = true;
            this.checkBox2Triangle.Location = new System.Drawing.Point(22, 62);
            this.checkBox2Triangle.Name = "checkBox2Triangle";
            this.checkBox2Triangle.Size = new System.Drawing.Size(79, 20);
            this.checkBox2Triangle.TabIndex = 1;
            this.checkBox2Triangle.Text = "Triangle";
            this.checkBox2Triangle.UseVisualStyleBackColor = true;
            // 
            // checkBox1Square
            // 
            this.checkBox1Square.AutoSize = true;
            this.checkBox1Square.Location = new System.Drawing.Point(22, 36);
            this.checkBox1Square.Name = "checkBox1Square";
            this.checkBox1Square.Size = new System.Drawing.Size(73, 20);
            this.checkBox1Square.TabIndex = 0;
            this.checkBox1Square.Text = "Square";
            this.checkBox1Square.UseVisualStyleBackColor = true;
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.checkBox6Blue);
            this.groupBox3.Controls.Add(this.checkBox5Red);
            this.groupBox3.Controls.Add(this.checkBox4Green);
            this.groupBox3.Location = new System.Drawing.Point(432, 204);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(247, 139);
            this.groupBox3.TabIndex = 8;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Color Option";
            // 
            // checkBox6Blue
            // 
            this.checkBox6Blue.AutoSize = true;
            this.checkBox6Blue.Location = new System.Drawing.Point(18, 88);
            this.checkBox6Blue.Name = "checkBox6Blue";
            this.checkBox6Blue.Size = new System.Drawing.Size(56, 20);
            this.checkBox6Blue.TabIndex = 2;
            this.checkBox6Blue.Text = "Blue";
            this.checkBox6Blue.UseVisualStyleBackColor = true;
            // 
            // checkBox5Red
            // 
            this.checkBox5Red.AutoSize = true;
            this.checkBox5Red.Location = new System.Drawing.Point(18, 61);
            this.checkBox5Red.Name = "checkBox5Red";
            this.checkBox5Red.Size = new System.Drawing.Size(55, 20);
            this.checkBox5Red.TabIndex = 1;
            this.checkBox5Red.Text = "Red";
            this.checkBox5Red.UseVisualStyleBackColor = true;
            // 
            // checkBox4Green
            // 
            this.checkBox4Green.AutoSize = true;
            this.checkBox4Green.Location = new System.Drawing.Point(18, 35);
            this.checkBox4Green.Name = "checkBox4Green";
            this.checkBox4Green.Size = new System.Drawing.Size(66, 20);
            this.checkBox4Green.TabIndex = 0;
            this.checkBox4Green.Text = "Green";
            this.checkBox4Green.UseVisualStyleBackColor = true;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(351, 367);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 38);
            this.button1.TabIndex = 9;
            this.button1.Text = "Save";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // Form3
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Name = "Form3";
            this.Text = "Settings";
            this.Load += new System.EventHandler(this.Form3_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.TextBox textBox2;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.Button button1;
        public System.Windows.Forms.RadioButton radioButton4;
        public System.Windows.Forms.RadioButton radioButton3;
        public System.Windows.Forms.RadioButton radioButton2;
        public System.Windows.Forms.RadioButton radioButton1;
        public System.Windows.Forms.GroupBox groupBox1;
        public System.Windows.Forms.CheckBox checkBox3Round;
        public System.Windows.Forms.CheckBox checkBox2Triangle;
        public System.Windows.Forms.CheckBox checkBox1Square;
        public System.Windows.Forms.CheckBox checkBox6Blue;
        public System.Windows.Forms.CheckBox checkBox5Red;
        public System.Windows.Forms.CheckBox checkBox4Green;
    }
}