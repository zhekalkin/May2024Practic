using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.OleDb;
namespace EBook
{
    public partial class test_2 : Form
    {
        int n = 0;
        int[] answer;

        public static string ConnectString = "Provider = Microsoft.Jet.OLEDB.4.0; Data Source = database.mdb;";
        private OleDbConnection myConnection;
        public test_2()
        {
            InitializeComponent();
            this.CenterToScreen();
            answer = new int[7];
            MaximizeBox = false;
            myConnection = new OleDbConnection(ConnectString);
        }

        private void test_2_Load(object sender, EventArgs e)
        {
            var bmp = new Bitmap(EBook.Properties.Resources.t1);
            pictureBox1.Image = bmp;

            
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void test_2_FormClosed(object sender, FormClosedEventArgs e)
        {
            this.Dispose();
            menuVebora f1 = new menuVebora();
            f1.ShowDialog();
        }
        public void show(int n)
        {
            int n1 = n + 1;
            label1.Text = "Вопрос № " + n1;
            switch (answer[n])
            {
                case 0:
                    radioButton1.Checked = false;
                    radioButton2.Checked = false;
                    break;
                case 1:
                    radioButton1.Checked = true;
                    radioButton2.Checked = false;
                    break;
                case 2:
                    radioButton1.Checked = false;
                    radioButton2.Checked = true;
                    break;

            }
            switch (n)
            {
                case 0:
                    pictureBox1.Image = new Bitmap(EBook.Properties.Resources.t1);
                    break;
                case 1:
                    pictureBox1.Image = new Bitmap(EBook.Properties.Resources.t2);
                    break;
                case 2:
                    pictureBox1.Image = new Bitmap(EBook.Properties.Resources.t3);
                    break;
                case 3:
                    pictureBox1.Image = new Bitmap(EBook.Properties.Resources.t4);
                    break;
                case 4:
                    pictureBox1.Image = new Bitmap(EBook.Properties.Resources.t5);
                    break;
                case 5:
                    pictureBox1.Image = new Bitmap(EBook.Properties.Resources.t6);
                    break;
                case 6:
                    pictureBox1.Image = new Bitmap(EBook.Properties.Resources.t7);
                    break;

            }
        }
        private void button1_Click_1(object sender, EventArgs e)
        {
            n++;
            if (n > 6) n = 6;
            show(n);
            if (n == 6)
            {
                button3.Visible = true;
            }
        }

        private void button2_Click_1(object sender, EventArgs e)
        {
            n--;
            if (n < 0) n = 0;
            show(n);
        }

        private void radioButton1_CheckedChanged_1(object sender, EventArgs e)
        {
            answer[n] = 1;
        }

        private void radioButton2_CheckedChanged_1(object sender, EventArgs e)
        {
            answer[n] = 2;
        }


        private void button3_Click_1(object sender, EventArgs e)
        {
            myConnection.Open();
            int correct = 0;
            if (answer[0] == 1)
            {
                correct++;
            }
            if (answer[1] == 1)
            {
                correct++;
            }
            if (answer[2] == 1)
            {
                correct++;
            }
            if (answer[3] == 1)
            {
                correct++;
            }
            if (answer[4] == 1)
            {
                correct++;
            }
            if (answer[5] == 1)
            {
                correct++;
            }
            if (answer[6] == 1)
            {
                correct++;
            }

            this.Dispose();


            button1.Visible = false;
            button2.Visible = false;
            string f = "0";

            int prcnt = correct * 100 / 7;
            string msg;
            msg = "Вы не прошли тест! Попытайтесь снова или обратитесь к изучению *Теориитический материал*.";
            //Сделать для всех тестов
            if (prcnt >= 90 && prcnt <= 100)
            {
                msg = "Вы прошли тест на 5!";
                f = "5";
                MessageBox.Show("Вы прошли тест на " + prcnt + "%. " + msg);
            }
            else
            {
                if (prcnt >= 70 && prcnt < 90)
                {
                    msg = "Вы прошли тест на 4!";
                    f = "4";
                    MessageBox.Show("Вы прошли тест на " + prcnt + "%. " + msg);
                }
                else
                {
                    if (prcnt >= 50 && prcnt < 70)
                    {
                        msg = "Вы прошли тест на 3!";
                        f = "3";
                        MessageBox.Show("Вы прошли тест на " + prcnt + "%. " + msg);
                    }
                    else
                    {
                        MessageBox.Show("Вы прошли тест на " + prcnt + "%. " + msg);
                        this.Dispose();
                        test_2 a = new test_2();
                        a.ShowDialog();
                    }
                }
            }

            //Запрос в таблицу Access

            // Main fm = new Main();
            OleDbDataAdapter ada = new OleDbDataAdapter("SELECT COUNT (*) FROM users WHERE ID = (" + Int32.Parse(Globals.ID) + ")", myConnection);
            DataTable dt = new DataTable();
            ada.Fill(dt);

            // if (fm.label2.Text != "Вы не вошли" || Globals.ID == 2)
            //  {
            if (f != "0")
            {

                //string query = "INSERT INTO users (Test_1)  VALUES ('" +f+ "') WHERE ID = (" + Globals.ID + ") ";
                string query = "UPDATE users SET Test_2 = \"" + f + "\" WHERE ID = " + Int32.Parse(Globals.ID) + "";
                OleDbCommand command = new OleDbCommand(query, myConnection);
                command.ExecuteNonQuery();
            }
            // }
            else
            {
                MessageBox.Show("Вы не авторизировались как пользователь!Данные буду утеряны!");
                return;
            }

            myConnection.Close();
        }

        private void test_2_FormClosing(object sender, FormClosingEventArgs e)
        {
            
            
        }
    }
}
