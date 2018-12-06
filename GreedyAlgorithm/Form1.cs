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

namespace GreedyAlgorithm
{
    public partial class Form1 : Form
    {
        //количество городов
        int n = 0;
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
            lB_Way.Items.Clear();
            btnAddFile.Enabled = true;
            btnAddCity.Enabled = true;
            btnRandom.Enabled = false;
            //panel1.Visible = false;
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
        }
    }
}
