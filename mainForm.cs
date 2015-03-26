﻿using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data.MySqlClient;
using MySql.Data.Types;

namespace JEON_CManager
{
    public partial class mainForm : Form
    {

        TimerForm s_form = new TimerForm();
        GlobalHooking LockKey = new GlobalHooking();
        string URLHOME = @"http://google.co.kr";

        public mainForm()
        {
            InitializeComponent();
            this.FormBorderStyle = FormBorderStyle.None;
            this.Size = new Size(Screen.PrimaryScreen.Bounds.Width, Screen.PrimaryScreen.Bounds.Height);
            webBrowser1.Navigate(URLHOME);
            GlobalHooking LockKey = new GlobalHooking();
            LockKey.LockKeyboard();
            

        }


        private void mainForm_Load(object sender, EventArgs e)
        {
            this.TopMost = true;
            textBox2.Location = new Point(Convert.ToInt32(Screen.PrimaryScreen.Bounds.Width * textBox2.Location.X / 1000f), Convert.ToInt32(Screen.PrimaryScreen.Bounds.Height * textBox2.Location.Y / 1000f));
            textBox2.Size = new Size(Convert.ToInt32(Screen.PrimaryScreen.Bounds.Width * textBox2.Size.Width / 1000f), Convert.ToInt32(Screen.PrimaryScreen.Bounds.Height * textBox2.Size.Height / 1000f));

            button1.Location = new Point(Convert.ToInt32(Screen.PrimaryScreen.Bounds.Width * button1.Location.X / 1000f), Convert.ToInt32(Screen.PrimaryScreen.Bounds.Height * button1.Location.Y / 1000f));
            button1.Size = new Size(Convert.ToInt32(Screen.PrimaryScreen.Bounds.Width * button1.Size.Width / 1000f), Convert.ToInt32(Screen.PrimaryScreen.Bounds.Height * button1.Size.Height / 1000f));

            label1.Location = new Point(Convert.ToInt32(Screen.PrimaryScreen.Bounds.Width * label1.Location.X / 1000f), Convert.ToInt32(Screen.PrimaryScreen.Bounds.Height * label1.Location.Y / 1000f));
            label1.Size = new Size(Convert.ToInt32(Screen.PrimaryScreen.Bounds.Width * label1.Size.Width / 1000f), Convert.ToInt32(Screen.PrimaryScreen.Bounds.Height * label1.Size.Height / 1000f));

            webBrowser1.Location = new Point(Convert.ToInt32(Screen.PrimaryScreen.Bounds.Width * webBrowser1.Location.X / 1000f), Convert.ToInt32(Screen.PrimaryScreen.Bounds.Height * webBrowser1.Location.Y / 1000f));
            webBrowser1.Size = new Size(Convert.ToInt32(Screen.PrimaryScreen.Bounds.Width * webBrowser1.Size.Width / 1000f), Convert.ToInt32(Screen.PrimaryScreen.Bounds.Height * webBrowser1.Size.Height / 1000f));

            toolStrip1.Location = new Point(Convert.ToInt32(Screen.PrimaryScreen.Bounds.Width * toolStrip1.Location.X / 1000f), Convert.ToInt32(Screen.PrimaryScreen.Bounds.Height * toolStrip1.Location.Y / 1000f));
            toolStrip1.Size = new Size(Convert.ToInt32(Screen.PrimaryScreen.Bounds.Width * toolStrip1.Size.Width / 1000f), Convert.ToInt32(Screen.PrimaryScreen.Bounds.Height * toolStrip1.Size.Height / 1000f));

            toolStripTextBox1.Size = new Size(Convert.ToInt32(Screen.PrimaryScreen.Bounds.Width * toolStripTextBox1.Size.Width / 1000f), toolStripTextBox1.Size.Height);

        }

        private void mainForm_KeyDown_1(object sender, KeyEventArgs e)
        {
            if (e.Alt && e.KeyCode == Keys.F4)
                e.Handled = true;
            if (e.KeyCode == Keys.Delete)
                Application.Exit(); 
                
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
        }

        private void mainForm_Deactivate(object sender, EventArgs e)
        {

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {

            if (textBox2.Text.Length != 10)
            {
                MessageBox.Show("학번을 제대로 입력해주세요","학번 오류");
                return;
            }
            
            string[] lines = System.IO.File.ReadAllLines(@"D:\JEON_COMMANAGER\tempdb.txt",Encoding.GetEncoding("ks_c_5601-1987"));

            foreach(string line in lines.Where(t => t.Split('|')[0] == textBox2.Text))
            {
                var r = MessageBox.Show("이름 - " + line.Split('|')[1] 
                               + Environment.NewLine + "학번 - " + line.Split('|')[0]
                                 + Environment.NewLine + "위 정보가 본인이 맞으며 사용하는데 동의 하십니까?","로그인",MessageBoxButtons.YesNo,MessageBoxIcon.Question);
                if (r == DialogResult.Yes)
                {
                    s_form.Show();
                    s_form.Location = new Point(Convert.ToInt32(Screen.PrimaryScreen.Bounds.Width * 0.82f), Convert.ToInt32(Screen.PrimaryScreen.Bounds.Height * 0.01f));
                    s_form.text_stdNum.Text = line.Split('|')[0];
                    s_form.text_name.Text = line.Split('|')[1];
                    LockKey.UnlockKeyboard();
                    this.Hide();
                }
                else if(r == DialogResult.No)
                    textBox2.Text = "";
                return;
            }
            MessageBox.Show("학번이 잘못 되었거나 서버상에 정보가 존재하지 않습니다. \n담당자에게 연락해주세요.","학번 오류");
        }

        private void webBrowser1_DocumentCompleted(object sender, WebBrowserDocumentCompletedEventArgs e)
        {
            toolStripTextBox1.Text = webBrowser1.Url.ToString();
        }

        private void toolStripTextBox1_Click(object sender, EventArgs e)
        {
            webBrowser1.GoBack();
        }

        private void toolStripButton4_Click(object sender, EventArgs e)
        {
            webBrowser1.Navigate(toolStripTextBox1.Text);
            toolStripTextBox1.Focus();
        }

        private void toolStripButton2_Click(object sender, EventArgs e)
        {
            webBrowser1.Navigate(URLHOME);
        }

        private void toolStripTextBox1_KeyDown(object sender, KeyEventArgs e)
        {
            if(e.KeyCode == Keys.Return)
                webBrowser1.Navigate(toolStripTextBox1.Text);
            toolStripTextBox1.Focus();
        }

    }
}
