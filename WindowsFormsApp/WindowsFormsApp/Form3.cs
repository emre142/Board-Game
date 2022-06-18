using System;
using System.Windows.Forms;

namespace WindowsFormsApp
{
    public partial class Form3 : Form
    {
     
        static public string a = "9", b = "9";
        static public int rdbtnindex = 0;

        public Form3()
        {
            InitializeComponent();
        }

        public void radioButton2_CheckedChanged(object sender, EventArgs e)
        {
            textBox1.Hide();
            textBox2.Hide();
            groupBox2.Hide();
            groupBox3.Hide();
            textBox1.Text = "";
            textBox2.Text = "";
            a = "9";
            b = "9";
            rdbtnindex = 2;
        }

        private void radioButton4_CheckedChanged(object sender, EventArgs e)
        {
            textBox1.Show();
            textBox2.Show();
            groupBox2.Show();
            groupBox3.Show();
            rdbtnindex = 4;
        }
        private void textBox1_TextChanged_1(object sender, EventArgs e)
        {
            int parsedValue;

            if (!int.TryParse(textBox1.Text, out parsedValue))
            {
                textBox1.Text = "";
            }
            a = textBox1.Text;

        }
        private void textBox2_TextChanged_1(object sender, EventArgs e)
        {
            int parsedValue2;

            if (!int.TryParse(textBox2.Text, out parsedValue2))
            {
                textBox2.Text = "";
            }
            b = textBox2.Text;
        }
        private void Form3_Load(object sender, EventArgs e)
        {
            checkBox1Square.Checked = Properties.Settings.Default.checkbox1;
            checkBox2Triangle.Checked = Properties.Settings.Default.checkbox2;
            checkBox3Round.Checked = Properties.Settings.Default.checkbox3;
            checkBox4Green.Checked = Properties.Settings.Default.checkbox4;
            checkBox5Red.Checked = Properties.Settings.Default.checkbox5;
            checkBox6Blue.Checked = Properties.Settings.Default.checkbox6;
            radioButton1.Checked = Properties.Settings.Default.radioButton1;
            radioButton2.Checked = Properties.Settings.Default.radioButton2;
            radioButton3.Checked = Properties.Settings.Default.radioButton3;
            radioButton4.Checked = Properties.Settings.Default.radioButton4;
            textBox1.Text = Properties.Settings.Default.textbox1;
            textBox2.Text = Properties.Settings.Default.textbox2;

        }

        private void button1_Click(object sender, EventArgs e)
        {

            if (radioButton4.Checked && (textBox1.Text == "" || textBox2.Text == "" || int.Parse(textBox1.Text) < 5 || int.Parse(textBox2.Text) < 5))
            {
                MessageBox.Show("Lütfen 5 veya 5'ten büyük tam sayı değerleri giriniz.","",MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else if (radioButton4.Checked && (checkBox1Square.Checked == false && checkBox2Triangle.Checked == false && checkBox3Round.Checked == false))
            {
                MessageBox.Show("Lütfen en az bir şekil seçiniz.", "", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else if (radioButton4.Checked && (checkBox4Green.Checked == false && checkBox5Red.Checked == false && checkBox6Blue.Checked == false))
            {
                MessageBox.Show("Lütfen en az bir renk seçiniz.", "", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else
            {
                Properties.Settings.Default.checkbox1 = checkBox1Square.Checked;
                Properties.Settings.Default.checkbox2 = checkBox2Triangle.Checked;
                Properties.Settings.Default.checkbox3 = checkBox3Round.Checked;
                Properties.Settings.Default.checkbox4 = checkBox4Green.Checked;
                Properties.Settings.Default.checkbox5 = checkBox5Red.Checked;
                Properties.Settings.Default.checkbox6 = checkBox6Blue.Checked;
                Properties.Settings.Default.radioButton1 = radioButton1.Checked;
                Properties.Settings.Default.radioButton2 = radioButton2.Checked;
                Properties.Settings.Default.radioButton3 = radioButton3.Checked;
                Properties.Settings.Default.radioButton4 = radioButton4.Checked;
                Properties.Settings.Default.textbox1 = textBox1.Text;
                Properties.Settings.Default.textbox2 = textBox2.Text;
                Properties.Settings.Default.Save();
                MessageBox.Show("Ayarlar kaydedildi.", "", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }

        }

        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {
            textBox1.Hide();
            textBox2.Hide();
            groupBox2.Hide();
            groupBox3.Hide();
            textBox1.Text = "";
            textBox2.Text = "";
            a = "15";
            b = "15";
            rdbtnindex = 1;
        }

        private void radioButton3_CheckedChanged(object sender, EventArgs e)
        {
            textBox1.Hide();
            textBox2.Hide();
            groupBox2.Hide();
            groupBox3.Hide();
            textBox1.Text = "";
            textBox2.Text = "";
            a = "6";
            b = "6";
            rdbtnindex = 3;
        }
    }
}
