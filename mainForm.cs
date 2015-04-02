using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Threading;


namespace JEON_CManager
{
    public partial class mainForm : Form
    {
        static public class TopMostMessageBox
        {
            static public DialogResult Show(string message)
            {
                return Show(message, string.Empty, MessageBoxButtons.OK);
            }

            static public DialogResult Show(string message, string title)
            {
                return Show(message, title, MessageBoxButtons.OK);
            }

            static public DialogResult Show(string message, string title,
                MessageBoxButtons buttons)
            {

                // Create a host form that is a TopMost window which will be the 
                // parent of the MessageBox.
                Form topmostForm = new Form();


                topmostForm.ShowIcon = false;
                topmostForm.ShowInTaskbar = false;
                // We do not want anyone to see this window so position it off the 
                // visible screen and make it as small as possible
                topmostForm.Size = new System.Drawing.Size(1, 1);
                topmostForm.StartPosition = FormStartPosition.Manual;
                System.Drawing.Rectangle rect = SystemInformation.VirtualScreen;
                topmostForm.Location = new System.Drawing.Point(rect.Bottom + 10,
                    rect.Right + 10);
                topmostForm.Show();
                // Make this form the active form and make it TopMost
                topmostForm.Focus();
                topmostForm.BringToFront();
                topmostForm.TopMost = true;
                // Finally show the MessageBox with the form just created as its owner
                DialogResult result = MessageBox.Show(topmostForm, message, title,
                    buttons);
                topmostForm.Dispose(); // clean it up all the way

                return result;
            }
        }

        TimerForm s_form = new TimerForm();
        GlobalHooking LockKey = new GlobalHooking();
        string URLHOME = @"http://google.co.kr";
        string DBURL = @"https://raw.githubusercontent.com/papa7545/JEON_COMMANAGER/master/stdnum.jdb";
        string CLASSNUM;
        string NAME;
        string STDNUM;
        string name_Class = "2학년";

        public mainForm()
        {
            this.TopMost = true;
            InitializeComponent();
            this.FormBorderStyle = FormBorderStyle.None;
            this.Size = new Size(Screen.PrimaryScreen.Bounds.Width, Screen.PrimaryScreen.Bounds.Height);
            webBrowser1.Navigate(URLHOME);
            GlobalHooking LockKey = new GlobalHooking();
            LockKey.LockKeyboard();
            
        }


        private void mainForm_Load(object sender, EventArgs e)
        {
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
            Thread t1 = new Thread(new ThreadStart(checkDB));

            if (textBox2.Text.Length != 10)
            {
                TopMostMessageBox.Show("학번을 제대로 입력해주세요","학번 오류");
                return;
            }
            t1.Start();
        }
        private void checkDB()
        {

            string tempFile = System.IO.Path.GetTempFileName();
            System.Net.WebClient loader = new System.Net.WebClient();
            loader.DownloadFile(DBURL, tempFile);

            string[] lines = System.IO.File.ReadAllLines(tempFile, Encoding.GetEncoding("ks_c_5601-1987"));

            foreach (string line in lines)
            {
                if (line.Split('|')[1] == "CLASS")
                    name_Class = line.Split('|')[2];

                if (line.Split('|')[2] == textBox2.Text)
                {
                    CLASSNUM = line.Split('|')[0];
                    NAME = line.Split('|')[1];
                    STDNUM = line.Split('|')[2];

                    var r = TopMostMessageBox.Show("학년/반 - " + name_Class + " " + CLASSNUM + "번"
                    + Environment.NewLine + "이름 - " + NAME
                               + Environment.NewLine + "학번 - " + STDNUM
                                 + Environment.NewLine + "위 정보가 본인이 맞으며 사용하는데 동의 하십니까?", "로그인", MessageBoxButtons.YesNo);



                    if (r == DialogResult.Yes)
                    {
                        this.SetHide();
                    }
                    else if (r == DialogResult.No)
                        this.SetText("");

                    return;
                }
                if (line.Split('|')[0] == "endline")
                {
                    MessageBox.Show("학번이 잘못 되었거나 서버상에 정보가 존재하지 않습니다. \n담당자에게 연락해주세요.", "학번 오류");
                }
            }
        }

        delegate void SetTextCallback(string text);
        private void SetText(string text)
        {
            // InvokeRequired required compares the thread ID of the
            // calling thread to the thread ID of the creating thread.
            // If these threads are different, it returns true.
            if (this.textBox2.InvokeRequired)
            {
                SetTextCallback d = new SetTextCallback(SetText);
                this.Invoke(d, new object[] { text });
            }
            else
            {
                this.textBox2.Text = text;
            }
        }
        delegate void SetHideCallback();
        private void SetHide()
        {
            // InvokeRequired required compares the thread ID of the
            // calling thread to the thread ID of the creating thread.
            // If these threads are different, it returns true.
            if (this.textBox2.InvokeRequired)
            {
                SetHideCallback d = new SetHideCallback(SetHide);
                this.Invoke(d, new object[] { });
            }
            else
            {
                s_form.Show();
                s_form.Location = new Point(Convert.ToInt32(Screen.PrimaryScreen.Bounds.Width * 0.82f), Convert.ToInt32(Screen.PrimaryScreen.Bounds.Height * 0.01f));
                s_form.text_stdNum.Text = STDNUM;
                s_form.text_name.Text = NAME;
                s_form.classnum.Text = name_Class + " " + CLASSNUM;
                LockKey.UnlockKeyboard();
                this.Hide();
            }
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
