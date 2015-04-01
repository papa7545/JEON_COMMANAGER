using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.IO;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace JEON_CManager
{
    public partial class TimerForm : Form
    {

        public static int h = 0;
        public static int m = 0;
        public static int s = 0;
        public static Uri uriAdd = new Uri(@"ftp://112.175.184.72/log.txt");

        public TimerForm()
        {
            InitializeComponent();
            this.ShowInTaskbar = false;
            this.Disposed += TimerForm_Disposed;
            
        }

        void TimerForm_Disposed(object sender, EventArgs e)
        {
            string fileName = "D:\\test.txt";

            FileStream fs = new FileStream(fileName, FileMode.Append, FileAccess.Write);
            StreamWriter sw = new StreamWriter(fs, Encoding.Default);
            sw.WriteLine("karuru.com");
            sw.Close();
            fs.Close();


            System.Net.FtpWebRequest ftpReq = (System.Net.FtpWebRequest)
                System.Net.WebRequest.Create(uriAdd);
            ftpReq.Credentials = new System.Net.NetworkCredential("papa7545", "fldzmdi1");
            ftpReq.Method = System.Net.WebRequestMethods.Ftp.UploadFile;
            ftpReq.KeepAlive = false;
            ftpReq.UseBinary = false;
            ftpReq.UsePassive = false;
            System.IO.Stream reqStrm = ftpReq.GetRequestStream();
            fs = new System.IO.FileStream(
                fileName, System.IO.FileMode.OpenOrCreate, System.IO.FileAccess.Read);

            byte[] buffer = new byte[1024];
            while (true)
            {
                int readSize = fs.Read(buffer, 0, buffer.Length);
                if (readSize == 0)
                    break;
                reqStrm.Write(buffer, 0, readSize);
            }

            fs.Close();
            reqStrm.Close();

            m = 0;
            s = 0;
            h = 0;

        }

        private void TimerForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            new mainForm().Show();
            this.Dispose();
        }

        private void TimerForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            e.Cancel = true;
        }

        private void timer1_Tick(object sender, EventArgs e)
        {

            s++;
            if (s >= 60)
            {
                m++;
                s = 0;
            }
            if (m >= 60)
            {
                h++;
                m = 0;
            }

            t_hour.Text =
                string.Format("{0:00}:{1:00}", h, m);
            t_second.Text =
                string.Format("{0:00}", s);
            
        }

        private void Time_Click(object sender, EventArgs e)
        {

        }

        private void t_hour_Click(object sender, EventArgs e)
        {

        }

        
        private void button1_Click(object sender, EventArgs e)
        {
            var r = MessageBox.Show("정말로 로그아웃 하시겠습니까?", "로그아웃", MessageBoxButtons.YesNo,
                                 MessageBoxIcon.Question);

            if(r == DialogResult.Yes)
            {
                new mainForm().Show();
                this.Dispose();
            }
            
        }


        private void TimerForm_Shown(object sender, EventArgs e)
        {
            timer1.Enabled = true;
        }
    }
}
