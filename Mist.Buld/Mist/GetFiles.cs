using System;

namespace Mist
{
	// Token: 0x0200004D RID: 77
	public class GetFiles
	{
		// Token: 0x0200004E RID: 78
		public class Folders : IFolders
		{
			// Token: 0x17000055 RID: 85
			// (get) Token: 0x0600021B RID: 539 RVA: 0x000056C2 File Offset: 0x000038C2
			// (set) Token: 0x0600021C RID: 540 RVA: 0x000056CA File Offset: 0x000038CA
			public string Source { get; private set; }

			// Token: 0x17000056 RID: 86
			// (get) Token: 0x0600021D RID: 541 RVA: 0x000056D3 File Offset: 0x000038D3
			// (set) Token: 0x0600021E RID: 542 RVA: 0x000056DB File Offset: 0x000038DB
			public string Target { get; private set; }

			// Token: 0x0600021F RID: 543 RVA: 0x000056E4 File Offset: 0x000038E4
			public Folders(string source, string target)
			{
				this.Source = source;
				this.Target = target;
			}
		}
	}
}
