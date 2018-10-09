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
    public partial class Form_forcast : Form
    {
        string[] str_allData;
        private int num_lastAppear;
        int[] num_redNums = new int[33];
        int[] num_blueNums = new int[16];

        public Form_forcast()
        {
            InitializeComponent();
        }

        private void Form_forcast_Activated(object sender, EventArgs e)
        {
            dataGridViewX1.Rows.Clear();
            dataGridViewX2.Rows.Clear();
            //
            //红球
            //
            str_allData = File.ReadAllLines("data.CPD");
            num_lastAppear = str_allData.Length;
            //连续未出现次数
            for (int i = 1; i < 34; i++)
            {
                dataGridViewX1.Rows.Add();
                dataGridViewX1.Rows[dataGridViewX1.Rows.Count - 1].Cells[1].Value = i;

                for (int j = 0; j < str_allData.Length; j++)
                {
                    if (str_allData[j].Contains("-" + i.ToString() + "-"))
                    {
                        num_lastAppear = str_allData.Length - j -1;
                    }
                }
                dataGridViewX1.Rows[dataGridViewX1.Rows.Count - 1].Cells[2].Value = num_lastAppear;
                num_lastAppear = str_allData.Length;
            }
            //共出现次数和排名
            for (int i = 0; i < 33; i++)
            {
                num_redNums[i] = 0;
                if (i < 16)
                  num_blueNums[i] = 0;
            }

            for (int i = 0; i < str_allData.Length; i++)
            {
                for (int j = 1; j < 34; j++)
                {
                    if (str_allData[i].Contains("-" + j.ToString() + "-"))
                        num_redNums[j-1]++;
                   
                }
            }
            

            for (int i = 0; i < 33; i++)
            {
                dataGridViewX1.Rows[i].Cells[3].Value = num_redNums[i];

            }
            dataGridViewX1.Sort(dataGridViewX1.Columns[2], ListSortDirection.Descending);

            for (int i = 0; i < 33; i++)
            {

                dataGridViewX1.Rows[i].Cells[0].Value = i + 1;
            }
            //
            //兰球
            //
            num_lastAppear = str_allData.Length;
            //连续未出现次数
            for (int i = 1; i < 17; i++)
            {
                dataGridViewX2.Rows.Add();
                dataGridViewX2.Rows[dataGridViewX2.Rows.Count - 1].Cells[1].Value = i;

                for (int j = 0; j < str_allData.Length; j++)
                {
                    if (str_allData[j].Contains("[" + i.ToString() + "]"))
                    {
                        num_lastAppear = str_allData.Length - j - 1;
                    }
                }
                dataGridViewX2.Rows[dataGridViewX2.Rows.Count - 1].Cells[2].Value = num_lastAppear;
                num_lastAppear = str_allData.Length;
            }
            //共出现次数和排名
           

            for (int i = 0; i < str_allData.Length; i++)
            {
                for (int j = 1; j < 17; j++)
                {
                    
                        if (str_allData[i].Contains("[" + j.ToString() + "]"))
                            num_blueNums[j - 1]++;
                    
                }
            }


            for (int i = 0; i < 16; i++)
            {
                dataGridViewX2.Rows[i].Cells[3].Value = num_blueNums[i];

            }
            dataGridViewX2.Sort(dataGridViewX2.Columns[2], ListSortDirection.Descending);

            for (int i = 0; i < 16; i++)
            {

                dataGridViewX2.Rows[i].Cells[0].Value = i + 1;
            }
        }
    }
}