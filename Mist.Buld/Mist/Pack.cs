using System;

namespace Mist
{
	// Token: 0x02000012 RID: 18
	internal sealed class Pack
	{
		// Token: 0x0600004A RID: 74 RVA: 0x000042E0 File Offset: 0x000024E0
		private Pack()
		{
		}

		// Token: 0x0600004B RID: 75 RVA: 0x000043E2 File Offset: 0x000025E2
		internal static void UInt32_To_BE(uint n, byte[] bs)
		{
			bs[0] = (byte)(n >> 24);
			bs[1] = (byte)(n >> 16);
			bs[2] = (byte)(n >> 8);
			bs[3] = (byte)n;
		}

		// Token: 0x0600004C RID: 76 RVA: 0x00004400 File Offset: 0x00002600
		internal static void UInt32_To_BE(uint n, byte[] bs, int off)
		{
			bs[off] = (byte)(n >> 24);
			bs[++off] = (byte)(n >> 16);
			bs[++off] = (byte)(n >> 8);
			bs[++off] = (byte)n;
		}

		// Token: 0x0600004D RID: 77 RVA: 0x0000442D File Offset: 0x0000262D
		internal static uint BE_To_UInt32(byte[] bs)
		{
			return (uint)((int)bs[0] << 24 | (int)bs[1] << 16 | (int)bs[2] << 8 | (int)bs[3]);
		}

		// Token: 0x0600004E RID: 78 RVA: 0x00004446 File Offset: 0x00002646
		internal static uint BE_To_UInt32(byte[] bs, int off)
		{
			return (uint)((int)bs[off] << 24 | (int)bs[++off] << 16 | (int)bs[++off] << 8 | (int)bs[++off]);
		}

		// Token: 0x0600004F RID: 79 RVA: 0x00008874 File Offset: 0x00006A74
		internal static ulong BE_To_UInt64(byte[] bs)
		{
			ulong num = (ulong)Pack.BE_To_UInt32(bs);
			uint num2 = Pack.BE_To_UInt32(bs, 4);
			return num << 32 | (ulong)num2;
		}

		// Token: 0x06000050 RID: 80 RVA: 0x00008898 File Offset: 0x00006A98
		internal static ulong BE_To_UInt64(byte[] bs, int off)
		{
			ulong num = (ulong)Pack.BE_To_UInt32(bs, off);
			uint num2 = Pack.BE_To_UInt32(bs, off + 4);
			return num << 32 | (ulong)num2;
		}

		// Token: 0x06000051 RID: 81 RVA: 0x0000446E File Offset: 0x0000266E
		internal static void UInt64_To_BE(ulong n, byte[] bs)
		{
			Pack.UInt32_To_BE((uint)(n >> 32), bs);
			Pack.UInt32_To_BE((uint)n, bs, 4);
		}

		// Token: 0x06000052 RID: 82 RVA: 0x00004484 File Offset: 0x00002684
		internal static void UInt64_To_BE(ulong n, byte[] bs, int off)
		{
			Pack.UInt32_To_BE((uint)(n >> 32), bs, off);
			Pack.UInt32_To_BE((uint)n, bs, off + 4);
		}

		// Token: 0x06000053 RID: 83 RVA: 0x0000449D File Offset: 0x0000269D
		internal static void UInt32_To_LE(uint n, byte[] bs)
		{
			bs[0] = (byte)n;
			bs[1] = (byte)(n >> 8);
			bs[2] = (byte)(n >> 16);
			bs[3] = (byte)(n >> 24);
		}

		// Token: 0x06000054 RID: 84 RVA: 0x000044BB File Offset: 0x000026BB
		internal static void UInt32_To_LE(uint n, byte[] bs, int off)
		{
			bs[off] = (byte)n;
			bs[++off] = (byte)(n >> 8);
			bs[++off] = (byte)(n >> 16);
			bs[++off] = (byte)(n >> 24);
		}

		// Token: 0x06000055 RID: 85 RVA: 0x000044E8 File Offset: 0x000026E8
		internal static uint LE_To_UInt32(byte[] bs)
		{
			return (uint)((int)bs[0] | (int)bs[1] << 8 | (int)bs[2] << 16 | (int)bs[3] << 24);
		}

		// Token: 0x06000056 RID: 86 RVA: 0x00004501 File Offset: 0x00002701
		internal static uint LE_To_UInt32(byte[] bs, int off)
		{
			return (uint)((int)bs[off] | (int)bs[++off] << 8 | (int)bs[++off] << 16 | (int)bs[++off] << 24);
		}

		// Token: 0x06000057 RID: 87 RVA: 0x000088C0 File Offset: 0x00006AC0
		internal static ulong LE_To_UInt64(byte[] bs)
		{
			uint num = Pack.LE_To_UInt32(bs);
			return (ulong)Pack.LE_To_UInt32(bs, 4) << 32 | (ulong)num;
		}

		// Token: 0x06000058 RID: 88 RVA: 0x000088E4 File Offset: 0x00006AE4
		internal static ulong LE_To_UInt64(byte[] bs, int off)
		{
			uint num = Pack.LE_To_UInt32(bs, off);
			return (ulong)Pack.LE_To_UInt32(bs, off + 4) << 32 | (ulong)num;
		}

		// Token: 0x06000059 RID: 89 RVA: 0x00004529 File Offset: 0x00002729
		internal static void UInt64_To_LE(ulong n, byte[] bs)
		{
			Pack.UInt32_To_LE((uint)n, bs);
			Pack.UInt32_To_LE((uint)(n >> 32), bs, 4);
		}

		// Token: 0x0600005A RID: 90 RVA: 0x0000453F File Offset: 0x0000273F
		internal static void UInt64_To_LE(ulong n, byte[] bs, int off)
		{
			Pack.UInt32_To_LE((uint)n, bs, off);
			Pack.UInt32_To_LE((uint)(n >> 32), bs, off + 4);
		}
	}
}
