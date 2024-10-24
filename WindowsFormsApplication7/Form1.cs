using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApplication7
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            
        }

        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void radioButton2_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void radioButton3_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void numericUpDown1_ValueChanged(object sender, EventArgs e)
        {

        }

        private void numericUpDown2_ValueChanged(object sender, EventArgs e)
        {

        }
        

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                dataGridView1.Rows.Clear();
                double a = Convert.ToDouble(numericUpDown1.Value);
                double b = Convert.ToDouble(numericUpDown2.Value);
                double c = Convert.ToDouble(numericUpDown3.Value);
                double y;
                double initial = a;

                if (radioButton1.Checked == true || radioButton2.Checked == true || radioButton3.Checked == true)
                {
                    if (b > a)
                    {
                        if (c > 0)
                        {
                            if (radioButton1.Checked)
                            {
                                double f = Math.Cos(a - (Math.PI / 4));
                                if (c < b - a)
                                {
                                    for (int i = 0; a <= b; i++)
                                    {
                                        y = Math.Cos(a - (Math.PI / 4));
                                        dataGridView1.Rows.Add(i + 1, Math.Round(a, 1), Math.Round(y, 2));
                                        
                                        a += c;
                                    }
                                }
                                else MessageBox.Show("Приращение должно быть меньше наблюдаемого промежутка");
                            }

                            if (radioButton2.Checked)
                            {
                                double f = (-1) * Math.Sin((a / 3) - Math.PI);
                                if (c < b - a)
                                {
                                    for (int i = 0; a <= b; i++)
                                    {
                                        y = Math.Sin((a / 3) - Math.PI);
                                        dataGridView1.Rows.Add(i + 1, Math.Round(a, 1), Math.Round(y, 2));
                                        
                                        a += c;
                                    }
                                }
                                else MessageBox.Show("Приращение должно быть меньше наблюдаемого промежутка");
                            }


                            if (radioButton3.Checked)
                            {
                                double f = Math.Pow(a, 3) - 5 * Math.Pow(a, 2);

                                if (c < b - a)
                                {
                                    for (int i = 0; a <= b; i++)
                                    {
                                        y = Math.Pow(a, 3) - 5 * Math.Pow(a, 2);
                                        dataGridView1.Rows.Add(i + 1, Math.Round(a, 1), Math.Round(y, 2));
                                        
                                        a += c;
                                    }
                                }
                                else MessageBox.Show("Приращение должно быть меньше наблюдаемого промежутка");
                            }
                        }
                        else
                        {
                            MessageBox.Show("Приращение не может меньше нуля");
                        }


                    }
                    else
                    {
                        MessageBox.Show("Неправильно введены границы графика");
                    }
                }
                else
                {
                    MessageBox.Show("Не выбрана функция");
                }

            }
            catch (FormatException)
            {
                MessageBox.Show("Неверный ввод");
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (dataGridView1.Rows.Count == 1)
            { MessageBox.Show("Нет данных для составления графика"); }
            
            chart1.Series[0].Points.Clear();
            for (int i = 0; i < dataGridView1.Rows.Count - 1; i++)
            {
                double x = Convert.ToDouble(dataGridView1.Rows[i].Cells[1].Value);
                double y = Convert.ToDouble(dataGridView1.Rows[i].Cells[2].Value);

                chart1.Series[0].Points.AddXY(x, y);
            }

        }

        private void groupBox3_Enter(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            dataGridView1.Rows.Clear();
            chart1.Series[0].Points.Clear();
            numericUpDown1.Value = 0;
            numericUpDown2.Value = 0;
            numericUpDown3.Value = 0;
            radioButton1.Checked = false;
            radioButton2.Checked = false;
            radioButton3.Checked = false;
            button8.BackColor = Color.White;
        }

        private void button4_Click(object sender, EventArgs e)
        {
            double a = Convert.ToDouble(numericUpDown1.Value);
            double b = Convert.ToDouble(numericUpDown2.Value);
            double c = Convert.ToDouble(numericUpDown3.Value);

            string[] mas1 = new string[dataGridView1.Rows.Count - 1];
            for (int i = 0; i < dataGridView1.Rows.Count - 1; i++)
            {
                mas1[i]=dataGridView1[1, i].Value.ToString();
            }

            string[] mas2 = new string[dataGridView1.Rows.Count - 1];
            for (int i = 0; i < dataGridView1.Rows.Count - 1; i++)
            {
                mas2[i] = dataGridView1[2, i].Value.ToString();
            }

            Form frm = new Form2(a, b, c, mas1, mas2);

            frm.Show();
            
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void numericUpDown3_ValueChanged(object sender, EventArgs e)
        {

        }

        private void button5_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void работаToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form frm = new Form3();

            frm.Show();
        }

        private void справкаToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form frm = new Form4();

            frm.Show();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            dataGridView1.Rows.Clear();
        }

        private void button7_Click(object sender, EventArgs e)
        {
            chart1.Series[0].Points.Clear();
        }

        private void button8_Click(object sender, EventArgs e)
        {
            ColorDialog colorDialog1 = new ColorDialog();
            if (colorDialog1.ShowDialog() == DialogResult.Cancel)
                return;
            
            chart1.Series[0].Color = colorDialog1.Color;

            button8.BackColor = chart1.Series[0].Color;
        }

        private void menuStrip1_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {

        }
    }
}
