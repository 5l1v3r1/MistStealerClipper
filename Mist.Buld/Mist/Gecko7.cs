using System;
using System.Globalization;

namespace Mist
{
	// Token: 0x02000036 RID: 54
	public class Gecko7
	{
		// Token: 0x17000025 RID: 37
		// (get) Token: 0x0600010B RID: 267 RVA: 0x000049CA File Offset: 0x00002BCA
		public string EntrySalt { get; }

		// Token: 0x17000026 RID: 38
		// (get) Token: 0x0600010C RID: 268 RVA: 0x000049D2 File Offset: 0x00002BD2
		public string OID { get; }

		// Token: 0x17000027 RID: 39
		// (get) Token: 0x0600010D RID: 269 RVA: 0x000049DA File Offset: 0x00002BDA
		public string Passwordcheck { get; }

		// Token: 0x0600010E RID: 270 RVA: 0x0000BF58 File Offset: 0x0000A158
		public Gecko7(string DataToParse)
		{
			int num = int.Parse(DataToParse.Substring(2, 2), NumberStyles.HexNumber) * 2;
			this.EntrySalt = DataToParse.Substring(6, num);
			int num2 = DataToParse.Length - (6 + num + 36);
			this.OID = DataToParse.Substring(6 + num + 36, num2);
			this.Passwordcheck = DataToParse.Substring(6 + num + 4 + num2);
		}
	}
}
