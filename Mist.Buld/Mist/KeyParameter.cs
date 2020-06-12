using System;

namespace Mist
{
	// Token: 0x02000014 RID: 20
	public class KeyParameter : ICipherParameters
	{
		// Token: 0x0600005F RID: 95 RVA: 0x00004580 File Offset: 0x00002780
		public KeyParameter(byte[] key)
		{
			if (key == null)
			{
				throw new ArgumentNullException("key");
			}
			this.key = (byte[])key.Clone();
		}

		// Token: 0x06000060 RID: 96 RVA: 0x00008960 File Offset: 0x00006B60
		public KeyParameter(byte[] key, int keyOff, int keyLen)
		{
			if (key == null)
			{
				throw new ArgumentNullException("key");
			}
			if (keyOff < 0 || keyOff > key.Length)
			{
				throw new ArgumentOutOfRangeException("keyOff");
			}
			if (keyLen < 0 || keyOff + keyLen > key.Length)
			{
				throw new ArgumentOutOfRangeException("keyLen");
			}
			this.key = new byte[keyLen];
			Array.Copy(key, keyOff, this.key, 0, keyLen);
		}

		// Token: 0x06000061 RID: 97 RVA: 0x000045A7 File Offset: 0x000027A7
		public byte[] GetKey()
		{
			return (byte[])this.key.Clone();
		}

		// Token: 0x0400003E RID: 62
		private readonly byte[] key;
	}
}
