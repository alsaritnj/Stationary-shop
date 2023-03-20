using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Stationary_shop
{
    public partial class Form6 : Form
    {
        public Form6()
        {
            InitializeComponent();
        }

        Merchandise[] merchandises = new Merchandise[100];
        int numberOfMerchandises;
        double sum;

        private void Form6_Load(object sender, EventArgs e)
        {
            this.CenterToScreen();
            this.Text = "Канцелярия";
            this.Icon = new Icon(@"Files\Pictures\forms icon.ico");

            sum = 0;
            String[] s = System.IO.File.ReadAllLines(@"Files\список товаров.txt");
            numberOfMerchandises = 0;
            DataTable dt = new DataTable();
            dt.Columns.Add("Категория товара");
            dt.Columns.Add("Название товара");
            dt.Columns.Add("Цена товара");
            try
            {
                for (int i = 0; i < s.Length; i += 3)
                {
                    merchandises[numberOfMerchandises] = new Merchandise(s[i], s[i + 1], System.Convert.ToDouble(s[i + 2]));
                    numberOfMerchandises++;
                }

                for (int i = 0; i < numberOfMerchandises; i++)
                {
                    DataRow st = dt.NewRow();
                    st[0] = merchandises[i].Kategory;
                    st[1] = merchandises[i].Name;
                    st[2] = merchandises[i].Price;
                    dt.Rows.Add(st);
                }
                dataGridView1.DataSource = dt;
                dataGridView1.Columns[0].Width = this.Size.Width / 3;

                dataGridView1.Columns[1].Width = this.Size.Width / 3; ;
                dataGridView1.Columns[2].Width = (this.Size.Width / 3);
            }
            catch
            {
                MessageBox.Show("Не верный путь к файлу!", "Ошибка программы!",
                MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            comboBox1.Items.Add(merchandises[0].Kategory);
            for (int i = 1; i < numberOfMerchandises; i++)
            {
                bool b = false;
                for (int j = 0; j < i; j++)
                    if (merchandises[j].Kategory == merchandises[i].Kategory)
                        b = true;
                if (!b)
                {
                    comboBox1.Items.Add(merchandises[i].Kategory);
                }
            }
            comboBox1.Items.Add("Все");
            comboBox1.Text = "Все";
        }

        private void button1_Click(object sender, EventArgs e)
        {
            using (System.IO.StreamWriter file = new
            System.IO.StreamWriter(@"Files\заказ.txt", true))
            {
                file.WriteLine(richTextBox1.Text);
                file.WriteLine("Стоимость: " + sum + " рублей");
            }
            sum = 0;
            label3.Text = "Стоимость заказа:";
            richTextBox1.Text = "";
            comboBox1.Text = "Все";
            Form7 f = new Form7();
            f.Show();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            sum = 0;
            label3.Text = "Стоимость заказа:";
            richTextBox1.Text = "";
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            DataTable dt = new DataTable();
            dt.Columns.Add("Категория товара");
            dt.Columns.Add("Название товара");
            dt.Columns.Add("Цена товара");
            for (int i = 0; i < numberOfMerchandises; i++)
            {
                DataRow st = dt.NewRow();
                if (comboBox1.Text == "Все" || comboBox1.Text == merchandises[i].Kategory)
                {
                    st[0] = merchandises[i].Kategory;
                    st[1] = merchandises[i].Name;
                    st[2] = merchandises[i].Price;
                    dt.Rows.Add(st);
                }
            }
            dataGridView1.DataSource = dt;
            dataGridView1.Columns[0].Width = this.Size.Width / 3;
            dataGridView1.Columns[1].Width = this.Size.Width / 3; ;
            dataGridView1.Columns[2].Width = (this.Size.Width / 3);
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            string nazvanie_tovara = Convert.ToString(dataGridView1[1, e.RowIndex].Value);
            richTextBox1.Text += nazvanie_tovara + "\n";
            double stoimost = Convert.ToDouble(Convert.ToString(dataGridView1[2, e.RowIndex].Value));
            sum += stoimost;
            label3.Text = "Стоимость заказа: " + sum;
        }
    }
}
