using System;
using System.Security.Principal;

namespace Mist
{
	// Token: 0x02000061 RID: 97
	public static class RunChecker
	{
		// Token: 0x17000059 RID: 89
		// (get) Token: 0x06000273 RID: 627 RVA: 0x000042B2 File Offset: 0x000024B2
		public static bool IsAdmin
		{
			get
			{
				return new WindowsPrincipal(WindowsIdentity.GetCurrent()).IsInRole(WindowsBuiltInRole.Administrator);
			}
		}

		// Token: 0x1700005A RID: 90
		// (get) Token: 0x06000274 RID: 628 RVA: 0x000042C8 File Offset: 0x000024C8
		public static bool IsWin64
		{
			get
			{
				return Environment.Is64BitOperatingSystem;
			}
		}
	}
}
