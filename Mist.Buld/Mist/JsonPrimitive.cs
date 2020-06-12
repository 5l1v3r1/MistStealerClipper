using System;
using System.Globalization;
using System.IO;
using System.Text;

namespace Mist
{
	// Token: 0x02000040 RID: 64
	public class JsonPrimitive : JsonValue
	{
		// Token: 0x17000047 RID: 71
		// (get) Token: 0x06000182 RID: 386 RVA: 0x00004F59 File Offset: 0x00003159
		public object Value
		{
			get
			{
				return this.value;
			}
		}

		// Token: 0x17000048 RID: 72
		// (get) Token: 0x06000183 RID: 387 RVA: 0x0000DF64 File Offset: 0x0000C164
		public override JsonType JsonType
		{
			get
			{
				if (this.value == null)
				{
					return JsonType.String;
				}
				TypeCode typeCode = Type.GetTypeCode(this.value.GetType());
				switch (typeCode)
				{
				case TypeCode.Object:
				case TypeCode.Char:
					break;
				case TypeCode.DBNull:
					return JsonType.Number;
				case TypeCode.Boolean:
					return JsonType.Boolean;
				default:
					if (typeCode != TypeCode.DateTime && typeCode != TypeCode.String)
					{
						return JsonType.Number;
					}
					break;
				}
				return JsonType.String;
			}
		}

		// Token: 0x06000184 RID: 388 RVA: 0x00004F61 File Offset: 0x00003161
		public JsonPrimitive(bool value)
		{
			this.value = value;
		}

		// Token: 0x06000185 RID: 389 RVA: 0x00004F75 File Offset: 0x00003175
		public JsonPrimitive(byte value)
		{
			this.value = value;
		}

		// Token: 0x06000186 RID: 390 RVA: 0x00004F89 File Offset: 0x00003189
		public JsonPrimitive(char value)
		{
			this.value = value;
		}

		// Token: 0x06000187 RID: 391 RVA: 0x00004F9D File Offset: 0x0000319D
		public JsonPrimitive(decimal value)
		{
			this.value = value;
		}

		// Token: 0x06000188 RID: 392 RVA: 0x00004FB1 File Offset: 0x000031B1
		public JsonPrimitive(double value)
		{
			this.value = value;
		}

		// Token: 0x06000189 RID: 393 RVA: 0x00004FC5 File Offset: 0x000031C5
		public JsonPrimitive(float value)
		{
			this.value = value;
		}

		// Token: 0x0600018A RID: 394 RVA: 0x00004FD9 File Offset: 0x000031D9
		public JsonPrimitive(int value)
		{
			this.value = value;
		}

		// Token: 0x0600018B RID: 395 RVA: 0x00004FED File Offset: 0x000031ED
		public JsonPrimitive(long value)
		{
			this.value = value;
		}

		// Token: 0x0600018C RID: 396 RVA: 0x00005001 File Offset: 0x00003201
		public JsonPrimitive(sbyte value)
		{
			this.value = value;
		}

		// Token: 0x0600018D RID: 397 RVA: 0x00005015 File Offset: 0x00003215
		public JsonPrimitive(short value)
		{
			this.value = value;
		}

		// Token: 0x0600018E RID: 398 RVA: 0x00005029 File Offset: 0x00003229
		public JsonPrimitive(string value)
		{
			this.value = value;
		}

		// Token: 0x0600018F RID: 399 RVA: 0x00005038 File Offset: 0x00003238
		public JsonPrimitive(DateTime value)
		{
			this.value = value;
		}

		// Token: 0x06000190 RID: 400 RVA: 0x0000504C File Offset: 0x0000324C
		public JsonPrimitive(uint value)
		{
			this.value = value;
		}

		// Token: 0x06000191 RID: 401 RVA: 0x00005060 File Offset: 0x00003260
		public JsonPrimitive(ulong value)
		{
			this.value = value;
		}

		// Token: 0x06000192 RID: 402 RVA: 0x00005074 File Offset: 0x00003274
		public JsonPrimitive(ushort value)
		{
			this.value = value;
		}

		// Token: 0x06000193 RID: 403 RVA: 0x00005088 File Offset: 0x00003288
		public JsonPrimitive(DateTimeOffset value)
		{
			this.value = value;
		}

		// Token: 0x06000194 RID: 404 RVA: 0x0000509C File Offset: 0x0000329C
		public JsonPrimitive(Guid value)
		{
			this.value = value;
		}

		// Token: 0x06000195 RID: 405 RVA: 0x000050B0 File Offset: 0x000032B0
		public JsonPrimitive(TimeSpan value)
		{
			this.value = value;
		}

		// Token: 0x06000196 RID: 406 RVA: 0x00005029 File Offset: 0x00003229
		public JsonPrimitive(Uri value)
		{
			this.value = value;
		}

		// Token: 0x06000197 RID: 407 RVA: 0x00005029 File Offset: 0x00003229
		public JsonPrimitive(object value)
		{
			this.value = value;
		}

		// Token: 0x06000198 RID: 408 RVA: 0x0000DFB8 File Offset: 0x0000C1B8
		public override void Save(Stream stream, bool parsing)
		{
			JsonType jsonType = this.JsonType;
			if (jsonType == JsonType.String)
			{
				stream.WriteByte(34);
				byte[] bytes = Encoding.UTF8.GetBytes(base.EscapeString(this.value.ToString()));
				stream.Write(bytes, 0, bytes.Length);
				stream.WriteByte(34);
				return;
			}
			if (jsonType != JsonType.Boolean)
			{
				byte[] bytes2 = Encoding.UTF8.GetBytes(this.GetFormattedString());
				stream.Write(bytes2, 0, bytes2.Length);
				return;
			}
			if ((bool)this.value)
			{
				stream.Write(JsonPrimitive.true_bytes, 0, 4);
				return;
			}
			stream.Write(JsonPrimitive.false_bytes, 0, 5);
		}

		// Token: 0x06000199 RID: 409 RVA: 0x0000E050 File Offset: 0x0000C250
		public string GetFormattedString()
		{
			JsonType jsonType = this.JsonType;
			if (jsonType != JsonType.String)
			{
				if (jsonType != JsonType.Number)
				{
					throw new InvalidOperationException();
				}
				string text = (!(this.value is float) && !(this.value is double)) ? ((IFormattable)this.value).ToString("G", NumberFormatInfo.InvariantInfo) : ((IFormattable)this.value).ToString("R", NumberFormatInfo.InvariantInfo);
				if (text == "NaN" || text == "Infinity" || text == "-Infinity")
				{
					return "\"" + text + "\"";
				}
				return text;
			}
			else if (this.value is string || this.value == null)
			{
				string text2 = this.value as string;
				if (string.IsNullOrEmpty(text2))
				{
					return "null";
				}
				return text2.Trim(new char[]
				{
					'"'
				});
			}
			else
			{
				if (this.value is char)
				{
					return this.value.ToString();
				}
				string str = "GetFormattedString from value type ";
				Type type = this.value.GetType();
				throw new NotImplementedException(str + ((type != null) ? type.ToString() : null));
			}
		}

		// Token: 0x040000ED RID: 237
		private object value;

		// Token: 0x040000EE RID: 238
		private static readonly byte[] true_bytes = Encoding.UTF8.GetBytes("true");

		// Token: 0x040000EF RID: 239
		private static readonly byte[] false_bytes = Encoding.UTF8.GetBytes("false");
	}
}
