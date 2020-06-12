using System;

namespace Mist
{
	// Token: 0x0200001B RID: 27
	public class CryptoException : Exception
	{
		// Token: 0x060000A0 RID: 160 RVA: 0x0000477D File Offset: 0x0000297D
		public CryptoException()
		{
		}

		// Token: 0x060000A1 RID: 161 RVA: 0x00004785 File Offset: 0x00002985
		public CryptoException(string message) : base(message)
		{
		}

		// Token: 0x060000A2 RID: 162 RVA: 0x0000478E File Offset: 0x0000298E
		public CryptoException(string message, Exception exception) : base(message, exception)
		{
		}
	}
}
