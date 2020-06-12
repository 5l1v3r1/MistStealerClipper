using System;

namespace Mist
{
	// Token: 0x02000018 RID: 24
	public class GcmBlockCipher : IAeadBlockCipher
	{
		// Token: 0x17000007 RID: 7
		// (get) Token: 0x06000073 RID: 115 RVA: 0x00004642 File Offset: 0x00002842
		public virtual string AlgorithmName
		{
			get
			{
				return this.cipher.AlgorithmName + "/GCM";
			}
		}

		// Token: 0x06000074 RID: 116 RVA: 0x00004659 File Offset: 0x00002859
		public GcmBlockCipher(IBlockCipher c) : this(c, null)
		{
		}

		// Token: 0x06000075 RID: 117 RVA: 0x00008E1C File Offset: 0x0000701C
		public GcmBlockCipher(IBlockCipher c, IGcmMultiplier m)
		{
			if (c.GetBlockSize() != 16)
			{
				throw new ArgumentException("cipher required with a block size of " + 16.ToString() + ".");
			}
			if (m == null)
			{
				m = new Tables8kGcmMultiplier();
			}
			this.cipher = c;
			this.multiplier = m;
		}

		// Token: 0x06000076 RID: 118 RVA: 0x00004663 File Offset: 0x00002863
		public virtual int GetBlockSize()
		{
			return 16;
		}

		// Token: 0x06000077 RID: 119 RVA: 0x00008E70 File Offset: 0x00007070
		public virtual void Init(bool forEncryption, ICipherParameters parameters)
		{
			this.forEncryption = forEncryption;
			this.macBlock = null;
			if (parameters is AeadParameters)
			{
				AeadParameters aeadParameters = (AeadParameters)parameters;
				this.nonce = aeadParameters.GetNonce();
				this.A = aeadParameters.GetAssociatedText();
				int num = aeadParameters.MacSize;
				if (num < 96 || num > 128 || num % 8 != 0)
				{
					throw new ArgumentException("Invalid value for MAC size: " + num.ToString());
				}
				this.macSize = num / 8;
				this.keyParam = aeadParameters.Key;
			}
			else
			{
				if (!(parameters is ParametersWithIV))
				{
					throw new ArgumentException("invalid parameters passed to GCM");
				}
				ParametersWithIV parametersWithIV = (ParametersWithIV)parameters;
				this.nonce = parametersWithIV.GetIV();
				this.A = null;
				this.macSize = 16;
				this.keyParam = (KeyParameter)parametersWithIV.Parameters;
			}
			int num2 = forEncryption ? 16 : (16 + this.macSize);
			this.bufBlock = new byte[num2];
			if (this.nonce == null || this.nonce.Length < 1)
			{
				throw new ArgumentException("IV must be at least 1 byte");
			}
			if (this.A == null)
			{
				this.A = new byte[0];
			}
			this.cipher.Init(true, this.keyParam);
			this.H = new byte[16];
			this.cipher.ProcessBlock(this.H, 0, this.H, 0);
			this.multiplier.Init(this.H);
			this.initS = this.gHASH(this.A);
			if (this.nonce.Length == 12)
			{
				this.J0 = new byte[16];
				Array.Copy(this.nonce, 0, this.J0, 0, this.nonce.Length);
				this.J0[15] = 1;
			}
			else
			{
				this.J0 = this.gHASH(this.nonce);
				byte[] array = new byte[16];
				GcmBlockCipher.packLength((ulong)((long)this.nonce.Length * 8L), array, 8);
				GcmUtilities.Xor(this.J0, array);
				this.multiplier.MultiplyH(this.J0);
			}
			this.S = Arrays.Clone(this.initS);
			this.counter = Arrays.Clone(this.J0);
			this.bufOff = 0;
			this.totalLength = 0UL;
		}

		// Token: 0x06000078 RID: 120 RVA: 0x00004667 File Offset: 0x00002867
		public virtual byte[] GetMac()
		{
			return Arrays.Clone(this.macBlock);
		}

		// Token: 0x06000079 RID: 121 RVA: 0x00004674 File Offset: 0x00002874
		public virtual int GetOutputSize(int len)
		{
			if (this.forEncryption)
			{
				return len + this.bufOff + this.macSize;
			}
			return len + this.bufOff - this.macSize;
		}

		// Token: 0x0600007A RID: 122 RVA: 0x0000469D File Offset: 0x0000289D
		public virtual int GetUpdateOutputSize(int len)
		{
			return (len + this.bufOff) / 16 * 16;
		}

		// Token: 0x0600007B RID: 123 RVA: 0x000046AD File Offset: 0x000028AD
		public virtual int ProcessByte(byte input, byte[] output, int outOff)
		{
			return this.Process(input, output, outOff);
		}

		// Token: 0x0600007C RID: 124 RVA: 0x000090A8 File Offset: 0x000072A8
		public virtual int ProcessBytes(byte[] input, int inOff, int len, byte[] output, int outOff)
		{
			int num = 0;
			for (int num2 = 0; num2 != len; num2++)
			{
				byte[] array = this.bufBlock;
				int num3 = this.bufOff;
				this.bufOff = num3 + 1;
				array[num3] = input[inOff + num2];
				if (this.bufOff == this.bufBlock.Length)
				{
					this.gCTRBlock(this.bufBlock, 16, output, outOff + num);
					if (!this.forEncryption)
					{
						Array.Copy(this.bufBlock, 16, this.bufBlock, 0, this.macSize);
					}
					this.bufOff = this.bufBlock.Length - 16;
					num += 16;
				}
			}
			return num;
		}

		// Token: 0x0600007D RID: 125 RVA: 0x00009140 File Offset: 0x00007340
		private int Process(byte input, byte[] output, int outOff)
		{
			byte[] array = this.bufBlock;
			int num = this.bufOff;
			this.bufOff = num + 1;
			array[num] = input;
			if (this.bufOff == this.bufBlock.Length)
			{
				this.gCTRBlock(this.bufBlock, 16, output, outOff);
				if (!this.forEncryption)
				{
					Array.Copy(this.bufBlock, 16, this.bufBlock, 0, this.macSize);
				}
				this.bufOff = this.bufBlock.Length - 16;
				return 16;
			}
			return 0;
		}

		// Token: 0x0600007E RID: 126 RVA: 0x000091C0 File Offset: 0x000073C0
		public int DoFinal(byte[] output, int outOff)
		{
			int num = this.bufOff;
			if (!this.forEncryption)
			{
				if (num < this.macSize)
				{
					throw new InvalidCipherTextException("data too short");
				}
				num -= this.macSize;
			}
			if (num > 0)
			{
				byte[] array = new byte[16];
				Array.Copy(this.bufBlock, 0, array, 0, num);
				this.gCTRBlock(array, num, output, outOff);
			}
			byte[] array2 = new byte[16];
			GcmBlockCipher.packLength((ulong)((long)this.A.Length * 8L), array2, 0);
			GcmBlockCipher.packLength(this.totalLength * 8UL, array2, 8);
			GcmUtilities.Xor(this.S, array2);
			this.multiplier.MultiplyH(this.S);
			byte[] array3 = new byte[16];
			this.cipher.ProcessBlock(this.J0, 0, array3, 0);
			GcmUtilities.Xor(array3, this.S);
			int num2 = num;
			this.macBlock = new byte[this.macSize];
			Array.Copy(array3, 0, this.macBlock, 0, this.macSize);
			if (this.forEncryption)
			{
				Array.Copy(this.macBlock, 0, output, outOff + this.bufOff, this.macSize);
				num2 += this.macSize;
			}
			else
			{
				byte[] array4 = new byte[this.macSize];
				Array.Copy(this.bufBlock, num, array4, 0, this.macSize);
				if (!Arrays.ConstantTimeAreEqual(this.macBlock, array4))
				{
					throw new InvalidCipherTextException("mac check in GCM failed");
				}
			}
			this.Reset(false);
			return num2;
		}

		// Token: 0x0600007F RID: 127 RVA: 0x000046B8 File Offset: 0x000028B8
		public virtual void Reset()
		{
			this.Reset(true);
		}

		// Token: 0x06000080 RID: 128 RVA: 0x0000932C File Offset: 0x0000752C
		private void Reset(bool clearMac)
		{
			this.S = Arrays.Clone(this.initS);
			this.counter = Arrays.Clone(this.J0);
			this.bufOff = 0;
			this.totalLength = 0UL;
			if (this.bufBlock != null)
			{
				Array.Clear(this.bufBlock, 0, this.bufBlock.Length);
			}
			if (clearMac)
			{
				this.macBlock = null;
			}
			this.cipher.Reset();
		}

		// Token: 0x06000081 RID: 129 RVA: 0x0000939C File Offset: 0x0000759C
		private void gCTRBlock(byte[] buf, int bufCount, byte[] output, int outOff)
		{
			for (int i = 15; i >= 12; i--)
			{
				byte[] array = this.counter;
				int num = i;
				byte b = array[num] + 1;
				array[num] = b;
				if (b != 0)
				{
					break;
				}
			}
			byte[] array2 = new byte[16];
			this.cipher.ProcessBlock(this.counter, 0, array2, 0);
			byte[] val;
			if (this.forEncryption)
			{
				Array.Copy(GcmBlockCipher.Zeroes, bufCount, array2, bufCount, 16 - bufCount);
				val = array2;
			}
			else
			{
				val = buf;
			}
			for (int j = bufCount - 1; j >= 0; j--)
			{
				byte[] array3 = array2;
				int num2 = j;
				array3[num2] ^= buf[j];
				output[outOff + j] = array2[j];
			}
			GcmUtilities.Xor(this.S, val);
			this.multiplier.MultiplyH(this.S);
			this.totalLength += (ulong)((long)bufCount);
		}

		// Token: 0x06000082 RID: 130 RVA: 0x00009464 File Offset: 0x00007664
		private byte[] gHASH(byte[] b)
		{
			byte[] array = new byte[16];
			for (int i = 0; i < b.Length; i += 16)
			{
				byte[] array2 = new byte[16];
				int length = Math.Min(b.Length - i, 16);
				Array.Copy(b, i, array2, 0, length);
				GcmUtilities.Xor(array, array2);
				this.multiplier.MultiplyH(array);
			}
			return array;
		}

		// Token: 0x06000083 RID: 131 RVA: 0x00004484 File Offset: 0x00002684
		private static void packLength(ulong len, byte[] bs, int off)
		{
			Pack.UInt32_To_BE((uint)(len >> 32), bs, off);
			Pack.UInt32_To_BE((uint)len, bs, off + 4);
		}

		// Token: 0x04000040 RID: 64
		private const int BlockSize = 16;

		// Token: 0x04000041 RID: 65
		private static readonly byte[] Zeroes = new byte[16];

		// Token: 0x04000042 RID: 66
		private readonly IBlockCipher cipher;

		// Token: 0x04000043 RID: 67
		private readonly IGcmMultiplier multiplier;

		// Token: 0x04000044 RID: 68
		private bool forEncryption;

		// Token: 0x04000045 RID: 69
		private int macSize;

		// Token: 0x04000046 RID: 70
		private byte[] nonce;

		// Token: 0x04000047 RID: 71
		private byte[] A;

		// Token: 0x04000048 RID: 72
		private KeyParameter keyParam;

		// Token: 0x04000049 RID: 73
		private byte[] H;

		// Token: 0x0400004A RID: 74
		private byte[] initS;

		// Token: 0x0400004B RID: 75
		private byte[] J0;

		// Token: 0x0400004C RID: 76
		private byte[] bufBlock;

		// Token: 0x0400004D RID: 77
		private byte[] macBlock;

		// Token: 0x0400004E RID: 78
		private byte[] S;

		// Token: 0x0400004F RID: 79
		private byte[] counter;

		// Token: 0x04000050 RID: 80
		private int bufOff;

		// Token: 0x04000051 RID: 81
		private ulong totalLength;
	}
}
