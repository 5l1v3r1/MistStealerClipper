using System;
using System.IO;

namespace Mist
{
	// Token: 0x0200003E RID: 62
	public static class JsonExt
	{
		// Token: 0x06000169 RID: 361 RVA: 0x00004DDC File Offset: 0x00002FDC
		public static JsonValue FromJSON(this string json)
		{
			return JsonValue.Load(new StringReader(json));
		}

		// Token: 0x0600016A RID: 362 RVA: 0x00004DE9 File Offset: 0x00002FE9
		public static string ToJSON<T>(this T instance)
		{
			return JsonValue.ToJsonValue<T>(instance);
		}
	}
}
