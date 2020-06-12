using System;

namespace Mist
{
	// Token: 0x0200003A RID: 58
	public struct FF
	{
		// Token: 0x17000037 RID: 55
		// (get) Token: 0x06000133 RID: 307 RVA: 0x00004AE9 File Offset: 0x00002CE9
		// (set) Token: 0x06000134 RID: 308 RVA: 0x00004AF1 File Offset: 0x00002CF1
		public long ID { get; set; }

		// Token: 0x17000038 RID: 56
		// (get) Token: 0x06000135 RID: 309 RVA: 0x00004AFA File Offset: 0x00002CFA
		// (set) Token: 0x06000136 RID: 310 RVA: 0x00004B02 File Offset: 0x00002D02
		public string Type { get; set; }

		// Token: 0x17000039 RID: 57
		// (get) Token: 0x06000137 RID: 311 RVA: 0x00004B0B File Offset: 0x00002D0B
		// (set) Token: 0x06000138 RID: 312 RVA: 0x00004B13 File Offset: 0x00002D13
		public string Name { get; set; }

		// Token: 0x1700003A RID: 58
		// (get) Token: 0x06000139 RID: 313 RVA: 0x00004B1C File Offset: 0x00002D1C
		// (set) Token: 0x0600013A RID: 314 RVA: 0x00004B24 File Offset: 0x00002D24
		public string AstableName { get; set; }

		// Token: 0x1700003B RID: 59
		// (get) Token: 0x0600013B RID: 315 RVA: 0x00004B2D File Offset: 0x00002D2D
		// (set) Token: 0x0600013C RID: 316 RVA: 0x00004B35 File Offset: 0x00002D35
		public long RootNum { get; set; }

		// Token: 0x1700003C RID: 60
		// (get) Token: 0x0600013D RID: 317 RVA: 0x00004B3E File Offset: 0x00002D3E
		// (set) Token: 0x0600013E RID: 318 RVA: 0x00004B46 File Offset: 0x00002D46
		public string SqlStatement { get; set; }
	}
}
