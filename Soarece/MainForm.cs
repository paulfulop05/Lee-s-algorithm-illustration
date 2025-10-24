using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.IO;
using System.Windows.Forms;
using System.Threading;

namespace Soarece
{
    public partial class MainForm : Form
    {
        public struct Cords
        {
            public int x, y;
        };

        private int n, m;
        private int L;
        private int clicks;
        private int nrobs;
        private int[,] labirint, v;
        private int istart, jstart, icheese, jcheese;
        private int[] di = { 1, 0, -1, 0 }, dj = { 0, 1, 0, -1 };

        private Queue<int> q1, q2;
        private Cords[] path_cords, obstacle_cords;
        private Button[,] btn;
        private TableLayoutPanel tbl;

        private string filename = Path.GetFullPath("mouse_background.jpg");

        private Color path_color = Color.FromArgb(102, 133, 90),
            obstacle_color = Color.FromArgb(153, 124, 86),
            start_color = Color.FromArgb(189, 193, 199),
            forecolor_green = Color.FromArgb(51, 69, 45),
            forecolor_brown = Color.FromArgb(77, 61, 41),
            forecolor_grey = Color.FromArgb(77, 76, 76),
            grey = Color.FromArgb(128, 125, 120),
            green = Color.FromArgb(49, 186, 28),
            red = Color.FromArgb(209, 47, 29);

        public MainForm()
        {
            InitializeComponent();
            SetPanelBackground();
            btnReset.Enabled = false;
        }

        private void SetPanelBackground()
        {
            panel.BackgroundImage = Image.FromFile(filename);
            panel.BackgroundImageLayout = ImageLayout.Stretch;
        }

        private void Lee(int i, int j)
        {
            q1.Enqueue(i);
            q2.Enqueue(j);
            v[i, j] = 1;

            int i1, j1, i2, j2;
            while (q1.Count > 0)
            {
                i1 = q1.Dequeue();
                j1 = q2.Dequeue();

                for (int d = 0; d < 4; ++d)
                {
                    i2 = i1 + di[d];
                    j2 = j1 + dj[d];
                    if (Ok(i2, j2))
                    {
                        v[i2, j2] = v[i1, j1] + 1;
                        q1.Enqueue(i2);
                        q2.Enqueue(j2);
                    }
                }
            }
        }

        private bool Ok(int i, int j)
        {
            if (i < 1 || i > n || j < 1 || j > m) return false;
            if (labirint[i, j] == 1) return false;
            if (v[i, j] != 0) return false;
            return true;
        }

        private void FindPath(int i, int j, int k)
        {
            if (i == icheese && j == jcheese)
            {
                for (int l = 2; l < k; ++l)
                {
                    Application.DoEvents();
                    btn[path_cords[l].x, path_cords[l].y].BackColor = path_color;
                    btn[path_cords[l].x, path_cords[l].y].ForeColor = forecolor_green;
                    Thread.Sleep(180);
                }
                lbl_nrsol.Text = "Soarecele a facut " + (k - 1).ToString() + " pasi pana la cascaval";

                return;
            }

            if (k > 1)
            {
                path_cords[k].x = i;
                path_cords[k].y = j;
            }

            for (int d = 0; d < 4; ++d)
            {
                int i1 = i + di[d];
                int j1 = j + dj[d];

                if (inMatrix(i1, j1) && v[i1, j1] == v[i, j] - 1)
                {
                    FindPath(i1, j1, k + 1);
                    break;
                }
            }
        }

        private bool inMatrix(int i, int j)
        {
            if (i < 1 || i > n || j < 1 || j > m) return false;
            return true;
        }

        private void ReadData()
        {
            StreamReader sr = new StreamReader("soarece.txt");
            string line = sr.ReadLine();
            char[] sep = { ' ' };
            string[] s = line.Split(sep, StringSplitOptions.RemoveEmptyEntries);

            n = int.Parse(s[0]);
            m = int.Parse(s[1]);
            labirint = new int[n + 1, m + 1];
            v = new int[n + 1, m + 1];
            q1 = q2 = new Queue<int>();
            lbl_nrsol.Text = "Soarecele nu a ajuns inca!";
            path_cords = new Cords[100];
            obstacle_cords = new Cords[100];

            int i = 1;
            while ((line = sr.ReadLine()) != null)
            {
                s = line.Split(sep, StringSplitOptions.RemoveEmptyEntries);
                for (int j = 1; j <= m; ++j)
                    labirint[i, j] = int.Parse(s[j - 1]);
                ++i;
                if (i == n + 1)
                    break;
            }
        }

        private void CreateGUI()
        {
            btn = new Button[n + 1, m + 1];
            tbl = new TableLayoutPanel()
            {
                RowCount = n + 1,
                ColumnCount = m,
                Dock = DockStyle.Fill
            };

            int H = panel.Height;
            int W = panel.Width;
            L = Math.Min(H, W) / Math.Max(n, m);

            for (int j = 1; j <= m; j++)
                tbl.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, L));

            for (int i = 1; i <= n; i++)
            {
                tbl.RowStyles.Add(new RowStyle(SizeType.Percent, L));
                for (int j = 1; j <= m; ++j)
                {
                    btn[i, j] = new Button()
                    {
                        Dock = DockStyle.Fill,
                        BackColor = Color.FromArgb(189, 193, 199),
                        FlatStyle = FlatStyle.Flat,
                        BackgroundImageLayout = ImageLayout.Zoom,
                        Margin = new Padding(0)
                    };

                    if (labirint[i, j] == 0)
                    {
                        btn[i, j].BackColor = start_color;
                        btn[i, j].ForeColor = forecolor_grey;
                    }
                    else
                    {
                        btn[i, j].BackColor = obstacle_color;
                        btn[i, j].ForeColor = forecolor_brown;
                        obstacle_cords[++nrobs].x = i;
                        obstacle_cords[nrobs].y = j;
                    }

                    btn[i, j].MouseEnter += HandleMouseEnter;
                    btn[i, j].MouseLeave += HandleMouseLeave;
                    btn[i, j].Click += HandleClick;
                    tbl.Controls.Add(btn[i, j]);
                }
            }
            panel.Controls.Add(tbl);
        }

        private void ResetMatrix()
        {
            for (int i = 1; i <= n; ++i)
                for (int j = 1; j <= m; ++j)
                    if (v[i, j] != 0) v[i, j] = 0;
        }

        public void HandleClick(object sender, EventArgs e)
        {
            Button b = (Button)sender;
            if (b.BackColor == green)
                ++clicks;

            if (clicks == 1 && b.BackColor == green)
            {
                b.BackColor = grey;
                b.ForeColor = Color.Black;
                b.BackgroundImage = Properties.Resources.mouse;

                lbl_nrsol.Text = "Soarecele este aici!";

                for (int i = 1; i <= n; ++i)
                    for (int j = 1; j <= m; ++j)
                        if (b == btn[i, j])
                        {
                            istart = i;
                            jstart = j;
                            break;
                        }
            }

            if (clicks > 1 && b.BackColor == green)
            {
                lbl_nrsol.Text = "Soarecele a facut ... pasi pana la cascaval";
                btnReset.Enabled = false;

                for (int i = 1; i <= n; ++i)
                    for (int j = 1; j <= m; ++j)
                    {
                        if (btn[i, j].BackColor != start_color && btn[i, j].BackColor != obstacle_color)
                        {
                            btn[i, j].BackColor = start_color;
                            btn[i, j].ForeColor = forecolor_grey;
                        }
                    }

                btn[istart, jstart].BackColor = grey;
                btn[istart, jstart].ForeColor = Color.Black;

                if (icheese != 0 && jcheese != 0)
                    btn[icheese, jcheese].BackgroundImage = null;

                b.BackColor = grey;
                b.ForeColor = Color.Black;
                b.BackgroundImage = Properties.Resources.cheese;

                for (int i = 1; i <= n; ++i)
                    for (int j = 1; j <= m; ++j)
                        if (b == btn[i, j])
                        {
                            icheese = i;
                            jcheese = j;
                            break;
                        }

                Lee(icheese, jcheese);
                FindPath(istart, jstart, 1);
                ResetMatrix();

                btnReset.Enabled = true;
            }
        }

        public void HandleMouseEnter(object sender, EventArgs e)
        {
            Button b = (Button)sender;
            if (b.BackColor == start_color)
                b.BackColor = green;

            if (b.BackColor == obstacle_color)
                b.BackColor = red;

        }

        public void HandleMouseLeave(object sender, EventArgs e)
        {
            Button b = (Button)sender;
            if (b.BackColor == green)
                b.BackColor = start_color;

            if (b.BackColor == red)
                b.BackColor = obstacle_color;
        }

        private void btnReset_Click(object sender, EventArgs e)
        {
            lbl_nrsol.Text = "Soarecele a plecat!";
            clicks = 0;

            for (int i = 1; i <= n; ++i)
                for (int j = 1; j <= m; ++j)
                {
                    if (btn[i, j].BackColor != start_color && btn[i, j].BackColor != obstacle_color)
                    {
                        btn[i, j].BackColor = start_color;
                        btn[i, j].ForeColor = forecolor_grey;
                        btn[i, j].Text = "";
                    }

                    if (btn[i, j].BackgroundImage != null)
                        btn[i, j].BackgroundImage = null;
                }

            ResetMatrix();
        }

        private void btnStart_Click(object sender, EventArgs e)
        {
            ReadData();
            CreateGUI();
            btnStart.Enabled = false;
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}