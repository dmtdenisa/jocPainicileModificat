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
    public partial class Form2 : Form
    { 
        public string textFromForm1;
        public static List<int> ListaNumereJucatorF3;
        public static List<int> ListaNumerePC;
        Random randomNumber = new Random();
        int indiceAles = 0;
        int numarGeneratUSER, numarGeneratPC, numarGhicitUser, numarGhicitPC;
        int count = 0;
        int painicaUSER = 0;
        int painicaPC = 0;
        int runda = 1;
        Form4 f4 = new Form4();

        private void ScriereIstoricFisier(int numar)
        {
            if (!File.Exists("istoricJoc.txt"))
            {
                File.Create("istoricJoc.txt").Close();
                using (StreamWriter sw = File.AppendText("istoricJoc.txt"))
                {
                    
                    if (runda % 2 == 0)
                    {
                        sw.WriteLine($"Runda {runda}, randul USER-ului");
                        sw.WriteLine($"Painci: USER {painicaUSER} vs. PC {painicaPC}");
                        sw.WriteLine($"Numar generat de PC: {numar}");
                        sw.WriteLine($"USER a gresit de {count} ori.");
                        sw.WriteLine("");
                       
                    }else
                    {
                        sw.WriteLine($"Runda {runda}, randul PC-ului");
                        sw.WriteLine($"Painci: USER {painicaUSER} vs. PC {painicaPC}");
                        sw.WriteLine($"Numar generat de USER: {numar}");
                        sw.WriteLine($"PC a gresit de {count} ori.");
                        sw.WriteLine("");
                    }

                    if (painicaUSER == 10)
                    {
                        sw.WriteLine("PC a castigat jocul!");
                        sw.WriteLine("----------------------");
                    }
                    else if (painicaPC == 10)
                    {
                        sw.WriteLine("User a castigat jocul!");
                        sw.WriteLine("----------------------");
                    }

                }
            }
            else
            {
                //File.WriteAllText("istoricJoc.txt", String.Empty);
                using (StreamWriter sw = File.AppendText("istoricJoc.txt"))
                {
                    
                    if (runda % 2 == 0)
                    {
                        sw.WriteLine($"Runda {runda}, randul USER-ului");
                        sw.WriteLine($"Painci: USER {painicaUSER} vs. PC {painicaPC}");
                        sw.WriteLine($"Numar generat de PC: {numar}");
                        sw.WriteLine($"USER a gresit de {count} ori.");
                        sw.WriteLine("");

                    }
                    else
                    {
                        sw.WriteLine($"Runda {runda}, randul PC-ului");
                        sw.WriteLine($"Painci: USER {painicaUSER} vs. PC {painicaPC}");
                        sw.WriteLine($"Numar generat de USER: {numar}");
                        sw.WriteLine($"PC a gresit de {count} ori.");
                        sw.WriteLine("");
                    }

                    if (painicaUSER == 10)
                    {
                        sw.WriteLine("PC a castigat jocul!");
                        sw.WriteLine("----------------------");
                    }
                    else if (painicaPC == 10)
                    {
                        sw.WriteLine("User a castigat jocul!");
                        sw.WriteLine("----------------------");
                    }
                }
            }
        }
        private void AlegereIndice(List<int> lista)
        {
            indiceAles = randomNumber.Next(0, lista.Count-1);
        }
        private void ActualizareRunda()
        {
            pictureBox6.Visible = false;
            pictureBox5.Visible = false;
            pictureBox4.Visible = false;
            if (runda % 2 == 0)
            {
                label8.Text = $"Runda {runda}, randul user-ului";
                //controale user
                button2.Visible = false;
                label6.Visible = true;
                textBox3.Visible = true;
                button5.Visible = true;
                //controale PC
                button3.Visible = true;
                button4.Visible = false;
            }
            else
            {
                label8.Text = $"Runda {runda}, randul PC-ului";
                //controale user
                button2.Visible = true;
                label6.Visible = false;
                textBox3.Visible = false;
                button5.Visible = false;
                //controale PC
                button3.Visible = false;
                button4.Visible = true;
            }
                

        }

        public void EliminareNumarGhicit(List<int> lista, int nr)
        {
            lista.Remove(nr);
            textBox1.Text = String.Join(Environment.NewLine, ListaNumereJucatorF3);
            textBox2.Text = String.Join(Environment.NewLine, ListaNumerePC);
        }
        public int GhicirePC()
        {
            numarGhicitPC = randomNumber.Next(1, 20);
            label5.Text = numarGhicitPC.ToString();
            return numarGhicitPC;
        }

        

        private int GenerareNumar(List<int> lista)
        {
            int numarAles;
            AlegereIndice(lista);
            numarAles = lista[indiceAles];
            //lista.RemoveAt(indiceAles);
            return numarAles;
        }
        private int ComparareNumereRunda(List<int> listaCurenta, int numarGhicit, int numarGenerat, int painica)
        {
            if (numarGhicit == numarGenerat)
            {
                label7.Text = "Corect!";
                EliminareNumarGhicit(listaCurenta, numarGhicit);
                ScriereIstoricFisier(numarGhicit);
                runda++;
                count = 0;
                label4.Text = " ";
                label5.Text = " ";
                label7.Text = " ";
                MessageBox.Show("Randul urmatorului jucator!");
                ActualizareRunda();
            }
            else
            {
                label7.Text = "Gresit!";
                count++;
                switch (count)
                {
                    case 0:
                        pictureBox6.Visible = false;
                        break;
                    case 1:
                        pictureBox6.Visible = true;
                        break;
                    case 2:
                        pictureBox6.Visible = false;
                        pictureBox5.Visible = true;
                        break;
                    case 3:
                        pictureBox5.Visible = false;
                        pictureBox4.Visible = true;
                        break;
                    case 4:
                        pictureBox4.Visible = false;
                        pictureBox3.Visible = true;
                        painica++;
                        if (painica < 10)
                            MessageBox.Show("Randul urmatorului jucator!");
                        pictureBox3.Visible = false;
                        label4.Text = " ";
                        label5.Text = " ";
                        label7.Text = " ";
                        ScriereIstoricFisier(numarGenerat);
                        count = 0;
                        runda++;
                        ActualizareRunda();
                        break;
                }

            }
            return painica;
        }

        public void VerificarePainicaUSER(int painica)
        {
            switch (painica)
            {
                case 0:
                    break;
                case 1:
                    pictureBox7.Visible = true;
                    break;
                case 2:
                    pictureBox8.Visible = true;
                    break;
                case 3:
                    pictureBox9.Visible = true;
                    break;
                case 4:
                    pictureBox10.Visible = true;
                    break;
                case 5:
                    pictureBox11.Visible = true;
                    break;
                case 6:
                    pictureBox16.Visible = true;
                    break;
                case 7:
                    pictureBox15.Visible = true;
                    break;
                case 8:
                    pictureBox14.Visible = true;
                    break;
                case 9:
                    pictureBox13.Visible = true;
                    break;
                case 10:
                    pictureBox12.Visible = true;
                    ScriereIstoricFisier(numarGeneratPC);
                    MessageBox.Show("Jocul s-a terminat! Ai Pierdut!");
                    textBox1.Text = " ";
                    textBox2.Text = " ";
                    label4.Text = " ";
                    label5.Text = " ";
                    label7.Text = "Apasati pe butonul IESIRE sau RESTART";
                    break;
                
            }
        }

        public void VerificarePainicaPC(int painica)
        {
            switch (painica)
            {
                case 0:
                    break;
                case 1:
                    pictureBox26.Visible = true;
                    break;
                case 2:
                    pictureBox25.Visible = true;
                    break;
                case 3:
                    pictureBox24.Visible = true;
                    break;
                case 4:
                    pictureBox23.Visible = true;
                    break;
                case 5:
                    pictureBox22.Visible = true;
                    break;
                case 6:
                    pictureBox21.Visible = true;
                    break;
                case 7:
                    pictureBox20.Visible = true;
                    break;
                case 8:
                    pictureBox19.Visible = true;
                    break;
                case 9:
                    pictureBox18.Visible = true;
                    break;
                case 10:
                    pictureBox17.Visible = true;
                    ScriereIstoricFisier(numarGeneratUSER);
                    MessageBox.Show("Jocul s-a terminat! Ai Castigat!");
                    textBox1.Text = " ";
                    textBox2.Text = " ";
                    label4.Text = " ";
                    label5.Text = " ";
                    label7.Text = "Apasati pe butonul IESIRE sau RESTART";
                    break;
               
            }
        }
        public Form2()
        {
            InitializeComponent();
            textFromForm1 = Form1.TextboxText;
            label1.Text = textFromForm1;
            ListaNumereJucatorF3 = new List<int>(Form3.ListaNumereJucator); //deep copy ?
            ListaNumerePC = new List<int>() { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10 };
            
            
            
        }
       

        private void button1_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void Form2_Load(object sender, EventArgs e)
        {
            textBox1.Text = String.Join(Environment.NewLine, ListaNumereJucatorF3);
            textBox2.Text = String.Join(Environment.NewLine, ListaNumerePC);
            ActualizareRunda();

        }

        private void button5_Click(object sender, EventArgs e)
        {
            int a;
            if (int.TryParse(textBox3.Text, out a))
            {
                numarGhicitUser = a;
                label4.Text = numarGhicitUser.ToString();
            }else
                MessageBox.Show("Introduceti un numar intreg!");
            painicaUSER = ComparareNumereRunda(ListaNumerePC, numarGhicitUser, numarGeneratPC, painicaUSER);
            VerificarePainicaUSER(painicaUSER);
            //ScriereIstoricFisier(numarGeneratPC);


        }

        private void button6_Click(object sender, EventArgs e)
        {
            this.Hide();
            f4.ShowDialog();
        }

        private void button6_Click_1(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            numarGeneratUSER = GenerareNumar(ListaNumereJucatorF3);
            textBox1.Text = String.Join(Environment.NewLine, ListaNumereJucatorF3);
            label4.Text = numarGeneratUSER.ToString();
            
        }

        private void button3_Click(object sender, EventArgs e)
        {
            numarGeneratPC = GenerareNumar(ListaNumerePC);
            textBox2.Text = String.Join(Environment.NewLine, ListaNumerePC);
            label5.Text = numarGeneratPC.ToString();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            GhicirePC();
            painicaPC = ComparareNumereRunda(ListaNumereJucatorF3, numarGhicitPC, numarGeneratUSER, painicaPC);
            VerificarePainicaPC(painicaPC);
            //ScriereIstoricFisier(numarGeneratUSER);
        }
    }
}
