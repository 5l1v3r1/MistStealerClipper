using System;

namespace Mist
{
	// Token: 0x0200001F RID: 31
	public class InvalidCipherTextException : CryptoException
	{
		// Token: 0x060000AC RID: 172 RVA: 0x00004798 File Offset: 0x00002998
		public InvalidCipherTextException()
		{
		}

		// Token: 0x060000AD RID: 173 RVA: 0x000047A0 File Offset: 0x000029A0
		public InvalidCipherTextException(string message) : base(message)
		{
		}

		// Token: 0x060000AE RID: 174 RVA: 0x000047A9 File Offset: 0x000029A9
		public InvalidCipherTextException(string message, Exception exception) : base(message, exception)
		{
		}
	}
}
