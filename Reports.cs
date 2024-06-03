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
using System.Runtime.InteropServices;
using Excel = Microsoft.Office.Interop.Excel;

namespace EBook
{

    public partial class Reports : Form
    {
        public static string ConnectString = "Provider = Microsoft.Jet.OLEDB.4.0; Data Source = database.mdb;";
        private OleDbConnection myConnection;
        Excel.Application ExRep = new Excel.Application();

        public Reports()
        {
            MaximizeBox = false;
            InitializeComponent();
            myConnection = new OleDbConnection(ConnectString);
        }

        private void printPreviewControl1_Click(object sender, EventArgs e)
        {

        }

        private void Reports_Load(object sender, EventArgs e)
        {
            if (ExRep == null)
            {
                label3.Text = "Excel библиотека не подключена! Функции печати ограничены.";
                label3.ForeColor = System.Drawing.Color.Red;
                button1.Enabled = false;
                button2.Enabled = false;
            }
            else
            {
                label3.Text = "Excel библиотека подключена! Печать доступна!";
                label3.ForeColor = System.Drawing.Color.Green;
            }


            
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {

            Excel.Worksheet xlWorksheet;
            Excel.Workbook xlWorkbook;

            
            object misValue = System.Reflection.Missing.Value;
            xlWorkbook = ExRep.Workbooks.Add(misValue);
            xlWorksheet = (Excel.Worksheet)xlWorkbook.Worksheets.get_Item(1);


            myConnection.Open();
            //OleDbDataAdapter ada = new OleDbDataAdapter("SELECT ID, login, pasword FROM users ", myConnection);
            //DataTable dt = new DataTable();
            //ada.Fill(dt);

            

            xlWorksheet.Cells[1, 1] = "ID";
            xlWorksheet.Cells[1, 2] = "Login";
            xlWorksheet.Cells[1, 3] = "Pasword";


            string query = "SELECT ID, login, pasword FROM users ORDER BY ID";
            OleDbCommand command = new OleDbCommand(query, myConnection);

            OleDbDataReader reader = command.ExecuteReader();

            

           //while (reader.Read())
           // {
              //  if (reader[2].ToString() != string.Empty)
              //  {
               //     xlWorksheet.Rows["ID"].Add(reader[0].ToString()); //"ИМЯ ФАМИЛИЯ: " + reader[0].ToString() + " , " + reader[1].ToString() + ". ОЦЕНКА:  " + reader[2].ToString() + " "
               // }

           // }
            xlWorkbook.SaveAs(@"C:\Файлы\323232\asd.xls", Excel.XlFileFormat.xlWorkbookNormal, misValue, misValue, misValue, misValue ,Excel.XlSaveAsAccessMode.xlExclusive, misValue, misValue, misValue, misValue, misValue);
            xlWorkbook.Close(true, misValue ,misValue);
            ExRep.Quit();

            Marshal.ReleaseComObject(xlWorksheet);
            Marshal.ReleaseComObject(xlWorkbook);
            Marshal.ReleaseComObject(ExRep);

            MessageBox.Show("Файл бы создан в C:/Файлы/323232/asd.xls");

            myConnection.Close();
        }

        private void reportViewer1_Load(object sender, EventArgs e)
        {

        }
    }
}
