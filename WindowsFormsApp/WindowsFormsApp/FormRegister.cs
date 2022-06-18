using System;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Windows.Forms;

namespace WindowsFormsApp
{
    public partial class FormRegister : Form
    {
        public FormRegister()
        {
            InitializeComponent();
        }
        SqlConnection connection = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\OOPLAB2PROJECT\ooplab2\WindowsFormsApp\WindowsFormsApp\users.mdf;Integrated Security=True");
        public string temp;
        private void button2_Click(object sender, EventArgs e)
        {
            if (button2.Text == "Register" || button2.Text == "Add")
            {
                connection.Open();
                SqlCommand commandAdd = new SqlCommand("UserAdd", connection);
                commandAdd.CommandType = CommandType.StoredProcedure;

                string hashedPassword = Sha2.ComputeSha256Hash(textBox2.Text);

                commandAdd.Parameters.AddWithValue("@username", textBox1.Text);
                commandAdd.Parameters.AddWithValue("@password", hashedPassword);
                commandAdd.Parameters.AddWithValue("@namesurname", textBox3.Text);
                commandAdd.Parameters.AddWithValue("@phone", textBox4.Text);
                commandAdd.Parameters.AddWithValue("@addres", textBox5.Text);
                commandAdd.Parameters.AddWithValue("@city", textBox6.Text);
                commandAdd.Parameters.AddWithValue("@country", textBox7.Text);
                commandAdd.Parameters.AddWithValue("@email", textBox8.Text);
                commandAdd.ExecuteNonQuery();
                MessageBox.Show("Kayıt başarıyla oluşturuldu.");
                connection.Close();
            }
            else
            {
                string sorgu = "UPDATE Table1 SET password=@password,namesurname=@namesurname,phone=@phone,addres=@addres," +
                "city=@city,country=@country,email=@email WHERE username=@username";
                SqlCommand commandAdd = new SqlCommand(sorgu, connection);

                commandAdd.Parameters.AddWithValue("@username", textBox1.Text);
                if(textBox2.Text != "")
                {
                    string hashedPassword = Sha2.ComputeSha256Hash(textBox2.Text);
                    commandAdd.Parameters.AddWithValue("@password", hashedPassword);
                }
                else
                    commandAdd.Parameters.AddWithValue("@password", temp);

                commandAdd.Parameters.AddWithValue("@namesurname", textBox3.Text);
                commandAdd.Parameters.AddWithValue("@phone", textBox4.Text);
                commandAdd.Parameters.AddWithValue("@addres", textBox5.Text);
                commandAdd.Parameters.AddWithValue("@city", textBox6.Text);
                commandAdd.Parameters.AddWithValue("@country", textBox7.Text);
                commandAdd.Parameters.AddWithValue("@email", textBox8.Text);
                connection.Open();
                commandAdd.ExecuteNonQuery();
                connection.Close();
            }
            
        }

        string oldText = string.Empty;
        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            if (textBox1.Text.All(chr => char.IsLetter(chr)))
            {
                oldText = textBox1.Text;
                textBox1.Text = oldText;

                textBox1.BackColor = System.Drawing.Color.White;
                textBox1.ForeColor = System.Drawing.Color.Black;
            }
            else
            {
                textBox1.Text = "";
                textBox1.BackColor = System.Drawing.Color.Red;
                textBox1.ForeColor = System.Drawing.Color.White;
            }
            textBox2.SelectionStart = textBox1.Text.Length;
        }

        private void FormRegister_Load(object sender, EventArgs e)
        {

        }
    }
}
