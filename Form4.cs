using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.IO;

namespace DumitruMariaDenisa609ProiectSem1
{
    public partial class Form4 : Form
    {
        public Form4()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string istoric = File.ReadAllText("istoricJoc.txt");
            textBox1.Text = istoric;
            //OpenFileDialog ofd = new OpenFileDialog();
            //if (ofd.ShowDialog() == DialogResult.OK)
            //{
            //    string istoric = File.ReadAllText(ofd.FileName);
            //    textBox1.Text = istoric;
            //}
            //else
            //{
            //    MessageBox.Show("Alegeti fisierul dorit!");
            //}
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Form2 frm2 = new Form2();
            this.Hide();
            frm2.ShowDialog();
        }
    }
}
