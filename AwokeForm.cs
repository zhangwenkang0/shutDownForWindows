using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using ExitWindowsAll;

namespace ShuntDoneWindows
{
    public partial class AwokeForm : Form 
    {
        //定义最大定时时间60秒
        int maxTimeNumber = 60;
        //定义主窗体类型变量objShutDone
        ShuntDone objShutDone;
        //定义ExitWindows类型成员
        ExitWindows objExitWindows;
        public Label lbl = new Label();
        public Timer tmr = new Timer();
        public AwokeForm(ShuntDone mainForm)
        {
            InitializeComponent();
            objShutDone = mainForm;     
            //启动计时器控件
            this.tmrClock.Start();
            //显示提示信息
            this.lblMessage.Text = "离自动关机时计时间还有60 秒";
        }    

        private void AwokeForm_Closing(object sender,System.ComponentModel.CancelEventArgs e)
        {
            //当用户关闭本窗体时进行的工作
            //关闭计时器控件
            this.tmrClock.Stop();
            //释放资源。这条不是必须的，尽管系统会自己收回资源，但是写出来条理清楚一些
            tmrClock.Dispose();
            //关闭主窗体
            objShutDone.Close();
        }
        private void tmrClock_Tick(object sender, System.EventArgs e)
        {
            //计时减一
            this.maxTimeNumber = maxTimeNumber - 1;
            if (this.maxTimeNumber == 0)
            {
                //关机时间到，执行关机操作
                //关闭计时器控件
                this.tmrClock.Stop();
                //实例化ExitWindows类
                objExitWindows = new ExitWindows();
                bool ok = objExitWindows.Close();
                if (!ok)
                {
                    MessageBox.Show("由于某种原因，无法完成操作");
                }
            }
            else
            {
                //显示提示信息
                this.lblMessage.Text = "离自动关机时计时间还有 " + this.maxTimeNumber.ToString() + " 秒";
            }
}
   

        private void btnCancel_Click(object sender, EventArgs e)
        {
            //关闭计时器控件
            this.tmrClock.Stop();
            //释放资源
            tmrClock.Dispose();
            //关闭本窗体
            this.Close();
            //显示主窗体
            objShutDone.Visible = true;
            objShutDone.State = false;
           lbl.Text = "未启动";
           tmr.Start();
        }

   
    }

}
