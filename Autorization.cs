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
    
    public partial class Autorization : Form
    {
        public static string ConnectString = "Provider = Microsoft.Jet.OLEDB.4.0; Data Source = database.mdb;";


        private OleDbConnection myConnection;

        public Autorization()
        {
            MaximizeBox = false;
            InitializeComponent();
            this.CenterToScreen();
            myConnection = new OleDbConnection(ConnectString);
        }

        private void Autorization_FormClosed(object sender, FormClosedEventArgs e)
        {
            
            if (button1.Focused)
            {
                this.Dispose();
                Main f1 = new Main();
                f1.Show(); 
            }
            
        }

        private void Autorization_Load(object sender, EventArgs e)
        {
            
            //string query = "SELECT ID, login, pasword FROM users ORDER BY ID";
            //OleDbCommand command = new OleDbCommand(query, myConnection);

           // OleDbDataReader reader = command.ExecuteReader();

           // OleDbDataAdapter da = new OleDbDataAdapter(query, myConnection);
           // DataTable dt = new DataTable();
           // da.Fill(dt);
           // dataGridView1.DataSource = dt; //выводим в грид

            
        }

        private void button2_Click(object sender, EventArgs e)
        {
            textBox1.Text = null;//логин
            textBox2.Text = null;//имя
        }

        public void button1_Click(object sender, EventArgs e)
        {
            myConnection.Open();

            if (textBox1.Text == string.Empty)
            {
                MessageBox.Show("Введите логин!", "Внимание!");
            }
            else 
            {
                if (textBox2.Text == string.Empty)
                {
                    MessageBox.Show("Введите пароль!", "Внимание!");
                }
                else 
                {
                    if (textBox1.Text == "admin" && textBox2.Text == "123")
                    {
                        if (textBox1.Text == "admin")
                        {
                            MessageBox.Show("Вы зашли под Администратором - доступны расширенные функции.", "Внимание!");
                        }
                        myConnection.Close();
                        this.Dispose();
                        Main fm = new Main(); 
                        fm.label2.Text = "admin";
                        fm.Show();
                    }
                    else 
                    {
                        //поиск значения в бд
                        //string Log ;
                        //string pwd ;
                        //string query = $"SELECT COUNT (*) FROM users WHERE login = {textBox1.Text}";
                        //string query1 = $"SELECT COUNT (*) FROM users WHERE  pasword = {textBox2.Text}";
                        //OleDbCommand command = new OleDbCommand(query, myConnection);
                        //OleDbCommand command1 = new OleDbCommand(query1, myConnection);
                        //Log = command.ExecuteNonQuery().ToString();
                        //pwd = command.ExecuteNonQuery().ToString();
                        OleDbDataAdapter ada = new OleDbDataAdapter("SELECT COUNT (*) FROM users WHERE login = '" + textBox1.Text + "' AND pasword = '" + textBox2.Text + "'", myConnection);
                        DataTable dt = new DataTable();
                        ada.Fill(dt);

                        OleDbDataAdapter dataAdapter = new OleDbDataAdapter("SELECT ID FROM users WHERE login ='" + textBox1.Text + "' AND pasword ='" + textBox2.Text + "'", myConnection);
                        DataTable dtf = new DataTable();
                        dataAdapter.Fill(dtf);

                        OleDbDataAdapter dataAda= new OleDbDataAdapter("SELECT login FROM users WHERE login ='" + textBox1.Text + "' AND pasword ='" + textBox2.Text + "'", myConnection);
                        DataTable dtf1 = new DataTable();
                        dataAda.Fill(dtf1);
                        //сравнить значение с условием
                        // if (textBox1.Text == Log && textBox2.Text == pwd)
                        if (dt.Rows[0][0].ToString() == "1")
                        {
                            //действие со значением #
                            
                            
                            Main fm = new Main();
                            fm.label2.Text = this.textBox1.Text;
                            fm.button8.Visible = true;
                            fm.Show();
                            myConnection.Close();
                            this.Dispose(); 
                        }
                        else
                        {
                            MessageBox.Show("Вы ввели неправильный учетную запись или пароль, проверьте правильность.", "Внимание!");
                        }
                        if (dtf != null && dtf.Rows.Count > 0)
                        {
                            Globals.ID = dtf.Rows[0][0].ToString();
                            //string f2 = Globals.ID;
                            //MessageBox.Show(f2);
                        }
                        if (dtf1 != null && dtf.Rows.Count > 0)
                        {
                            Globals.Log = dtf.Rows[0][0].ToString();
                            //string f2 = Globals.ID;
                            //MessageBox.Show(f2);
                        }
                    }
                    

                }
            }
            myConnection.Close();

        }
        

        private void Autorization_FormClosing(object sender, FormClosingEventArgs e)
        {
            
        }
    }
}
