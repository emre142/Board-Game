using Microsoft.VisualBasic;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp
{
    public partial class Managerscreen : Form
    {
        SqlConnection connection;
        SqlDataAdapter adapter;
        SqlCommand commandAdd;
        FormRegister fr = new FormRegister();
        public Managerscreen()
        {
            InitializeComponent();
        }

        public void Getir()
        {
            connection = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\OOPLAB2PROJECT\ooplab2-yedek\WindowsFormsApp\WindowsFormsApp\users.mdf;Integrated Security=True");
            connection.Open();
            if (Properties.Settings.Default.lastUsername != "admin")
                adapter = new SqlDataAdapter("select * from Table1 where username = '"+ Properties.Settings.Default.lastUsername + "' ", connection);
            else
                adapter = new SqlDataAdapter("select * from Table1", connection);

            DataTable table = new DataTable();
            adapter.Fill(table);
            dataGridView1.DataSource = table;
            connection.Close();
        }
        private void Managerscreen_Load(object sender, EventArgs e)
        {
            if (button4.Visible == false)
            {
                this.Text = "Profil Screen";
            }
            Getir();
        }
        private void dataGridView1_CellEnter(object sender, DataGridViewCellEventArgs e)
        {
            fr.textBox1.Text = dataGridView1.CurrentRow.Cells[0].Value.ToString();
            fr.textBox2.Text = "";
            fr.temp = dataGridView1.CurrentRow.Cells[1].Value.ToString();
            fr.textBox3.Text = dataGridView1.CurrentRow.Cells[2].Value.ToString();
            fr.textBox4.Text = dataGridView1.CurrentRow.Cells[3].Value.ToString();
            fr.textBox5.Text = dataGridView1.CurrentRow.Cells[4].Value.ToString();
            fr.textBox6.Text = dataGridView1.CurrentRow.Cells[5].Value.ToString();
            fr.textBox7.Text = dataGridView1.CurrentRow.Cells[6].Value.ToString();
            fr.textBox8.Text = dataGridView1.CurrentRow.Cells[7].Value.ToString();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            fr.button2.Text = "Add";
            fr.textBox1.Text = "";
            fr.textBox2.Text = "";
            fr.textBox3.Text = "";
            fr.textBox4.Text = "";
            fr.textBox5.Text = "";
            fr.textBox6.Text = "";
            fr.textBox7.Text = "";
            fr.textBox8.Text = "";
            fr.ShowDialog();
            Getir();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            DialogResult cevap;
            cevap = MessageBox.Show("Kullanıcıyı silmek istediğine emin misin?", "Pencere", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button2);
            if (DialogResult.OK == cevap)
            {
             string query = "DELETE FROM Table1 Where username=@username";
            commandAdd = new SqlCommand(query, connection);
            commandAdd.Parameters.AddWithValue("@username", fr.textBox1.Text);
            connection.Open();
            commandAdd.ExecuteNonQuery();
            connection.Close();
            Getir();               
            }
            

        }

        private void button3_Click(object sender, EventArgs e)
        {
            fr.button2.Text = "Update";
            fr.textBox1.Enabled = false;
            fr.ShowDialog();
            Getir();
            fr.textBox1.Enabled = true;
        }
    }
}
