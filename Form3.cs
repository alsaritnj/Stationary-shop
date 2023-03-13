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
    public partial class Form3 : Form
    {
        public Form3()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                if (textBox1.Text == "")
                {
                    MessageBox.Show("Введите пароль!", "Ошибка программы",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                    this.ActiveControl = textBox1;
                }
                else
                {
                    String[] s = System.IO.File.ReadAllLines(@"Files\Пароль Администратора.txt"); 
                    if (textBox1.Text != s[0])
                    {
                        MessageBox.Show("Не верный пароль!", "Ошибка программы",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                        this.ActiveControl = textBox1;
                        textBox1.Text = "";
                    }
                    else
                    {
                        Form4 form4 = new Form4();
                        form4.Show();

                        this.Close();

                    }
                }
            }
            catch
            {
                MessageBox.Show("Ошибка открытия файла!", "Ошибка программы",
                MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void Form3_Load(object sender, EventArgs e)
        {
            this.CenterToScreen();
            this.Text = "Канцелярия";
            this.Icon = new Icon(@"Files\Pictures\forms icon.ico");

            this.ActiveControl = textBox1;
        }
    }
}
