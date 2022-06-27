using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Media;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp
{
    public partial class GameForm : Form
    {
        public List<string> icons = new List<string>();
        public List<string> colours = new List<string>();
        public GameForm()
        {
            InitializeComponent();
        }



        SqlConnection connection;
        Random random = new Random();
        Button[,] button;
        int randomindex, x = -1, y = -1, num1, num2;
        string temp1;
        Font temp2;
        Color temp3;
        int score = 0;
 

        private void GameForm_Load(object sender, EventArgs e)
        {
            SoundPlayer scoreaudio = new SoundPlayer(WindowsFormsApp.Properties.Resources.score);
            SoundPlayer moveaudio = new SoundPlayer(WindowsFormsApp.Properties.Resources.move);
          
            scrBox1.Text = "0";

            Managerscreen ms = new Managerscreen();
            ms.Getir();
            int[] columnData = new int[ms.dataGridView1.Rows.Count];
            columnData = (from DataGridViewRow row in ms.dataGridView1.Rows
                          where row.Cells[8].FormattedValue.ToString() != string.Empty
                          select Convert.ToInt32(row.Cells[8].FormattedValue)).ToArray();
            bestscrBox1.Text = columnData.Max().ToString();

            Form3 f3 = new Form3();
            f3.Show();
            f3.Hide();
            this.Text = "GAME";

            icons.Add("p");
            icons.Add("l");
            icons.Add("n");
            if (f3.radioButton4.Checked == true)
            {
                if (f3.checkBox1Square.Checked == false)
                    icons.Remove("n");
                if (f3.checkBox2Triangle.Checked == false)
                    icons.Remove("p");
                if (f3.checkBox3Round.Checked == false)
                    icons.Remove("l");
            }

            colours.Add("Blue");
            colours.Add("Red");
            colours.Add("Green");
            if (f3.radioButton4.Checked == true)
            {
                if (f3.checkBox4Green.Checked == false)
                    colours.Remove("Green");
                if (f3.checkBox5Red.Checked == false)
                    colours.Remove("Red");
                if (f3.checkBox6Blue.Checked == false)
                    colours.Remove("Blue");
            }

            button = new Button[int.Parse(Form3.a), int.Parse(Form3.b)];
            int top = 40;
            int left = 0;
            for (int i = 0; i < int.Parse(Form3.a); i++)
            {
                for (int j = 0; j < int.Parse(Form3.b); j++)
                {
                    button[i, j] = new Button();
                    button[i, j].Width = 40;
                    button[i, j].Height = 40;
                    button[i, j].Left = left;
                    button[i, j].Top = top;
                    this.Controls.Add(button[i, j]);
                    left += 40;
                    if ((i + j) % 2 == 0)
                    {
                        button[i, j].BackColor = Color.LightGray;
                    }
                    else
                    {
                        button[i, j].BackColor = Color.White;
                    }
                    button[i, j].Click += (s, e1) =>
                    {
                        Button btn = s as Button;
                        if (btn.Text != "")
                        {
                            temp1 = btn.Text;
                            temp2 = btn.Font;
                            temp3 = btn.ForeColor;
                            for (int a = 0; a < i; a++)
                            {
                                for (int b = 0; b < j; b++)
                                {
                                    if (btn == button[a, b])
                                    {
                                        x = a;
                                        y = b;
                                    };
                                }
                            }
                        }
                        else if (x != -1)
                        {
                            for (int a = 0; a < i; a++)
                            {
                                for (int b = 0; b < j; b++)
                                {
                                    if (btn == button[a, b])
                                    {
                                        num1 = a;
                                        num2 = b;
                                    };
                                }
                            }
                            int a1 = x;
                            int b1 = y;
                            while (btn.Text == "")
                            {
                                if (x < num1)
                                {
                                    if (button[x + 1, y].Text == "")
                                    {
                                        button[x, y].Text = "";
                                        button[x, y].Update();
                                        button[x + 1, y].Text = temp1;
                                        button[x + 1, y].Font = temp2;
                                        button[x + 1, y].ForeColor = temp3;
                                        button[x + 1, y].Update();
                                        x++;
                                        moveaudio.Play();
                                        System.Threading.Thread.Sleep(350);
                                    }
                                    else if (x != a1 || y != b1)
                                    {
                                        button[a1, b1].Text = button[x, y].Text;
                                        button[a1, b1].Update();
                                        button[x, y].Text = "";
                                        button[x, y].Update();
                                        x = a1;
                                        y = b1;
                                        break;
                                    }
                                    else
                                        break;

                                }
                                else if (x > num1)
                                {
                                    if (button[x - 1, y].Text == "")
                                    {
                                        button[x, y].Text = "";
                                        button[x, y].Update();
                                        button[x - 1, y].Text = temp1;
                                        button[x - 1, y].Font = temp2;
                                        button[x - 1, y].ForeColor = temp3;
                                        button[x - 1, y].Update();
                                        x--;
                                        moveaudio.Play();
                                        System.Threading.Thread.Sleep(350);
                                    }
                                    else if (x != a1 || y != b1)
                                    {
                                        button[a1, b1].Text = button[x, y].Text;
                                        button[a1, b1].Update();
                                        button[x, y].Text = "";
                                        button[x, y].Update();
                                        x = a1;
                                        y = b1;
                                        break;
                                    }
                                    else
                                        break;
                                }
                                else if (y < num2)
                                {
                                    if (button[x, y + 1].Text == "")
                                    {
                                        button[x, y].Text = "";
                                        button[x, y].Update();
                                        button[x, y + 1].Text = temp1;
                                        button[x, y + 1].Font = temp2;
                                        button[x, y + 1].ForeColor = temp3;
                                        button[x, y + 1].Update();
                                        y++;
                                        moveaudio.Play();
                                        System.Threading.Thread.Sleep(350);
                                    }
                                    else if (x != a1 || y != b1)
                                    {
                                        button[a1, b1].Text = button[x, y].Text;
                                        button[a1, b1].Update();
                                        button[x, y].Text = "";
                                        button[x, y].Update();
                                        x = a1;
                                        y = b1;
                                        break;
                                    }
                                    else
                                        break;
                                }
                                else if (y > num2)
                                {
                                    if (button[x, y - 1].Text == "")
                                    {
                                        button[x, y].Text = "";
                                        button[x, y].Update();
                                        button[x, y - 1].Text = temp1;
                                        button[x, y - 1].Font = temp2;
                                        button[x, y - 1].ForeColor = temp3;
                                        button[x, y - 1].Update();
                                        y--;
                                        moveaudio.Play();
                                        System.Threading.Thread.Sleep(350);
                                    }
                                    else if (x != a1 || y != b1)
                                    {
                                        button[a1, b1].Text = button[x, y].Text;
                                        button[a1, b1].Update();
                                        button[x, y].Text = "";
                                        button[x, y].Update();
                                        x = a1;
                                        y = b1;
                                        break;
                                    }
                                    else
                                        break;
                                }

                            }
                            int countp = 0, countl = 0, countn = 0;
                            int temp = score;
                            Form3 f_3 = new Form3();

                            for (int a = 0; a < i; a++) // yatay
                            {
                                for (int b = 0; b < j; b++)
                                {
                                    if (b == 0 && button[a, b].Text == "p")
                                    {
                                        countl = 0;
                                        countn = 0;
                                        countp++;
                                    }
                                    else if (b == 0 && button[a, b].Text == "l")
                                    {
                                        countp = 0;
                                        countn = 0;
                                        countl++;
                                    }
                                    else if (b == 0 && button[a, b].Text == "n")
                                    {
                                        countp = 0;
                                        countl = 0;
                                        countn++;
                                    }
                                    else if (button[a,b].Text == "p" && (button[a, b].ForeColor == button[a, b - 1].ForeColor || countp == 0))
                                    {
                                        countl = 0;
                                        countn = 0;
                                        countp++;
                                    }
                                    else if (button[a, b].Text == "l" && (button[a, b].ForeColor == button[a, b - 1].ForeColor || countl == 0))
                                    {
                                        countp = 0;
                                        countn = 0;
                                        countl++;
                                    }
                                    else if (button[a, b].Text == "n" && (button[a, b].ForeColor == button[a, b - 1].ForeColor || countn == 0))
                                    {
                                        countp = 0;
                                        countl = 0;
                                        countn++;
                                    }
                                    else
                                    {
                                        countp = 0; 
                                        countl = 0;
                                        countn = 0;
                                    }
                                    if (countp == 5 || countl == 5 || countn == 5)
                                    {
                                        button[a, b].Text = "";
                                        button[a, b - 1].Text = "";
                                        button[a, b - 2].Text = "";
                                        button[a, b - 3].Text = "";
                                        button[a, b - 4].Text = "";

                                        if (Form3.rdbtnindex == 1)
                                        {
                                            score += 1;
                                            countp = 0;
                                            countl = 0;
                                            countn = 0;

                                        }
                                        else if (Form3.rdbtnindex == 2)
                                        {
                                            score += 3;
                                            countp = 0;
                                            countl = 0;
                                            countn = 0;
                                        }
                                        else if (Form3.rdbtnindex == 3)
                                        {
                                            score += 5;
                                            countp = 0;
                                            countl = 0;
                                            countn = 0;
                                        }
                                        else
                                        {
                                            score += 2;
                                            countp = 0;
                                            countl = 0;
                                            countn = 0;
                                        }
                                    }
                                }
                                countp = 0;
                                countl = 0;
                                countn = 0;
                            }

                            countp = 0;
                            countl = 0;
                            countn = 0;
                            for (int b = 0; b < i; b++) // dikey
                            {
                                for (int a = 0; a < j; a++)
                                {
                                    if (a == 0 && button[a, b].Text == "p")
                                    {
                                        countl = 0;
                                        countn = 0;
                                        countp++;
                                    }
                                    else if (a == 0 && button[a, b].Text == "l")
                                    {
                                        countp = 0;
                                        countn = 0;
                                        countl++;
                                    }
                                    else if (a == 0 && button[a, b].Text == "n")
                                    {
                                        countp = 0;
                                        countl = 0;
                                        countn++;
                                    }
                                    else if (button[a, b].Text == "p" && (button[a, b].ForeColor == button[a - 1 , b].ForeColor || countp == 0))
                                    {
                                        countl = 0;
                                        countn = 0;
                                        countp++;
                                    }
                                    else if (button[a, b].Text == "l" && (button[a, b].ForeColor == button[a - 1, b ].ForeColor || countl == 0))
                                    {
                                        countp = 0;
                                        countn = 0;
                                        countl++;
                                    }
                                    else if (button[a, b].Text == "n" && (button[a, b].ForeColor == button[a - 1, b].ForeColor || countn == 0))
                                    {
                                        countp = 0;
                                        countl = 0;
                                        countn++;
                                    }
                                    else
                                    {
                                        countp = 0;
                                        countl = 0;
                                        countn = 0;
                                    }
                                    if (countp == 5 || countl == 5 || countn == 5)
                                    {
                                        button[a, b].Text = "";
                                        button[a - 1, b].Text = "";
                                        button[a - 2, b].Text = "";
                                        button[a - 3, b].Text = "";
                                        button[a - 4, b].Text = "";

                                        if (Form3.rdbtnindex == 1)
                                        {
                                            score += 1;
                                            countp = 0;
                                            countl = 0;
                                            countn = 0;

                                        }
                                        else if (Form3.rdbtnindex == 2)
                                        {
                                            score += 3;
                                            countp = 0;
                                            countl = 0;
                                            countn = 0;
                                        }
                                        else if (Form3.rdbtnindex == 3)
                                        {
                                            score += 5;
                                            countp = 0;
                                            countl = 0;
                                            countn = 0;
                                        }
                                        else
                                        {
                                            score += 2;
                                            countp = 0;
                                            countl = 0;
                                            countn = 0;
                                        }
                                    }
                                }
                                countp = 0;
                                countl = 0;
                                countn = 0;
                            }

                            if(score > int.Parse(scrBox1.Text))
                            {
                                scoreaudio.Play();
                                scrBox1.Text = score.ToString();
                            }
                            if (score > int.Parse(bestscrBox1.Text))
                            {
                                bestscrBox1.Text = score.ToString();
                            }

                            int count = 0;
                            foreach (Button btn1 in button)
                            {
                                if (btn1.Text == "")
                                    count++;
                            }
                            if (count <= 3)
                            {
                                connection = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDBFilename=|DataDirectory|users.mdf;Integrated Security=True");
                                string sorgu = "UPDATE Table1 SET score=@score WHERE username='" + Properties.Settings.Default.lastUsername + "'";
                                SqlCommand commandAdd = new SqlCommand(sorgu, connection);
                                commandAdd.Parameters.AddWithValue("@score", bestscrBox1.Text);
                                connection.Open();
                                commandAdd.ExecuteNonQuery();
                                connection.Close();

                                this.Close();
                                MessageBox.Show(" Your score = " + score);

                            }
                            else if ((x != a1 || y != b1) && score == temp)
                            {
                                olustur();
                            }
                            x = -1;
                            y = -1;
                        }
                    };
                }
                top += 40;
                left = 0;
            }
            olustur();
        }

        private void olustur()
        {
            for (int i = 0; i < 3; i++)
            {
                do
                {
                    num1 = random.Next(int.Parse(Form3.a));
                    num2 = random.Next(int.Parse(Form3.b));
                } while (button[num1, num2].Text != "");

                randomindex = random.Next(icons.Count);
                if (icons.IndexOf("p") == randomindex )
                {
                    button[num1, num2].Font = new Font("Wingdings 3", 25, Font.Style);
                    button[num1, num2].Text = "p";
                    button[num1, num2].ForeColor = Color.FromName(colours[random.Next(colours.Count)]);
                }
                if (icons.IndexOf("l") == randomindex)
                {
                    button[num1, num2].Font = new Font("Wingdings", 25, Font.Style);
                    button[num1, num2].Text = "l";
                    button[num1, num2].ForeColor = Color.FromName(colours[random.Next(colours.Count)]);
                }
                if (icons.IndexOf("n") == randomindex)
                {
                    button[num1, num2].Font = new Font("Wingdings", 25, Font.Style);
                    button[num1, num2].Text = "n";
                    button[num1, num2].ForeColor = Color.FromName(colours[random.Next(colours.Count)]);
                }
            }
        }

        private void button6_Click(object sender, EventArgs e)
        {
            Helpscreen help = new Helpscreen();
            help.ShowDialog();
        }
    }
}
