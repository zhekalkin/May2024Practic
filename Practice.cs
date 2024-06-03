using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace EBook
{
    public partial class Practice : Form
    {
        public Practice()
        {
            InitializeComponent();
            this.CenterToScreen();

        }

        private void Practice_Load(object sender, EventArgs e)
        {

        }

        private void Practice_FormClosed(object sender, FormClosedEventArgs e)
        {
            this.Dispose();
            Main f1 = new Main();
            f1.Show();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Dispose();
            menuVebora f2 = new menuVebora();
            f2.Show();
        }
    }
}
