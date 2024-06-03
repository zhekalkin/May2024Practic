using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Runtime.Remoting.Channels;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.OleDb;

namespace EBook
{
    public partial class test : Form
    {
        int quection_count; //колличество вопросов
        int correct_answers; //правильные ответы
        int wrong_answer; //Неправильный ответ
        
        string[] array; //Массив

        int correct_answer_number; // номер правильного ответа
        int selected_answer; //номер выбранного ответа

        System.IO.StreamReader Read;

        public static string ConnectString = "Provider = Microsoft.Jet.OLEDB.4.0; Data Source = database.mdb;";
        private OleDbConnection myConnection;

        public test()
        {
            InitializeComponent();
            this.CenterToScreen();
            MaximizeBox = false;
            myConnection = new OleDbConnection(ConnectString);
        }

        void start() 
        {
            var Encoding = System.Text.Encoding.GetEncoding(65001);

            try
            {
                Read = new System.IO.StreamReader (
                    System.IO.Directory.GetCurrentDirectory()+@"\t.txt", Encoding
                    );
                this.Text = Read.ReadLine();

                quection_count      = 0;
                correct_answers     = 0;
                wrong_answer        = 0;

                array = new String[30];

            }

            catch (Exception)
            {
                MessageBox.Show("Ошибка навязанная разработчиком =)");
            }

            вопрос();

        }

        void вопрос() 
        {
            label1.Text = Read.ReadLine();

            radioButton1.Text = Read.ReadLine();
            radioButton2.Text = Read.ReadLine();
            radioButton3.Text = Read.ReadLine();
            radioButton4.Text = Read.ReadLine();
            radioButton5.Text = Read.ReadLine();
            radioButton6.Text = Read.ReadLine();
            radioButton7.Text = Read.ReadLine();
            radioButton8.Text = Read.ReadLine();

            correct_answer_number = int.Parse(Read.ReadLine());

            radioButton1.Checked = false;
            radioButton2.Checked = false;
            radioButton3.Checked = false;
            radioButton4.Checked = false;
            radioButton5.Checked = false;
            radioButton6.Checked = false;
            radioButton7.Checked = false;
            radioButton8.Checked = false;

            button2.Enabled = false;

            quection_count = quection_count + 1;

            if (Read.EndOfStream == true) button2.Text = "Завершить";
        }

        void состояниепереключения(object sender, EventArgs e) 
        {
            button2.Enabled = true;
            button2.Focus();
            RadioButton Переключатель = (RadioButton)sender;

            var tmp = Переключатель.Name;

            selected_answer = int.Parse(tmp.Substring(11)); 
        }

        private void test_Load(object sender, EventArgs e)
        {
            button2.Text = "Следующий вопрос";
            button1.Text = "Выйти из теста";

            radioButton1.CheckedChanged += new EventHandler(состояниепереключения);
            radioButton2.CheckedChanged += new EventHandler(состояниепереключения);
            radioButton3.CheckedChanged += new EventHandler(состояниепереключения);
            radioButton4.CheckedChanged += new EventHandler(состояниепереключения);
            radioButton5.CheckedChanged += new EventHandler(состояниепереключения);
            radioButton6.CheckedChanged += new EventHandler(состояниепереключения);
            radioButton7.CheckedChanged += new EventHandler(состояниепереключения);
            radioButton8.CheckedChanged += new EventHandler(состояниепереключения);

            start();

            myConnection.Open();
            string query1 = "UPDATE users SET mark = (Test_1 + Test_2 + Test_3 + Test_4)/4  WHERE ID = " + Int32.Parse(Globals.ID) + "";
            OleDbCommand command1 = new OleDbCommand(query1, myConnection);
            command1.ExecuteNonQuery();
            myConnection.Close();
        }

        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void radioButton2_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void radioButton3_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void radioButton4_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void radioButton5_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void radioButton6_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void radioButton7_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void radioButton8_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Dispose();
            menuVebora f2 = new menuVebora();
            f2.ShowDialog();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            myConnection.Open();

            if (selected_answer == correct_answer_number)
            {
                correct_answers = correct_answers + 1;
            }

            if (selected_answer != correct_answer_number) 
            {
                wrong_answer = wrong_answer + 1;

                array[wrong_answer] = label1.Text;
            }

            if (button2.Text == "Заново") 
            {
                myConnection.Close();
                button2.Text = "Следующий вопрос";

                radioButton1.Visible = true;
                radioButton2.Visible = true;
                radioButton3.Visible = true;
                radioButton4.Visible = true;
                radioButton5.Visible = true;
                radioButton6.Visible = true;
                radioButton7.Visible = true;
                radioButton8.Visible = true;

                start();

                return;
            }

            if (button2.Text == "Завершить") 
            {
                
                Read.Close();

                radioButton1.Visible = false;
                radioButton2.Visible = false;
                radioButton3.Visible = false;
                radioButton4.Visible = false;
                radioButton5.Visible = false;
                radioButton6.Visible = false;
                radioButton7.Visible = false;
                radioButton8.Visible = false;

                label1.Text = string.Format("Тестирование завершено.\n" + "Правильных ответов: {0} из {1}.\n" + "Набранные баллы: {2:F2}.", correct_answers, quection_count, (correct_answers * 5.0F) / quection_count);

                button2.Text = "Заново";

                var Str = "Список ошибок " + ":\n\n";

                for (int i = 1; i <= wrong_answer; i++)
                    Str = Str + array[i] + "\n";

                if (wrong_answer != 0)
                {
                    MessageBox.Show(Str, "Тест закончен");
                }

                OleDbDataAdapter ada = new OleDbDataAdapter("SELECT COUNT (*) FROM users WHERE ID = (" + Int32.Parse(Globals.ID) + ")", myConnection);
                DataTable dt = new DataTable();
                ada.Fill(dt);

                // if (fm.label2.Text != "Вы не вошли" || Globals.ID == 2)
                //  {
                    //string query = "INSERT INTO users (Test_1)  VALUES ('" +f+ "') WHERE ID = (" + Globals.ID + ") ";
                    string query = "UPDATE users SET Test_END = true WHERE ID = " + Int32.Parse(Globals.ID) + "";
                    OleDbCommand command = new OleDbCommand(query, myConnection);
                    command.ExecuteNonQuery();
                
                    //string query1 = "UPDATE users SET mark VALUES ((Test_1 + Test_2 + Test_3 Test_4)/4)  WHERE ID = " + Int32.Parse(Globals.ID) + "";
                    

                // }




            }
            if (button2.Text == "Следующий вопрос") вопрос();
            myConnection.Close();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void test_FormClosed(object sender, FormClosedEventArgs e)
        {
            //this.Dispose();
           // Practice f2 = new Practice();
           // f2.Show();

            this.Dispose();
            
        }

        private void test_FormClosing(object sender, FormClosingEventArgs e)
        {
            
        }
    }
}
