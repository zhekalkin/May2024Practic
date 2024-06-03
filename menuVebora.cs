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
    public partial class menuVebora : Form
    {
        public static string ConnectString = "Provider = Microsoft.Jet.OLEDB.4.0; Data Source = database.mdb;";
        private OleDbConnection myConnection;
        public menuVebora()
        {
            InitializeComponent();
            this.CenterToScreen();
            MaximizeBox = false;
            myConnection = new OleDbConnection(ConnectString);
        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void button5_Click(object sender, EventArgs e)
        {
            this.Dispose();
            test f2 = new test();
            f2.ShowDialog();
        }

        private void menuVebora_Load(object sender, EventArgs e)
        {
            
        }

        private void menuVebora_FormClosed(object sender, FormClosedEventArgs e)
        {
            //this.Dispose();
            // Practice f1 = new Practice();
            //f1.Show();

            this.Dispose();
           // Main f1 = new Main();
           // f1.Show();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Dispose();
            test_1 f = new test_1();
            f.ShowDialog();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Dispose();
            test_2 ds = new test_2();
            ds.ShowDialog();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            this.Dispose();
            test_3 s = new test_3();
            s.ShowDialog();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            this.Dispose();
            test_4 s1 = new test_4();
            s1.ShowDialog();
        }
        private void menuVebora_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (Globals.Log != "Вы не вошли")
            {

                myConnection.Open();
                string query1 = "UPDATE users SET mark = (Test_1 + Test_2 + Test_3 + Test_4)/4  WHERE ID = " + Int32.Parse(Globals.ID) + "";
                OleDbCommand command1 = new OleDbCommand(query1, myConnection);
                command1.ExecuteNonQuery();
                myConnection.Close();

            }
        }
    }
}
