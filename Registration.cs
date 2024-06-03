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
    public partial class Registration : Form
    {
        public static string ConnectString = "Provider = Microsoft.Jet.OLEDB.4.0; Data Source = database.mdb;";


        private OleDbConnection myConnection;

        public Registration()
        {
            InitializeComponent();

            this.CenterToScreen();

            myConnection = new OleDbConnection(ConnectString);

            myConnection.Open();
            //MaximizeBox = false;
            

            //podkl.ConnectionString = @"Driver={Microsoft Access Driver (*.mdb, *.accdb)};Dbq=d:Ежедневник.accdb
        }

        private void Registration_Load(object sender, EventArgs e)
        {


        }

        private void Registration_FormClosed(object sender, FormClosedEventArgs e)
        {
            myConnection.Close();
            this.Dispose();
            
        }

        private void button2_Click(object sender, EventArgs e)
        {
            textBox1.Text = null;//логин
            textBox2.Text = null;//имя
            textBox3.Text = null;//фамилия
            textBox4.Text = null;//пароль
            textBox5.Text = null;//повторить пароль
        }

        private void button1_Click(object sender, EventArgs e)
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
                MessageBox.Show("Скорее всего вы не заполнили все строки, пожалуйста заполните имеющиеся строки.", "Что-то пошло не так!");
            }
            else 
            {

                if (textBox4.Text != textBox5.Text)
                {

                    MessageBox.Show("Пароли не совпадают, пожалуйста проверьте правильность.", "Пароли не совпадают! >_<");

                }
                else 
                {
                    if (isUserExists())
                    {
                        return;
                    }
                    else {
                        string query = "INSERT INTO Users (login, pasword, firstname, lastname) VALUES ('" + textBox1.Text + "' , '" + textBox2.Text + "', '" + textBox3.Text + "', '" + textBox4.Text + "')";
                        OleDbCommand command = new OleDbCommand(query, myConnection);
                        command.ExecuteNonQuery();

                        MessageBox.Show("Ученая запись была успешно создана!", "Успешно!");
                    }
                    
                }
                    
            }
        }

        public Boolean isUserExists()
        {
            OleDbDataAdapter ada = new OleDbDataAdapter("SELECT COUNT (*) FROM users WHERE login = '" + textBox1.Text + "'", myConnection);
            DataTable dt = new DataTable();
            ada.Fill(dt);

            //сравнить значение с условием
            // if (textBox1.Text == Log && textBox2.Text == pwd)
            if (dt.Rows[0][0].ToString() == "1")
            {
                //действие со значением #
                MessageBox.Show("Такой логин существует, введите другой.", "Внимание!");
                return true;
            }
            else
            {
                return false;
            }
        }

        private void Registration_FormClosing(object sender, FormClosingEventArgs e)
        {
            myConnection.Close();
        }
    }
}
