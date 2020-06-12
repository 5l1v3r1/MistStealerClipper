using System;

namespace Mist
{
	// Token: 0x0200001D RID: 29
	public interface IBlockCipher
	{
		// Token: 0x1700000B RID: 11
		// (get) Token: 0x060000A6 RID: 166
		string AlgorithmName { get; }

		// Token: 0x1700000C RID: 12
		// (get) Token: 0x060000A7 RID: 167
		bool IsPartialBlockOkay { get; }

		// Token: 0x060000A8 RID: 168
		void Init(bool forEncryption, ICipherParameters parameters);

		// Token: 0x060000A9 RID: 169
		int GetBlockSize();

		// Token: 0x060000AA RID: 170
		int ProcessBlock(byte[] inBuf, int inOff, byte[] outBuf, int outOff);

		// Token: 0x060000AB RID: 171
		void Reset();
	}
}
