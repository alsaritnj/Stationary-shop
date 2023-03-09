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
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();
        }

        private void Form2_Load(object sender, EventArgs e)
        {
            this.CenterToScreen();
            this.Text = "Канцелярия";
            this.Icon = new Icon(@"Files\Pictures\forms icon.ico");

            richTextBox1.ReadOnly = true;

            try
            {
                String[] s = System.IO.File.ReadAllLines(@"Files\Отзывы.txt"); 
                for (int i = 0; i < s.Length; i++)
                {
                    richTextBox1.Text += s[i] + "\n";
                }
            }
            catch
            {
                MessageBox.Show("Ошибка открытия файла!", "Ошибка программы!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
