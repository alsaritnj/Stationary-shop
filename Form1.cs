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
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void Form1_Load(object sender, EventArgs e)
        {
            this.CenterToScreen();
            this.Text = "Канцелярия";
            this.Icon = new Icon(@"Files\Pictures\forms icon.ico");
            pictureBox1.BackgroundImageLayout = ImageLayout.Stretch;
            pictureBox1.BackgroundImage = Image.FromFile(@"Files\Pictures\shop logo.png");

            AddMerchandisesFromFileToDataGridView(@"Files\список товаров.txt", this, dataGridView1);
        }

        private static void AddMerchandisesFromFileToDataGridView(string filePath, Form form, DataGridView dataGridView)
        {
            DataTable dataTable = new DataTable();

            dataTable.Columns.Add("Категория товара");
            dataTable.Columns.Add("Название товара");
            dataTable.Columns.Add("Цена товара");

            Merchandise[] Merchandises = new Merchandise[100];
            int number = 0;

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
                dataGridView.Columns[1].Width = form.Size.Width / 3;;
                dataGridView.Columns[2].Width = (form.Size.Width / 3);
            }
            catch
            {
                MessageBox.Show("Не верные данные в файле!", "Ошибка программы!",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            Application.Exit();
        }

        private void отзывыToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form2 form2 = new Form2();
            form2.Show();
        }

        private void администрированиеToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form3 form3 = new Form3();
            form3.Show();
        }

        private void входРегистрацияToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form5 form5 = new Form5();
            form5.Show();
        }
    }
}
