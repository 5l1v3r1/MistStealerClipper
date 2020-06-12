using System;

namespace Mist
{
	// Token: 0x02000016 RID: 22
	public interface IGcmMultiplier
	{
		// Token: 0x0600006E RID: 110
		void Init(byte[] H);

		// Token: 0x0600006F RID: 111
		void MultiplyH(byte[] x);
	}
}
