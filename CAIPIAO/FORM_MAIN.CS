using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace CaiPiao
{
    public partial class Form_main : Form
    {

        private bool bool_begin_move = false;
        private int num_mouseDown_X = 0;
        private int num_mouseDown_Y = 0;


        public Form_main()
        {
            InitializeComponent();
            sideBarPanelItem1.Focus();
            //
            //显示总表
            //
            Form_allData fad = new Form_allData();
            fad.MdiParent = this;
            fad.Show();


        }
        //
        //最小,隐藏,关闭按钮设置
        //
        private void buttonItem1_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        private void buttonItem2_Click(object sender, EventArgs e)
        {
            this.Visible = false;
            this.notifyIcon1.Visible = true;
        }

        private void buttonItem3_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
        //
        //窗体拖动
        //
        private void labelX1_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                bool_begin_move = true;
                num_mouseDown_X = e.X;
                num_mouseDown_Y = e.Y;
            }
        }

        private void labelX1_MouseMove(object sender, MouseEventArgs e)
        {
            if (bool_begin_move)
            {
                Point temp = new Point(0, 0);

                temp.X = this.Location.X + (e.X - num_mouseDown_X);
                temp.Y = this.Location.Y + (e.Y - num_mouseDown_Y);
                this.Location = temp;
            }
        }

        private void labelX1_MouseUp(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
                bool_begin_move = false;
        }
        //siderBar点击PANEL按钮
        private void sideBarPanelItem1_Click(object sender, EventArgs e)
        {
            labelX1.Text = "双色球彩票信息统计分析管理系统:数据分析";
        }

        private void sideBarPanelItem2_Click(object sender, EventArgs e)
        {
            labelX1.Text = "双色球彩票信息统计分析管理系统:数据管理";
        }

        private void sideBarPanelItem3_Click(object sender, EventArgs e)
        {
            labelX1.Text = "双色球彩票信息统计分析管理系统:数据预测";
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            labelX2.Text = DateTime.Now.ToString();
        }
        //
        //各期总表
        //
        private void buttonItem4_Click(object sender, EventArgs e)
        {
            int i;
            for (i = 0; i < this.MdiChildren.Length; i++)
            {
                if (this.MdiChildren[i].Name == "Form_allData")
                    break;
            }
            if (i == this.MdiChildren.Length)
            {
                Form_allData fad = new Form_allData();
                fad.MdiParent = this;
                fad.Show();
            }
            else
            {
                this.MdiChildren[i].BringToFront();
            }
        }
        //
        //添加数据
        //
        private void buttonItem5_Click(object sender, EventArgs e)
        {
            int i;
            for (i = 0; i < this.MdiChildren.Length; i++)
            {
                if (this.MdiChildren[i].Name == "Form_addData")
                    break;
            }
            if (i == this.MdiChildren.Length)
            {
                Form_addData fad = new Form_addData();
                fad.MdiParent = this;
                fad.Show();
            }
            else
            {
                this.MdiChildren[i].BringToFront();
            }
        }
        //
        //号码统计
        //
        private void buttonItem6_Click(object sender, EventArgs e)
        {
            int i;
            for (i = 0; i < this.MdiChildren.Length; i++)
            {
                if (this.MdiChildren[i].Name == "Form_numUsed")
                    break;
            }
            if (i == this.MdiChildren.Length)
            {
                Form_numUsed fnu = new Form_numUsed();
                fnu.MdiParent = this;
                fnu.Show();
            }
            else
            {
                this.MdiChildren[i].BringToFront();
            }
        }
        //
        //号码查找
        //
        private void buttonItem7_Click(object sender, EventArgs e)
        {
            int i;
            for (i = 0; i < this.MdiChildren.Length; i++)
            {
                if (this.MdiChildren[i].Name == "Form_findNum")
                    break;
            }
            if (i == this.MdiChildren.Length)
            {
                Form_findNum ffn = new Form_findNum();
                ffn.MdiParent = this;
                ffn.Show();
            }
            else
            {
                this.MdiChildren[i].BringToFront();
            }
        }
        //
        //概率预测
        //
        private void buttonItem8_Click(object sender, EventArgs e)
        {

            int i;
            for (i = 0; i < this.MdiChildren.Length; i++)
            {
                if (this.MdiChildren[i].Name == "Form_forcast")
                    break;
            }
            if (i == this.MdiChildren.Length)
            {
                Form_forcast fft = new Form_forcast();
                fft.MdiParent = this;
                fft.Show();
            }
            else
            {
                this.MdiChildren[i].BringToFront();
            }
        }
        //
        //图标
        //
        private void notifyIcon1_MouseClick(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                this.Visible = true;
                this.notifyIcon1.Visible = false;
            }
        }
    }
}