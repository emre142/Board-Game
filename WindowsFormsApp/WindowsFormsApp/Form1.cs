using System;
using System.Data;
using System.Linq;
using System.Windows.Forms;
using System.Data.Sql;
using System.Data.SqlClient;


namespace WindowsFormsApp
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        string[] usernames = { "admin", "user" };
        string[] passwords = { "8c6976e5b5410415bde908bd4dee15dfb167a9c873fc4bb8a81f6f2ab448a918", "04f8996da763b7a969b1028ee3007569eaf3a635486ddab211d512c85b9df8fb" };
        private void button1_Click(object sender, EventArgs e)
        {
            SqlConnection connection = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\OOPLAB2PROJECT\ooplab2\WindowsFormsApp\WindowsFormsApp\users.mdf;Integrated Security=True");
            
            string hashedPassword = Sha2.ComputeSha256Hash(textBox2.Text);

            string query = "Select * from Table1 Where username = '" + textBox1.Text.Trim() + "' and password = '" + hashedPassword.Trim() + "'";
            SqlDataAdapter sda = new SqlDataAdapter(query, connection);
            DataTable dtbl = new DataTable();
            sda.Fill(dtbl);

            if (usernames.Contains(textBox1.Text) && passwords.Contains(hashedPassword) &&
     Array.IndexOf(usernames, textBox1.Text) == Array.IndexOf(passwords, hashedPassword))
            {
                Properties.Settings.Default.lastUsername = textBox1.Text;
                Properties.Settings.Default.Save();

                this.Hide();
                Form2 f2 = new Form2();
                if (textBox1.Text == "admin")
                {
                    f2.button4.Text = "Manager Screen";
                }
                else
                {
                    f2.button4.Text = "Profile Screen";
                }
                f2.ShowDialog();
                this.Show();
            }
            else if (dtbl.Rows.Count >= 1)
            {
                Properties.Settings.Default.lastUsername = textBox1.Text;
                Properties.Settings.Default.Save();

                this.Hide();
                Form2 f2 = new Form2();
                if (textBox1.Text == "admin")
                {
                    f2.button4.Text = "Manager Screen";
                }
                else
                {
                    f2.button4.Text = "Profile Screen";
                }
                f2.ShowDialog();
                this.Show();
            }
            else
            {
                MessageBox.Show("The username or the password is incorrect!");
            }
        }
        
        private void button2_Click(object sender, EventArgs e)
        {
            this.Hide();
            FormRegister fr = new FormRegister();
            fr.ShowDialog();
            this.Show();
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

        private void Form1_Load(object sender, EventArgs e)
        {
            textBox1.Text = Properties.Settings.Default.lastUsername;
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox1.Checked)
            {

                textBox2.PasswordChar = '\0';
            }
            else
            {
                textBox2.PasswordChar = '*';
            }
        }
    }
}
