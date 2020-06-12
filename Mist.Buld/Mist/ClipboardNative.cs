using System;
using System.Runtime.InteropServices;

namespace Mist
{
	// Token: 0x0200004B RID: 75
	internal static class ClipboardNative
	{
		// Token: 0x06000216 RID: 534 RVA: 0x0000FF14 File Offset: 0x0000E114
		public static string GetText()
		{
			if (NativeMethods.IsClipboardFormatAvailable(13U) && NativeMethods.OpenClipboard(IntPtr.Zero))
			{
				string result = string.Empty;
				IntPtr clipboardData = NativeMethods.GetClipboardData(13U);
				if (!clipboardData.Equals(IntPtr.Zero))
				{
					IntPtr intPtr = NativeMethods.GlobalLock(clipboardData);
					if (!intPtr.Equals(IntPtr.Zero))
					{
						try
						{
							result = Marshal.PtrToStringUni(intPtr);
							NativeMethods.GlobalUnlock(intPtr);
						}
						catch
						{
						}
					}
				}
				NativeMethods.CloseClipboard();
				return result;
			}
			return null;
		}

		// Token: 0x04000115 RID: 277
		private const uint CF_UNICODETEXT = 13U;
	}
}
