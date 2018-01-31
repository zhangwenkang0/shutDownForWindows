using System;
using System.Runtime.InteropServices;

namespace ExitWindowsAll
{
    public class ExitWindows
    {
        //在LookupPrivilegeValue函数中使用的常量
        //关机特权的常量
        internal const string SE_SHUTDOWN_NAME = "SeShutdownPrivilege";
        //在OpenProcessToken函数中使用的常量
        //令牌查询方式的常量
        internal const int TOKEN_QUERY = 0x00000008;
        //令牌调整方式的常量
        internal const int TOKEN_ADJUST_PRIVILEGES = 0x00000020;
        //在AdjustTokenPrivileges函数中使用的常量
        //Windows系统特权常量
        internal const int SE_PRIVILEGE_ENABLED = 0x00000002;
        //在DoExitWin函数中使用的常量
        //注销计算机的常量
        internal const int EWX_LOGOFF = 0x00000000;
        //关机计算机的常量
        internal const int EWX_SHUTDOWN = 0x00000001;
        //重启计算机的常量
        internal const int EWX_REBOOT = 0x00000002;
        //强迫中止没有响应的进程的常量
        internal const int EWX_FORCE = 0x00000004;
        //关闭电源的常量
        internal const int EWX_POWEROFF = 0x00000008;
        //中断进程的常量
        internal const int EWX_FORCEIFHUNG = 0x00000010;
        //定义向非托管函数之间相互传递值的结构体,
        //结构体的名称TokenPrivilegeLuid含义为－令牌权限Luid
        [StructLayout(LayoutKind.Sequential, Pack = 1)]
        internal struct TokenPrivilegeLuid
        {
            //确定权限数组元素的个数
            public int PrivilegesCount;
            //Luid 的含义为 locally unique identifier
            //保证局部唯一标志，就是指在系统的每一次运行期间保证是唯一的值
            //这里定义存放权限的Luid
            public long PrivilegesLuid;
            //权限属性
            public int PrivilegesAttributes;
        }
        //导入API函数
        //导入获取当前进程句柄的函数。
        [DllImport("kernel32.dll", ExactSpelling = true)]
        internal static extern IntPtr GetCurrentProcess();
        //导入打开当前进程的访问令牌的函数
        [DllImport("advapi32.dll", ExactSpelling = true, SetLastError = true)]
        internal static extern bool OpenProcessToken(IntPtr h, int acc, ref IntPtr phtok);
        //导入获取系统特定的权限值的函数
        [DllImport("advapi32.dll", SetLastError = true)]
        internal static extern bool LookupPrivilegeValue(string host, string name, ref long pluid);
        //导入调整访问令牌权限的函数
        [DllImport("advapi32.dll", ExactSpelling = true, SetLastError = true)]
        internal static extern bool AdjustTokenPrivileges(IntPtr htok, bool disall, ref TokenPrivilegeLuid
        newst, int len, IntPtr prev, IntPtr relen);
        //导入关闭计算机的函数
        [DllImport("user32.dll", ExactSpelling = true, SetLastError = true)]
        internal static extern bool ExitWindowsEx(int flags, int reason);
        //构造函数
        public ExitWindows()
        {
        }
        //关闭方法
        public bool Close()
        {
            //关机、关闭电源和强迫中止没有响应的进程的常量
            if (DoExitWin(EWX_SHUTDOWN | EWX_POWEROFF | EWX_FORCE))
            {
                return true;
            }
            return false;
        }
//        //注销方法
//        public bool ReLogin()
//{
////注销用户和强迫中止没有响应的进程的常量
//if(DoExitWin(EWX_LOGOFF | EWX_FORCE))
//{
//return true;
//}
//return false;
//}
////重启方法和强迫中止没有响应的进程的常量
//public bool ReBoot()
//{
////重启计算机
//if(DoExitWin(EWX_REBOOT | EWX_FORCE))
//{
//return true;
//}
//return false;
//}
//退出Windows的具体实现方法
public bool DoExitWin( int flags )
{
bool ok;
//定义向非托管函数之间相互传递值的的类型变量objTPL
TokenPrivilegeLuid objTPL;
//设定objTPL的值
//设置权限个数为1
objTPL.PrivilegesCount = 1;
//给PrivilegesLuid赋初始值，无其他含义
objTPL.PrivilegesLuid = 0;
//设置权限属性，允许使用特权
objTPL.PrivilegesAttributes = SE_PRIVILEGE_ENABLED;
//初始化为零的指针句柄,为下面的调用做准备
//htok含义为handle token令牌句柄，这里遵循VC++的命名习惯
IntPtr htok = IntPtr.Zero;
//获取当前进程的句柄，结果在hproc结构体中
//hproc含义为handle process进程句柄，这里遵循VC++的命名习惯
IntPtr hproc = GetCurrentProcess();
//以调整和查询的方式打开本进程的访问令牌，访问令牌句柄返回在htok结构体中
ok = OpenProcessToken( hproc, TOKEN_ADJUST_PRIVILEGES | TOKEN_QUERY, ref
htok );
if(!ok)
    {
return false;
}
//获取系统关机的权限值，结果在objTPL.PrivilegesLuid中
ok = LookupPrivilegeValue( null, SE_SHUTDOWN_NAME, ref objTPL.PrivilegesLuid );
if(!ok)
{
return false;
}
//修改当前进程访问令牌的权限，使其具有关机权限
//这里使用到了objTPL.PrivilegesAttributes = SE_PRIVILEGE_ENABLED的值
ok = AdjustTokenPrivileges(htok, false, ref objTPL, 0, IntPtr.Zero, IntPtr.Zero );
if(!ok)
{
return false;
}
//调用退出Windows的函数，具体是关机、注销还是重启等由flags的值来确定
//EWX_FORCE 是强迫中止没有响应的进程，这样能保证关机操作的进行
ok = ExitWindowsEx(flags | EWX_FORCE, 0 );
if(!ok)
{
return false;
}
return true;
}
}

    }

