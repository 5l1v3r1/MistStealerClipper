using System;

namespace Mist
{
	// Token: 0x02000021 RID: 33
	public class AeadParameters : ICipherParameters
	{
		// Token: 0x1700000D RID: 13
		// (get) Token: 0x060000B0 RID: 176 RVA: 0x000047B3 File Offset: 0x000029B3
		public virtual KeyParameter Key
		{
			get
			{
				return this.key;
			}
		}

		// Token: 0x1700000E RID: 14
		// (get) Token: 0x060000B1 RID: 177 RVA: 0x000047BB File Offset: 0x000029BB
		public virtual int MacSize
		{
			get
			{
				return this.macSize;
			}
		}

		// Token: 0x060000B2 RID: 178 RVA: 0x000047C3 File Offset: 0x000029C3
		public AeadParameters(KeyParameter key, int macSize, byte[] nonce, byte[] associatedText)
		{
			this.key = key;
			this.nonce = nonce;
			this.macSize = macSize;
			this.associatedText = associatedText;
		}

		// Token: 0x060000B3 RID: 179 RVA: 0x000047E8 File Offset: 0x000029E8
		public virtual byte[] GetAssociatedText()
		{
			return this.associatedText;
		}

		// Token: 0x060000B4 RID: 180 RVA: 0x000047F0 File Offset: 0x000029F0
		public virtual byte[] GetNonce()
		{
			return this.nonce;
		}

		// Token: 0x04000068 RID: 104
		private readonly byte[] associatedText;

		// Token: 0x04000069 RID: 105
		private readonly byte[] nonce;

		// Token: 0x0400006A RID: 106
		private readonly KeyParameter key;

		// Token: 0x0400006B RID: 107
		private readonly int macSize;
	}
}
