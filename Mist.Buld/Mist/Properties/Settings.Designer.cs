using System;
using System.CodeDom.Compiler;
using System.Configuration;
using System.Runtime.CompilerServices;

namespace Mist.Properties
{
	// Token: 0x02000072 RID: 114
	[CompilerGenerated]
	[GeneratedCode("Microsoft.VisualStudio.Editors.SettingsDesigner.SettingsSingleFileGenerator", "16.5.0.0")]
	internal sealed partial class Settings : ApplicationSettingsBase
	{
		// Token: 0x1700005B RID: 91
		// (get) Token: 0x060002B3 RID: 691 RVA: 0x00005AAB File Offset: 0x00003CAB
		public static Settings Default
		{
			get
			{
				return Settings.defaultInstance;
			}
		}

		// Token: 0x04000172 RID: 370
		private static Settings defaultInstance = (Settings)SettingsBase.Synchronized(new Settings());
	}
}
