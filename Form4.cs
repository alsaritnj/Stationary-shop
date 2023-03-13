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
    public partial class Form4 : Form

    {
        public Form4()
        {
            InitializeComponent();
        }

        Merchandise[] Merchandises = new Merchandise[100];
        int number;

        private void Zapoln_Tab(string filePath, Form form, DataGridView dataGridView)
        {
            DataTable dataTable = new DataTable();

            dataTable.Columns.Add("Категория товара");
            dataTable.Columns.Add("Название товара");
            dataTable.Columns.Add("Цена товара");

            number = 0;

            String[] s = System.IO.File.ReadAllLines(filePath);
            try
            {
                for (int i = 0; i < s.Length; i += 3)
                {
                    Merchandises[number] = new Merchandise(s[i], s[i + 1], Double.Parse(s[i + 2]));
                    number++;
                }

                for (int i = 0; i < number; i++)
                {
                    DataRow newRow = dataTable.NewRow();
                    newRow[0] = Merchandises[i].Kategory;
                    newRow[1] = Merchandises[i].Name;
                    newRow[2] = Merchandises[i].Price;
                    dataTable.Rows.Add(newRow);
                }

                dataGridView.DataSource = dataTable;
                dataGridView.Columns[0].Width = form.Size.Width / 3;
                dataGridView.Columns[1].Width = form.Size.Width / 3; ;
                dataGridView.Columns[2].Width = (form.Size.Width / 3);
            }
            catch
            {
                MessageBox.Show("Не верные данные в файле!", "Ошибка программы!",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void Form4_Load(object sender, EventArgs e)
        {
            this.CenterToScreen();
            this.Text = "Канцелярия";
            this.Icon = new Icon(@"Files\Pictures\forms icon.ico");
            pictureBox1.BackgroundImageLayout = ImageLayout.Stretch;
            pictureBox1.BackgroundImage = Image.FromFile(@"Files\Pictures\shop logo.png");
            Zapoln_Tab(@"Files\список товаров.txt", this, dataGridView1);
            this.ActiveControl = textBox1;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (textBox1.Text == "" || textBox2.Text == "" || textBox3.Text == "")
            {

                MessageBox.Show("Введите данные!", "Ошибка программы", MessageBoxButtons.OK,
                MessageBoxIcon.Error);
                this.ActiveControl = textBox1;
            }
            else
            {
                Merchandises[number] = new Merchandise(textBox1.Text, textBox2.Text, Convert.ToDouble(textBox3.Text));
                using (System.IO.StreamWriter file = new System.IO.StreamWriter(@"Files\список товаров.txt", true))
                {
                    file.WriteLine();
                    file.WriteLine(Merchandises[number].Kategory);
                    file.WriteLine(Merchandises[number].Name); 
                    file.Write(Merchandises[number].Price);
                    MessageBox.Show("Товар добавлен!", "Редактирование данных",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                number++;
            }
            dataGridView1.DataSource = new object();
            Zapoln_Tab(@"Files\список товаров.txt", this, dataGridView1);
            textBox1.Text = "";
            textBox2.Text = "";
            textBox3.Text = "";
        }
    }
}
