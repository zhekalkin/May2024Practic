using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace EBook
{
    public partial class TextBook_inside : Form
    {
        public string WayToTheoryDir = @"Теория";

        public TextBook_inside()
        {
            InitializeComponent();

            this.CenterToScreen();

            LoadDirectory(WayToTheoryDir);
        }

        #region фильтрация_treeview
        private void LoadDirectory(string Dir)
        {
            DirectoryInfo di = new DirectoryInfo(Dir);

            TreeNode tds = treeView1.Nodes.Add(di.Name);

            tds.Tag = di.FullName;

            tds.StateImageIndex = 0;

            LoadFiles(Dir, tds);

            LoadSubDirectories(Dir, tds);
        }

        private void LoadSubDirectories(string dir, TreeNode td)
        {
            string[] subdirectoryEntries = Directory.GetDirectories(dir);

            foreach (string subdirectory in subdirectoryEntries)
            {
                DirectoryInfo di = new DirectoryInfo(subdirectory);

                TreeNode tds = td.Nodes.Add(di.Name);

                tds.StateImageIndex = 0;

                tds.Tag = di.FullName;

                LoadFiles(subdirectory, tds);

                LoadSubDirectories(subdirectory, tds);
            }
        }

        private void LoadFiles(string dir, TreeNode td)
        {
            string[] files = Directory.GetFiles(dir, "*.*");

            foreach (string file in files)
            {
                FileInfo fi = new FileInfo(file);

                TreeNode tds = td.Nodes.Add(fi.Name);

                tds.Tag = fi.FullName;

                tds.StateImageIndex = 1;
            }
        }
        #endregion

        #region открыть_и_прочитать_в_textbox
        private void treeView1_DoubleClick(object sender, EventArgs e)
        {
            textBox1.Clear();

            if (Path.GetExtension(treeView1.SelectedNode.FullPath) == ".txt")
            {
                string[] data = File.ReadAllLines(treeView1.SelectedNode.FullPath, Encoding.UTF8);

                for (int i = 0; i < data.Length; i++)
                {
                    textBox1.Text += data[i] + Environment.NewLine; // data[i];
                }
            }
        }
        #endregion


        private void TextBook_inside_Load(object sender, EventArgs e)
        {

        }

        private void TextBook_inside_FormClosed(object sender, FormClosedEventArgs e)
        {
            this.Dispose();
            
        }

        private void splitter1_SplitterMoved(object sender, SplitterEventArgs e)
        {

        }

        private void splitContainer1_Panel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void treeView1_AfterSelect(object sender, TreeViewEventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            panel1.Visible = true;
            button2.Visible = false;
            button1.Visible = true;
            label1.Visible = true;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            panel1.Visible = false;
            button2.Visible = true;
            button1.Visible = false;
            label1.Visible = false;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            pictureBox1.Image = imageList1.Images["1.jpg"];
            label1.Text = "Рисунок 1";

        }

        private void button23_Click(object sender, EventArgs e)
        {
            pictureBox1.Image = imageList1.Images["2.jpg"];
            label1.Text = "Рисунок 2";
        }

        private void button4_Click(object sender, EventArgs e)
        {
            pictureBox1.Image = imageList1.Images["21.jpg"];
            label1.Text = "Рисунок 21";
        }

        private void button18_Click(object sender, EventArgs e)
        {
            pictureBox1.Image = imageList1.Images["22.jpg"];
            label1.Text = "Рисунок 22";
        }

        private void button22_Click(object sender, EventArgs e)
        {
            
        }

        private void button21_Click(object sender, EventArgs e)
        {
            pictureBox1.Image = imageList1.Images["4.jpg"];
            label1.Text = "Рисунок 4";
        }

        private void button20_Click(object sender, EventArgs e)
        {
            pictureBox1.Image = imageList1.Images["5.1.jpg"];
            label1.Text = "Рисунок 5.1";
        }

        private void button9_Click(object sender, EventArgs e)
        {
            pictureBox1.Image = imageList1.Images["10.jpg"];
            label1.Text = "Рисунок 10";
        }

        private void button13_Click(object sender, EventArgs e)
        {
            pictureBox1.Image = imageList1.Images["11a.jpg"];
            label1.Text = "Рисунок 11a";
        }

        private void button8_Click(object sender, EventArgs e)
        {
            pictureBox1.Image = imageList1.Images["9.jpg"];
            label1.Text = "Рисунок 9";
        }

        private void button7_Click(object sender, EventArgs e)
        {
            pictureBox1.Image = imageList1.Images["8.jpg"];
            label1.Text = "Рисунок 8";
        }

        private void button6_Click(object sender, EventArgs e)
        {
            pictureBox1.Image = imageList1.Images["7.jpg"];
            label1.Text = "Рисунок 7";
        }

        private void button5_Click(object sender, EventArgs e)
        {
            pictureBox1.Image = imageList1.Images["6.jpg"];
            label1.Text = "Рисунок 6";
        }

        private void button11_Click(object sender, EventArgs e)
        {
            pictureBox1.Image = imageList1.Images["5.2.jpg"];
            label1.Text = "Рисунок 5.2";
        }

        private void button22_Click_1(object sender, EventArgs e)
        {
            pictureBox1.Image = imageList1.Images["3.1.jpg"];
            label1.Text = "Рисунок 3.1";
        }

        private void button27_Click(object sender, EventArgs e)
        {
            pictureBox1.Image = imageList1.Images["3.2.jpg"];
            label1.Text = "Рисунок 3.2";
        }

        private void button14_Click(object sender, EventArgs e)
        {
            pictureBox1.Image = imageList1.Images["11b.jpg"];
            label1.Text = "Рисунок 11б";
        }

        private void button12_Click(object sender, EventArgs e)
        {
            pictureBox1.Image = imageList1.Images["12.jpg"];
            label1.Text = "Рисунок 12";
        }

        private void button10_Click(object sender, EventArgs e)
        {
            pictureBox1.Image = imageList1.Images["13.jpg"];
            label1.Text = "Рисунок 13";
        }

        private void button26_Click(object sender, EventArgs e)
        {
            pictureBox1.Image = imageList1.Images["14.jpg"];
            label1.Text = "Рисунок 14";
        }

        private void button25_Click(object sender, EventArgs e)
        {
            pictureBox1.Image = imageList1.Images["15.jpg"];
            label1.Text = "Рисунок 15";
        }

        private void button24_Click(object sender, EventArgs e)
        {
            pictureBox1.Image = imageList1.Images["16, 17.jpg"];
            label1.Text = "Рисунок 16, 17";
        }

        private void button17_Click(object sender, EventArgs e)
        {
            pictureBox1.Image = imageList1.Images["18.jpg"];
            label1.Text = "Рисунок 18";
        }

        private void button16_Click(object sender, EventArgs e)
        {
            pictureBox1.Image = imageList1.Images["19.jpg"];
            label1.Text = "Рисунок 19";
        }

        private void button15_Click(object sender, EventArgs e)
        {
            pictureBox1.Image = imageList1.Images["20.jpg"];
            label1.Text = "Рисунок 20";
        }

        private void button19_Click(object sender, EventArgs e)
        {
            pictureBox1.Image = imageList1.Images["23.jpg"];
            label1.Text = "Рисунок 23";
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }
    }
}
