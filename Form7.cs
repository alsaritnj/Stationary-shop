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
    public partial class Form7 : Form
    {
        public Form7()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            using (System.IO.StreamWriter file = new
            System.IO.StreamWriter(@"Files\Заказ.txt", true))
            {
                file.WriteLine(textBox1.Text);
                file.WriteLine(textBox2.Text);
                file.WriteLine();
}
            MessageBox.Show("Ваш заказ, " + textBox1.Text + ", будет проверен администратором. Мы с вами свяжемся в течении трех дней\n\nСпасибо за заказ!", "Оформление заказа",
            MessageBoxButtons.OK, MessageBoxIcon.Error); this.Close();
        }

        private void Form7_Load(object sender, EventArgs e)
        {
            this.CenterToScreen();
            this.Text = "Канцелярия";
            this.Icon = new Icon(@"Files\Pictures\forms icon.ico");


        }
    }
}
