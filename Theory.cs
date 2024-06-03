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

namespace EBook
{
    public partial class Theory : Form
    {
        public Theory()
        {
            InitializeComponent();
            this.CenterToScreen();
            MaximizeBox = false;
        }

        private void Theory_Load(object sender, EventArgs e)
        {

        }

        private void Theory_FormClosed(object sender, FormClosedEventArgs e)
        {
            this.Dispose();
            
        }

        private void button2_Click(object sender, EventArgs e)
        {
            TextBook_inside f1 = new TextBook_inside();

            f1.ShowDialog();

            this.Dispose();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Process.Start(@"WordBook_Inside.docx");
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Process.Start(@"https://c-kd.ru/eskd");
        }
    }
}
