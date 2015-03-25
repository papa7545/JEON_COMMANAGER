using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace JEON_CManager
{
    public partial class mainForm : Form
    {
        public mainForm()
        {
            InitializeComponent();
            this.FormBorderStyle = FormBorderStyle.None;
            this.Size = new Size(Screen.PrimaryScreen.Bounds.Width, Screen.PrimaryScreen.Bounds.Height);
        }

        private void mainForm_Load(object sender, EventArgs e)
        {
            this.TopMost = true;
        }

        private void mainForm_KeyDown_1(object sender, KeyEventArgs e)
        {
            if (e.Alt && e.KeyCode == Keys.F4)
                e.Handled = true;
            if (e.KeyCode == Keys.Delete)
                this.Dispose();

        }

        private void timer1_Tick(object sender, EventArgs e)
        {

        }

        private void mainForm_Deactivate(object sender, EventArgs e)
        {
            
        }
    }
}
