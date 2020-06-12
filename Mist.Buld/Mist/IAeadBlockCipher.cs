using System;

namespace Mist
{
	// Token: 0x02000019 RID: 25
	public interface IAeadBlockCipher
	{
		// Token: 0x17000008 RID: 8
		// (get) Token: 0x06000085 RID: 133
		string AlgorithmName { get; }

		// Token: 0x06000086 RID: 134
		void Init(bool forEncryption, ICipherParameters parameters);

		// Token: 0x06000087 RID: 135
		int GetBlockSize();

		// Token: 0x06000088 RID: 136
		int ProcessByte(byte input, byte[] outBytes, int outOff);

		// Token: 0x06000089 RID: 137
		int ProcessBytes(byte[] inBytes, int inOff, int len, byte[] outBytes, int outOff);

		// Token: 0x0600008A RID: 138
		int DoFinal(byte[] outBytes, int outOff);

		// Token: 0x0600008B RID: 139
		byte[] GetMac();

		// Token: 0x0600008C RID: 140
		int GetUpdateOutputSize(int len);

		// Token: 0x0600008D RID: 141
		int GetOutputSize(int len);

		// Token: 0x0600008E RID: 142
		void Reset();
	}
}
