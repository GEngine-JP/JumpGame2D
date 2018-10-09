using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.IO;

namespace CaiPiao
{
    public partial class Form_findNum : Form
    {
        public Form_findNum()
        {
            InitializeComponent();
        }

        private void btn_findNum_Click(object sender, EventArgs e)
        {
            if (textBox1.Text != "" && textBox2.Text != "" && textBox3.Text != "" && textBox4.Text != "" && textBox5.Text != "" && textBox6.Text != "" && textBox7.Text != "")
            {
                
                try
                {

                    int temp1 = Convert.ToInt32(textBox1.Text);
                    int temp2 = Convert.ToInt32(textBox2.Text);
                    int temp3 = Convert.ToInt32(textBox3.Text);
                    int temp4 = Convert.ToInt32(textBox4.Text);
                    int temp5 = Convert.ToInt32(textBox5.Text);
                    int temp6 = Convert.ToInt32(textBox6.Text);
                    int temp7 = Convert.ToInt32(textBox7.Text);
                    if (temp1 > 0 && temp1 < 34 && temp2 >= 0 && temp2 < 34 && temp3 >= 0 && temp3 < 34 && temp4 >= 0 && temp4 < 34 && temp5 >= 0 && temp5 < 34 && temp6 >= 0 && temp6 < 34 && temp7 >= 1 && temp7 < 17)
                    {
                        int flag = 0;
                        listBox1.Items.Clear();

                        string[] str_allData = File.ReadAllLines("data.CPD");

                        for (int i = 0; i < str_allData.Length; i++)
                        {
                            if (str_allData[i].Contains("-"+textBox1.Text+"-"))
                                flag++;
                            if (str_allData[i].Contains("-" + textBox2.Text + "-"))
                                flag++;
                            if (str_allData[i].Contains("-" + textBox3.Text + "-"))
                                flag++;
                            if (str_allData[i].Contains("-" + textBox4.Text + "-"))
                                flag++;
                            if (str_allData[i].Contains("-" + textBox5.Text + "-"))
                                flag++;
                            if (str_allData[i].Contains("-" + textBox6.Text + "-"))
                                flag++;
                            if (str_allData[i].Contains("["+textBox7.Text+"]"))
                                flag++;

                            if (flag > 3)
                            {
                                string str_temp1 = str_allData[i].Replace("-", "   ");
                                string str_temp2 = str_temp1.Replace("[", "     ");
                                string str_temp3 = str_temp2.Replace("]", "");
                                listBox1.Items.Add(str_temp3);

                            }
                            flag = 0;
                        }

                    }
                    else
                        MessageBox.Show("请正确输入号码!\r\n红球号码:0~33\r\n兰球号码:1~16");
                }
                catch(Exception ex)
                { MessageBox.Show(ex.Message); }
            }
            else
                MessageBox.Show("请完整输入!");
        }
    }
}