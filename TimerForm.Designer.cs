namespace JEON_CManager
{
    partial class TimerForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.text_stdNum = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.text_name = new System.Windows.Forms.Label();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.t_hour = new System.Windows.Forms.Label();
            this.t_second = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.classnum = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(148, 30);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(29, 12);
            this.label1.TabIndex = 0;
            this.label1.Text = "이름";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(18, 30);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(29, 12);
            this.label2.TabIndex = 0;
            this.label2.Text = "학번";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(104, 82);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(29, 12);
            this.label3.TabIndex = 0;
            this.label3.Text = "시간";
            // 
            // text_stdNum
            // 
            this.text_stdNum.AutoSize = true;
            this.text_stdNum.Font = new System.Drawing.Font("Gulim", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.text_stdNum.Location = new System.Drawing.Point(54, 30);
            this.text_stdNum.Name = "text_stdNum";
            this.text_stdNum.Size = new System.Drawing.Size(61, 12);
            this.text_stdNum.TabIndex = 0;
            this.text_stdNum.Text = "00000000";
            // 
            // button1
            // 
            this.button1.Font = new System.Drawing.Font("Gulim", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.button1.ForeColor = System.Drawing.Color.Red;
            this.button1.Location = new System.Drawing.Point(12, 52);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(86, 48);
            this.button1.TabIndex = 1;
            this.button1.Text = "로그아웃";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // text_name
            // 
            this.text_name.AutoSize = true;
            this.text_name.Font = new System.Drawing.Font("Gulim", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.text_name.Location = new System.Drawing.Point(184, 30);
            this.text_name.Name = "text_name";
            this.text_name.Size = new System.Drawing.Size(44, 12);
            this.text_name.TabIndex = 0;
            this.text_name.Text = "홍길동";
            // 
            // timer1
            // 
            this.timer1.Interval = 1000;
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // t_hour
            // 
            this.t_hour.AutoSize = true;
            this.t_hour.Font = new System.Drawing.Font("Gulim", 36F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.t_hour.Location = new System.Drawing.Point(139, 52);
            this.t_hour.Name = "t_hour";
            this.t_hour.Size = new System.Drawing.Size(153, 48);
            this.t_hour.TabIndex = 2;
            this.t_hour.Text = "00:00";
            this.t_hour.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.t_hour.Click += new System.EventHandler(this.t_hour_Click);
            // 
            // t_second
            // 
            this.t_second.AutoSize = true;
            this.t_second.Font = new System.Drawing.Font("Gulim", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.t_second.Location = new System.Drawing.Point(283, 75);
            this.t_second.Name = "t_second";
            this.t_second.Size = new System.Drawing.Size(31, 19);
            this.t_second.TabIndex = 3;
            this.t_second.Text = "00";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(12, 9);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(41, 12);
            this.label4.TabIndex = 0;
            this.label4.Text = "학년반";
            // 
            // classnum
            // 
            this.classnum.AutoSize = true;
            this.classnum.Font = new System.Drawing.Font("Gulim", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.classnum.Location = new System.Drawing.Point(54, 9);
            this.classnum.Name = "classnum";
            this.classnum.Size = new System.Drawing.Size(63, 12);
            this.classnum.TabIndex = 0;
            this.classnum.Text = "0학년 0반";
            // 
            // TimerForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(333, 105);
            this.Controls.Add(this.t_second);
            this.Controls.Add(this.t_hour);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.text_stdNum);
            this.Controls.Add(this.classnum);
            this.Controls.Add(this.text_name);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Location = new System.Drawing.Point(1000, 1000);
            this.Name = "TimerForm";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.Text = "TimerForm";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.TimerForm_FormClosing);
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.TimerForm_FormClosed);
            this.Shown += new System.EventHandler(this.TimerForm_Shown);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.Label t_hour;
        private System.Windows.Forms.Label t_second;
        public System.Windows.Forms.Label text_stdNum;
        public System.Windows.Forms.Label text_name;
        private System.Windows.Forms.Label label4;
        public System.Windows.Forms.Label classnum;
    }
}