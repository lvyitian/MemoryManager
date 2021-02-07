/*
 * 由SharpDevelop创建。
 * 用户： 吕易天
 * 日期: 2021/2/7
 * 时间: 19:14
 * 
 * 要改变这种模板请点击 工具|选项|代码编写|编辑标准头文件
 */
using System;
using System.Runtime.InteropServices;
using System.Windows.Forms;

namespace MemoryManager
{
	/// <summary>
	/// Description of MainForm.
	/// </summary>
	
	public partial class MainForm : Form
	{
		[DllImport("ntdll.dll",SetLastError=true,EntryPoint="RtlAdjustPrivilege")]
        public extern static uint RtlAdjustPrivilege(int Privilege,bool Enable,bool CurrentThread,ref IntPtr Enabled);
        [DllImport("ntdll.dll",SetLastError=true,EntryPoint="ZwSetSystemInformation")]
		public static unsafe extern uint ZwSetSystemInformation(int a,int* b,int c,int d);
		[DllImport("kernel32.dll",SetLastError=true,EntryPoint="SetSystemFileCacheSize")]
		public static extern bool SetSystemFileCacheSize(int a,int b,int c,int d);
		public MainForm()
		{
			//
			// The InitializeComponent() call is required for Windows Forms designer support.
			//
			InitializeComponent();
			//
			// TODO: Add constructor code after the InitializeComponent() call.
			//
		}
		unsafe void Button1Click(object sender, EventArgs e)
		{
			int pwq=2;
			MessageBox.Show("NTSTATUS: "+ZwSetSystemInformation(80,&pwq,4,716));
		}
		void Button2Click(object sender, EventArgs e)
		{
			MessageBox.Show("Success: "+SetSystemFileCacheSize(-1,-1,0,716));
		}
		unsafe void Button3Click(object sender, EventArgs e)
		{
			int pwq=3;
			MessageBox.Show("NTSTATUS: "+ZwSetSystemInformation(80,&pwq,4,716));
		}
		unsafe void Button4Click(object sender, EventArgs e)
		{
			int pwq=4;
			MessageBox.Show("NTSTATUS: "+ZwSetSystemInformation(80,&pwq,4,716));
		}
		unsafe void Button5Click(object sender, EventArgs e)
		{
			int pwq=5;
			MessageBox.Show("NTSTATUS: "+ZwSetSystemInformation(80,&pwq,4,716));
		}
	}
}
