using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Net.Sockets;
using System.Media;

namespace WindowsFormsApp
{
    public partial class Multiplayer : Form
    {
        public Multiplayer(bool isHost, string ip = null, string port = null)
        {
            InitializeComponent();
            MessageReceiver.DoWork += MessageReceiver_DoWork; ;
            CheckForIllegalCrossThreadCalls = false;

            if (isHost)
            {
                server = new TcpListener(System.Net.IPAddress.Any, Convert.ToInt32(port));
                server.Start();
                sock = server.AcceptSocket();
            }
            else
            {
                try
                {
                    client = new TcpClient(ip, 5732);
                    sock = client.Client;
                    MessageReceiver.RunWorkerAsync();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                    Close();
                }
            }
        }
        private void MessageReceiver_DoWork(object sender, DoWorkEventArgs e)
        {

            if (Game())
                return;
            ButtonEnabled();
            CheckPoint();
            label1.Text = "Opponent's Turn!";
            ReceiveMove();
            int cnt = 0;
            foreach (Button btn1 in button)
            {
                if (btn1.Text != "")
                    cnt++;
            }
            if (cnt == 0)
            {
                label1.Text = "Click a button to get started!";
            }
            else
            {
                CheckPoint();
                label1.Text = "Your Trun!";
            }
            if (!Game())
            {
                ButtonNotEnabled();
            }


        }
        private void CheckPoint()
        {
            if (button != null)
            {
                SoundPlayer scoreaudio = new SoundPlayer(WindowsFormsApp.Properties.Resources.score);
                int countp = 0, countl = 0, countn = 0;

                for (int a = 0; a < 9; a++) // yatay
                {
                    for (int b = 0; b < 9; b++)
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
                        else if (button[a, b].Text == "p" && (button[a, b].ForeColor == button[a, b - 1].ForeColor || countp == 0))
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
                            if (label1.Text == "Your Trun!")
                            {
                                scoreaudio.Play();
                                score1 += 5;
                                textBox1.Text = score1.ToString();
                            }
                            else
                            {
                                score2 += 5;
                                textBox2.Text = score2.ToString();
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
                for (int b = 0; b < 9; b++) // dikey
                {
                    for (int a = 0; a < 9; a++)
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
                        else if (button[a, b].Text == "p" && (button[a, b].ForeColor == button[a - 1, b].ForeColor || countp == 0))
                        {
                            countl = 0;
                            countn = 0;
                            countp++;
                        }
                        else if (button[a, b].Text == "l" && (button[a, b].ForeColor == button[a - 1, b].ForeColor || countl == 0))
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
                            if (label1.Text == "Your Trun!")
                            {
                                scoreaudio.Play();
                                score1 += 5;
                                textBox1.Text = score1.ToString();
                            }
                            else
                            {
                                score2 += 5;
                                textBox2.Text = score2.ToString();
                            }
                        }
                    }
                    countp = 0;
                    countl = 0;
                    countn = 0;
                }
            }
        }

        private bool Game()
        {
            if (button != null)
            {
                int count = 0;
                foreach (Button btn1 in button)
                {
                    if (btn1.Text == "")
                        count++;
                }
                if (count <= 3)
                {
                    if (score1 > score2)
                    {
                        label1.Text = "You Won!";
                    }
                    else if (score1 < score2)
                    {
                        label1.Text = "You Lost!";
                    }
                    else
                    {
                        label1.Text = "It's a draw!";
                    }
                    return true;
                }
            }
            return false;
        }

        private void ButtonNotEnabled()
        {
            if (button != null)
            {
                foreach (Button btn in button)
                {
                    btn.Enabled = true;
                }
            }

        }

        private void ButtonEnabled()
        {
            if (button != null)
            {
                foreach (Button btn in button)
                {
                    btn.Enabled = false;
                }
            }
        }

        private Socket sock;
        private BackgroundWorker MessageReceiver = new BackgroundWorker();
        private TcpListener server = null;
        private TcpClient client;

        private void ReceiveMove()
        {
            byte[] buffer = new byte[18];
            sock.Receive(buffer);
            if (buffer[0] != 9)
            {
                if (buffer[2] == 0)
                {
                    button[buffer[0], buffer[1]].Font = new Font("Wingdings 3", 25, Font.Style);
                    button[buffer[0], buffer[1]].Text = "p";

                }
                if (buffer[2] == 1)
                {
                    button[buffer[0], buffer[1]].Font = new Font("Wingdings", 25, Font.Style);
                    button[buffer[0], buffer[1]].Text = "l";
                }
                if (buffer[2] == 2)
                {
                    button[buffer[0], buffer[1]].Font = new Font("Wingdings", 25, Font.Style);
                    button[buffer[0], buffer[1]].Text = "n";
                }
                if (buffer[3] == 0)
                {
                    button[buffer[0], buffer[1]].ForeColor = Color.Blue;
                }
                if (buffer[3] == 1)
                {
                    button[buffer[0], buffer[1]].ForeColor = Color.Red;
                }
                if (buffer[3] == 2)
                {
                    button[buffer[0], buffer[1]].ForeColor = Color.Green;
                }
                button[buffer[4], buffer[5]].Text = "";
            }
            if (buffer[12] == 0)
            {
                button[buffer[6], buffer[7]].Font = new Font("Wingdings 3", 25, Font.Style);
                button[buffer[6], buffer[7]].Text = "p";

            }
            if (buffer[12] == 1)
            {
                button[buffer[6], buffer[7]].Font = new Font("Wingdings", 25, Font.Style);
                button[buffer[6], buffer[7]].Text = "l";
            }
            if (buffer[12] == 2)
            {
                button[buffer[6], buffer[7]].Font = new Font("Wingdings", 25, Font.Style);
                button[buffer[6], buffer[7]].Text = "n";
            }
            if (buffer[13] == 0)
            {
                button[buffer[6], buffer[7]].ForeColor = Color.Blue;
            }
            if (buffer[13] == 1)
            {
                button[buffer[6], buffer[7]].ForeColor = Color.Red;
            }
            if (buffer[13] == 2)
            {
                button[buffer[6], buffer[7]].ForeColor = Color.Green;
            }

            if (buffer[14] == 0)
            {
                button[buffer[8], buffer[9]].Font = new Font("Wingdings 3", 25, Font.Style);
                button[buffer[8], buffer[9]].Text = "p";

            }
            if (buffer[14] == 1)
            {
                button[buffer[8], buffer[9]].Font = new Font("Wingdings", 25, Font.Style);
                button[buffer[8], buffer[9]].Text = "l";
            }
            if (buffer[14] == 2)
            {
                button[buffer[8], buffer[9]].Font = new Font("Wingdings", 25, Font.Style);
                button[buffer[8], buffer[9]].Text = "n";
            }
            if (buffer[15] == 0)
            {
                button[buffer[8], buffer[9]].ForeColor = Color.Blue;
            }
            if (buffer[15] == 1)
            {
                button[buffer[8], buffer[9]].ForeColor = Color.Red;
            }
            if (buffer[15] == 2)
            {
                button[buffer[8], buffer[9]].ForeColor = Color.Green;
            }


            if (buffer[16] == 0)
            {
                button[buffer[10], buffer[11]].Font = new Font("Wingdings 3", 25, Font.Style);
                button[buffer[10], buffer[11]].Text = "p";

            }
            if (buffer[16] == 1)
            {
                button[buffer[10], buffer[11]].Font = new Font("Wingdings", 25, Font.Style);
                button[buffer[10], buffer[11]].Text = "l";
            }
            if (buffer[16] == 2)
            {
                button[buffer[10], buffer[11]].Font = new Font("Wingdings", 25, Font.Style);
                button[buffer[10], buffer[11]].Text = "n";
            }
            if (buffer[17] == 0)
            {
                button[buffer[10], buffer[11]].ForeColor = Color.Blue;
            }
            if (buffer[17] == 1)
            {
                button[buffer[10], buffer[11]].ForeColor = Color.Red;
            }
            if (buffer[17] == 2)
            {
                button[buffer[10], buffer[11]].ForeColor = Color.Green;
            }
        }

        private void Game_FormClosing(object sender, FormClosingEventArgs e)
        {
            MessageReceiver.WorkerSupportsCancellation = true;
            MessageReceiver.CancelAsync();
            if (server != null)
                server.Stop();
        }

        Button[,] button;
        Random random = new Random();
        int randomindex1, randomindex2, randomindex3, randomindex4, randomindex5, randomindex6;
        int x = -1, y = -1, num1, num2, num3, num4, num5, num6, number1, number2;
        string temp1 = "";
        Font temp2;
        Color temp3 = Color.Black;
        int score1 = 0;
        int score2 = 0;
        private void Multiplayer_Load(object sender, EventArgs e)
        {
            SoundPlayer moveaudio = new SoundPlayer(WindowsFormsApp.Properties.Resources.move);

            button = new Button[9, 9];
            int top = 40;
            int left = 0;
            for (int i = 0; i < 9; i++)
            {
                for (int j = 0; j < 9; j++)
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
                        int cnt = 0;
                        foreach (Button btn1 in button)
                        {
                            if (btn1.Text != "")
                                cnt++;
                        }
                        if (cnt == 0)
                        {
                            x = 9;
                            y = 9;
                            number1 = 9;
                            number2 = 9;
                            olustur(x, y, number1, number2);
                            x = -1;
                            y = -1;
                        }
                        else if (btn.Text != "")
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
                                        number1 = a;
                                        number2 = b;
                                    };
                                }
                            }
                            int a1 = x;
                            int b1 = y;
                            while (btn.Text == "")
                            {
                                if (x < number1)
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
                                        System.Threading.Thread.Sleep(100);
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
                                else if (x > number1)
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
                                        System.Threading.Thread.Sleep(100);
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
                                else if (y < number2)
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
                                        System.Threading.Thread.Sleep(100);
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
                                else if (y > number2)
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
                                        System.Threading.Thread.Sleep(100);
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

                            int count = 0;
                            foreach (Button btn1 in button)
                            {
                                if (btn1.Text == "")
                                    count++;
                            }
                            if ((x != a1 || y != b1) && count > 3)
                            {
                                olustur(a1, b1, number1, number2);
                            }
                            x = -1;
                            y = -1;
                        }
                    };
                }
                top += 40;
                left = 0;
            }
        }

        int send1, send2;
        public List<string> icons = new List<string>() { "p", "l", "n" };
        public List<string> colours = new List<string>() { "Blue", "Red", "Green" };
        void send(int x, int y, int number1, int number2)
        {

            if (temp1 == "p")
            {
                send1 = 0;
            }
            if (temp1 == "l")
            {
                send1 = 1;
            }
            if (temp1 == "n")
            {
                send1 = 2;
            }
            if (temp1 == "")
            {
                send1 = 3;
            }
            if (temp3 == Color.Blue)
            {
                send2 = 0;
            }
            if (temp3 == Color.Red)
            {
                send2 = 1;
            }
            if (temp3 == Color.Green)
            {
                send2 = 2;
            }
            if (temp3 == Color.Black)
            {
                send2 = 3;
            }
            byte[] num = { (byte)number1, (byte)number2, (byte)send1, (byte)send2, (byte)x, (byte)y,
                (byte)num1, (byte)num2,(byte)num3,(byte)num4, (byte)num5, (byte)num6,
                (byte)randomindex1, (byte)randomindex2, (byte)randomindex3,
                (byte)randomindex4, (byte)randomindex5, (byte)randomindex6 };
            sock.Send(num);
            MessageReceiver.RunWorkerAsync();
        }

        private void olustur(int x, int y, int number1, int number2)
        {
            do
            {
                num1 = random.Next(9);
                num2 = random.Next(9);
                num3 = random.Next(9);
                num4 = random.Next(9);
                num5 = random.Next(9);
                num6 = random.Next(9);
            } while ((button[num1, num2].Text != "" || button[num3, num4].Text != "" || button[num5, num6].Text != "")
                || ((num1 == num3 && num2 == num4) || (num1 == num5 && num2 == num6) || (num5 == num3 && num6 == num4)));

            randomindex1 = random.Next(icons.Count);
            randomindex2 = random.Next(colours.Count);
            if (icons.IndexOf("p") == randomindex1)
            {
                button[num1, num2].Font = new Font("Wingdings 3", 25, Font.Style);
                button[num1, num2].Text = "p";
                button[num1, num2].ForeColor = Color.FromName(colours[randomindex2]);
            }
            if (icons.IndexOf("l") == randomindex1)
            {
                button[num1, num2].Font = new Font("Wingdings", 25, Font.Style);
                button[num1, num2].Text = "l";
                button[num1, num2].ForeColor = Color.FromName(colours[randomindex2]);
            }
            if (icons.IndexOf("n") == randomindex1)
            {
                button[num1, num2].Font = new Font("Wingdings", 25, Font.Style);
                button[num1, num2].Text = "n";
                button[num1, num2].ForeColor = Color.FromName(colours[randomindex2]);
            }
            randomindex3 = random.Next(icons.Count);
            randomindex4 = random.Next(colours.Count);
            if (icons.IndexOf("p") == randomindex3)
            {
                button[num3, num4].Font = new Font("Wingdings 3", 25, Font.Style);
                button[num3, num4].Text = "p";
                button[num3, num4].ForeColor = Color.FromName(colours[randomindex4]);
            }
            if (icons.IndexOf("l") == randomindex3)
            {
                button[num3, num4].Font = new Font("Wingdings", 25, Font.Style);
                button[num3, num4].Text = "l";
                button[num3, num4].ForeColor = Color.FromName(colours[randomindex4]);
            }
            if (icons.IndexOf("n") == randomindex3)
            {
                button[num3, num4].Font = new Font("Wingdings", 25, Font.Style);
                button[num3, num4].Text = "n";
                button[num3, num4].ForeColor = Color.FromName(colours[randomindex4]);
            }
            randomindex5 = random.Next(icons.Count);
            randomindex6 = random.Next(colours.Count);
            if (icons.IndexOf("p") == randomindex5)
            {
                button[num5, num6].Font = new Font("Wingdings 3", 25, Font.Style);
                button[num5, num6].Text = "p";
                button[num5, num6].ForeColor = Color.FromName(colours[randomindex6]);
            }
            if (icons.IndexOf("l") == randomindex5)
            {
                button[num5, num6].Font = new Font("Wingdings", 25, Font.Style);
                button[num5, num6].Text = "l";
                button[num5, num6].ForeColor = Color.FromName(colours[randomindex6]);
            }
            if (icons.IndexOf("n") == randomindex5)
            {
                button[num5, num6].Font = new Font("Wingdings", 25, Font.Style);
                button[num5, num6].Text = "n";
                button[num5, num6].ForeColor = Color.FromName(colours[randomindex6]);
            }

            send(x, y, number1, number2);
        }
    }
}
