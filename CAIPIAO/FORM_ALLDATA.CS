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
    public partial class Form_allData : Form
    {
        string[] str_data;
        public Form_allData()
        {
            InitializeComponent();
        }

        private void Form_allData_Activated(object sender, EventArgs e)
        {
          
            str_data = File.ReadAllLines("data.CPD");

            if (str_data.Length > dataGridView1.Rows.Count)
            {
                dataGridView1.Rows.Clear();
                for (int i = 0; i < str_data.Length; i++)
                {
                    //
                    //期数
                    //
                    dataGridView1.Rows.Add();
                    int x1 = str_data[i].IndexOf("=");
                    int x2 = str_data[i].LastIndexOf("=");
                    string num_temp = str_data[i].Substring(x1 + 1, x2 - x1 - 1);
                    int num_qi = Convert.ToInt32(num_temp);
                    dataGridView1.Rows[dataGridView1.Rows.Count - 1].Cells[0].Value = num_qi;

                    //
                    //兰球
                    //
                    int x3 = str_data[i].IndexOf("[");
                    int x4 = str_data[i].IndexOf("]");
                    string num_temp2 = str_data[i].Substring(x3 + 1, x4 - x3 - 1);
                    int num_blueBall = Convert.ToInt32(num_temp2);
                    dataGridView1.Rows[dataGridView1.Rows.Count - 1].Cells[34].Value = num_blueBall;

                    //
                    //红球
                    //
                    for (int j = 1; j < 35; j++)
                    {
                        if (str_data[i].Contains("-" + dataGridView1.Columns[j].HeaderText + "-"))
                            dataGridView1.Rows[dataGridView1.Rows.Count - 1].Cells[j].Value = "√";
                    }

                }


                dataGridView1.Sort(dataGridView1.Columns[0], ListSortDirection.Ascending);

            }
        }
    }
}