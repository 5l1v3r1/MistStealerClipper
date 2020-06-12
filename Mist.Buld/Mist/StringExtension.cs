using System;
using System.Globalization;
using System.Text;

namespace Mist
{
	// Token: 0x02000048 RID: 72
	public static class StringExtension
	{
		// Token: 0x06000203 RID: 515 RVA: 0x000055CA File Offset: 0x000037CA
		public static T ForceTo<T>(this object @this)
		{
			return (T)((object)Convert.ChangeType(@this, typeof(T)));
		}

		// Token: 0x06000204 RID: 516 RVA: 0x000055E1 File Offset: 0x000037E1
		public static string Remove(this string input, string strToRemove)
		{
			if (input.IsNullOrEmpty())
			{
				return null;
			}
			return input.Replace(strToRemove, "");
		}

		// Token: 0x06000205 RID: 517 RVA: 0x000055F9 File Offset: 0x000037F9
		public static string Left(this string input, int minusRight = 1)
		{
			if (input.IsNullOrEmpty() || input.Length <= minusRight)
			{
				return null;
			}
			return input.Substring(0, input.Length - minusRight);
		}

		// Token: 0x06000206 RID: 518 RVA: 0x0000561D File Offset: 0x0000381D
		public static CultureInfo ToCultureInfo(this string culture, CultureInfo defaultCulture)
		{
			if (!culture.IsNullOrEmpty())
			{
				return defaultCulture;
			}
			return new CultureInfo(culture);
		}

		// Token: 0x06000207 RID: 519 RVA: 0x0000562F File Offset: 0x0000382F
		public static string ToCamelCasing(this string value)
		{
			if (!string.IsNullOrEmpty(value))
			{
				return value.Substring(0, 1).ToUpper() + value.Substring(1, value.Length - 1);
			}
			return value;
		}

		// Token: 0x06000208 RID: 520 RVA: 0x0000FC74 File Offset: 0x0000DE74
		public static double? ToDouble(this string value, string culture = "en-US")
		{
			double? result;
			try
			{
				result = new double?(double.Parse(value, new CultureInfo(culture)));
			}
			catch
			{
				result = null;
			}
			return result;
		}

		// Token: 0x06000209 RID: 521 RVA: 0x0000FCB4 File Offset: 0x0000DEB4
		public static bool? ToBoolean(this string value)
		{
			bool value2 = false;
			if (bool.TryParse(value, out value2))
			{
				return new bool?(value2);
			}
			return null;
		}

		// Token: 0x0600020A RID: 522 RVA: 0x0000FCE0 File Offset: 0x0000DEE0
		public static int? ToInt32(this string value)
		{
			int value2 = 0;
			if (int.TryParse(value, out value2))
			{
				return new int?(value2);
			}
			return null;
		}

		// Token: 0x0600020B RID: 523 RVA: 0x0000FD0C File Offset: 0x0000DF0C
		public static long? ToInt64(this string value)
		{
			long value2 = 0L;
			if (long.TryParse(value, out value2))
			{
				return new long?(value2);
			}
			return null;
		}

		// Token: 0x0600020C RID: 524 RVA: 0x0000FD38 File Offset: 0x0000DF38
		public static string AddQueyString(this string url, string queryStringKey, string queryStringValue)
		{
			string text = (url.Split(new char[]
			{
				'?'
			}).Length <= 1) ? "?" : "&";
			return string.Concat(new string[]
			{
				url,
				text,
				queryStringKey,
				"=",
				queryStringValue
			});
		}

		// Token: 0x0600020D RID: 525 RVA: 0x0000565C File Offset: 0x0000385C
		public static string FormatFirstLetterUpperCase(this string value, string culture = "en-US")
		{
			return CultureInfo.GetCultureInfo(culture).TextInfo.ToTitleCase(value);
		}

		// Token: 0x0600020E RID: 526 RVA: 0x0000FD94 File Offset: 0x0000DF94
		public static string FillLeftWithZeros(this string value, int decimalDigits)
		{
			if (!string.IsNullOrEmpty(value))
			{
				StringBuilder stringBuilder = new StringBuilder();
				stringBuilder.Append(value);
				string[] array = value.Split(new char[]
				{
					','
				});
				for (int i = array[array.Length - 1].Length; i < decimalDigits; i++)
				{
					stringBuilder.Append("0");
				}
				value = stringBuilder.ToString();
			}
			return value;
		}

		// Token: 0x0600020F RID: 527 RVA: 0x0000FDF4 File Offset: 0x0000DFF4
		public static string FormatWithDecimalDigits(this string value, bool removeCurrencySymbol, bool returnZero, int? decimalDigits)
		{
			if (value.IsNullOrEmpty())
			{
				return value;
			}
			if (!value.IndexOf(",").Equals(-1))
			{
				string[] array = value.Split(new char[]
				{
					','
				});
				if (array.Length.Equals(2) && array[1].Length > 0)
				{
					value = array[0] + "," + array[1].Substring(0, (array[1].Length >= decimalDigits.Value) ? decimalDigits.Value : array[1].Length);
				}
			}
			if (decimalDigits == null)
			{
				return value;
			}
			return value.FillLeftWithZeros(decimalDigits.Value);
		}

		// Token: 0x06000210 RID: 528 RVA: 0x0000566F File Offset: 0x0000386F
		public static string FormatWithoutDecimalDigits(this string value, bool removeCurrencySymbol, bool returnZero, int? decimalDigits, CultureInfo culture)
		{
			if (removeCurrencySymbol)
			{
				value = value.Remove(culture.NumberFormat.CurrencySymbol).Trim();
			}
			return value;
		}
	}
}
