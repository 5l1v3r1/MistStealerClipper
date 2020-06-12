using System;
using System.CodeDom.Compiler;
using System.ComponentModel;
using System.Diagnostics;
using System.Globalization;
using System.Resources;
using System.Runtime.CompilerServices;

namespace Mist.Properties
{
	// Token: 0x02000073 RID: 115
	[GeneratedCode("System.Resources.Tools.StronglyTypedResourceBuilder", "16.0.0.0")]
	[DebuggerNonUserCode]
	[CompilerGenerated]
	internal class Resources
	{
		// Token: 0x060002B6 RID: 694 RVA: 0x000042E0 File Offset: 0x000024E0
		internal Resources()
		{
		}

		// Token: 0x1700005C RID: 92
		// (get) Token: 0x060002B7 RID: 695 RVA: 0x00005AD0 File Offset: 0x00003CD0
		[EditorBrowsable(EditorBrowsableState.Advanced)]
		internal static ResourceManager ResourceManager
		{
			get
			{
				if (Resources.resourceMan == null)
				{
					Resources.resourceMan = new ResourceManager("Mist.Properties.Resources", typeof(Resources).Assembly);
				}
				return Resources.resourceMan;
			}
		}

		// Token: 0x1700005D RID: 93
		// (get) Token: 0x060002B8 RID: 696 RVA: 0x00005AFC File Offset: 0x00003CFC
		// (set) Token: 0x060002B9 RID: 697 RVA: 0x00005B03 File Offset: 0x00003D03
		[EditorBrowsable(EditorBrowsableState.Advanced)]
		internal static CultureInfo Culture
		{
			get
			{
				return Resources.resourceCulture;
			}
			set
			{
				Resources.resourceCulture = value;
			}
		}

		// Token: 0x1700005E RID: 94
		// (get) Token: 0x060002BA RID: 698 RVA: 0x00005B0B File Offset: 0x00003D0B
		internal static string Domains
		{
			get
			{
				return Resources.ResourceManager.GetString("Domains", Resources.resourceCulture);
			}
		}

		// Token: 0x1700005F RID: 95
		// (get) Token: 0x060002BB RID: 699 RVA: 0x00005B21 File Offset: 0x00003D21
		internal static byte[] DotNetZip
		{
			get
			{
				return (byte[])Resources.ResourceManager.GetObject("DotNetZip", Resources.resourceCulture);
			}
		}

		// Token: 0x04000173 RID: 371
		private static ResourceManager resourceMan;

		// Token: 0x04000174 RID: 372
		private static CultureInfo resourceCulture;
	}
}
