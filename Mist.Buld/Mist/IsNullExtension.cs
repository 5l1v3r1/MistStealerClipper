using System;

namespace Mist
{
	// Token: 0x0200003B RID: 59
	public static class IsNullExtension
	{
		// Token: 0x0600013F RID: 319 RVA: 0x00004B4F File Offset: 0x00002D4F
		public static bool IsNotNull<T>(this T data)
		{
			return data != null;
		}

		// Token: 0x06000140 RID: 320 RVA: 0x00004B5A File Offset: 0x00002D5A
		public static string IsNull(this string value, string defaultValue)
		{
			if (!string.IsNullOrEmpty(value))
			{
				return value;
			}
			return defaultValue;
		}

		// Token: 0x06000141 RID: 321 RVA: 0x00004B67 File Offset: 0x00002D67
		public static bool IsNullOrEmpty(this string str)
		{
			return string.IsNullOrEmpty(str);
		}

		// Token: 0x06000142 RID: 322 RVA: 0x00004B6F File Offset: 0x00002D6F
		public static bool IsNull(this bool? value, bool def)
		{
			if (value != null)
			{
				return value.Value;
			}
			return def;
		}

		// Token: 0x06000143 RID: 323 RVA: 0x00004B83 File Offset: 0x00002D83
		public static T IsNull<T>(this T value) where T : class
		{
			if (value == null)
			{
				return Activator.CreateInstance<T>();
			}
			return value;
		}

		// Token: 0x06000144 RID: 324 RVA: 0x00004B94 File Offset: 0x00002D94
		public static T IsNull<T>(this T value, T def) where T : class
		{
			if (value != null)
			{
				return value;
			}
			if (def == null)
			{
				return Activator.CreateInstance<T>();
			}
			return def;
		}

		// Token: 0x06000145 RID: 325 RVA: 0x00004BAF File Offset: 0x00002DAF
		public static int IsNull(this int? value, int def)
		{
			if (value != null)
			{
				return value.Value;
			}
			return def;
		}

		// Token: 0x06000146 RID: 326 RVA: 0x00004BC3 File Offset: 0x00002DC3
		public static long IsNull(this long? value, long def)
		{
			if (value != null)
			{
				return value.Value;
			}
			return def;
		}

		// Token: 0x06000147 RID: 327 RVA: 0x00004BD7 File Offset: 0x00002DD7
		public static double IsNull(this double? value, double def)
		{
			if (value != null)
			{
				return value.Value;
			}
			return def;
		}

		// Token: 0x06000148 RID: 328 RVA: 0x00004BEB File Offset: 0x00002DEB
		public static DateTime IsNull(this DateTime? value, DateTime def)
		{
			if (value != null)
			{
				return value.Value;
			}
			return def;
		}

		// Token: 0x06000149 RID: 329 RVA: 0x00004BFF File Offset: 0x00002DFF
		public static Guid IsNull(this Guid? value, Guid def)
		{
			if (value != null)
			{
				return value.Value;
			}
			return def;
		}
	}
}
