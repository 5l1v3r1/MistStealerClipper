using System;

namespace Mist
{
	// Token: 0x02000015 RID: 21
	internal abstract class GcmUtilities
	{
		// Token: 0x06000062 RID: 98 RVA: 0x000045B9 File Offset: 0x000027B9
		internal static byte[] OneAsBytes()
		{
			byte[] array = new byte[16];
			array[0] = 128;
			return array;
		}

		// Token: 0x06000063 RID: 99 RVA: 0x000045CA File Offset: 0x000027CA
		internal static uint[] OneAsUints()
		{
			uint[] array = new uint[4];
			array[0] = 2147483648U;
			return array;
		}

		// Token: 0x06000064 RID: 100 RVA: 0x000045DA File Offset: 0x000027DA
		internal static uint[] AsUints(byte[] bs)
		{
			return new uint[]
			{
				Pack.BE_To_UInt32(bs, 0),
				Pack.BE_To_UInt32(bs, 4),
				Pack.BE_To_UInt32(bs, 8),
				Pack.BE_To_UInt32(bs, 12)
			};
		}

		// Token: 0x06000065 RID: 101 RVA: 0x000089C8 File Offset: 0x00006BC8
		internal static void Multiply(byte[] block, byte[] val)
		{
			byte[] array = Arrays.Clone(block);
			byte[] array2 = new byte[16];
			for (int i = 0; i < 16; i++)
			{
				byte b = val[i];
				for (int j = 7; j >= 0; j--)
				{
					if (((int)b & 1 << j) != 0)
					{
						GcmUtilities.Xor(array2, array);
					}
					bool flag = (array[15] & 1) > 0;
					GcmUtilities.ShiftRight(array);
					if (flag)
					{
						byte[] array3 = array;
						int num = 0;
						array3[num] ^= 225;
					}
				}
			}
			Array.Copy(array2, 0, block, 0, 16);
		}

		// Token: 0x06000066 RID: 102 RVA: 0x0000460B File Offset: 0x0000280B
		internal static void MultiplyP(uint[] x)
		{
			bool flag = (x[3] & 1U) > 0U;
			GcmUtilities.ShiftRight(x);
			if (flag)
			{
				x[0] ^= 3774873600U;
			}
		}

		// Token: 0x06000067 RID: 103 RVA: 0x00008A44 File Offset: 0x00006C44
		internal static void MultiplyP8(uint[] x)
		{
			uint num = x[3];
			GcmUtilities.ShiftRightN(x, 8);
			for (int i = 7; i >= 0; i--)
			{
				if (((ulong)num & (ulong)(1L << (i & 31))) != 0UL)
				{
					x[0] ^= 3774873600U >> 7 - i;
				}
			}
		}

		// Token: 0x06000068 RID: 104 RVA: 0x00008A8C File Offset: 0x00006C8C
		internal static void ShiftRight(byte[] block)
		{
			int num = 0;
			byte b = 0;
			for (;;)
			{
				byte b2 = block[num];
				block[num] = (byte)(b2 >> 1 | (int)b);
				if (++num == 16)
				{
					break;
				}
				b = (byte)(b2 << 7);
			}
		}

		// Token: 0x06000069 RID: 105 RVA: 0x00008ABC File Offset: 0x00006CBC
		internal static void ShiftRight(uint[] block)
		{
			int num = 0;
			uint num2 = 0U;
			for (;;)
			{
				uint num3 = block[num];
				block[num] = (num3 >> 1 | num2);
				if (++num == 4)
				{
					break;
				}
				num2 = num3 << 31;
			}
		}

		// Token: 0x0600006A RID: 106 RVA: 0x00008AE8 File Offset: 0x00006CE8
		internal static void ShiftRightN(uint[] block, int n)
		{
			int num = 0;
			uint num2 = 0U;
			for (;;)
			{
				uint num3 = block[num];
				block[num] = (num3 >> n | num2);
				if (++num == 4)
				{
					break;
				}
				num2 = num3 << 32 - n;
			}
		}

		// Token: 0x0600006B RID: 107 RVA: 0x00008B1C File Offset: 0x00006D1C
		internal static void Xor(byte[] block, byte[] val)
		{
			for (int i = 15; i >= 0; i--)
			{
				int num = i;
				block[num] ^= val[i];
			}
		}

		// Token: 0x0600006C RID: 108 RVA: 0x00008B48 File Offset: 0x00006D48
		internal static void Xor(uint[] block, uint[] val)
		{
			for (int i = 3; i >= 0; i--)
			{
				block[i] ^= val[i];
			}
		}
	}
}
