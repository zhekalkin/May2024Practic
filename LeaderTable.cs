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
    public partial class LeaderTable : Form
    {

        public static string ConnectString = "Provider = Microsoft.Jet.OLEDB.4.0; Data Source = database.mdb;";


        private OleDbConnection myConnection;
        public LeaderTable()
        {
            InitializeComponent();
            this.CenterToScreen();

            myConnection = new OleDbConnection(ConnectString);
            myConnection.Open();

            MaximizeBox = false;

        }

        private void LeaderTable_Load(object sender, EventArgs e)
        {
            string query = "SELECT firstname, lastname , mark FROM users ORDER BY ID";

            OleDbCommand command = new OleDbCommand(query, myConnection);

            OleDbDataReader reader = command.ExecuteReader();

            listBox1.Items.Clear();

            while (reader.Read() ) 
            {
                if (reader[2].ToString() != string.Empty) {
                    listBox1.Items.Add("ИМЯ ФАМИЛИЯ: " + reader[0].ToString() + " , " + reader[1].ToString() + ". ОЦЕНКА:  " + reader[2].ToString() + " ");



                }
                
            }

        }

        private void LeaderTable_FormClosed(object sender, FormClosedEventArgs e)
        {
            this.Dispose();
            
        }

        private void dataGridView2_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
