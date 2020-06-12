using System;

namespace Mist
{
	// Token: 0x0200001C RID: 28
	public class DataLengthException : CryptoException
	{
		// Token: 0x060000A3 RID: 163 RVA: 0x00004798 File Offset: 0x00002998
		public DataLengthException()
		{
		}

		// Token: 0x060000A4 RID: 164 RVA: 0x000047A0 File Offset: 0x000029A0
		public DataLengthException(string message) : base(message)
		{
		}

		// Token: 0x060000A5 RID: 165 RVA: 0x000047A9 File Offset: 0x000029A9
		public DataLengthException(string message, Exception exception) : base(message, exception)
		{
		}
	}
}
