/*
 * 由SharpDevelop创建。
 * 用户： 吕易天
 * 日期: 2021/2/7
 * 时间: 19:14
 * 
 * 要改变这种模板请点击 工具|选项|代码编写|编辑标准头文件
 */
using System;
using System.Windows.Forms;

namespace MemoryManager
{
	/// <summary>
	/// Class with program entry point.
	/// </summary>
	internal sealed class Program
	{
		/// <summary>
		/// Program entry point.
		/// </summary>
		[STAThread]
		private static void Main(string[] args)
		{
			IntPtr pwq=new IntPtr();
			uint r=MainForm.RtlAdjustPrivilege(13,true,false,ref pwq);
			if(pwq.ToInt32()==0&&r!=0)
			{
				MessageBox.Show("Failed to get SeProfileSingleProcessPrivilege. NTSTATUS: "+r,"Try running as admin");
				Environment.Exit(-1);
			}
			r=MainForm.RtlAdjustPrivilege(20,true,false,ref pwq);
			if(pwq.ToInt32()==0&&r!=0)
			{
				MessageBox.Show("Failed to get SeDebugPrivilege. NTSTATUS: "+r,"Try running as admin");
				Environment.Exit(-1);
			}
			r=MainForm.RtlAdjustPrivilege(5,true,false,ref pwq);
			if(pwq.ToInt32()==0&&r!=0)
			{
				MessageBox.Show("Failed to get SeIncreaseQuotaPrivilege. NTSTATUS: "+r,"Try running as admin");
				Environment.Exit(-1);
			}
			Application.EnableVisualStyles();
			Application.SetCompatibleTextRenderingDefault(true);
			Application.Run(new MainForm());
		}
		
	}
}
