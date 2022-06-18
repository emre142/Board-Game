using System;
using System.Windows.Forms;

namespace WindowsFormsApp
{
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Form3 f3 = new Form3();
            f3.ShowDialog();
        }
        private void button3_Click(object sender, EventArgs e)
        {
            GameForm game = new GameForm();
            game.ShowDialog();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            if(button4.Text == "Manager Screen") 
            {
                Managerscreen ms = new Managerscreen();
                ms.ShowDialog();
            }
            else
            {
                Managerscreen ms = new Managerscreen();
                ms.button2.Visible = false;
                ms.button4.Visible = false;
                ms.ShowDialog();
            }
            
        }

        private void button2_Click(object sender, EventArgs e)
        {
           Connection cnn = new Connection();
           this.Hide();
           cnn.ShowDialog();
        }
    }
}
