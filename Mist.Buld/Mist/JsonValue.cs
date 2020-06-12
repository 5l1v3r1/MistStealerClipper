using System;
using System.Collections;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Reflection;
using System.Text;

namespace Mist
{
	// Token: 0x02000042 RID: 66
	public abstract class JsonValue : IEnumerable
	{
		// Token: 0x17000049 RID: 73
		// (get) Token: 0x0600019B RID: 411 RVA: 0x000050EE File Offset: 0x000032EE
		public virtual int Count
		{
			get
			{
				throw new InvalidOperationException();
			}
		}

		// Token: 0x1700004A RID: 74
		// (get) Token: 0x0600019C RID: 412
		public abstract JsonType JsonType { get; }

		// Token: 0x1700004B RID: 75
		public virtual JsonValue this[int index]
		{
			get
			{
				throw new InvalidOperationException();
			}
			set
			{
				throw new InvalidOperationException();
			}
		}

		// Token: 0x1700004C RID: 76
		public virtual JsonValue this[string key]
		{
			get
			{
				throw new InvalidOperationException();
			}
			set
			{
				throw new InvalidOperationException();
			}
		}

		// Token: 0x060001A1 RID: 417 RVA: 0x000050F5 File Offset: 0x000032F5
		public static JsonValue Load(Stream stream)
		{
			if (stream == null)
			{
				throw new ArgumentNullException("stream");
			}
			return JsonValue.Load(new StreamReader(stream, true));
		}

		// Token: 0x060001A2 RID: 418 RVA: 0x00005111 File Offset: 0x00003311
		public static JsonValue Load(TextReader textReader)
		{
			if (textReader == null)
			{
				throw new ArgumentNullException("textReader");
			}
			return JsonValue.ToJsonValue<object>(new JavaScriptReader(textReader).Read());
		}

		// Token: 0x060001A3 RID: 419 RVA: 0x00005131 File Offset: 0x00003331
		private static IEnumerable<KeyValuePair<string, JsonValue>> ToJsonPairEnumerable(IEnumerable<KeyValuePair<string, object>> kvpc)
		{
			foreach (KeyValuePair<string, object> keyValuePair in kvpc)
			{
				yield return new KeyValuePair<string, JsonValue>(keyValuePair.Key, JsonValue.ToJsonValue<object>(keyValuePair.Value));
			}
			IEnumerator<KeyValuePair<string, object>> enumerator = null;
			yield break;
			yield break;
		}

		// Token: 0x060001A4 RID: 420 RVA: 0x00005141 File Offset: 0x00003341
		private static IEnumerable<JsonValue> ToJsonValueEnumerable(IEnumerable arr)
		{
			foreach (object ret in arr)
			{
				yield return JsonValue.ToJsonValue<object>(ret);
			}
			IEnumerator enumerator = null;
			yield break;
			yield break;
		}

		// Token: 0x060001A5 RID: 421 RVA: 0x0000E184 File Offset: 0x0000C384
		public static JsonValue ToJsonValue<T>(T ret)
		{
			if (ret == null)
			{
				return null;
			}
			T t;
			if ((t = ret) is bool)
			{
				return new JsonPrimitive((bool)((object)t));
			}
			if ((t = ret) is byte)
			{
				return new JsonPrimitive((byte)((object)t));
			}
			if ((t = ret) is char)
			{
				return new JsonPrimitive((char)((object)t));
			}
			if ((t = ret) is decimal)
			{
				return new JsonPrimitive((decimal)((object)t));
			}
			if ((t = ret) is double)
			{
				return new JsonPrimitive((double)((object)t));
			}
			if ((t = ret) is float)
			{
				return new JsonPrimitive((float)((object)t));
			}
			if ((t = ret) is int)
			{
				return new JsonPrimitive((int)((object)t));
			}
			if ((t = ret) is long)
			{
				return new JsonPrimitive((long)((object)t));
			}
			if ((t = ret) is sbyte)
			{
				return new JsonPrimitive((sbyte)((object)t));
			}
			if ((t = ret) is short)
			{
				return new JsonPrimitive((short)((object)t));
			}
			string value;
			if ((value = (ret as string)) != null)
			{
				return new JsonPrimitive(value);
			}
			if ((t = ret) is uint)
			{
				return new JsonPrimitive((uint)((object)t));
			}
			if ((t = ret) is ulong)
			{
				return new JsonPrimitive((ulong)((object)t));
			}
			if ((t = ret) is ushort)
			{
				return new JsonPrimitive((ushort)((object)t));
			}
			if ((t = ret) is DateTime)
			{
				return new JsonPrimitive((DateTime)((object)t));
			}
			if ((t = ret) is DateTimeOffset)
			{
				return new JsonPrimitive((DateTimeOffset)((object)t));
			}
			if ((t = ret) is Guid)
			{
				return new JsonPrimitive((Guid)((object)t));
			}
			if ((t = ret) is TimeSpan)
			{
				return new JsonPrimitive((TimeSpan)((object)t));
			}
			Uri value2;
			if ((value2 = (ret as Uri)) != null)
			{
				return new JsonPrimitive(value2);
			}
			IEnumerable<KeyValuePair<string, object>> enumerable = ret as IEnumerable<KeyValuePair<string, object>>;
			if (enumerable != null)
			{
				return new JsonObject(JsonValue.ToJsonPairEnumerable(enumerable));
			}
			IEnumerable enumerable2 = ret as IEnumerable;
			if (enumerable2 != null)
			{
				return new JsonArray(JsonValue.ToJsonValueEnumerable(enumerable2));
			}
			if (!(ret is IEnumerable))
			{
				PropertyInfo[] properties = ret.GetType().GetProperties();
				Dictionary<string, object> dictionary = new Dictionary<string, object>();
				foreach (PropertyInfo propertyInfo in properties)
				{
					dictionary.Add(propertyInfo.Name, propertyInfo.GetValue(ret, null).IsNull("null"));
				}
				if (dictionary.Count > 0)
				{
					return new JsonObject(JsonValue.ToJsonPairEnumerable(dictionary));
				}
			}
			throw new NotSupportedException(string.Format("Unexpected parser return type: {0}", ret.GetType()));
		}

		// Token: 0x060001A6 RID: 422 RVA: 0x00005151 File Offset: 0x00003351
		public static JsonValue Parse(string jsonString)
		{
			if (jsonString == null)
			{
				throw new ArgumentNullException("jsonString");
			}
			return JsonValue.Load(new StringReader(jsonString));
		}

		// Token: 0x060001A7 RID: 423 RVA: 0x000050EE File Offset: 0x000032EE
		public virtual bool ContainsKey(string key)
		{
			throw new InvalidOperationException();
		}

		// Token: 0x060001A8 RID: 424 RVA: 0x0000516C File Offset: 0x0000336C
		public virtual void Save(Stream stream, bool parsing)
		{
			if (stream == null)
			{
				throw new ArgumentNullException("stream");
			}
			this.Save(new StreamWriter(stream), parsing);
		}

		// Token: 0x060001A9 RID: 425 RVA: 0x00005189 File Offset: 0x00003389
		public virtual void Save(TextWriter textWriter, bool parsing)
		{
			if (textWriter == null)
			{
				throw new ArgumentNullException("textWriter");
			}
			this.Savepublic(textWriter, parsing);
		}

		// Token: 0x060001AA RID: 426 RVA: 0x0000E4BC File Offset: 0x0000C6BC
		private void Savepublic(TextWriter w, bool saving)
		{
			switch (this.JsonType)
			{
			case JsonType.String:
				if (saving)
				{
					w.Write('"');
				}
				w.Write(this.EscapeString(((JsonPrimitive)this).GetFormattedString()));
				if (saving)
				{
					w.Write('"');
					return;
				}
				return;
			case JsonType.Object:
			{
				w.Write('{');
				bool flag = false;
				foreach (KeyValuePair<string, JsonValue> keyValuePair in ((JsonObject)this))
				{
					if (flag)
					{
						w.Write(", ");
					}
					w.Write('"');
					w.Write(this.EscapeString(keyValuePair.Key));
					w.Write("\": ");
					if (keyValuePair.Value == null)
					{
						w.Write("null");
					}
					else
					{
						keyValuePair.Value.Savepublic(w, saving);
					}
					flag = true;
				}
				w.Write('}');
				return;
			}
			case JsonType.Array:
			{
				w.Write('[');
				bool flag2 = false;
				foreach (JsonValue jsonValue in ((IEnumerable<JsonValue>)((JsonArray)this)))
				{
					if (flag2)
					{
						w.Write(", ");
					}
					if (jsonValue != null)
					{
						jsonValue.Savepublic(w, saving);
					}
					else
					{
						w.Write("null");
					}
					flag2 = true;
				}
				w.Write(']');
				return;
			}
			case JsonType.Boolean:
				w.Write(this ? "true" : "false");
				return;
			}
			w.Write(((JsonPrimitive)this).GetFormattedString());
		}

		// Token: 0x060001AB RID: 427 RVA: 0x0000E66C File Offset: 0x0000C86C
		public string ToString(bool saving = true)
		{
			StringWriter stringWriter = new StringWriter();
			this.Save(stringWriter, saving);
			return stringWriter.ToString();
		}

		// Token: 0x060001AC RID: 428 RVA: 0x000050EE File Offset: 0x000032EE
		IEnumerator IEnumerable.GetEnumerator()
		{
			throw new InvalidOperationException();
		}

		// Token: 0x060001AD RID: 429 RVA: 0x0000E690 File Offset: 0x0000C890
		private bool NeedEscape(string src, int i)
		{
			char c = src[i];
			return c < ' ' || c == '"' || c == '\\' || (c >= '\ud800' && c <= '\udbff' && (i == src.Length - 1 || src[i + 1] < '\udc00' || src[i + 1] > '\udfff')) || (c >= '\udc00' && c <= '\udfff' && (i == 0 || src[i - 1] < '\ud800' || src[i - 1] > '\udbff')) || c == '\u2028' || c == '\u2029' || (c == '/' && i > 0 && src[i - 1] == '<');
		}

		// Token: 0x060001AE RID: 430 RVA: 0x0000E758 File Offset: 0x0000C958
		public string EscapeString(string src)
		{
			if (src == null)
			{
				return null;
			}
			for (int i = 0; i < src.Length; i++)
			{
				if (this.NeedEscape(src, i))
				{
					StringBuilder stringBuilder = new StringBuilder();
					if (i > 0)
					{
						stringBuilder.Append(src, 0, i);
					}
					return this.DoEscapeString(stringBuilder, src, i);
				}
			}
			return src;
		}

		// Token: 0x060001AF RID: 431 RVA: 0x0000E7A4 File Offset: 0x0000C9A4
		private string DoEscapeString(StringBuilder sb, string src, int cur)
		{
			int num = cur;
			for (int i = cur; i < src.Length; i++)
			{
				if (this.NeedEscape(src, i))
				{
					sb.Append(src, num, i - num);
					char c = src[i];
					if (c <= '"')
					{
						switch (c)
						{
						case '\b':
							sb.Append("\\b");
							break;
						case '\t':
							sb.Append("\\t");
							break;
						case '\n':
							sb.Append("\\n");
							break;
						case '\v':
							goto IL_D5;
						case '\f':
							sb.Append("\\f");
							break;
						case '\r':
							sb.Append("\\r");
							break;
						default:
							if (c != '"')
							{
								goto IL_D5;
							}
							sb.Append("\\\"");
							break;
						}
					}
					else if (c != '/')
					{
						if (c != '\\')
						{
							goto IL_D5;
						}
						sb.Append("\\\\");
					}
					else
					{
						sb.Append("\\/");
					}
					IL_FC:
					num = i + 1;
					goto IL_100;
					IL_D5:
					sb.Append("\\u");
					sb.Append(((int)src[i]).ToString("x04"));
					goto IL_FC;
				}
				IL_100:;
			}
			sb.Append(src, num, src.Length - num);
			return sb.ToString();
		}

		// Token: 0x060001B0 RID: 432 RVA: 0x000051A1 File Offset: 0x000033A1
		public static implicit operator JsonValue(bool value)
		{
			return new JsonPrimitive(value);
		}

		// Token: 0x060001B1 RID: 433 RVA: 0x000051A9 File Offset: 0x000033A9
		public static implicit operator JsonValue(byte value)
		{
			return new JsonPrimitive(value);
		}

		// Token: 0x060001B2 RID: 434 RVA: 0x000051B1 File Offset: 0x000033B1
		public static implicit operator JsonValue(char value)
		{
			return new JsonPrimitive(value);
		}

		// Token: 0x060001B3 RID: 435 RVA: 0x000051B9 File Offset: 0x000033B9
		public static implicit operator JsonValue(decimal value)
		{
			return new JsonPrimitive(value);
		}

		// Token: 0x060001B4 RID: 436 RVA: 0x000051C1 File Offset: 0x000033C1
		public static implicit operator JsonValue(double value)
		{
			return new JsonPrimitive(value);
		}

		// Token: 0x060001B5 RID: 437 RVA: 0x000051C9 File Offset: 0x000033C9
		public static implicit operator JsonValue(float value)
		{
			return new JsonPrimitive(value);
		}

		// Token: 0x060001B6 RID: 438 RVA: 0x000051D1 File Offset: 0x000033D1
		public static implicit operator JsonValue(int value)
		{
			return new JsonPrimitive(value);
		}

		// Token: 0x060001B7 RID: 439 RVA: 0x000051D9 File Offset: 0x000033D9
		public static implicit operator JsonValue(long value)
		{
			return new JsonPrimitive(value);
		}

		// Token: 0x060001B8 RID: 440 RVA: 0x000051E1 File Offset: 0x000033E1
		public static implicit operator JsonValue(sbyte value)
		{
			return new JsonPrimitive(value);
		}

		// Token: 0x060001B9 RID: 441 RVA: 0x000051E9 File Offset: 0x000033E9
		public static implicit operator JsonValue(short value)
		{
			return new JsonPrimitive(value);
		}

		// Token: 0x060001BA RID: 442 RVA: 0x000051F1 File Offset: 0x000033F1
		public static implicit operator JsonValue(string value)
		{
			return new JsonPrimitive(value);
		}

		// Token: 0x060001BB RID: 443 RVA: 0x000051F9 File Offset: 0x000033F9
		public static implicit operator JsonValue(uint value)
		{
			return new JsonPrimitive(value);
		}

		// Token: 0x060001BC RID: 444 RVA: 0x00005201 File Offset: 0x00003401
		public static implicit operator JsonValue(ulong value)
		{
			return new JsonPrimitive(value);
		}

		// Token: 0x060001BD RID: 445 RVA: 0x00005209 File Offset: 0x00003409
		public static implicit operator JsonValue(ushort value)
		{
			return new JsonPrimitive(value);
		}

		// Token: 0x060001BE RID: 446 RVA: 0x00005211 File Offset: 0x00003411
		public static implicit operator JsonValue(DateTime value)
		{
			return new JsonPrimitive(value);
		}

		// Token: 0x060001BF RID: 447 RVA: 0x00005219 File Offset: 0x00003419
		public static implicit operator JsonValue(DateTimeOffset value)
		{
			return new JsonPrimitive(value);
		}

		// Token: 0x060001C0 RID: 448 RVA: 0x00005221 File Offset: 0x00003421
		public static implicit operator JsonValue(Guid value)
		{
			return new JsonPrimitive(value);
		}

		// Token: 0x060001C1 RID: 449 RVA: 0x00005229 File Offset: 0x00003429
		public static implicit operator JsonValue(TimeSpan value)
		{
			return new JsonPrimitive(value);
		}

		// Token: 0x060001C2 RID: 450 RVA: 0x00005231 File Offset: 0x00003431
		public static implicit operator JsonValue(Uri value)
		{
			return new JsonPrimitive(value);
		}

		// Token: 0x060001C3 RID: 451 RVA: 0x00005239 File Offset: 0x00003439
		public static implicit operator bool(JsonValue value)
		{
			if (value == null)
			{
				throw new ArgumentNullException("value");
			}
			return Convert.ToBoolean(((JsonPrimitive)value).Value, NumberFormatInfo.InvariantInfo);
		}

		// Token: 0x060001C4 RID: 452 RVA: 0x0000525E File Offset: 0x0000345E
		public static implicit operator byte(JsonValue value)
		{
			if (value == null)
			{
				throw new ArgumentNullException("value");
			}
			return Convert.ToByte(((JsonPrimitive)value).Value, NumberFormatInfo.InvariantInfo);
		}

		// Token: 0x060001C5 RID: 453 RVA: 0x00005283 File Offset: 0x00003483
		public static implicit operator char(JsonValue value)
		{
			if (value == null)
			{
				throw new ArgumentNullException("value");
			}
			return Convert.ToChar(((JsonPrimitive)value).Value, NumberFormatInfo.InvariantInfo);
		}

		// Token: 0x060001C6 RID: 454 RVA: 0x000052A8 File Offset: 0x000034A8
		public static implicit operator decimal(JsonValue value)
		{
			if (value == null)
			{
				throw new ArgumentNullException("value");
			}
			return Convert.ToDecimal(((JsonPrimitive)value).Value, NumberFormatInfo.InvariantInfo);
		}

		// Token: 0x060001C7 RID: 455 RVA: 0x000052CD File Offset: 0x000034CD
		public static implicit operator double(JsonValue value)
		{
			if (value == null)
			{
				throw new ArgumentNullException("value");
			}
			return Convert.ToDouble(((JsonPrimitive)value).Value, NumberFormatInfo.InvariantInfo);
		}

		// Token: 0x060001C8 RID: 456 RVA: 0x000052F2 File Offset: 0x000034F2
		public static implicit operator float(JsonValue value)
		{
			if (value == null)
			{
				throw new ArgumentNullException("value");
			}
			return Convert.ToSingle(((JsonPrimitive)value).Value, NumberFormatInfo.InvariantInfo);
		}

		// Token: 0x060001C9 RID: 457 RVA: 0x00005317 File Offset: 0x00003517
		public static implicit operator int(JsonValue value)
		{
			if (value == null)
			{
				throw new ArgumentNullException("value");
			}
			return Convert.ToInt32(((JsonPrimitive)value).Value, NumberFormatInfo.InvariantInfo);
		}

		// Token: 0x060001CA RID: 458 RVA: 0x0000533C File Offset: 0x0000353C
		public static implicit operator long(JsonValue value)
		{
			if (value == null)
			{
				throw new ArgumentNullException("value");
			}
			return Convert.ToInt64(((JsonPrimitive)value).Value, NumberFormatInfo.InvariantInfo);
		}

		// Token: 0x060001CB RID: 459 RVA: 0x00005361 File Offset: 0x00003561
		public static implicit operator sbyte(JsonValue value)
		{
			if (value == null)
			{
				throw new ArgumentNullException("value");
			}
			return Convert.ToSByte(((JsonPrimitive)value).Value, NumberFormatInfo.InvariantInfo);
		}

		// Token: 0x060001CC RID: 460 RVA: 0x00005386 File Offset: 0x00003586
		public static implicit operator short(JsonValue value)
		{
			if (value == null)
			{
				throw new ArgumentNullException("value");
			}
			return Convert.ToInt16(((JsonPrimitive)value).Value, NumberFormatInfo.InvariantInfo);
		}

		// Token: 0x060001CD RID: 461 RVA: 0x000053AB File Offset: 0x000035AB
		public static implicit operator string(JsonValue value)
		{
			if (value == null)
			{
				return null;
			}
			return value.ToString(true);
		}

		// Token: 0x060001CE RID: 462 RVA: 0x000053B9 File Offset: 0x000035B9
		public static implicit operator uint(JsonValue value)
		{
			if (value == null)
			{
				throw new ArgumentNullException("value");
			}
			return Convert.ToUInt32(((JsonPrimitive)value).Value, NumberFormatInfo.InvariantInfo);
		}

		// Token: 0x060001CF RID: 463 RVA: 0x000053DE File Offset: 0x000035DE
		public static implicit operator ulong(JsonValue value)
		{
			if (value == null)
			{
				throw new ArgumentNullException("value");
			}
			return Convert.ToUInt64(((JsonPrimitive)value).Value, NumberFormatInfo.InvariantInfo);
		}

		// Token: 0x060001D0 RID: 464 RVA: 0x00005403 File Offset: 0x00003603
		public static implicit operator ushort(JsonValue value)
		{
			if (value == null)
			{
				throw new ArgumentNullException("value");
			}
			return Convert.ToUInt16(((JsonPrimitive)value).Value, NumberFormatInfo.InvariantInfo);
		}

		// Token: 0x060001D1 RID: 465 RVA: 0x00005428 File Offset: 0x00003628
		public static implicit operator DateTime(JsonValue value)
		{
			if (value == null)
			{
				throw new ArgumentNullException("value");
			}
			return (DateTime)((JsonPrimitive)value).Value;
		}

		// Token: 0x060001D2 RID: 466 RVA: 0x00005448 File Offset: 0x00003648
		public static implicit operator DateTimeOffset(JsonValue value)
		{
			if (value == null)
			{
				throw new ArgumentNullException("value");
			}
			return (DateTimeOffset)((JsonPrimitive)value).Value;
		}

		// Token: 0x060001D3 RID: 467 RVA: 0x00005468 File Offset: 0x00003668
		public static implicit operator TimeSpan(JsonValue value)
		{
			if (value == null)
			{
				throw new ArgumentNullException("value");
			}
			return (TimeSpan)((JsonPrimitive)value).Value;
		}

		// Token: 0x060001D4 RID: 468 RVA: 0x00005488 File Offset: 0x00003688
		public static implicit operator Guid(JsonValue value)
		{
			if (value == null)
			{
				throw new ArgumentNullException("value");
			}
			return (Guid)((JsonPrimitive)value).Value;
		}

		// Token: 0x060001D5 RID: 469 RVA: 0x000054A8 File Offset: 0x000036A8
		public static implicit operator Uri(JsonValue value)
		{
			if (value == null)
			{
				throw new ArgumentNullException("value");
			}
			return (Uri)((JsonPrimitive)value).Value;
		}
	}
}
