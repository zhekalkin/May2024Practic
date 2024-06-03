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
    public partial class editor_users : Form
    {
        public static string ConnectString = "Provider = Microsoft.Jet.OLEDB.4.0; Data Source = database.mdb;";


        private OleDbConnection myConnection;

        public editor_users()
        {
            MaximizeBox = false;
            InitializeComponent();
            this.CenterToScreen();

            myConnection = new OleDbConnection(ConnectString);

            
        }

        private void button_download_Click(object sender, EventArgs e)
        {
           
        }



        private void button_add_Click(object sender, EventArgs e)
        {
            
            if
                 (
                     textBox1.Text == string.Empty ||
                     textBox2.Text == string.Empty ||
                     textBox3.Text == string.Empty ||
                     textBox4.Text == string.Empty ||
                     textBox5.Text == string.Empty
                 )
            {
                MessageBox.Show("Скорее всего вы не заполнили все строки, пожалуйста заполните все имеющиеся строки.", "Что-то пошло не так!");
            }
            else
            {

                if (textBox4.Text != textBox5.Text)
                {

                    MessageBox.Show("Пароли не совпадают, пожалуйста проверьте правильность.", "Пароли не совпадают! >_<");

                }
                else
                {
                    string query = "INSERT INTO Users (login, pasword, firstname, lastname) VALUES ('" + textBox1.Text + "' , '" + textBox4.Text+ "', '" + textBox2.Text + "', '"  +textBox3.Text + "')";
                    OleDbCommand command = new OleDbCommand(query, myConnection);
                    command.ExecuteNonQuery();

                    MessageBox.Show("Ученая запись была успешно создана!", "Успешно!");

                    this.Dispose();
                    editor_users f3 = new editor_users();
                    f3.Show();

                }

            }
            

        }

        private void button_update_Click(object sender, EventArgs e)
        {
            // string query = "UPDATE Users WHERE ID";//(login, pasword, firstname, lastname) ;
            //  OleDbCommand command = new OleDbCommand(query, myConnection);
            //  command.ExecuteNonQuery();
            // MessageBox.Show("Данные обновлены!", "Внимание!");
        }

        private void button_delete_Click(object sender, EventArgs e)
        {
            

            if (dataGridView1.SelectedRows.Count != 1)
            {
                MessageBox.Show("Выберите одну строку!", "Внимание!");
                return;
            }
            int index = dataGridView1.SelectedRows[0].Index;

            if (dataGridView1.Rows[index].Cells[0].Value == null)
            {
                MessageBox.Show("Не все данные введены!", "Внимание!");
                return;
            }

            string id = dataGridView1.Rows[index].Cells[0].Value.ToString();

            string query = $"DELETE FROM users WHERE ID={id} ";

            OleDbCommand command = new OleDbCommand(query, myConnection);
            
            if (command.ExecuteNonQuery() != 1)
            {
                MessageBox.Show("Ошибка выполнения запроса!", "Ошибка!");
            }
            else
            {

                MessageBox.Show("Данные удалены!", "Внимание!");

                dataGridView1.Rows.RemoveAt(index);

            }
            
        }

        private void выйтиИзПрограммыToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void покинутьРедакторПользователейToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Dispose();
            Main f = new Main();
            f.Show();
        }

        private void помощToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Кнопка -Добавить- добавляет данные в таблицу, кнопка -удалить- удаляет данные из таблици!", "Внимание!");
        }

        private void editor_users_Load(object sender, EventArgs e)
        {
            myConnection.Open();
            string query = "SELECT ID, login, pasword, firstname, lastname FROM users ORDER BY ID";
            OleDbCommand command = new OleDbCommand(query, myConnection);

            OleDbDataReader reader = command.ExecuteReader();

            OleDbDataAdapter da = new OleDbDataAdapter(query, myConnection);
            DataTable dt = new DataTable();
            da.Fill(dt);
            dataGridView1.DataSource = dt; //выводим в грид
            
        }

        private void editor_users_FormClosed(object sender, FormClosedEventArgs e)
        {
            this.Dispose();
            Main f = new Main();
            f.Show();
        }

        private void usersBindingSource_CurrentChanged(object sender, EventArgs e)
        {

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void editor_users_FormClosing(object sender, FormClosingEventArgs e)
        {
            myConnection.Close();
        }

        private void добавитьToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if
                 (
                     textBox1.Text == string.Empty ||
                     textBox2.Text == string.Empty ||
                     textBox3.Text == string.Empty ||
                     textBox4.Text == string.Empty ||
                     textBox5.Text == string.Empty
                 )
            {
                MessageBox.Show("Скорее всего вы не заполнили все строки, пожалуйста заполните все имеющиеся строки.", "Что-то пошло не так!");
            }
            else
            {

                if (textBox4.Text != textBox5.Text)
                {

                    MessageBox.Show("Пароли не совпадают, пожалуйста проверьте правильность.", "Пароли не совпадают! >_<");

                }
                else
                {
                    string query = "INSERT INTO Users (login, pasword, firstname, lastname) VALUES ('" + textBox1.Text + "' , '" + textBox4.Text + "', '" + textBox2.Text + "', '" + textBox3.Text + "')";
                    OleDbCommand command = new OleDbCommand(query, myConnection);
                    command.ExecuteNonQuery();

                    MessageBox.Show("Ученая запись была успешно создана!", "Успешно!");

                    this.Dispose();
                    editor_users f3 = new editor_users();
                    f3.Show();

                }

            }
        }

        private void удалитьToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count != 1)
            {
                MessageBox.Show("Выберите одну строку!", "Внимание!");
                return;
            }
            int index = dataGridView1.SelectedRows[0].Index;

            if (dataGridView1.Rows[index].Cells[0].Value == null)
            {
                MessageBox.Show("Не все данные введены!", "Внимание!");
                return;
            }

            string id = dataGridView1.Rows[index].Cells[0].Value.ToString();

            string query = $"DELETE FROM users WHERE ID={id} ";

            OleDbCommand command = new OleDbCommand(query, myConnection);

            if (command.ExecuteNonQuery() != 1)
            {
                MessageBox.Show("Ошибка выполнения запроса!", "Ошибка!");
            }
            else
            {

                MessageBox.Show("Данные удалены!", "Внимание!");

                dataGridView1.Rows.RemoveAt(index);

            }
        }
    }
}
