using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using System.Text.RegularExpressions;

namespace WindowsFormsApplication7
{
    public partial class Form2 : Form
    {
        double a, b, c;
        string[] mas1, mas2;
        
        public Form2(double a1, double b1, double c1, string[] mas11, string[] mas21)
        {
            InitializeComponent();
            a = a1;
            b = b1;
            c = c1;
            mas1 = mas11;
            mas2 = mas21;

        }
        

        private void button2_Click(object sender, EventArgs e)
        {
            
            FolderBrowserDialog FBD = new FolderBrowserDialog();
            if (FBD.ShowDialog() ==  DialogResult.OK)
            {
                textBox1.Text = FBD.SelectedPath;
            }

        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void checkBox6_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox6.Checked == true)
            {
                checkBox1.Checked = true;
                checkBox2.Checked = true;
                checkBox3.Checked = true;
                checkBox4.Checked = true;
                checkBox5.Checked = true;
            }
            
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox1.Checked == false)
            {
                checkBox6.Checked = false;
            }
        }

        private void checkBox2_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox2.Checked == false)
            {
                checkBox6.Checked = false;
            }
        }

        private void checkBox3_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox3.Checked == false)
            {
                checkBox6.Checked = false;
            }
        }

        private void checkBox4_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox4.Checked == false)
            {
                checkBox6.Checked = false;
            }
        }

        private void checkBox5_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox5.Checked == false)
            {
                checkBox6.Checked = false;
            }
        }

        private void textBox2_Click(object sender, EventArgs e)
        {
            if(textBox2.Text == "Ввeдите имя фaйла")
            {
                textBox2.Text = "";
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            this.Close(); ;
        }

        private void Form2_Load(object sender, EventArgs e)
        {
            textBox2.Text = "Input file name";
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string pattern = @"[\?!/<>|:]";
            Regex rg = new Regex(pattern);

            if ((checkBox1.Checked || checkBox2.Checked || checkBox3.Checked || checkBox4.Checked || checkBox5.Checked) == false)
            {
                MessageBox.Show("Report data not chosen");
            }
            else
            {
                if (textBox1.Text == "")
                {
                    MessageBox.Show("Choose file path");
                }
                else
                {
                    if (textBox2.Text == "Input file name")
                    { MessageBox.Show("Input file name"); }

                    else
                    {
                        if (rg.IsMatch(textBox2.Text) == true)
                        { MessageBox.Show("Invalid file name format"); }
                        else
                        {
                            string path = textBox1.Text + "/" + textBox2.Text + ".txt";
                            using (StreamWriter sw = new StreamWriter(path, false, Encoding.Default))
                            {
                                if (checkBox1.Checked)
                                {
                                    sw.WriteLine();
                                    sw.WriteLine("            Course work report for Programming II");
                                }
                                if (checkBox2.Checked)
                                {
                                    sw.WriteLine();
                                    sw.WriteLine("    Author: Ramis R. Sultanov\n           Group C20-361-1");
                                }

                                if (checkBox3.Checked)
                                {
                                    sw.WriteLine();
                                    sw.WriteLine();
                                    sw.WriteLine("  Table of graph coordinates:");
                                    sw.WriteLine();
                                    sw.WriteLine("   #          X                    Y");
                                    sw.WriteLine();
                                    for (int i = 0; i < mas1.Length; i++)
                                    {

                                        sw.WriteLine("  {0,4}  .... {1, 5}   .... | .... {2, 8}  |", (i+1), mas1[i], mas2[i]);

                                    }
                                    sw.WriteLine();
                                }
                                string date = DateTime.Now.ToShortDateString();
                                if (checkBox4.Checked)
                                {
                                    sw.WriteLine();
                                    sw.WriteLine("    Date: " + date);
                                }
                                string time = DateTime.Now.ToShortTimeString();
                                if (checkBox5.Checked)
                                {
                                    sw.WriteLine();
                                    sw.WriteLine("    Time: " + time);
                                }

                                if (MessageBox.Show("Report created in the chosen folder.\n   Close this window?", "", MessageBoxButtons.OKCancel) == DialogResult.OK)
                                {
                                    this.Close();
                                }
                                
                            }
                        }
                    }
                }
            }
        }     
    }
}
