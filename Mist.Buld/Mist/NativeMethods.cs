using System;
using System.Runtime.InteropServices;

namespace Mist
{
	// Token: 0x0200000A RID: 10
	internal class NativeMethods
	{
		// Token: 0x06000018 RID: 24
		[DllImport("kernel32.dll", BestFitMapping = false, CharSet = CharSet.Unicode)]
		internal static extern IntPtr GetModuleHandle(string lpModuleName);

		// Token: 0x06000019 RID: 25
		[DllImport("Kernel32.dll", ExactSpelling = true, SetLastError = true)]
		[return: MarshalAs(UnmanagedType.Bool)]
		internal static extern bool CheckRemoteDebuggerPresent(IntPtr hProcess, [MarshalAs(UnmanagedType.Bool)] ref bool isDebuggerPresent);

		// Token: 0x0600001A RID: 26
		[DllImport("kernel32.dll")]
		internal static extern IntPtr ZeroMemory(IntPtr addr, IntPtr size);

		// Token: 0x0600001B RID: 27
		[DllImport("kernel32.dll")]
		internal unsafe static extern bool VirtualProtect(byte* lpAddress, int dwSize, uint flNewProtect, out uint lpflOldProtect);

		// Token: 0x0600001C RID: 28
		[DllImport("user32.dll")]
		internal static extern IntPtr GetClipboardData(uint uFormat);

		// Token: 0x0600001D RID: 29
		[DllImport("user32.dll")]
		public static extern bool IsClipboardFormatAvailable(uint format);

		// Token: 0x0600001E RID: 30
		[DllImport("user32.dll", SetLastError = true)]
		internal static extern bool OpenClipboard(IntPtr hWndNewOwner);

		// Token: 0x0600001F RID: 31
		[DllImport("user32.dll", SetLastError = true)]
		internal static extern bool CloseClipboard();

		// Token: 0x06000020 RID: 32
		[DllImport("user32.dll")]
		internal static extern bool EmptyClipboard();

		// Token: 0x06000021 RID: 33
		[DllImport("kernel32.dll")]
		internal static extern IntPtr GlobalLock(IntPtr hMem);

		// Token: 0x06000022 RID: 34
		[DllImport("kernel32.dll")]
		internal static extern bool GlobalUnlock(IntPtr hMem);

		// Token: 0x04000028 RID: 40
		public const int WM_CLIPBOARDUPDATE = 797;

		// Token: 0x04000029 RID: 41
		public static IntPtr HWND_MESSAGE = new IntPtr(-3);
	}
}
