using System;

namespace Mist
{
	// Token: 0x02000013 RID: 19
	public class ParametersWithIV : ICipherParameters
	{
		// Token: 0x17000006 RID: 6
		// (get) Token: 0x0600005B RID: 91 RVA: 0x00004558 File Offset: 0x00002758
		public ICipherParameters Parameters
		{
			get
			{
				return this.parameters;
			}
		}

		// Token: 0x0600005C RID: 92 RVA: 0x00004560 File Offset: 0x00002760
		public ParametersWithIV(ICipherParameters parameters, byte[] iv) : this(parameters, iv, 0, iv.Length)
		{
		}

		// Token: 0x0600005D RID: 93 RVA: 0x0000890C File Offset: 0x00006B0C
		public ParametersWithIV(ICipherParameters parameters, byte[] iv, int ivOff, int ivLen)
		{
			if (parameters == null)
			{
				throw new ArgumentNullException("parameters");
			}
			if (iv == null)
			{
				throw new ArgumentNullException("iv");
			}
			this.parameters = parameters;
			this.iv = new byte[ivLen];
			Array.Copy(iv, ivOff, this.iv, 0, ivLen);
		}

		// Token: 0x0600005E RID: 94 RVA: 0x0000456E File Offset: 0x0000276E
		public byte[] GetIV()
		{
			return (byte[])this.iv.Clone();
		}

		// Token: 0x0400003C RID: 60
		private readonly ICipherParameters parameters;

		// Token: 0x0400003D RID: 61
		private readonly byte[] iv;
	}
}
