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


            Merchandise[] Merchandises = new Merchandise[100]; 
            int number = 0;
            try
            {
                String[] s = System.IO.File.ReadAllLines(@"Files\список товаров.txt");
           
                for (int i = 0; i < s.Length; i += 3)
                {
                    Merchandises[number] = new Merchandise(s[i], s[i + 1], Double.Parse(s[i + 2]));
                    number++;
                }

                for (int i = 0; i < number; i++)
                {
                    richTextBox1.Text += Merchandises[i].Kategory + " " 
                        + Merchandises[i].Name + " " 
                        + Merchandises[i].Price + "\n";
                }
            }
            catch
            {
                MessageBox.Show("Не верный путь к файлу!", "Ошибка программы!", 
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
    }
}
