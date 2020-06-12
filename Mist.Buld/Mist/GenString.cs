using System;

namespace Mist
{
	// Token: 0x02000008 RID: 8
	internal class GenString
	{
		// Token: 0x0600000F RID: 15 RVA: 0x00005E54 File Offset: 0x00004054
		public static string Generate()
		{
			string text = "acegikmoqsuwyBDFHJLNPRTVXZ";
			string text2 = "";
			Random random = new Random();
			int num = random.Next(0, text.Length);
			for (int i = 0; i < num; i++)
			{
				text2 += text[random.Next(10, text.Length)].ToString();
			}
			return text2;
		}

		// Token: 0x06000010 RID: 16 RVA: 0x00004308 File Offset: 0x00002508
		public static int GeneNumbersTo()
		{
			return new Random().Next(11, 99);
		}
	}
}
