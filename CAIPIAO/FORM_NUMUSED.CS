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
    public partial class Form_numUsed : Form
    {
        string[] str_allData;
        int[] num_redNums=new int[33];
        int[] num_blueNums=new int[16];


        public Form_numUsed()
        {
            InitializeComponent();
        }

        private void Form_numUsed_Activated(object sender, EventArgs e)
        {
            listBox1.Items.Clear();
            listBox2.Items.Clear();

            for (int i = 0; i < 33; i++)
            {
                num_redNums[i] = 0;
                if (i < 16)
                    num_blueNums[i] = 0;
            }
            str_allData = File.ReadAllLines("data.CPD");

            for (int i = 0; i < str_allData.Length; i++)
            {
                for (int j = 0; j < 33; j++)
                {
                    int temp = j + 1;
                    if (str_allData[i].Contains("-" + temp.ToString() + "-"))
                        num_redNums[j]++;
                    if (j > 0 && j < 17)
                    {
                        if (str_allData[i].Contains("[" + j.ToString() + "]"))
                            num_blueNums[j - 1]++;
                    }
                }
            }

            for (int i = 1; i < 34; i++)
            {
                listBox1.Items.Add(i.ToString()+"号出现次数:"+num_redNums[i-1].ToString());
                if (i < 17)
                {
                   // int temp = i + 1;
                    listBox2.Items.Add(i.ToString() + "号出现次数:" + num_blueNums[i-1].ToString());
                }
                    
            }


        }
    }
}