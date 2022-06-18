using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace WindowsFormsApp
{
    public partial class Connection : Form
    {
        public Connection()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Multiplayer newGame = new Multiplayer(false, textBox1.Text, textBox2.Text);
            Visible = false;
            if (!newGame.IsDisposed)
                newGame.ShowDialog();
            Visible = true;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Multiplayer newGame = new Multiplayer(true, "", textBox2.Text);
            Visible = false;
            if (!newGame.IsDisposed)
                newGame.ShowDialog();
            Visible = true;
        }
        private void Connection_Load(object sender, EventArgs e)
        {
            textBox1.Text = "192.168.1.121";
            textBox2.Text = "5732";
        }
    }
}
