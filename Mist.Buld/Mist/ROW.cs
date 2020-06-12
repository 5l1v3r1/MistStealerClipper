using System;

namespace Mist
{
	// Token: 0x02000045 RID: 69
	public struct ROW
	{
		// Token: 0x17000051 RID: 81
		// (get) Token: 0x060001E9 RID: 489 RVA: 0x00005556 File Offset: 0x00003756
		// (set) Token: 0x060001EA RID: 490 RVA: 0x0000555E File Offset: 0x0000375E
		public long ID { get; set; }

		// Token: 0x17000052 RID: 82
		// (get) Token: 0x060001EB RID: 491 RVA: 0x00005567 File Offset: 0x00003767
		// (set) Token: 0x060001EC RID: 492 RVA: 0x0000556F File Offset: 0x0000376F
		public string[] RowData { get; set; }
	}
}
