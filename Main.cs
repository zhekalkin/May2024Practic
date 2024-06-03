using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Diagnostics;
using System.Data.OleDb;
using System.Runtime.InteropServices;
using Excel = Microsoft.Office.Interop.Excel;

namespace EBook
{
    
    public partial class Main : Form
    {
        public static string ConnectString = "Provider = Microsoft.Jet.OLEDB.4.0; Data Source = database.mdb;";
        private OleDbConnection myConnection;
        public Main()
        {
            InitializeComponent();
            this.CenterToScreen();
            myConnection = new OleDbConnection(ConnectString);
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            if (label2.Text == "admin")
            {
                button7.Visible = true;
               // отчетToolStripMenuItem.Visible = true;
                редакторПользователейToolStripMenuItem.Visible = true;
                button8.Visible = true;
                //button9.Visible = true;
            }

            //mark = (test_1 + test_2 + test_3 + test_4) / 4

        }

        private void panel5_Paint(object sender, PaintEventArgs e)
        {

        }

        private void groupBox3_Enter(object sender, EventArgs e)
        {

        }

        private void Main_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
            this.Dispose();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Hide();

            Autorization f2 = new Autorization();

            f2.ShowDialog();

            
        }

        private void button4_Click(object sender, EventArgs e)
        {
            Registration f3 = new Registration();

            f3.ShowDialog();

            
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Training f4 = new Training();

            f4.ShowDialog();


        }

        private void button2_Click(object sender, EventArgs e)
        {
            LeaderTable f5 = new LeaderTable();

            f5.ShowDialog();

            
        }
        

        private void button5_Click(object sender, EventArgs e)
        {
            Theory f6 = new Theory();
            f6.ShowDialog();
            
        }

        private void button6_Click(object sender, EventArgs e)
        {
            // Practice f7 = new Practice();
            // f7.Show();
            // this.Hide();
            if (label2.Text != "Вы не вошли") 
            {

                myConnection.Open();
                string query1 = "UPDATE users SET mark = (Test_1 + Test_2 + Test_3 + Test_4)/4  WHERE ID = " + Int32.Parse(Globals.ID) + "";
                OleDbCommand command1 = new OleDbCommand(query1, myConnection);
                command1.ExecuteNonQuery();
                myConnection.Close();

            }
            

            menuVebora f2 = new menuVebora();
            f2.ShowDialog();
            
        }

        private void button7_Click(object sender, EventArgs e)
        {
           editor_users edu = new editor_users();

           edu.Show();

           this.Hide();
        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void официальныйСайтЕСКдToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Process.Start(@"https://c-kd.ru/eskd");
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void отчетToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void редакторПользователейToolStripMenuItem_Click(object sender, EventArgs e)
        {
            editor_users edu = new editor_users();

            edu.Show();

            this.Hide();
        }

        private void button8_Click(object sender, EventArgs e)
        {
            Main ed1 = new Main();

            ed1.Show();

            this.Hide();
        }

        private void тест1ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            
            test_1 f = new test_1();
            f.ShowDialog();
        }

        private void тест2ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            
            test_2 ds = new test_2();
            ds.ShowDialog();
        }

        private void тест3ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            
            test_3 s = new test_3();
            s.ShowDialog();
        }

        private void тест4ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            
            test_4 s1 = new test_4();
            s1.ShowDialog();
        }

        private void итоговыйТестToolStripMenuItem_Click(object sender, EventArgs e)
        {
            
            test f2 = new test();
            f2.ShowDialog();
        }

        private void встроенныйУчебникToolStripMenuItem_Click(object sender, EventArgs e)
        {
            TextBook_inside f1 = new TextBook_inside();

            f1.Show();

            
        }

        private void учебникВФорматеWordToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Process.Start(@"WordBook_Inside.docx");
        }

        private void выйтиИзПрограммыToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void button9_Click(object sender, EventArgs e)
        {
            Reports f1 = new Reports();

            f1.Show();
        }
    }
    public static class Globals
    {
        public static String ID;
        public static String Log = "Вы не вошли";
    }
}
