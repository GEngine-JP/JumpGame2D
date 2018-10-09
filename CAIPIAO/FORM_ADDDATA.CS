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
    public partial class Form_addData : Form
    {
        private int[] num_redBalls = new int[6];
        private int num_redBallFlag = 0;
        public Form_addData()
        {
            InitializeComponent();
        }

        private void btn_addRedBallNum_Click(object sender, EventArgs e)
        {
            int i;
            for (i = 0; i < num_redBallFlag; i++)
            {
                if (num_redBalls[i] == (int)numericUpDown_redBall.Value)
                    break;
            }
            if (i == num_redBallFlag)
            {

                if (num_redBallFlag == 6)
                { MessageBox.Show("已经输入6个号码球!"); }
                else
                {
                    labelX1.Text += numericUpDown_redBall.Value.ToString()+"    ";
                    num_redBalls[num_redBallFlag] = (int)numericUpDown_redBall.Value;
                    num_redBallFlag++;
                }
            }
            else
                MessageBox.Show("请不要输入相同号码球!");
            //labelX1.Text += numericUpDown_redBall.Value.ToString()+"    ";
        }

        private void btn_redBallNumClear_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < 6; i++)
            {
                num_redBalls[i] = -1;
            }
            labelX1.Text = "号码:";
            num_redBallFlag = 0;
        }

        private void btn_addDataOK_Click(object sender, EventArgs e)
        {
            string str_allData = File.ReadAllText("data.CPD");
            if(str_allData.Contains("="+numericUpDown_qi.Value.ToString()+"="))
            {
                MessageBox.Show("这期数据已经输入!");
            }
            else
            {
                if (num_redBallFlag == 6)
                {
                    string str_all = File.ReadAllText("data.CPD");
                    if (str_all != "")
                    {
                        File.AppendAllText("data.CPD", "\r\n=" + numericUpDown_qi.Value.ToString() + "=" + "-" + num_redBalls[0].ToString() + "-" + num_redBalls[1].ToString() + "-" + num_redBalls[2].ToString() + "-" + num_redBalls[3].ToString() + "-" + num_redBalls[4].ToString() + "-" + num_redBalls[5].ToString() + "-" + "[" + numericUpDown_blueBall.Value.ToString() + "]");
                    }
                    else
                    {
                        File.AppendAllText("data.CPD", "=" + numericUpDown_qi.Value.ToString() + "=" + "-" + num_redBalls[0].ToString() + "-" + num_redBalls[1].ToString() + "-" + num_redBalls[2].ToString() + "-" + num_redBalls[3].ToString() + "-" + num_redBalls[4].ToString() + "-" + num_redBalls[5].ToString() + "-" + "[" + numericUpDown_blueBall.Value.ToString() + "]");
                    }
                    for (int i = 0; i < 6; i++)
                    {
                        num_redBalls[i] = -1;
                    }
                    labelX1.Text = "号码:";
                    num_redBallFlag = 0;

                }
                else
                    MessageBox.Show("红色号码球数输入不完整!");
            }

        }
    }
}