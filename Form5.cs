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
    public partial class Form5 : Form
    {
        public Form5()
        {
            InitializeComponent();
        }

        Customer[] customers = new Customer[1000];
        int numberOfCustomers;
        bool customerRegistered;

        private void Form5_Load(object sender, EventArgs e)
        {
            this.CenterToScreen();
            this.Text = "Канцелярия";
            this.Icon = new Icon(@"Files\Pictures\forms icon.ico");
            this.ActiveControl = textBox1;
            customerRegistered = false;
            try
            {
                String[] s = System.IO.File.ReadAllLines(@"Files\учетные данные.txt");
                numberOfCustomers = 0;

                for (int i = 0; i < s.Length; i += 2)
                {
                    customers[numberOfCustomers] = new Customer(s[i], s[i + 1]);
                    numberOfCustomers++;
                }
            } 
            catch
            {
                MessageBox.Show("Ошибка чтения файла!", "Ошибка программы!",
                MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                if (textBox1.Text == "" || textBox2.Text == "" || textBox3.Text == "")
                {
                    MessageBox.Show("Введите данные полностью!", "Создание учетной записи!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    this.ActiveControl = textBox1;
                }
                else
                {
                    if (isLoginRegistered())
                    {

                        MessageBox.Show("Такой логин уже занят!", "Создание учетной записи!",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                        this.ActiveControl = textBox1;
                    }
                    else
                    {
                        if (textBox2.Text != textBox3.Text)
                        {

                            MessageBox.Show("Пароли должны совпадать!", "Создание учетной записи!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            this.ActiveControl = textBox1;
                        }
                        else
                        {
                            customers[numberOfCustomers] = new Customer(textBox1.Text, textBox2.Text);
                            using (System.IO.StreamWriter file = new System.IO.StreamWriter(@"Files\Учетные данные.txt", true))
                            {
                                file.WriteLine(customers[numberOfCustomers].Login);
                                file.WriteLine(customers[numberOfCustomers].Password);
                            }
                            numberOfCustomers++;
                            MessageBox.Show("Регистрация прошла успешно!", "Создание учетной записи!", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            using (System.IO.StreamWriter file = new System.IO.StreamWriter(@"Files\режим.txt"))
                            {
                                file.WriteLine(1);
                                file.WriteLine(textBox1.Text);
                            }
                            customerRegistered = true;
                            this.Close();
                        }
                    }

                }
            }
            catch
            {
                MessageBox.Show("Ошибка регистрации!", "Создание учетной записи!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                textBox1.Text = "";
                textBox2.Text = "";
                textBox3.Text = "";
            }
        }

        private bool isLoginRegistered()
        {
            bool result = false;

            for (int i = 0; i < numberOfCustomers && !result; i++)
            {
                if (textBox1.Text == customers[i].Login)
                {
                    result = true;
                }
            }

            return result;
        }

        private void Form5_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (!customerRegistered)
            {
                using (System.IO.StreamWriter file = new System.IO.StreamWriter(@"Files\режим.txt"))
                {
                    file.WriteLine(0);
                }
            }
        }
    }
}
