using System;
using System.Security.Principal;

// Token: 0x02000002 RID: 2
public class RunCheck
{
	// Token: 0x17000001 RID: 1
	// (get) Token: 0x06000002 RID: 2 RVA: 0x000042B2 File Offset: 0x000024B2
	public static bool IsAdmin
	{
		get
		{
			return new WindowsPrincipal(WindowsIdentity.GetCurrent()).IsInRole(WindowsBuiltInRole.Administrator);
		}
	}

	// Token: 0x17000002 RID: 2
	// (get) Token: 0x06000003 RID: 3 RVA: 0x000042C8 File Offset: 0x000024C8
	public static bool IsWin64
	{
		get
		{
			return Environment.Is64BitOperatingSystem;
		}
	}

	// Token: 0x06000004 RID: 4 RVA: 0x000042D4 File Offset: 0x000024D4
	public static bool StartWin_xSixtyFour()
	{
		return Environment.Is64BitOperatingSystem;
	}

	// Token: 0x06000005 RID: 5 RVA: 0x00005BD4 File Offset: 0x00003DD4
	public static bool IsUserAdministrator()
	{
		bool result;
		try
		{
			result = new WindowsPrincipal(WindowsIdentity.GetCurrent()).IsInRole(WindowsBuiltInRole.Administrator);
		}
		catch
		{
			result = false;
		}
		return result;
	}
}
