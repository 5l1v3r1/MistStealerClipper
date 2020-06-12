using System;
using System.Collections.Generic;
using System.Text;

namespace Mist
{
	// Token: 0x02000033 RID: 51
	public class Gecko4
	{
		// Token: 0x17000013 RID: 19
		// (get) Token: 0x060000E3 RID: 227 RVA: 0x00004885 File Offset: 0x00002A85
		// (set) Token: 0x060000E4 RID: 228 RVA: 0x0000488D File Offset: 0x00002A8D
		public Gecko2 ObjectType { get; set; }

		// Token: 0x17000014 RID: 20
		// (get) Token: 0x060000E5 RID: 229 RVA: 0x00004896 File Offset: 0x00002A96
		// (set) Token: 0x060000E6 RID: 230 RVA: 0x0000489E File Offset: 0x00002A9E
		public byte[] ObjectData { get; set; }

		// Token: 0x17000015 RID: 21
		// (get) Token: 0x060000E7 RID: 231 RVA: 0x000048A7 File Offset: 0x00002AA7
		// (set) Token: 0x060000E8 RID: 232 RVA: 0x000048AF File Offset: 0x00002AAF
		public int ObjectLength { get; set; }

		// Token: 0x17000016 RID: 22
		// (get) Token: 0x060000E9 RID: 233 RVA: 0x000048B8 File Offset: 0x00002AB8
		// (set) Token: 0x060000EA RID: 234 RVA: 0x000048C0 File Offset: 0x00002AC0
		public List<Gecko4> Objects { get; set; }

		// Token: 0x060000EB RID: 235 RVA: 0x000048C9 File Offset: 0x00002AC9
		public Gecko4()
		{
			this.Objects = new List<Gecko4>();
		}

		// Token: 0x060000EC RID: 236 RVA: 0x0000BD20 File Offset: 0x00009F20
		public override string ToString()
		{
			StringBuilder stringBuilder = new StringBuilder();
			StringBuilder stringBuilder2 = new StringBuilder();
			Gecko2 objectType = this.ObjectType;
			switch (objectType)
			{
			case Gecko2.Integer:
				foreach (byte b in this.ObjectData)
				{
					stringBuilder2.AppendFormat("{0:X2}", b);
				}
				stringBuilder.Append("\tINTEGER ").Append(stringBuilder2).AppendLine();
				break;
			case Gecko2.BitString:
			case Gecko2.Null:
				break;
			case Gecko2.OctetString:
				foreach (byte b2 in this.ObjectData)
				{
					stringBuilder2.AppendFormat("{0:X2}", b2);
				}
				stringBuilder.Append("\tOCTETSTRING ").AppendLine(stringBuilder2.ToString());
				break;
			case Gecko2.ObjectIdentifier:
				foreach (byte b3 in this.ObjectData)
				{
					stringBuilder2.AppendFormat("{0:X2}", b3);
				}
				stringBuilder.Append("\tOBJECTIDENTIFIER ").AppendLine(stringBuilder2.ToString());
				break;
			default:
				if (objectType == Gecko2.Sequence)
				{
					stringBuilder.AppendLine("SEQUENCE {");
				}
				break;
			}
			foreach (Gecko4 gecko in this.Objects)
			{
				stringBuilder.Append(gecko.ToString());
			}
			if (this.ObjectType == Gecko2.Sequence)
			{
				stringBuilder.AppendLine("}");
			}
			stringBuilder2.Remove(0, stringBuilder2.Length - 1);
			return stringBuilder.ToString();
		}
	}
}
