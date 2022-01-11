using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace DumitruMariaDenisa609ProiectSem1
{
    public partial class Form3 : Form
    {
        public static List<int> ListaNumereJucator;
        public Form3()
        {
            InitializeComponent();
            ListaNumereJucator = new List<int>();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            int i;
            int counter = 0;
            foreach(string str in textBox1.Text.Split(' '))
            {
                if (int.TryParse(str, out i))
                    ListaNumereJucator.Add(int.Parse(str));
                else
                {
                    MessageBox.Show("Nu ati introdus numere intregi!");
                }
            }

            if (ListaNumereJucator.Count == 10)
            {
                for (int x=0; x < ListaNumereJucator.Count; x++)
                {
                    if(ListaNumereJucator[x]<1 || ListaNumereJucator[x] > 20)
                    {
                        counter++;
                    }
                }
                if (counter < 0)
                {
                    MessageBox.Show("Unele numere sunt in afara intervalului!");
                    ListaNumereJucator.Clear();
                }
                else
                {
                    this.Hide();
                    Form2 frm2 = new Form2();
                    frm2.Show();
                }
                
            } else
            {
                ListaNumereJucator.Clear();
                MessageBox.Show("Nu ati introdus 10 numere!");
            }

            
        }
    }
}
