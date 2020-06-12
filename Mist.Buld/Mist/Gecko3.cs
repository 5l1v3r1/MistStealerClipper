using System;

namespace Mist
{
	// Token: 0x02000032 RID: 50
	public class Gecko3
	{
		// Token: 0x1700000F RID: 15
		// (get) Token: 0x060000DA RID: 218 RVA: 0x00004841 File Offset: 0x00002A41
		// (set) Token: 0x060000DB RID: 219 RVA: 0x00004849 File Offset: 0x00002A49
		public int nextId { get; set; }

		// Token: 0x17000010 RID: 16
		// (get) Token: 0x060000DC RID: 220 RVA: 0x00004852 File Offset: 0x00002A52
		// (set) Token: 0x060000DD RID: 221 RVA: 0x0000485A File Offset: 0x00002A5A
		public Gecko5[] logins { get; set; }

		// Token: 0x17000011 RID: 17
		// (get) Token: 0x060000DE RID: 222 RVA: 0x00004863 File Offset: 0x00002A63
		// (set) Token: 0x060000DF RID: 223 RVA: 0x0000486B File Offset: 0x00002A6B
		public object[] disabledHosts { get; set; }

		// Token: 0x17000012 RID: 18
		// (get) Token: 0x060000E0 RID: 224 RVA: 0x00004874 File Offset: 0x00002A74
		// (set) Token: 0x060000E1 RID: 225 RVA: 0x0000487C File Offset: 0x00002A7C
		public int version { get; set; }
	}
}
