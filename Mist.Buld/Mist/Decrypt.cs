using System;
using System.IO;
using Ionic.Zlib;

namespace Mist
{
	// Token: 0x02000006 RID: 6
	internal class Decrypt
	{
		// Token: 0x06000009 RID: 9 RVA: 0x00005CA0 File Offset: 0x00003EA0
		public static string Get(string str)
		{
			byte[] array = Convert.FromBase64String(str);
			string result = string.Empty;
			if (array != null && array.Length != 0)
			{
				using (MemoryStream memoryStream = new MemoryStream(array))
				{
					using (GZipStream gzipStream = new GZipStream(memoryStream, 1))
					{
						using (StreamReader streamReader = new StreamReader(gzipStream))
						{
							result = streamReader.ReadToEnd();
						}
					}
				}
			}
			return result;
		}
	}
}
