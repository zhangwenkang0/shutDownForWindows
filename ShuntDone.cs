using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using ExitWindowsAll;
using System.Threading;  


namespace ShuntDoneWindows
{
    
    public partial class ShuntDone : Form
    {
        ExitWindows objExitWindows;
        public Boolean State = false;
      
        public ShuntDone()
        {
            
            InitializeComponent();
            //获取当前日期
            DateTime objDateTime = System.DateTime.Now;
            //获取当前日期
            string currentDate = objDateTime.ToLongDateString();
            //获取当前时间
            string currentTime = objDateTime.ToLongTimeString();
            //在界面上显示当前日期和时间
            this.textDateTime.Text =currentDate + "" + currentTime;
            //给 DateTimePicker控件赋值
            this.dtpCurrentDate.Value = objDateTime;
            //给 DateTimePicker控件赋值
            this.dtpCurrentTime.Value = objDateTime;
            //启动定时器
            this.tmrMainClock.Start();
            //不显示系统托盘
            this.notifyIcon1.Visible = false;
            //实例化ExitWindows类
            objExitWindows = new ExitWindows();
            this.lblState2.Text = "未启动";
        }
        /// <summary>
        /// 应用程序的主入口点。
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            
            bool initiallyOwned = true;
            bool isCreated;
            Mutex m = new Mutex(initiallyOwned, "MyTest", out isCreated);
            if (!(initiallyOwned && isCreated))
            {
                MessageBox.Show("程序已运行！", "提示");
                Application.Exit();
            }
            else
            {
                Application.Run(new ShuntDone());
            }  

            
        }


   private void btnHide_Click(object sender, EventArgs e)
        {
            //在系统托盘显示图标
            this.notifyIcon1.Visible = true;
            //隐藏主界面
            this.Visible = false;
        }

    private void tmrMainClock_Tick(object sender, EventArgs e)
        {
            //每一次定时时间内刷新日期时间的显示
            DateTime objDateTime = System.DateTime.Now;
            string currentDate = objDateTime.ToLongDateString();
            string currentTime = objDateTime.ToLongTimeString();
            this.textDateTime.Text = currentDate + " " + currentTime;
            //检查是否启动定时关机
            if (State == true)
            {
                //定时关机已经启动
                //计算剩余的关机时间
                //得到设定关机时间的年分
                int intYear = this.dtpCurrentDate.Value.Year;
                //得到设定关机时间的月分
                int intMonth = this.dtpCurrentDate.Value.Month;
                //得到设定关机时间的天数
                int intDay = this.dtpCurrentDate.Value.Day;
                //得到设定关机时间的小时
                int intHour = this.dtpCurrentTime.Value.Hour;
                //得到设定关机时间的分
                int intMinute = this.dtpCurrentTime.Value.Minute;
                //得到设定关机时间的秒
                int intSecond = this.dtpCurrentTime.Value.Second;
                //用设定关机时间的年、月、日、小时、分、秒实例化
                objDateTime = new DateTime(intYear, intMonth, intDay, intHour, intMinute, intSecond);
                //求剩余的关机时间
                System.TimeSpan remainTime = objDateTime - System.DateTime.Now;
                //将剩余的关机时间转换为秒
                double time = remainTime.TotalSeconds;
                //判断是否为负值
                if (time < 0)
                {
                    //结果为负，表示设置的关机时间不合适，一般为误操作
                    //取消“启动定时关机”
                    State = false;
                    //显示提示信息
                    MessageBox.Show("设定的定时关机时间必须大于当前的时间");
                    this.lblState2.Text = "未启动";
                }
                else
                {
                    //结果为正值
                    //检查是否小于60秒并且提示方式为1分钟倒计时
                    if (time < 60 && State == true)
                    {
                        //启动提醒界面
                        //实例化AwokeForm，并传递主窗体对象
                        AwokeForm objAwokeForm = new AwokeForm(this);
                        //关闭计时器
                        this.tmrMainClock.Stop();
                        //隐藏主界面
                        this.Visible = false;
                        //显示提醒界面
                        objAwokeForm.Show();
                        objAwokeForm.lbl = lblState2;
                        objAwokeForm.tmr = tmrMainClock;
                    }
                    //检查是否小于0秒并且提示方式为无
                    if (time < 0 && State== false)
                    {
                        //关机
                        //调用关闭方法
                        bool ok = objExitWindows.Close();
                        if (!ok)
                        {
                            MessageBox.Show("由于某种原因，无法完成操作");
                        }
                    }
                }
            }
        }

        private void notifyIcon1_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            //显示主界面
            this.Visible = true;
        }

        private void menuItemShowMainForm_Click(object sender, EventArgs e)
        {//显示主界面
            this.Visible = true;
            //不在系统托盘显示图标
            this.notifyIcon1.Visible = false;

        }

        private void menuItemExit_Click(object sender, EventArgs e)
        {
            //关闭主界面
            this.Close();
        }

        private void btnStart_Click(object sender, EventArgs e)
        {
            State = true;
            this.lblState2.Text = "已启动";
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            State = false;
            this.lblState2.Text = "未启动";
        }

        private void btnOut_Click(object sender, EventArgs e)
        {
            this.Close();
        }



    }
}
