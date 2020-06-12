using System;

namespace Mist
{
	// Token: 0x0200005D RID: 93
	public static class Index
	{
		// Token: 0x0200005E RID: 94
		public enum KeyIndexWin
		{
			// Token: 0x04000147 RID: 327
			KEY_START_INDEX = 52,
			// Token: 0x04000148 RID: 328
			KEY_END_INDEX = 67,
			// Token: 0x04000149 RID: 329
			DECODE_LENGTH = 29,
			// Token: 0x0400014A RID: 330
			DECODE_STRING = 15
		}

		// Token: 0x0200005F RID: 95
		public enum Type
		{
			// Token: 0x0400014C RID: 332
			Sequence = 48,
			// Token: 0x0400014D RID: 333
			Integer = 2,
			// Token: 0x0400014E RID: 334
			BitString,
			// Token: 0x0400014F RID: 335
			OctetString,
			// Token: 0x04000150 RID: 336
			Null,
			// Token: 0x04000151 RID: 337
			ObjectIdentifier
		}
	}
}
