using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using System.Threading;

namespace GreedyAlgorithm
{
    public partial class Form1 : Form
    {
        //количество городов
        int n = 0;
        Algorithms algs = new Algorithms();
        public Form1()
        {
            InitializeComponent();
        }

        private void btnAbout_Click(object sender, EventArgs e)
        {
            MessageBox.Show("1a. Задача коммивояжера. Жадный алгоритм", "Условие задачи");
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            Close();
        }

        //очистка
        private void btnClear_Click(object sender, EventArgs e)
        {
            dGV_Cities.Rows.Clear();
            dGV_Cities.Columns.Clear();
            dGV_Cities.ColumnCount = 1;
            dGV_Cities.RowCount = 1;
            n = 0;
            lB_Way.Clear();
            btnAddFile.Enabled = true;
            btnAddCity.Enabled = true;
            btnRandom.Enabled = false;
            btnRun.Enabled = false;
            //panel1.Visible = false;
            dGV_Result.Rows.Clear();
            dGV_Result.Columns.Clear();
            dGV_Result.ColumnCount = 1;
            dGV_Result.RowCount = 1;
        }

        //добавление городов по 1 вручную
        private void btnAddCity_Click(object sender, EventArgs e)
        {
            void AddOneCity(int i)
            {
                dGV_Cities.Rows.Add();
                dGV_Cities.Columns.Add("newColumnName", "");
                dGV_Cities.Rows[i].HeaderCell.Value = tBCity.Text;
                dGV_Cities.Columns[i].HeaderCell.Value = tBCity.Text;
            }
            bool flag = true;
            for (int i = 0; (flag) && (i < tBCity.Text.Length); i++)
            {
                flag = Char.IsLetter(tBCity.Text[i]);
            };
            if ((flag) && (tBCity.Text.Length != 0))
            {
                AddOneCity(n);
                tBCity.Clear();
                n++;
            }
            else
                MessageBox.Show("Введено недопустимое значение!",
                "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            if (n == 2)
            {
                btnRandom.Enabled = true;
            }
        }

        //добавление городов из файла
        private void btnAddFile_Click(object sender, EventArgs e)
        {
            string[] str;
            StreamReader f = new StreamReader("1.txt", Encoding.GetEncoding(1251));
            {
                str = f.ReadToEnd().Split(new Char[] { ' ', '\n', '\r' });
                int pos = 0;
                for (int i = 0; (i <= dGV_Cities.RowCount - 1) && (str.Length != pos); i++)
                {
                    while (str[pos] == "")
                    {
                        pos++;
                    }
                    dGV_Cities.Rows.Add();
                    dGV_Cities.Columns.Add("newColumnName", "");
                    dGV_Cities.Rows[i].HeaderCell.Value = str[pos];
                    dGV_Cities.Columns[i].HeaderCell.Value = str[pos];
                    n++;
                    pos++;
                }
                f.Close();
            }
            btnRandom.Enabled = true;
            btnAddFile.Enabled = false;
            //dGV_Cities.AutoResizeColumns();
        }

        //загрузка формы
        private void Form1_Load(object sender, EventArgs e)
        {
            dGV_Cities.ColumnCount = 1;
            dGV_Cities.RowCount = 1;
            dGV_Result.ColumnCount = 1;
            dGV_Result.RowCount = 1;
            btnRandom.Enabled = false;
            btnRun.Enabled = false;
            //panel1.Visible = false;
            dGV_Result.Rows.Add();
            dGV_Result.Columns.Add("newColumnName", "");
            dGV_Result.Rows[0].HeaderCell.Value = "t";
            dGV_Result.Rows[1].HeaderCell.Value = "S";
            dGV_Result.Columns[0].HeaderCell.Value = "Полный перебор";
            dGV_Result.Columns[1].HeaderCell.Value = "Жадный алгоритм";
            //dGV_Result.AutoResizeColumns();
        }

        //заполнить случайными расстояниями
        private void btnRandom_Click(object sender, EventArgs e)
        {
            Random rand = new Random();
            for (int i = 0; (i <= n - 1); i++)
                for (int j = 0; (j <= n - 1); j++)
                {
                    if (i == j)
                    {
                        dGV_Cities.Rows[j].Cells[i].Value = "0";
                    }
                    else
                    {
                        dGV_Cities.Rows[i].Cells[j].Value = Convert.ToString(rand.Next(10, 250));
                    }
                };
            //panel1.Visible = true;
            btnRun.Enabled = true;
        }

        private void CallGreedyFunc()
        {
            List<int> way = new List<int>();
            string cities1 = "";
            int min1 = 0;
            int[,] TR = new int[dGV_Cities.ColumnCount - 1, dGV_Cities.ColumnCount - 1];
            for (int i = 0; i < dGV_Cities.ColumnCount - 1; i++)
                for (int j = 0; j < dGV_Cities.ColumnCount - 1; j++)
                    TR[i, j] = int.Parse(dGV_Cities.Rows[i].Cells[j].Value.ToString());
            DateTime FirstTime1 = DateTime.Now;
            way = algs.FindWayGreedyAlgorithm(TR, ref min1);
            DateTime SecondTime1 = DateTime.Now;
            for (int i = 0; i < n; i++)
            {
                cities1 = cities1 + dGV_Cities.Rows[way[i]].HeaderCell.Value.ToString() + Environment.NewLine;
            }
            lB_Way.Invoke(new Action(() => { lB_Way.Text += Environment.NewLine + "Жадный алгоритм:" +  Environment.NewLine + cities1 + "--------------------"; }));
            string time1 = Convert.ToString(SecondTime1.Subtract(FirstTime1).TotalMilliseconds);
            dGV_Result.Rows[0].Cells[1].Value = time1;
            dGV_Result.Rows[1].Cells[1].Value = Convert.ToString(min1);
        }

        //полный перебор
        private void CallFullFunc()
        {
            List<int> way = new List<int>();
            string cities2 = "";
            int min2 = 0;
            int[,] TR = new int[dGV_Cities.ColumnCount - 1, dGV_Cities.ColumnCount - 1];
            for (int i = 0; i < dGV_Cities.ColumnCount - 1; i++)
                for (int j = 0; j < dGV_Cities.ColumnCount - 1; j++)
                    TR[i, j] = int.Parse(dGV_Cities.Rows[i].Cells[j].Value.ToString());
            DateTime FirstTime2 = DateTime.Now;
            way = algs.FindMinWayExhaustiveSearch(TR, ref min2);
            DateTime SecondTime2 = DateTime.Now;
            for (int i = 0; i < n; i++)
            {
                cities2 = cities2 + dGV_Cities.Rows[way[i] - 1].HeaderCell.Value.ToString() + Environment.NewLine;
            }
            lB_Way.Invoke(new Action(() => { lB_Way.Text += Environment.NewLine + "Полный перебор:" + 
                Environment.NewLine + cities2 + "--------------------"; }));
            string time2 = Convert.ToString(SecondTime2.Subtract(FirstTime2).TotalMilliseconds);
            dGV_Result.Rows[0].Cells[0].Value = time2;
            dGV_Result.Rows[1].Cells[0].Value = Convert.ToString(min2);

        }

        private void btnRun_Click(object sender, EventArgs e)
        {
            btnRandom.Select();
            lB_Way.Clear();
            Thread thread1 = new Thread(CallGreedyFunc);
            Thread thread2 = new Thread(CallFullFunc);
            thread1.Start();
            thread2.Start();
            btnRun.Enabled = false;
        }
    }
}
